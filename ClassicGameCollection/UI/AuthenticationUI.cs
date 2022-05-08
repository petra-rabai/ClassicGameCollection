using ClassicGameCollection.ScreenSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicGameCollection.UI
{
	public class AuthenticationUI
	{
		private readonly IScreen _screen;
		private readonly string _title = UIResources.AuthenticationScreenTitle;

		public AuthenticationUI(IScreen screen)
		{
			_screen = screen;
		}

		public void Initialize()
		{
			TitleUI(_title);
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

		private void ButtonsUI()
		{
			Console.WriteLine("\n");
			Console.WriteLine("\t*********" + "\t\t***************" + "\t\t\t*********");
			Console.WriteLine("\t* L key *" + "\t\t*    R key     *" + "\t\t\t* E key *");
			Console.WriteLine("\t* LOGIN *" + "\t\t* REGISTRATION *" + "\t\t\t* EXIT  *");
			Console.WriteLine("\t*********" + "\t\t***************" + "\t\t\t*********");
			Console.WriteLine("\n");
		}
	}
}
