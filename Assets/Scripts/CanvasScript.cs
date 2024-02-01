using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    float maxHealth = 100;
    float currentHealth;
    public float width;
    public RectTransform healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>().health;
        // Calculate the percentage of current health from the max health
        float p1percentage = Mathf.Clamp01((float)currentHealth / maxHealth);
        // Set the width variable to be a float of the health percentage
        width = p1percentage * 200f;
        // set the health bar size to width variable's float number
        healthBar.sizeDelta = new Vector2(width, healthBar.sizeDelta.y);
    }
}
