using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    GameObject kangaroo; // this would be replaced with a "closest entity" variable in the future so
                         // the player could interact with any number of entities in the scene, but for now its simpler
                         // to just reference the Kangaroo directly

    public float hitCooldownStartTime;
    float hitCooldown;

    public float angrinessGivenOnAttack;
    public float damageGivenOnAttack;

    public float attackRange;

    Animator animator;

    void Start()
    {
        kangaroo = GameObject.FindGameObjectWithTag("Entity");
        hitCooldown = 0;
        animator = GetComponent<Animator>();
    }

    void Update()
    {  
        if (kangaroo == null) kangaroo = GameObject.FindGameObjectWithTag("Entity");
        if (hitCooldown < 0 && Input.GetKeyDown(KeyCode.Space)) // cooldown hasn't run out, and pressing space
        {
            hitCooldown = hitCooldownStartTime;
			animator.Play("Base Layer.PlayerAttack");

			float distanceTokangaroo = Vector3.Distance(kangaroo.transform.position, transform.position);

			if (distanceTokangaroo < attackRange) // player is within range
            {
				kangaroo.GetComponent<Blackboard>().GetVariable<float>("angriness").value += angrinessGivenOnAttack;
				kangaroo.GetComponent<Blackboard>().GetVariable<float>("damageTaken").value += damageGivenOnAttack;
			}			
			
        }
        else
        {
            hitCooldown -= Time.deltaTime;
        }

    }


}
