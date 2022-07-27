using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UITextTypeWriter : MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;
    [SerializeField] AudioSource _typingSound;

    public string[] stringArray;

    [SerializeField] float timeBtwnChars;
    [SerializeField] float timeBtwnWords;

    public UnityEvent FinishedTextEvent;

    int i = 0;


    private void Awake()
    {

        _textMeshPro = GetComponent<TextMeshProUGUI>();

    }

    void Start()
    {
        EndCheck();
    }

    public void EndCheck()
    {
        if (i <= stringArray.Length - 1)
        {
            _textMeshPro.text = stringArray[i];
            StartCoroutine(TextVisible());
        }
    }

    private IEnumerator TextVisible()
    {
        _textMeshPro.ForceMeshUpdate();
        int totalVisibleCharacters = _textMeshPro.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            if (_typingSound != null && counter != 0) _typingSound.Play(0);

            int visibleCount = counter % (totalVisibleCharacters + 1);
            _textMeshPro.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                i += 1;
                Invoke("EndCheck", timeBtwnWords);
                break;
            }

            counter += 1;
            yield return new WaitForSeconds(timeBtwnChars);

        }

        if (i == stringArray.Length - 1) StartCoroutine(DelayFinishedTextEvent());
    }


    private IEnumerator DelayFinishedTextEvent()
    {
        yield return new WaitForSeconds(3);
        FinishedTextEvent.Invoke();
        
    }
}