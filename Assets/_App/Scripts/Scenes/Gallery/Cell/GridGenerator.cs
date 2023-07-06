using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Screen;

public static class DefaultViewSceneSize
{
    public static Vector2 ScreenSize { get; set; }
}

[RequireComponent(typeof(GridLayoutGroup))]
public class GridGenerator : MonoBehaviour
{
    [SerializeField] private int _optimalCountLoadingScreens;
    [SerializeField, Range(1, 6)] private int _countImagesOnTheScreen;
    [SerializeField, Min(1)] private int _totalCountImages;
    [SerializeField] private Cell _cellPrefab;

    private int _startLoadingCountImages;
    private CellFactory _factory;
    private Queue<Cell> _collectionClearCells;
    private GridLayoutGroup _gridLayoutGroup;

    public void Init()
    {
        _startLoadingCountImages = Mathf.Clamp(_startLoadingCountImages, _startLoadingCountImages, _totalCountImages);
        _startLoadingCountImages = _countImagesOnTheScreen * _optimalCountLoadingScreens;
        
        _factory = new CellFactory(_cellPrefab, transform);
        _collectionClearCells = new Queue<Cell>();
        _gridLayoutGroup = GetComponent<GridLayoutGroup>();
        
        SetCellSize();
        SpawnCells();
    }

    public void LoadImagePack()
    {
        if (_collectionClearCells.Count == 0) return;

        for (var i = 0; i < _countImagesOnTheScreen; i++)
        {
            _collectionClearCells.Dequeue().Init().SetImage(new ImageLoader(), _totalCountImages - _collectionClearCells.Count);
        }
    }

    private void SetCellSize()
    {
        if(DefaultViewSceneSize.ScreenSize == default)
        {
            _gridLayoutGroup.cellSize =
            new Vector2(width / _gridLayoutGroup.constraintCount - _gridLayoutGroup.spacing.x,
                height / (_countImagesOnTheScreen / _gridLayoutGroup.constraintCount) - _gridLayoutGroup.spacing.y);

            DefaultViewSceneSize.ScreenSize = _gridLayoutGroup.cellSize;
        }
        else
        {
            _gridLayoutGroup.cellSize = DefaultViewSceneSize.ScreenSize;
        }
    }

    private void GenerateNewCell(int imageNumber)
    {
        var newCell = _factory.Create().Init();

        if (imageNumber <= _startLoadingCountImages)
        {
            newCell.SetImage(new ImageLoader(), imageNumber);
        }
        else
        {
            _collectionClearCells.Enqueue(newCell);
        }
    }

    private void SpawnCells()
    {
        for (var i = 0; i < _totalCountImages;)
        {
            GenerateNewCell(++i);
        }
    }
}

