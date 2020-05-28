using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HealthBar : MonoBehaviour
{
    public Image PlayerEnergyBar,PlayerHealthBar, ComputerEnergyBar, ComputerHealthBar;
    public PlayerMovement playerMovement;
    public float fill,player_energy,player_health;
    void Start()
    {
        PlayerEnergyBar.fillAmount = playerMovement.player_energy / 100;
        PlayerHealthBar.fillAmount = playerMovement.player_energy / 100;
        ComputerEnergyBar.fillAmount = playerMovement.computer_energy / 100;
        ComputerHealthBar.fillAmount = playerMovement.computer_energy / 100;
    }

    
    void Update()
    {
        SetPlayerEnergy();
        SetPlayerHealth();
        SetComputerEnergy();
        SetComputerHealth();
    }
    public void SetPlayerEnergy()
    {
        float player_energy = (float)playerMovement.player_energy;
        fill = player_energy / 100;
        PlayerEnergyBar.fillAmount = fill;
    }
    public void SetPlayerHealth()
    {
        float player_health = (float)playerMovement.player_health;
        fill = player_health / 100;
        PlayerHealthBar.fillAmount = fill;
    }
    public void SetComputerEnergy()
    {
        float computer_energy = (float)playerMovement.computer_energy;
        fill = computer_energy / 100;
        ComputerEnergyBar.fillAmount = fill;
    }
    public void SetComputerHealth()
    {
        float computer_health = (float)playerMovement.computer_health;
        fill = computer_health / 100;
        ComputerHealthBar.fillAmount = fill;
    }

}
