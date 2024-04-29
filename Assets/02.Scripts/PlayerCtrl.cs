using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] // private 속성 유지한 채 인스펙터 뷰 노출 기능
    private Transform tr; //컴포넌트를 캐시 처리할 변수
    private Animation anim; // Animation 컴포넌트를 저장할 변수

    public float MoveSpeed = 10.0f;
    public float TurnSpeed = 80.0f;

    private void Start()
    {
        // 컴포넌트를 추출해 변수에 대입
        tr = GetComponent<Transform>();    
        anim = GetComponent<Animation>();

        // 애니메이션 실행
        anim.Play("Idle");
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");  // -1.0f ~ 0.0f ~ + 1.0f
        float v = Input.GetAxis("Vertical");    // -1.0f ~ 0.0f ~ + 1.0f
        float r = Input.GetAxis("Mouse X");

        //Debug.Log("h=" + h);
        //Debug.Log("v=" + v);

        //transform.position += new Vector3(0, 0, 1);
        // 정규화 벡터를 사용한 코드
        //tr.position += Vector3.forward * 1; // [전진 방향 * 속력]

        //tr.Translate(Vector3.forward * 1); // 번역
        //tr.Translate(Vector3.forward * Time.deltaTime *v * MoveSpeed); // v(키보드 입력값: 전진, 후진, 정지

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir.normalized *MoveSpeed *Time.deltaTime);
        tr.Rotate(Vector3.up *TurnSpeed * Time.deltaTime *r); // Vector3.up 축을 기준으로 회전

        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)
    {
        if (v >= 0.1f)
        {
            anim.CrossFade("RunF", 0.25f); // CrossFade 함수: 애니메이션 블렌딩
        }
        else if(v <= -0.1f)
        {
            anim.CrossFade("RunB", 0.25f);
        }
        else if (h >= 0.1f)
        {
            anim.CrossFade("RunR", 0.25f);
        }
        else if (h <= -0.1f)
        {
            anim.CrossFade("RunL", 0.25f);
        }
        else
        {
            anim.CrossFade("Idle", 0.25f);
        }
    }
}
