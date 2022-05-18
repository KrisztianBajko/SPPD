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
       

    }
        #endregion


    #region Public Fields


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
    public void OnStartGameButtonClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitGameButtonClicked()
    {
        Application.Quit();
    }

    #endregion


    #region Private Methods


    #endregion
}
