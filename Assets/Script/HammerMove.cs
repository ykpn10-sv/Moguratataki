using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HammerMove : MonoBehaviour
{
    Animator animator; //animatorを宣言

    public GameObject hammerObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //宣言したanimatorに、Animatorコンポーネントを取得する
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            
            Vector3 pos = hit.point;
        
        // var mousePosition = Input.mousePosition;
        // mousePosition.z = 10;
        // var pos = Camera.main.ScreenToWorldPoint(mousePosition);
        pos.y += 0.3f;
        hammerObject.transform.position = pos;

        }

        //マウスクリック情報を取得する
        if (Input.GetMouseButtonDown(0))
        {
            //マウスクリックが入っているかどうかの、確認ログ
            // Debug.Log("入力されてる");

            GetComponent<AudioSource>().Play();
            
            //SetTriggerでMove0を発動させる
            animator.SetTrigger("Move0");
        }
       
    
    }
}
