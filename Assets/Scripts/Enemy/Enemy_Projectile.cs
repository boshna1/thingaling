using System.Collections;
using UnityEngine;
using static Global_Values;

public class Enemy_Projectile : MonoBehaviour
{
    public Direction dir;
    public float speed;
    Rigidbody rb;
    Vector2 customDireciton;
    Vector2 directionVector;
    float timeToAppear;
    float timeToFly;
    float timeToDisable;
    //Player player
    bool fly;
    bool indicator;
    [SerializeField] GameObject indicatorPrefab;
    public bool isActive;
    Vector3 pos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fly)
        {
            rb.AddForce(new Vector3(directionVector.x * speed, rb.linearVelocity.y, directionVector.y * speed), ForceMode.Impulse);
            fly = false;
        }

    }

    public void SetParameters(Vector3 scale, Vector3 pos, float timeToAppear, float timeToFly, float Speed, bool snapshotPlayerPos, Direction dir, bool indicator, float timeToDisable, Vector3 glovePos)
    {
        transform.position = pos;
        GetComponent<MeshRenderer>().enabled = true;
        this.timeToAppear = timeToAppear;
        this.timeToFly = timeToFly;
        this.speed = Speed;
        this.timeToDisable  = timeToDisable;

        if (snapshotPlayerPos)
        {
            //customDirection = player.transform.position - transform.position
            //dir = Custom
        }
        else
        {
            this.dir = dir;
        }
        SetDir(glovePos);
        isActive = true;

    }

    void SetDir(Vector3 glovePos)
    {
        transform.LookAt(glovePos);
        directionVector = (glovePos - transform.position).normalized;
    }

    void SetIndicator()
    {
        GameObject tempIndicator = Instantiate(indicatorPrefab, transform.position, Quaternion.identity);
        tempIndicator.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        //tempIndicator.transform.LookAt(player.transform.position);
    }

    public void SetActive(bool isActive)
    {
        this.isActive = isActive;
    }
    public void Disable()
    {
        isActive = false;
        GetComponent<MeshRenderer>().enabled = false;
        transform.position = new Vector3(0, -5, 0);
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeToAppear);
        //glove
        yield return new WaitForSeconds(timeToFly);
        fly = true;
        yield return new WaitForSeconds(timeToDisable);
        Disable();
    }
}
