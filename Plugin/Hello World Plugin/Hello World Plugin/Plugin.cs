using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Configuration;
using Kitchen;
using Kitchen.Modules;
using UnityEngine;
using System.Reflection;
using KitchenLib;
using KitchenLib.Event;


namespace Plugin
{
    //[BepInPlugin("Dino.first.plugin", "Test Plugin", "3.0")] //plugin描述  ID.名子.版本
    [BepInProcess("PlateUp.exe")]
    [BepInPlugin("Dino.test.plugin", "Test Plugin", "1.0.0")]
    public class Plugin : BaseMod //繼承
    {
        public Plugin() : base("Dino.test.plugin", "Test Plugin", "Dino", "1.0.0", ">=1.1.1", Assembly.GetExecutingAssembly()) { }

        //protected override void OnFrameUpdate() { }

        //protected override void OnInitialise() { }

        /*
        ConfigEntry<int> intConfig;
        ConfigEntry<string> stringConfig;
        void Awake()
        {
            Logger.LogInfo("Hello World!"); //log print

            show in option, key name in file, default value, description
            intConfig = Config.Bind<int>("config", "TestInt", 20, "測試用整數");
            stringConfig = Config.Bind<string>("config", "TestString", "Hello World!!", "測試用字串");

            Logger.LogInfo("int " + intConfig.Value);
            Logger.LogInfo("string " + stringConfig.Value);
        }*/

        private void initMainMenu()
        {
            //Events.PreferenceMenu_MainMenu_SetupEvent = ;

            Events.PreferenceMenu_PauseMenu_CreateSubmenusEvent += (s, args) => {
                args.Menus.Add(typeof(TestMenu<MainMenuAction>), null);
            };
            ModsPreferencesMenu<MainMenuAction>.RegisterMenu("TTTTTT Menu", typeof(TestMenu<MainMenuAction>), typeof(MainMenuAction));

        }



    }

    internal class TestMenu<T> : KLMenu<T> 
    {
        public TestMenu(Transform container, ModuleList Module_list) : base(container, Module_list)
        {

        }


    }
}
