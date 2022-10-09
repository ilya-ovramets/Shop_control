using System.Text.Json.Serialization;
using System.Text.Json;
using Shop_control.Data_base;
using System;

namespace Shop_control
{
    public class PersonConverter : JsonConverter<Persons>
    {
        public override Persons Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            var fname = "Undefined";
            var sname = "Undefined";
            var lname = "Undefined";
            DateOnly? birthday = null;
            var phone_number = "Undefined";
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
                                if (String.IsNullOrWhiteSpace(reader.GetString()))
                                {
                                    break;
                                }
                                birthday = DateOnly.Parse(reader.GetString());
                                break;
                            case "phone_number" when reader.TokenType == JsonTokenType.String:
                                phone_number = reader.GetString();
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
                if (birthday == null || String.IsNullOrWhiteSpace(fname) || String.IsNullOrWhiteSpace(sname) || String.IsNullOrWhiteSpace(lname) || String.IsNullOrWhiteSpace(phone_number))
                {
                    // Add loger before
                    Console.WriteLine("Exception");
                    return null;
                    throw new Exception();
                }
            }
            catch
            {
                Console.WriteLine("Ви ввели не всі данні!");
            }
            

            return new Persons() {first_name = fname,second_name = sname,last_name = lname,birthday = birthday , phone_number = phone_number};
        }
        
        // сериализуем объект Person в json
        public override void Write(Utf8JsonWriter writer, Persons person, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("first_name", person.first_name);
            writer.WriteString("second_name", person.second_name);
            writer.WriteString("last_name", person.last_name);
            if (person.birthday != null)
            {
                writer.WriteString("birthday", person.birthday.ToString());
            }
            writer.WriteString("phone_number", person.last_name);
            writer.WriteEndObject();
        }

        
    }
}
