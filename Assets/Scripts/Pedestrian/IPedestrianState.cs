namespace Assets.Scripts.States
{
    /// <summary>
    /// General interface for all pedestrian states, must be implemented by all pedestrian states
    /// </summary>
    public interface IPedestrianState
    {
        /// <summary>
        ///  Handle method for all states, gets called when change to new state. Pass in controller to make changes to pedestrian
        /// </summary>
        /// <param name="pedestrianController">the controller for pedestrian object</param>
        void Handle(PedestrianController pedestrianController);
    }

    /// <summary>
    /// Moving direction of pedestrian
    /// </summary>
    public enum PedDirection
    {
        Up = 1,
        Down = 1
    }
}