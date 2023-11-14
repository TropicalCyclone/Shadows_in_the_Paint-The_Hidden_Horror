using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpscareAnimation : MonoBehaviour
{
    [SerializeField] private FadeScreen _fader;

    IEnumerator fadeOut()
    {
        _fader.Fade(0,1,0.2f);
        yield return new WaitForSeconds(0.2f);
    }
    void Death()
    {   
        SceneManager.LoadScene("GameScene");    
    }
}
