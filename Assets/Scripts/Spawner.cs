using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  //[SerializeField] List<GameObject> targets;
  public bool leftToRight = true;
  public float delay = 2;
  [Range(0, 5)] public float delayRandom = 2;
  public bool _enable = true;
  private void Start()
  {

    GameManager.instance.spawners.Add(this);


  }



  public void BeginGame()
  {
    if (_enable)
      InvokeRepeating(nameof(Wave), Random.Range(0, 3), delay + Random.Range(0, delayRandom));
  }

  void Wave()
  {
    if (GameManager.isFinish)
    {
      CancelInvoke(nameof(Wave));
      return;
    }


    //if (GameManager.instance.targets.Count >= GameManager.instance.maxTargetsCount) return;

    //GameObject target = targets[Random.Range(0, targets.Count)];

    GameObject instance = Instantiate(SpawnerManager.GetRandomElement(), transform.position, Quaternion.identity);
    MovementController mc = instance.GetComponent<MovementController>();
    mc.leftToRight = leftToRight;

    if (leftToRight == false)
    {
      instance.transform.GetChild(0).localScale = new Vector3(-1, 1, 1);
    }
  }
}
