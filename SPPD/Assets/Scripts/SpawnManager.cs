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
    [SerializeField] private int wavesLeftToNextLevel;
    [SerializeField] private bool isLevelOneActive;
    [SerializeField] private GameObject[] enemyPrefab;
   
    private GameObject spawnedEnemy;
    private bool isWaveOne;
    private bool isEnemiesAlive = false;
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private UIManager uiManagerScript;
    
    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        GameManager.Instance.isLevelFinished = false;

        uiManagerScript = GameObject.Find("UIManager").GetComponent<UIManager>();
        uiManagerScript.WavesCount(wavesLeftToNextLevel);
    }

    void Update()
    {
        if (!GameManager.Instance.isLevelFinished)
        {
            CheckIfEnemiesAlive();
            CountDown();
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


                // as i have only 2 level now i just simple check the bool variable if im in level 2 otherwise i leave it false
              
                if (isLevelOneActive)
                {
                    spawnedEnemy = Instantiate(enemyPrefab[0], location, Quaternion.identity);
                }
                else
                {
                    if (isWaveOne)
                    {
                        spawnedEnemy = Instantiate(enemyPrefab[0], location, Quaternion.identity);
                    }
                    else
                    {
                        spawnedEnemy = Instantiate(enemyPrefab[1], location, Quaternion.identity);
                    }
                }
               
                
                

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
    private void CheckIfEnemiesAlive()
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
    }
   
    private void CountDown()
    {
        if (!isEnemiesAlive)
        {
            if (timeForNextwave <= 0)
            {
                timeForNextwave = timeBetweenWaves;
             
                
                wavesLeftToNextLevel--;
                
                 
                uiManagerScript.WavesCount(wavesLeftToNextLevel);
                if(wavesLeftToNextLevel == -1)
                {
                    GameManager.Instance.isLevelFinished = true;
                    
                }
                else
                {
                    isEnemiesAlive = true;
                    isWaveOne = !isWaveOne;
                    StartCoroutine(SpawnEnemy());
                }
               
            }
            else
            {
                timeForNextwave -= Time.deltaTime;
                uiManagerScript.WaveCountDown(timeForNextwave);
            }
        }
    }


    #endregion
}
