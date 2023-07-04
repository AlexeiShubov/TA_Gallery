using UnityEngine;

public class MenuInitialize : MonoBehaviour
{
    [SerializeField] private SceneTransition sceneTransition;
    [SerializeField] private MenuManager _menuManager;
    
    private void Awake()
    {
        InitializeObjects();
    }

    private void InitializeObjects()
    {
        sceneTransition.Init();
        _menuManager.Init();
    }
}