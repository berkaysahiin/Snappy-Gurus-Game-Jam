using System;
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
    [SerializeField] private GameObject _puzzleContainer;
    [SerializeField] private GameObject _showcaseButton;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float timeBetweenLetters;

    [SerializeField] private GameObject word_1_solution;
    private readonly int word_1_solution_last_index = 3;

    private int buttonIndex;
    private int _wordIndex;
    private string word;
    private static readonly string[] Words = new[] { "SXWP", "AXIPL", "CUNXQS", "AIONMSA" };

    private void Start()
    {
        _showcaseButton.SetActive(false);
        _puzzleContainer.SetActive(false);
        word_1_solution.SetActive(false);    
    }

    public void StartPuzzle()
    {
        _puzzleContainer.SetActive(true);
        WORD_1_Showcase();
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            if (buttonIndex == word_1_solution_last_index)
            {
                Debug.Log("weldone");                
            }
            else
            {
                buttonIndex += 1;
            }
        }
    }

    private void WORD_1_Showcase()
    {
        _showcaseButton.SetActive(true);
        _text.text = "";
        _wordIndex = 0;
        
        Sequence _sequence = DOTween.Sequence();
        
        _sequence.AppendCallback(ShowcaseLetter);
        _sequence.AppendInterval(timeBetweenLetters);

        _sequence.AppendCallback(ShowcaseLetter);
        _sequence.AppendInterval(timeBetweenLetters);

        _sequence.AppendCallback(ShowcaseLetter);
        _sequence.AppendInterval(timeBetweenLetters);

        _sequence.AppendCallback(ShowcaseLetter);
        _sequence.AppendInterval(timeBetweenLetters);
        
        _sequence.PlayForward();

        _sequence.onComplete = EndShowCase;

        _text.text = "";
    }

    private void ShowcaseLetter()
    {
        _text.text = Words[0][_wordIndex].ToString();
        _wordIndex += 1;
    }

    private void EndShowCase()
    {
        _showcaseButton.SetActive(false);
        word_1_solution.SetActive(true);
    }

   
}