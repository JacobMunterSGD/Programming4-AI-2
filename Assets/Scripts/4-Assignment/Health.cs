using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float health;
    public float startHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

}
