using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Burst;
    [SerializeField] private GameObject Timer;
    
    void Start()
    {
        GameObject burst = Instantiate(Burst, transform.position, Quaternion.identity) as GameObject;
        Destroy(player, 0);
        Timer.GetComponent<GameOver>().BackToMenu();
    }
  

   
}
