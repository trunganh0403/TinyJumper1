using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNhay : MonoBehaviour
{
    public float lucCongThem;
    public float doCao;
    public float lucNhay;
    public float minGioiHanDoCao;
    public float maxGioiHanDoCao;
    public float minGioiHanLucNhay;
    public float maxGioiHanLucNhay;
    float doCaoBanDau;
    float lucNhayBanDauBan;
    AudioSource audioSou;
    public AudioClip amThanhNhay;
    public AudioClip amThanhChet;
    public AudioClip amThanhPoint;
    
    bool blNhay;
    bool blDuocPhepNhay;
    Rigidbody2D rb;
    Animator ani;
    int diemCong;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        doCaoBanDau = doCao;
        lucNhayBanDauBan = lucNhay;
        audioSou = GetComponent<AudioSource>();
        diemCong=0;
    }

    void Update()
    {
        BamNut();
    }
    
    void BamNut()
    {


        if (Input.GetKey(KeyCode.Space) )
        {
            TaoLuc();
        }
        if (Input.GetKeyUp(KeyCode.Space) && blNhay && blDuocPhepNhay)
        {
            Nhay();
            lucNhay = lucNhayBanDauBan;
            doCao = doCaoBanDau;
            blNhay=false;

        }
    }    
    void Nhay()
    {
        if (amThanhNhay != null)
        {
            audioSou.clip = amThanhNhay;
            audioSou.Play();
        }
       
        ani.SetBool("DungYen", false);
        rb.AddForce(new Vector2(lucNhay,doCao));
        blDuocPhepNhay = false;

    }
    
    void TaoLuc ()
    {
        doCao +=lucCongThem*Time.deltaTime;
        lucNhay += Time.deltaTime * lucCongThem;
        doCao = Mathf.Clamp(doCao, minGioiHanDoCao, maxGioiHanDoCao);
        lucNhay = Mathf.Clamp(lucNhay, minGioiHanLucNhay, maxGioiHanLucNhay);
        blNhay = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == ("NenDat"))
        {
            if (amThanhPoint != null)
            {
                audioSou.clip = amThanhPoint;
                audioSou.Play();
            }
            diemCong++;
            ani.SetBool("DungYen", true);
            blDuocPhepNhay = true;
            GameConTroller.Instance.CongDiem(diemCong);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null && collision.gameObject.tag == ("GioiHanChet"))
        {

            if (amThanhChet != null)
            {
                audioSou.clip = amThanhChet;
                audioSou.Play();
            }
            GameConTroller.Instance.EndGame();
        }    
    }
}
