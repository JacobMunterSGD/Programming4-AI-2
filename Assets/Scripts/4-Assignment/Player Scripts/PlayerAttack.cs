using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    GameObject kangaroo; // this would be replaced with a "closest entity" variable in the future so
                         // the player could interact with a number of entities, but for now its simpler
                         // that to just reference the Kangaroo directly

    public float hitCooldownStartTime;
    float hitCooldown;

    public float angrinessGivenOnAttack;

    void Start()
    {
        kangaroo = GameObject.FindGameObjectWithTag("Entity");
        hitCooldown = hitCooldownStartTime;
    }

    void Update()
    {

        if (hitCooldown < 0 && Input.GetKeyDown(KeyCode.Space))
        {
            print(kangaroo.GetComponent<Blackboard>().GetVariable<float>("angriness").value);
            hitCooldown = hitCooldownStartTime;
            kangaroo.GetComponent<Blackboard>().GetVariable<float>("angriness").value += angrinessGivenOnAttack;
        }
        else
        {
            hitCooldown -= Time.deltaTime;
        }

    }


}
