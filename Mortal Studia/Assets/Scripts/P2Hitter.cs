using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Hitter : MonoBehaviour
{
    [SerializeField] private int addDamage = 0;
    [SerializeField] private ParticleSystem hit;

    void OnTriggerEnter(Collider other)
    {
       
        HParea player = other.GetComponent<HParea>();
        if (player != null)
        {
            player.Damage(addDamage);
            hit.Play();

        }

    }
}
