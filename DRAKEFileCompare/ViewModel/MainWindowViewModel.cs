// ***********************************************************************
// Assembly         : DRAKEFileCompare
// Author           : Conan D. Foster
// Created          : 04-05-2016
//
// Last Modified By : Conan D. Foster
// Last Modified On : 12-09-2016
// ***********************************************************************
// <copyright file="MainWindowViewModel.cs" company="Blackdrake Inc.">
//     Copyright ©  2016
//     All Rights Reserved.
// </copyright>
// <summary>
// NOTICE:  All information contained herein is, and remains the
// property of Blackdrake Inc. and its suppliers, if any.  The
// intellectual and technical concepts contained herein are proprietary to
// Blackdrake Inc. and its suppliers and may be covered by U.S.and Foreign
// Patents, patents in process, and are protected by trade secret or
// copyright law.  Dissemination of this information or reproduction of
// this material is strictly forbidden unless prior written permission is
// obtained from Blackdrake Inc.
// </summary>
// ***********************************************************************
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Input;
using System.ComponentModel;
using DRAKEFileCompare.View;
using DRAKEFileCompare.Model;

namespace DRAKEFileCompare.ViewModel
{
    /// <summary>
    /// Class MainWindowViewModel.
    /// view model for Main Window
    /// </summary>
    /// <seealso cref="DRAKEFileCompare.ViewModel.ViewModelBase" />
    /// <seealso cref="System.ComponentModel.IDataErrorInfo" />
    public class MainWindowViewModel : ViewModelBase, IDataErrorInfo
    {
        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// default constructor
        /// </summary>
        public MainWindowViewModel() { }

        #endregion

        #region constants

        /// <summary>
        /// The file dialog default extension
        /// </summary>
        const string FILEDIALOG_DEFAULTEXT = ".csv";
        /// <summary>
        /// The file dialog filter
        /// </summary>
        const string FILEDIALOG_FILTER = "Text files (*.txt)|*.txt|CSV files (*.csv*)|*.csv*";

        #endregion

        #region fields

        /// <summary>
        /// The EIMS file path text
        /// string full file path for EIMS csv file
        /// </summary>
        private string _EIMSFilePathText;
        /// <summary>
        /// The DM file path text
        /// string full file path for DM csv file
        /// </summary>
        private string _DMFilePathText;
        /// <summary>
        /// The ignore leg CheckBox is checked
        /// boolean data type for storing boolean value of Leg is checked status
        /// </summary>
        private bool _IgnoreLegCheckBoxIsChecked;
        /// <summary>
        /// The ignore probe sn CheckBox is checked
        /// boolean data type for storing boolean value of probesn is checked status
        /// </summary>
        private bool _IgnoreProbeSNCheckBoxIsChecked;
        /// <summary>
        /// The compare button is enabled
        /// boolean data type for storing boolean value of compare button is enabled status
        /// </summary>
        private bool _CompareButtonIsEnabled;

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the eims file path text.
        /// EIMSFilePathText property gives read/write access to _EIMSFilePathText field
        /// </summary>
        /// <value>The eims file path text.</value>
        public string EIMSFilePathText
        {
            get { return this._EIMSFilePathText; }
            set
            {
                if (this._EIMSFilePathText == value) { return; }
                this._EIMSFilePathText = value;
                RaisePropertyChanged("EIMSFilePathText");
                RaisePropertyChanged("CompareButtonIsEnabled");
            }
        }

        /// <summary>
        /// Gets or sets the dm file path text.
        /// DMFilePathText property gives read/write access to _DMFilePathText field
        /// </summary>
        /// <value>The dm file path text.</value>
        public string DMFilePathText
        {
            get { return this._DMFilePathText; }
            set
            {
                if (this._DMFilePathText == value) { return; }
                this._DMFilePathText = value;
                RaisePropertyChanged("DMFilePathText");
                RaisePropertyChanged("CompareButtonIsEnabled");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [ignore leg CheckBox is checked].
        /// IgnoreLegCheckBoxIsChecked property gives read/write access to _IgnoreLegCheckBoxIsChecked field
        /// </summary>
        /// <value><c>true</c> if [ignore leg CheckBox is checked]; otherwise, <c>false</c>.</value>
        public bool IgnoreLegCheckBoxIsChecked
        {
            get { return this._IgnoreLegCheckBoxIsChecked; }
            set
            {
                if (this._IgnoreLegCheckBoxIsChecked == value) { return; }
                this._IgnoreLegCheckBoxIsChecked = value;
                RaisePropertyChanged("IgnoreLegCheckBoxIsChecked");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [ignore probe sn CheckBox is checked].
        /// IgnoreProbeSNCheckBoxIsChecked property gives read/write access to _IgnoreProbeSNCheckBoxIsChecked field
        /// </summary>
        /// <value><c>true</c> if [ignore probe sn CheckBox is checked]; otherwise, <c>false</c>.</value>
        public bool IgnoreProbeSNCheckBoxIsChecked
        {
            get { return this._IgnoreProbeSNCheckBoxIsChecked; }
            set
            {
                if (this._IgnoreProbeSNCheckBoxIsChecked == value) { return; }
                this._IgnoreProbeSNCheckBoxIsChecked = value;
                RaisePropertyChanged("IgnoreProbeSNCheckBoxIsChecked");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [compare button is enabled].
        /// CompareButtonIsEnabled property gives read/write access to _setCompareButtonIsEnabled field
        /// </summary>
        /// <value><c>true</c> if [compare button is enabled]; otherwise, <c>false</c>.</value>
        public bool CompareButtonIsEnabled
        {
            get { return this._setCompareButtonIsEnabled(); }
            set
            {
                if (this._CompareButtonIsEnabled == value) { return; }
                this._CompareButtonIsEnabled = value;
                RaisePropertyChanged("CompareButtonIsEnabled");
            }
        }

        #endregion

        #region private methods

        /// <summary>
        /// returns if both EIMSFilePathText and DMFilePathText are valid
        /// </summary>
        /// <returns>boolean value</returns>
        private bool _setCompareButtonIsEnabled()
        {
            return this._validateFilePathText(EIMSFilePathText) == String.Empty && 
                this._validateFilePathText(DMFilePathText) == String.Empty;
        }

        /// <summary>
        /// Select and validate EIMS csv file
        /// sets and shows file dialog for EIMS csv file selection
        /// </summary>
        private void _selectEIMSFilePath()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.DefaultExt = FILEDIALOG_DEFAULTEXT;
                openFileDialog.Filter = FILEDIALOG_FILTER;

                DialogResult result = openFileDialog.ShowDialog();

                EIMSFilePathText = openFileDialog.FileName;
            }
            catch (Exception e)
            {
                string title = "MainWindowViewModel -> _selectEIMSFilePath()";
                Utilities.WriteErrorLog(title, e);
            }
            finally
            {
                RaisePropertyChanged("EIMSFilePathText");
                RaisePropertyChanged("CompareButtonIsEnabled");
            }
        }

        /// <summary>
        /// Select and validate DM csv file
        /// sets and shows file dialog for DM csv file selection
        /// </summary>
        private void _selectDMFilePath()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.DefaultExt = FILEDIALOG_DEFAULTEXT;
                openFileDialog.Filter = FILEDIALOG_FILTER;

                DialogResult result = openFileDialog.ShowDialog();

                DMFilePathText = openFileDialog.FileName;
            }
            catch (Exception e)
            {
                string title = "MainWindowViewModel -> _selectDMFilePath()";
                Utilities.WriteErrorLog(title, e);
            }
            finally
            {
                RaisePropertyChanged("DMFilePathText");
                RaisePropertyChanged("CompareButtonIsEnabled");
            }
        }

        /// <summary>
        /// Compare method
        /// creates and initializes new CompareReportView
        /// with compare results
        /// </summary>
        private void _compare()
        {
            List<string> compareReport = new List<string>();
            EddynetCSVReportModel eimsReportModel = new EddynetCSVReportModel(EIMSFilePathText, IgnoreLegCheckBoxIsChecked, IgnoreProbeSNCheckBoxIsChecked);
            EddynetCSVReportModel dmReportModel = new EddynetCSVReportModel(DMFilePathText, IgnoreLegCheckBoxIsChecked, IgnoreProbeSNCheckBoxIsChecked);

            compareReport = CompareFiles(eimsReportModel, dmReportModel);

            /// <remarks>
            /// Test if the compare report is empty
            /// if the compare report is empty enter results in compare report
            /// </remarks>
            if (compareReport.Capacity == 0)
                this._enterCompareReportEntry(compareReport);

            CompareReportView compareReportView = new CompareReportView(compareReport);
            compareReportView.ShowDialog();
        }

        /// <summary>
        /// Compare files method
        /// returns the compare report.
        /// creates and initializes a new EddynetCSVReportModel for EIMS and DM csv files
        /// compares key values in EIMS file to DM file
        /// compares list values in each EIMS key to DM key
        /// compares key values in DM file to EIMS file
        /// </summary>
        /// <param name="eimsReportModel">The eims report model.</param>
        /// <param name="dmReportModel">The dm report model.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<string> CompareFiles(EddynetCSVReportModel eimsReportModel, EddynetCSVReportModel dmReportModel)
        {
            List<string> compareReport = new List<string>();

            /// <remarks>
            /// Compare key values in EIMS file to key values in DM file
            /// if key does not exist in DM file, enter error in compare report
            /// otherwise compare all values in each list at key location
            /// if values are not equal in order, enter error in compare report
            /// </remarks>
            foreach (string key in eimsReportModel.EddynetCSVReport.Keys)
            {
                if (!dmReportModel.EddynetCSVReport.Find(key))
                {
                    _enterCompareReportEntry(key, compareReport, eimsReportModel, dmReportModel);
                }
                else
                {
                    List<string> list1 = eimsReportModel.EddynetCSVReport[key];
                    List<string> list2 = dmReportModel.EddynetCSVReport[key];
                    if (list1.Count == list2.Count)
                    {
                        bool isMatch = true;
                        for (int i = 0; i < list1.Count; i++)
                        {
                            if (list1[i] == list2[i])
                                isMatch = true;
                            else
                                isMatch = false;
                        }
                        if (!isMatch)
                        {
                            this._enterCompareReportEntry(key, compareReport, eimsReportModel, dmReportModel);
                        }
                    }
                    else
                    {
                        this._enterCompareReportEntry(key, compareReport, eimsReportModel, dmReportModel);
                    }
                }
            }

            /// <remarks>
            /// Compare key values in DM file to key values in EIMS file
            /// if key does not exist in EIMS file, enter error in compare report
            /// </remarks>
            foreach (string key in dmReportModel.EddynetCSVReport.Keys)
            {
                if (!eimsReportModel.EddynetCSVReport.Find(key))
                {
                    this._enterCompareReportEntry(key, compareReport, eimsReportModel, dmReportModel);
                }
            }

            return compareReport;
        }

        /// <summary>
        /// Enters the compare report entry for an empty report.
        /// </summary>
        /// <param name="reportList">The report list.</param>
        private void _enterCompareReportEntry(List<string> reportList)
        {
            reportList.Add("");
            reportList.Add("");
            reportList.Add("      No Discrepancies found.        ");
            reportList.Add("");
            reportList.Add("");
        }

        /// <summary>
        /// Enters the compare report entry for a given key.
        /// stores all report lines for a given key in both csv files
        /// into the compare report list as formatted and organized error entries
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="reportList">The report list.</param>
        /// <param name="eimsReportModel">The eims report model.</param>
        /// <param name="dmReportModel">The dm report model.</param>
        private void _enterCompareReportEntry(string key, List<string> reportList, EddynetCSVReportModel eimsReportModel, EddynetCSVReportModel dmReportModel)
        {
            reportList.Add("");
            reportList.Add("     Discrepancies found for:  " + key);
            reportList.Add("         EIMS Entries");
            foreach (string report in eimsReportModel.EddynetCSVReport[key])
            {
                reportList.Add("     " + report + "      ");
            }
            reportList.Add("");
            reportList.Add("         DM Entries");
            foreach (string report in dmReportModel.EddynetCSVReport[key])
            {
                reportList.Add("     " + report + "      ");
            }
            reportList.Add("");
        }

        /// <summary>
        /// View Liecense method.
        /// </summary>
        private void _viewLicense()
        {
            List<string> list = new List<string>() { "License" };
            HelpView helpView = new HelpView("License Agreement", list);
            helpView.ShowDialog();
        }

        /// <summary>
        /// View About method.
        /// </summary>
        private void _viewAbout()
        {
            List<string> list = new List<string>() { "About" };
            HelpView helpView = new HelpView("About DRAKE Compare", list);
            helpView.ShowDialog();
        }

        /// <summary>
        /// View About method.
        /// </summary>
        private void _viewHelp()
        {
            List<string> list = new List<string>() { "Title", "About", "Features", "License" };
            HelpView helpView = new HelpView("DRAKE Compare Help", list);
            helpView.ShowDialog();
        }
        #endregion

        #region ICommand commands

        /// <summary>
        /// Selects the eims file path command.
        /// </summary>
        private void SelectEIMSFilePathCommand() { this._selectEIMSFilePath(); }
        /// <summary>
        /// Determines whether this instance [can select eims file path command].
        /// </summary>
        /// <returns><c>true</c> if this instance [can select eims file path command]; otherwise, <c>false</c>.</returns>
        private bool CanSelectEIMSFilePathCommand() { return true; }
        /// <summary>
        /// Gets the select eims file path.
        /// </summary>
        /// <value>The select eims file path.</value>
        public ICommand SelectEIMSFilePath
        {
            get { return new RelayCommand(SelectEIMSFilePathCommand, CanSelectEIMSFilePathCommand); }
        }

        /// <summary>
        /// Selects the dm file path command.
        /// </summary>
        private void SelectDMFilePathCommand() { this._selectDMFilePath(); }
        /// <summary>
        /// Determines whether this instance [can select dm file path command].
        /// </summary>
        /// <returns><c>true</c> if this instance [can select dm file path command]; otherwise, <c>false</c>.</returns>
        private bool CanSelectDMFilePathCommand() { return true; }
        /// <summary>
        /// Gets the select dm file path.
        /// </summary>
        /// <value>The select dm file path.</value>
        public ICommand SelectDMFilePath
        {
            get { return new RelayCommand(SelectDMFilePathCommand, CanSelectDMFilePathCommand); }
        }

        /// <summary>
        /// Compare command.
        /// </summary>
        private void CompareCommand() { this._compare(); }
        /// <summary>
        /// Determines whether this instance [can compare command].
        /// </summary>
        /// <returns><c>true</c> if this instance [can compare command]; otherwise, <c>false</c>.</returns>
        private bool CanCompareCommand() { return this._setCompareButtonIsEnabled(); }
        /// <summary>
        /// Gets the compare.
        /// </summary>
        /// <value>The compare.</value>
        public ICommand Compare
        {
            get { return new RelayCommand(CompareCommand, CanCompareCommand); }
        }

        /// <summary>
        /// View License command.
        /// </summary>
        private void ViewLicenseCommand() { this._viewLicense(); }
        /// <summary>
        /// Determines whether this instance [can ViewLicense command].
        /// </summary>
        /// <returns><c>true</c> if this instance [can ViewLicense command]; otherwise, <c>false</c>.</returns>
        private bool CanViewLicenseCommand() { return true; }
        /// <summary>
        /// Gets the ViewLicense.
        /// </summary>
        /// <value>The ViewLicense.</value>
        public ICommand ViewLicense
        {
            get { return new RelayCommand(ViewLicenseCommand, CanViewLicenseCommand); }
        }

        /// <summary>
        /// View About command.
        /// </summary>
        private void ViewAboutCommand() { this._viewAbout(); }
        /// <summary>
        /// Determines whether this instance [can ViewAbout command].
        /// </summary>
        /// <returns><c>true</c> if this instance [can ViewAbout command]; otherwise, <c>false</c>.</returns>
        private bool CanViewAboutCommand() { return true; }
        /// <summary>
        /// Gets the ViewAbout.
        /// </summary>
        /// <value>The ViewAbout.</value>
        public ICommand ViewAbout
        {
            get { return new RelayCommand(ViewAboutCommand, CanViewAboutCommand); }
        }

        /// <summary>
        /// View Help command.
        /// </summary>
        private void ViewHelpCommand() { this._viewHelp(); }
        /// <summary>
        /// Determines whether this instance [can ViewHelp command].
        /// </summary>
        /// <returns><c>true</c> if this instance [can ViewHelp command]; otherwise, <c>false</c>.</returns>
        private bool CanViewHelpCommand() { return true; }
        /// <summary>
        /// Gets the ViewHelp.
        /// </summary>
        /// <value>The ViewHelp.</value>
        public ICommand ViewHelp
        {
            get { return new RelayCommand(ViewHelpCommand, CanViewHelpCommand); }
        }
        
        #endregion

        #region IDataErrorInfo properties

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value>The error.</value>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public string Error { get { return null; } }

        /// <summary>
        /// Gets the <see cref="System.String" /> with the specified property name.
        /// </summary>
        /// <param name="PropertyName">Name of the property.</param>
        /// <returns>System.String.</returns>
        public string this[string PropertyName]
        {
            get
            {
                string error = null;
                switch (PropertyName)
                {
                    case "EIMSFilePathText":
                        error = this._validateFilePathText(EIMSFilePathText);
                        break;
                    case "DMFilePathText":
                        error = this._validateFilePathText(DMFilePathText);
                        break;
                }
                return error;
            }
        }

        #endregion

        #region IDataErrorInfo methods

        /// <summary>
        /// Checks if string path is not null or empty and that the file exits
        /// </summary>
        /// <param name="path">file path as string</param>
        /// <returns>error string</returns>
        private string _validateFilePathText(string path)
        {
            if (String.IsNullOrEmpty(path) || !File.Exists(path))
                return "File needs to exist and be accessible";
            else
                return String.Empty;
        }

        #endregion
    }
}
