using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_HealthBar : MonoBehaviour
{
    public Image PlayerEnergyBar,PlayerHealthBar;
    public Single_Game single;
    public float fill,player_energy,player_health;
    void Start()
    {
        PlayerEnergyBar.fillAmount = single.player_energy / 100;
        PlayerHealthBar.fillAmount = single.player_energy / 100;
    }

    
    void Update()
    {
        SetPlayerEnergy();
        SetPlayerHealth();


    }
    public void SetPlayerEnergy()
    {
        float player_energy = (float)single.player_energy;
        fill = player_energy / 100;
        PlayerEnergyBar.fillAmount = fill;
    }
    public void SetPlayerHealth()
    {
        float player_health = (float)single.player_health;
        fill = player_health / 100;
        PlayerHealthBar.fillAmount = fill;
    }

}
