using UnityEngine;

public class Glove : MonoBehaviour
{
    public bool isActive;
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
}
