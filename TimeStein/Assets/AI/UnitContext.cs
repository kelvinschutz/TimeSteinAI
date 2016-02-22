using System;
using UnityEngine;

//Always initialize a UnitContext before all other composite classes
public class UnitContext
{
    //UNIT PROPERTIES
    public Unit unit;
    public NavMeshAgent agent;
    public Color color; //Testing Purposes
    public int state;
    public bool isSelected;
    public Material material;
    public ViewRangeEventBroadcaster viewRangeEventBroadcaster;
    public AttackRangeEventBroadcaster attackRangeEventBroadcaster;
    public CollisionRangeEventBroadcaster collisionRangeEventBroadcaster;
    public Unit targetEnemy;
    public Vector3 targetDestination;
    public int health;
    public int damage;

    //CONSTRUCTOR
    public UnitContext(Unit parentUnit)
    {
        unit = parentUnit;
        state = UnitState.IDLE;
        agent = unit.gameObject.GetComponent<NavMeshAgent>();
        material = unit.gameObject.GetComponent<Material>();
        color = Color.white;
        isSelected = false;
        viewRangeEventBroadcaster = unit.gameObject.GetComponentInChildren<ViewRangeEventBroadcaster>();
        attackRangeEventBroadcaster = unit.gameObject.GetComponentInChildren<AttackRangeEventBroadcaster>();
        collisionRangeEventBroadcaster = unit.gameObject.GetComponentInChildren<CollisionRangeEventBroadcaster>();
        targetEnemy = null;
        targetDestination = Vector3.zero;
        health = 100;
        damage = 20;
    }
}
