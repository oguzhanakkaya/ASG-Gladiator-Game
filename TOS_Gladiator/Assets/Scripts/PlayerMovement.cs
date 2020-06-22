using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject computer,MissShieldObject,MissShieldImage,HitImage;
    public Canvas HitCanvas;
    public Animator animation_player, animation_computer;
    public Text player_text, computer_text,HitText;   
    public Camera Main_Camera;
    public Transform computer_transform, camera_transform, temp_transform;
    public SingleGameRoom gameRoom;
    public int PlayerHealth, ComputerHealth, PlayerEnergy, ComputerEnergy, hit, miss;
    public float HitTimer;
    public CountdownTimer CountdownTimerScript;


    public readonly string MovementSpeedString = "Movement Speed";
    public readonly string PowerString = " Power";
    public readonly string StrengthString = "Strength String";
    public readonly string StaminaString = " Stamina String";
    public readonly string SpecialSkillsString = "Special Skills";
    public int MovementSpeed, Power, Strength, Stamina, SpecialSkills;
    void Start()
    {
        animation_player = gameRoom.player.GetComponent<Animator>();
        animation_computer = computer.GetComponent<Animator>();

        SetSkillPointsToCharacter();

        MissShieldImage=GameObject.Find("MissShieldComputer");
        HitImage = GameObject.Find("HitImageComputer");
       // HitText=GameObject.Find("HitImageText").GetComponent<Text>();
        HitCanvas= GameObject.Find("HitCanvasComputer").GetComponent<Canvas>();

        HitImage.SetActive(false);

    }

    void Update()
    {
        HideImage();
    }
    public void SetTransforms()
    {
        camera_transform.position = Main_Camera.transform.position;
    }
    public void WalkLeft()
    {
       

        animation_player.speed = +2.0f;
        animation_player.Play("walkBack");

        gameRoom.player.transform.position -= new Vector3(1.0f, 0.0f, 0.0f) * MovementSpeed;

        PlayerEnergy -= 5;
        player_text.text = "Health:" + (PlayerHealth) + "\n\nEnergy:" + PlayerEnergy;

        gameRoom.SetTurnControlToComputer();

        CountdownTimerScript.CountdownAudio.Stop();

    }
    public void WalkRight()
    {
        animation_player.speed = +2.0f;
        animation_player.Play("walkForw");

        gameRoom.player.transform.position += new Vector3(1.0f, 0.0f, 0.0f) * MovementSpeed;

        PlayerEnergy -= 5;
        player_text.text = "Health:" + (PlayerHealth) + "\n\nEnergy:" + PlayerEnergy;

        gameRoom.SetTurnControlToComputer();

        CountdownTimerScript.CountdownAudio.Stop();

    }
    public void QuickAttack()
    {
      

        miss = Random.Range(0, 100);

        if (miss <= 5)
        {
            Debug.Log(miss);
            

            animation_player.speed = +1.0f;
            animation_player.Play("attack1");
            animation_computer.Play("defans");
            animation_computer.speed = +1.0f;
            PlayerEnergy -= 10;

             
            ShowMissImage();

        }
        else
        {

            animation_player.speed = +1.0f;
            animation_player.Play("attack1");
            animation_computer.Play("hurt");
            animation_computer.speed = +1.0f;

            int hit = Random.Range(1, 5) * Power;
            PlayerEnergy -= 10;
            Debug.Log(hit);
            ComputerHealth -= hit;
            ShowHitImage();
        }

      
        player_text.text = "Health:" + PlayerHealth + "\n\nEnergy:" + PlayerEnergy;
        computer_text.text = "Health:" + ComputerHealth + "\n\nEnergy:" + ComputerEnergy;

        gameRoom.SetTurnControlToComputer();
        CountdownTimerScript.CountdownAudio.Stop();
    }
    public void NormalAttack()
    {
     

        miss = Random.Range(0, 100);

        if (miss <=20)
        {
            Debug.Log(miss);
            Debug.Log("Miss");
            animation_player.speed = +1.0f;
            animation_player.Play("attack2");
            animation_computer.Play("defans");
            animation_computer.speed = +1.0f;
            PlayerEnergy -= 20;

             ShowMissImage();
        }
        else
        {

            animation_player.speed = +1.0f;
            animation_player.Play("attack2");


            animation_computer.Play("hurt");
            animation_computer.speed = +1.0f;

            int hit = Random.Range(5, 10) * Power;
            PlayerEnergy -= 20;
            ComputerHealth -= hit;

            ShowHitImage();

        }


        player_text.text = "Health:" + PlayerHealth + "\n\nEnergy:" + PlayerEnergy;
        computer_text.text = "Health:" + ComputerHealth + "\n\nEnergy:" + ComputerEnergy;

        gameRoom.SetTurnControlToComputer();
        CountdownTimerScript.CountdownAudio.Stop();

    }
    public void HardAttack()
    {
      
        miss = Random.Range(0, 100);

        if (miss <= 45)
        {
            Debug.Log(miss);
            Debug.Log("Miss");
            animation_player.speed = +1.0f;
            animation_player.Play("attack3");
             animation_computer.Play("defans");
            animation_computer.speed = +1.0f;
            PlayerEnergy -= 30;

             ShowMissImage();
        }
        else
        {

            animation_player.speed = +1.0f;
            animation_player.Play("attack3");
            animation_computer.Play("hurt");
            animation_computer.speed = +1.0f;

            int hit = Random.Range(10,15) * Power;
            PlayerEnergy -= 30;
            ComputerHealth -= hit;
            ShowHitImage();

        }


        player_text.text = "Health:" + PlayerHealth + "\n\nEnergy:" + PlayerEnergy;
        computer_text.text = "Health:" + ComputerHealth + "\n\nEnergy:" + ComputerEnergy;



        gameRoom.SetTurnControlToComputer();
        CountdownTimerScript.CountdownAudio.Stop();
    }
    public void Sleep()
    {
        Debug.Log("sleep");

        PlayerEnergy += 50;
        player_text.text = "Health:" + PlayerHealth + "\n\nEnergy:" + PlayerEnergy;
        computer_text.text = "Health:" + ComputerHealth + "\n\nEnergy:" + ComputerEnergy;

        gameRoom.SetTurnControlToComputer();
        CountdownTimerScript.CountdownAudio.Stop();


    }
    public void PrintTextbox()
    {
        PlayerHealth = 50 * PlayerPrefs.GetInt(StrengthString, 0);
        PlayerEnergy = 50 * PlayerPrefs.GetInt(StaminaString, 0);

        ComputerEnergy = 100;
        ComputerHealth = 100;

        player_text = GameObject.Find("Player_Text").GetComponent<Text>();
        player_text.text = "Health:" + PlayerHealth + "\n\nEnergy:" + PlayerEnergy;

        computer_text = GameObject.Find("Computer_Text").GetComponent<Text>();
        computer_text.text = "Health:" + ComputerHealth + "\n\nEnergy:" + ComputerEnergy;
    }
    public void SetSkillPointsToCharacter()
    {
        MovementSpeed = PlayerPrefs.GetInt(MovementSpeedString, 0);
        Power = PlayerPrefs.GetInt(PowerString, 0);
        Strength = PlayerPrefs.GetInt(StrengthString, 0);
        Stamina = PlayerPrefs.GetInt(StaminaString, 0);
        SpecialSkills = PlayerPrefs.GetInt(SpecialSkillsString, 0);
    }
   public void ShowMissImage()
    {
        
        MissShieldObject = Instantiate(MissShieldImage, new Vector3(computer.transform.position.x, -4f, 0), Quaternion.identity) as GameObject;
        MissShieldObject.transform.SetParent(computer.transform);
        MissShieldObject.transform.localScale = new Vector3(2f, 2f, 2f);
        
       
        Destroy(MissShieldObject, 1.0f);
    }
    public void ShowHitImage()
    {
        HitCanvas.transform.SetParent(gameRoom.computer.transform);
        HitImage.SetActive(true);
        HitImage.transform.position = new Vector3(computer.transform.position.x, -4, 0);

      //  HitText.text = "aa";  

    }
    public void HideImage()
    {
        if (HitImage.activeSelf == true)
        {
            HitTimer += Time.deltaTime;
            if (HitTimer >= 1)
            {
                HitImage.SetActive(false);
                HitTimer = 0;
            }
        }
    }
  /*  public void CheckDied()
    {
        if(ComputerHealth <= 0)
        {        
            
            Debug.Log("Comp Died");
            animation_computer.Play("die");
            animation_computer.speed = +1.0f;
            gameRoom.GameFinished();
        }
        if (PlayerHealth <= 0)
        {

            Debug.Log("Comp Died");
            animation_player.Play("die");
            animation_player.speed = +1.0f;
            gameRoom.GameFinished();
        }
    }
    */
}

  

