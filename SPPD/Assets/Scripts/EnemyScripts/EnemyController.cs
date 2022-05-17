using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    #region Public Fields


    #endregion


    #region Private Fields
    [SerializeField] private float attackRange;
    [SerializeField] private Transform firePointGameObject;
    [SerializeField] private float timeToNextAttack = 2f;
    [SerializeField] private float fireRate = 5f;
    [SerializeField] private float viewAngle;
    [SerializeField] private LayerMask targetLayer;
    private bool isAttacking;
    public bool isPlayerVisible;

    private Transform player;
    private NavMeshAgent agent;
    private Animator anim;
    
    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }
    
    void Update()
    {
        if(player != null)
        {
            CheckIfPlayerIsVisible();
            CheckIfCanAttack();
        }
        
    }

    #endregion



    #region Public Methods


    #endregion


    #region Private Methods

    private void CheckIfPlayerIsVisible()
    {
        Vector3 targetDirection = (player.position - transform.position).normalized;

        if(Vector3.Angle(transform.forward, targetDirection) < viewAngle)
        {
            float distanceToTarget = Vector3.Distance(transform.position, player.position);

            if(!Physics.Raycast(transform.position, targetDirection, distanceToTarget, targetLayer))
            {
                isPlayerVisible = true;
            }
            else
            {
                isPlayerVisible = false;
            }
        }
        
    }



    private void CheckIfCanAttack()
    {
        if (Vector3.Distance(transform.position, player.position) > attackRange)
        {

            isAttacking = false;
        }
        else
        {
            isAttacking = true;
        }


        if (isAttacking && isPlayerVisible)
        {
            AttackThePlayer();
        }
        else
        {
            FollowThePlayer();
        }
    }

    private void FollowThePlayer()
    {
        anim.SetBool("IsFiring", false);
        anim.SetBool("IsRunning", true);
        agent.stoppingDistance = 2f;
        agent.SetDestination(player.position);
    }
    private void AttackThePlayer()
    {
        anim.SetBool("IsFiring", true);
        anim.SetBool("IsRunning", false);
        agent.stoppingDistance = attackRange -1;
        transform.LookAt(player.transform);

        if (Time.time > timeToNextAttack)
        {
            timeToNextAttack = Time.time + fireRate;

            ObjectPooler.Instance.SpawnFromPool("Bullet", firePointGameObject.position, Quaternion.identity,true,firePointGameObject.transform.forward);
        }
    }

    #endregion
}
