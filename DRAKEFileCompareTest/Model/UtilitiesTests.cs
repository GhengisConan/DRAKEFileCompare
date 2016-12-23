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
using System;
using System.IO;

namespace DRAKEFileCompare.Model.Tests
{
    /// <summary>
    /// Class UtilitiesTests.
    /// </summary>
    [TestClass()]
    public class UtilitiesTests
    {
        /// <summary>
        /// Error log write test.
        /// Test if Error Log is empty.
        /// </summary>
        [TestMethod()]
        public void WriteErrorLogTest()
        {
            try
            {
                int i = int.Parse("String");
            }
            catch (Exception ex)
            {
                Utilities.WriteErrorLog("Error Log Test", ex);
            }

            Assert.IsTrue(new FileInfo("ErrorLog/ErrorLog.txt").Length != 0);
        }
    }
}