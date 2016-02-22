using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {

    public Transform goal;
    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("MoveToTarget", 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            
            if(Physics.Raycast(ray, out hitInfo))
            {
                agent.destination = hitInfo.point;
            }
        }
        */
        //agent.destination = goal.position;
    }

    //Move to a target after finding the nearest target
    void MoveToTarget()
    {
        print("MoveTo::MoveToTarget() called.");
        GameObject target = FindTarget();
        if(target != null)
        {
            agent.destination = target.transform.position;
        } else {
            Debug.LogError("No targets were found when attempting FindTarget()!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
            print("Triggered!");
    }

    //Find the nearest target with a tag "Enemy"
    GameObject FindTarget()
    {
        print("MoveTo::FindTarget() called.");
        GameObject nearestTarget = null;
        float nearestPosition = Mathf.Infinity;
        GameObject[] targetCollection = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var target in targetCollection)
        {
            float distance = (target.transform.position - transform.position).sqrMagnitude;
            if(distance < nearestPosition)
            {
                nearestPosition = distance;
                nearestTarget = target;
            }
        }
        return nearestTarget;
    }
}
