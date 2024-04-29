using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCtrl : MonoBehaviour
{
    //컴포넌트를 캐시 처리할 변수
    private Transform tr;
    public float MoveSpeed = 10.0f;

    private void Start()
    {
        tr = GetComponent<Transform>();    
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");  // -1.0f ~ 0.0f ~ + 1.0f
        float v = Input.GetAxis("Vertical");    // -1.0f ~ 0.0f ~ + 1.0f

        Debug.Log("h=" + h);
        Debug.Log("v=" + v);

        //transform.position += new Vector3(0, 0, 1);
        // 정규화 벡터를 사용한 코드
        //tr.position += Vector3.forward * 1; // [전진 방향 * 속력]

        //tr.Translate(Vector3.forward * 1); // 번역
        tr.Translate(Vector3.forward * Time.deltaTime *v * MoveSpeed); // v(키보드 입력값: 전진, 후진, 정지
    }
}
