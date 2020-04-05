using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class SingleGameAgilitySelection : MonoBehaviour
{

    public int CharacterNumber;
    public readonly string SelectedCharacter = "Selected Character";
    public GameObject Character,Cavalier,Gladiator,Vikings;
    public bool Control=true;
   
    void Start()
    {
        CharacterNumber = PlayerPrefs.GetInt(SelectedCharacter);
        

        /* Gladiator = Resources.Load("Prefabs/Knight11") as GameObject;
         Vikings = Resources.Load("Prefabs/Knight2") as GameObject;
         Cavalier = Resources.Load("Prefabs/Knight3") as GameObject;*/

    }

   
    void Update()
    {
        if(Control)
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
}
