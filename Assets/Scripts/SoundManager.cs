using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
  public static SoundManager i;


  AudioSource audio;

  public enum SoundType
  {
    hitsound,
    failsound
  }


  void Awake()
  {
    i = this;
    audio = GetComponent<AudioSource>();
  }
  public static void PlaySound(AudioClip[] audios)
  {
    if (audios.Length == 0)
    {
      Debug.LogError("la liste de son est vide !!!");
      return;
    }
    PlaySound(audios[Random.Range(0, audios.Length)]);
  }
  public static void PlaySound(AudioClip audio)
  {
    if (audio == null)
    {
      Debug.LogError("le son est vide !!!");
      return;
    }

    i.audio.PlayOneShot(audio);
  }



}
