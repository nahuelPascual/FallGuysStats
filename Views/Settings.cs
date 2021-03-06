﻿using System;
using System.IO;
using System.Windows.Forms;
namespace FallGuysStats {
    public partial class Settings : Form {
        public UserSettings CurrentSettings { get; set; }
        public Settings() {
            InitializeComponent();
        }
        private void Settings_Load(object sender, EventArgs e) {
            txtLogPath.Text = CurrentSettings.LogPath;
            chkCycleOverlayLongest.Checked = CurrentSettings.SwitchBetweenLongest;
            chkCycleOverlayQualify.Checked = CurrentSettings.SwitchBetweenQualify;
            txtCycleTimeSeconds.Text = CurrentSettings.CycleTimeSeconds.ToString();
            txtPreviousWins.Text = CurrentSettings.PreviousWins.ToString();
            chkUseNDI.Checked = CurrentSettings.UseNDI;
            chkOverlayOnTop.Checked = !CurrentSettings.OverlayNotOnTop;
            chkHideWinsInfo.Checked = CurrentSettings.HideWinsInfo;
            chkHideRoundInfo.Checked = CurrentSettings.HideRoundInfo;
            chkHideTimeInfo.Checked = CurrentSettings.HideTimeInfo;
            chkShowTabs.Checked = CurrentSettings.ShowOverlayTabs;
            chkAutoUpdate.Checked = CurrentSettings.AutoUpdate;
            chkFlipped.Checked = CurrentSettings.FlippedDisplay;

            switch (CurrentSettings.OverlayColor) {
                case 0: cboOverlayColor.SelectedItem = "Magenta"; break;
                case 1: cboOverlayColor.SelectedItem = "Blue"; break;
                case 2: cboOverlayColor.SelectedItem = "Red"; break;
                case 3: cboOverlayColor.SelectedItem = "Transparent"; break;
                case 4: cboOverlayColor.SelectedItem = "Black"; break;
                case 5: cboOverlayColor.SelectedItem = "Green"; break;
            }
            switch (CurrentSettings.WinsFilter) {
                case 0: cboWinsFilter.SelectedItem = "Stats and Party Filter"; break;
                case 1: cboWinsFilter.SelectedItem = "Season Stats"; break;
                case 2: cboWinsFilter.SelectedItem = "Week Stats"; break;
                case 3: cboWinsFilter.SelectedItem = "All Time Stats"; break;
                case 4: cboWinsFilter.SelectedItem = "Day Stats"; break;
                case 5: cboWinsFilter.SelectedItem = "Session Stats"; break;
            }
            switch (CurrentSettings.QualifyFilter) {
                case 0: cboQualifyFilter.SelectedItem = "All Time Stats"; break;
                case 1: cboQualifyFilter.SelectedItem = "Stats and Party Filter"; break;
                case 2: cboQualifyFilter.SelectedItem = "Season Stats"; break;
                case 3: cboQualifyFilter.SelectedItem = "Week Stats"; break;
                case 4: cboQualifyFilter.SelectedItem = "Day Stats"; break;
                case 5: cboQualifyFilter.SelectedItem = "Session Stats"; break;
            }
            switch (CurrentSettings.FastestFilter) {
                case 0: cboFastestFilter.SelectedItem = "All Time Stats"; break;
                case 1: cboFastestFilter.SelectedItem = "Stats and Party Filter"; break;
                case 2: cboFastestFilter.SelectedItem = "Season Stats"; break;
                case 3: cboFastestFilter.SelectedItem = "Week Stats"; break;
                case 4: cboFastestFilter.SelectedItem = "Day Stats"; break;
                case 5: cboFastestFilter.SelectedItem = "Session Stats"; break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            CurrentSettings.LogPath = txtLogPath.Text;

            if (string.IsNullOrEmpty(txtCycleTimeSeconds.Text)) {
                CurrentSettings.CycleTimeSeconds = 5;
            } else {
                CurrentSettings.CycleTimeSeconds = int.Parse(txtCycleTimeSeconds.Text);
                if (CurrentSettings.CycleTimeSeconds <= 0) {
                    CurrentSettings.CycleTimeSeconds = 5;
                }
            }

            if (string.IsNullOrEmpty(txtPreviousWins.Text)) {
                CurrentSettings.PreviousWins = 0;
            } else {
                CurrentSettings.PreviousWins = int.Parse(txtPreviousWins.Text);
                if (CurrentSettings.PreviousWins < 0) {
                    CurrentSettings.PreviousWins = 0;
                }
            }

            CurrentSettings.SwitchBetweenLongest = chkCycleOverlayLongest.Checked;
            CurrentSettings.SwitchBetweenQualify = chkCycleOverlayQualify.Checked;
            CurrentSettings.UseNDI = chkUseNDI.Checked;
            CurrentSettings.OverlayNotOnTop = !chkOverlayOnTop.Checked;
            if (chkHideRoundInfo.Checked && chkHideTimeInfo.Checked && chkHideWinsInfo.Checked) {
                chkHideWinsInfo.Checked = false;
            }
            bool resizeOverlay = CurrentSettings.HideWinsInfo != chkHideWinsInfo.Checked ||
                CurrentSettings.HideRoundInfo != chkHideRoundInfo.Checked ||
                CurrentSettings.HideTimeInfo != chkHideTimeInfo.Checked ||
                CurrentSettings.ShowOverlayTabs != chkShowTabs.Checked;
            CurrentSettings.HideWinsInfo = chkHideWinsInfo.Checked;
            CurrentSettings.HideRoundInfo = chkHideRoundInfo.Checked;
            CurrentSettings.HideTimeInfo = chkHideTimeInfo.Checked;
            CurrentSettings.ShowOverlayTabs = chkShowTabs.Checked;
            CurrentSettings.AutoUpdate = chkAutoUpdate.Checked;
            CurrentSettings.FlippedDisplay = chkFlipped.Checked;

            switch ((string)cboOverlayColor.SelectedItem) {
                case "Magenta": CurrentSettings.OverlayColor = 0; break;
                case "Blue": CurrentSettings.OverlayColor = 1; break;
                case "Red": CurrentSettings.OverlayColor = 2; break;
                case "Transparent": CurrentSettings.OverlayColor = 3; break;
                case "Black": CurrentSettings.OverlayColor = 4; break;
                case "Green": CurrentSettings.OverlayColor = 5; break;
            }
            switch ((string)cboWinsFilter.SelectedItem) {
                case "Stats and Party Filter": CurrentSettings.WinsFilter = 0; break;
                case "Season Stats": CurrentSettings.WinsFilter = 1; break;
                case "Week Stats": CurrentSettings.WinsFilter = 2; break;
                case "All Time Stats": CurrentSettings.WinsFilter = 3; break;
                case "Day Stats": CurrentSettings.WinsFilter = 4; break;
                case "Session Stats": CurrentSettings.WinsFilter = 5; break;
            }
            switch ((string)cboQualifyFilter.SelectedItem) {
                case "All Time Stats": CurrentSettings.QualifyFilter = 0; break;
                case "Stats and Party Filter": CurrentSettings.QualifyFilter = 1; break;
                case "Season Stats": CurrentSettings.QualifyFilter = 2; break;
                case "Week Stats": CurrentSettings.QualifyFilter = 3; break;
                case "Day Stats": CurrentSettings.QualifyFilter = 4; break;
                case "Session Stats": CurrentSettings.QualifyFilter = 5; break;
            }
            switch ((string)cboFastestFilter.SelectedItem) {
                case "All Time Stats": CurrentSettings.FastestFilter = 0; break;
                case "Stats and Party Filter": CurrentSettings.FastestFilter = 1; break;
                case "Season Stats": CurrentSettings.FastestFilter = 2; break;
                case "Week Stats": CurrentSettings.FastestFilter = 3; break;
                case "Day Stats": CurrentSettings.FastestFilter = 4; break;
                case "Session Stats": CurrentSettings.FastestFilter = 5; break;
            }

            if (resizeOverlay) {
                int overlaySetting = (CurrentSettings.HideWinsInfo ? 4 : 0) + (CurrentSettings.HideRoundInfo ? 2 : 0) + (CurrentSettings.HideTimeInfo ? 1 : 0);
                switch (overlaySetting) {
                    case 0: CurrentSettings.OverlayWidth = 786; break;
                    case 1: CurrentSettings.OverlayWidth = 786 - 225 - 6; break;
                    case 2: CurrentSettings.OverlayWidth = 786 - 281 - 6; break;
                    case 3: CurrentSettings.OverlayWidth = 786 - 281 - 225 - 12; break;
                    case 4: CurrentSettings.OverlayWidth = 786 - 238 - 6; break;
                    case 5: CurrentSettings.OverlayWidth = 786 - 238 - 225 - 12; break;
                    case 6: CurrentSettings.OverlayWidth = 786 - 238 - 281 - 12; break;
                }
                
                if (CurrentSettings.ShowOverlayTabs) {
                    CurrentSettings.OverlayHeight = 134;
                } else {
                    CurrentSettings.OverlayHeight = 99;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void txtCycleTimeSeconds_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            if (!string.IsNullOrEmpty(txtCycleTimeSeconds.Text) && !int.TryParse(txtCycleTimeSeconds.Text, out _)) {
                txtCycleTimeSeconds.Text = "5";
            }
        }
        private void txtLogPath_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            try {
                if (txtLogPath.Text.IndexOf(".log", StringComparison.OrdinalIgnoreCase) > 0) {
                    txtLogPath.Text = Path.GetDirectoryName(txtLogPath.Text);
                }
            } catch { }
        }

        private void txtPreviousWins_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            if (!string.IsNullOrEmpty(txtPreviousWins.Text) && !int.TryParse(txtPreviousWins.Text, out _)) {
                txtPreviousWins.Text = "0";
            }
        }
    }
}