using System.Collections;
using Ink.Runtime;
using UnityEngine;

[RequireComponent(typeof(DialogueWindow))]
public class DialogueController : MonoBehaviour
{
    [SerializeField] private Player player;
    private DialogueWindow _dialogueWindow; 
    private DialogueTag _dialogueTag;
    
    public Story CurrentStory { get; private set;}
    public ITalk Collocutor;
    private Coroutine _displayLineCoroutine;

    private void Start()
    {
        _dialogueWindow.SetActive(false);
    }

    private void Update()
    {
        if (_dialogueWindow.IsStatusAnswer == true ||
            _dialogueWindow.IsPlaying == false ||
            _dialogueWindow.CanContinueToNextLine == false)
        {
         return;   
        }

        if (Input.GetMouseButton(0))
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(Story story, ITalk collocutor)
    {
        Collocutor = collocutor;
        player.StopMove();
        
        CurrentStory = story;
        _dialogueWindow.SetActive(true);
        ContinueStory();
    }

    private void ContinueStory()
    {
        if (CurrentStory.canContinue == false)
        {
            StartCoroutine(ExitDialogueMode());
            return;
        }

        if (_displayLineCoroutine != null)
        {
            StopCoroutine(_displayLineCoroutine);
        }

        _displayLineCoroutine = StartCoroutine(_dialogueWindow.DisplayLine(CurrentStory));
        
        _dialogueTag.HandleTags(CurrentStory.currentTags);
    }

   
    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(_dialogueWindow.CooldownNewLetter);
        
        player.StartMove();
        _dialogueWindow.SetActive(false);
        _dialogueWindow.ClearText();
    }

    private void Awake()
    {
        _dialogueTag = GetComponent<DialogueTag>();
        _dialogueWindow = GetComponent<DialogueWindow>();
        
        _dialogueTag.Init();
        _dialogueWindow.Init();
    }

    public void MakeChoice(int choiceIndex)
    {
        _dialogueWindow.MakeChoice();
        CurrentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
}
