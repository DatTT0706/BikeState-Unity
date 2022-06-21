using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    // traffic light game objects
    [SerializeField]
    public GameObject redLight;
    [SerializeField]
    public GameObject greenLight;

    // pedestrian and bike controller to control bike and pedestrian
    private PedestrianController _pedestrianController;
    private BikeController _bikeController;

    void Start()
    {
        // instantiate pedestrian and bike controller
        _pedestrianController =
            (PedestrianController)
            FindObjectOfType(typeof(PedestrianController));
        _bikeController =
           (BikeController)
           FindObjectOfType(typeof(BikeController));
        // start traffic light
        StartCoroutine(lightSwitch());
        // set default state for traffic lights
        greenLight.SetActive(false);
        redLight.SetActive(false);
    }

    /// <summary>
    /// Coroutine to change light speeds every 3 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator lightSwitch()
    {
        while (true)
        {
            // wait for initialize
            yield return new WaitForSeconds(1);
            // red light
            TurnRed();
            yield return new WaitForSeconds(3);
            // green light
            TurnGreen();
            yield return new WaitForSeconds(3);
        }
    }

    // red light, bike stop, pedestrian move
    void TurnRed()
    {
        redLight.SetActive(true);
        _pedestrianController.StartMoving();
        _bikeController.StopBike();
        greenLight.SetActive(false);
    }

    // green light, bike can move, pedestrian stop
    void TurnGreen()
    {
        redLight.SetActive(false);
        _pedestrianController.Stop();
        greenLight.SetActive(true);
    }
}
