
using UnityEngine;

public class spowEffect : MonoBehaviour
{
    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(spow), 0, 0.3f);
    }
    public void spow()
    {
        int i=Random.Range(0, prefabs.Length);
        Instantiate(prefabs[i], new Vector3(Random.Range(-15f, 17f), 13, 0),Quaternion.identity);
    }
}
