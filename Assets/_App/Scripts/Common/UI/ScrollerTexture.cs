using UnityEngine;
using UnityEngine.UI;

public class ScrollerTexture : MonoBehaviour
{
    [SerializeField] private RawImage _rawImage;
    [SerializeField] private Vector2 _speedAnimation;

    private void Update()
    {
        _rawImage.uvRect = new Rect(_rawImage.uvRect.position + _speedAnimation * Time.deltaTime, _rawImage.uvRect.size);
    }
}
