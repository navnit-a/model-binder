using System;
using System.ComponentModel;
using System.Globalization;

namespace model_binder.Models
{
    public class TestTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                TestData data;
                if (TestData.TryParse((string)value, out data))
                {
                    return data;
                }
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}