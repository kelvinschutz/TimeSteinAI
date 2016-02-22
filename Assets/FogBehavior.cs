using UnityEngine;
using System.Collections;

public class FogBehavior : MonoBehaviour {
	public GameObject fogPartlicle;

	// Use this for initialization
	void Start () {
		for (int x = 0; x< 800; x+=10) {
			for (int y = 0; y < 500; y+=10)
			{
			GameObject tmp = Instantiate(fogPartlicle, new Vector3 (x,100,y),fogPartlicle.transform.rotation) as GameObject;
			

			}
		
		}




	}
	
	// Update is called once per frame
	void Update () {
	
	


	}
}
