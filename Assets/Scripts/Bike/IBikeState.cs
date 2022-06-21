using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    /// <summary>
    /// General interface for all bike states, must be implemented by all bike states
    /// </summary>
    public interface IBikeState
    {
        /// <summary>
        /// Handle method for all states, gets called when change to new state. Pass in controller to make changes to bike
        /// </summary>
        /// <param name="controller">the controller for bike object</param>
        void Handle(BikeController controller);
    }
}
