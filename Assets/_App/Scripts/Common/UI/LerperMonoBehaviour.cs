using UnityEngine;

public abstract class LerperMonoBehaviour : MonoBehaviour
{
    protected const float _FULL_PERCENT_COMPLETE = 1f;
    
    [SerializeField] protected AnimationCurve _animationCurve;
    [SerializeField] protected float _duration;
    
    protected float _percentageComplete;

    protected virtual float GetPercentageComplete()
    {
        _percentageComplete = Mathf.MoveTowards(_percentageComplete, _FULL_PERCENT_COMPLETE, _duration * Time.deltaTime);

        return _percentageComplete;
    }
}