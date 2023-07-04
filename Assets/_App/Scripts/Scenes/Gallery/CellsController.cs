using UnityEngine;
using UnityEngine.UI;

public class CellsController : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;

    private SwipeHandler _swipeHandler;
    private GridGenerator _gridGenerator;

    public void Init(GridGenerator gridGenerator)
    {
        _gridGenerator = gridGenerator;
    }

    private void Start()
    {
        _swipeHandler = new SwipeHandler(_scrollRect);
        _swipeHandler.OnMinimumDistanceTraveled += OnMinimumDistanceTraveled;
    }

    private void OnMinimumDistanceTraveled()
    {
        _gridGenerator.LoadImagePack();
    }

    private void OnDisable()
    {
        _swipeHandler.OnMinimumDistanceTraveled -= OnMinimumDistanceTraveled;
    }
}
