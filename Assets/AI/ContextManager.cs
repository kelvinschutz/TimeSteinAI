using System;
using UnityEngine;

//Handles all incoming changes of UnitContext
public class ContextManager
{
    Unit unit;
    UnitContext context;

    public ContextManager(Unit unit)
    {
        this.unit = unit;
        this.context = new UnitContext(unit);
    }

    //EVENT DELEGATE SIGNATURE DEFINITION
    public delegate void PropertyChangedEvent(System.Object sender);
    public delegate void DeathEvent(System.Object sender);
    public delegate void DamageEvent(System.Object sender, Unit source, int damage);
    public delegate void StateChangeEvent(System.Object sender, UnitState state);

    //PROPERTY CHANGE EVENTS
    public event PropertyChangedEvent OnStateChange;
    public event PropertyChangedEvent OnTargetEnemyChange;
    public event PropertyChangedEvent OnTargetDestinationChange;
    public event PropertyChangedEvent OnHealthChange;
    public event PropertyChangedEvent OnUnitSelected;

    //UNIQUE SIGNATURE EVENTS
    public event DeathEvent OnTargetEnemyDeath;
    public event DeathEvent OnUnitDeath = delegate { };
    public event DamageEvent OnTakenDamage = delegate { };
    public event StateChangeEvent OnChangedState = delegate { };

    //--PROPERTY CHANGE EVENT TRIGGERS--\\
    //----------------------------------\\

    public void SetState(int newState)
    {
        context.state = newState;
        if (OnStateChange != null)
        { OnStateChange(this); }
    }

    public void SetTargetEnemy(Unit newEnemy)
    {
        context.targetEnemy = newEnemy;
        if (OnTargetEnemyChange != null)
        { OnTargetEnemyChange(this); }
    }

    public void SetTargetDestination(Vector3 newDestination)
    {
        context.targetDestination = newDestination;
        if (OnTargetDestinationChange != null)
        { OnTargetDestinationChange(this); }
    }

    public void SetHealth(int newHealth)
    {
        context.health = newHealth;
        if (OnHealthChange != null)
        { OnHealthChange(this); }
    }

    public void TakeDamage(Unit source, int damage)
    {
        context.health -= damage;
        if(context.health <= 0)
        { unit.Destroy(); }

        if (OnTakenDamage != null)
        { OnTakenDamage(this, source, damage); }

        Debug.Log(unit.gameObject.name + " took damage from " + source.gameObject.name + " and has " + context.health + " health left.");
    }

    public void Die()
    {
        //On Acquiring this target, a unit should subscribe to OnUnitDeath, the switch states when it is broadcasted.
        if (OnUnitDeath != null)
        { OnUnitDeath(GetUnit()); }
        GameObject.Destroy(unit.gameObject);
        Debug.Log(unit.gameObject.name + " has been slain!");
    }

    public void Select()
    {
        Debug.Log(GetUnit().name + " has been selected!");
        context.isSelected = true;
        if (OnUnitSelected != null)
        { OnUnitSelected(this); }
    }

    public void DealDamage()
    {
        GetTargetEnemy().TakeDamage(GetUnit(), GetDamage());
    }

    //--CONTEXT ACCESSORS--\\
    public int GetState() { return context.state; }
    public Unit GetUnit() { return context.unit; }
    public NavMeshAgent GetAgent() { return context.agent; }
    public int GetHealth() { return context.health; }
    public int GetDamage() { return context.damage; }
    public bool GetSelected() { return context.isSelected; }
    public Unit GetTargetEnemy() { return context.targetEnemy; }
    public Vector3 GetTargetDestination() { return context.targetDestination; }
    public ViewRangeEventBroadcaster GetViewRangeEventBroadcaster() { return context.viewRangeEventBroadcaster; }
    public AttackRangeEventBroadcaster GetAttackRangeEventBroadcaster() { return context.attackRangeEventBroadcaster; }
    public CollisionRangeEventBroadcaster GetCollisionRangeEventBroadcaster() { return context.collisionRangeEventBroadcaster; }
}
