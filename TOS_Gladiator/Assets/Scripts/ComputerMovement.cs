﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerMovement : MonoBehaviour
{
    public GameObject computer, MissShieldObject, MissShieldImage, HitImage,player;
    public Canvas HitCanvas;
  //  public Animator playerMovement.animation_player, playerMovement.animation_computer;
    public Text player_text, computer_text, HitText;
    public Camera Main_Camera;
    public Transform computer_transform, camera_transform, temp_transform;
    public SingleGameRoom gameRoommm;
    public int hit, miss;
    public PlayerMovement playerMovement;
    public float HitTimer;
    public CountdownTimer CountdownTimerScript;
    public int ComputerPoint, PlayerPoint;



    [System.Serializable]
    struct Actions
    {
        public float GivenHit;
        public float LostEnergy;
        public float Miss;

    }
   
    public bool ComputerWalkLeftBool, ComputerWalkRightBool, ComputerAttackBool, PlayerWalkLeftBool, PlayerWalkRightBool, PlayerAttackBool;

    public int MovementSpeed, Power, Strength, Stamina, SpecialSkills;
    void Start()
    {
    //    playerMovement.animation_player =gameRoommm.player.GetComponent<Animator>();
    //    playerMovement.animation_computer = computer.GetComponent<Animator>();
 



        MissShieldImage = GameObject.Find("MissShield");
        HitImage = GameObject.Find("HitImage");
        HitText = GameObject.Find("HitImageText").GetComponent<Text>();
        HitCanvas = GameObject.Find("HitCanvas").GetComponent<Canvas>();

        HitImage.SetActive(false);

        ComputerWalkLeftBool = false;
        ComputerWalkRightBool = false;
        ComputerAttackBool = false;
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
        Debug.Log("walkback");

        playerMovement.animation_computer.speed = +2.0f;
        playerMovement.animation_computer.Play("walkBack");

        gameRoommm.player.transform.position -= new Vector3(1.0f, 0.0f, 0.0f);  //* MovementSpeed;

        playerMovement.ComputerEnergy -= 10;
        computer_text.text = "Health:" + (playerMovement.ComputerHealth) + "\n\nEnergy:" + playerMovement.ComputerEnergy;

        gameRoommm.SetTurnControlToPlayer();

        CountdownTimerScript.CountdownAudio.Stop();

    }
    public void WalkRight()
    {
        Debug.Log("walkback");

        playerMovement.animation_computer.speed = +2.0f;
        playerMovement.animation_computer.Play("walkForw");

        gameRoommm.player.transform.position -= new Vector3(1.0f, 0.0f, 0.0f);  //* MovementSpeed;

        playerMovement.ComputerEnergy -= 10;
        computer_text.text = "Health:" + (playerMovement.ComputerHealth) + "\n\nEnergy:" + playerMovement.ComputerEnergy;

        gameRoommm.SetTurnControlToPlayer();

        CountdownTimerScript.CountdownAudio.Stop();

    }
    public void QuickAttack()
    {
        Debug.Log("ataack1");

        miss = Random.Range(0, 100);

        if (miss <= 5)
        {
            Debug.Log(miss);


            playerMovement.animation_computer.speed = +1.0f;
            playerMovement.animation_computer.Play("attack1");
            playerMovement.animation_player.Play("defans");
            playerMovement.animation_player.speed = +1.0f;

            ShowMissImage();

        }
        else
        {

            playerMovement.animation_computer.speed = +1.0f;
            playerMovement.animation_computer.Play("attack1");
            playerMovement.animation_player.Play("hurt");
            playerMovement.animation_player.speed = +1.0f;

            int hit = Random.Range(1, 5) * Power;
            playerMovement.ComputerEnergy -= 10;
            playerMovement.PlayerHealth -= hit;
            ShowHitImage();
        }


        player_text.text = "Health:" + playerMovement.PlayerHealth + "\n\nEnergy:" + playerMovement.PlayerEnergy;
        computer_text.text = "Health:" +playerMovement.ComputerHealth + "\n\nEnergy:" + playerMovement.ComputerEnergy;

        gameRoommm.SetTurnControlToPlayer();
        CountdownTimerScript.CountdownAudio.Stop();
    }
    public void NormalAttack()
    {
        Debug.Log("attack2");

        miss = Random.Range(0, 100);

        if (miss <= 20)
        {
            playerMovement.animation_computer.speed = +1.0f;
            playerMovement.animation_computer.Play("attack2");
            playerMovement.animation_player.Play("defans");
            playerMovement.animation_player.speed = +1.0f;

           

            ShowMissImage();
        }
        else
        {

            playerMovement.animation_player.speed = +1.0f;
            playerMovement.animation_player.Play("attack2");
            playerMovement.animation_computer.Play("hurt");
            playerMovement.animation_computer.speed = +1.0f;

            int hit = Random.Range(5, 10) * Power;
            playerMovement.ComputerEnergy -= 10;
            playerMovement.PlayerHealth -= hit;
            ShowHitImage();

        }


        player_text.text = "Health:" + playerMovement.PlayerHealth + "\n\nEnergy:" + playerMovement.PlayerEnergy;
        computer_text.text = "Health:" +playerMovement.ComputerHealth + "\n\nEnergy:" + playerMovement.ComputerEnergy;

        gameRoommm.SetTurnControlToPlayer();
        CountdownTimerScript.CountdownAudio.Stop();

    }
    public void HardAttack()
    {
        Debug.Log("attack3");

        miss = Random.Range(0, 100);

        if (miss <= 45)
        {
            playerMovement.animation_computer.speed = +1.0f;
            playerMovement.animation_computer.Play("attack3");
            playerMovement.animation_player.Play("defans");
            playerMovement.animation_player.speed = +1.0f;

            ShowMissImage();
        }
        else
        {

            playerMovement.animation_computer.speed = +1.0f;
            playerMovement.animation_computer.Play("attack3");
            playerMovement.animation_player.Play("hurt");
            playerMovement.animation_player.speed = +1.0f;

            int hit = Random.Range(10, 15) * Power;
            playerMovement.ComputerEnergy -= 10;
            playerMovement.PlayerHealth -= hit;
            ShowHitImage();

        }


        player_text.text = "Health:" + playerMovement.PlayerHealth + "\n\nEnergy:" + playerMovement.PlayerEnergy;
        computer_text.text = "Health:" +playerMovement.ComputerHealth + "\n\nEnergy:" + playerMovement.ComputerEnergy;



        gameRoommm.SetTurnControlToPlayer();
        CountdownTimerScript.CountdownAudio.Stop();
    }
    public void Sleep()
    {
        Debug.Log("sleep");

        gameRoommm.SetTurnControlToComputer();
        CountdownTimerScript.CountdownAudio.Stop();
    }
    public void ShowMissImage()
    {
        MissShieldObject = Instantiate(MissShieldImage, new Vector3 (gameRoommm.player.transform.position.x, gameRoommm.player.transform.position.y+1, gameRoommm.player.transform.position.z), 
        Quaternion.identity) as GameObject;
        MissShieldObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        MissShieldObject.transform.SetParent(gameRoommm.player.transform);

        Destroy(MissShieldObject, 1.0f);

    }
    public void ShowHitImage()
    {
        HitCanvas.transform.SetParent(gameRoommm.player.transform);
        HitImage.SetActive(true);
        HitImage.transform.position = new Vector3(9, -4.5f, 0);

        HitText.text = "aa";

    }
    public void HideImage()
    {
        if (HitImage.activeSelf == true)
        {
            HitTimer += Time.deltaTime;
            if (HitTimer >= 2)
            {
                HitImage.SetActive(false);
                HitTimer = 0;
            }
        }
    }
    public void ComputerActionCheck()
    {
        if (computer.transform.position.x-1.0f>=-14f)
        {
            ComputerWalkLeftBool = true;
        }
        if(computer.transform.position.x + 1.0f <= 14f)
        {
            ComputerWalkRightBool = true;
        }
        if (Mathf.Abs(gameRoommm.player.transform.position.x - computer.transform.position.x) < 3.0f)
        {
            ComputerAttackBool = true;
        }
    }
    public void PlayerActionCheck()
    {
       
        if (gameRoommm.player.transform.position.x - 1.0f*playerMovement.MovementSpeed >= -14f)
        {
            PlayerWalkLeftBool = true;
        }
        if (computer.transform.position.x + 1.0f * playerMovement.MovementSpeed <= 14f)
        {
            PlayerWalkRightBool = true;
        }
        if (Mathf.Abs(gameRoommm.player.transform.position.x - computer.transform.position.x) < 3.0f)
        {
            PlayerAttackBool = true;
        }
    }
    public void SetActionsFeature()
    {
        Actions WalkRightPoint;
        WalkRightPoint.GivenHit = 1;
        WalkRightPoint.LostEnergy = 10;
        WalkRightPoint.Miss = 1;


        Actions WalkLeftPoint;
        WalkLeftPoint.GivenHit = 1;
        WalkLeftPoint.LostEnergy = 10;
        WalkLeftPoint.Miss = 1;


        Actions QuickAttackPoint;
        QuickAttackPoint.GivenHit = 2.5f * (float)Power;
        QuickAttackPoint.LostEnergy = 10;
        QuickAttackPoint.Miss = 0.2f;


        Actions NormalAttackPoint;
        NormalAttackPoint.GivenHit = 7.5f * (float)Power;
        NormalAttackPoint.LostEnergy = 10;
        NormalAttackPoint.Miss = 0.05f;


        Actions HardAttackPoint;
        HardAttackPoint.GivenHit = 12.5f * (float)Power;
        HardAttackPoint.LostEnergy = 10;
        HardAttackPoint.Miss = 0.022f;

       // Actions SleepPoint;


    }
    public void CalculateGamePoint()
    {
        
    }


}