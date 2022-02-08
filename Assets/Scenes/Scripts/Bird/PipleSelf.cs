using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipleSelf : MonoBehaviour
{
    public float speed;
    public float MinHight;
    public float MaxHight;
    private float Y;
    private float T;
    void Start()
    {
        Init();
    }

    void Update()
    {
        this.transform.position += new Vector3(-speed, 0) * Time.deltaTime;
        T += Time.deltaTime;
        if(T > 6.5f)
        {
            T = 0;
            Init();
        }
    }

    void Init()
    {
        Y = Random.Range(MinHight, MaxHight);
        transform.localPosition = new Vector3(0, Y, 0);
    }
}
