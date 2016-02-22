using UnityEngine;
using System.Collections;

public class ViewRangeEventBroadcaster : MonoBehaviour {

    public delegate void ColliderEvent(System.Object sender, Collider collider);
    public event ColliderEvent OnViewRangeEnter;
    public string enemyTag;

    void Awake()
    {
        string selfTag = transform.root.gameObject.tag;
        if( selfTag == "Monster") { enemyTag = "Dinosaur"; }
        if (selfTag == "Dinosaur") { enemyTag = "Monster"; }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == enemyTag)
        {
            Debug.Log("ViewRangeEventBroadcaster::OnTriggerEnter() triggered by" + collider.transform.root.gameObject.name);
            if (OnViewRangeEnter != null)
                OnViewRangeEnter(this, collider);
        }
    }
}
