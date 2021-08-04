using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueConversation
{
    public List<DialogueNode> conversationNodes;
}

[System.Serializable]
public class DialogueNode
{
    public string nodeText;
}