using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_G1_Ctrl : MonoBehaviour
{
    public AudioSource audioTap;
	public AudioSource audioColorchange;
	public AudioSource audioHightScore;

    public void AudioTap(){
		audioTap.Play();
	}
	public void AudioColorChange(){
		audioColorchange.Play();
	}
	public void AudioHightScore(){
		audioHightScore.Play();
	}
}
