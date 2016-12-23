// ***********************************************************************
// Assembly         : DRAKEFileCompare
// Author           : Conan D. Foster
// Created          : 12-20-2016
//
// Last Modified By : Conan D. Foster
// Last Modified On : 12-20-2016
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DRAKEFileCompare.ViewModel;
using DRAKEFileCompare.Model;
using System.Collections.Generic;

namespace DRAKEFileCompare.ViewModel.Tests
{
    /// <summary>
    /// Class MainWindowViewModelTests.
    /// </summary>
    [TestClass()]
    public class MainWindowViewModelTests
    {
        /// <summary>
        /// Main window view model test.
        /// Compare two files with a descrepancy.
        /// </summary>
        [TestMethod()]
        public void MainWindowViewModelTest1()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            List<string> compareReport = new List<string>();

            EddynetCSVReportModel eimsReportModel = new EddynetCSVReportModel();
            eimsReportModel.ReadCSVFile("TestFiles/TestFile1.txt", false, true);

            EddynetCSVReportModel dmReportModel = new EddynetCSVReportModel();
            dmReportModel.ReadCSVFile("TestFiles/TestFile2.txt", false, true);

            compareReport = viewModel.CompareFiles(eimsReportModel, dmReportModel);

            Assert.IsFalse(compareReport.Capacity == 0);
        }

        /// <summary>
        /// Main window view model test.
        /// Compare the same file, now descrepancies.
        /// </summary>
        [TestMethod()]
        public void MainWindowViewModelTest2()
        {
            MainWindowViewModel viewModel = new MainWindowViewModel();
            List<string> compareReport = new List<string>();

            EddynetCSVReportModel eimsReportModel = new EddynetCSVReportModel();
            eimsReportModel.ReadCSVFile("TestFiles/TestFile1.txt", false, true);

            EddynetCSVReportModel dmReportModel = new EddynetCSVReportModel();
            dmReportModel.ReadCSVFile("TestFiles/TestFile1.txt", false, true);

            compareReport = viewModel.CompareFiles(eimsReportModel, dmReportModel);

            compareReport = viewModel.CompareFiles(eimsReportModel, dmReportModel);

            Assert.IsTrue(compareReport.Capacity == 0);
        }
    }
}