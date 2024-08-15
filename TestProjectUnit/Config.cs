using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TestProjectUnit
{
    public class Config
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public static Config Load(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Config>(json);
        }
    }
}
