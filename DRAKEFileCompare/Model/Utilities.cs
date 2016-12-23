// ***********************************************************************
// Assembly         : DRAKEFileCompare
// Author           : Conan D. Foster
// Created          : 12-10-2016
//
// Last Modified By : Conan D. Foster
// Last Modified On : 12-10-2016
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

namespace DRAKEFileCompare.Model
{
    /// <summary>
    /// Class Utilities.
    /// </summary>
    public static class Utilities
    {
        #region WriteErrorLog method

        /// <summary>
        /// Writes the error log.
        /// </summary>
        /// <param name="e">The e.</param>
        public static void WriteErrorLog(string title, Exception e)
        {
            string message = title;
            message += " - " + string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", e.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", e.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", e.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", e.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;

            string errorLogPath = "ErrorLog/ErrorLog.txt";
            StreamWriter sWriter = File.AppendText(errorLogPath);

            try
            {
                sWriter.WriteLine(message);
            }
            finally
            {
                sWriter.Close();
            }
        }

        #endregion
    }
}
