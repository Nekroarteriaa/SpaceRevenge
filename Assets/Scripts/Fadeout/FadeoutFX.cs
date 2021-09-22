using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeoutFX : MonoBehaviour
{
    [SerializeField] float fadeOutTimer;
    [SerializeField] Image imageFadeOut;
    [SerializeField] TextMeshProUGUI thanksText;
    CinematicController cinematicController;
    SceneController sceneController;
    private void Awake()
    {
        cinematicController = FindObjectOfType<CinematicController>();
        sceneController = FindObjectOfType<SceneController>();
    }

    private void OnEnable()
    {
        cinematicController.onPlayLastCinematic += OnPlayLastCinematic;
    }

    private void OnDisable()
    {
        cinematicController.onPlayLastCinematic -= OnPlayLastCinematic;
    }

    private void OnPlayLastCinematic()
    {
        StartCoroutine(DoFadeOut());
    }

    IEnumerator DoFadeOut()
    {
        var elapsedTime = 0f;
        var percentageComplete = 0f;
        var newColor = new Color(0, 0, 0, 0);

        while (percentageComplete < 1f)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / fadeOutTimer;
            newColor.a = percentageComplete;
            imageFadeOut.color = newColor;
        }
        thanksText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        sceneController.OnMenuLoad();

    }
    
}
