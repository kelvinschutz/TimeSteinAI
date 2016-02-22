using UnityEngine;
using System.Collections;

public class DinoMatBehavior : MonoBehaviour {
	public Material dinoMat;
    public GameObject cubeMat;
	public Texture2D[] IdleFrames;
	public Texture2D[] WalkFrames;
	public Texture2D[] AttackFrames;
	int idleLength;
	int walkLength;
	int AttackLenght;

	int counter = 0;
	bool forward = true;

	public string State = "IDLE";  // "WALK"  "ATTACK"

	// Use this for initialization
	void Start () {
		idleLength = IdleFrames.Length;
		walkLength = WalkFrames.Length;
		AttackLenght = AttackFrames.Length;
	}
	
	// Update is called once per frame
	void Update () {
    
		FindTexture ();
	}

	void FindTexture (){
		switch (State) {

		case"IDLE":{
				if (counter <= 0){forward = true;}
				else if (counter == IdleFrames.Length-1) {forward = false;}
				try {
				SetTexture (IdleFrames[counter]);
				}
				catch{ counter = 0; }
				break;
			}
		case"WALK":{
				if (counter <= 0){forward = true;}
				else if (counter >= WalkFrames.Length-1) {forward = false;}
				try {
				SetTexture (WalkFrames[counter]);
				}
				catch{ counter = 0; }
				break;
			}
		case"ATTACK":{
				if (counter <= 0){forward = true;}
				else if (counter >= AttackFrames.Length-1) {forward = false;}
				try {
				SetTexture (AttackFrames[counter]);
			}
			catch{ counter = 0; }
			break;
			}



		}// switch


	if (forward){
		counter++;}
	else{
		counter--;
		}
		
	}
	
	void SetTexture(Texture text){
	    try {
            cubeMat.GetComponent<Renderer>().material.SetTexture("_MainTex", text);
		//dinoMat.SetTexture ("_MainTex", text);
		}
		catch {
			counter = 0;
		}


	}
}
