using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioTap;
    public AudioSource audioPlay;

    void Update()
    {
      AudioTap();
    }

    public void AudioTap(){
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)){audioTap.Play();}
	}

    public void AudioPlay(){
	    audioPlay.Play();
	}
}
