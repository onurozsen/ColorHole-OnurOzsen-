using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    static MusicController muzikOynaticisi;
    private void Awake()
    {

        if (muzikOynaticisi != null)
        {
            Destroy(gameObject);
        }
        else
        {
            muzikOynaticisi = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
}
