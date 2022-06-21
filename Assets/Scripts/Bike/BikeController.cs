using Assets.Scripts;
using Assets.Scripts.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeController : MonoBehaviour
{
    // bike max speed
    public float MaxSpeed = 2.0f;
    // is bike engine on
    public bool IsOn { get; set; }
    // speed of bike
    public float BikeSpeed { get; set; }
    // current move direction (forward/reverse)
    public Direction CurrentMoveDirection
    {
        get; private set;
    }
    // states of bike
    private IBikeState
        _startState, _stopState, _turnState;
    // context class
    private BikeStateContext _bikeStateContext;

    private void Start()
    {
        // engine not on
        IsOn = false;
        
        // init state context and bike state
        _bikeStateContext =
            new BikeStateContext(this);
        // assign bike states to bike
        _startState =
            gameObject.AddComponent<BikeStartState>();
        _stopState =
            gameObject.AddComponent<BikeStopState>();
        _turnState =
            gameObject.AddComponent<BikeTurnState>();

        // set default to stop state
        _bikeStateContext.Transition(_stopState);
    }

    // change to start state (engine on)
    public void StartBike()
    {
        _bikeStateContext.Transition(_startState);
    }

    // change to start state (engine off, stop moving)
    public void StopBike()
    {
        _bikeStateContext.Transition(_stopState);
    }

    /// <summary>
    /// change to move state
    /// </summary>
    /// <param name="direction">Direction of bike</param>
    public void MoveBike(Direction direction)
    {

        CurrentMoveDirection = direction;
        _bikeStateContext.Transition(_turnState);
    }

    /// <summary>
    /// Detect collision of bike with other objects ingame (with collider)
    /// </summary>
    /// <param name="collision">The object that this object collided with</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Change direction for bike if reach end of road
        if (collision.gameObject.name == "EndRoadBikeRight" || collision.gameObject.name == "EndRoadBikeLeft")
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

}
