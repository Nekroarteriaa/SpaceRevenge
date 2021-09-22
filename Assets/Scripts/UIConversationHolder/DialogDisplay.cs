using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogDisplay : MonoBehaviour
{
    public event System.Action onConversationFinished;
    [SerializeField] Image commetBlock;
    [SerializeField] Image profilePortrait;
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] ImageTapHandler imageTap;
    [SerializeField] float dialogTimeRate;
    float nextDialogTime;


    Conversation conversation;
    Image portraitBackground;
    Image girlPortrait;
    int currentLine;
    bool isShowingDialog;

    private void Awake()
    {
        portraitBackground = profilePortrait.transform.GetChild(0).GetComponent<Image>();
        girlPortrait = profilePortrait.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        SetDialogObjectsState(false);
        dialogText.text = string.Empty;
    }

    private void OnEnable()
    {
        imageTap.onImagePressedDown += OnImagePressedDown;
    }

    private void OnDisable()
    {
        imageTap.onImagePressedDown -= OnImagePressedDown;
    }

    public void InjectConversation(Conversation conversation)
    {
        this.conversation = conversation;
        isShowingDialog = true;
        OnShowConversation(0);
    }

    private void OnImagePressedDown()
    {
        if (isShowingDialog)
        {
            if (currentLine < conversation.Lines.Length - 1 && CanShowNextDialog())
            {
                currentLine++;
                ShowDialog(currentLine);
            }
            else if (currentLine >= conversation.Lines.Length - 1 && CanShowNextDialog())
                OnConversationFinished();
        }
        else
            return;
        
    }

    private void OnShowConversation(int currentCinematic)
    {
        currentLine = currentCinematic;
        StartCoroutine(DoShowDialog());
    }

    private void OnConversationFinished()
    {
        isShowingDialog = false;
        StartCoroutine(DoHideDialog());
    }

   

    void ShowDialog(int dialogLine)
    {
        girlPortrait.sprite = conversation.Lines[dialogLine].PilotGirl.GirlPortrait;
        dialogText.text = conversation.Lines[dialogLine].PilotText;
        SetNextDialogTime();
    }


    void SetDialogObjectsState(bool state)
    {        
        commetBlock.gameObject.SetActive(state);
        profilePortrait.gameObject.SetActive(state);
        imageTap.gameObject.SetActive(state);
    }
    private void ResetPortraitFillAmount()
    {
        profilePortrait.fillAmount = 0;
        portraitBackground.fillAmount = 0;
        girlPortrait.fillAmount = 0;
    }

    IEnumerator DoShowDialog()
    {
        ResetPortraitFillAmount();
        girlPortrait.sprite = conversation.Lines[currentLine].PilotGirl.GirlPortrait;
        yield return new WaitForSeconds(1f);
        SetDialogObjectsState(true);
        yield return StartCoroutine(DoFillAmountInterpolation(0, 1, 0.5f));
        ShowDialog(currentLine);

    }

    IEnumerator DoHideDialog()
    {
        yield return StartCoroutine(DoFillAmountInterpolation(1, 0, 1.5f));
        dialogText.text = string.Empty;
        ResetPortraitFillAmount();
        SetDialogObjectsState(false);
        currentLine = 0;
        onConversationFinished?.Invoke();

    }


    IEnumerator DoFillAmountInterpolation(float startFillValue, float finalFillValue, float desiredTime)
    {
        float elapsedTime = startFillValue;
        float percentageComplete = startFillValue;
        float fillAmount = startFillValue;
        while (profilePortrait.fillAmount != finalFillValue)
        {
            yield return null;
            elapsedTime += Time.deltaTime;
            percentageComplete = elapsedTime / desiredTime;
            fillAmount = Mathf.Lerp(fillAmount, finalFillValue, percentageComplete);

            profilePortrait.fillAmount = fillAmount;
            portraitBackground.fillAmount = fillAmount;
            girlPortrait.fillAmount = fillAmount;
        }
    }


    public bool CanShowNextDialog()
    {
        return Time.time >= nextDialogTime;
    }

  
    public void SetNextDialogTime()
    {
        nextDialogTime = Time.time + dialogTimeRate;
    }
}
