using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
	public BlockController BlockController;
	public RecordController RecordController;
	public TopUI TopUI;
	public StartMenuWindow StartMenuWindow;
	public TopMenuWindow TopMenuWindow;
	public EndGameWindow EndGameWindow;
	public int GameTime = 3;

	private void Awake()
	{
		Hide();
		OpenStartMenu();
		BlockController.CheckNewScore += SetScore;
		TopUI.OnClickMenuButtonEvent += OpenTopMenu;
		TopUI.Timer.TimeEndEvent += EndGame;
	}
	private void StartPlay()
	{
		ResetGame();
		Hide();
		TopUI.Show();

		BlockController.GenerateBlock();

		SwitchTimeScale(true);
		TopUI.Timer.SetTimer(GameTime);
	}

	private void SwitchTimeScale(bool DoTimeRun)
	{
		switch (DoTimeRun)
		{
			case true:
				Time.timeScale = 3;
				break;
			case false:
				Time.timeScale = 0;
				break;
		}
	}

	private void ContinuePlay()
	{
		Hide();
		SwitchTimeScale(true);
		TopUI.Show();
		TopUI.Timer.SetTimer(GameTime);
	}
	private void ResetGame()
	{
		BlockController.ResetBlocks();
		TopUI.Timer.ResetTimer(GameTime);
		TopUI.Score.ResetScore();
	}
	private void EndGame()
	{
		Hide();

		EndGameWindow.SetFinalScore(TopUI.Score.GetScore());
		EndGameWindow.Show();

		if (RecordController.IsNewRecord())
		{
			EndGameWindow.SetNewRecordText();
		}
		else
		{
			EndGameWindow.SetNoRecordText();
		}

		BlockController.ResetBlocks();

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
		SwitchTimeScale(false);
		Hide();
		TopUI.Show();
		TopMenuWindow.Show();
		TopMenuWindow.OnClickContinueButtonEvent += ContinuePlay;
		TopMenuWindow.OnClickRestartButtonEvent += StartPlay;
		TopMenuWindow.OnClickQuitButtonEvent += QuitGame;
	}
	private void OpenRecords()
	{
		Hide();
		RecordController.Show();
		RecordController.OnClickCloseButtonEvent += OpenStartMenu;
	}
	private void Hide()
	{
		SwitchTimeScale(false);
		TopMenuWindow?.gameObject.SetActive(false);
		StartMenuWindow?.gameObject.SetActive(false);
		RecordController?.gameObject.SetActive(false);
		EndGameWindow?.gameObject.SetActive(false);
		TopUI?.gameObject.SetActive(false);
	}
	public void OnTouchScreen()
	{
		BlockController.ThrowBlock();
	}
	private void SetScore()
	{
		TopUI.Score.SetScore(BlockController.BlockList);
	}
}
