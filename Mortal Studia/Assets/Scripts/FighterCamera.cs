using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterCamera : MonoBehaviour
{


    [SerializeField] private Transform Target;
   
  
    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void LateUpdate()
    {
        CamControl();
    }
    void CamControl()
    {

        transform.LookAt(Target);

    }


}
