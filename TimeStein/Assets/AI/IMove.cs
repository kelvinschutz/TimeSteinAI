using System;
using UnityEngine;

public interface IMove
{
    //Input: Destination
    //Move until we collide with the point
    void OnTriggerEnter(Collider other);
}
