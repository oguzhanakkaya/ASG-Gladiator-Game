using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SingleCharacterSelection : MonoBehaviour
{

    public Button NextButton, PreviousButton;
    public Text CharacterNameText;
    public GameObject Gladiator, Cavalier, Viking;
    

    void Start()
    {
        NextButton = GameObject.Find("NextCharacter").GetComponent<Button>();
        PreviousButton = GameObject.Find("PreviousCharacter").GetComponent<Button>();
        CharacterNameText= GameObject.Find("CharacterNameText").GetComponent<Text>();

        //Gladiator = GameObject.Find("GameObject");
        /*Cavalier = GameObject.Find("Cavalier");
        Viking = GameObject.Find("Viking");*/

        Gladiator.SetActive(true);
        CharacterNameText.text = "Gladiator";

        NextButton.onClick.AddListener(NextCharacter);
        PreviousButton.onClick.AddListener(PreviousCharacter);

    }

  
    void Update()
    {
       
    }
    public void NextCharacter()
    {
        if(Gladiator.activeSelf==true)
        {
            Gladiator.SetActive(false);
            Cavalier.SetActive(true);
            CharacterNameText.text = "Cavalier";
        }
        else if(Cavalier.activeSelf== true)    
        {
            Cavalier.SetActive(false);
            Viking.SetActive(true);
            CharacterNameText.text = "Viking";
        }
        else if (Viking.activeSelf == true)
        {
            Viking.SetActive(false);
            Gladiator.SetActive(true);
            CharacterNameText.text = "Gladiator";
        }

    }
    public void PreviousCharacter()
    {
        if (Gladiator.activeSelf == true)
        {
            Gladiator.SetActive(false);
            Viking.SetActive(true);
            CharacterNameText.text = "Viking";
        }
        else if (Cavalier.activeSelf == true)
        {
            Cavalier.SetActive(false);
            Gladiator.SetActive(true);
            CharacterNameText.text = "Gladiator";
        }
        else if (Viking.activeSelf == true)
        {
            Viking.SetActive(false);
            Cavalier.SetActive(true);
            CharacterNameText.text = "Cavalier";
        }
    }
}
