using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;

    public static GameManager Instance
    {
        get 
        { if(instance == null)
            {
                Debug.LogError("GameManager is NULL");
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion


    #region Public Fields
    public float playerHealth;
    public bool isLevelFinished;
    #endregion


    #region Private Fields

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {

    }

    void Update()
    {
        

    }

    #endregion



    #region Public Methods
    

    #endregion


    #region Private Methods


    #endregion
}
