using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    #region Public Fields


    #endregion


    #region Private Fields
    [SerializeField] private Image healthBar, ammoBar;
    [SerializeField] private GameObject player;

    private Health playerHealthScript;
    private Shoot shootScript;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        playerHealthScript = player.GetComponent<Health>();
        shootScript = player.GetComponent<Shoot>();
    }

    void Update()
    {
        healthBar.fillAmount = playerHealthScript.currentHealth / playerHealthScript.maxHealth;

        ammoBar.fillAmount = shootScript.bulletAmount / shootScript.maxBulletAmount;
    }

    #endregion



    #region Public Methods


    #endregion


    #region Private Methods


    #endregion
}
