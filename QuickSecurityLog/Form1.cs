using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickSecurityLog
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private long getCurrentEpoch()
		{
			return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000)/10000000;
		}
	}
}
