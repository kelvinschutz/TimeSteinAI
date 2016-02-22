using System;
using UnityEngine;

public class StateTransitioner
{
    ContextManager CM;
    Unit thisUnit;
    Master user;

    public StateTransitioner(ContextManager newContextManager)
    {
        CM = newContextManager;
        user = GameObject.Find("MasterObject").GetComponent<Master>();
        
        CM.GetViewRangeEventBroadcaster().OnViewRangeEnter += EnemyUnitInViewRangeHandler;
        CM.GetAttackRangeEventBroadcaster().OnAttackRangeEnter += EnemyUnitInAttackRangeHandler;
        CM.GetCollisionRangeEventBroadcaster().OnCollisionRangeEnter += DestinationReachedHandler;
        CM.OnTargetEnemyChange += TargetEnemyChangedHandler;
        CM.OnTargetEnemyDeath += TargetEnemyDeathHandler;
        //user.OnUserRightClick += RightClickEventHandler;
        user.OnClickTerrain += ClickTerrainHandler;
        user.OnClickDinosaur += ClickDinosaurHandler;
    }

    /*
    void RightClickEventHandler(string tag, Vector3 position)
    {
        Debug.Log("StateTransitioner::RightClickEventHandle() called with " + tag + " by " + contextManager.GetUnit().name);
        if (tag == "Terrain" || tag == "Tower")
        {
            contextManager.SetTargetDestination(position);
            contextManager.SetState(UnitState.MOVE);
            Debug.Log(contextManager.GetUnit().name + " to MOVE State.");
        }
        else if (tag == "Enemy")
        {
            contextManager.SetState(UnitState.ATTACK_MOVE);
            Debug.Log(contextManager.GetUnit().name + " to ATTACK_MOVE State.");
        }
    }
    */

    void ClickTerrainHandler(Vector3 position)
    {
        Debug.Log("ClickTerrainHandler() and unit selected is " + CM.GetSelected());
        if (CM.GetSelected())
        {
            Debug.Log(CM.GetUnit().name + " to MOVE State.");
            CM.SetTargetDestination(position);
            CM.SetState(UnitState.MOVE);
        }
    }

    void ClickDinosaurHandler(Unit unit)
    {
        if(CM.GetSelected())
        {
            Debug.Log(CM.GetUnit().name + " to ATTACK_MOVE State.");
            CM.SetTargetEnemy(unit);
            CM.SetState(UnitState.ATTACK_MOVE);
        }
    }

    void EnemyUnitInViewRangeHandler(System.Object sender, Collider collider)
    {
        Debug.Log("StateTransitioner::EnemyUnitInViewRangeHandle() called by " + CM.GetUnit().name);
        if (CM.GetState() == UnitState.IDLE)
        {
            CM.SetTargetEnemy(collider.transform.root.gameObject.GetComponent<Unit>());
            CM.SetState(UnitState.ATTACK_MOVE);
            CM.GetTargetEnemy().CM.OnUnitDeath += TargetEnemyDeathHandler;
            Debug.Log(CM.GetUnit().name + " to ATTACK_MOVE State.");
            //Set entering unit to new targetEnemy
        }
    }

    void EnemyUnitInAttackRangeHandler(System.Object sender, Collider collider)
    {
        Debug.Log("StateTransitioner::EnemyUnitInAttackRangeHandle() called by " + CM.GetUnit().name);
        if (CM.GetState() == UnitState.ATTACK_MOVE)
        {
            CM.GetAgent().Stop();
            CM.SetState(UnitState.ATTACK);
            Debug.Log(CM.GetUnit().name + " to ATTACK State.");
        }
    }

    void DestinationReachedHandler(System.Object sender, Collider collider)
    {
        Debug.Log("StateTransitioner::DestinationReachedHandle() called by " + CM.GetUnit().name);
        if (CM.GetState() == UnitState.MOVE)
        {
            CM.SetState(UnitState.IDLE);
            Debug.Log(CM.GetUnit().name + " to IDLE State.");
        }
    }

    //If the target dies, let all subscribers know
    void TargetEnemyDeathHandler(System.Object sender)
    {
        Debug.Log("StateTransitioner::TargetEnemyDeathHandler() called by " + CM.GetUnit().name);
        if(CM.GetTargetEnemy() == (Unit)sender)
        {
            CM.SetState(UnitState.IDLE);
        }
        Debug.Log(CM.GetUnit().name + " to IDLE State.");
    }

    void EnemyLeftAttackRangeHandler()
    {
        Debug.Log("StateTransitioner::EnemyLeftAttackRangeHandle() called by " + CM.GetUnit().name);
        CM.SetState(UnitState.MOVE);
        Debug.Log(CM.GetUnit().name + " to MOVE State.");
    }

    void TargetEnemyChangedHandler(System.Object sender)
    {
        Debug.Log("StateTransitioner::TargetEnemyChangedHandler() called by " + CM.GetUnit().name);
        CM.SetState(UnitState.ATTACK_MOVE);
        Debug.Log(CM.GetUnit().name + " to ATTACK_MOVE State.");
    }
}