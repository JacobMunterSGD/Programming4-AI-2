using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHurt : MonoBehaviour
{
    float stunCooldown;
    public float stunDuration;

    public NavMeshAgent navMeshAgent;

    void Update()
    {
        if (stunCooldown > 0)
        {
            stunCooldown -= Time.deltaTime;
        }
        else
        {
            navMeshAgent.enabled = true;
        }
    }

    public void JustBeenHit()
    {
        stunCooldown = stunDuration;
        if (navMeshAgent.enabled) navMeshAgent.ResetPath();
		navMeshAgent.enabled = false;
    }
}
