using UnityEngine;

public class TargetController : MonoBehaviour
{
  [SerializeField] bool destroy = false;
  [SerializeField] int value = 1;


  public float multiplier;
  [SerializeField] Vector2 multiplierRange = new Vector2(1, 3);


  Animator anim;

  [Header("Sound")]
  public AudioClip[] hitSound;


  public bool IsDestroy => destroy;

  [SerializeField] GameObject effects;
  private void Awake()
  {
    anim = GetComponent<Animator>();

    multiplier = Random.Range(multiplierRange.x, multiplierRange.y);
    enabled = true;
  }


  private void OnEnable()
  {
    GameManager.instance.targets.Add(gameObject);
  }

  public void Destroy()
  {
    if (GameManager.instance.targets.Contains(gameObject))
      GameManager.instance.targets.Remove(gameObject);

    Destroy(gameObject);

    if (!destroy) GameManager.DecreaseLife();

  }

  public void BeTouched()
  {
    if (effects) effects.SetActive(false);
    destroy = true;
    anim.SetTrigger("touche");

    PlayerController.IncrementScore(Mathf.RoundToInt(value * multiplier));
    SoundManager.PlaySound(hitSound);
    UiManager.UpdateUI();
  }
}
