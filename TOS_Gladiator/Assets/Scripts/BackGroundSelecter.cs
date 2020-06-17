using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BackGroundSelecter : MonoBehaviour
{
    public GameObject BackGround;
    public SpriteRenderer BackGroundSprite;
    public Sprite Image1, Image2, Image3;
    public int BackgroundNumber;
    void Start()
    {
        BackGround = GameObject.Find("BackgroundImage");
        BackGroundSprite = BackGround.GetComponent<SpriteRenderer>();
        SelectBackGround();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectBackGround ()
    {
        BackgroundNumber = Random.Range(1, 4);
        switch (BackgroundNumber)
        {
            case 1:
                BackGroundSprite.sprite = Image1;
                break;

            case 2:
                BackGroundSprite.sprite = Image2;
                break;

            case 3:
                BackGroundSprite.sprite = Image3;
                break;

      
            default:
                break;
        }
    }
}
