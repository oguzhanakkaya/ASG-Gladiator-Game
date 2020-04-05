using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class SingleGameAgilitySelection : MonoBehaviour
{
    SingleCharacterSelection Character;
    public int CharacterNumber;
    public Text text;
    void Start()
    {
        CharacterNumber = Character.chr;
        text.text = CharacterNumber.ToString();
    }

   
    void Update()
    {
      
    }
}
