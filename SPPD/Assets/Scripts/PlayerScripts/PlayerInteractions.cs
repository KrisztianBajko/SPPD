using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    #region Public Fields


    #endregion


    #region Private Fields
    [SerializeField] private float healAmount;
    [SerializeField] private float ammoAmount;

    private Shoot shootScript;
    private Health healthScript;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        shootScript = GetComponent<Shoot>();
        healthScript = GetComponent<Health>();
    }

    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            if(other.gameObject.name.Contains("BulletPickUp"))
            {
                if(shootScript.bulletAmount < shootScript.maxBulletAmount)
                {
                    shootScript.bulletAmount += ammoAmount;

                    if(shootScript.bulletAmount > shootScript.maxBulletAmount)
                    {
                        shootScript.bulletAmount = shootScript.maxBulletAmount;
                    }

                    other.gameObject.SetActive(false);
                }
                
            }
            else if(other.gameObject.name.Contains("HealPickUp"))
            {
                if(healthScript.currentHealth < healthScript.maxHealth)
                {
                    
                    healthScript.currentHealth += healAmount;

                    if(healthScript.currentHealth > healthScript.maxHealth)
                    {
                        healthScript.currentHealth = healthScript.maxHealth;
                    }
                    other.gameObject.SetActive(false);
                }

            }
            
        }
    }
    #endregion



    #region Public Methods


    #endregion


    #region Private Methods


    #endregion
}
