using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    #region Public Fields


    #endregion


    #region Private Fields
    [SerializeField] private Image healthBar, ammoBar;
    [SerializeField] private GameObject player,finishScreenGameObject;
    [SerializeField] private TextMeshProUGUI wavesCountText, countDownTimerText;

    private Health playerHealthScript;
    private Shoot shootScript;
    

    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        playerHealthScript = player.GetComponent<Health>();
        shootScript = player.GetComponent<Shoot>();
    }

    void Update()
    {
        UpdateHealth();
        UpdateBullet();
        CheckForWaves();
    }

    #endregion



    #region Public Methods

    public void WavesCount(int count)
    {

        if(count < 0)
        {
            wavesCountText.text = "";
        }
        else
        {
            wavesCountText.text = "Wave: " + count;
        }
            
        
        
    }

    public void WaveCountDown(float timer)
    {
        if(timer <= 0)
        {
            countDownTimerText.text = "";
        }
        else
        {
            countDownTimerText.text = "Next wave incoming in: " + timer.ToString("0");
        }
       
    }
    public void OnBackToMenuButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void OnNextLevelButtonClicked(int sceneIndex)
    {
        GameManager.Instance.playerHealth = playerHealthScript.currentHealth;
        GameManager.Instance.isLevelFinished = false;


        SceneManager.LoadScene(sceneIndex);

    }

    #endregion


    #region Private Methods

    private void CheckForWaves()
    {
        if(GameManager.Instance.isLevelFinished)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            finishScreenGameObject.SetActive(true);
        }
    }

    private void UpdateHealth()
    {
        healthBar.fillAmount = playerHealthScript.currentHealth / playerHealthScript.maxHealth;
    }

    private void UpdateBullet()
    {
        ammoBar.fillAmount = shootScript.bulletAmount / shootScript.maxBulletAmount;
    }

    #endregion
}
