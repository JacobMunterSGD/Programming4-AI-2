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

    Animator animator;

    void Start()
    {
        kangaroo = GameObject.FindGameObjectWithTag("Entity");
        hitCooldown = 0;
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (hitCooldown < 0 && Input.GetKeyDown(KeyCode.Space))
        {
            hitCooldown = hitCooldownStartTime;
            kangaroo.GetComponent<Blackboard>().GetVariable<float>("angriness").value += angrinessGivenOnAttack;
			kangaroo.GetComponent<Blackboard>().GetVariable<float>("damageTaken").value += damageGivenOnAttack;
			animator.Play("Base Layer.PlayerAttack");
        }
        else
        {
            hitCooldown -= Time.deltaTime;
        }

    }


}
