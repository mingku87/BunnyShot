using UnityEngine;

public class MoveableObject : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    protected Vector3 pos
    {
        get { return transform.position; }
        set { transform.position = value; }
    }
    protected Vector3 vel
    {
        get { return rb.velocity; }
        set { rb.velocity = value; }
    }
}