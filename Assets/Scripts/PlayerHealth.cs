using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 20;
    public int currentHealth;
    public int statusEffect;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Damage(1);
            Debug.Log(currentHealth);
        }
    }
    public void Damage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Damage: " + currentHealth);
        healthBar.setHealth(currentHealth);
    }

    public void shockDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        Debug.Log("Shock damage: " + currentHealth);
        transform.Find("shockEffect").gameObject.SetActive(true);
        Invoke("Recover", 3f);
    }

    public void Recover()
    {
        healthBar.setHealth(currentHealth);
        Debug.Log("Recover: " + currentHealth);
        transform.Find("shockEffect").gameObject.SetActive(false);
    }

}
