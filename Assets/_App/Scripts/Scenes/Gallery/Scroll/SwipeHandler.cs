using System;
using UnityEngine;
using UnityEngine.UI;

public class SwipeHandler : IDisposable
{
    private const float _MIN_SCROLL_VALUE_FOR_LOAD_IMAGE = 0.2f;
    private const float _TOTAL_PROGRESS_PATH = 1f;
    private readonly ScrollRect _scrollRect;

    private float _currentProgressPath;
    private float _previousScrollValue;

    public event Action OnMinimumDistanceTraveled;
    
    public SwipeHandler(ScrollRect scrollRect)
    {
        _scrollRect = scrollRect;
        SetScrollToTopPosition();
        scrollRect.onValueChanged.AddListener(OnScrolling);
    }

    private void SetScrollToTopPosition()
    {
        _scrollRect.verticalNormalizedPosition = _TOTAL_PROGRESS_PATH;
    }
    
    private void OnScrolling(Vector2 scrollingValue)
    {
        var value = (float)Math.Round(scrollingValue.y, 1);

        if (value < _previousScrollValue)
        {
            OnScrollingDown(value);
        }

        _previousScrollValue = value;
    }

    private void OnScrollingDown(float scrollingValue)
    {
        if (scrollingValue < GetPercentDistance())
        {
            OnMinimumDistanceTraveled.Invoke();
        }
    }

    private float GetPercentDistance()
    {
        _currentProgressPath = _TOTAL_PROGRESS_PATH - _previousScrollValue;

        return _currentProgressPath / _MIN_SCROLL_VALUE_FOR_LOAD_IMAGE;
    }

    ~SwipeHandler()
    {
        ReleaseUnmanagedResources();
    }

    private void ReleaseUnmanagedResources()
    {
        _scrollRect.onValueChanged.RemoveListener(OnScrolling);
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();
        GC.SuppressFinalize(this);
    }
}
