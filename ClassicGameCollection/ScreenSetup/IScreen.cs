namespace ClassicGameCollection.ScreenSetup
{
	public interface IScreen
	{
		void Loading();
		void Setup();
		void Clear();
		void WaitForUserInput();
	}
}