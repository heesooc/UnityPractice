using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Content;

public class Dotweentest : MonoBehaviour
{
    public CanvasGroup A;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(new Vector3(2, 3, 4), 1);
        A.DOFade(1, 5);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
