using UnityEngine;
using System.Collections;

public class CollisionRangeEventBroadcaster : MonoBehaviour {

    public delegate void ColliderEvent(System.Object sender, Collider collider);
    public event ColliderEvent OnCollisionRangeEnter;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Destination")
        {
            Debug.Log("CollisionRangeEventBroadcaster::OnTriggerEnter() triggered by targetDestination");
            if (OnCollisionRangeEnter != null)
                OnCollisionRangeEnter(this, collider);
        }
    }
}
