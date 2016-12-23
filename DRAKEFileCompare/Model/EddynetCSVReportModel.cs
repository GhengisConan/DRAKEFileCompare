// ***********************************************************************
// Assembly         : DRAKEFileCompare
// Author           : Conan D. Foster
// Created          : 04-05-2016
//
// Last Modified By : Conan D. Foster
// Last Modified On : 12-08-2016
// ***********************************************************************
// <copyright file="EddynetCSVReportModel.cs" company="Blackdrake Inc.">
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
using System.IO;
using DRAKEFileCompare.DataType;

namespace DRAKEFileCompare.Model
{
    /// <summary>
    /// Class EddynetCSVReportModel.
    /// Data Type with a Multimap Dictionary type for storing and reading data into
    /// the Eddynet data format for storage and comparison
    /// </summary>
    public class EddynetCSVReportModel
    {
        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EddynetCSVReportModel"/> class.
        /// Default constructor initializes _eddynetCSVReport field
        /// </summary>
        public EddynetCSVReportModel() { _eddynetCSVReport = new MultiMapDictionaryType<string>(); }

        /// <summary>
        /// Initializes a new instance of the <see cref="EddynetCSVReportModel"/> class.
        /// Constructor takes user input and reads csv file into _eddynetCSVReport field
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="ignoreLegIsEnabled">if set to <c>true</c> [ignore leg is enabled].</param>
        /// <param name="ignoreProbeSNIsEnabled">if set to <c>true</c> [ignore probesn is enabled].</param>
        public EddynetCSVReportModel(string filePath, bool ignoreLegIsEnabled, bool ignoreProbeSNIsEnabled)
        {
            this._eddynetCSVReport = new MultiMapDictionaryType<string>();
            this._filePath = filePath;
            this._ignoreLegIsEnabled = ignoreLegIsEnabled;
            this._ignoreProbeSNIsEnabled = ignoreProbeSNIsEnabled;

            this._readCSVFile();
        }

        #endregion

        #region constants

        /// <summary>
        /// The LEG location
        /// numeric location of LEG field
        /// </summary>
        const int LEG_LOCATION = 16;
        /// <summary>
        /// The PROBESN location
        /// numeric location of ProbeSN field
        /// </summary>
        const int PROBESN_LOCATION = 18;
        /// <summary>
        /// The CSV Field separator
        /// char internal file field separator
        /// </summary>
        const char FIELD_SEPARATOR = ',';
        /// <summary>
        /// The Header prefix
        /// string Header prefix identifier
        /// </summary>
        const string HEADER_PREFIX = "#";
        /// <summary>
        /// The CSV Field filler
        /// char field input replacement value
        /// </summary>
        const char FIELD_FILLER = '0';
        /// <summary>
        /// The Report KEY ROW
        /// char value for Key Row identifier
        /// </summary>
        const char REPORT_KEY_ROW = 'R';
        /// <summary>
        /// The Report KEY COL
        /// char value for Key Col identifier
        /// </summary>
        const char REPORT_KEY_COL = 'C';

        #endregion

        #region fields

        /// <summary>
        /// The Eddynet CSV report
        /// MultiMapDictionaryType string data type for storing Eddynet formatted data
        /// </summary>
        private MultiMapDictionaryType<string> _eddynetCSVReport;
        /// <summary>
        /// The file path
        /// string data type for storing csv file filepath information
        /// </summary>
        private string _filePath;
        /// <summary>
        /// The ignore leg is enabled
        /// boolean data type for storing boolean value of Leg read status
        /// </summary>
        private bool _ignoreLegIsEnabled;
        /// <summary>
        /// The ignore probeSN is enabled
        /// boolean data type for storing boolean value of ProbeSN read status
        /// </summary>
        private bool _ignoreProbeSNIsEnabled;

        #endregion

        #region properties

        /// <summary>
        /// Gets the eddynet CSV report.
        /// MultiMapDictionaryType property gives read only access to _eddynetCSVReport field
        /// </summary>
        /// <value>The eddynet CSV report.</value>
        public MultiMapDictionaryType<string> EddynetCSVReport
        {
            get { return this._eddynetCSVReport; }
        }

        #endregion

        #region private methods

        /// <summary>
        /// Get Report Key method
        /// creates Key from report line first two fields
        /// returns Key string on success, null otherwise
        /// </summary>
        /// <param name="reportLine">The report line.</param>
        /// <returns>System.String.</returns>
        private string _getReportKey(string reportLine)
        {
            string reportKey = null;

            try
            {
                string[] reportLineArray = reportLine.Split(FIELD_SEPARATOR);
                reportKey = REPORT_KEY_ROW + reportLineArray[0].Trim() + REPORT_KEY_COL + reportLineArray[1].Trim();
            }
            catch (Exception e)
            {
                string title = "EddynetCSVReportModel -> _getReportKey(string " + reportLine + ")";
                Utilities.WriteErrorLog(title, e);
            }

            return reportKey;
        }

        /// <summary>
        /// Format report line method
        /// creates an Eddynet formatted string from fields in user inputted string
        /// returns Eddynet formatted report line on success, null otherwise
        /// </summary>
        /// <param name="reportLine">The report line.</param>
        /// <returns>System.String.</returns>
        private string _formatReportLine(string reportLine)
        {
            string formattedReportLine = null;

            try
            {
                string[] reportLineArray = reportLine.Split(FIELD_SEPARATOR);

                formattedReportLine = reportLineArray[0];
                for (int i = 1; i < reportLineArray.Length; i++)
                {
                    if (i == 1)
                        formattedReportLine = formattedReportLine + FIELD_SEPARATOR + reportLineArray[i].Trim();
                    else if (this._ignoreLegIsEnabled && i == LEG_LOCATION - 1)
                        formattedReportLine = formattedReportLine + FIELD_SEPARATOR + FIELD_FILLER;
                    else if (this._ignoreProbeSNIsEnabled && i == PROBESN_LOCATION - 1)
                        formattedReportLine = formattedReportLine + FIELD_SEPARATOR + FIELD_FILLER;
                    else
                        formattedReportLine = formattedReportLine + FIELD_SEPARATOR + reportLineArray[i];
                }
            }
            catch (Exception e)
            {
                string title = "EddynetCSVReportModel -> _formatReportLine(string " + reportLine + ")";
                Utilities.WriteErrorLog(title, e);
            }

            return formattedReportLine;
        }

        /// <summary>
        /// Overloaded Read CSV file method
        /// reads csv file into Eddynet formatted report line with Key
        /// and stores in EddynetCSVReport MultiMapDictionaryType data type
        /// </summary>
        private void _readCSVFile()
        {
            try
            {
                string[] csvFileArray = File.ReadAllLines(_filePath);

                for (int i = 0; i < csvFileArray.Length; i++)
                {
                    string line = csvFileArray[i];
                    line = line.Replace("\t", " ");
                    line = line.Trim();
                    if (!line.StartsWith(HEADER_PREFIX) && !String.IsNullOrEmpty(line) && !String.IsNullOrWhiteSpace(line))
                    {
                        EddynetCSVReport.Add(this._getReportKey(line), this._formatReportLine(line));
                    }
                }
            }
            catch (Exception e)
            {
                string title = "EddynetCSVReportModel -> ReadCSVFile()";
                Utilities.WriteErrorLog(title, e);
            }
        }
        
        #endregion

        #region public methods

        /// <summary>
        /// Overloaded Read CSV file method
        /// takes filePath, ignoreLegIsEnabled and ignoreProbeSNIsEnabled from user input
        /// and stores to fields _filePath, _ignoreLegIsEnabled and _ignoreProbeSNIsEnabled
        /// and then reads csv file into Eddynet formatted report line with Key
        /// and stores in EddynetCSVReport MultiMapDictionaryType data type
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="ignoreLegIsEnabled">if set to <c>true</c> [ignore leg is enabled].</param>
        /// <param name="ignoreProbeSNIsEnabled">if set to <c>true</c> [ignore probesn is enabled].</param>
        public void ReadCSVFile(string filePath, bool ignoreLegIsEnabled, bool ignoreProbeSNIsEnabled)
        {
            try
            {
                this._filePath = filePath;
                this._ignoreLegIsEnabled = ignoreLegIsEnabled;
                this._ignoreProbeSNIsEnabled = ignoreProbeSNIsEnabled;
                string[] csvFileArray = File.ReadAllLines(_filePath);

                for (int i = 0; i < csvFileArray.Length; i++)
                {
                    string line = csvFileArray[i];
                    line = line.Replace("\t", " ");
                    line = line.Trim();
                    if (!line.StartsWith(HEADER_PREFIX) && !String.IsNullOrEmpty(line) && !String.IsNullOrWhiteSpace(line))
                    {
                        EddynetCSVReport.Add(this._getReportKey(line), this._formatReportLine(line));
                    }
                }
            }
            catch (Exception e)
            {
                string title = "EddynetCSVReportModel -> ReadCSVFile(string " + filePath + ", bool " + ignoreLegIsEnabled + ", bool " + ignoreProbeSNIsEnabled + ")";
                Utilities.WriteErrorLog(title, e);
            }
        }

        #endregion
    }
}
