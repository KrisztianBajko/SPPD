using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region Public Fields
    public bool isAlive;

    #endregion


    #region Private Fields
    [SerializeField] private float currentHealth;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        isAlive = true;
        currentHealth = 100;
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
