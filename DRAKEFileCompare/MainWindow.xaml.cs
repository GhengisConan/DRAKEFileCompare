﻿// ***********************************************************************
// Assembly         : DRAKEFileCompare
// Author           : Conan D. Foster
// Created          : 04-05-2016
//
// Last Modified By : Conan D. Foster
// Last Modified On : 04-05-2016
// ***********************************************************************
// <copyright file="MainWindow.xaml.cs" company="Blackdrake Inc.">
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
using System.Windows;
using DRAKEFileCompare.ViewModel;

namespace DRAKEFileCompare
{
    /// <summary>
    /// Class MainWindow.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class MainWindow : Window
    {
        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            this.DataContext = _viewModel;
        }

        #endregion

        #region fields

        /// <summary>
        /// The view model
        /// </summary>
        private MainWindowViewModel _viewModel;

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

        #endregion
    }
}
