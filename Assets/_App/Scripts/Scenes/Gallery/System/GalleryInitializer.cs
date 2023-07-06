using UnityEngine;

public class GalleryInitializer : MonoBehaviour
{
    [SerializeField] private GalleryManager _galleryManager;
    [SerializeField] private GridGenerator _gridGenerator;
    [SerializeField] private CellsController _cellsController;
    [SerializeField] private OrientationController _orientationController;

    private void Awake()
    {
        InitializeObjects();
    }

    private void InitializeObjects()
    {
        _orientationController.Init();
        _galleryManager.Init();
        _gridGenerator.Init();
        _cellsController.Init(_gridGenerator);
    }
}
