using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerCoroutine : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerTxt;
    [SerializeField] private float _valueInSecondsForTheTimer;
   
    private bool _isTimerPlaying;
    private string _timePlayingFormat;
    private TimeSpan _timePlaying;
 
    private Coroutine _coroutineTimer;
   
    private void Start()
    {
        _isTimerPlaying = false;
        _timerTxt.text = "00:00.0";
        
        BeginTimer();
    }

    private void Update()
    {
        if (_valueInSecondsForTheTimer <= 0f)
        {
            _isTimerPlaying = false;
            StopCoroutine(_coroutineTimer);
        }
    }

    private void BeginTimer()
    {
        _isTimerPlaying = false;
        if (_coroutineTimer != null) {
            StopCoroutine(_coroutineTimer);
        }
        
        _isTimerPlaying = true;
        _coroutineTimer = StartCoroutine(UpdateTimer());
    }
 
    private IEnumerator UpdateTimer()
    {
        while (_isTimerPlaying)
        {
            _valueInSecondsForTheTimer -= Time.deltaTime;
           
            _timePlaying = TimeSpan.FromSeconds(_valueInSecondsForTheTimer);
            _timePlayingFormat = _timePlaying.ToString("mm':'ss'.'f");
            _timerTxt.text = _timePlayingFormat;
           
            yield return null;
        }
    }
}
