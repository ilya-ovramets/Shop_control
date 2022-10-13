namespace Shop_control.Converter
{
    public class Shop_converter : JsonConverter<Shops>
    {
        public override Shops? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {


            return new Shops();
        }

        public override void Write(Utf8JsonWriter writer, Shops value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WriteNumber("shop_id", value.shop_id);
            
            writer.WriteString("name", value.shop_name);
            
            writer.WriteString("shop_phone", value.shop_phone_number);

            writer.WriteString("open_time", value.open_time.ToString());
            
            writer.WriteString("close_time", value.close_time.ToString());
            
            writer.WriteEndObject();

        }
    }
}
