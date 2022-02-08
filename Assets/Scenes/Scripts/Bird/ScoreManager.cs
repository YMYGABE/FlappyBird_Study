using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreManager
{
    private static ScoreManager instance;
    private int Max;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null) instance = new ScoreManager();
            return instance;
        }
    }
         
    public int Comper(int a)
    {
        if(a > Max)
        {
            Max = a;
            return Max;
        }
        else
        {
            return Max;
        }
    }
    
}
