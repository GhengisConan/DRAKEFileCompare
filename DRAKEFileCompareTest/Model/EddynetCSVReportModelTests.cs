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
using DRAKEFileCompare.Model;

/// <summary>
/// The Tests namespace.
/// </summary>
namespace DRAKEFileCompare.Model.Tests
{
    /// <summary>
    /// Class EddynetCSVReportModelTests.
    /// </summary>
    [TestClass()]
    public class EddynetCSVReportModelTests
    {
        /// <summary>
        /// Eddynet CSV report model test, default constructor.
        /// </summary>
        [TestMethod()]
        public void EddynetCSVReportModelTest1()
        {
            EddynetCSVReportModel eddynetCSVReportModel = new EddynetCSVReportModel();
            Assert.IsNotNull(eddynetCSVReportModel);
        }

        /// <summary>
        /// Eddynets CSV report model test, constructor with values.
        /// </summary>
        [TestMethod()]
        public void EddynetCSVReportModelTest2()
        {
            EddynetCSVReportModel eddynetCSVReportModel = new EddynetCSVReportModel("TestFiles/TestFile1.txt", false, false);
            Assert.IsNotNull(eddynetCSVReportModel);
        }

        /// <summary>
        /// Tests the Read CSV public method.
        /// </summary>
        [TestMethod()]
        public void ReadCSVFileTest()
        {
            EddynetCSVReportModel eddynetCSVReportModel = new EddynetCSVReportModel();
            eddynetCSVReportModel.ReadCSVFile("TestFiles/TestFile1.txt", false, false);
            string key = "R3C52";
            Assert.IsTrue(eddynetCSVReportModel.EddynetCSVReport.Find(key));
        }
    }
}