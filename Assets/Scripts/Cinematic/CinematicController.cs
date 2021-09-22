using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicController : MonoBehaviour
{
    public event System.Action onStopCinematic;
    public event System.Action onPlayCinematic;
    public event System.Action onPlayLastCinematic;
    public bool IsPlayingCinematic => isPlayingCinematic;
    [SerializeField] List<CinematicBehaviour> cinematicBehaviours;
    [SerializeField] List<Conversation> conversations;
    int currentCinematic;
    DialogDisplay dialogDisplay;
    bool isPlayingCinematic;
    MoveEnemyAndPlayerInCinematic moveEnemyAndPlayerInCinematic;

    private void Awake()
    {
        dialogDisplay = FindObjectOfType<DialogDisplay>();
        moveEnemyAndPlayerInCinematic = GetComponent<MoveEnemyAndPlayerInCinematic>();
    }

    private void OnEnable()
    {
        dialogDisplay.onConversationFinished += OnConversationFinished;
    }

    private void OnDisable()
    {
        dialogDisplay.onConversationFinished -= OnConversationFinished;
    }

    private void OnConversationFinished()
    {
        OnStopCinematic();
        cinematicBehaviours[currentCinematic - 1].enabled = false;
    }

    private void Start()
    {
        PlayCinematic();
    }

    public void PlayCinematic()
    {
        cinematicBehaviours[currentCinematic].SetNewConversation(conversations[currentCinematic]);
        cinematicBehaviours[currentCinematic].BeginCinematicBehaviour();
        OnPlayCinematic();
    }

    void OnStopCinematic()
    {
        isPlayingCinematic = false;
        onStopCinematic?.Invoke();
    }

    void OnPlayCinematic()
    {
        isPlayingCinematic = true;
        onPlayCinematic?.Invoke();
        currentCinematic++;
        if (currentCinematic >= cinematicBehaviours.Count)
            onPlayLastCinematic?.Invoke();
    }

    public void ActivateMoveEnemyAndPlayerCinematicComponent()
    {
        moveEnemyAndPlayerInCinematic.enabled = true;
    }
}
