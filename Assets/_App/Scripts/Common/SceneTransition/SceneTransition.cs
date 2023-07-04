using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    private const float _START_PERCENT = 0f;
    private const float _FULL_PERCENT_COMPLETE = 1f;

    [SerializeField] private Fader _fader;
    [SerializeField] private Image _progressImage;
    [SerializeField] private TextMeshProUGUI _percentageProgressText;
    [SerializeField] private float _durationSwitchScene;

    private float _percentageComplete;
    private AsyncOperation _asyncOperation;
    private Coroutine _coroutine;

    public void Init()
    {
        _fader.Init();
    }

    public void StartSwitchScene(string nameScene)
    {
        if(_coroutine != null) return;

        _asyncOperation = SceneManager.LoadSceneAsync(nameScene);
        _asyncOperation.allowSceneActivation = false;
        _fader.StartAnimationFade(true, _durationSwitchScene, OnAnimationOver);
        _progressImage.gameObject.SetActive(true);

        _coroutine = StartCoroutine(StartAnimationProgress());
    }

    private IEnumerator StartAnimationProgress()
    {
        var currentTime = 0f;

        while (currentTime < _durationSwitchScene)
        {
            currentTime += Time.deltaTime;
            _percentageComplete = Mathf.Lerp(_START_PERCENT, _FULL_PERCENT_COMPLETE,  currentTime / _durationSwitchScene);
            _percentageProgressText.text = $"{_percentageComplete * 100:F0}%";
            _progressImage.fillAmount = _percentageComplete;
            
            yield return null;
        }
    }

    private void OnAnimationOver()
    {
        StopCoroutine(_coroutine);
        _coroutine = null;
        _progressImage.gameObject.SetActive(false);
        _asyncOperation.allowSceneActivation = true;
    }
}
