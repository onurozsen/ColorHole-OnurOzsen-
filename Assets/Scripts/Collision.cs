using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class Collision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (!Game.oyunBitti)
        {
            string tag = other.tag;


            if (tag.Equals("Nesnemiz"))
            {
                Levels.Instance.sahneicindekiObjeler--;
                UIManager.Instance.LevelGelisimGüncelle();

                Magnet.Instance.miktanisAlaniKaldir(other.attachedRigidbody);

                Destroy(other.gameObject);


                if (Levels.Instance.sahneicindekiObjeler == 0)
                {
                    UIManager.Instance.LevelTamamlamayiGoster();
                    Levels.Instance.KazanmaEfektiniBaslat();
                    Invoke("gelecekLevel", 3f);
                    
                }
            }
            if (tag.Equals("Engelimiz"))
            {
                Game.oyunBitti = true;
                Camera.main.transform
                    .DOShakePosition(1f, .2f, 20, 90f)
                    .OnComplete(() =>
                    {
                        Levels.Instance.LeveliTekrarYükle();
                    });
            }
        }
    }

        void gelecekLevel()
        {
            Levels.Instance.GelecekLeveliYükle();
        }
    }

