using UnityEngine;

public class GameplayController : MonoBehaviour
{
	public BlockController BlockController;
	public RecordController RecordController;
	public TopUI TopUI;
	public StartMenuWindow StartMenuWindow;
	public TopMenuWindow TopMenuWindow;
	public EndGameWindow EndGameWindow;

	[HideInInspector]
	public int GameTime = 3;

	private void Awake()
	{
		HideWindows();
		SubscribeEvent();
		OpenStartMenu();
	}
	private void StartPlay()
	{
		ResetGame();
		HideWindows();
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
				Time.timeScale = 1;
				break;
			case false:
				Time.timeScale = 0;
				break;
		}
	}

	private void ContinuePlay()
	{
		HideWindows();
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
		HideWindows();

		EndGameWindow.SetFinalScore(TopUI.Score.GetScore());
		EndGameWindow.SetResult(RecordController.IsNewRecord());
		EndGameWindow.Show();

		BlockController.ResetBlocks();
	}
	private void QuitGame()
	{
		UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
	}
	private void OpenStartMenu()
	{
		HideWindows();
		StartMenuWindow.Show();
	}
	private void OpenTopMenu()
	{
		SwitchTimeScale(false);
		HideWindows();
		TopUI.Show();
		TopMenuWindow.Show();
	}
	private void OpenRecords()
	{
		HideWindows();
		RecordController.Show();
	}
	private void HideWindows()
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
		TopUI.Score.SetScore(BlockController.TowerBlockList);
	}

	private void SubscribeEvent()
	{
		StartMenuWindow.ClickStartButtonEvent += StartPlay;
		StartMenuWindow.ClickRecordsButtonEvent += OpenRecords;
		StartMenuWindow.ClickQuitButtonEvent += QuitGame;

		BlockController.CheckNewScore += SetScore;

		TopUI.ClickMenuButtonEvent += OpenTopMenu;
		TopUI.Timer.TimeEndEvent += EndGame;

		TopMenuWindow.ClickContinueButtonEvent += ContinuePlay;
		TopMenuWindow.ClickRestartButtonEvent += StartPlay;
		TopMenuWindow.ClickQuitButtonEvent += QuitGame;

		RecordController.ClickCloseButtonEvent += OpenStartMenu;

		EndGameWindow.ClickCloseButtonEvent += OpenStartMenu;
	}
}
