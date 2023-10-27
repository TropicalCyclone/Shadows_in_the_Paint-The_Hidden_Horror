using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
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
        
    }

    public void SetText(string input)
    {
        _text.text = input;
    }

    public void SetUIVisual(bool value)
    {
        if (value)
        {
            _uiGroup.SetActive(true);
        }
        else
        {
            _uiGroup.SetActive(false);
        }
    }
}
