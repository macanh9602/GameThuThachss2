
using UnityEngine;

public class spowEffect : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(spow), 0, 0.3f);
    }
    public void spow()
    {
        int i=Random.Range(0, prefabs.Length);
        Instantiate(prefabs[i], new Vector3(Random.Range(-15f + parent.transform.position.x, 17f+parent.transform.position.x), 13, 0),Quaternion.identity);
    }
}
