using MyLibs;
using UnityEngine;

public class GalleryManager : MonoBehaviour
{
    [SerializeField] private Transform _contentCanvas;
    [SerializeField] private SceneTransition sceneTransition;
    
    public void Init()
    {
        sceneTransition.Init();
        Cell.OnClickImageEvent += OnClickImage;
    }

    private void OnDisable()
    {
        Cell.OnClickImageEvent -= OnClickImage;
    }

    private void OnClickImage(Cell cell)
    {
        TransformExtension.Deactivate(_contentCanvas);
        ServiceManager.Instance.GetService<TextureBaseDataHolder>().SelectTextureNumber = cell.ImageNumber;
        sceneTransition.StartSwitchScene(SceneNames.View.ToString());
    }
}
