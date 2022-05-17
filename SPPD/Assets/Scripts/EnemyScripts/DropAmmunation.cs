using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAmmunation : MonoBehaviour
{
    #region Public Fields


    #endregion


    #region Private Fields
    [SerializeField] private float dropChance;

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {

    }

    void Update()
    {

    }


    private void OnDisable()
    {
        if(Random.value > dropChance)
        {
            ObjectPooler.Instance.SpawnPickUpFromPool("Ammo", transform.position, Quaternion.identity);
        }
    }
    #endregion



    #region Public Methods


    #endregion


    #region Private Methods


    #endregion
}
