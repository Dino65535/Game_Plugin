using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;

namespace Plugin
{
    [BepInPlugin("Dino.first.plugin", "Test Plugin", "8.0")] //plugin描述  ID.名子.版本
    public class TestPlugin : BaseUnityPlugin //繼承
    {
        void Awake()
        {
            Logger.LogInfo("Hello World"); //log print
        }
    }
}
