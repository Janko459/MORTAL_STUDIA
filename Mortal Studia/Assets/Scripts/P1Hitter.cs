using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Hitter : MonoBehaviour
{
    [SerializeField] private int addDamage = 0;
    [SerializeField] private ParticleSystem hit;
   
    void OnTriggerEnter(Collider other)
    {
       
        HP2area player = other.GetComponent<HP2area>();
        if (player != null)
        {
            player.Damage(addDamage);
            hit.Play();

        }

    }
}
