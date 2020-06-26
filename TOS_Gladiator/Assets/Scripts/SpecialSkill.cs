using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialSkill : MonoBehaviour
{
    public Canvas SpecialSkillCanvas;
    public SingleGameRoom gameRoom;
    public Button ThunderBoltButton;
    public GameObject ThunderBolt;
    public PlayerMovement playerMovement;
    public float SkillTimer;
 
    void Start()
    {
        //SpecialSkillCanvas= GameObject.Find("SpecialSkillCanvas").GetComponent<Canvas>();
        SpecialSkillCanvas.gameObject.SetActive(false);
        //ThunderBoltButton = GameObject.Find("ThunderBoltButton").GetComponent<Button>();
        ThunderBoltButton.onClick.AddListener(ThunderBoltSkill);
        ThunderBolt = GameObject.Find("ThunderBolt");
        ThunderBolt.SetActive(false);
    }

   
    void Update()
    {
        if (ThunderBolt.activeSelf == true)
        {
            ThunderBoltSkillTimerFunc();
        }
    }
    public void SpecialSkillCanvasDisplay()
    {
        SpecialSkillCanvas.gameObject.SetActive(true);
    }
    public void SpecialSkillsCanvasClose()
    {
        SpecialSkillCanvas.gameObject.SetActive(false);
    }
    public void ThunderBoltSkill()
    {
       
        Debug.Log("thunder");
        ThunderBolt.SetActive(true);
        ThunderBolt.transform.position = new Vector3(playerMovement.computer.transform.position.x-1,playerMovement.computer.transform.position.y+1,0);

        gameRoom.SetTurnControlToComputer();
    }
    public void ThunderBoltSkillTimerFunc()
    {
        SkillTimer += Time.deltaTime;

        if(SkillTimer>=0.5f)
        {
            playerMovement.animation_computer.Play("hurt");
            playerMovement.animation_computer.speed = +1.0f;
        }

        if (SkillTimer >= 1f)
        {
            int hit = Random.Range(10, 15) * playerMovement.SpecialSkills;
            playerMovement.PlayerEnergy -= 30;
            playerMovement.ComputerHealth -= hit;
            ThunderBolt.SetActive(false);
            SkillTimer = 0;
        }
    }
}
