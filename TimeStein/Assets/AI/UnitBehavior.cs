using UnityEngine;
using System.Collections;

public class UnitBehavior
{
    float AI_timer = 0;
    float AI_UPDATE_RATE = .3f;
    float currentCooldown = 0;
    float COOLDOWN_RATE = 1; //ADD COOLDOWN RATE TO UNIT CONTEXT
    ContextManager CM;
    Master master;

    public UnitBehavior(ContextManager newContextManager)
    {
        CM = newContextManager;
        master = GameObject.Find("MasterObject").GetComponent<Master>();
    }

    public void UpdateUnit()
    {
        //Update State based on the AI_UPDATE_RATE
        currentCooldown += Time.deltaTime;
        AI_timer += Time.deltaTime;
        if (AI_timer > AI_UPDATE_RATE)
        {
            int currentState = CM.GetState();
            Debug.Log("Current State for " + CM.GetUnit().gameObject.name + " is " + currentState);
            switch (CM.GetState())
            {
                case UnitState.IDLE:
                    IdleCommands();
                    break;
                case UnitState.MOVE:
                    MoveCommands();
                    break;
                case UnitState.ATTACK_MOVE:
                    AttackMoveCommands();
                    break;
                case UnitState.ATTACK:
                    AttackCommands();
                    break;
            }
            AI_timer = 0.0f;
        }
    }

    void IdleCommands()
    {
        //Play IDLE Animation
    }

    void MoveCommands()
    {
        //Assign agent.destination to targetDestination
        CM.GetAgent().destination = CM.GetTargetDestination();
        //Play WALK animation
    }

    void AttackMoveCommands()
    {
        //Assign agent.destination to targetEnemy's position
        //master.TARGET = CM.GetTargetEnemy();
        //var thing1 = CM.GetTargetEnemy().gameObject;
        Debug.Log("AttackMoveCommands by " + CM.GetUnit().gameObject.name + "AttackMove to " + CM.GetTargetEnemy().gameObject.name);
        Vector3 position = CM.GetTargetEnemy().gameObject.transform.position;
        CM.GetAgent().destination = position;
        //Play WALK animation
    }

    void AttackCommands()
    {
        //Check current cooldown timer
        Debug.Log(CM.GetUnit().gameObject.name + " has current cooldown of " + currentCooldown);
        //Play ATTACK animation
        if (currentCooldown > COOLDOWN_RATE)
        {
            Debug.Log(CM.GetUnit().gameObject.name + " is attacking!");
            //Apply damage
            CM.DealDamage();
            //Reset timer
            currentCooldown = 0.0f;
        }
    }
}
