using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextController : MonoBehaviour
{
    TMP_Text ui;
    [SerializeField] float power = 0.05f;
    [SerializeField] string format = "{0}";
    [SerializeField] bool hideEgalOnZero = false;


    [Space(30)]
    [SerializeField] IntReference value;
    private void Awake()
    {
        ui = GetComponent<TMP_Text>();
    }
    public void UpdateMe()
    {
        if (hideEgalOnZero && value.Value == 0)
        {
            ui.text = "";
        }
        else
        {
            ui.text = string.Format(format, value.Value);
        }
        ui.transform.DOPunchScale(Vector3.one * power, .1f, 1, 0);

    }
}
