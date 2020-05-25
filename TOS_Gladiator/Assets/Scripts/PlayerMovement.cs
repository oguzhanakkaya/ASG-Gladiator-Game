using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject computer;
    public Animator animation_player, animation_computer;
    public Text player_text, computer_text;
    public int player_health, computer_health, player_energy, computer_energy;
    public Camera Main_Camera;
    public int hit, miss;
    public Transform computer_transform, camera_transform, temp_transform;
    public SingleGameRoom gameRoom;

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

        animation_player.speed = +2.0f;
        animation_player.Play("walkBack");

        gameRoom.player.transform.position -= new Vector3(1.0f, 0.0f, 0.0f) * MovementSpeed;

        player_energy = player_energy - 10;
        player_text.text = "Health:" + (player_health) + "\n\nEnergy:" + player_energy;

        gameRoom.SetTurnControlToTrue();

    }
    public void WalkRight()
    {
        Debug.Log("walkforw");

        animation_player.speed = +2.0f;
        animation_player.Play("walkForw");

        gameRoom.player.transform.position += new Vector3(1.0f, 0.0f, 0.0f) * MovementSpeed;

        player_energy = player_energy - 10;
        player_text.text = "Health:" + (player_health) + "\n\nEnergy:" + player_energy;

        gameRoom.SetTurnControlToTrue();

    }
    public void QuickAttack()
    {
        Debug.Log("ataack1");

        miss = Random.Range(0, 100);

        if (miss <= 10)
        {
            Debug.Log(miss);
            Debug.Log("Miss");
        }
        else
        {

            animation_player.speed = +1.0f;
            animation_player.Play("attack1");        
            animation_computer.Play("hurt");
            animation_computer.speed = +1.0f;
            int hit = Random.Range(1, 10) * Power;
            player_energy -= 10;
            Debug.Log(hit);
            computer_health -= hit;
        }

        player_text.text = "Health:" + player_health + "\n\nEnergy:" + player_energy;
        computer_text.text = "Health:" + computer_health + "\n\nEnergy:" + computer_energy;

        gameRoom.SetTurnControlToTrue();
    }
    public void NormalAttack()
    {
        Debug.Log("attack2");

        miss = Random.Range(0, 100);

        if (miss <= 30)
        {
            Debug.Log(miss);
            Debug.Log("Miss");
        }
        else
        {

            animation_player.speed = +1.0f;
            animation_player.Play("attack2");


            animation_computer.Play("hurt");
            animation_computer.speed = +1.0f;

            int hit = Random.Range(10, 20) * Power;
            player_energy -= 10;
            computer_health -= hit;
            Debug.Log(hit);

        }


        player_text.text = "Health:" + player_health + "\n\nEnergy:" + player_energy;
        computer_text.text = "Health:" + computer_health + "\n\nEnergy:" + computer_energy;

        gameRoom.SetTurnControlToTrue();

    }
    public void HardAttack()
    {
        Debug.Log("attack3");

        miss = Random.Range(0, 100);

        if (miss <= 50)
        {
            Debug.Log(miss);
            Debug.Log("Miss");
        }
        else
        {

            animation_player.speed = +1.0f;
            animation_player.Play("attack3");
            animation_computer.Play("hurt");
            animation_computer.speed = +1.0f;

            int hit = Random.Range(20, 30) * Power;
            player_energy -= 10;
            computer_health -= hit;
            Debug.Log(hit);

        }


        player_text.text = "Health:" + player_health + "\n\nEnergy:" + player_energy;
        computer_text.text = "Health:" + computer_health + "\n\nEnergy:" + computer_energy;



        gameRoom.SetTurnControlToTrue();
    }
    public void Sleep()
    {
        Debug.Log("sleep");

        animation_player.speed = +1.0f;
        animation_player.Play("attack3");

        gameRoom.SetTurnControlToTrue();
    }
    public void PrintTextbox()
    {
        player_health = 50 * PlayerPrefs.GetInt(StrengthString, 0);
        player_energy = 50 * PlayerPrefs.GetInt(StaminaString, 0);

        computer_energy = 100;
        computer_health = 100;

        player_text = GameObject.Find("Player_Text").GetComponent<Text>();
        player_text.text = "Health:" + player_health + "\n\nEnergy:" + player_energy;

        computer_text = GameObject.Find("Computer_Text").GetComponent<Text>();
        computer_text.text = "Health:" + computer_health + "\n\nEnergy:" + computer_energy;
    }
    public void SetSkillPointsToCharacter()
    {
        MovementSpeed = PlayerPrefs.GetInt(MovementSpeedString, 0);
        Power = PlayerPrefs.GetInt(PowerString, 0);
        Strength = PlayerPrefs.GetInt(StrengthString, 0);
        Stamina = PlayerPrefs.GetInt(StaminaString, 0);
        SpecialSkills = PlayerPrefs.GetInt(SpecialSkillsString, 0);
    }
    
}

  

