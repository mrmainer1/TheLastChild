using Ink.Runtime;
using UnityEngine;
public abstract class Npc : MonoBehaviour , ITalk
{
    [SerializeField] protected TextAsset _inkJSON;
    [SerializeField] protected DialogueController _dialogueController;
    [SerializeField] protected GameObject _textInteract;
    public AudioClip[] Voice;
    
    protected bool _canStartDialogue;
    protected Story _story;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _textInteract.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _canStartDialogue = true;
            _textInteract.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _canStartDialogue = false;
            _textInteract.SetActive(false);
        }
    }
    private void Update()
    {
        if (_canStartDialogue)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Talk();
            }
        }
    }
    
    public abstract void ChangeInkVariableInUnity(string nameVariable, bool value);
    
    public void PlaySound(string nameClip)
    {
        foreach (AudioClip clip in Voice)
        {
            if (clip.name == nameClip)
            {
                _audioSource.PlayOneShot(clip);
                return;
            }
        }
        
        Debug.Log("Не удалось найти аудиоклип с названием " + nameClip);
    }

    protected void Talk()
    {
        _story = new Story(_inkJSON.text);
        SetInkVariable();
        StartDialog();
    }

    protected void StartDialog()
    {
        _dialogueController.EnterDialogueMode(_story, this);
        _canStartDialogue = false;
        _textInteract.SetActive(false);
    }

    protected abstract void SetInkVariable();
}
