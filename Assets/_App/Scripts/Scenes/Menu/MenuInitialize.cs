using UnityEngine;

public class MenuInitialize : MonoBehaviour
{
    [SerializeField] private SceneTransition sceneTransition;
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private OrientationController _orientationController;
    
    private void Awake()
    {
        InitializeObjects();
    }

    private void InitializeObjects()
    {
        _orientationController.Init();
        sceneTransition.Init();
        _menuManager.Init();
    }
}