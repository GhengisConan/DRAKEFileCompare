// ***********************************************************************
// Assembly         : DRAKEFileCompare
// Author           : Conan D. Foster
// Created          : 04-05-2016
//
// Last Modified By : Conan D. Foster
// Last Modified On : 12-08-2016
// ***********************************************************************
// <copyright file="CompareReportViewModel.cs" company="Blackdrake Inc.">
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
using System.Collections.Generic;

namespace DRAKEFileCompare.ViewModel
{
    /// <summary>
    /// Class CompareReportViewModel.
    /// view model for Compare Report window
    /// </summary>
    public class CompareReportViewModel
    {
        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CompareReportViewModel"/> class.
        /// </summary>
        /// <param name="compareReport">The compare report.</param>
        public CompareReportViewModel(List<string> compareReport)
        {
            this._compareReport = compareReport;
        }

        #endregion

        #region fields

        /// <summary>
        /// The compare report
        /// </summary>
        private List<string> _compareReport;

        #endregion

        #region properties

        /// <summary>
        /// Gets or sets the compare report list.
        /// </summary>
        /// <value>The compare report list.</value>
        public List<string> CompareReportList
        {
            get { return this._compareReport; }
            set { if (this._compareReport == value) { return; } this._compareReport = value; }
        }

        #endregion
    }
}
