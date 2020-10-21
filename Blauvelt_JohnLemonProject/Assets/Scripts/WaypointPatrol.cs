using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;

    int m_CurrentWaypointIndex;

    bool stunned = false;
    public GameObject pointOfViewObject; //so John won't get caught while stunned


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position); 
    }

    public void Stun ()
    {
        if(!stunned)
        {
            stunned = true;
            navMeshAgent.isStopped = true;
            pointOfViewObject.SetActive(false);
            Invoke("ResumePatrol", 3f); //stops for 3 seconds
        }
    }

    public void ResumePatrol()
    {
        stunned = false;
        navMeshAgent.isStopped = false;
        pointOfViewObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }
}
