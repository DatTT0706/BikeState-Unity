using UnityEngine;

namespace Assets.Scripts.States
{
    public class StartState : MonoBehaviour, IPedestrianState
    {
        // to access variables of pedestrian and make changes to pedestrian
        private PedestrianController _controller;

        public void Handle(PedestrianController pedestrianController)
        {
            // instantiate the pedestrian controller
            if (!_controller)
            {
                _controller = pedestrianController;
            }
            // change speed of pedestrian
            _controller.CurrentSpeed = _controller.maxSpeed;
        }

        /// <summary>
        /// Move pedestrian
        /// </summary>
        private void Update()
        {
            // check if controller existing
            if (!_controller) return;
            if (_controller.CurrentSpeed > 0)
            {
                // move pedestrian
                _controller.transform.Translate(Vector3.up * _controller.MoveDirection *
                                                (_controller.CurrentSpeed * Time.deltaTime));
            }
        }
    }
}