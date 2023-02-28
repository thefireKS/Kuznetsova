using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Villain : MonoBehaviour
{
    [SerializeField] private GameObject[] spotsToAppear;
    
    [SerializeField] private GameObject[] villainImages;
    private GameObject _currentImage;

    [SerializeField] private float timeBetweenAppearances;
    private float _timerBetweenAppearances;
    
    [SerializeField] private float timeToCatch;
    private float _timerToCatch;
    private bool _needToCatch;

    private void Update()
    {
        if(_timerBetweenAppearances >= timeBetweenAppearances) Appear();
        _timerBetweenAppearances += Time.fixedDeltaTime;
        
        if(_needToCatch) _timerToCatch += Time.fixedDeltaTime;
        if(_timerToCatch >= timeToCatch) Chase();
    }

    private void Appear()
    {
        _currentImage = Instantiate(villainImages[Random.Range(0, villainImages.Length)], spotsToAppear[Random.Range(0, spotsToAppear.Length)].transform);
        _needToCatch = true;
    }

    public void Disappear()
    {
        Destroy(_currentImage);
        _needToCatch = false;
        _timerToCatch = 0;
    }

    private void Chase()
    {
        // spawn villain 
    }

}
