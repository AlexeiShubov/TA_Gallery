using UnityEngine;

public class GalleryInitializer : MonoBehaviour
{
    [SerializeField] private GalleryManager _galleryManager;
    [SerializeField] private GridGenerator _gridGenerator;
    [SerializeField] private CellsController _cellsController;

    private void Awake()
    {
        InitializeObjects();
    }

    private void InitializeObjects()
    {
        _galleryManager.Init();
        _gridGenerator.Init();
        _cellsController.Init(_gridGenerator);
    }
}
