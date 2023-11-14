using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private GameObject _uiGroup;
    [SerializeField] private TMP_Text _text;

    private bool _uiSwitch;
    // Start is called before the first frame update
    void OnEnable()
    {
        SetGrabVisual(false);
        SetPauseVisual(false);
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.JoystickButton10) || Input.GetKeyDown(KeyCode.Escape))
        {
            _uiSwitch = !_uiSwitch;
            if (_uiSwitch)
            {
                SetPauseVisual(true);
            }
            else
            {
                SetPauseVisual(false);
            }
            
        }
    }

    public void SetText(string input)
    {
        _text.text = input;
    }

    public void SetGrabVisual(bool value)
    {    
         _uiGroup.SetActive(value); 
    }

    public void SetPauseVisual(bool value)      
    {
        if (value)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        Cursor.visible = value;
        _pauseMenuUI.SetActive(value);
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name,LoadSceneMode.Single);
        
    }

    public void ExitButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");  
    }

}
