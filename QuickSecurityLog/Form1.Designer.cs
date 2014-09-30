/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Media;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace QuickSecurityLog
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Font = new System.Drawing.Font("Calibri", 10F);
			this.textBox1.Location = new System.Drawing.Point(13, 13);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(550, 24);
			this.textBox1.TabIndex = 0;
			this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEntryKeys);
            //
            // textBox3
            //
            this.textBox3.Font = new System.Drawing.Font("Calibri", 10F);
            this.textBox3.Location = new System.Drawing.Point(565, 13);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(30, 24);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "MB";
			// 
			// checkBox1
			// 

			 this.checkBox1.AutoSize = true;
			 this.checkBox1.Location = new System.Drawing.Point(713, 15);
			 this.checkBox1.Name = "checkBox1";
			 this.checkBox1.Size = new System.Drawing.Size(74, 17);
			 this.checkBox1.TabIndex = 1;
			 this.checkBox1.Text = "Point?";
		     this.checkBox1.UseVisualStyleBackColor = true;

            //
            // checkBox2
            //
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(773, 15);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(74, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Penalty?";
            this.checkBox2.UseVisualStyleBackColor = true;

			// 
			// textBox2
			// 
			this.textBox2.Font = new System.Drawing.Font("Calibri", 12F);
			this.textBox2.Location = new System.Drawing.Point(13, 40);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox2.Size = new System.Drawing.Size(814, 194);
			this.textBox2.TabIndex = 2;
			this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextFieldKeys);
            

			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Windows XP",
            "Windows 7",
            "Server 2003",
            "Server 2008",
            "Server 2012",
            "Ubuntu",
            "Fedora",});
			this.comboBox1.Location = new System.Drawing.Point(619, 13);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(88, 21);
			this.comboBox1.TabIndex = 3;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 247);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(839, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(117, 17);
			this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(839, 269);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox3);
			this.Name = "Form1";
			this.Text = "QSL";
			this.Load += new System.EventHandler(this.SetupDefaults);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
			this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
		}

		void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				SaveThread.Abort();
				downloadThread.Abort();
			} catch (Exception)
			{
			}
		}

		#endregion

		void SaveRoutine()
		{
			if (path == "")
			{
				Thread.CurrentThread.Abort();
			}
			if (File.Exists(path))
			{
				File.Delete(path);
			}
			TextWriter tw = new StreamWriter(path);
			tw.Write(textBox2.Text);
			tw.Close();
			SetStatus("Last saved at " + System.DateTime.Now);
			Thread.Sleep(15000);
			SaveRoutine();
		}

		void DownloadResources()
		{
			savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/qsl/";
			if (!Directory.Exists(savePath))
			{
				Directory.CreateDirectory(savePath);
			}

			if (!File.Exists(savePath + "coin.wav"))
			{
				WebClient webClient = new WebClient();
				webClient.DownloadFileAsync(new Uri("http://dl.dropbox.com/u/1253613/SuperMarioBrothers-Coin.wav"), savePath + "coin.wav");
				webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
			} else
			{
				canPlaySound = true;
			}
		}

		void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			SetStatus("Downloaded resources successfully.");
			canPlaySound = true;
		}

		void SetStatus(string str)
		{
			if (this.InvokeRequired)
			{
				this.BeginInvoke(new Action<string>(SetStatus), str);
				return;
			}
			this.toolStripStatusLabel1.Text = str;
		}

		void SetupDefaults(object sender, EventArgs eventArgs)
		{
			this.comboBox1.SelectedIndex = 0;
			this.Text = "QSL @ Windows XP";
			SelectOutputFile();
			downloadThread = new Thread(DownloadResources);
			downloadThread.Start();
			soundEpoch = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000)/10000000;
		}

		void ReadRoutine()
		{
			if (File.Exists(path))
			{
				TextReader tr = new StreamReader(path);
				textBox2.Text = tr.ReadToEnd();
				tr.Close();
			} else
			{
				textBox2.Text = "Started QSL at " + System.DateTime.Now + "\r\n";
			}
		}

		void SelectOutputFile()
		{
			SaveFileDialog sd = new SaveFileDialog();
			sd.Filter = "Text File|*.txt";
			sd.Title = "Save an log...";
			sd.ShowDialog();

			path = sd.FileName;
			if (path.Trim().Length == 0)
			{
				SelectOutputFile();
			}
			ReadRoutine();
			SaveThread = new Thread(SaveRoutine);
			SaveThread.Start();
		}

		void SelectedIndexChanged(object sender, EventArgs eventArgs)
		{
			this.Text = "QSL @ " + comboBox1.SelectedItem;
		}

		void TextFieldKeys(object sender, KeyPressEventArgs keyPressEventArgs)
		{
			keyPressEventArgs.Handled = true;
		}
 
            
		void CheckEntryKeys(object sender, KeyPressEventArgs keyPressEventArgs)
		{
			if (keyPressEventArgs.KeyChar == (char)Keys.Enter)
			{
                string temp = "[" + textBox3.Text + " " + System.DateTime.Now + " | " + comboBox1.SelectedItem + "]: " + textBox1.Text;
				if (textBox1.Text.Trim() == "")
				{
					keyPressEventArgs.Handled = true;
					return;
				}
				if (checkBox1.Checked)
				{
					temp = "{Point Get} " + temp;
					if (canPlaySound)
					{
						if (soundEpoch + 100 < getCurrentEpoch())
						{
							SoundPlayer soundPlayer = new SoundPlayer(savePath + "coin.wav");
							soundPlayer.Play();
						} else
						{
							toolStripStatusLabel1.Text = "Not playing sound because the cooldown is in effect.";
						}
					}
				}
                if (checkBox1.Checked)
                {
                    temp = "{Point Loss :(} " + temp;
                }
				textBox1.Text = "";
				if (textBox2.Text.Trim() == "")
				{
					textBox2.Text = temp;
				}
				else
				{
					textBox2.Text += "\r\n" + temp;
				}
				textBox2.SelectionStart = textBox2.TextLength;
				textBox2.ScrollToCaret();
				keyPressEventArgs.Handled = true;
			}
		}

		private long soundEpoch = 0;
		private Thread SaveThread;
		private string path = "";
		private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.TextBox textBox2;
		private ComboBox comboBox1;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel toolStripStatusLabel1;
		private bool canPlaySound = false;
		private string savePath;
		private Thread downloadThread;
	}
}

