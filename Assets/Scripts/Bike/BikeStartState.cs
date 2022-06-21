using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class BikeStartState : MonoBehaviour, IBikeState
    {
        // to access variables of bike and make changes to bike
        private BikeController _bikeController;

        public void Handle(BikeController bikeController)
        {
            // instantiate the bike controller
            if (!_bikeController)
                _bikeController = bikeController;

           // start the bike
            _bikeController.IsOn = true;
        }

       
    }
}
