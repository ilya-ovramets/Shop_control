var builder = WebApplication.CreateBuilder(args);



var app = builder.Build();




app.Run(async context =>
{
    var response = context.Response;
    var request = context.Request;
    var path = request.Path;

    if (path == "/api/shops" && request.Method == "GET")
    {
        await GetAllShop(response);
    }
    else if (path == "/api/positions" && request.Method == "GET")
    {
        await GetAllPositions(response);

    }
    else if (path == "/api/employee" && request.Method == "POST")
    {
        await CreateEmployee(response, request);
    }
    else if (path == "/api/customer" && request.Method == "POST")
    {
        await CreateCustomer(response, request);
    }
    else if (path == "/Person")
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

async Task CreateEmployee(HttpResponse response, HttpRequest request)
{
    
    try
    {
        var jsonoptions = new JsonSerializerOptions();
        jsonoptions.Converters.Add(new PersonConverter());
        var employee = await request.ReadFromJsonAsync<Employees>(jsonoptions);
        Console.WriteLine(employee);
        if (employee != null)
        {
            Console.WriteLine("employe != null");
            Console.WriteLine(employee);
            using (ApplicationContext db = new ApplicationContext())
            {
                db.persons.Add(employee?.Persons);
                Employees employees = new Employees { corp_email = employee.corp_email, Persons = employee.Persons, shop_id = employee.shop_id, position_id = employee.position_id };
                db.employees.Add(employees);
                db.SaveChanges();
                Console.WriteLine("Данні збережено");

            }

            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    var persons = db.persons.ToList();

                
            //    db.SaveChanges();
            //}
        }
    }
    catch (Exception)
    {
        response.StatusCode = 400;
        await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
    }

}

//async Task CreatePerson(HttpResponse response, HttpRequest request)
//{
//    try
//    {
//        var jsonoptions = new JsonSerializerOptions();
//        jsonoptions.Converters.Add(new PersonConverter());

//        // получаем данные пользователя
//        var user = await request.ReadFromJsonAsync<Persons>(jsonoptions);


//        if (user != null)
//        {
//            using (ApplicationContext db = new ApplicationContext())
//            {

//                db.persons.Add(user);
//                db.SaveChanges();
//                Console.WriteLine("Запис додано");
//            }
//        }
//        else
//        {
//            throw new Exception("Некорректные данные");
//        }
//    }
//    catch (Exception)
//    {
//        response.StatusCode = 400;
//        await response.WriteAsJsonAsync(new { message = "Некорректные данные" });
//    }
//}


async Task CreateCustomer(HttpResponse response, HttpRequest request)
{
    using (ApplicationContext db = new ApplicationContext())
    {
        var positions = db.positions.ToList();

        await response.WriteAsJsonAsync(positions);

    }
}


async Task GetAllShop(HttpResponse response)
{
    var jsonoptions = new JsonSerializerOptions();
    jsonoptions.Converters.Add(new Shop_converter());

    using (ApplicationContext db = new ApplicationContext())
    {
        var shops = db.shops.ToList();

        await response.WriteAsJsonAsync(shops, jsonoptions);

    }
}

async Task GetAllPositions(HttpResponse response)
{
    using (ApplicationContext db = new ApplicationContext())
    {
        var positions = db.positions.ToList();

        await response.WriteAsJsonAsync(positions);

    }
}

