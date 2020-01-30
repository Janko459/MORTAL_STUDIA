using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerPick : MonoBehaviour
{
    [SerializeField] private GameObject Janko;
    [SerializeField] private GameObject Anuk;
    [SerializeField] private GameObject Borys;
    [SerializeField] private GameObject Staszko;
    [SerializeField] private GameObject Janko_P2;
    [SerializeField] private GameObject Anuk_P2;
    [SerializeField] private GameObject Borys_P2;
    [SerializeField] private GameObject Staszko_P2;
    //CHARACTERS
    [SerializeField] private GameObject Jan;
    [SerializeField] private GameObject Anu;
    [SerializeField] private GameObject Boryc;
    [SerializeField] private GameObject Stacho;
    [SerializeField] private GameObject Jan_p2;
    [SerializeField] private GameObject Anu_p2;
    [SerializeField] private GameObject Boryc_p2;
    [SerializeField] private GameObject Stacho_p2;
    //Character pickers in selector window
    [SerializeField] private GameObject Fight;

    [SerializeField] private GameObject MovingObjects;
    [SerializeField] private GameObject pickerCamera;
    [SerializeField] private GameObject thisCanvas;
    [SerializeField] private GameObject PlayerCanvas;

    
    // Start is called before the first frame update
    void Start()
    {
        Fight.SetActive(false);
        Jan.SetActive(false);
        Anu.SetActive(false);
        Boryc.SetActive(false);
        Stacho.SetActive(false);
        Jan_p2.SetActive(false);
        Anu_p2.SetActive(false);
        Boryc_p2.SetActive(false);
        Stacho_p2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Jan.activeInHierarchy == true || Anu.activeInHierarchy == true || Boryc.activeInHierarchy == true || Stacho.activeInHierarchy == true)
            && (Jan_p2.activeInHierarchy == true || Anu_p2.activeInHierarchy == true || Boryc_p2.activeInHierarchy == true || Stacho_p2.activeInHierarchy == true))
        {
            Fight.SetActive(true);
        }
        else
        {
            Fight.SetActive(false);
        }
    }
    public void JankoisPicked()
    {
        Jan.SetActive(true);
        Anu.SetActive(false);
        Boryc.SetActive(false);
        Stacho.SetActive(false);
    }
    public void AnukisPicked()
    {
        Jan.SetActive(false);
        Anu.SetActive(true);
        Boryc.SetActive(false);
        Stacho.SetActive(false);
    }
    public void BorysisPicked()
    {
        Jan.SetActive(false);
        Anu.SetActive(false);
        Boryc.SetActive(true);
        Stacho.SetActive(false);
    }
    public void StachoisPicked()
    {
        Jan.SetActive(false);
        Anu.SetActive(false);
        Boryc.SetActive(false);
        Stacho.SetActive(true);
    }
    public void JankoP2isPicked()
    {
        Jan_p2.SetActive(true);
        Anu_p2.SetActive(false);
        Boryc_p2.SetActive(false);
        Stacho_p2.SetActive(false);
    }
    public void AnukP2isPicked()
    {
        Jan_p2.SetActive(false);
        Anu_p2.SetActive(true);
        Boryc_p2.SetActive(false);
        Stacho_p2.SetActive(false);
    }
    public void BorysP2isPicked()
    {
        Jan_p2.SetActive(false);
        Anu_p2.SetActive(false);
        Boryc_p2.SetActive(true);
        Stacho_p2.SetActive(false);
    }
    public void StachoP2isPicked()
    {
        Jan_p2.SetActive(false);
        Anu_p2.SetActive(false);
        Boryc_p2.SetActive(false);
        Stacho_p2.SetActive(true);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }
    public void FIGHT()
    {
        MovingObjects.SetActive(true);
        

        if(Jan.activeInHierarchy == true)
        {
            Janko.SetActive(true);
        }
        if (Anu.activeInHierarchy == true)
        {
            Anuk.SetActive(true);
        }
        if (Boryc.activeInHierarchy == true)
        {
            Borys.SetActive(true);
        }
        if (Stacho.activeInHierarchy == true)
        {
            Staszko.SetActive(true);
        }
        if (Jan_p2.activeInHierarchy == true)
        {
            Janko_P2.SetActive(true);
        }
        if (Anu_p2.activeInHierarchy == true)
        {
            Anuk_P2.SetActive(true);
        }
        if (Boryc_p2.activeInHierarchy == true)
        {
            Borys_P2.SetActive(true);
        }
        if (Stacho_p2.activeInHierarchy == true)
        {
            Staszko_P2.SetActive(true);
        }
        PlayerCanvas.SetActive(true);
        thisCanvas.SetActive(false);
        pickerCamera.SetActive(false);
    }
}
