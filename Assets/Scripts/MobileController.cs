using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float speed = 30f;    // Player hareket hızı
    [SerializeField] private float horizontalspeed = 10f; // Player yön hareket hızı
    [SerializeField] private float defaultSwipe = 4f;    // // Player default kaydırma mesafesi
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //transform.Translate(0, 0, speed * Time.fixedDeltaTime);
        MoveInput();    // Player hareket kontrolü
    }

    void MoveInput()
    {
        #region Mobile Controller 2 Direction

        //float moveX = transform.position.x; // Player objesinin x pozisyonun değerini alır
        //transform.Translate(0, 0, speed * Time.fixedDeltaTime); // Player nesnesi oyun başladığında sürekli ileri hareket eder

        //if (Input.GetKey(KeyCode.LeftArrow) || MobileInput.instance.swipeLeft)
        //{   // Eğer klavyede sol ok tuşuna basıldıysa yada "MobileInput" scriptinin swipeLeft değeri True ise  Sola gider               
        //    moveX = Mathf.Clamp(moveX - 1 * horizontalspeed * Time.fixedDeltaTime, -defaultSwipe, defaultSwipe);  // Pozisyon sınırlandırılması koyulacaksa
        //    // Player objesinin x (sol) pozisyonundaki gideceği min-max sınırı belirler
        //    //moveX = moveX - 1 * horizontalspeed * Time.fixedDeltaTime;  // Pozisyon sınırlandırılması yoksa        
        //}
        //else if (Input.GetKey(KeyCode.RightArrow) || MobileInput.instance.swipeRight)
        //{   // Eğer klavyede sağ ok tuşuna basıldıysa yada "MobileInput" scriptinin swipeRight değeri True ise Sağa gider         
        //    moveX = Mathf.Clamp(moveX + 1 * horizontalspeed * Time.fixedDeltaTime, -defaultSwipe, defaultSwipe);  // Pozisyon sınırlandırılması koyulacaksa
        //    // Player objesinin  x (sağ) pozisyonundaki gideceği min-max sınırı belirler
        //    //moveX = moveX + 1 * horizontalspeed * Time.fixedDeltaTime;  // Pozisyon sınırlandırılması yoksa                  
        //}
        //else
        //{
        //    rb.velocity = Vector3.zero; //Eğer sağ-sol hareket yapılmadıysa Player objesi sabit kalsın
        //}
        //transform.position = new Vector3(moveX, transform.position.y, transform.position.z);
        //// Player objesinin pozisyonu moveX değerine göre x ekseninde sağ-sol hareket eder

        #endregion

        #region Mobile Controller 4 Direction

        float moveX = transform.position.x; // Player objesinin x pozisyonun değerini alır      
        float moveZ = transform.position.z; // Player objesinin z pozisyonun değerini alır       

        if (Input.GetKey(KeyCode.LeftArrow) || MobileInput.instance.swipeLeft)
        {   // Eğer klavyede sol ok tuşuna basıldıysa yada "MobileInput" scriptinin swipeLeft değeri True ise  Sola hareket gider
            moveX = Mathf.Clamp(moveX - 1 * horizontalspeed * Time.fixedDeltaTime, -defaultSwipe, defaultSwipe);    // Pozisyon sınırlandırılması koyulacaksa
            // Player objesinin x (sol) pozisyonundaki gideceği min-max sınırı belirler
            //moveX = moveX - 1 * horizontalspeed * Time.fixedDeltaTime;    // Pozisyon sınırlandırılması yoksa 
        }
        else if (Input.GetKey(KeyCode.RightArrow) || MobileInput.instance.swipeRight)
        {   // Eğer klavyede sağ ok tuşuna basıldıysa yada "MobileInput" scriptinin swipeRight değeri True ise Sağa hareket gider  
            moveX = Mathf.Clamp(moveX + 1 * horizontalspeed * Time.fixedDeltaTime, -defaultSwipe, defaultSwipe);    // Pozisyon sınırlandırılması koyulacaksa
            // Player objesinin x (sağ) pozisyonundaki gideceği min-max sınırı belirler
            //moveX = moveX + 1 * horizontalspeed * Time.fixedDeltaTime;    // Pozisyon sınırlandırılması yoksa 
        }
        else if (Input.GetKey(KeyCode.UpArrow) || MobileInput.instance.swipeUp)
        {   // Eğer klavyede yukarı ok tuşuna basıldıysa yada "MobileInput" scriptinin swipeUp değeri True ise İleri hareket gider         
            moveZ = moveZ + 1 * speed * Time.fixedDeltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow) || MobileInput.instance.swipeDown)
        {   // Eğer klavyede aşağı ok tuşuna basıldıysa yada "MobileInput" scriptinin swipeDown değeri True ise Geri hareket gider         
            moveZ = moveZ - 1 * speed * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = Vector3.zero; // Eğer hareket edilmediyse Player objesi sabit kalsın
        }
        
        transform.position = new Vector3(moveX, transform.position.y, moveZ);
        // Player objesinin pozisyonu moveX değerine göre x ekseninde, moveZ değerine göre z ekseninde hareket eder ve y ekseninde sabit kalır 

        #endregion
    }
}
