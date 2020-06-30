using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Database : ScriptableObject
{
  public Dictionary<string, int> score = new Dictionary<string, int>();
}

