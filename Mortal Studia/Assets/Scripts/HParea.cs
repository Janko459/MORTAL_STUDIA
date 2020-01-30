using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HParea : MonoBehaviour
{
    [SerializeField] private int critDamage = 0;
    private int addCritDamage;
    [SerializeField] private GameObject Player;
    [SerializeField] private ParticleSystem Blood;

    private int damage;
   
    void Awake()
    {
        addCritDamage = critDamage;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<P2Hitter>())
        {


            Blood.Play();




        }

    }
    public void Damage(int addDamage)
    {
        addCritDamage += addDamage;
        damage += addCritDamage;
        Player.GetComponent<P1FighterHP>().TakeDamage(damage);
        Debug.Log("Ouch!" + damage);
        ReturnValue();

    }
    void ReturnValue()
    {
        addCritDamage = critDamage;
        damage = 0;
      //  Debug.Log("Fix!");
    }
}
