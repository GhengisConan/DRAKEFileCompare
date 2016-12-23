// ***********************************************************************
// Assembly         : DRAKEFileCompare
// Author           : Conan D. Foster
// Created          : 04-05-2016
//
// Last Modified By : Conan D. Foster
// Last Modified On : 04-05-2016
// ***********************************************************************
// <copyright file="ViewModelBase.cs" company="Blackdrake Inc.">
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
using System.ComponentModel;

namespace DRAKEFileCompare.ViewModel
{
    /// <summary>
    /// Class ViewModelBase.
    /// Base ViewModel contains prototype for INotifyPropertyChanged.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region INotifyPropertyChanged methods

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEventHandler = PropertyChanged;
            if (propertyChangedEventHandler != null)
            {
                propertyChangedEventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
