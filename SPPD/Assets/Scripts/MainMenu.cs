using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
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
