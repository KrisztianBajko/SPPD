using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPod : MonoBehaviour
{
    #region Public Fields


    #endregion


    #region Private Fields
    [SerializeField] private float healAmount;
    [SerializeField] private float timeToNextHeal;
    [SerializeField] private GameObject healingPodIndicator;
    [SerializeField] private Collider collider;
    private float countDownTimer;

    private bool canHeal = true;
    private bool isHealing = false;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {

    }

    void Update()
    {
        if (!canHeal)
        {
            healingPodIndicator.SetActive(false);
            collider.enabled = false;

            countDownTimer -= Time.deltaTime;

            if(countDownTimer <= 0)
            {
                countDownTimer = timeToNextHeal;
                canHeal = true;
            }
        }
        else
        {
            healingPodIndicator.SetActive(true);
            collider.enabled = true;


        }

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            // we want to heal the player only if the players current health is less then the max health
            if(other.gameObject.GetComponent<Health>().currentHealth < other.gameObject.GetComponent<Health>().maxHealth)
            {
                other.gameObject.GetComponent<Health>().currentHealth += healAmount * Time.deltaTime;
            }
            else
            {
                canHeal = false;
            }
            
        }
    
    
    }


        #endregion



        #region Public Methods


        #endregion


        #region Private Methods


        #endregion
    }
