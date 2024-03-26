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

        GameObject thing;

        void Start()
        {
            /* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */

            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void ChangeColour(Color colour)
        {
            thing.transform.GetChild(0).GetComponent<Renderer>().material.color = colour;
            thing.transform.GetChild(1).GetComponent<Renderer>().material.color = colour;
            thing.transform.GetChild(2).GetComponent<Renderer>().material.color = colour;
        }

        bool isEnabled;
        void Update()
        {
            if (Keyboard.current.tabKey.wasPressedThisFrame) isEnabled = !isEnabled;
        }

        void OnGUI()
        {
            if (isEnabled)
            {
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

      


        void OnGameInitialized(object sender, EventArgs e)
        {
            var bundle = LoadAssetBundle("MonkeyHead.Assets.greenscreen");
            thing = bundle.LoadAsset<GameObject>("greenscreen");
            thing = GameObject.Instantiate(thing);
            thing.transform.localPosition = new Vector3(-48.2222f, 14.5121f, -126.7394f);
            thing.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            thing.transform.localRotation = Quaternion.Euler(0f, 210f, 0f);

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
