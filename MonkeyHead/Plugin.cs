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
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;

        static GameObject thing;

        GameObject Blue,
                   Green,
                   Red,
                   Enable,
                   Grey;

        GameObject pizza;

        void Start()
        {
            /* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */

            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        public static void ChangeColour(Color colour)
        {
            thing.transform.GetChild(0).GetComponent<Renderer>().material.color = colour;
            thing.transform.GetChild(1).GetComponent<Renderer>().material.color = colour;
            thing.transform.GetChild(2).GetComponent<Renderer>().material.color = colour;
        }

        bool isEnabled;
        public static bool thingEnabled = true;
        void Update()
        {
            if (Keyboard.current.tabKey.wasPressedThisFrame) isEnabled = !isEnabled;
            thing.SetActive(thingEnabled);
            pizza.GetComponent<Renderer>().enabled = !thingEnabled;
        }

        void OnGUI()
        {
            if (isEnabled)

            {
                if (GUI.Button(new Rect(25, 420, 250, 25), "Enable/Disable"))
                {
                    Debug.Log("wow you pressed a button");
                    thingEnabled =!thingEnabled;

                }

                if (GUI.Button(new Rect(25, 370, 250, 25), "Grey"))
                {
                    Debug.Log("wow you pressed a button");
                    ChangeColour(Color.grey);

                }

                if (GUI.Button(new Rect(25, 310, 250, 25), "Red"))
                {
                    Debug.Log("wow you pressed a button");
                    ChangeColour(Color.red);

                }
                if (GUI.Button(new Rect(25, 280, 250, 25), "Green"))
                {
                    Debug.Log("wow you pressed a button");
                    ChangeColour(Color.green);

                }
                if (GUI.Button(new Rect(25, 340, 250, 25), "Blue"))
                {
                    Debug.Log("wow you pressed a button");
                    ChangeColour(Color.blue);

                }
            }
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
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }

        
        
    }
}
