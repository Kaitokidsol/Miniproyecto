using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyPatrol3 : MonoBehaviour
{
    [Header("Waypoints")]
    public List<Transform> waypoints = new List<Transform>(); // Lista de waypoints

    private int currentWaypoint = 0; // Índice del waypoint actual
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (waypoints.Count > 0)
        {
            // Si hay waypoints asignados, comienza a patrullar hacia el primer waypoint
            agent.SetDestination(waypoints[currentWaypoint].position);
        }
    }

    // Función que devuelve la lista de waypoints
    public List<Transform> GetWaypoints()
    {
        return waypoints;
    }

    // Función que cambia al siguiente waypoint
    public void GoToNextWaypoint()
    {
        currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
        agent.SetDestination(waypoints[currentWaypoint].position);
    }
}
