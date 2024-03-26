using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MonkeyHead
{
    internal class Butan:MonoBehaviour
    {
        public string button;
        void Start()
        {
            button = transform.name;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out GorillaTriggerColliderHandIndicator component))
            {
                switch (button)
                {
                    case "Blue":
                        Plugin.ChangeColour(Color.blue);
                        break;

                    case "Green":
                        Plugin.ChangeColour(Color.green);
                        break;

                    case "Red":
                        Plugin.ChangeColour(Color.red);
                        break;

                    case "Grey":
                        Plugin.ChangeColour(Color.grey);
                        break;

                    case "Enable":
                        Plugin.thingEnabled = ! Plugin.thingEnabled;
                        break;
                }
            }
        }

    }
}
