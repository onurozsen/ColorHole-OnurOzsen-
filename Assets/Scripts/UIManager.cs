using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;


public class UIManager : MonoBehaviour
{
    #region Singleton class: UIManager
    public static UIManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    #endregion
    [SerializeField] int sceneOffset = 0;
    [SerializeField] TMP_Text SuankiLevelText = null;
    [SerializeField] TMP_Text GelecekLevelText = null;
    [SerializeField] Image LevelGelisimResmi = null;


    [Space]
    [SerializeField] TMP_Text LevelTamamlanditext = null;  

    [Space]
    [SerializeField] Image ekraniYavascaGoster = null;
    void Start()
    {
        karartmayiBaslat();
        LevelGelisimResmi.fillAmount = 0f;
        SetLevelGelisimText();
    }


    void SetLevelGelisimText()
    {
        int level = SceneManager.GetActiveScene().buildIndex + sceneOffset;
        SuankiLevelText.text = level.ToString();
        GelecekLevelText.text = (level + 1).ToString();
    }

     public void LevelGelisimGüncelle()
    {
        float val = 1f - ((float)Levels.Instance.sahneicindekiObjeler / Levels.Instance.toplamObjeler);
        LevelGelisimResmi.DOFillAmount(val, .4f);
    }
    
   public void LevelTamamlamayiGoster()
    {
        LevelTamamlanditext.DOFade(1f, .6f).From(0f);
        
    }

    public void karartmayiBaslat()
    {
        ekraniYavascaGoster.DOFade(0f, 1.3f).From(1f);
    }
}
