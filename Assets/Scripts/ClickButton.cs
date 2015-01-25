using UnityEngine;
using System.Collections;

public class ClickButton : MonoBehaviour {

	public Animator anim;
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

			anim.SetTrigger ("PushButton");

			// if left button pressed...
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit)){
				// the object identified by hit.transform was clicked
				// do whatever you want

				Debug.Log("Touched something.");


				//if(hit.transform.tag == "Button"){


				if(hit.transform.root.transform.GetComponent<ButtonScript>()){


					int hitID = hit.transform.root.transform.GetComponent<ButtonScript>().GetInstanceID();

					Debug.Log("Touched button.");
					if(mainButtonScript.getInstanceIDAtCounter() == hitID)
					{
						hit.transform.root.collider.renderer.material = changeTo;
						//Debug.Log("Touched button.");
						Renderer[] cList =hit.transform.root.GetComponentsInChildren<Renderer>();
						foreach (Renderer child in cList) {
							child.gameObject.renderer.material = changeTo;
						}

						hit.transform.root.transform.GetComponent<ButtonScript>().pressed = true;
						mainButtonScript.inctCounter();

						mainButtonScript.allButtonsPressed();
					}

				}
			}
		}

	}
}
