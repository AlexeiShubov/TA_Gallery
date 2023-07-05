using System.Collections;
using MyLibs;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageLoader
{
    private const string _IMAGE_URL = "https://data.ikppbb.com/test-task-unity-data/pics/";
    
    private RawImage _rawImage;
    private CoroutineService _coroutineService;

    public ImageLoader()
    {
        _coroutineService = ServiceManager.Instance.GetService<CoroutineService>();
    }

    public void LoadImage(RawImage rawImage, int imageNumber)
    {
        _rawImage = rawImage;
        _coroutineService.StartRoutine(LoadImageFromServer(imageNumber));
    }

    private IEnumerator LoadImageFromServer(int imageNumber)
    {
        using var webRequest = UnityWebRequestTexture.GetTexture(_IMAGE_URL + $"{imageNumber}.jpg");
        
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            var texture = DownloadHandlerTexture.GetContent(webRequest);

            _rawImage.texture = texture;
        }
        else
        {
            Debug.LogError("Error: " + webRequest.error);
        }
    }
}