﻿using System;
using DG.Tweening;
using JetBrains.Annotations;
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

    private int buttonIndex;
    private int _letterIndex;
    private int _wordIndex;
    private string word;
    private string endWord = "Behind";
    private static readonly string[] Words = new[] { "SXWP", "AXIPL", "CUNXQS", "AIONMSY" };

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
        print("button index: " + buttonIndex);
        print("word index: " + _wordIndex);
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

        if (buttonIndex.ToString() != button.name)
        {
            ReloadScene();
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