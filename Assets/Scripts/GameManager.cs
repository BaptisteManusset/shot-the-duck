using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using static Database;

public class GameManager : MonoBehaviour
{
  public static GameManager instance;

  public float timer = 0;
  public Transform clock;
  public TextMeshPro text;
  public static bool isFinish = false;
  public static bool isStart = false;

  [Header("Spawner Parameter")]
  public int maxTargetsCount = 5;
  int maxTargetsCountDefault;
  public int delayBetweenIncrease = 10;

  [Header("Target list")]
  public List<GameObject> targets;
  public List<Spawner> spawners;

  [Header("UI")]

  public GameObject winui;
  public GameObject startui;

  MouseLook mouseLook;
  PlayerController playerController;

  [Header("Life")]
  public int life = 10;

  [Header("Score")]
  [SerializeField] IntReference actualScore;
  [SerializeField] IntReference highscore;
  public static bool isHightscore = false;
  private void Awake()
  {
    #region set static
    isFinish = false;
    isStart = false;
    isHightscore = false;
    #endregion



    instance = this;

    mouseLook = FindObjectOfType<MouseLook>();
    playerController = FindObjectOfType<PlayerController>();

    maxTargetsCountDefault = maxTargetsCount;


    Cursor.visible = false;
  }

  private void Start()
  {
    Invoke(nameof(ThisIsTheBeginning), 3);
  }
  void ThisIsTheBeginning()
  {
    if (isStart) return;
    timer = 0;
    startui.SetActive(true);

  }
  void Update()
  {
    if (!isFinish && isStart)
    {
      timer += Time.deltaTime;

      UpdateUi();
    }

    if (Input.GetKeyDown(KeyCode.R) && isStart && !isFinish)
    {
      Restart();
    }


    maxTargetsCount = maxTargetsCountDefault + Mathf.RoundToInt(timer % delayBetweenIncrease);
  }
  public static void StartGame()
  {

    isStart = true;

    foreach (var item in instance.spawners)
    {
      item.BeginGame();

    }
  }
  public void RestartLevel()
  {
    Restart();
  }
  public static void Restart()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
  void UpdateUi()
  {
    clock.localRotation = Quaternion.Euler(0, 0, (timer % 60) * 6 * -1);
    text.text = FormatTime(timer);

    if (instance.actualScore.Value > instance.highscore.Value && instance.highscore.Value != 0)
    {
      isHightscore = true;
    }

  }
  public static string FormatTime(float time)
  {
    System.TimeSpan t = System.TimeSpan.FromSeconds(time);
    return string.Format("{0,1:0}:{1,2:00}", t.Minutes, t.Seconds);
  }
  public static float Remap(float value, float from1, float to1, float from2, float to2)
  {
    return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
  }
  public static void DecreaseLife()
  {
    instance.life--;
    UiManager.UpdateHealth(instance.life);
    if (instance.life <= 0)
    {
      Win();
    }

  }
  public static void Win()
  {
    if (isFinish) return;

    #region mouse & controls
    instance.mouseLook.enabled = false;
    instance.playerController.enabled = false;
    Cursor.visible = true;
    Cursor.lockState = CursorLockMode.None;
    #endregion


    if (isHightscore)
    {
      instance.highscore.Value = instance.actualScore.Value;
    }




    isFinish = true;
    instance.winui.SetActive(true);
  }

  #region it's for leaderboard // unused
  public static void AddPlayerToScore(string pseudo, int score)
  {
    Leaderscore.AddNewScore(pseudo, score);
  }
  #endregion
}
