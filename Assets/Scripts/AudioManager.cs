using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource WalkingAudio;
    [SerializeField] private AudioSource GrabbingAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void grabSoundPlay()
    {
        StartCoroutine(grabObject());
    }

    public IEnumerator grabObject()
    {
        GrabbingAudio.Play();
        yield return new WaitForSeconds(1f);
        GrabbingAudio.Stop();
    }

    public void StartWalking()
    {
        WalkingAudio.Play();
    }  
    public void EndWalking()
    {
        WalkingAudio.Stop();
    }

}
