using UnityEngine;
using System.Collections;

//Acts as the UI handle.
public class Master : MonoBehaviour {

    public float AI_UPDATE_RATE = 1;

    UnitBehavior[] selection = null;
    public Unit controlledUnit;
    public Unit TARGET;

    //public delegate void UserClickEvent(string tag, Vector3 position);
    //public event UserClickEvent OnUserRightClick;

    public delegate void UserClickTerrain(Vector3 position);
    public event UserClickTerrain OnClickTerrain;

    public delegate void UserClickMonster(Unit unit);
    public event UserClickMonster OnClickMonster;

    public delegate void UserClickDinosaur(Unit unit);
    public event UserClickDinosaur OnClickDinosaur;

    public delegate void UnitSelectionEvent(Unit unit);
    public event UnitSelectionEvent OnUnitSelected;

    // Use this for initialization
    void Start () {
        //controlledUnit = GameObject.Find("TestUnit").GetComponent<Unit>();
	}
	
	void Update () {
	    if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject hitObject = hitInfo.transform.root.gameObject;
                Debug.Log("Master::RightClick: " + hitObject.name);
                switch (hitObject.tag)
                {
                    case "Terrain":
                        if (OnClickTerrain != null)
                        {
                            OnClickTerrain(hitInfo.point);
                        }
                        break;
                    case "Monster":
                        hitObject.GetComponent<Unit>().CM.Select();
                        if (OnClickMonster != null)
                        {
                            OnClickMonster(hitObject.GetComponent<Unit>());
                        }
                        break;
                    case "Dinosaur":
                        if (OnClickDinosaur != null)
                        {
                            OnClickDinosaur(hitObject.GetComponent<Unit>());
                        }
                        break;
                }
            }
        }

        //Test damage of a random unit
        if(Input.GetKeyDown("d"))
        {
            Unit enemyUnit = GameObject.FindGameObjectWithTag("Dinosaur").GetComponent<Unit>();
            controlledUnit.TakeDamage(enemyUnit, 200);
        }
	}
}
