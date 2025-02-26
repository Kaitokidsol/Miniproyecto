using UnityEngine;

public class RunState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Running", true);
    }

    public override void UpdateSate(MovementStateManager movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) ExitSate(movement, movement.Walk);
        else if (movement.dir.magnitude < 0.1f) ExitSate(movement, movement.Idle);

        if (movement.vInput < 0) movement.curretMoveSpeed = movement.runBackSpeed;
        else movement.curretMoveSpeed = movement.runSpeed;
    }

    void ExitSate(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Running", false);
        movement.SwitchState(state);
    }
}
