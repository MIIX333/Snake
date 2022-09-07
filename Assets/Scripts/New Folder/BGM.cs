using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM _BGM;
    private void Awake()
    {
        if (_BGM == null)
        {
            _BGM = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_BGM != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
