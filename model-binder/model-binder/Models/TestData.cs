using System.Collections.Generic;
using System.ComponentModel;

namespace model_binder.Models
{
    [TypeConverter(typeof(TestTypeConverter))]
    public class TestData
    {
        public List<string> Message { get; set; }

        public static bool TryParse(string s, out TestData result)
        {
            result = null;

            var parts = s.Split(',');
            var list = new List<string>();
            foreach (var part in parts)
            {
                list.Add(part);
            }

            result = new TestData {Message = list};
  
            return true;
        }
    }
}