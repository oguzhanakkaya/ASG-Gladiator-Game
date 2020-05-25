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
    public int CharacterSelect;
    public readonly string SelectedCharacter = "Selected Character";

    

    void Start()
    {
        NextButton = GameObject.Find("NextCharacter").GetComponent<Button>();
        PreviousButton = GameObject.Find("PreviousCharacter").GetComponent<Button>();
        CharacterNameText= GameObject.Find("CharacterNameText").GetComponent<Text>();

        CharacterSelect = 1;
        
        NextButton.onClick.AddListener(NextCharacter);
        PreviousButton.onClick.AddListener(PreviousCharacter);
    } 
    void Update()
    {
          
    }
    public void NextCharacter()
    {
        
        switch (CharacterSelect)
        {
            case 1: // case 1 = cavalier
                PlayerPrefs.SetInt(SelectedCharacter, 1);              
                Destroy(Gladiator);
                SpawnCavalier();
                CharacterSelect++;
                break;

            case 2: // case 2 = Viking
                PlayerPrefs.SetInt(SelectedCharacter, 2);
                Destroy(Cavalier);
                SpawnViking();
                CharacterSelect++;
                break;

            case 3: // case 3 = gladiator
                PlayerPrefs.SetInt(SelectedCharacter, 3);
                Destroy(Viking);
                CharacterSelect=1;
                SpawnGladiator();
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
                Destroy(Gladiator);
                PlayerPrefs.SetInt(SelectedCharacter, 2);
                SpawnViking();               
                CharacterSelect=3;
                break;

            case 2:
                Destroy(Cavalier);
                PlayerPrefs.SetInt(SelectedCharacter, 3);
                SpawnGladiator();              
                CharacterSelect--;
                break;

            case 3:
                Destroy(Viking);
                PlayerPrefs.SetInt(SelectedCharacter, 1);
                SpawnCavalier();
                CharacterSelect--;
                break;

            default:
                break;
        }
    }
    public void SpawnGladiator()
    {
        Gladiator = Instantiate(Resources.Load("Knight1", typeof(GameObject))) as GameObject;
        Gladiator.transform.position = new Vector3(0f, -0.7f, -1);
        Gladiator.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        CharacterNameText.text = "Gladiator";
    }
    public void SpawnViking()
    {
        Viking = Instantiate(Resources.Load("Knight2", typeof(GameObject))) as GameObject;
        Viking.transform.position = new Vector3(0, -0.8f, -1);
        Viking.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        CharacterNameText.text = "Viking";
    }
    public void SpawnCavalier()
    {
        Cavalier = Instantiate(Resources.Load("Knight3", typeof(GameObject))) as GameObject;
        Cavalier.transform.position = new Vector3(0f, -0.75f, -1);
        Cavalier.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        CharacterNameText.text = "Cavalier";
    }
}
