using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public BlockController BlockController;
    public TopUI TopUI;
    public StartMenuWindow StartMenuWindow;
    public RecordsWindow RecordsWindow;
    public TopMenuWindow TopMenuWindow;
    public EndGameWindow EndGameWindow;
    public int GameTime = 3;

    private void Awake()
    {
        Time.timeScale = 0;
        Hide();
        OpenStartMenu();
    }
    private void StartPlay()
    {
        Hide();
        TopUI.Show();
        BlockController.GenerateBlock();
        BlockController.CheckNewScore += SetScore;
        TopUI.OnClickMenuButtonEvent += OpenTopMenu;
        TopUI.Timer.TimeEndEvent += EndGame;
        Time.timeScale = 1;
        TopUI.SetTimerTime(GameTime);
    }
    private void RestartPlay()
    {
        ResetGame();
        StartPlay();
    }
    private void PausePlay()
    {
        Time.timeScale = 0;
    }
    private void ContinuePlay()
    {
        Hide();
        Time.timeScale = 1;
        TopUI.Show();
        TopUI.SetTimerTime(GameTime);
    }
    private void ResetGame()
    {
        BlockController.ResetBlocks();
        TopUI.ResetTimerTime();
        TopUI.ScoreNumber = 0;
    }
    private void EndGame()
    {
        EndGameWindow.Show(TopUI.ScoreNumber);
        EndGameWindow.SetResult(false);
        EndGameWindow.OnClickCloseButtonEvent += OpenStartMenu;
    }
    private void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    private void OpenStartMenu()
    {
        Hide();
        StartMenuWindow.Show();
        StartMenuWindow.OnClickStartButtonEvent += StartPlay;
        StartMenuWindow.OnClickRecordsButtonEvent += OpenRecords;
        StartMenuWindow.OnClickQuitButtonEvent += QuitGame;
    }
    private void OpenTopMenu()
    {
        PausePlay();
        Hide();
        TopUI.Show();
        TopMenuWindow.Show();
        TopMenuWindow.OnClickContinueButtonEvent += ContinuePlay;
        TopMenuWindow.OnClickRestartButtonEvent += RestartPlay;
        TopMenuWindow.OnClickRecordsButtonEvent += OpenRecords;
        TopMenuWindow.OnClickQuitButtonEvent += QuitGame;
    }
    private void OpenRecords()
    {
        Hide();
        RecordsWindow.Show();
        RecordsWindow.OnClickCloseButtonEvent += OpenStartMenu;
    }
    private void Hide()
    {
        TopMenuWindow?.gameObject.SetActive(false);
        StartMenuWindow?.gameObject.SetActive(false);
        RecordsWindow?.gameObject.SetActive(false);
        EndGameWindow?.gameObject.SetActive(false);
        TopUI?.gameObject.SetActive(false);
    }
    public void OnTouchScreen()
    {
        BlockController.ThrowBlock();
    }
    private void SetScore()
    {
        TopUI.ScoreNumber = NumberGenerator.FindMaxNumberOfBlocks(BlockController.BlockList);
    }
}
