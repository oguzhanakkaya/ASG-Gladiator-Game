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
    public int CharacterSelect=1,chr;

    

    void Start()
    {
        NextButton = GameObject.Find("NextCharacter").GetComponent<Button>();
        PreviousButton = GameObject.Find("PreviousCharacter").GetComponent<Button>();
        CharacterNameText= GameObject.Find("CharacterNameText").GetComponent<Text>();

        Gladiator = GameObject.Find("Gladiator");
        Cavalier = GameObject.Find("Cavalier");
        Viking = GameObject.Find("Viking");

        Gladiator.SetActive(true);
        Cavalier.SetActive(false);
        Viking.SetActive(false);

        CharacterNameText.text = "Gladiator";

        NextButton.onClick.AddListener(NextCharacter);
        PreviousButton.onClick.AddListener(PreviousCharacter);

    }

  
    void Update()
    {
        chr = CharacterSelect;
    }
    public void NextCharacter()
    {
        switch(CharacterSelect)
        {
            case 1: // case 1 = cavalier
                Gladiator.SetActive(false);
                Cavalier.SetActive(true);
                CharacterNameText.text = "Cavalier";
                CharacterSelect++;
                break;

            case 2: // case 2 = Viking
                Cavalier.SetActive(false);
                Viking.SetActive(true);
                CharacterNameText.text = "Viking";
                CharacterSelect++;
                break;

            case 3: // case 3 = gladiator
                Viking.SetActive(false);
                Gladiator.SetActive(true);
                CharacterNameText.text = "Gladiator";
                CharacterSelect=1;
                break;

            default:
                break;
        }
    }
    public void PreviousCharacter()
    {
        switch (CharacterSelect)
        {
            case 1:
                Gladiator.SetActive(false);
                Viking.SetActive(true);
                CharacterNameText.text = "Viking";
                CharacterSelect=3;
                break;

            case 2:
                Cavalier.SetActive(false);
                Gladiator.SetActive(true);
                CharacterNameText.text = "Gladiator";
                CharacterSelect--;
                break;

            case 3:
                Viking.SetActive(false);
                Cavalier.SetActive(true);
                CharacterNameText.text = "Cavalier";
                CharacterSelect--;
                break;

            default:
                break;
        }
    }
}
