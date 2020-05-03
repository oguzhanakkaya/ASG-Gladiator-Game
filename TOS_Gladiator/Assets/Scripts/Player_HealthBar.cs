using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HealthBar : MonoBehaviour
{
    public Image PlayerEnergyBar,PlayerHealthBar;
    public PlayerMovement playerMovement;
    public float fill,player_energy,player_health;
    void Start()
    {
        PlayerEnergyBar.fillAmount = playerMovement.player_energy / 100;
        PlayerHealthBar.fillAmount = playerMovement.player_energy / 100;
    }

    
    void Update()
    {
        SetPlayerEnergy();
        SetPlayerHealth();
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

}
