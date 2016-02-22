using UnityEngine;
using System.Collections;

public class AttackRangeEventBroadcaster : MonoBehaviour {

    public delegate void ColliderEvent(System.Object sender, Collider collider);
    public event ColliderEvent OnAttackRangeEnter;
    public event ColliderEvent OnAttackRangeExit;
    public string selfTag;

    void Awake()
    {
        selfTag = gameObject.tag;
    }

    //Check if the entering collider is from the target enemy.
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Terrain" && collider.gameObject.tag != selfTag)
        {
            
            if (OnAttackRangeEnter != null)
                OnAttackRangeEnter(this, collider);
        }
    }

    //Check if the exiting collider is from the target enemy.
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag != "Terrain" && collider.gameObject.tag != selfTag)
        {
            Debug.Log("AttackRangeEventBroadcaster::OnTriggerEnter() triggered by " + collider.gameObject.name);
            if (OnAttackRangeExit != null)
                OnAttackRangeExit(this, collider);
        }
    }
}
