using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private GameObject _uiGroup;
    [SerializeField] private TMP_Text _text; 
    // Start is called before the first frame update
    void OnEnable()
    {
        _uiGroup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetButtonDown("Jump"))
        {
            _pauseMenuUI.SetActive(true);
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
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        Cursor.visible = value;
        _pauseMenuUI.SetActive(value);
    }
}
