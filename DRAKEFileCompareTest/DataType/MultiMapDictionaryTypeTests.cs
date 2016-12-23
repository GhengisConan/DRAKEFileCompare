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
using DRAKEFileCompare.DataType;
using System;
using System.Collections.Generic;

/// <summary>
/// The Tests namespace.
/// </summary>
namespace DRAKEFileCompare.DataType.Tests
{
    /// <summary>
    /// Class MultiMapDictionaryTypeTests.
    /// </summary>
    [TestClass()]
    public class MultiMapDictionaryTypeTests
    {
        /// <summary>
        /// MultiMapDictionaryType test.
        /// </summary>
        [TestMethod()]
        public void MultiMapDictionaryTypeTest()
        {
            MultiMapDictionaryType<List<String>> multiMapDictionaryType = new MultiMapDictionaryType<List<string>>();
            Assert.IsNotNull(multiMapDictionaryType);
        }

        /// <summary>
        /// Add & Find Pass test.
        /// </summary>
        [TestMethod()]
        public void AddFindTestPass()
        {
            MultiMapDictionaryType<List<String>> multiMapDictionaryType = new MultiMapDictionaryType<List<String>>();

            string key = "key";
            List<string> list = new List<string>() { "test1", "test2", "test3" };

            multiMapDictionaryType.Add(key, list);

            Assert.IsTrue(multiMapDictionaryType.Find(key));
        }

        /// <summary>
        /// Add & Find Fail test.
        /// </summary>
        [TestMethod()]
        public void AddFindTestFail()
        {
            MultiMapDictionaryType<List<String>> multiMapDictionaryType = new MultiMapDictionaryType<List<String>>();

            string key = "key";
            string falseKey = "notKey";
            List<string> list = new List<string>() { "test1", "test2", "test3" };

            multiMapDictionaryType.Add(key, list);

            Assert.IsFalse(multiMapDictionaryType.Find(falseKey));
        }
    }
}