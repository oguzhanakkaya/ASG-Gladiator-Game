using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player, computer;
    public Animator animation_player, animation_computer;
    public Text player_text, computer_text;
    public int player_health, computer_health, player_energy, computer_energy;
    public Camera Main_Camera;
    public int check;
    public Transform computer_transform, player_transform, camera_transform, temp_transform;
    public SingleGamePhysicalSelection Physical;
    public SingleGameRoom gameRoom;
    void Start()
    {
        animation_player = player.GetComponent<Animator>();
        animation_computer = computer.GetComponent<Animator>();
        
    }

    void Update()
    {
        
    }
    public void SetTransforms()
    {
        computer_transform.position = computer.transform.position;
        player_transform.position = player.transform.position;
        camera_transform.position = Main_Camera.transform.position;
    }
    public void WalkLeft()
    {
        Debug.Log("walkback");
       


        animation_player.speed = +2.0f;
        animation_player.Play("walkBack");

        player_transform.position = player_transform.position - new Vector3(1.0f, 0.0f, 0.0f);

        player_energy = player_energy - 10;
        player_text.text = "Health:" + (player_health) + "/100" + "\n\nEnergy:" + player_energy + "/100";
        check = check + 1;
        gameRoom.SetTurnControlToTrue();

    }
    public void WalkRight()
    {
        Debug.Log("walkforw");

        animation_player.speed = +2.0f;
        animation_player.Play("walkForw");
    
        player_transform.position = player_transform.position + new Vector3(1.0f, 0.0f, 0.0f);

        player_energy = player_energy - 10;
        player_text.text = "Health:" + (player_health) + "/100" + "\n\nEnergy:" + player_energy + "/100";

        gameRoom.SetTurnControlToTrue();
   
    }
    public void QuickAttack()
    {
        Debug.Log("ataack1");
        animation_player.speed = +1.0f;
        animation_player.Play("attack1");
        animation_computer.Play("hurt");
        animation_computer.speed = +1.0f;

        gameRoom.SetTurnControlToTrue();

    }
    public void NormalAttack()
    {
        Debug.Log("attack2");
        animation_player.speed = +1.0f;
        animation_player.Play("attack1");
        animation_computer.Play("hurt");
        animation_computer.speed = +1.0f;

        gameRoom.SetTurnControlToTrue();

    }
    public void HardAttack()
    {
        Debug.Log("attack3");
        animation_player.speed = +1.0f;
        animation_player.Play("attack3");
        animation_computer.Play("hurt");
        animation_computer.speed = +1.0f;

        gameRoom.SetTurnControlToTrue();
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
}
