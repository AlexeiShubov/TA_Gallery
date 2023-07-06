using System.Collections;
using MyLibs;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageLoader
{
    private const string _IMAGE_URL = "https://data.ikppbb.com/test-task-unity-data/pics/";
    private static int _counter;
    
    private RawImage _rawImage;
    private CoroutineService _coroutineService;
    private TextureBaseDataHolder _textureBaseDataHolder;

    public ImageLoader()
    {
        _coroutineService = ServiceManager.Instance.GetService<CoroutineService>();
        _textureBaseDataHolder = ServiceManager.Instance.GetService<TextureBaseDataHolder>();
    }

    public void LoadImage(RawImage rawImage, int imageNumber)
    {
        var texture = _textureBaseDataHolder.GetData(imageNumber);
        
        _rawImage = rawImage;

        if (texture == default)
        {
            _coroutineService.StartRoutine(LoadImageFromServer(imageNumber));
        }
        else
        {
            _rawImage.texture = texture;
        }
    }

    private IEnumerator LoadImageFromServer(int imageNumber)
    {
        using var webRequest = UnityWebRequestTexture.GetTexture(_IMAGE_URL + $"{imageNumber}.jpg");
        
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            var texture = DownloadHandlerTexture.GetContent(webRequest);

            _textureBaseDataHolder.SetData(imageNumber, texture);
            
            _rawImage.texture = texture;
        }
        else
        {
            Debug.LogError("Error: " + webRequest.error);
        }
    }
}