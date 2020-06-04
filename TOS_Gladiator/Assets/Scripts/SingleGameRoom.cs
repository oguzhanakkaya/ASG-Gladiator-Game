using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SingleGameRoom : MonoBehaviour
{
    public bool temp, WaitBool;
    public float cameraZoom, cameraZoomDifference, cameraZoomSpeed, camera_x, CameraTimer;
    public int time,TurnControl;
    public GameObject player, computer;
    public Camera Main_Camera;
    public Button walkforw, walkBack, attack1, attack2, attack3, sleep,btn,btn1,btn3,btn4,btn5,btn6;   
    public Canvas HealthAndEnergyCanvas,PlayerActionButtons;
    public CountdownTimer countdowntimer;
    public PlayerMovement playerMovement;
    public ComputerMovement computerMovement;
    public ComputerAI ComputerAI;
    public readonly string SelectedCharacter = "Selected Character";

    void Start()
    {

        Main_Camera.orthographic = true;
        Main_Camera.orthographicSize = 8.0f;
        Main_Camera.transform.GetComponent<Camera>();


        SpawnPlayerCharacter();
        

        PlayerActionButtons.transform.parent = player.transform;

        playerMovement.SetTransforms();

        SetButton();
        ButtonDeactive();

        HealthAndEnergyCanvas.enabled = false;

        countdowntimer.SetTimerToFullTime();    

        TurnControl = 2;

        WaitBool = false;

        playerMovement.PrintTextbox();

        CameraTimer = 0f;
    }

   
    void Update()
    {
        playerMovement.SetTransforms();
        RotationCheck();
        playerMovement.CheckDied();

        if (TurnControl==1) // Turn for Player
        {
            CameraTimer = 0;
            CameraZoom();
            if (countdowntimer.time == 0)
            {
                TurnControl = 2;
                WaitBool = false;
               
            }
            
        }
        else if(TurnControl==2) // Turn for Computer
        {      
            CameraNormal();
             if(CameraTimer < 5f)
             {
                 CameraTimer += Time.deltaTime;
             }           
             if (CameraTimer >= 5f)
             {
                /*   TurnControl = 1;
                   WaitBool = true;*/
                ComputerAI.GetMoves();
                ComputerAI.CalculateMovesPoint();
                ComputerAI.SelectNextMove();


            }
           
            
        }
        else if (TurnControl == 3) // GameOver
        {
            CameraNormal();
           


        }

    }
    public void SetButton()
    {
       

        btn = GameObject.Find("walk_forward").GetComponent<Button>();  //Walk Right
        btn1 = GameObject.Find("walk_back").GetComponent<Button>();    // Walk Left
        btn3 = GameObject.Find("attack_1").GetComponent<Button>();
        btn4 = GameObject.Find("attack_2").GetComponent<Button>();
        btn5 = GameObject.Find("attack_3").GetComponent<Button>();
        btn6 = GameObject.Find("sleep").GetComponent<Button>();
      

        btn.onClick.AddListener(playerMovement.WalkRight);
        btn1.onClick.AddListener(playerMovement.WalkLeft);
        btn3.onClick.AddListener(playerMovement.QuickAttack);
        btn4.onClick.AddListener(playerMovement.NormalAttack);
        btn5.onClick.AddListener(playerMovement.HardAttack);
        btn6.onClick.AddListener(playerMovement.Sleep);
    }
    public void CameraZoom()
    {

        HealthAndEnergyCanvas.enabled = false;

        cameraZoomSpeed = 15f;
        cameraZoom = 4f;

        if (!(Mathf.Abs(player.transform.position.x - Main_Camera.transform.position.x)<0.5f))
        {
            if (player.transform.position.x < Main_Camera.transform.position.x)
            {
                Main_Camera.transform.position -= new Vector3(0.5f, 0.0f, 0.0f)*Time.deltaTime*cameraZoomSpeed;
                     
            }
            if (player.transform.position.x > Main_Camera.transform.position.x)
            {
                Main_Camera.transform.position += new Vector3(0.5f, 0.0f, 0.0f) * Time.deltaTime * cameraZoomSpeed;
            }
        }
        if (player.transform.position.y < Main_Camera.transform.position.y)
        {
            Main_Camera.transform.position -= new Vector3(0.0f, 0.5f, 0.0f) * Time.deltaTime * cameraZoomSpeed;
        }

        cameraZoomDifference = cameraZoom - Main_Camera.orthographicSize;
        Main_Camera.orthographicSize += cameraZoomDifference * cameraZoomSpeed * Time.deltaTime;

        if((Mathf.Abs(Main_Camera.transform.position.x-player.transform.position.x)<1 ) && (Mathf.Abs(Main_Camera.transform.position.y - player.transform.position.y) < 2))
        {
            ButtonActive();
            HealthAndEnergyCanvas.enabled = true;
        }

    } 
    public void CameraNormal()
    {
        ButtonDeactive();
        
        if(Mathf.Abs(player.transform.position.x - computer.transform.position.x)<=11f)
        {
            if (Mathf.Abs(player.transform.position.x - computer.transform.position.x)>=4f)
            {
                camera_x = (player.transform.position.x + computer.transform.position.x) / 2.0f;
                Main_Camera.transform.position = new Vector3(camera_x, -camera_x + 1, -10.0f);
                Main_Camera.orthographicSize = Mathf.Abs(player.transform.position.x - computer.transform.position.x) * 8 / 18 + 1;
            }
            else
            {
                camera_x = (player.transform.position.x + computer.transform.position.x) / 2.0f;
                Main_Camera.transform.position = new Vector3(camera_x, -camera_x + 3, -10.0f);
                Main_Camera.orthographicSize =3f;
            }
            
        }  
        else
        {
            camera_x = (player.transform.position.x + computer.transform.position.x) / 2.0f;
            Main_Camera.transform.position = new Vector3(camera_x, -camera_x, -10.0f);
            Main_Camera.orthographicSize = Mathf.Abs(player.transform.position.x - computer.transform.position.x) * 8 / 18;
        }
         
        countdowntimer.SetTimerToFullTime();
    }
    public void ButtonDeactive()
    {
        btn.gameObject.SetActive(false);
        btn1.gameObject.SetActive(false);
        btn3.gameObject.SetActive(false);
        btn4.gameObject.SetActive(false);
        btn5.gameObject.SetActive(false);
        btn6.gameObject.SetActive(false);

        countdowntimer.DeactiveTimer();
    }
    public void ButtonActive()
    {
        if (player.transform.position.x+playerMovement.MovementSpeed<=14)
        {
            btn.gameObject.SetActive(true);
        }
        if (player.transform.position.x - playerMovement.MovementSpeed >= -14)
        {
            btn1.gameObject.SetActive(true);
        }
        if (Mathf.Abs(player.transform.position.x-computer.transform.position.x)<3.0f)
        {
            btn3.gameObject.SetActive(true);
        }
        if (Mathf.Abs(player.transform.position.x - computer.transform.position.x) < 3.0f)
        {
            btn4.gameObject.SetActive(true);
        }
        if (Mathf.Abs(player.transform.position.x - computer.transform.position.x) < 3.0f)
        {
            btn5.gameObject.SetActive(true);
        }

        btn6.gameObject.SetActive(true);


        ActiveAndCountTimer();
        
      
    }
    public void ActiveAndCountTimer()
    {
        countdowntimer.ActiveTimer();
        countdowntimer.CountTimer();
    }
    public void SetTurnControlToComputer()
    {
            TurnControl = 2;     
    }
    public void SetTurnControlToPlayer()
    {
        TurnControl = 1;
    }
    public void GameFinished()
    {
        TurnControl = 3;
    }
    public void SpawnPlayerCharacter()
    {
        switch (PlayerPrefs.GetInt(SelectedCharacter, 0))
        {
            case 1:
                player = Instantiate(Resources.Load("Knight3", typeof(GameObject))) as GameObject;

                break;
            case 2:
                player = Instantiate(Resources.Load("Knight2", typeof(GameObject))) as GameObject;
                break;
            case 3:
                player = Instantiate(Resources.Load("Knight1", typeof(GameObject))) as GameObject;
                break;
            default:
                break;
        }
        player.transform.position = new Vector3(-9f, -6f, -5);
        player.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }
    public void RotationCheck()
    {
         if((player.transform.position.x- computer.transform.position.x)>0)
         {
             player.transform.rotation= Quaternion.Euler(new Vector3(0, -180, 0));
            computer.transform.rotation= Quaternion.Euler(new Vector3(0, 0, 0));

         }
         else if(player.transform.position.x <= computer.transform.position.x)
         {
             player.transform.rotation= Quaternion.Euler(new Vector3(0, 0, 0));
            computer.transform.rotation= Quaternion.Euler(new Vector3(0, -180, 0));

         }        
    }


}
