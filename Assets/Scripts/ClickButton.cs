using UnityEngine;
using System.Collections;

public class ClickButton : MonoBehaviour {

	public Material changeTo;
	public ButtonManager mainButtonScript;

	// Use this for initialization
	void Start () {
	
		GameObject manager = GameObject.Find("ButtonManager");
		mainButtonScript = manager.GetComponent<ButtonManager>();

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown(0)){

			// if left button pressed...
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit)){
				// the object identified by hit.transform was clicked
				// do whatever you want

				//Debug.Log("Touched something.");


				//if(hit.transform.tag == "Button"){




				if(hit.transform.GetComponent<ButtonScript>()){

					int hitID = hit.transform.GetComponent("ButtonScript").GetInstanceID();

					if(mainButtonScript.getInstanceIDAtCounter() == hitID)
					{
						hit.collider.renderer.material = changeTo;
						//Debug.Log("Touched button.");

						hit.transform.GetComponent<ButtonScript>().pressed = true;
						mainButtonScript.inctCounter();

						mainButtonScript.allButtonsPressed();
					}

				}
			}
		}

	}
}
