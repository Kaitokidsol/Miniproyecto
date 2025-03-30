using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class AttackState : StateMachineBehaviour
{
    Transform player;
    float attackRange = 3f;
    float attackCooldown = 1.5f; // Tiempo entre golpes
    float lastAttackTime;
    bool hasAttacked; // Controla si ya hizo daño en este ataque

    PlayerStats playerStats;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Obtener referencia al jugador y a su sistema de vida
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player != null)
            playerStats = player.GetComponent<PlayerStats>();

        lastAttackTime = Time.time;
        hasAttacked = false; // Reiniciamos el ataque

        animator.SetTrigger("Attack"); // 🔥 Reproduce la animación de ataque

        // Detener el NavMeshAgent durante el ataque
        NavMeshAgent agent = animator.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.isStopped = true; // Detiene el movimiento
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null || playerStats == null) return;

        animator.transform.LookAt(player);
        float distance = Vector3.Distance(player.position, animator.transform.position);

        if (distance > attackRange)
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isChasing", true);
        }
        else
        {
            if (!hasAttacked && stateInfo.normalizedTime >= 0.5f) // Ataca a la mitad de la animación
            {
                hasAttacked = true;
                playerStats.TakeDamage(10);
                Debug.Log("⚔️ Enemigo golpeó al jugador! Vida restante: " + playerStats.currentHealth);
            }

            // 🔥 Espera a que termine la animación para hacer otro ataque
            if (stateInfo.normalizedTime >= 1f && Time.time >= lastAttackTime + attackCooldown)
            {
                lastAttackTime = Time.time;
                hasAttacked = false; // Permite un nuevo ataque
                animator.SetTrigger("Attack"); // 🔥 Repite el ataque
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack"); // Evita que se quede atrapado en la animación
                                         // Reactivar el NavMeshAgent al salir del estado de ataque
        NavMeshAgent agent = animator.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.isStopped = false; // Reactiva el movimiento
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
