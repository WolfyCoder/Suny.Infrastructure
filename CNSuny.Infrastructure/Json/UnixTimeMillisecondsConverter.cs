using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNSuny.Infrastructure.Json
{
    /// <summary>
    /// unix 时间戳转换
    /// </summary>
    public class UnixTimeMillisecondsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(Nullable<DateTime>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Integer)
            {
                throw new Exception($"Unexpected token parsing DateTime. Expected String.get{reader.TokenType}");
            }
            var value = (long)reader.Value;
            return DateTimeOffset.FromUnixTimeMilliseconds(value).LocalDateTime;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, new DateTimeOffset(Convert.ToDateTime(value.ToString())).ToUnixTimeMilliseconds());
        }
    }
}
