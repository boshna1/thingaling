using UnityEngine;
using static Global_Values;

public class Hitbox : MonoBehaviour
{
    [SerializeField] float Damage;
    [SerializeField] float iFrameTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Update()
    {

    }


    void OnTriggerStay(Collider other)
    {
        Debug.Log("Triggered");
        if (other.TryGetComponent<PlayerHp>(out PlayerHp php))
        {
            Debug.Log("Checked");
            if (!php.hasIFrame)
            {
                Debug.Log("Damage");
                php.TakeDamage(Damage, iFrameTime);
            }
            
        }
    }
}
