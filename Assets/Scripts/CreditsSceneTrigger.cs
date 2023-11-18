using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsSceneTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundAudioSource;
    [SerializeField] private AudioSource _creditsAudioSource;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private Animator Credits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartCreditsAudio()
    {
        _creditsAudioSource.Play();
        yield return new WaitForSeconds(3);
        _backgroundAudioSource.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Credits.Play("Credits");
            StartCoroutine(StartCreditsAudio());
        }
    }
}
