using MyLibs;
using UnityEngine;
using UnityEngine.UI;

public class ViewManager : MonoBehaviour
{
    private const int _DEFAULT_IMAGE = 1;
    
    [SerializeField] private SceneTransition _sceneTransition;
    [SerializeField] private Button _backButton;
    [SerializeField] private RawImage _rawImage;

    public void Init()
    {
        _sceneTransition.Init();
        ButtonExtension.AddListener(_backButton, OnClickBackButton);
        
        var number = ServiceManager.Instance.GetService<TextureBaseDataHolder>().SelectTextureNumber;
        
        number = number == default ? _DEFAULT_IMAGE : number;
        new ImageLoader().LoadImage(_rawImage, number);
    }

    private void OnDisable()
    {
        ButtonExtension.RemoveAllListeners(_backButton);
    }

    private void OnClickBackButton()
    {
        _sceneTransition.StartSwitchScene(SceneNames.Gallery.ToString());
        ButtonExtension.RemoveAllListeners(_backButton);
    }
}
