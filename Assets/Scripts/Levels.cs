using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    #region Singleton class: Levels
    public static Levels Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] ParticleSystem KazanmaEfekti = null;

    [Space]
    [HideInInspector] public int sahneicindekiObjeler;
    [HideInInspector] public int toplamObjeler;

    [SerializeField] Transform objelerinEbeveyni = null;

    [Space]
    [Header("Malzemeler")]
    [SerializeField] Material zemin = null;
    [SerializeField] Material nesnemiz = null;
    [SerializeField] Material engelimiz= null;
    [SerializeField] SpriteRenderer kenarliklar = null;
    [SerializeField] SpriteRenderer altkisim = null;
    [SerializeField] Image levelGelisimi = null;

    [SerializeField] SpriteRenderer arkaplan = null;



    [Space]
    [Header("Renklerimiz")]
    [Header("Zemin")]
    [SerializeField] Color zeminRengi = default;
    [SerializeField] Color kenarRengi = default;
    [SerializeField] Color altkisminRengi = default;
    
    [Header("Nesnelerimiz ve Engellerimiz")]
    [SerializeField] Color nesnelerimizinRengi = default;
    [SerializeField] Color engellerimizinRengi = default;

    [Header("Level Gelisimi")]
    [SerializeField] Color LevelGelisimRengi =default; 
    
    [Header("Arka Plan")]
    [SerializeField] Color kameraRengi =default;
    [SerializeField] Color arkaPlanRengi =default;


    
    void Start()
    {
        sayNesne();
        LevelRenkleriniGuncelle();
    }

    void sayNesne()
    {
        toplamObjeler = objelerinEbeveyni.childCount;
        sahneicindekiObjeler = toplamObjeler;
    }

    public void KazanmaEfektiniBaslat()
    {
        KazanmaEfekti.Play();
    }

    public void GelecekLeveliYükle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LeveliTekrarYükle()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LevelRenkleriniGuncelle()
    {
        zemin.color = zeminRengi;
        altkisim.color = altkisminRengi;
        kenarliklar.color = kenarRengi;

        nesnemiz.color = nesnelerimizinRengi;
        engelimiz.color = engellerimizinRengi;

        levelGelisimi.color = LevelGelisimRengi;

        Camera.main.backgroundColor = kameraRengi;
        arkaplan.color = arkaPlanRengi;
    }

    void OnValidate()
    {
        LevelRenkleriniGuncelle();
    }

}
