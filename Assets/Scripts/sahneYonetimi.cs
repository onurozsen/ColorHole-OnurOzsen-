using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahneYonetimi : MonoBehaviour
{
    public void IsimleSahneCagirma(string sahneIsmi)
    {
        SceneManager.LoadScene(sahneIsmi);
    }
}