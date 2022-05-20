using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    #region Public Fields


    #endregion


    #region Private Fields
    [SerializeField] private float mouseSensitivity = 5f;
    [SerializeField] private float xRotationClamp = 90f;
    [SerializeField] Transform playerBody;


    private float xRotation;
    #endregion

    #region MonoBehaviour Callbacks

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!GameManager.Instance.isLevelFinished)
        {
            LookAround();
        }
        


    }

    #endregion



    #region Public Methods


    #endregion


    #region Private Methods
    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xRotationClamp, xRotationClamp);

        //rotate the camera on the x axes so we can look up and down
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);



        // rotate the player body only
        playerBody.Rotate(Vector3.up * mouseX);
    }

    #endregion
}
