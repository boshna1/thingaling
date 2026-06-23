using UnityEngine;

public class Baseball_Projectile : Enemy_Projectile
{
    public GameObject glove;

    public Vector3 GetVector()
    {
        return (glove.transform.position - transform.position).normalized;
    }
}
