using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static MobileInput instance;   // Diğer Script'ler üzrerinden erişimi sağlar

    // Mouse Positions
    private Vector2 start_pos;
    Vector2 last_pos;
    Vector2 delta;

    [Header("Controllers")]
    public bool tap;
    public bool swipeLeft;
    public bool swipeRight;
    public bool swipeUp;
    public bool swipeDown;
    public bool swipe;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        // Bütün boolları sıfırlıyoruz
        tap = swipe = false;
        swipeLeft = false;  // Sola kaydırma
        swipeRight = false; // Sağa kaydırma
        swipeUp = false; // Yukarı kaydırma
        swipeDown = false; // Aşağı kaydırma
    }
    private void FixedUpdate()
    {
        SwipeMove();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   // Mosue tuşuna baıldığında veya ekranda parmak ile basıldığındaki ilk pozisyon değerini alır
            start_pos = Input.mousePosition;    // İlk posizsyon değeri tutulur
            tap = true; // Dokunma aktif olur
        }

        if (Input.GetMouseButton(0))
        {   // Mosue tuşuna baılı tutulduğunda veya ekranda parmak ile basılı tutularak gidildiğindeki son pozisyonun değerini alır
            last_pos = Input.mousePosition; // Son pozisyon değeri tutulur
            delta = start_pos - last_pos;   // Toplam kaydırılan mesafe hesaplanır ve delta değerinde tutulur
            swipe = true;   // Kaydırma aktif olur

        }

        if (Input.GetMouseButtonUp(0))
        {   // Mosue tuşuna basma bırakıldığında veya ekranda parmak basma bırakıldığında 
            if (start_pos == last_pos) swipe = false;
            // Eğer dokunulan ilk pozisyon ile son pozisyon değeri aynı ise kaydırma pasif olur
            start_pos = Vector2.zero;
            last_pos = Vector2.zero;
            delta = Vector2.zero;
            // Tüm değerler sıfırlanır tekrar dokunma işlemine kadar

            swipeRight = false;
            swipeLeft = false;
            swipeUp = false;
            swipeDown = false;
            tap = false;
            // Tüm bool değerler sıfırlanır tekrar dokunma işlemine kadar
        }
    }
    void SwipeMove()
    {
        #region Mobile Controller 2 Direction
        // Kaydırma hareketinin yönünü belirler
        //if (tap)    // Eğer dokunma işlemi aktif ise çalışır
        //{
        //    if (swipe)  // Eğer swipe(kaydırma) işlemi aktif ise çalışır
        //    {
        //        if (delta.magnitude > 100)  // delta değerinin uzunluk bilgisini alır ve 100 değerinden büyükse çalışır - 100 değeri minimum kaydırma mesafesi
        //        {
        //            float x = delta.x;
        //            if (x < 0)
        //            {   // Eğer delta vector'nün (Toplam kaydırma mesafesi) x değeri 0 dan küçükse Sağa kaydırma aktif olur                       
        //                swipeRight = true;
        //                swipeLeft = false;
        //                tap = false;
        //            }
        //            else
        //            {   //  Eğer delta vector'nün (Toplam kaydırma mesafesi) x değeri 0 dan büyükse Sola kaydırma aktif olur 
        //                swipeRight = false;
        //                swipeLeft = true;
        //                tap = false;
        //            }
        //        }
        //    }
        //    else
        //    {   // Eğer kaydırma işlemi pasif ise 
        //        tap = false;    // Dokunma pasif olur
        //    }
        //}
        #endregion

        #region Mobile Controller 4 Direction
        if (tap)    // Eğer dokunma işlemi aktif ise çalışır
        {
            if (swipe)  // Eğer swipe(kaydırma) işlemi aktif ise çalışır
            {
                if (delta.magnitude > 100)  // delta değerinin uzunluk bilgisini alır ve 100 değerinden büyükse çalışır - 100 değeri minimum kaydırma mesafesi
                {
                    float x = delta.x;  // Kayrıma mesafesinin x değerini alır
                    float y = delta.y;  // Kayrıma mesafesinin y değerini alır
                    if (Mathf.Abs(x) > Mathf.Abs(y))    // Eğer kaydırma mesafesinin x ekseni y ekseninden daha büyükse (Right-Left) deilse (Up-Down) kaydırma aktif olur
                    {
                        // Right-Left
                        if (x < 0)
                        {
                            // Sağa kaydırma aktif olur 
                            swipeRight = true;
                            swipeLeft = false;
                            swipeUp = false;
                            swipeDown = false;
                        }
                        else
                        {
                            // Sola kaydırma aktif olur 
                            swipeRight = false;
                            swipeLeft = true;
                            swipeUp = false;
                            swipeDown = false;
                        }
                    }
                    else
                    {
                        // Up-Down
                        if (y < 0)
                        {
                            // İleri kaydırma aktif olur 
                            swipeRight = false;
                            swipeLeft = false;
                            swipeUp = true;
                            swipeDown = false;
                        }
                        else
                        {
                            // Geri kaydırma aktif olur 
                            swipeRight = false;
                            swipeLeft = false;
                            swipeUp = false;
                            swipeDown = true;
                        }
                    }
                }
            }
            else
            {   // Eğer kaydırma işlemi pasif ise 
                tap = false;    // Dokunma pasif olur
            }
        }
        #endregion
    }
}