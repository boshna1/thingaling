using System.Collections;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] float playerHp;
    [SerializeField] public float playerDef;
    public bool hasIFrame;
    int safeguardCount;
    void Start()
    {
        
        playerHp = Global_Values.CalculatePlayerHP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage, float iFrameTime)
    {
        if (!hasIFrame)
        {
            hasIFrame = true;
            playerHp -= damage;         
            StartCoroutine(DamageCooldown(iFrameTime)); 
            CheckDeath();
        }
        
    }
    
    public void TakeDamage(float damage) //i frame ignore
    {
        if (!hasIFrame)
        {
            playerHp -= damage;
            CheckDeath();
        }
    }

    IEnumerator DamageCooldown(float time)
    {
        
        yield return new WaitForSeconds(time);
        hasIFrame = false;
    }

    public void CheckDeath()
    {
        if (playerHp <= 0 && safeguardCount <= 0)
        {
            //die stuff
        }
    }
}
