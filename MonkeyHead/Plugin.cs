using BepInEx;
using GorillaExtensions;
using Photon.Voice;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilla;

namespace MonkeyHead
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static bool thingEnabled = true;

        static GameObject greenscreen;

        GameObject Blue,
                   Green,
                   Red,
                   Enable,
                   Grey;

        GameObject pizza;

        GameObject table;

        void Start() => Events.GameInitialized += OnGameInitialized;

        public static void ChangeColour(Color colour)
        {
            greenscreen.transform.GetChild(0).GetComponent<Renderer>().material.color = colour;
            greenscreen.transform.GetChild(1).GetComponent<Renderer>().material.color = colour;
            greenscreen.transform.GetChild(2).GetComponent<Renderer>().material.color = colour;
            greenscreen.transform.GetChild(3).GetComponent<Renderer>().material.color = colour;
        }

        GameObject CreateButan(Color color, String name, float x, float y, float z)
        {
            GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            temp.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
            temp.transform.localScale = new Vector3(0.13f, 0.1f, 0.13f);
            temp.transform.position = new Vector3(x, y, z);
            temp.transform.localRotation = Quaternion.Euler(0f, 30f, 0f);
            temp.layer = 18;
            temp.AddComponent<Butan>();
            temp.GetComponent<Renderer>().material.color = color;
            temp.name = name;
            return temp;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {

            greenscreen = GameObject.Instantiate(LoadAssetBundle("MonkeyHead.Assets.greenscreen").LoadAsset<GameObject>("greenscreen"));
            greenscreen.transform.localPosition = new Vector3(-48.1722f, 14.5121f, -126.4994f);
            greenscreen.transform.localScale = new Vector3(0.4f, 0.4f, 0.34f);
            greenscreen.transform.localRotation = Quaternion.Euler(0f, 210f, 0f);

            Blue = CreateButan(Color.blue, "Blue", -56.32f, 16.8134f, -120.7547f);

            Green = CreateButan(Color.green, "Green", -56.11f, 16.8134f, -120.8746f);

            Red = CreateButan(Color.red, "Red", -55.9f, 16.8134f, -120.9946f);

            Grey = CreateButan(Color.grey, "Grey", -55.69f, 16.8134f, -121.1246f);

            Enable = CreateButan(Color.white, "Enable", -56.52f, 16.7734f, -120.6846f);

            pizza = GameObject.Find("Environment Objects/LocalObjects_Prefab/City/CosmeticsRoomAnchor/ShoppingCenterAnchor/Stuff/Empty Stuff/table (1)");

            table = GameObject.Instantiate(LoadAssetBundle("MonkeyHead.Assets.table").LoadAsset<GameObject>("table"));
            table.transform.localPosition = new Vector3(-55.9767f, 16.7594f, -120.7577f);
            table.transform.localScale = new Vector3(0.3f, 0.4f, 0.3f);
            table.transform.localRotation = Quaternion.Euler(0f, 120.1824f, 0f);
        }

        public AssetBundle LoadAssetBundle(string path)
        {
            Assembly.GetExecutingAssembly().GetManifestResourceStream(path).Close();
            return AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(path));
        }

        void Update()
        {
            greenscreen.SetActive(thingEnabled);
            pizza.GetComponent<Renderer>().enabled = !thingEnabled;
        }
    }
}
