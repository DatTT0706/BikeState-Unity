# BikeState Unity Project

## Introduction
* This is a Unity project to demonstrate how to implement the State Design Pattern in Unity.
* The Game Scene consists of a bike and a pedestrian, along with a traffic light system.
* When the game start, the traffic light will loop between red and green every 3 seconds. The pedestrian will move when the light is red and stop when the light is green.
* The bike can be controlled by clicking the buttons on the top left of the screen and will automatically stop when the light is red but can still be controlled by the buttons. The bike will only move forward/reverse (depending on the button) after start bike button is clicked.
* The bike and the pedestrian will automatically change direction after reaching the edge of the screen.

## Implementing the State Design Pattern
* The BikeController class is use to control the bike and change states of the bike.
* The BikeContext class implement the change state of the bike, which is called by the BikeController when needed to change state.
* The Bike consists of 3 different states, all of which implement IBikeState interface. The IBikeState interface has a Handle() method which pass in the BikeController to change properties of the bike as the state needed.
* Direction class is simply the direction the bike is facing.
* Similar to the bike, the pedestrian also have controller class and context class to control and change states.
* The pedestrian class have start and stop states, which implements the IPedestrianState interface with the Handle() method to handle changes needed of the state. This Handle() method also requires a PedestrianController to make changes to the pedestrian.
* The TrafficLightController will change traffic every 3 seconds and have codes to change states of bike and pedestrian depending on weather the light is red or green.
* The ClientState class loads buttons to control the bike on game load and each button can change bike state using the BikeController.

## Usage
* Clone the project.
* Install Unity version 2020.3.25f1, open UnityHub and import this project.
* After opening in UnityEditor, go to Assets/Scenes and open SampleScene, press play button to start the demonstration.


