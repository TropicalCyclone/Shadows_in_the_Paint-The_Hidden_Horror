using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MainMenuAnimation : MonoBehaviour
{
    [SerializeField] private Animator CameraAnimator;
    [SerializeField] private Animator MainMenuAnimator;
    [SerializeField] private CanvasGroup MainMenu;
    [SerializeField] private PlayableDirector StartAnim;
    [SerializeField] private Animator OldManAnimator;
    [SerializeField] private CanvasGroup CreditsMenu;
    [SerializeField] private float Duration = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CreditsButton()
    {
        OldManAnimator.SetBool("IsSettings",true);
        CameraAnimator.SetBool("IsSettings", true);
        MainMenuAnimator.SetBool("IsSettings", true);
    }

    public void ResetSaves()
    {
        PlayerPrefs.DeleteAll();
    }

    public void BackButtton()
    {
        OldManAnimator.SetBool("IsSettings",false);
        CameraAnimator.SetBool("IsSettings", false);
        MainMenuAnimator.SetBool("IsSettings", false);
    }

    public void StartButton()
    {
        StartAnim.Play();
    }
    public void CreditsAppear()
    {
        StartCoroutine(Fade(CreditsMenu, 0, 1));
    }
    public void CreditsDisppear()
    {
        StartCoroutine(Fade(CreditsMenu, 1, 0));
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Fade(CanvasGroup canvas,float start, float end)
    {
        float counter = 0f;

        while(counter < Duration)
        {
            counter += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(start, end, counter/Duration);
            yield return null;  
        }
    }
}
