using ClassicGameCollection.ScreenSetup;
using ClassicGameCollection.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicGameCollection
{
	public class Application : IApplication
	{
		private readonly IMainScreenUI _mainScreenUI;

		public Application(IMainScreenUI mainScreenUI)
		{
			_mainScreenUI = mainScreenUI;
		}


		public void Run()
		{
			_mainScreenUI.Initialize();
		}


	}
}
