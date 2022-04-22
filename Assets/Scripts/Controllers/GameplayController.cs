using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public BlockController BlockController;
    public MenuWindow MenuWindow;
    public RecordsWindow RecordsWindow;
    public TopUI TopUI;
    public GameObject Ground;

    private void Awake()
    {
        Hide();
        OpenMenu();
    }
    public void StartPlay()
    {
        Hide();
        TopUI.Show();
        Ground.SetActive(true);
        BlockController.GenerateBlock();
        BlockController.CheckNewScore += SetScore;
        TopUI.OnClickMenuButtonEvent += OpenMenu;
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void OpenMenu()
    {
        Hide();
        MenuWindow.Show();
        MenuWindow.OnClickStartButtonEvent += StartPlay;
        MenuWindow.OnClickRecordsButtonEvent += OpenRecords;
        MenuWindow.OnClickQuitButtonEvent += QuitGame;
    }
    public void OpenRecords()
    {
        Hide();
        RecordsWindow.Show();
        RecordsWindow.OnClickCloseButtonEvent += OpenMenu;
    }
    private void Hide()
    {
        Ground.SetActive(false);
        MenuWindow?.gameObject.SetActive(false);
        RecordsWindow?.gameObject.SetActive(false);
        TopUI?.gameObject.SetActive(false);
    }
    public void OnTouchScreen()
    {
        BlockController.ThrowBlock();
    }
    public void SetScore()
    {
        TopUI.ScoreNumber = NumberGenerator.FindMaxNumberOfBlocks(BlockController.BlockList);
    }
}
