using dnd_manager_webapplication.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

var wc = new WebClient();
var data = JsonConvert.DeserializeObject<List<Character>>(wc.DownloadString("http://localhost:7193/api"));

foreach (var item in data)
{
    Console.WriteLine(item.Name + " " + item.Level + " " + item.Race + " " + item.Class);
}