using UnityEngine;

public class EnemyObject : MoveableObject
{
    protected float lenth = 9.0f;
    protected float lenthOffset = 9.1f;

    protected void Update()
    {
        CheckPos();
    }

    protected void CheckPos()
    {
        if (pos.x > lenthOffset)
        {
            pos = new Vector3(lenth, pos.y, pos.z);
            vel = new Vector3(-vel.x, 0, vel.z);
        }
        else if (pos.x < -lenthOffset)
        {
            pos = new Vector3(-lenth, pos.y, pos.z);
            vel = new Vector3(-vel.x, 0, vel.z);
        }

        if (pos.z > lenthOffset)
        {
            pos = new Vector3(pos.x, pos.y, lenth);
            vel = new Vector3(vel.x, 0f, -vel.z);
        }
        else if (pos.z < -lenthOffset)
        {
            pos = new Vector3(pos.x, pos.y, -lenth);
            vel = new Vector3(vel.x, 0f, -vel.z);
        }

        transform.rotation = Quaternion.LookRotation(vel);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false) return;

        Player.Instance.GetDamaged();
        Destroy(gameObject);
    }
}
