using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class WinUi : MonoBehaviour
{
  public TMP_InputField text;
  EventSystem es;

  TextController[] textes;

  Sequence sequence;
  [SerializeField] AudioClip sound;

  [SerializeField] GameObject higthscore;

  private void Start()
  {
    es = FindObjectOfType<EventSystem>();
    es.SetSelectedGameObject(text.gameObject);

    textes = GetComponentsInChildren<TextController>();

    higthscore.SetActive(GameManager.isHightscore);


    foreach (var item in textes)
    {
      item.UpdateMe();
    }

    SoundManager.PlaySound(sound);
    Animation();

    Cursor.visible = true; 
  }

  public void Animation()
  {
    sequence
          .Append(transform.DOScale(Vector3.zero, 0.1f).From())
          .Append(transform.DOScale(Vector3.one, 1).SetEase(Ease.OutBack));

  }
  #region it's for leaderboard // unused

  public void onendedit()
  {
    Debug.Log("on end edit");
    GameManager.AddPlayerToScore(text.text, PlayerController.instance.score.Value);
    gameObject.SetActive(false);
  }
  #endregion
}
