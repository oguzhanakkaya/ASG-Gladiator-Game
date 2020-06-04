using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ComputerAI : MonoBehaviour
{

    struct Actions
    {
        public string ActionName;
        public float ActionPoint;
        public float Miss;
        public float AttackPower;
        public float SpendEnergy;
    };
    Actions WalkLeft, WalkRight, QuickAttack, NormalAttack, HardAttack, Sleep;

    public ComputerMovement ComputerMovement;
    public PlayerMovement PlayerMovement;
    public SingleGameRoom gameRoom;

    public float[] ActionsArray = new float[5];







    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GetMoves()
    {
        SetActionsVariables();
        ComputerMovement.ComputerActionCheck();
    }
    public void CalculateMovesPoint()
    {
        if (ComputerMovement.ComputerWalkLeftBool == true)
        {
           WalkLeft.ActionPoint = (PlayerMovement.ComputerHealth/PlayerMovement.PlayerHealth) 
                + (WalkLeft.Miss + WalkLeft.AttackPower + (PlayerMovement.ComputerEnergy/PlayerMovement.PlayerEnergy));
            ActionsArray[0] = WalkLeft.ActionPoint;
        }
        else
        {
            ActionsArray[0] = -100;
        }

        if (ComputerMovement.ComputerWalkRightBool == true)
        {
            WalkRight.ActionPoint = (PlayerMovement.ComputerHealth / PlayerMovement.PlayerHealth)
                 + (WalkRight.Miss + WalkRight.AttackPower + (PlayerMovement.ComputerEnergy / PlayerMovement.PlayerEnergy));
            ActionsArray[1] = WalkRight.ActionPoint;
        }
        else
        {
            ActionsArray[1] = -100;
        }

        if (ComputerMovement.ComputerAttackBool == true)
        {
            QuickAttack.ActionPoint = (PlayerMovement.ComputerHealth / PlayerMovement.PlayerHealth)
                + (QuickAttack.Miss / QuickAttack.AttackPower + (PlayerMovement.ComputerEnergy / PlayerMovement.PlayerEnergy));
            ActionsArray[2] = QuickAttack.ActionPoint;

           NormalAttack.ActionPoint = (PlayerMovement.ComputerHealth / PlayerMovement.PlayerHealth)
                + (NormalAttack.Miss / NormalAttack.AttackPower + (PlayerMovement.ComputerEnergy / PlayerMovement.PlayerEnergy));
            ActionsArray[3] = NormalAttack.ActionPoint;

           HardAttack.ActionPoint = (PlayerMovement.ComputerHealth / PlayerMovement.PlayerHealth)
                + (HardAttack.Miss / HardAttack.AttackPower + (PlayerMovement.ComputerEnergy / PlayerMovement.PlayerEnergy));
            ActionsArray[4] = HardAttack.ActionPoint;
        }
        else
        {
            ActionsArray[2] = -100;
            ActionsArray[3] = -100;
            ActionsArray[4] = -100;
        }

    }
    public void SelectNextMove()
    {
        if(PlayerMovement.ComputerEnergy<=25)
        {
            ComputerMovement.Sleep();
        }
        else if ((PlayerMovement.computer.transform.position.x - gameRoom.player.transform.position.x) > 5.0f)
        {
            ComputerMovement.WalkLeft();
        }
        else if ((PlayerMovement.computer.transform.position.x - gameRoom.player.transform.position.x) < -5.0f)
        {
            ComputerMovement.WalkRight();
        }
        else
        {
            float maxValue = ActionsArray.Max();
            int maxIndex = ActionsArray.ToList().IndexOf(maxValue);
            Debug.Log(maxIndex);

            switch (maxIndex)
            {
                case 0:
                    ComputerMovement.WalkLeft();
                    break;

                case 1:
                    ComputerMovement.WalkRight();
                    break;

                case 2:
                    ComputerMovement.QuickAttack();
                    break;

                case 3:
                    ComputerMovement.NormalAttack();
                    break;

                case 4:
                    ComputerMovement.HardAttack();
                    break;

                default:
                    break;
            }
        }
    }
    public void SetActionsVariables()
    {
        WalkLeft.ActionName = "WalkLeft";
        WalkLeft.AttackPower = 0.1f;
        WalkLeft.Miss = 0.1f;
        WalkLeft.SpendEnergy =5f;


        WalkRight.ActionName = "WalkRight";
        WalkRight.AttackPower = 0.1f;
        WalkRight.Miss = 0.1f;
        WalkRight.SpendEnergy = 5f;

        QuickAttack.ActionName = "QuickAttack";
        QuickAttack.AttackPower = 2.5f;
        QuickAttack.Miss = 0.05f;
        QuickAttack.SpendEnergy = 5f;


        NormalAttack.ActionName = "NormalAttack";
        NormalAttack.AttackPower = 7.5f;
        NormalAttack.Miss = 0.2f;
        NormalAttack.SpendEnergy = 5f;


        HardAttack.ActionName = "HardAttack";
        HardAttack.AttackPower = 12.5f;
        HardAttack.Miss = 0.55f;
        HardAttack.SpendEnergy = 5f;


        Sleep.ActionName = "Sleep";


    }


}
