using UnityEngine;

public class MovementController : MonoBehaviour
{
  Rigidbody rb;
  TargetController tc;
  [SerializeField] float pathWidth = 3.5f;
  public bool leftToRight = true;
  [SerializeField] float speed = .5f;


  private void Awake()
  {
    rb = GetComponent<Rigidbody>();
    tc = GetComponent<TargetController>();

  }

  private void FixedUpdate()
  {

    if ((transform.position.x > pathWidth && leftToRight) || (transform.position.x < -pathWidth && !leftToRight))
    {
      tc.Destroy();

    }

    rb.MovePosition(transform.position + transform.right * (leftToRight ? 1 : -1) * Time.fixedDeltaTime * tc.multiplier * speed);
  }
}
