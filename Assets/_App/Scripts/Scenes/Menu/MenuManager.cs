using MyLibs;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private SceneTransition sceneTransition;
    
    public void Init()
    {
        sceneTransition.Init();
        ButtonExtension.AddListener(_startButton, OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        sceneTransition.StartSwitchScene(SceneNames.Gallery.ToString());
        TransformExtension.Deactivate(_startButton.transform);
    }

    private void OnDisable()
    {
        ButtonExtension.RemoveAllListeners(_startButton);
    }
}
