using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class BikeTurnState : MonoBehaviour, IBikeState
    {
        // new direcction for bike
        private Vector3 _turnDirection;
        // to access variables of bike and make changes to bike
        private BikeController _bikeController;

        public void Handle(BikeController bikeController)
        {
            // instantiate the bike controller
            if (!_bikeController)
                _bikeController = bikeController;

            // set direction
            _turnDirection.x =
                (float)_bikeController.CurrentMoveDirection;

            // set speed
            _bikeController.BikeSpeed =
               _bikeController.MaxSpeed;
        }

        /// <summary>
        /// Handle moving of bike
        /// </summary>
        void Update()
        {
            if (_bikeController)
            {
                // move the bike if there is speed to bike and engine is on
                if (_bikeController.BikeSpeed > 0 && _bikeController.IsOn)
                {
                    _bikeController.transform.Translate(
                         Vector2.left * _turnDirection * (
                             _bikeController.BikeSpeed *
                             Time.deltaTime));
                }
            }
        }
    }
}
