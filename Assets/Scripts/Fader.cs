using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	
	/*// FadeInOut
	
	Texture2D fadeTexture;
	float fadeSpeed = 0.2f;
	float drawDepth = -1000f;
	
	private float alpha = 1.0f; 
	private int fadeDir = -1;
	
	void OnGUI(){
		
		alpha += fadeDir * fadeSpeed * Time.deltaTime;  
		alpha = Mathf.Clamp01(alpha);   
		
		GUI.color.a = alpha;
		
		GUI.depth = drawDepth;
		
		GUI.DrawTexture(Rect(0, 0, Screen.width, Screen.height), fadeTexture);
	}

	*/
}
