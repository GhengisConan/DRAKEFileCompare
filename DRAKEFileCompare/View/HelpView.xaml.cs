// ***********************************************************************
// Assembly         : DRAKEFileCompare
// Author           : Conan D. Foster
// Created          : 12-09-2016
//
// Last Modified By : Conan D. Foster
// Last Modified On : 12-09-2016
// ***********************************************************************
//     Copyright ©  2016
//     All Rights Reserved.
// </copyright>
// <summary> NOTICE:  All information contained herein is, and remains the 
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
using System.Collections.Generic;
using System.Windows;

namespace DRAKEFileCompare.View
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class HelpView : Window
    {
        #region constructor

        public HelpView(string title, List<string> helpList)
        {
            InitializeComponent();
            this.Title = title;
            this._helpList = helpList;
            this._setHelpItems();
        }

        #endregion

        #region fields

        /// <summary>
        /// The help list
        /// String list of help items contained with help window.
        /// </summary>
        private List<string> _helpList;

        #endregion

        #region private methods

        /// <summary>
        /// Handles the Click event of the Close control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Sets the help items.
        /// </summary>
        private void _setHelpItems()
        {
            foreach (string item in this._helpList)
            {
                Console.WriteLine(item);
                switch (item)
                {
                    case "Title":
                        TitleControlView titleView = new TitleControlView();
                        this.HelpStackPanel.Children.Add(titleView);
                        break;
                    case "About":
                        AboutControlView aboutView = new AboutControlView();
                        this.HelpStackPanel.Children.Add(aboutView);
                        break;
                    case "Features":
                        FeaturesControlView featuresView = new FeaturesControlView();
                        this.HelpStackPanel.Children.Add(featuresView);
                        break;
                    case "License":
                        LicenseControlView licenseView = new LicenseControlView();
                        this.HelpStackPanel.Children.Add(licenseView);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}
