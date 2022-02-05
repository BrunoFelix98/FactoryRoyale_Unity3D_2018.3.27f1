
using UnityEngine;
using UnityEngine.Audio;

public class OnmouseOver : MonoBehaviour
{
    AudioSource audioData;

    public bool PlayedOnce;
    private void Start()
    {
        audioData = GetComponent<AudioSource>();
        PlayedOnce = true;
    }
    void OnMouseOver()
    {
   
        if (PlayedOnce)
        {
            audioData.Play();
            PlayedOnce = false;
        }
    }
    void OnMouseExit()
    {
        PlayedOnce = true;
    }
}
