using CsvHelper;
using System.Collections;
using System.Dynamic;
using System.Globalization;
using System.Reflection;

namespace Community.Services
{
    public class ExportService : IExportService
    {
        private readonly IAreaService _areaService;
        public ExportService(IAreaService areaService)
        {
            _areaService = areaService;
        }
        public async Task<bool> Run()
        {
            try
            {
                var records = await _areaService.All();

                var expandos = new List<dynamic>();

                // Convert to Expando object
                foreach (var record in records)
                {
                    var expando = new ExpandoObject();
                    var dictionary = (IDictionary<string, object>)expando;

                    foreach (var property in record.GetType().GetProperties())
                    {
                        var currentField = GetValueOrExpandoObject(record, property);
                        if (currentField is IEnumerable enumerable && currentField is not string)
                        {
                            var enumerator = enumerable.GetEnumerator();
                            var count = 1;
                            while (enumerator.MoveNext())
                            {
                                var child = (IDictionary<string, object>)enumerator.Current;
                                foreach (KeyValuePair<string, object> kvp in child)
                                    dictionary.TryAdd($"{kvp.Key}_{count}", kvp.Value);
                                count++;
                            }
                        }
                        else
                        {
                            dictionary.Add(property.Name, currentField);
                        }
                    }
                    expandos.Add(dictionary);
                }

                using (TextWriter writer = new StreamWriter(@"C:\Users\rujin\Documents\workspace\test.csv", false, System.Text.Encoding.UTF8))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(expandos);
                    writer.ToString();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public object GetValueOrExpandoObject(object @object, PropertyInfo property)
        {
            var value = property.GetValue(@object);
            if (value == null) return null;

            var valueType = value.GetType();
            if (valueType.IsValueType || value is string) return value;

            if (value is IEnumerable enumerable) return ToExpandoCollection(enumerable);

            return ToExpando(value);
        }

        public ExpandoObject ToExpando(object @object)
        {
            var properties = @object.GetType().GetProperties();
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (var property in properties)
            {
                var value = GetValueOrExpandoObject(@object, property);
                expando.Add(property.Name, value);
            }
            return (ExpandoObject)expando;
        }

        public IEnumerable<ExpandoObject> ToExpandoCollection(IEnumerable enumerable)
        {
            var enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return ToExpando(enumerator.Current);
            }
        }
    }
}