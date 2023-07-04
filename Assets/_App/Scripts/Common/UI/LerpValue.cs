using System.Collections;
using UnityEngine;

public class LerpValue
{
    private const float _FULL_PERCENT_COMPLETE = 1f;
    private float _currentTime;
    private float _percentageComplete;

    public IEnumerator LerpAnimationValue(float startValue, float targetValue, float duration)
    {
        while (_percentageComplete < _FULL_PERCENT_COMPLETE)
        {
            _percentageComplete = Mathf.MoveTowards(_percentageComplete, _FULL_PERCENT_COMPLETE, duration * Time.deltaTime);
            
            yield return null;
        }
    }
}
