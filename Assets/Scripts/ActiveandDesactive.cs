using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveandDesactive : MonoBehaviour
{

    public GameObject ocjectActivateAndDesactive;

    public PaddleController mypaddleController;
    
    public InteligenciaArtificial myinteligenciaArtificial;

    // Start is called before the first frame update
    void Start()
    {
       
    }
     
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            if (myinteligenciaArtificial.enabled == true)
            {
                myinteligenciaArtificial.enabled = false;
                mypaddleController.enabled = true;
            } else {
                myinteligenciaArtificial.enabled = true;
                mypaddleController.enabled = false;
            }           
        }
        
    }
}