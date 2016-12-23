// ***********************************************************************
// Assembly         : DRAKEFileCompare
// Author           : Conan D. Foster
// Created          : 04-05-2016
//
// Last Modified By : Conan D. Foster
// Last Modified On : 12-08-2016
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
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Media;
using DRAKEFileCompare.ViewModel;

namespace DRAKEFileCompare.View
{
    /// <summary>
    /// Class CompareReportView.
    /// </summary>
    /// <seealso cref="System.Windows.Window" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class CompareReportView : Window
    {
        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CompareReportView"/> class.
        /// </summary>
        /// <param name="compareReport">The compare report.</param>
        public CompareReportView(List<string> compareReport)
        {
            InitializeComponent();
            this._viewModel = new CompareReportViewModel(compareReport);
            this.DataContext = _viewModel;
        }

        #endregion

        #region fields

        /// <summary>
        /// The view model
        /// </summary>
        private CompareReportViewModel _viewModel;

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
        /// Handles the Click event of the Print selection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                // Setup flowdocument parameters
                FlowDocument flowDocument = new FlowDocument();
                flowDocument.FontFamily = new FontFamily("Segoe UI");
                flowDocument.FontSize = 12.0;
                flowDocument.PagePadding = new Thickness(50);
                flowDocument.ColumnGap = 0;
                flowDocument.ColumnWidth = printDialog.PrintableAreaWidth;
                flowDocument.PageHeight = printDialog.PrintableAreaHeight;
                flowDocument.PageWidth = printDialog.PrintableAreaWidth;

                // Create Compare Report header
                Paragraph paragraph = new Paragraph(new Run("Compare Report"));
                paragraph.FontSize = 24;
                paragraph.TextAlignment = TextAlignment.Center;
                flowDocument.Blocks.Add(paragraph);

                // Add items from the Compare Report Listbox to the flowdocument
                foreach (string item in this.CompareReportListBox.Items)
                {
                    flowDocument.Blocks.Add(new Paragraph(new Run(item.ToString())));
                }

                // Set paginatorsource and send to printdialog
                IDocumentPaginatorSource paginatorSource = flowDocument as IDocumentPaginatorSource;
                printDialog.PrintDocument(paginatorSource.DocumentPaginator, "Compare Report");
            }
        }

        #endregion
    }
}
