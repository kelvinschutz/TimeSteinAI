using UnityEngine;
using System.Collections;

public class Fog_War_Behavior : MonoBehaviour {
	public Camera mainCamera;
	float rot = 0.0f;
	float inc = 0.0f;

	// Use this for initialization
	void Start () {
		inc = Random.Range (0.0f, 2.0f) - 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		//rot += inc;
		//transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
//		                 mainCamera.transform.rotation * new Vector3(0,rot,0));

		transform.Rotate (new Vector3(0,0,inc));

		CheckDistanceToObject ();


	


	}


	 void CheckDistanceToObject (){

		Vector3 camPos = mainCamera.transform.position;
		
		Vector2 a = new Vector2 (camPos.x, camPos.z);
		Vector2 b = new Vector2 (transform.position.x, transform.position.z);
		
		if (Vector2.Distance (a, b) < 30.0f)
			Destroy (gameObject);
	}

}
