using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    
    public AudioClip buttonMenu;
    public AudioClip gameOver;
    public AudioClip messageSound;
    public AudioClip guillotine;
    public AudioClip jump;
    public AudioClip puzzleOk;
    public AudioClip rock;
    public AudioClip death;

    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        audioSource = this.GetComponent<AudioSource>();
	}

    public void PlayButtonMenu() {

        audioSource.clip = buttonMenu;
        audioSource.Play();
    }

    public void PlayGameOver()
    {
        audioSource.clip =gameOver;
        audioSource.Play();
    }

    public void PlayMessageSound()
    {
        audioSource.clip =messageSound;
        audioSource.Play();
    }

    public void PlayGuillotine()
    {
        audioSource.clip =guillotine;
        audioSource.Play();
    }

    public void PlayJump()
    {
        audioSource.clip =jump;
        audioSource.Play();
    }

    public void PlayPuzzleOK()
    {
        audioSource.clip =puzzleOk;
        audioSource.Play();
    }

    public void PlayRock()
    {
        audioSource.clip =rock;
        audioSource.Play();
    }

    public void PlayDeath()
    {
        audioSource.clip =death;
        audioSource.Play();
    }
}
