using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1FighterHP : MonoBehaviour
{
    [SerializeField] private int playerHP = 100;
    private float health;

    [SerializeField] private int playerST = 100;
    private float stamina;

    [SerializeField] private Image hp1;
    [SerializeField] private Image st1;
    [SerializeField] private GameObject HP;
    [SerializeField] private GameObject ST;
    [SerializeField] private ParticleSystem Depletion;
    [SerializeField] private GameObject PlayerName;

    private float _staminaRegTime = 1.5f;
    private float _staminaRegTimer = 0.0f;
    private int _staminaRegPerFrame = 8;

    [SerializeField] private GameObject lost;

    private Animator anim;
    //block
    private bool _valueLocked = false;
    private bool depleted = false;
    public GameObject Sword_4;

    
    void Awake()
    {
        health = playerHP;
        stamina = playerST;
        HP.SetActive(true);
        ST.SetActive(true);
        PlayerName.SetActive(true);

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        st1.fillAmount = stamina / playerST;
       // Debug.Log(stamina);
        if (stamina < playerST)
        {
            if (_staminaRegTimer >= _staminaRegTime)
            {
                stamina += _staminaRegPerFrame * Time.deltaTime; 
                Debug.Log("Regenerating");

                if (stamina < 0)
                {
                    

                    stamina = 0;
                }
            }
            else //adds time to timer
            {
                _staminaRegTimer += Time.deltaTime;
                
            }
           

        }
        if (stamina > playerST)
        {
            stamina = 100;
        }
      
            if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Block"))
            {

            Sword_4.SetActive(true);
            _valueLocked = true;


        }
        else
        {
            Sword_4.SetActive(false);
            _valueLocked = false;

        }

    }
    public void TakeDamage(int damage)
    {
        if (_valueLocked == false)
        {


            health -= damage;
            hp1.fillAmount = health / playerHP;
            Debug.Log("Health: " + health);



            if (health <= 0)
            {
                lost.SetActive(true);

                

                anim.SetBool("Jump", false);
                anim.SetBool("Run", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Attack", false);
                anim.SetBool("Block", false);
                anim.SetBool("Death", true);

                this.GetComponent<Death>().enabled = true;

            }

        }
    }
    public void UseStamina(int tire)
    {
        
        if (tire < stamina)
        {
            _staminaRegTimer = 0.0f;
            stamina -= tire;
            st1.fillAmount = stamina / playerST;

            depleted = false;
            anim.SetBool("Interrupt", false);
        }
        else
        {
            depleted = true;
            anim.SetBool("Interrupt", true);

        }
        if (depleted == true)
        {
            Depletion.Play();
        }

    }
}


