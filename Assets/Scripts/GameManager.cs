using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public enum NumeroJugador
{
    UNO, DOS
}

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textMarcador1;
    public TextMeshProUGUI textMarcador2;


    public TextMeshProUGUI textGolesSeguidos1;
    public TextMeshProUGUI textGolesSeguidos2;


    public BallController ballController;

    public GameObject objectToPaddle1Efecto;

    public GameObject objectToPaddle2Efecto;

    public GameObject objectToEfectoTriplete;

    public GameObject objectToEfectoFondo;


    public GameObject BarreraJ1;
    public GameObject BarreraJ2;


    public GameObject objectToSpecialBall;

    public GameObject objectToBall;


    public PaddleController mypaddleController;

    private int puntajeJugador1 = 0;
    private int puntajeJugador2 = 0;
    private bool mIsRunning = true;

    private int golesSeguidosJ1 = 0;

    private int golesSeguidosJ2 = 0;
      
    

    private void Start()
    {
        // Se inscribe el GameManager al evento OnGoal
        ballController.OnGoal += BallController_OnGoal;
        textMarcador1.text = puntajeJugador1.ToString();
        textMarcador2.text = puntajeJugador2.ToString();

        textMarcador1.text = puntajeJugador1.ToString();
        textMarcador2.text = puntajeJugador2.ToString();


    }

    private void BallController_OnGoal(object sender, System.EventArgs e)
    {
        NumeroJugador numJugador = (e as OnGoalEventArg).jugador;

        

        if (numJugador == NumeroJugador.UNO)
        {
            puntajeJugador1++;
            golesSeguidosJ1++;
            golesSeguidosJ2=0;

            

            //EFECTO DE METER UN GOL DEL JUGADOR 1
            objectToPaddle1Efecto.SetActive(true);
            
           
        }else
        {
            puntajeJugador2++;

            golesSeguidosJ2++;
            golesSeguidosJ1=0;
            //EFECTO DE METER UN GOL DEL JUGADOR 2
            objectToPaddle2Efecto.SetActive(true);

                       
        }

        //EFECTOS DE METER UN TRIPLETE
        if (golesSeguidosJ1 ==3)
        {
                objectToEfectoTriplete.SetActive(true);
                
        }
        else if (golesSeguidosJ1==4)
        {
            objectToEfectoFondo.SetActive(true);
        }
        
        
         else if (golesSeguidosJ1>=5)
        {   //EFECTOS DE METER UN QUINTUPLETE

                objectToEfectoTriplete.SetActive(true);
                objectToEfectoFondo.SetActive(true);

                // SE CREA UNA BARRERA PARA EL JUGADOR QUE VA PERDIENDO
                BarreraJ2.SetActive(true);
                

        }
        
        //EFECTOS DE METER UN TRIPLETE
        if (golesSeguidosJ2 ==3)
        {
                objectToEfectoTriplete.SetActive(true);
                
        } 
         else if (golesSeguidosJ2==4)
        {
            objectToEfectoFondo.SetActive(true);
        }
        else if (golesSeguidosJ2>=5)
        {   //EFECTOS DE METER UN QUINTUPLETE
                objectToEfectoTriplete.SetActive(true);
                objectToEfectoFondo.SetActive(true);

                // SE CREA UNA BARRERA PARA EL JUGADOR QUE VA PERDIENDO
                BarreraJ1.SetActive(true);
                
        }
       

        textGolesSeguidos1.text = golesSeguidosJ1.ToString();

        textGolesSeguidos2.text = golesSeguidosJ2.ToString();


        textMarcador1.text = puntajeJugador1.ToString();
        textMarcador2.text = puntajeJugador2.ToString();

        ballController.ReInit();
        mIsRunning = false;
    }

    private void Update()
    {
        if (!mIsRunning && Input.GetKeyDown(KeyCode.Space))
        {
            ballController.ReStart();
            mIsRunning = true;

            // SE DESACTIVAN TODOS LOS EFECTOS Y VENTAJAS
            
            objectToPaddle1Efecto.SetActive(false);
            objectToPaddle2Efecto.SetActive(false);
            objectToEfectoTriplete.SetActive(false);
            objectToEfectoFondo.SetActive(false);

            //logica de desaparicon de barreras
            if (2 >  golesSeguidosJ1)
            {
                BarreraJ2.SetActive(false);
            }
            if (golesSeguidosJ2 < 2 )
            {
                BarreraJ1.SetActive(false);
            }

          
        
        }
    }


}
