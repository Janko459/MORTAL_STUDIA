using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP2area : MonoBehaviour
{
    [SerializeField] private int critDamage = 0;
    private int addCritDamage;
    [SerializeField] private GameObject Player;
    [SerializeField] private ParticleSystem Blood;

    private int damage;
    // Start is called before the first frame update
    void Awake()
    {
        addCritDamage = critDamage;
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<P1Hitter>())
        {



            Blood.Play();



        }

    }
    public void Damage(int addDamage)
    {
        addCritDamage += addDamage;
        damage += addCritDamage;
        Player.GetComponent<P2FighterHP>().TakeDamage(damage);
        Debug.Log("Ouch!"  + damage );
        ReturnValue();
        
    }
    void ReturnValue()
    {
        addCritDamage = critDamage;
        damage = 0;
       // Debug.Log("Fix!");
    }
}
