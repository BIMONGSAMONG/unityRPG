﻿using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; set; }
    
    public Stat damage;
    public Stat armor;

    public event System.Action<int, int> OnHealthChanged;

    public GameObject damageText;
    public Transform textPos;

    Transform cam;
    Quaternion rotation;

    void Awake()
    {
        currentHealth = maxHealth;
        cam = Camera.main.transform;
    }

    void Update()
    {
        
    }

    public void TakeDamage (int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        GameObject text = Instantiate(damageText);
        text.transform.position = textPos.position;

        Vector3 relativePos = textPos.position - cam.position;
        rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        text.transform.rotation = rotation;

        text.GetComponent<DamageText>().damage = damage;

        Debug.Log(transform.name + " take " + damage + " damage.");

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died.");
    }
}