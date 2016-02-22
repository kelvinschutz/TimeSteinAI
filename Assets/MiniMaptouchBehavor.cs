using UnityEngine;
using System.Collections;

public class MiniMaptouchBehavor : MonoBehaviour {
	public Camera MainCamera;
	public Terrain terrain;
	public Collider minimap;
	float scaleTouchLength = 0.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	


			if (Input.touches.Length > 0) {
			if (Input.touches.Length == 1) {
				//Debug.Log ("Yeah, you know that's right");
				FindTouchPoint (Input.touches [0]);
			} else {
				ZoomCamera ();
			}
		} else {
			scaleTouchLength = 0.0f;
		}
		}

	void ZoomCamera(){
		if (scaleTouchLength == 0.0f) { 
			// first touch
			scaleTouchLength = Vector2.Distance (Input.touches [0].position, Input.touches [1].position);

		} else {

			float temp = (Vector2.Distance (Input.touches [0].position, Input.touches [1].position) / 100.0f);
			Vector3 newPos = new Vector3();
			if (temp > scaleTouchLength){
				newPos =  new Vector3 ( MainCamera.transform.position.x,  MainCamera.transform.position.y - temp ,MainCamera.transform.position.z);

			}else{



			newPos =  new Vector3 ( MainCamera.transform.position.x,  MainCamera.transform.position.y + temp ,MainCamera.transform.position.z);
			}
			 // replace with a raycast solution later.   don't want to move the camera below the terrain.

			if (newPos.y > 85.0f || newPos.y < 150.0f)
			{
			MainCamera.transform.position = newPos;
				scaleTouchLength = temp;
			}

		}

	}


	void FindTouchPoint(Touch touch)
	{
		RaycastHit hit;
	//	Ray ray = GetComponent<Camera>().ScreenPointToRay (new Vector3 (touch.position.x, touch.position.y, 0));
		Ray ray = MainCamera.ScreenPointToRay (Input.touches[0].position);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider != null)
			{
				if (hit.collider == minimap)
				{
					Vector2 pixelUV = hit.textureCoord;
					Vector3 newPos = new Vector3(pixelUV.x *800,MainCamera.transform.position.y, pixelUV.y *500);
				
					MainCamera.transform.position = newPos;

				
				}
			}
				
		}
	}

}
