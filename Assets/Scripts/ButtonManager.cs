using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {
	
	public ButtonScript[] buttonList;

	static System.Random _random = new System.Random();

	public int counter = 0;

	//public bool pressed = false;
	
	// Use this for initialization
	void Start () {

		buttonList = GameObject.FindObjectsOfType<ButtonScript> ();

		Shuffle (buttonList);

		foreach(ButtonScript button in buttonList)
		{
			Debug.Log(button.description);
			
		}
		//pressThisButton();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public ButtonScript getButtonAtCounter(){


		return buttonList[counter];
	}


	public int getInstanceIDAtCounter(){
		
		if (counter  < buttonList.Length) {
		
			return buttonList[counter].GetInstanceID();
		}

		return buttonList.Length-1;
	}


	public void inctCounter(){
		
	
		counter++;

		Debug.Log ("Increment counter. Counter is"+counter);
	}


	public void allButtonsPressed(){
		
		bool allPressed = true;

		//Debug.Log ("All pressed called.");

		foreach(ButtonScript button in buttonList)
		{
			allPressed = allPressed && button.pressed;
		
		}

		if (allPressed){

			Debug.Log ("They have all been pressed.");
			Application.Quit();
			
		}
	}

	
	public class ExampleClass : MonoBehaviour {
		void OnGUI() {
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "This is a title");
		}
	}


	static void Shuffle<T>(T[] array)
	{
		int n = array.Length;
		for (int i = 0; i < n; i++)
		{
			// NextDouble returns a random number between 0 and 1.
			// ... It is equivalent to Math.random() in Java.
			int r = i + (int)(_random.NextDouble() * (n - i));
			T t = array[r];
			array[r] = array[i];
			array[i] = t;
		}
	}
	
}