using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuickSecurityLog
{
	static class Program
	{
		private static Form1 form;
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(form = new Form1());

			
		}
	}
}
