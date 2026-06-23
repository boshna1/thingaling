using System.Collections;
using UnityEngine;

public class v1_BatterUp_Object : MonoBehaviour
{
    public bool isActive;
    Rigidbody rb;
    float timeToAppear;
    float timeToFly;
    float timeToDisable;
    bool indicator;
    [SerializeField] GameObject indicatorPrefab;
    Vector3 pos;
    bool lerp;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetParameters(Vector3 rot, Vector3 scale, Vector3 pos, float timeToAppear, float timeToFly, bool indicator, float timeToDisable)
    {
        transform.position = pos;
        transform.localScale = scale;
        transform.eulerAngles = rot;
        GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        this.timeToAppear = timeToAppear;
        this.timeToFly = timeToFly;
        this.timeToDisable = timeToDisable;
        isActive = true;
    }

    public void Execute()
    {
        StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(timeToAppear);
        GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        yield return new WaitForSeconds(timeToFly);
        animator.SetTrigger("Fire");
        yield return new WaitForSeconds(timeToDisable);
        GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        isActive = false;
        transform.position = new Vector3(0, 20, 0);
    }
}
