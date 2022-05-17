using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region Public Fields
    public bool isAlive;
    public float currentHealth, maxHealth;
    #endregion


    #region Private Fields
    
    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        isAlive = true;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            isAlive = false;
        }


        if (!isAlive)
        {
            Die();
        }
    }

    #endregion



    #region Public Methods
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
    }

    #endregion


    #region Private Methods
    private void Die()
    {
        Destroy(gameObject,0.5f);
    }

    #endregion
}
