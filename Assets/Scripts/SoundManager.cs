using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip bottomPanelTap;
    [SerializeField]
    private AudioClip answerTap;
    [SerializeField]
    private AudioClip confirmTap;
    [SerializeField]
    private AudioClip correct;
    [SerializeField]
    private AudioClip incorrect;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void PlayAudioContainer(string audioName)
    {
        switch (audioName)
        {
            case "BottomTap":
                source.PlayOneShot(bottomPanelTap);
                break;

            case "AnswerTap":
                source.PlayOneShot(answerTap);
                break;

            case "ConfirmTap":
                source.PlayOneShot(confirmTap);
                break;

            case "Correct":
                source.PlayOneShot(correct);
                break;

            case "Incorrect":
                source.PlayOneShot(incorrect);
                break;
        }
    }

    
}
