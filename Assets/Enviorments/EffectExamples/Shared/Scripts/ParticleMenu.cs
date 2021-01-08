using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleMenu : MonoBehaviour {

	// our ParticleExamples class being turned into an array of things that can be referenced
	public ParticleExamples[] particleSystems;

	// a private integer to store the current position in the array
	private int currentIndex;

	// references to the UI Text components
	public Text title;
	public Text description;
	public Text navigationDetails;

	// setting up the first menu item and resetting the currentIndex to ensure it's at zero
	void Start()
	{
		Navigate (0);
		currentIndex = 0;
	}


	// our public function that gets called by our menu's buttons
	public void Navigate(int i){

		// set the current position in the array to the next or previous position depending on whether i is -1 or 1, defined in our button event
		currentIndex = (particleSystems.Length + currentIndex + i) % particleSystems.Length;

		// setup the UI texts according to the strings in the array 
		title.text = particleSystems [currentIndex].title;
		description.text = particleSystems [currentIndex].description;
		navigationDetails.text = "" + (currentIndex+1) + " out of " + particleSystems.Length.ToString();

	}
}
