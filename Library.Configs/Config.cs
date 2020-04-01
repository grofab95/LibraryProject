using System;
using System.IO;

namespace Library.Configs
{
    public class Config
    {
        public string DbConection { get; set; }
        public string TokenSecret { get; set; }

        public static Config Get()
        {
            var configPath = Path.GetFullPath(@"..\Library.Configs\config.json");

            if (!File.Exists(configPath))
            {
                throw new Exception("Config file not exist!");
            }

            var config = File.ReadAllText(configPath);
            return JsonUtility.ParseToObject<Config>(config);
        }
    }
}
