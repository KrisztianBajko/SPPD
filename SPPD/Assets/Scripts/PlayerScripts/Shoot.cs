using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    #region Public Fields


    #endregion


    #region Private Fields
    [SerializeField] private Transform firePointGameObject;


    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ObjectPooler.Instance.SpawnFromPool("Bullet", firePointGameObject.position, Quaternion.identity, false,Camera.main.transform.forward);
        }
    }

    #endregion



    #region Public Methods


    #endregion


    #region Private Methods


    #endregion
}
