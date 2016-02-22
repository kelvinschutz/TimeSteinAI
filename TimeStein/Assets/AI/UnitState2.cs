using UnityEngine;

/*
public struct State
{
    public const int IDLE = 0;
    public const int MOVE = 1;
    public const int ATTACK_MOVE = 2;
    public const int ATTACK = 3;
    public const int DEATH = 4;
}
*/

public class UnitState2
{
    /*
    public int currentState { get; set; }

    //Don't Need
    public Vector3 targetPosition { get; set; }
    public Unit targetEnemy { get; set; }
    public Unit unit; //For color change debugging
    public delegate void AcquireTarget();
    public event AcquireTarget OnAcquireNewTarget;
    //Don't Need

    public UnitState2(Unit unit)
    {
        //Don't Need
        Debug.Log("UnitState Constructor called.");
        //currentState = State.IDLE;
        targetPosition = Vector3.zero;
        targetEnemy = null;
        this.unit = unit; //For color change debugging
        //Don't Need
    }

    //Update the current state based on the desired new state
    public void ChangeState(int newState)
    {
        Debug.Log("UnitState::ChangeState() to " + newState);
        currentState = newState;

        //For Debugging Purposes - Should be implemented via StateTransitioner Events
        if (currentState == UnitState.IDLE)
            unit.ChangeColor(Color.gray);
        else if (currentState == UnitState.MOVE)
            unit.ChangeColor(Color.green);
        else if (currentState == UnitState.ATTACK_MOVE)
            unit.ChangeColor(Color.magenta);
        else if (currentState == UnitState.ATTACK)
            unit.ChangeColor(Color.red);
        else if (currentState == UnitState.DEATH)
            unit.ChangeColor(Color.black);
    }

    //Set the target enemy for this unit
    public void SetTargetEnemy(Unit newTarget)
    {
        targetEnemy = newTarget;
        if(OnAcquireNewTarget != null)
        {
            OnAcquireNewTarget();
        }
    }

    public static bool operator ==(UnitState stateA, UnitState stateB)
    {
        if(System.Object.ReferenceEquals(stateA, stateB))
        {
            return true;
        }

        if(((object)stateA == null) || ((object)stateB) == null)
        {
            return false;
        }

        return (stateA.currentState == stateB.currentState);
    }

    public static bool operator !=(UnitState stateA, UnitState stateB)
    {
        return !(stateA == stateB);
    }
    */
}


