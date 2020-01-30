using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnuMovP1 : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;
    private Animator anim;

    public int tire = 1;
    public int tire2 = 5;
    public int tire3 = 90;

    [SerializeField] private GameObject CameraR;
    [SerializeField] private GameObject CameraL;
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
    [SerializeField] private GameObject Hit4;
    [SerializeField] private ParticleSystem GroundSmasher;
    //hits
    [SerializeField] private GameObject Shield;
    [SerializeField] private GameObject Sword_1;
    [SerializeField] private GameObject Sword_2;
    [SerializeField] private GameObject Sword_3;
    //weapon
    [SerializeField] private GameObject refl1;
    [SerializeField] private GameObject refl2;
    [SerializeField] private GameObject refl3;
    //lights

    [SerializeField] private GameObject starSteps;
    [SerializeField] private GameObject starSteps2;
    [SerializeField] private GameObject mouth;
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
        refl2.SetActive(false);
        refl3.SetActive(false);

        Hit.SetActive(false);
        Hit2.SetActive(false);
        Hit3.SetActive(false);
        Hit4.SetActive(false);


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
        if (Input.GetKey(KeyCode.Keypad2))
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


        }
        else
        {
            Sword_2.SetActive(false);
        }
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("Ult"))

        {
            speed = 5f;
            CameraL.SetActive(true);
            CameraR.SetActive(false);
            Quaternion rot = new Quaternion();
            rot.eulerAngles = new Vector3(0, 0, 0);
            transform.rotation = rot;

            Sword_3.SetActive(true);
            starSteps.SetActive(true);
            starSteps2.SetActive(true);
            refl1.SetActive(true);
            mouth.SetActive(true);


        }
        else
        {
            speed = 10f;
            starSteps.SetActive(false);
            starSteps2.SetActive(false);
            refl1.SetActive(false);
            
            Sword_3.SetActive(false);
            mouth.SetActive(false);
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
        GroundSmasher.Play();
        refl2.SetActive(true);
    
    }
    void Hitter4()
    {
        Hit4.SetActive(true);
        GroundSmasher.Play();
        refl3.SetActive(true);
        
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
