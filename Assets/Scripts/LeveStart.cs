using UnityEngine;
using System.Collections;

public class LeveStart : MonoBehaviour {

	public ButtonManager mainButtonScript;
	
	// Use this for initialization
	void Start () {
		
		GameObject manager = GameObject.Find("ButtonManager");
		mainButtonScript = manager.GetComponent<ButtonManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "Player") {
		
			mainButtonScript.setMessage(" Sorry to awaken you from your nap chef Wilson but the caption abandoned \n the submarine in fear of his life."
				+" You only have a few minutes before you crash! \n I will try to walk you through how to fix " +
			                            "things over \n the radio but I can't remember the consoles too well...",12);
		}
		 
	}

}
