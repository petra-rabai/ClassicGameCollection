using ClassicGameCollection.ScreenSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassicGameCollection.UI
{
	public class MainScreenUI : IMainScreenUI
	{
		private readonly IScreen _screen;

		private readonly string _title = UIResources.MainScreenTitle;
		private readonly string _description = UIResources.MainScreenDescription;


		public MainScreenUI(IScreen screen)
		{
			_screen = screen;
		}

		public void Initialize()
		{
			_screen.Setup();
			_screen.Loading();
			TitleUI(_title);
			DescriptionUI(_description);
			ButtonsUI();
			_screen.WaitForUserInput();
		}

		private void TitleUI(string title)
		{
			_screen.Clear();
			Console.WriteLine("\n");
			Console.WriteLine("\t*****************************************************************");
			Console.WriteLine("\t*                                                               *");
			Console.WriteLine("\t******************                       ************************");
			Console.WriteLine("\t*                                                               *");
			Console.WriteLine("\t****************** " + title + " **********************");
			Console.WriteLine("\t*                                                               *");
			Console.WriteLine("\t******************                       ************************");
			Console.WriteLine("\t*                                                               *");
			Console.WriteLine("\t*****************************************************************");
		}

		private void DescriptionUI(string description)
		{
			Console.WriteLine("\n");
			Console.WriteLine("\t*****************************************************************");
			Console.WriteLine("\n");
			Console.WriteLine("\t******* " + description + " ****");
			Console.WriteLine("\n");
			Console.WriteLine("\t*****************************************************************");
		}

		private void ButtonsUI()
		{
			Console.WriteLine("\n");
			Console.WriteLine("\t*********" + "\t\t***************" + "\t\t\t*********");
			Console.WriteLine("\t* S key *" + "\t\t*    M key    *" + "\t\t\t* E key *");
			Console.WriteLine("\t* START *" + "\t\t* MAINTENANCE *" + "\t\t\t* EXIT  *");
			Console.WriteLine("\t*********" + "\t\t***************" + "\t\t\t*********");
			Console.WriteLine("\n");
		}
	}
}
