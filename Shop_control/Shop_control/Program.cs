using Shop_control;
using Shop_control.Data_base;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();




app.Run(async context =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;

    if (path == "/api/users" && request.Method == "POST")
    {
        await CreatePerson(response, request);
    }
    if (path == "/api/shops" && request.Method == "GET")
    {
        await GetAllShop(response);
    }

    if (path == "/Person")
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync(".//HTML//Person.html");
    }
    else
    {
        context.Response.ContentType = "text/html";
        await context.Response.SendFileAsync(".//HTML//meny.html");
    }
});



app.Run();



async Task CreatePerson(HttpResponse response, HttpRequest request)
{
    try
    {
        var jsonoptions = new JsonSerializerOptions();
        jsonoptions.Converters.Add(new PersonConverter());

        // получаем данные пользователя
        var user = await request.ReadFromJsonAsync<Persons>(jsonoptions);
        Console.WriteLine(user);
        
        if (user != null)
        {
            using (ApplicationContext db = new ApplicationContext()) 
            {
                
                My(user);
                db.persons.Add(user);
                db.SaveChanges();
                Console.WriteLine("Запис додано");
            }
        }
        else
        {
            throw new Exception("Некорректные данные");
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
    }
}


async Task GetAllShop(HttpResponse response)
{
    using (ApplicationContext db = new ApplicationContext())
    {
        var shops = db.shops.ToList();

        await response.WriteAsJsonAsync(shops);
    }
}


void My(Persons set_date)
{
    var item = set_date;
    Console.WriteLine($"ID:{item.person_id},Name {item.first_name} {item.second_name} {item.last_name}" +
            $"Phone: {item.phone_number} Birthday:{item.birthday.ToString()}");
    
}