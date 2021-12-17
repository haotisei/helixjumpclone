using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Player Player;
    public Transform FinishPlatform;
    public Slider Slider;
    public float AsseptableFinishPlayerDistance = 1f;

    private float _startY;
    private float _mininmumReachY;
    private void Start()
    {
       _startY =  Player.transform.position.y;
    }

    private void Update()
    {
        _mininmumReachY = Mathf.Min(_mininmumReachY, Player.transform.position.y);
        float finishY = FinishPlatform.position.y;
        float t = Mathf.InverseLerp(_startY, finishY + AsseptableFinishPlayerDistance, _mininmumReachY);
        Slider.value = t;
    }
}
