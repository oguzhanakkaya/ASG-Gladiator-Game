using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class SingleGamePhysicalSelection : MonoBehaviour
{

    public int CharacterNumber,MovementSpeed,Power,RemainingSkillsPoint,Strength,Stamina,SpecialSkills;
    public readonly string SelectedCharacter = "Selected Character";
    public GameObject Character, Cavalier, Gladiator, Vikings;
    public bool Control = true;
    public Text MovementSpeedText, RemainingSkillsText, PowerText, StrengthText, StaminaText, SpecialSkillsText;
    public Button MovementSpeedButtonUp, MovementSpeedButtonDown, PowerButtonUp, PowerButtonDown;
    public Button StrengthButtonUp, StrengthButtonDown, StaminaButtonUp, StaminaButtonDown, SpecialSkillsButtonUp, SpecialSkillsButtonDown;


    void Start()
    {
        CharacterNumber = PlayerPrefs.GetInt(SelectedCharacter);

        SetSkillsPoint();
        SetButton();
        SetTextBox();

        /* Gladiator = Resources.Load("Prefabs/Knight11") as GameObject;
         Vikings = Resources.Load("Prefabs/Knight2") as GameObject;
         Cavalier = Resources.Load("Prefabs/Knight3") as GameObject;*/

    }


    void Update()
    {
        PrintTextBox();

        CheckPoints();


        if (Control)
        {
            GetCharacter();
            Character.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
            Instantiate(Character, new Vector3(-3, 0, 0), Quaternion.identity);

            Control = false;
        }
       
      


    }
    public void GetCharacter()
    {
        switch (CharacterNumber)
        {
            case 1:
                Character = Cavalier;
                break;
            case 2:
                Character = Vikings;
                break;
            case 3:
                Character = Gladiator;
                break;
            default:
                break;
        }
    }
    public void SetButton()
    {
        MovementSpeedButtonUp = GameObject.Find("MovementSpeedButtonUp").GetComponent<Button>();
        MovementSpeedButtonDown = GameObject.Find("MovementSpeedButtonDown").GetComponent<Button>();
        PowerButtonUp = GameObject.Find("PowerButtonUp").GetComponent<Button>();
        PowerButtonDown = GameObject.Find("PowerButtonDown").GetComponent<Button>();
        StrengthButtonUp = GameObject.Find("StrengthButtonUp").GetComponent<Button>();
        StrengthButtonDown = GameObject.Find("StrengthButtonDown").GetComponent<Button>();
        StaminaButtonUp = GameObject.Find("StaminaButtonUp").GetComponent<Button>();
        StaminaButtonDown = GameObject.Find("StaminaButtonDown").GetComponent<Button>();
        SpecialSkillsButtonUp = GameObject.Find("SpecialSkillsButtonUp").GetComponent<Button>();
        SpecialSkillsButtonDown = GameObject.Find("SpecialSkillsButtonDown").GetComponent<Button>();

        MovementSpeedButtonUp.onClick.AddListener(MovementSpeedUp);
        MovementSpeedButtonDown.onClick.AddListener(MovementSpeedDown);
        PowerButtonUp.onClick.AddListener(PowerUp);
        PowerButtonDown.onClick.AddListener(PowerDown);
        StrengthButtonUp.onClick.AddListener(StrengthUp);
        StrengthButtonDown.onClick.AddListener(StrengthDown);
        StaminaButtonUp.onClick.AddListener(StaminaUp);
        StaminaButtonDown.onClick.AddListener(StaminaDown);
        SpecialSkillsButtonUp.onClick.AddListener(SpecialSkillsUp);
        SpecialSkillsButtonDown.onClick.AddListener(SpecialSkillsDown);
    }
    public void SetTextBox()
    {


        MovementSpeedText = GameObject.Find("MovementSpeedText").GetComponent<Text>();
        RemainingSkillsText = GameObject.Find("RemainingSkillsText").GetComponent<Text>();
        PowerText = GameObject.Find("PowerText").GetComponent<Text>();
        StrengthText = GameObject.Find("StrengthText").GetComponent<Text>();
        StaminaText = GameObject.Find("StaminaText").GetComponent<Text>();
        SpecialSkillsText = GameObject.Find("SpecialSkillsText").GetComponent<Text>();


    }
    public void MovementSpeedUp ()
    {
        MovementSpeed += 1;
        RemainingSkillsPoint -= 1;
    }
    public void MovementSpeedDown()
    {
        
        MovementSpeed -= 1;
        RemainingSkillsPoint += 1;
    }
    public void PowerUp()
    {
        Power += 1;
        RemainingSkillsPoint -= 1;
    }
    public void PowerDown()
    {
        Power -= 1;
        RemainingSkillsPoint += 1;
    }
    public void StrengthUp()
    {
        Strength += 1;
        RemainingSkillsPoint -= 1;
    }
    public void StrengthDown()
    {
        Strength -= 1;
        RemainingSkillsPoint += 1;
    }
    public void StaminaUp()
    {
        Stamina += 1;
        RemainingSkillsPoint -= 1;
    }
    public void StaminaDown()
    {
        Stamina -= 1;
        RemainingSkillsPoint += 1;

    }
    public void SpecialSkillsUp()
    {
        SpecialSkills += 1;
        RemainingSkillsPoint -= 1;
    }
    public void SpecialSkillsDown()
    {
        SpecialSkills -= 1;
        RemainingSkillsPoint += 1;
    }
    public void SetSkillsPoint()
    {
        RemainingSkillsPoint = 6;
        MovementSpeed = 1;
        Power = 1;
        Strength = 1;
        Stamina = 1;
        SpecialSkills = 1;
    }
    public void PrintTextBox()
    {

        RemainingSkillsText.text= RemainingSkillsPoint.ToString();
        MovementSpeedText.text = MovementSpeed.ToString();
        PowerText.text = Power.ToString();
        StrengthText.text = Strength.ToString();
        StaminaText.text = Stamina.ToString();
        SpecialSkillsText.text = SpecialSkills.ToString();

    }
    public void CheckPoints()
    {
        if (RemainingSkillsPoint == 0)
        {
            MovementSpeedButtonUp.gameObject.SetActive(false);
            PowerButtonUp.gameObject.SetActive(false);
            StrengthButtonUp.gameObject.SetActive(false);
            StaminaButtonUp.gameObject.SetActive(false);
            SpecialSkillsButtonUp.gameObject.SetActive(false);
        }
        if (RemainingSkillsPoint > 0)
        {
            MovementSpeedButtonUp.gameObject.SetActive(true);
            PowerButtonUp.gameObject.SetActive(true);
            StrengthButtonUp.gameObject.SetActive(true);
            StaminaButtonUp.gameObject.SetActive(true);
            SpecialSkillsButtonUp.gameObject.SetActive(true);
        }
        if (MovementSpeed == 1)
        {
            MovementSpeedButtonDown.gameObject.SetActive(false);
        }
        else
        {
            MovementSpeedButtonDown.gameObject.SetActive(true);
        }


        if (Strength == 1)
        {
            StrengthButtonDown.gameObject.SetActive(false);
        }
        else
        {
            StrengthButtonDown.gameObject.SetActive(true);
        }


        if (Stamina == 1)
        {
            StaminaButtonDown.gameObject.SetActive(false);
        }
        else
        {
            StaminaButtonDown.gameObject.SetActive(true);
        }


        if (SpecialSkills == 1)
        {
            SpecialSkillsButtonDown.gameObject.SetActive(false);
        }
        else
        {
            SpecialSkillsButtonDown.gameObject.SetActive(true);
        }


        if (Power == 1)
        {
            PowerButtonDown.gameObject.SetActive(false);
        }
        else
        {
            PowerButtonDown.gameObject.SetActive(true);
        }
    }
}
