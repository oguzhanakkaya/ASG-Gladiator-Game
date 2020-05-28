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
        PlayerEnergyBar.fillAmount = playerMovement.PlayerEnergy / 100;
        PlayerHealthBar.fillAmount = playerMovement.PlayerHealth / 100;
        ComputerEnergyBar.fillAmount = playerMovement.ComputerEnergy / 100;
        ComputerHealthBar.fillAmount = playerMovement.ComputerHealth / 100;
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
        float player_energy = (float)playerMovement.PlayerEnergy;
        fill = player_energy / 100;
        PlayerEnergyBar.fillAmount = fill;
    }
    public void SetPlayerHealth()
    {
        float player_health = (float)playerMovement.PlayerHealth;
        fill = player_health / 100;
        PlayerHealthBar.fillAmount = fill;
    }
    public void SetComputerEnergy()
    {
        float computer_energy = (float)playerMovement.ComputerEnergy;
        fill = computer_energy / 100;
        ComputerEnergyBar.fillAmount = fill;
    }
    public void SetComputerHealth()
    {
        float computer_health = (float)playerMovement.ComputerHealth;
        fill = computer_health / 100;
        ComputerHealthBar.fillAmount = fill;
    }

}
