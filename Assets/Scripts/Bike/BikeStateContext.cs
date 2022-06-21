using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    /// <summary>
    /// Context class, use to get current state and change state
    /// </summary>
    public class BikeStateContext
    {
        // current state of bike
        public IBikeState CurrentState
        {
            get; set;
        }

        // controller to get and/or properties of bike
        private readonly BikeController _bikeController;

        public BikeStateContext(BikeController bikeController)
        {
            // instantiate the bike controller
            _bikeController = bikeController;
        }

        /// <summary>
        /// Call handle method of current state
        /// </summary>
        public void Transition()
        {
            CurrentState.Handle(_bikeController);
        }

        /// <summary>
        /// Change to new state and call handle method of that state
        /// </summary>
        /// <param name="state">the new state to change to</param>
        public void Transition(IBikeState state)
        {
            CurrentState = state;
            CurrentState.Handle(_bikeController);
        }
    }
}
