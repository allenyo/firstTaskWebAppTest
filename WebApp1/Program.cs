using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApp1;
using WebApp1.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

WebCall.Instance();

var converter = new ModelConverter();



string data1 = WebCall.GetUser().Result;
string data2 = WebCall.GetUser("alen").Result;
string data3 = WebCall.GetUser(2).Result;

var listBackusers = JsonConvert.DeserializeObject<List<BackUser>>(data1);
 
var listUsers = new List<User>();
 
if (listBackusers != null)
foreach (var item in listBackusers)
{
    listUsers.Add(converter.OutToUser(item));   
}

var updateData = new JObject();

updateData.Add("user", listUsers[1].ToString());
updateData.Add("fname", "Ahasarsur");

await WebCall.UpdateUser(updateData);


app.Run(async context =>
    {
        await context.Response.WriteAsync(data1);  

    });

app.Run();










