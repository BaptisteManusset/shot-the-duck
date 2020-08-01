using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] GameObject impact;

    [SerializeField] LayerMask layerMask;
    public IntReference score;
    public IntReference combo;
    public IntReference kills;


    [Header("Audio")]
    public AudioClip[] failSound;

    private void Awake()
    {
        instance = this;

        score.Value = 0;
        combo.Value = 0;
        kills.Value = 0;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;


            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {

                GameObject instance = Instantiate(impact, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal), hit.collider.transform);
                instance.transform.position += instance.transform.forward * .001f;

                if (hit.collider.CompareTag("Target"))
                {
                    #region animation
                    TargetController tc = hit.collider.gameObject.transform.parent.GetComponent<TargetController>();
                    tc.BeTouched();
                    combo.Value++;
                    kills.Value += 1;
                    #endregion
                }
                else
                {
                    SoundManager.PlaySound(failSound);
                    combo.Value = 0;
                    UiManager.UpdateUI();
                }
            }
        }
    }


    public static void IncrementScore(int value)
    {
        instance.score.Value += value * Mathf.Max(1, instance.combo.Value);
    }

}
