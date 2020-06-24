using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Hole : MonoBehaviour
{

    [SerializeField] MeshFilter meshFilter = null;
    [SerializeField] MeshCollider meshCollider = null;

    [SerializeField] Vector2 hareketLimiti = default;
    [SerializeField] float radius = 0;
    [SerializeField] Transform delikMerkezi = null;
    [SerializeField] Transform cemberDönme = null;


    [Space]
    [SerializeField] float hareketHizi = 0;



    Mesh mesh;
    List<int> delikKoseNoktalari;
    List<Vector3> uzakliklar;
    int delikKoseNoktalariSayisi;

    float x, y;
    Vector3 dokunma, hedefAlma;


    void Start()
    {
        CemberAnimasyonu();

        Game.oyunBitti = false;
        Game.oyunDevamEdiyor = false;

        delikKoseNoktalari = new List<int>();
        uzakliklar = new List<Vector3>();

        mesh = meshFilter.mesh;

        delikKoseNoktalariniBul();
    }

    void CemberAnimasyonu()
    {
        cemberDönme
            .DORotate(new Vector3(90f, 0f, -90f), .2f)
            .SetEase(Ease.Linear)
            .From(new Vector3(90f, 0f, 0f))
            .SetLoops(-1, LoopType.Incremental);
    }

    void Update()
    {
        #if UNITY_EDITOR    //Mouse ile
        Game.oyunDevamEdiyor = Input.GetMouseButton(0);

        if (!Game.oyunBitti && Game.oyunDevamEdiyor)
        {
            DelikHareketi();
            delikKoseNoktalariPozisyonuGuncelle();
        }
       #else  //Telefon ile
        Game.oyunDevamEdiyor = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved;
        if(!Game.oyunBitti && Game.oyunDevamEdiyor)
        {
            DelikHareketi();
            delikKoseNoktalariPozisyonuGuncelle();
        }      
       #endif


    }


    void DelikHareketi()
    {
        x = Input.GetAxis("Mouse X");
        y = Input.GetAxis("Mouse Y");

        dokunma = Vector3.Lerp(delikMerkezi.position, delikMerkezi.position + new Vector3(x, 0f, y), hareketHizi * Time.deltaTime);

        hedefAlma = new Vector3(Mathf.Clamp(dokunma.x, -hareketLimiti.x, hareketLimiti.x), dokunma.y,
                    Mathf.Clamp(dokunma.z, -hareketLimiti.y, hareketLimiti.y)
            );
        delikMerkezi.position = hedefAlma;
    }

    void delikKoseNoktalariPozisyonuGuncelle()
    {
        Vector3[] vertices = mesh.vertices;
        for (int i = 0; i < delikKoseNoktalariSayisi; i++)
        {
            vertices[delikKoseNoktalari[i]] = delikMerkezi.position + uzakliklar[i];
        }

        mesh.vertices = vertices;
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }

    void delikKoseNoktalariniBul()
    {
        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            float distance = Vector3.Distance(delikMerkezi.position, mesh.vertices[i]);

            if (distance < radius)
            {
                delikKoseNoktalari.Add(i);
                uzakliklar.Add(mesh.vertices[i] - delikMerkezi.position);
            }

        }

        delikKoseNoktalariSayisi = delikKoseNoktalari.Count;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(delikMerkezi.position, radius);
    }
}
