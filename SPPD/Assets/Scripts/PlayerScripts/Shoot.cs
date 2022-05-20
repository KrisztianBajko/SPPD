using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    #region Public Fields
    public float bulletAmount;
    public float maxBulletAmount;

    #endregion


    #region Private Fields
    [SerializeField] private float timeToNextAttack;
    [SerializeField] private float fireRate;
    [SerializeField] private Transform firePointGameObject;


    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {

    }

    void Update()
    {
        if (!GameManager.Instance.isLevelFinished)
        {
            Shooting();
        }
       
    }

    #endregion



    #region Public Methods


    #endregion


    #region Private Methods
    private void Shooting()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > timeToNextAttack && bulletAmount > 0)
        {
            bulletAmount--;
            timeToNextAttack = Time.time + fireRate;

            ObjectPooler.Instance.SpawnFromPool("Bullet", firePointGameObject.position, Quaternion.identity, false, Camera.main.transform.forward);

        }
    }

    #endregion
}
