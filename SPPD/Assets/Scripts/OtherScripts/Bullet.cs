using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Public Fields
    public bool isTargetAPlayer;
    public float damageAmount = 50;
    #endregion


    #region Private Fields
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 direction;
    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        
        
    }

    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime) ;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && !isTargetAPlayer)
        {
            // Deal damage
            DamageTheTarget(other);
        }
        else if (other.gameObject.CompareTag("Player") && isTargetAPlayer)
        {
            DamageTheTarget(other);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    #endregion



    #region Public Methods


    public void SetTargetDirection(Vector3 dir,bool isAPlayer)
    {
        isTargetAPlayer = isAPlayer;
        direction = dir;
    }
    #endregion


    #region Private Methods
    private void DamageTheTarget(Collider target)
    {
        target.gameObject.GetComponent<Health>().TakeDamage(damageAmount);
        gameObject.SetActive(false);
    }

    #endregion
}
