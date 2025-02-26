using UnityEngine;

public class CrouchState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Crouching", true);
    }

    public override void UpdateSate(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitSate(movement, movement.Run);
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (movement.dir.magnitude < 0.1f) ExitSate(movement, movement.Idle);
            else ExitSate(movement, movement.Walk);
        }

        if (movement.vInput < 0) movement.curretMoveSpeed = movement.crouchBackSpeed;
        else movement.curretMoveSpeed = movement.crouchSpeed;
    }

    void ExitSate(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Crouching", false);
        movement.SwitchState(state);
    }
}
