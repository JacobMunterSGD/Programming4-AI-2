using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKangaroo : MonoBehaviour
{

    public GameObject kangarooPrefab;

    void Start()
    {
        Instantiate(kangarooPrefab);
    }

}
