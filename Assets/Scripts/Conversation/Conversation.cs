using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    public Pilot SpeakerOne;
    public Pilot SpeakerTwo;
    public Line[] Lines;
}

[System.Serializable]
public struct Line
{
    public Pilot PilotGirl;

    [TextArea(2, 5)]
    public string PilotText;
}
