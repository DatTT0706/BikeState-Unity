using UnityEngine;

namespace Assets.Scripts.States
{
    public class StopState : MonoBehaviour, IPedestrianState
    {
        // to access variables of pedestrian and make changes to pedestrian
        private PedestrianController _pedestrianController;

        public void Handle(PedestrianController pedestrianController)
        {
            // instantiate the pedestrian controller
            if (!_pedestrianController)
            {
                _pedestrianController = pedestrianController;
            }

            // stop pedestrian
            _pedestrianController.CurrentSpeed = 0;
            _pedestrianController.IsMoving = false;
        }
    }
}