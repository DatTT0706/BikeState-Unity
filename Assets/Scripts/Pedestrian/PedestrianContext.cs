using Assets.Scripts.States;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Context class, use to get current state and change state
    /// </summary>
    public class PedestrianContext
    {
        // current state of pedestrian
        public IPedestrianState CurrentState { get; set; }

        // controller to get and/or properties of pedestrian
        private readonly PedestrianController _pedestrianController;

        public PedestrianContext(PedestrianController controller)
        {
            // instantiate the pedestrian controller
            _pedestrianController = controller;
        }

        /// <summary>
        /// Change to new state and call handle method of that state
        /// </summary>
        /// <param name="state">the new state to change to</param>
        public void ChangeState(IPedestrianState state)
        {
            CurrentState = state;
            CurrentState.Handle(_pedestrianController);
        }
    }
}