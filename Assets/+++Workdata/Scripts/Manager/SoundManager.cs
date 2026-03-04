using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
 public static SoundManager instance;

 [SerializeField] private AudioSource soundObject;
 
  [Header("UI Sounds")]
  [SerializeField] private AudioClip _buttonClick;
  

  private void Awake()
 {
     if (instance == null)
     {
      instance = this;
     }
 }

 public void PlaySound(AudioClip audioClip, Transform spawnTransform, float volume)
 {
  AudioSource audioSource =
   Instantiate(soundObject, spawnTransform.position, Quaternion.identity); //gameObject erstellen

  audioSource.clip = audioClip; //Sound festlegen

  audioSource.volume = volume; //Volume festlegen
  
  audioSource.Play(); //play

  float clipLength = audioSource.clip.length; //length der Audio
  
  Destroy(audioSource.gameObject, clipLength); //nach dem Abspielen destroy

 }

 public void PlayRandomSound(AudioClip[] audioClip, Transform spawnTransform, float volume)
 {
  int rand = Random.Range(0, audioClip.Length);
  
  AudioSource audioSource =
   Instantiate(soundObject, spawnTransform.position, Quaternion.identity); //gameObject erstellen

  audioSource.clip = audioClip[rand]; //Sound festlegen

  audioSource.volume = volume; //Volume festlegen
  
  audioSource.Play(); //play

  float clipLength = audioSource.clip.length; //length der Audio
  
  Destroy(audioSource.gameObject, clipLength); //nach dem Abspielen destroy

 }
 
 
 public void ButtonClick()
 {
  PlaySound(_buttonClick, transform, 1f);
 }

 /*
  [SerializeField] private AudioClip _name; //um den Sound einzufügen im Inspector
  SoundManager.instance.PlaySound(_name, transform, 1f); //um Sound zu spielen
  */

}

