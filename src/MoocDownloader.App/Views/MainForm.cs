﻿using System;
using MoocDownloader.App.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MoocDownloader.App.Requests;

namespace MoocDownloader.App.Views
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Cookies of after logging in to icourse163.org
        /// </summary>
        private readonly List<CookieModel> _cookies = new List<CookieModel>();

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Login icourse163.org.
        /// </summary>
        private void LoginMoocButton_Click(object sender, System.EventArgs e)
        {
            var form   = new LoginForm(_cookies);
            var result = form.ShowDialog();

            switch (result)
            {
                case DialogResult.OK:
                {
                    if (_cookies.Any())
                    {
                        Log($@"已收集到登录信息.");
                    }

                    break;
                }
                case DialogResult.Cancel:
                    Log(@"已取消登录.");
                    break;
            }
        }

        /// <summary>
        /// Find save file path.
        /// </summary>
        private void FindPathButton_Click(object sender, System.EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                SavePathTextBox.Text = dialog.SelectedPath;
                Log($@"已设置保存路径为 {SavePathTextBox.Text}.");
            }
        }

        /// <summary>
        /// Write log.
        /// </summary>
        /// <param name="message">log message.</param>
        private void Log(string message)
        {
            RunningLogListBox.Items.Add(message);
        }

        /// <summary>
        /// Start download.
        /// </summary>
        private void StartDownloadButton_Click(object sender, System.EventArgs e)
        {
            const string courseUrl = "https://www.icourse163.org/course/ECNU-1002842004";

            // 1. initializes a mooc request.
            var mooc = new MoocRequest(_cookies, courseUrl);

            //var termId = mooc.GetTermId();

            //var dto = mooc.GetMocTermJavaScriptCode(termId, "ECNU-1002842004", _cookies);

            //var index = dto.IndexOf("dwr.engine._remoteHandleCallback", StringComparison.Ordinal);

            //var code = dto.Substring(0, index);
        }
    }
}