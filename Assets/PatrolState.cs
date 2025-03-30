using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class PatrolState : StateMachineBehaviour
{
    float timer;
    NavMeshAgent agent;
    Transform player;
    float chaseRange = 5;

    private EnemyPatrol3 enemyPatrol;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 2f;
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();

        // Obtén el script EnemyPatrol que contiene la lógica de patrullaje
        enemyPatrol = animator.GetComponent<EnemyPatrol3>();

        if (enemyPatrol != null)
        {
            // Si los waypoints ya están asignados, comienza a patrullar con los waypoints personalizados
            enemyPatrol.GoToNextWaypoint();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > 15)
            animator.SetBool("isPatrolling", false);

        // Revisa si el jugador está cerca y cambia al estado de persecución (ChaseState)
        float distanceToPlayer = Vector3.Distance(player.position, animator.transform.position);
        if (distanceToPlayer < chaseRange)
        {
            animator.SetBool("isChasing", true);
            animator.SetBool("isPatrolling", false); // El enemigo comienza a perseguir al jugador
        }

        // Si el enemigo ha llegado al waypoint, pasa al siguiente
        if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
        {
            if (enemyPatrol != null)
            {
                // Llama a GoToNextWaypoint cuando el enemigo llega al waypoint
                enemyPatrol.GoToNextWaypoint();
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position); // Detiene el movimiento al salir del estado
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
