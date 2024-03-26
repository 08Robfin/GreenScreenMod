using BepInEx;
using GorillaExtensions;
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

        static GameObject thing;

        GameObject Blue,
                   Green,
                   Red,
                   Enable,
                   Grey;

        GameObject pizza;

        void Start() => Events.GameInitialized += OnGameInitialized;

        public static void ChangeColour(Color colour)
        {
            thing.transform.GetChild(0).GetComponent<Renderer>().material.color = colour;
            thing.transform.GetChild(1).GetComponent<Renderer>().material.color = colour;
            thing.transform.GetChild(2).GetComponent<Renderer>().material.color = colour;
        }

        void Update()
        {
            thing.SetActive(thingEnabled);
            pizza.GetComponent<Renderer>().enabled = !thingEnabled;
        }

        GameObject CreateButan(Color color, String name, float x, float z)
        {
            GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            temp.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
            temp.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            temp.transform.position = new Vector3(x, 16.8034f, z);
            temp.transform.localRotation = Quaternion.Euler(0f, 30f, 0f);
            temp.layer = 18;
            temp.AddComponent<Butan>();
            temp.GetComponent<Renderer>().material.color = color;
            temp.name = name;
            return temp;
        }

        GameObject CreateButan(Color color, String name, float x, float z, float y)
        {
            GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
            temp.GetComponent<Renderer>().material.shader = Shader.Find("GorillaTag/UberShader");
            temp.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
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
            var bundle = LoadAssetBundle("MonkeyHead.Assets.greenscreen");
            thing = bundle.LoadAsset<GameObject>("greenscreen");
            thing = GameObject.Instantiate(thing);
            thing.transform.localPosition = new Vector3(-48.2222f, 14.5121f, -126.7394f);
            thing.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            thing.transform.localRotation = Quaternion.Euler(0f, 210f, 0f);

            Blue = CreateButan(Color.blue, "Blue", -56.3f, -120.2246f);

            Green = CreateButan(Color.green, "Green", -56, -120.4046f);

            Red = CreateButan(Color.red, "Red", -55.7f, -120.5746f);

            Grey = CreateButan(Color.grey, "Grey", -55.4f, -120.7446f);

            Enable = CreateButan(Color.white, "Enable", -56.3013f, -120.2246f, 17.1534f);

            pizza = GameObject.Find("Environment Objects/LocalObjects_Prefab/City/CosmeticsRoomAnchor/ShoppingCenterAnchor/Stuff/Empty Stuff/table (1)");
        }

        public AssetBundle LoadAssetBundle(string path)
        {
            Assembly.GetExecutingAssembly().GetManifestResourceStream(path).Close();
            return AssetBundle.LoadFromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream(path));
        }
    }
}
