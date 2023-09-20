using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class ParallaxController : MonoBehaviour
{
    Transform cam;
    Vector3 camStartPos;
    float distance;

    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;

    float farthestBack;

    [Range(0.01f, 0.05f)]
    public float parallaxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;

        int backCout = transform.childCount;
        mat = new Material[backCout];
        backSpeed = new float[backCout];
        backgrounds = new GameObject[backCout];

        for (int i = 0; i < backCout; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Material>();
        }
        BackSpeedCalculate(backCout);

    }



    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++)
        {
            if ((backgrounds[i].transform.position.z - camStartPos.z) > farthestBack) // khoang cach xa nhat
            {
                farthestBack = backgrounds[i].transform.position.z - camStartPos.z;
            }
        }
        for (int i = 0; i < backCount; i++)
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack; // luu vao mang , background can gan toc do cang nhanh
            Debug.Log(backSpeed[i]);

        }
    }

    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x;
        //Debug.Log(distance);
        transform.position = new Vector3(cam.position.x, transform.position.y, 0); // di theo cam
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            //mat[i].SetTexture("_MainTex", texture);
            backgrounds[i].GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
            //
        }
    }
}
