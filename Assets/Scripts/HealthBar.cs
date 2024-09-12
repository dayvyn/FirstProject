using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] PlayerController player;
    Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponentInChildren<Slider>();
        player.Hurt += DecreaseHealth;
    }

    void DecreaseHealth()
    {
        healthBar.value -= .1f;
    }
}
