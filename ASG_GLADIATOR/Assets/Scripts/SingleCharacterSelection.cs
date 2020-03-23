using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SingleCharacterSelection : MonoBehaviour
{

    public Button NextButton;
    public GameObject Gladiator, Cavalier, Viking;
    

    void Start()
    {
        NextButton = GameObject.Find("NextCharacter").GetComponent<Button>();
       
        //Gladiator = GameObject.Find("GameObject");
        /*Cavalier = GameObject.Find("Cavalier");
        Viking = GameObject.Find("Viking");*/

        Gladiator.SetActive(true);

        NextButton.onClick.AddListener(NextCharacter);
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
        }
        else if(Cavalier.activeSelf== true)    
        {
            Cavalier.SetActive(false);
            Viking.SetActive(true);
        }
        else if (Viking.activeSelf == true)
        {
            Viking.SetActive(false);
            Gladiator.SetActive(true);
        }

    }
}
