using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UiManager : MonoBehaviour
{
  [SerializeField] List<TextController> textControllers;
  [SerializeField] List<Rigidbody> healthBar;
  [SerializeField] AudioClip healthDamage;

  public static UiManager instance;
  void Awake()
  {
    instance = this;
  }

  private void Start()
  {
    Updater();
  }
  public static void UpdateUI()
  {
    instance.Updater();
  }

  public void Updater()
  {
    foreach (var item in textControllers)
    {
      item.UpdateMe();
    }
  }


  public static void UpdateHealth(int id)
  {
    if (id < 0) return;
    SoundManager.PlaySound(instance.healthDamage);
    instance.healthBar[id].useGravity = true;
  }


}
