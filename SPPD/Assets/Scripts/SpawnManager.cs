using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Public Fields


    #endregion

    #region Singleton

    public static SpawnManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    #region Private Fields

    [SerializeField] private float timeForNextwave;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float spawnRate;
    [SerializeField] private int enemySpawnCount;
    [SerializeField] private GameObject enemyPrefab;


    private bool isEnemiesAlive = false;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    
    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        
    }

    void Update()
    {
        if (spawnedEnemies.Count != 0)
        {
            for (int i = 0; i < spawnedEnemies.Count; i++)
            {
                if (!spawnedEnemies[i].GetComponent<Health>().isAlive)
                {
                    spawnedEnemies.Remove(spawnedEnemies[i]);
                }
            }
        }
        else
        {
            isEnemiesAlive = false;
        }


        if (!isEnemiesAlive)
        {
            if (timeForNextwave <= 0)
            {
                timeForNextwave = timeBetweenWaves;
               
                isEnemiesAlive = true;
               
                    StartCoroutine(SpawnEnemy());
                
            }
            else
            {
                timeForNextwave -= Time.deltaTime;
            }
        }

     
    }

    IEnumerator SpawnEnemy()
    {
        for(int i = 0; i< enemySpawnCount; i++)
        {

            RaycastHit hit;
            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
                float randomPosx = Random.Range(-10, 10);
                float randomPosz = Random.Range(-15, 15);
                Vector3 location = new Vector3(hit.point.x + randomPosx, hit.point.y + .5f, hit.point.z + randomPosz);

                GameObject spawnedEnemy = Instantiate(enemyPrefab, location , Quaternion.identity);

                spawnedEnemies.Add(spawnedEnemy);

                yield return new WaitForSeconds(1f / spawnRate);



            }
            

            
        }
        yield break;
    }


    

    #endregion



    #region Public Methods


    #endregion


    #region Private Methods
    


    #endregion
}
