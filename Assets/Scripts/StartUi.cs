using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartUi : MonoBehaviour
{

  [SerializeField] TextMeshProUGUI startCountdown;
  Sequence sequence;
  [SerializeField] AudioClip startSound;
  AudioSource audio;
  void Start()
  {
    audio = GetComponent<AudioSource>();
    StartCoroutine(nameof(StartCountdown));
  }


  public IEnumerator StartCountdown()
  {
    audio.DOPitch(2, 6);
    for (int i = 5; i > 0; i--)
    {
      audio.Play();

      Animation();
      startCountdown.text = i.ToString();
      yield return new WaitForSeconds(1f);
    }
    audio.Play();
    Animation();
    startCountdown.text = "Tirez!";
    yield return new WaitForSeconds(1f);
    gameObject.SetActive(false);


    GameManager.StartGame();
  }
  public void Animation()
  {
    sequence
          .Append(transform.DOScale(Vector3.zero, 0.1f).From())
          .Append(transform.DOScale(Vector3.one, 1).SetEase(Ease.OutBack));

  }
}
