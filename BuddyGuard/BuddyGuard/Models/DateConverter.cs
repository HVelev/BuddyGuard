using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BuddyGuard.API.Models
{
    public class DateConverter : JsonConverter<DateTime>
    {
        private string formatDate = "yyyy-MM-ddTHH:mm:ss.SSS";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                var date = DateTime.ParseExact(jsonDoc.RootElement.GetRawText(), formatDate, CultureInfo.InvariantCulture);
                return date;
            }
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(formatDate));
        }
    }
}
