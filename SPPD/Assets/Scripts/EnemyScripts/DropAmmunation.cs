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

        Vector3 dropPosition = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);

        if(Random.value > dropChance)
        {
            ObjectPooler.Instance.SpawnPickUpFromPool("Ammo", dropPosition, Quaternion.identity);
        }
    }
    #endregion



    #region Public Methods


    #endregion


    #region Private Methods


    #endregion
}
