using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    [SerializeField] private float time = 1.35f;
    [SerializeField] private GameObject Object;
    void Update()
    {
        Destroy(Object, time);
    }
}

