using ShellProgressBar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassicGameCollection.ScreenSetup
{
	public class Screen : IScreen
	{
		const int _progressBarTick = 10;

		[DllImport("kernel32.dll", ExactSpelling = true)]
		private static extern IntPtr GetConsoleWindow();

		private static readonly IntPtr _thisConsole = GetConsoleWindow();

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		private const int _maximize = 3;

		public void Setup()
		{
			Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
			ShowWindow(_thisConsole, _maximize);
		}

		public void Loading()
		{
			StartProgressBar();
		}

		private void StartProgressBar()
		{

			Console.CursorVisible = false;
			Console.SetCursorPosition(0, Console.LargestWindowHeight / 2);

			ProgressBarOptions progressBarOption = SetProgressBar();

			ProgressBar loadingProgressBar = new(_progressBarTick, "Initialize ...", progressBarOption);

			for (int i = 0; i < _progressBarTick; i++)
			{
				loadingProgressBar.Tick();
				Thread.Sleep(1000);
			}
		}

		private static ProgressBarOptions SetProgressBar()
		{
			ProgressBarOptions progressBarOption = new();
			progressBarOption.ProgressCharacter = '#';
			progressBarOption.ProgressBarOnBottom = true;
			progressBarOption.ForegroundColor = ConsoleColor.Yellow;
			progressBarOption.ForegroundColorDone = ConsoleColor.DarkGreen;
			progressBarOption.BackgroundColor = ConsoleColor.DarkGray;
			progressBarOption.BackgroundCharacter = '\u2593';
			return progressBarOption;
		}

		public void Clear()
		{
			Console.Clear();
		}

		public void WaitForUserInput()
		{
			while (FlashPrompt(" *** Wait for user input ... (Hit Enter to Continue)",
			TimeSpan.FromMilliseconds(500)) != ConsoleKey.Enter);
		}

		private static ConsoleKey FlashPrompt(string prompt, TimeSpan interval)
		{
			var cursorTop = Console.CursorTop;
			var colorOne = Console.ForegroundColor;
			var colorTwo = Console.BackgroundColor;

			var stopwatch = Stopwatch.StartNew();
			var lastValue = TimeSpan.Zero;

			Console.Write(prompt);

			while (!Console.KeyAvailable)
			{
				var currentValue = stopwatch.Elapsed;

				if (currentValue - lastValue < interval) continue;

				lastValue = currentValue;
				Console.ForegroundColor = Console.ForegroundColor == colorOne
					? colorTwo : colorOne;
				Console.BackgroundColor = Console.BackgroundColor == colorOne
					? colorTwo : colorOne;
				Console.SetCursorPosition(0, cursorTop);
				Console.CursorSize = 80;
				Console.Write(" " + prompt);
			}

			Console.ForegroundColor = colorOne;
			Console.BackgroundColor = colorTwo;

			return Console.ReadKey(true).Key;
		}

	}
}
