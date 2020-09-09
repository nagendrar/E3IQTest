using Syn.Bot.Oscova;
using Syn.Bot.Oscova.Attributes;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message
{
    public string Text;
    public Text TextObject;
    public MessageType MessageType;
}

public enum MessageType
{
    User, Bot
}

public class BotDialog : Dialog
{
    [Expression("Hi")]
    public void Hello(Context context, Result result)
    {
        result.SendResponse("Hi!");
    }
    [Expression("Hello Bot")]
    public void Hi(Context context, Result result)
    {
        result.SendResponse("Hello User!");
    }

    [Expression("How are you?")]
    public void How(Context context, Result result)
    {
        result.SendResponse("I am good, How are you?");
    }

    [Expression("What")]
    public void What(Context context, Result result)
    {
        result.SendResponse("I am waiting, what can I do for you");
    }
}

public class Chatbotmanager : MonoBehaviour
{
    OscovaBot MainBot;

    public GameObject chatPanel, textObject;
    public InputField chatBox;

    public Color UserColor, BotColor;

    List<Message> Messages = new List<Message>();

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            MainBot = new OscovaBot();
            OscovaBot.Logger.LogReceived += (s, o) =>
            {
                Debug.Log($"OscovaBot: {o.Log}");
            };

            MainBot.Dialogs.Add(new BotDialog());
            //MainBot.Dialogs.
            //MainBot.ImportWorkspace("Assets/bot-kb.west");
            MainBot.Trainer.StartTraining();

            MainBot.MainUser.ResponseReceived += (sender, evt) =>
            {
                AddMessage($"Bot: {evt.Response.Text}", MessageType.Bot);
            };
        }
        catch (Exception ex)
        {
            Debug.LogError(ex);
        }
    }

    public void AddMessage(string messageText, MessageType messageType)
    {
        if (Messages.Count >= 25)
        {
            //Remove when too much.
            Destroy(Messages[0].TextObject.gameObject);
            Messages.Remove(Messages[0]);
        }

        var newMessage = new Message { Text = messageText };

        var newText = Instantiate(textObject, chatPanel.transform);

        newMessage.TextObject = newText.GetComponent<Text>();
        newMessage.TextObject.text = messageText;
        newMessage.TextObject.alignment = messageType == MessageType.User ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft;
        newMessage.TextObject.color = messageType == MessageType.User ? UserColor : BotColor;

        Messages.Add(newMessage);

        //if(chatPanel.transform.position.y > 200)
        //chatPanel.transform.position = new Vector3(chatPanel.transform.position.x, chatPanel.transform.position.y + 400, chatPanel.transform.position.z);
    }

    public void SendMessageToBot()
    {
        var userMessage = chatBox.text;

        if (!string.IsNullOrEmpty(userMessage))
        {
            Debug.Log($"OscovaBot:[USER] {userMessage}");
            AddMessage($"User: {userMessage}", MessageType.User);
            var request = MainBot.MainUser.CreateRequest(userMessage);
            var evaluationResult = MainBot.Evaluate(request);
            evaluationResult.Invoke();

            chatBox.Select();
            chatBox.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendMessageToBot();
        }
    }
}