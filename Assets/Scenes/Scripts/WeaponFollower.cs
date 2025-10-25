using UnityEngine;

public class WeaponFollower : MonoBehaviour
{
    public Transform target; // assign the player transform here
    public Vector3 offset;

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
