using UnityEngine;

public class GameplayController : MonoBehaviour
{
	[SerializeField] private BlockController _blockController;
	[SerializeField] private GroundController _groundController;
	[SerializeField] private RecordController _recordController;
	[SerializeField] private Timer _timer;
	[SerializeField] private TopBar _topBar;
	[SerializeField] private StartMenuWindow _startMenuWindow;
	[SerializeField] private RecordWindow _recordWindow;
	[SerializeField] private TopMenuWindow _topMenuWindow;
	[SerializeField] private EndGameWindow _endGameWindow;

	public int GameDurationInMinutes = 1;

	private void Awake()
	{
		HideWindows();
		SubscribeEvent();
		ShowStartMenu();
	}

	private void StartPlay()
	{
		ResetGame();
		HideWindows();
		_topBar.Show();

		_blockController.GenerateBlock();
		RunTime();
		StartTimer();
	}

	private void ContinuePlay()
	{
		HideWindows();
		RunTime();
		_topBar.Show();
		StartTimer();
	}

	private void ResetGame()
	{
		_blockController.ResetBlocks();
		_groundController.ResetGroundPosition();
		ResetTimer();
		ResetScore();
	}

	private void EndGame()
	{
		HideWindows();

		_endGameWindow.SetFinalScore(Score.GetScore());
		_endGameWindow.SetResult(_recordController.IsNewRecord());
		_endGameWindow.Show();

		_blockController.ResetBlocks();
		_groundController.ResetGroundPosition();
	}

	private void QuitGame()
	{
		UnityEditor.EditorApplication.isPlaying = false;
		Application.Quit();
	}

	private void ShowStartMenu()
	{
		HideWindows();
		_startMenuWindow.Show();
	}

	private void ShowTopMenu()
	{
		PauseTime();
		HideWindows();
		_topBar.Show();
		_topMenuWindow.Show();
	}

	private void ShowRecords()
	{
		HideWindows();
		_recordWindow.Show();
	}

	private void HideWindows()
	{
		PauseTime();

		_topMenuWindow.Hide();
		_startMenuWindow.Hide();
		_recordWindow.Hide();
		_endGameWindow.Hide();
		_topBar.Hide();
	}

	public void OnTouchScreen()
	{
		_blockController.DropBlock();
	}

	private void PauseTime()
	{
		Time.timeScale = 0;
	}

	private void RunTime()
	{
		Time.timeScale = 1.2f;
	}

	private void StartTimer()
	{
		_timer.RunTimer(GameDurationInMinutes);
	}

	private void UpdateTimer()
	{
		_topBar.SetTime(_timer.Minutes, _timer.Seconds);
	}

	private void ResetTimer()
	{
		_timer.ResetTimer(GameDurationInMinutes);
	}

	private void SetScore()
	{
		int score = BlockNumberCalculator.FindMaxBlockNumber(_blockController.BlockList);
		Score.SetScore(score);
		_topBar.SetScore();
	}

	private void ResetScore()
	{
		Score.ResetScore();
		_topBar.SetScore();
	}

	private void SubscribeEvent()
	{
		_timer.UpdateTimeEvent += UpdateTimer;
		_timer.TimeEndEvent += EndGame;

		_startMenuWindow.ClickStartButtonEvent += StartPlay;
		_startMenuWindow.ClickRecordsButtonEvent += ShowRecords;
		_startMenuWindow.ClickQuitButtonEvent += QuitGame;

		_blockController.UpdateScore += SetScore;

		_topBar.ClickMenuButtonEvent += ShowTopMenu;

		_topMenuWindow.ClickContinueButtonEvent += ContinuePlay;
		_topMenuWindow.ClickRestartButtonEvent += StartPlay;
		_topMenuWindow.ClickQuitButtonEvent += QuitGame;

		_recordWindow.ClickCloseButtonEvent += ShowStartMenu;

		_endGameWindow.ClickCloseButtonEvent += ShowStartMenu;
	}
}
