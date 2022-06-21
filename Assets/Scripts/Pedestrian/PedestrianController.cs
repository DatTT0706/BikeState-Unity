using Assets.Scripts.States;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class PedestrianController : MonoBehaviour
    {
        // pedestrian max speed
        public float maxSpeed = 2.0f;
        // pedestrian current speed
        public float CurrentSpeed { get; set; }
        // is pedestrian moving
        public bool IsMoving { get; set; }
        // states of pedestrian
        private IPedestrianState _startState, _stopState;
        // context class
        private PedestrianContext _pedestrianContext;
        // current move direction (up/down)
        public float MoveDirection { get; private set; }

        private void Start()
        {
            // init state context and bike state
            _pedestrianContext = new PedestrianContext(this);
            _startState = gameObject.AddComponent<StartState>();
            _stopState = gameObject.AddComponent<StopState>();
            // set default state to stop state
            _pedestrianContext.CurrentState = _stopState;
            // default is not moving and move up
            IsMoving = false;
            MoveDirection = 1;
        }

        /// <summary>
        /// Change state to start moving
        /// </summary>
        public void StartMoving()
        {
            // pedestrian now moving
            IsMoving = true;
            _pedestrianContext.ChangeState(_startState);
        }

        /// <summary>
        /// Chage state to stop
        /// </summary>
        public void Stop()
        {
            // pedestrian no longer moving
            IsMoving = false;
            _pedestrianContext.ChangeState(_stopState);          
        }

        /// <summary>
        /// Change the moving direction of pedestrian
        /// </summary>
        public void ChangeMoveDirection()
        {
            if (IsMoving)
            {
                // change move direction only if pedestrian is moving
                MoveDirection *= -1;
            }          
        }

        /// <summary>
        /// Detect collision of pedestrian with other objects ingame (with collider)
        /// </summary>
        /// <param name="col">The object that this object collided with</param>
        public void OnCollisionEnter2D(Collision2D col)
        {            
            if (col.gameObject.name.Equals("EndRoadPedTop") || col.gameObject.name.Equals("EndRoadPedBottom"))
            {
                // change the moving direction for pedestrian if end of road is reached
                ChangeMoveDirection();
            }
        }
    }
}