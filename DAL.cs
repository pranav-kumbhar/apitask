
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class DAL
    {
       public static async void GetEntries()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://api.publicapis.org/entries");
            var responseContent = await response.Content.ReadAsStringAsync();
            var apiData = JsonConvert.DeserializeObject<Root>(responseContent);
            var data = apiData.entries.ToList(); 
            string filePath = @"E:\Temp\Entries.txt";
            Console.WriteLine("Record insert Starts...");
            foreach (var item in data)
            {
                string texts = $" API: {item.API} \n Description: {item.Description} \n Auth:{item.Auth} \n HTTPS: {item.HTTPS} \n Cors:{item.Cors} \n Link:{item.Link} \n Category: {item.Category} \n \n \n \n";            
                File.AppendAllText(filePath, texts);               
            }
            string readText = File.ReadAllText(filePath);
            Console.WriteLine(readText);
            Console.WriteLine("Record insert Ends ...");
        }
    }
}
