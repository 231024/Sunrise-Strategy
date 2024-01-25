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
    private string _endTimer = $"Game Over";
    private string _startTimer = $"Start Game";
    private TimeSpan _timePlaying;
 
    private Coroutine _coroutineTimer;
   
    private void Start()
    {
        _isTimerPlaying = false;
        _timerTxt.text = _startTimer;
        
        BeginTimer();
    }

    private void Update()
    {
        if (_valueInSecondsForTheTimer <= 0f)
        {
            _isTimerPlaying = false;
            StopCoroutine(_coroutineTimer);
            _timerTxt.text = _endTimer;
            _timerTxt.color = Color.red;
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
        while (_isTimerPlaying && _valueInSecondsForTheTimer >= 0f)
        {
            _valueInSecondsForTheTimer -= Time.deltaTime;
           
            _timePlaying = TimeSpan.FromSeconds(_valueInSecondsForTheTimer);
            _timePlayingFormat = _timePlaying.ToString("mm':'ss");
            _timerTxt.text = _timePlayingFormat;
           
            yield return null;
        }
    }
}
