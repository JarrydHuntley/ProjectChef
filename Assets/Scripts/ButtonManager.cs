using UnityEngine;
using System.Collections;

public class ButtonManager : MonoBehaviour {
	
	public ButtonScript[] buttonList;

	static System.Random _random = new System.Random();

	public int counter = 0;

	public GUIStyle myStyle;

	private string myGUIText;

	private float messageTimer = -10f;

	public float levelTimer = 100f;

	private bool hasCalledFirst = false;
	private bool win = false;
	private bool lose = false;
	//public bool pressed = false;

	private bool showTimer = false;

	// Use this for initialization
	void Start () {


		buttonList = GameObject.FindObjectsOfType<ButtonScript> ();

		Shuffle (buttonList);

		foreach(ButtonScript button in buttonList)
		{
			Debug.Log(button.returnMatertialName() + " " + button.description);

		}

		//pressThisButton();
	}
	
	// Update is called once per frame
	void Update () {

		messageTimer-=Time.deltaTime;

		if(showTimer)
		levelTimer -=Time.deltaTime;


		if((messageTimer> -5  && messageTimer < 0 )&& !hasCalledFirst && !win) {
			
			setMessage("Please find the "+ buttonList[counter].returnMatertialName() + "" + buttonList[counter].description+"!",30);
			hasCalledFirst = true;
		}


		if(messageTimer < 0 && win && !lose) {
			Debug.Log("Game end.");
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#elif UNITY_WEBPLAYER
			Application.OpenURL(webplayerQuitURL);
			#else
			Application.Quit();
			#endif
		}

		if(levelTimer < 0 ) {
			lose = true;
			setMessage("I'm sorry! Therese nothing we can do to save you now. What do we do now?!",10);
		}

		if(levelTimer < -10 ) {

			Debug.Log("Game end.");
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#elif UNITY_WEBPLAYER
			Application.OpenURL(webplayerQuitURL);
			#else
			Application.Quit();
			#endif
		}

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

		if (counter < buttonList.Length) {
				setMessage ("Please find the " + buttonList [counter].returnMatertialName () + "" + buttonList [counter].description + "!", 30);
		}
		//Debug.Log ("Increment counter. Counter is"+counter);
	}


	public void allButtonsPressed(){
		
		bool allPressed = true;

		//Debug.Log ("All pressed called.");

		foreach(ButtonScript button in buttonList)
		{
			allPressed = allPressed && button.pressed;
		
		}

		if (allPressed && !win){

			//setMessage("Good work diverting the submarine! Now lets get you out of there!!",10);
			setMessage("Good work diverting the submarine! Now lets get you out of there!!",10);
			Debug.Log ("They have all been pressed.");
			win = true;

		}
	}

	


	void OnGUI() {

		if(messageTimer>0){
		//GUI.backgroundColor = Color.black;
		//GUI.Box(new Rect(0, (Screen.height/2)+80, Screen.width/2, Screen.height), "This is a title",myStyle);
			GUI.Box(new Rect(0, (Screen.height/2)+80, Screen.width/2, Screen.height), myGUIText);
		}

		int minutes = Mathf.FloorToInt(levelTimer / 60F);
		int seconds = Mathf.FloorToInt(levelTimer - minutes * 60);
		
	
		if (showTimer) {
			string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
			Debug.Log(niceTime);
			GUI.Box(new Rect(10,10,250,100), niceTime+"");
		}
	}

	public void setMessage(string message, float timeOut){
		myGUIText = message;
		messageTimer = timeOut;
	
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

	public void setFirstMessage(string message, float timeOut){
		myGUIText = message;
		messageTimer = timeOut;

		showTimer = true;
	}
	
}

















