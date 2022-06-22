using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class ClientState : MonoBehaviour
    {
        // bike controller to control bike
        private BikeController _bikeController;

        void Start()
        {
            // instantiate bike controller
            _bikeController =
                (BikeController)
                FindObjectOfType(typeof(BikeController));
        }

        // Create buttons to control the bike.
        void OnGUI()
        {
            // start bike if click start bike
            if (GUILayout.Button("Start Bike", GUILayout.Width(150), GUILayout.Height(50)))
            {
                _bikeController.StartBike();
            }

            // move bike forward if click forward
            if (GUILayout.Button("Forward", GUILayout.Width(150), GUILayout.Height(50)))
            {
                _bikeController.MoveBike(Direction.Forward);
            }

            // move bike backwards if click reverse
            if (GUILayout.Button("Reverse", GUILayout.Width(150), GUILayout.Height(50)))
            {
                _bikeController.MoveBike(Direction.Reverse);
            }

            // stop bike if click stop bike
            if (GUILayout.Button("Stop Bike", GUILayout.Width(150), GUILayout.Height(50)))
            {
                _bikeController.StopBike();
            }

        }
    }
}
