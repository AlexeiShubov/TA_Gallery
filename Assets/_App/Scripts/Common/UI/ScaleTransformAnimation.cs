using UnityEngine;

public class ScaleTransformAnimation : LerperMonoBehaviour
{
    [SerializeField] private Vector3 _startScale;
    [SerializeField] private Vector3 _targetScale;
    [Space]
    [SerializeField] private bool _pingPong;
    
    private float _targetValue;
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }
    
    private void Update()
    {
        DoAnimation();
    }

    private void ReversAnimation()
    {
        (_targetScale, _startScale) = (_startScale, _targetScale);
            
        _percentageComplete = default;
    }

    private void DoAnimation()
    {
        if (_pingPong && _percentageComplete >= _FULL_PERCENT_COMPLETE)
        {
            ReversAnimation();
        }

        _transform.localScale = Vector3.Lerp(_startScale, _targetScale, _animationCurve.Evaluate(GetPercentageComplete()));
    }
}
