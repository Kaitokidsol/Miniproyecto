using UnityEngine;

public class WalkState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Walking", true);
    }

    public override void UpdateSate(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitSate(movement, movement.Run);
        else if (Input.GetKeyDown(KeyCode.LeftControl)) ExitSate(movement, movement.Crouch);
        else if (movement.dir.magnitude < 0.1f) ExitSate(movement, movement.Idle);

        if (movement.vInput < 0) movement.curretMoveSpeed = movement.walkBackSpeed;
        else movement.curretMoveSpeed = movement.walkSpeed;
    }

    void ExitSate(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Walking", false);
        movement.SwitchState(state);
    }
}
