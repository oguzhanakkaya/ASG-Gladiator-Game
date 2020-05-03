using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerMovement : MonoBehaviour
{
    public GameObject player, computer;
    public Animator animation_player, animation_computer;
    public Text player_text, computer_text;
    public int player_health, computer_health, player_energy, computer_energy;
    public Camera Main_Camera;
    public int check;
    public Transform computer_transform, player_transform, camera_transform, temp_transform;
    public SingleGameRoom gameRoom;
    public bool ToLeft, ToRight, Attack1, Attack2, Attack3,Sleep;
    void Start()
    {
         animation_player = player.GetComponent<Animator>();
         animation_computer = computer.GetComponent<Animator>();
}

  
    void Update()
    {
        SetActions();
    }
    public void WalkLeft()
    {
        Debug.Log("walkback");



        animation_computer.speed = +2.0f;
        animation_computer.Play("walkBack");

        computer_transform.position = computer_transform.position - new Vector3(1.0f, 0.0f, 0.0f);

        computer_energy = computer_energy - 10;
        computer_text.text = "Health:" + (computer_health) + "/100" + "\n\nEnergy:" + computer_energy + "/100";
        check = check + 1;
        gameRoom.SetTurnControlToTrue();

    }
    public void WalkRight()
    {

        Debug.Log("walkback");



        animation_computer.speed = +2.0f;
        animation_computer.Play("walkBack");

        computer_transform.position = computer_transform.position + new Vector3(1.0f, 0.0f, 0.0f);

        computer_energy = computer_energy - 10;
        computer_text.text = "Health:" + (computer_health) + "/100" + "\n\nEnergy:" + computer_energy + "/100";
        check = check + 1;
        gameRoom.SetTurnControlToTrue();
    }
    public void QuickAttack()
    {
        /* if ((Mathf.Abs(spawn2.position.x - spawn1.position.x)) >= 1.0f)
         {*/

        Debug.Log("ataack1");
        animation_computer.speed = +1.0f;
        animation_computer.Play("attack1");
        animation_player.Play("hurt");
        animation_player.speed = +1.0f;
        check = check + 1;

    }
    public void NormalAttack()
    {

        Debug.Log("attack2");
      
        animation_computer.speed = +1.0f;
        animation_computer.Play("attack2");
        animation_player.Play("hurt");
        animation_player.speed = +1.0f;
        check = check + 1;

    }
    public void HardAttack()
    {
        /* if ((Mathf.Abs(spawn2.position.x - spawn1.position.x)) >= 1.0f)
         {*/

        Debug.Log("attack3");
      
        animation_computer.speed = +1.0f;
        animation_computer.Play("attack3");
        animation_player.Play("hurt");
        animation_player.speed = +1.0f;
        check = check + 1;
        /*}*/
    }
    public void PrintTextbox()
    {

        player_health = 100;
        computer_health = 100;
        player_energy = 100;
        computer_energy = 100;

        player_text = GameObject.Find("Player_Text").GetComponent<Text>();
        player_text.text = "Health:" + player_health + "/100" + "\n\nEnergy:" + player_energy + "/100";

        computer_text = GameObject.Find("Computer_Text").GetComponent<Text>();
        computer_text.text = "Health:" + computer_health + "/100" + "\n\nEnergy:" + computer_energy + "/100";
    }
    public void SetActions()
    {
        ToLeft = true;
        ToRight = true;
        Sleep = true;

        if ((Mathf.Abs(computer.transform.position.x - player.transform.position.x)) > 1.0f)
        {
            Attack1 = false;
            Attack2 = false;
            Attack3 = false;
        }
        else
        {
            Attack1 = true;
            Attack2 = true;
            Attack3 = true;
        }
    }
}
