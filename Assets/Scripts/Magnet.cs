using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(SphereCollider))]
public class Magnet : MonoBehaviour
{
    #region Singleton class: Magnet
    public static Magnet Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] float miknatisForce = 0;

    List<Rigidbody> affectedRigidbodies = new List<Rigidbody>();
    Transform miknatis;
    void Start()
    {
        miknatis = transform;
        affectedRigidbodies.Clear();
    }

    void GuncellemeSabit()
    {
        if(!Game.oyunBitti && Game.oyunDevamEdiyor)
        {
            foreach(Rigidbody rb in affectedRigidbodies)
            {
                rb.AddForce((miknatis.position - rb.position) * miknatisForce * Time.fixedDeltaTime);
            }
        }   
    }

    void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;
        if (!Game.oyunBitti && (tag.Equals("Engelimiz") || tag.Equals("Nesnemiz")))
        {
            miktanisAlaniEkle(other.attachedRigidbody);
        }
    }

    void OnTriggerExit(Collider other)
    {
        string tag = other.tag;
        if (!Game.oyunBitti && (tag.Equals("Engelimiz") || tag.Equals("Nesnemiz")))
        {
            miktanisAlaniKaldir(other.attachedRigidbody);
        }
    }


    public void miktanisAlaniEkle(Rigidbody rb)
    {
        affectedRigidbodies.Add(rb);
    }
    public void miktanisAlaniKaldir(Rigidbody rb)
    {
        affectedRigidbodies.Remove(rb);
    }
}
