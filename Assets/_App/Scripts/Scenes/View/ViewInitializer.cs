using UnityEngine;

public class ViewInitializer : MonoBehaviour
{
    [SerializeField] private ViewManager _viewManager;
    [SerializeField] private OrientationController _orientationController;
    
    private void Awake()
    {
        InitializeObjects();
    }

    private void InitializeObjects()
    {
        _orientationController.Init();
        _viewManager.Init();
    }
}
