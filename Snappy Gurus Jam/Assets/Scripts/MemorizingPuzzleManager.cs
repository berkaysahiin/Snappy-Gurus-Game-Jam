using System;
using DG.Tweening;
using JetBrains.Annotations;
using SB;
using SG;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MemorizingPuzzleManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenLetters;
    [SerializeField] private float allowedAnswerTime;
    [SerializeField] private GameObject startButton; 
    [SerializeField] private GameObject[] Solutions;
    [SerializeField] private GameObject _puzzleContainer;
    [SerializeField] private GameObject _showcaseButton;
    [SerializeField] private TextMeshProUGUI _text;

    private NPCController _npc;

    private bool _lose = false;
    
    private int buttonIndex;
    private int _letterIndex;
    private int _wordIndex;
    private string word;
    private string endWord = "ignrc =>";
    private static readonly string[] Words = new[] { "SXWP", "AXIPL", "CUNXQS", "AIONMSY" };

    public ComputerScreenCamController playerCamera;
    
    private void Awake()
    {
        _npc = FindObjectOfType<NPCController>();
    }

    private void Start()
    {
        _showcaseButton.SetActive(false);
        _puzzleContainer.SetActive(false);

        foreach(var solution in Solutions)
        {
            solution.SetActive(false);
        }
    } 

    private void Update()
    {
        if (_lose)
        {
            playerCamera.transform.Rotate(Vector3.up * Time.deltaTime * 60);
        }
    }

    public void StartPuzzle()
    {
        startButton.SetActive(false);
        _puzzleContainer.SetActive(true);
        WordShowcase();
    }

    public void EndPuzzle()
    {
        _puzzleContainer.SetActive(false);
    }
    
    public void CheckButtonIndex()
    {
        var button = EventSystem.current.currentSelectedGameObject;
        AudioManager.Instance.PlayEffect(2);
        
        if (buttonIndex.ToString() != button.name)
        {
            button.GetComponent<Image>().color = Color.red;
            _lose = true;
            _npc.CatchCondition(2);
        }
        else
        {
            if (buttonIndex == Words[_wordIndex - 1].Length - 1)
            {
                Solutions[_wordIndex - 1].SetActive(false);
                buttonIndex = 0;
                if(!(_wordIndex > Words.Length - 1)) 
                {
                    WordShowcase();  
                }
                else
                {
                    ShowEndText();
                }
                                
            }
            else
            {
                button.GetComponent<Image>().color = Color.green;
                buttonIndex += 1;
            }
        }
    }

    private void WordShowcase()
    {
        _showcaseButton.SetActive(true);
        _text.text = "";
        _letterIndex = 0;
        word = Words[_wordIndex];
        
        Sequence _sequence = DOTween.Sequence();
        _sequence.AppendCallback(ShowcaseStartText);
        _sequence.AppendInterval(timeBetweenLetters);

        for(int i=0; i<word.Length; i++) 
        {
            _sequence.AppendCallback(ShowcaseLetter);
            _sequence.AppendInterval(timeBetweenLetters);
        }
        
        _sequence.PlayForward();

        _sequence.onComplete = EndShowCase;

        _text.text = "";
    }

    private void ShowcaseLetter()
    {
        _text.text = Words[_wordIndex][_letterIndex].ToString();
        _letterIndex += 1;
    }

    private void EndShowCase()
    {
        Solutions[_wordIndex].SetActive(true);
        _wordIndex += 1;
        _showcaseButton.SetActive(false);
    }

    private void ReloadScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ShowcaseStartText() 
    {
        _text.text = "Memorize";
    }

    private void ShowEndText()
    {
        _showcaseButton.SetActive(true);
        _text.text = endWord;
    }
}