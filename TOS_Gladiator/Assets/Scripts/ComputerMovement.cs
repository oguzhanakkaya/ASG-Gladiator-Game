﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerMovement : MonoBehaviour
{
    public GameObject computer, MissShieldObject, MissShieldImage;
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

    public bool ComputerWalkLeftBool, ComputerWalkRightBool, ComputerAttackBool, ComputerSleepBool;

    public int MovementSpeed, Power, Strength, Stamina, SpecialSkills;
    void Start()
    {
        //    playerMovement.animation_player =gameRoommm.player.GetComponent<Animator>();
        //    playerMovement.animation_computer = computer.GetComponent<Animator>();


      

        MissShieldImage = GameObject.Find("MissShieldPlayer");


        ComputerWalkLeftBool = false;
        ComputerWalkRightBool = false;
        ComputerAttackBool = false;
    }

    void Update()
    {

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

        computer.transform.position -= new Vector3(1.0f, 0.0f, 0.0f) * MovementSpeed;  //* MovementSpeed;

        playerMovement.ComputerEnergy -= 5;
        computer_text.text = "Health:" + (playerMovement.ComputerHealth) + "\n\nEnergy:" + playerMovement.ComputerEnergy;


        gameRoommm.SetTurnControlToPlayer();

        CountdownTimerScript.CountdownAudio.Stop();

    }
    public void WalkRight()
    {
        Debug.Log("walkback");

        playerMovement.animation_computer.speed = +2.0f;
        playerMovement.animation_computer.Play("walkForw");

        computer.transform.position -= new Vector3(1.0f, 0.0f, 0.0f) * MovementSpeed;  //* MovementSpeed;

        playerMovement.ComputerEnergy -= 5;
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
            playerMovement.ComputerEnergy -= 10;

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

        }


        player_text.text = "Health:" + playerMovement.PlayerHealth + "\n\nEnergy:" + playerMovement.PlayerEnergy;
        computer_text.text = "Health:" + playerMovement.ComputerHealth + "\n\nEnergy:" + playerMovement.ComputerEnergy;

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
            playerMovement.ComputerEnergy -= 20;



            ShowMissImage();
        }
        else
        {

            playerMovement.animation_player.speed = +1.0f;
            playerMovement.animation_player.Play("attack2");
            playerMovement.animation_computer.Play("hurt");
            playerMovement.animation_computer.speed = +1.0f;

            int hit = Random.Range(5, 10) * Power;
            playerMovement.ComputerEnergy -= 20;
            playerMovement.PlayerHealth -= hit;


        }


        player_text.text = "Health:" + playerMovement.PlayerHealth + "\n\nEnergy:" + playerMovement.PlayerEnergy;
        computer_text.text = "Health:" + playerMovement.ComputerHealth + "\n\nEnergy:" + playerMovement.ComputerEnergy;

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
            playerMovement.ComputerEnergy -= 30;

            ShowMissImage();
        }
        else
        {

            playerMovement.animation_computer.speed = +1.0f;
            playerMovement.animation_computer.Play("attack3");
            playerMovement.animation_player.Play("hurt");
            playerMovement.animation_player.speed = +1.0f;

            int hit = Random.Range(10, 15) * Power;
            playerMovement.ComputerEnergy -= 30;
            playerMovement.PlayerHealth -= hit;


        }


        player_text.text = "Health:" + playerMovement.PlayerHealth + "\n\nEnergy:" + playerMovement.PlayerEnergy;
        computer_text.text = "Health:" + playerMovement.ComputerHealth + "\n\nEnergy:" + playerMovement.ComputerEnergy;



        gameRoommm.SetTurnControlToPlayer();
        CountdownTimerScript.CountdownAudio.Stop();
    }
    public void Sleep()
    {
        Debug.Log("sleep");


        playerMovement.ComputerEnergy += 50;

        player_text.text = "Health:" + playerMovement.PlayerHealth + "\n\nEnergy:" + playerMovement.PlayerEnergy;
        computer_text.text = "Health:" + playerMovement.ComputerHealth + "\n\nEnergy:" + playerMovement.ComputerEnergy;

        gameRoommm.SetTurnControlToPlayer();
        CountdownTimerScript.CountdownAudio.Stop();

    }
    public void ShowMissImage()
    {
        MissShieldObject = Instantiate(MissShieldImage, new Vector3(gameRoommm.player.transform.position.x, -4f, 0), Quaternion.identity) as GameObject;
        MissShieldObject.transform.SetParent(gameRoommm.player.transform);
        MissShieldObject.transform.localScale = new Vector3(2f, 2f, 2f);

        Destroy(MissShieldObject, 1.0f);
    }
    public void ComputerActionCheck()
    {
        if (computer.transform.position.x - 1.0f >= -14f)
        {
            ComputerWalkLeftBool = true;
        }
        else
        {
            ComputerWalkLeftBool = false;
        }

        if (computer.transform.position.x + 1.0f <= 14f)
        {
            ComputerWalkRightBool = true;
        }
        else
        {
            ComputerWalkRightBool = false;
        }

        if (Mathf.Abs(gameRoommm.player.transform.position.x - computer.transform.position.x) < 3.0f)
        {
            ComputerAttackBool = true;
        }
        else
        {
            ComputerAttackBool = false;
        }

        if (playerMovement.ComputerEnergy < 50f)
        {
            ComputerSleepBool = true;
        }
        else
        {
            ComputerSleepBool = false;
        }
    }
    public void SetAgility()
    {
        MovementSpeed = Random.Range(1, 3);
        Power = Random.Range(1, 3);
        Strength = Random.Range(1, 3);
        Stamina = Random.Range(1, 3);
        SpecialSkills = Random.Range(1, 3);
    }
}