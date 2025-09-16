using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ODMO.Infrastructure.Converters
{
    public class ByteArrayToStringConverter : ValueConverter<byte[], string>
    {
        public ByteArrayToStringConverter()
            : base(
                v => string.Join(";", v),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries)
                .Select(val => byte.Parse(val))
                .ToArray())
        {
        }
    }
}
