using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Configuration;

namespace Plugin
{
    [BepInPlugin("Dino.first.plugin", "Test Plugin", "1.0")] //plugin描述  ID.名子.版本
    public class Plugin : BaseUnityPlugin //繼承
    {
        ConfigEntry<int> intConfig;
        ConfigEntry<string> stringConfig;
        void Awake()
        {
            Logger.LogInfo("Hello World!"); //log print

            //show in option, key name in file, default value, description
            intConfig = Config.Bind<int>("config", "TestInt", 20, "測試用整數");
            stringConfig = Config.Bind<string>("config", "TestString", "Hello World!!", "測試用字串");

            Logger.LogInfo("int " + intConfig.Value);
            Logger.LogInfo("string " + stringConfig.Value);
        }

        

        void Start()
        {
            Logger.LogInfo("plugin is success");
        }
        void OnDestory()
        {
            Logger.LogInfo("plugin is success");
        }
    }
}
