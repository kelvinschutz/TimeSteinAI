using UnityEngine;
using System;

public class Unit : MonoBehaviour, IDamageable, IDestroyable
{
    public ContextManager CM;
    public StateTransitioner stateTransitioner;
    public UnitBehavior unitBehavior;
    public Unit TARGET_ENEMY;

    void Awake()
    {
        CM = new ContextManager(this);
        stateTransitioner = new StateTransitioner(CM);
        unitBehavior = new UnitBehavior(CM);
        TARGET_ENEMY = CM.GetTargetEnemy();
    }

    void Update()
    {
        unitBehavior.UpdateUnit();
    }

    //For debugging purposes - Should be implemented via StateTransitioner Events
    public void ChangeColor(Color newColor)
    {
        gameObject.GetComponent<Renderer>().material.color = newColor;
    }

    public void TakeDamage(Unit source, int damage)
    {
        CM.TakeDamage(source, damage);
    }

    public void Destroy()
    {
        CM.Die();
    }
}