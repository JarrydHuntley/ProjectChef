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

		Debug.Log ("Collision");
		if (other.gameObject.tag == "Player") {
		
			mainButtonScript.setMessage("Sorry to awaken from your nap chef Wilson but the caption abbandoned the ship in fear of his life. You only have a few minutes before you crash. I will try to walk you through how to fix things over the radio but I can't remember the consoles too well...",20000);
		}
		 
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {

		Debug.Log ("Collision");

	}

	void OnCollisionEnter (Collision col)
	{
		Debug.Log ("Collision");
		if(col.gameObject.name == "prop_powerCube")
		{
			Destroy(col.gameObject);
		}
	}
}
