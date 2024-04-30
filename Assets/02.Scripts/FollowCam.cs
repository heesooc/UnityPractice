using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform targetTr;
    private Transform camTr;

    [Range(2.0f, 20.0f)]    // 선언할 변수 입력 범위 제한, 인스펙터 뷰 슬라이드바 표시
    public float distance = 10.0f; // 거리

    [Range(0.0f, 10.0f)]
    public float height = 2.0f; // 높이

    public float damping = 10.0f; // 반응속도
    public float targetOffset = 2.0f;

    private void Start()
    {
        camTr = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        Vector3 pos = targetTr.position + (-targetTr.forward * distance) + (Vector3.up * height);
        camTr.position = Vector3.Slerp(camTr.position, pos, Time.deltaTime * damping); // Slerp: 주로 회전 로직에 부드럽게 위치 변경
        camTr.LookAt(targetTr.position + (targetTr.up * targetOffset)); // 카메라 각도 회전
    }

}
