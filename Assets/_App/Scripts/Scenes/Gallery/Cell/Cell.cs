using System;
using MyLibs;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage), typeof(Button))]
public class Cell : MonoBehaviour
{
    public static event Action<Cell> OnClickImageEvent;
    
    [SerializeField] private Button _button;
    [SerializeField] private RawImage _rawImage;

    private int _imageNumber;

    public int ImageNumber => _imageNumber;

    public Cell Init()
    {
        ButtonExtension.AddListener(_button, OnClickImage);
        
        return this;
    }

    public void SetImage(ImageLoader imageLoader, int imageNumber)
    {
        _imageNumber = imageNumber;
        imageLoader.LoadImage(_rawImage, imageNumber);
    }

    private void OnClickImage()
    {
        if (_rawImage.texture != null)
        {
            OnClickImageEvent.Invoke(this);
        }
    }

    private void OnDisable()
    {
        ButtonExtension.RemoveAllListeners(_button);
    }
}