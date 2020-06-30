using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
  public static SpawnerManager instance;

  [SerializeField] List<Spawnable> spawnables;
  Dictionary<GameObject, int> pools = new Dictionary<GameObject, int>();

  private void Awake()
  {
    instance = this;

    if (spawnables.Count == 0)
    {
      Debug.LogError("List is empty");
      return;
    }

    Debug.Log(pools);
    for (int i = 0; i < spawnables.Count; i++)
    {
      Debug.Log(spawnables[i] + " -- " + spawnables[i].obj + " -- " + spawnables[i].probability);
      pools.Add(spawnables[i].obj, spawnables[i].probability);
    }
  }

  [System.Serializable]
  class Spawnable
  {
    public GameObject obj;
    public int probability;
  }

  public static GameObject GetRandomElement()
  {
    return WeightedRandomizer.From(instance.pools).TakeOne();
  }
}
