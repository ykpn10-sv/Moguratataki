using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 
public class MoguraMove : MonoBehaviour
{
    private float time;
    private float vecX;
    private float vecZ;
    bool isUp;

    public GameObject okText ;

    public TextMeshProUGUI scoreText;
    int score = 0;

 
    void Start()
    {
        isUp = false;
        okText.SetActive(false);
        scoreText.text = "Score: 0";

    }
 
    void Update()
    {
        time -= Time.deltaTime;
 
        if(time <= 0)
        {
           vecX = Random.Range(-4.5f, 4.5f);
           vecZ = Random.Range(-4.5f, 4.5f);
           this.transform.position = new Vector3(vecX, -1.1f, vecZ);
           if(!isUp)
           {
               isUp = true;
               StartCoroutine("MoguraUp");
           }
           time = 2.0f;
        }

        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // RaycastHit hit;

            // 左クリックされたら
        //     if (Input.GetMouseButtonDown(0))
        // {
        //     if (Physics.Raycast(ray, out hit))
        //     {
                // もぐら消す
                // Destroy(hit.collider.gameObject);
                // hit.collider.gameObject.SetActive(false);
                // Invoke("MoguraUp", 2.0f);
                // hit.collider.GetComponent<Renderer>().enabled = false;
        //     }
        // }

    }
 

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // もぐらを一時的に非表示
                hit.collider.GetComponent<Renderer>().enabled = false;
                Invoke("CubeActive", 1.0f);
                // テキスト表示
                okText.SetActive(true);
                Invoke("HideOkText", 0.2f);
                
                score++;
                scoreText.text = "Score: " + score;
            }
        
    }


     void CubeActive()
    {
        // もぐらを再表示
        GetComponent<Renderer>().enabled = true;

    }

    void HideOkText()
    {
        // テキスト非表示
        okText.SetActive(false);

    }
    
    IEnumerator MoguraUp()
    {

        GetComponent<AudioSource>().Play();


        for (int i=0; i<16; i++)
        {
            transform.Translate(0, 0.1f, 0);
            yield return new WaitForSeconds(0.01f);
        }
 
        for (int i=0; i<16; i++)
        {
            transform.Translate(0, -0.1f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        isUp = false;
    }
 
}