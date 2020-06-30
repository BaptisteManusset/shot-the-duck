using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Leaderscore : MonoBehaviour
{
  public Database database;

  public static Leaderscore instance;

  private void Awake()
  {
    instance = this;
  }

  public static Database GetDatabase()
  {
    return instance.database;
  }


  public static void AddNewScore(string pseudo, int score)
  {

    Debug.Log(GetDatabase());
    Debug.Log(GetDatabase().score);
    //Debug.Log(GetDatabase().score[pseudo]);
    if (GetDatabase().score.ContainsKey(pseudo) == true)
    {
      if (GetDatabase().score[pseudo] < score)
      {
        GetDatabase().score[pseudo] = score;
      }
    } else
    {
      GetDatabase().score.Add(pseudo.ToString(), score);
    }
    Debug.Log("\n \n \n \n");
    foreach (var item in GetDatabase().score)
    {
      Debug.Log($"{item.Key} | { item.Value}");
    }
    instance.Sort();
  }

  void Sort()
  {
    GetDatabase().score = GetDatabase().score.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
   
  }
}
