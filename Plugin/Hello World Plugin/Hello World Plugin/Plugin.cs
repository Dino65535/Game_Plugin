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
using System.ComponentModel;
using Unity.Entities;
using Unity.Collections;
using JetBrains.Annotations;

namespace Plugin
{
    //[BepInProcess("PlateUp.exe")]
    //[BepInPlugin("Dino.test.plugin", "Test Plugin", "0.0.1")]
    public class Plugin : BaseMod
    {
        public Plugin() : base("Dino.test.plugin", "Test Plugin", "Dino", "0.0.7", ">=0.0.0", Assembly.GetExecutingAssembly()) { }
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
        public static bool isRegistered = false;
        public static int PlayerLevels;
        public static int Level = 2;

        protected override void Initialise()
        {
            base.Initialise();

            if (!isRegistered)
            {
                //Registering
                Events.PreferenceMenu_PauseMenu_CreateSubmenusEvent += (s, args) => {
                    args.Menus.Add(typeof(TestMenu<PauseMenuAction>), new TestMenu<PauseMenuAction>(args.Container, args.Module_list));
                };
                //Adding
                ModsPreferencesMenu<PauseMenuAction>.RegisterMenu("Dino Pause Test Menu", typeof(TestMenu<PauseMenuAction>), typeof(PauseMenuAction));


                //Registering
                Events.PreferenceMenu_MainMenu_CreateSubmenusEvent += (s, args) =>
                {
                    args.Menus.Add(typeof(TestMenu<MainMenuAction>), new TestMenu<MainMenuAction>(args.Container, args.Module_list));
                };
                //Adding
                ModsPreferencesMenu<MainMenuAction>.RegisterMenu("Dino Main Test Menu", typeof(TestMenu<MainMenuAction>), typeof(MainMenuAction));

                isRegistered = true;
                
            }
            
            /*Events.PreferenceMenu_PauseMenu_CreateSubmenusEvent += (s, args) => {
                args.Menus.Add(typeof(TestMenu<MainMenuAction>), new TestMenu<MainMenuAction>(args.Container, args.Module_list));
                args.Menus.Add(typeof(TestMenu<PauseMenuAction>), new TestMenu<PauseMenuAction>(args.Container, args.Module_list));
            };*/
        }
    }

    internal class TestMenu<T> : KLMenu<T>
    {
        public TestMenu(Transform container, ModuleList Module_list) : base(container, Module_list)
        {
            
        }
        public override void Setup(int player_id)
        {       
            AddLabel("player level is : " + Plugin.Level);

            New<SpacerElement>(true);//end line
            New<SpacerElement>(true);
            
            AddButton("Back to Menu", delegate
            {
                base.RequestPreviousMenu();
            }, 0, 1f, 0.2f);
        }

    }

    public class ChangeExp : GameSystemBase
    {
        private EntityQuery PlayerLevelsQuery;
        private SPlayerLevel player;
        protected override void Initialise()
        {
            Debug.LogWarning("Work!!!");
            base.Initialise();
        }

        protected override void OnUpdate() 
        {
            PlayerLevelsQuery = base.GetEntityQuery(new ComponentType[] { typeof(SPlayerLevel) });
            player = PlayerLevelsQuery.GetSingleton<SPlayerLevel>();
            Plugin.Level = player.Level;
            Debug.LogWarning("Work!!!!!!!!!!!!!!!!");
        } 
    }
}
