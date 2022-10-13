

namespace Shop_control.Converter
{
    public class PersonConverter : JsonConverter<Employees>
    {
        public override Employees Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            var fname = "Undefined";
            var sname = "Undefined";
            var lname = "Undefined";
            DateOnly? birthday = null;
            var phone_number = "Undefined";
            var email = "Undefined";
            var shop_id = 0;
            var position_id = 0;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    try
                    {
                        var propertyName = reader.GetString();
                        reader.Read();
                        switch (propertyName?.ToLower())
                        {
                            case "first_name" when reader.TokenType == JsonTokenType.String:
                                fname = reader.GetString();
                                break;
                            case "second_name" when reader.TokenType == JsonTokenType.String:
                                sname = reader.GetString();
                                break;
                            case "last_name" when reader.TokenType == JsonTokenType.String:
                                lname = reader.GetString();
                                break;
                            case "birtdhday":
                                if (string.IsNullOrWhiteSpace(reader.GetString()))
                                {
                                    break;
                                }
                                birthday = DateOnly.Parse(reader.GetString());
                                break;
                            case "phone_number" when reader.TokenType == JsonTokenType.String:
                                phone_number = reader.GetString();
                                break;
                            case "email" when reader.TokenType == JsonTokenType.String:
                                email = reader.GetString();
                                break;
                            case "shop_id" when reader.TokenType == JsonTokenType.String:

                                string? shop_ID = reader.GetString();

                                if (int.TryParse(shop_ID, out int inter))
                                {
                                    shop_id = inter;
                                }
                                break;

                            case "position_id" when reader.TokenType == JsonTokenType.String:
                                
                                string? position_ID = reader.GetString();
                                
                                // try convert string to int
                                if (int.TryParse(position_ID, out int inter2))
                                {
                                    position_id = inter2;
                                }
                                break;

                        }
                    }
                    catch
                    {
                        Console.WriteLine("date Eroor");
                    }
                }
            }
            try
            {
                if (birthday == null || string.IsNullOrWhiteSpace(fname) || string.IsNullOrWhiteSpace(sname) || string.IsNullOrWhiteSpace(lname) || string.IsNullOrWhiteSpace(phone_number))
                {
                    // Add loger before
                    Console.WriteLine("Exception");
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("Ви ввели не всі данні!");
            }


            return new Employees { persons = new Persons { first_name = fname, second_name = sname, last_name = lname, birthday = birthday, phone_number = phone_number }, shop_id = shop_id, corp_email = email, position_id = position_id };
        }

        // сериализуем объект Person в json
        public override void Write(Utf8JsonWriter writer, Employees employees, JsonSerializerOptions options)
        {
            var person = employees.persons;
            writer.WriteStartObject();
            writer.WriteString("first_name", person?.first_name);
            writer.WriteString("second_name", person?.second_name);
            writer.WriteString("last_name", person?.last_name);
            if (person?.birthday != null)
            {
                writer.WriteString("birthday", person?.birthday.ToString());
            }
            writer.WriteString("phone_number", person?.last_name);
            writer.WriteEndObject();
        }


    }
}
