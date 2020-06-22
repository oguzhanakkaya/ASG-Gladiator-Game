using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialSkill : MonoBehaviour
{
    public Canvas SpecialSkillCanvas;
    public SingleGameRoom gameRoom;
 
    void Start()
    {
        //SpecialSkillCanvas= GameObject.Find("SpecialSkillCanvas").GetComponent<Canvas>();
        SpecialSkillCanvas.gameObject.SetActive(false);
    }

   
    void Update()
    {
        
    }
    public void SpecialSkillCanvasDisplay()
    {
        SpecialSkillCanvas.gameObject.SetActive(true);
    }
    public void SpecialSkillsCanvasClose()
    {
        SpecialSkillCanvas.gameObject.SetActive(false);
    }
}
