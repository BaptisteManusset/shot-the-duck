using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
  public static bool isPause = true;
  public static MenuManager instance;
  public GameObject ui;
  private void Awake()
  {
    instance = this;

    ToggleUi();
  }


  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      ToggleUi();
    }
  }

  public static void ToggleUi()
  {
    isPause = !isPause;
    Cursor.visible = isPause;

    instance.ui.SetActive(isPause);
    Time.timeScale = isPause ? 0 : 1;
    if (isPause)
    {
      Cursor.lockState = CursorLockMode.Confined;
    } else
    {
      Cursor.lockState = CursorLockMode.Locked;
    }

  }
}
