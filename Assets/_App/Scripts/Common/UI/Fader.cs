using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] private AnimationCurve _dimmingCurve;
    [SerializeField] private Image _fadeImage;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _targetColor;
    
    private bool _isFade;
    private float _currentTime;
    private float _progress;
    private Color _defaultStartColor;
    private Color _defaultTargetColor;
    private Coroutine _fadeCoroutine;

    public void Init()
    {
        _defaultStartColor = _startColor;
        _defaultTargetColor = _targetColor;

        SetDefaultSettings();
    }

    public void SetNewFadeColor(Color startColor, Color targetColor)
    {
        _defaultStartColor = startColor;
        _defaultTargetColor = targetColor;
    }
    
    public void StartAnimationFade(bool fade, float duration, Action fadeComplete = null)
    {
        if(fade == _isFade) return;
        
        if (_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }

        _isFade = fade;
        _fadeCoroutine = StartCoroutine(DoFade(fade, duration, fadeComplete));
    }
    
    private IEnumerator DoFade(bool fade, float duration, Action fadeComplete)
    {
        if (fade)
        {
            SetDefaultSettings();
        }
        else
        {
            (_startColor, _targetColor) = (_targetColor, _startColor);
        }

        while (_currentTime < duration)
        {
            _fadeImage.color = Color.Lerp(_startColor, _targetColor, GetPercentageComplete(duration));
            
            yield return null;
        }
        
        SetDefaultSettings();
        
        fadeComplete?.Invoke();
    }

    private float GetPercentageComplete(float duration)
    {
        _currentTime += Time.deltaTime;
        _progress = _dimmingCurve.Evaluate(_currentTime / duration);

        return _progress;
    }

    private void SetDefaultSettings()
    {
        _fadeCoroutine = null;
        _currentTime = default;
        _progress = default;
        _startColor =  _defaultStartColor;
        _targetColor = _defaultTargetColor;
    }
}
