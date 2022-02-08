using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipleManager : MonoBehaviour
{

    public GameObject TempPiple;
    public List<PipleSelf> PipList = new List<PipleSelf>();
    Coroutine coroutine;
    public void StartRun()
    {
        PipList.Clear();
        coroutine = StartCoroutine(CreatePipe());
    }
    public void StopRun()
    {
        StopCoroutine(coroutine);
        for (int i = 0; i < PipList.Count; i++)
        {
            PipList[i].enabled = false;
        }
    }
    public void Init()
    {
        for (int i = 0; i < PipList.Count; i++)
        {
            Destroy(PipList[i].gameObject);
        }
    }
    IEnumerator CreatePipe()
    {
        for(int i = 0;i < 3;i++)
        {
            GenaratePiple();
            yield return new WaitForSeconds(2.2f);
        }
    }

    void GenaratePiple()
    {
    
            GameObject piple = Instantiate(TempPiple, this.transform);
            PipList.Add(piple.GetComponent<PipleSelf>());
        
       
    }
}
