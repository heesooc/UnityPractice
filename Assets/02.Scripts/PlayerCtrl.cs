using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCtrl : MonoBehaviour
{
    //컴포넌트를 캐시 처리할 변수
    private Transform tr;

    private void Start()
    {
        tr = GetComponent<Transform>();    
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Debug.Log("h=" + h);
        Debug.Log("v=" + v);

        //transform.position += new Vector3(0, 0, 1);
        tr.position += Vector3.forward * 1; // [전진 방향 * 속력]
    }
}
