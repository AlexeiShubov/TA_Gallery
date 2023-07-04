using UnityEngine;

public class ViewInitializer : MonoBehaviour
{
    [SerializeField] private ViewManager _viewManager;
    
    private void Awake()
    {
        InitializeObjects();
    }

    private void InitializeObjects()
    {
        _viewManager.Init();
    }
}
