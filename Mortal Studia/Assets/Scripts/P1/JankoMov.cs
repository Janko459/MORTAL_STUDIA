using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JankoMov : MonoBehaviour
{
    [SerializeField] private float speed = 20f;

    [SerializeField] private int tire = 1;
    [SerializeField] private int tire2 = 5;
    [SerializeField] private int tire3 = 90;

    private Rigidbody rb;
    private Animator anim;

    public GameObject CameraR;
    public GameObject CameraL;
    //basic
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float jumpDForce = 2f;
    private bool _onGround = true;
    private const int _maxJump = 2;
    private int _currentJump = 0;
    //jumps
    [SerializeField] private GameObject Hit;
    [SerializeField] private GameObject Hit2;
    [SerializeField] private GameObject Hit3;
    [SerializeField] private ParticleSystem RageStream;
    [SerializeField] private ParticleSystem RageFlow;
    //hits
    [SerializeField] private GameObject Shield;
    [SerializeField] private GameObject Sword_1;

    [SerializeField] private GameObject Sword_2;
    [SerializeField] private GameObject Sword_3;
    //weapon
    [SerializeField] private GameObject rageFoot;
    [SerializeField] private GameObject rageFoot2;

    [SerializeField] private GameObject rageFoot3;
    [SerializeField] private GameObject rageFoot4;
    //effects


    private Collider coll;
    //block
    // Start is called before the first frame update
    void Awake()
    {
        anim = this.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Hit.SetActive(false);
        Hit2.SetActive(false);
        Hit3.SetActive(false);

        if (_onGround == true)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Idle", true);
            anim.SetBool("Jump", false);
            anim.SetBool("Attack", false);
            
           


        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            CameraL.SetActive(true);
            CameraR.SetActive(false);
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0, 0, 0);
            transform.rotation = rot;
            transform.Translate(0, 0, speed * Time.deltaTime);
            anim.SetBool("Block", false);
            if (_onGround == true)
            {
                anim.SetBool("Run", true);
                anim.SetBool("Idle", false);
                anim.SetBool("Jump", false);
                anim.SetBool("Attack", false);
                


            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            CameraL.SetActive(false);
            CameraR.SetActive(true);
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0, 180, 0);
            transform.rotation = rot;
            transform.Translate(0, 0, speed * Time.deltaTime);
            anim.SetBool("Block", false);
            if (_onGround == true)
            {
                anim.SetBool("Run", true);
                anim.SetBool("Idle", false);
                anim.SetBool("Jump", false);
                anim.SetBool("Attack", false);
                


            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            
            if (_onGround == false)
            {
                rb.AddForce(Vector3.down * jumpForce, ForceMode.Impulse);
                anim.SetBool("Run", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Jump", false);
                anim.SetBool("Attack", false);
                anim.SetTrigger("Dunk");

            }
           
           
        }
       


        if (Input.GetKeyDown(KeyCode.UpArrow) && (_onGround || _maxJump > _currentJump))
        {
            _onGround = false;

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetBool("Jump", true);
            anim.SetBool("Run", false);
            anim.SetBool("Idle", false);
            anim.SetBool("Attack", false);
            





            _currentJump++;


            if (Input.GetKeyDown(KeyCode.UpArrow) && (_maxJump > _currentJump))
            {

                _onGround = false;

                rb.AddForce(Vector3.up * jumpDForce, ForceMode.Impulse);
                anim.SetBool("Jump", true);
                anim.SetBool("Run", false);
                anim.SetBool("Idle", false);
                anim.SetBool("Attack", false);
                



            }
            

        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            
            anim.SetBool("Jump", false);
            anim.SetBool("Run", false);
            anim.SetBool("Idle", false);
            anim.SetBool("Kick", true);

            anim.SetBool("Block", false);


        }
        else
        {
            anim.SetBool("Kick", false);
        }
        if (Input.GetKey(KeyCode.Keypad1))
        {
            
            anim.SetBool("Jump", false);
            anim.SetBool("Run", false);
            anim.SetBool("Idle", false);
            anim.SetBool("Attack", true);

            anim.SetBool("Block", false);


        }
        else
        {
            anim.SetBool("Attack", false);
        }
        if (Input.GetKey(KeyCode.Keypad3))
        {

            
            
            anim.SetBool("Idle", false);
            anim.SetBool("Block", true);

            anim.SetBool("Attack", false);


        }
        else
        {
            anim.SetBool("Block", false);
        }
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Dunk"))

        {

            Shield.SetActive(true);



        }
        else
        {
            Shield.SetActive(false);

        }

        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Punch"))

        {
            
            Sword_1.SetActive(true);
            


        }
        else
        {
            Sword_1.SetActive(false);

        }
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Kick"))

        {
            
            Sword_2.SetActive(true);

            rageFoot.SetActive(true);
            rageFoot2.SetActive(true);


        }
        else
        {
            Sword_2.SetActive(false);
            rageFoot.SetActive(false);
            rageFoot2.SetActive(false);
        }
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Ult"))

        {

            
            Sword_3.SetActive(true);


        }
        else
        {
            Sword_3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            
            anim.SetBool("Jump", false);
            anim.SetBool("Run", false);
            anim.SetBool("Idle", false);
            anim.SetBool("Attack", false);
            anim.SetBool("Kick", false);
            anim.SetBool("Block", false);
            anim.SetBool("Dunk", false);
            anim.SetTrigger("Ult");




        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            rageFoot3.SetActive(true);
            rageFoot4.SetActive(true);
            speed = 20f;
        }
        else
        {
            rageFoot3.SetActive(false);
            rageFoot4.SetActive(false);
            speed = 10f;
        }



    }
    void OnCollisionEnter(Collision collision)
    {
        
        _onGround = true;
        _currentJump = 0;
    }
    void OnCollisionExit(Collision collision)
    {

       
        _currentJump = 1;

    }
    void Hitter1()
    {

        Hit.SetActive(true);
        


    }
    void Hitter2()
    {
        Hit2.SetActive(true);
        

    }
    void Hitter3()
    {
        
        Hit3.SetActive(true);
        RageStream.Play();
        RageFlow.Play();
        if (_onGround == false)
        {
            rb.AddForce(Vector3.down * jumpForce * 2, ForceMode.Impulse);
        }

    }
    void TakeTire1()
    {
        this.GetComponent<P1FighterHP>().UseStamina(tire);
    }
    void TakeTire2()
    {
        this.GetComponent<P1FighterHP>().UseStamina(tire2);
    }
    void TakeTire3()
    {
        this.GetComponent<P1FighterHP>().UseStamina(tire3);
    }
}
