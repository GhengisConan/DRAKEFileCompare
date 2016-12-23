// ***********************************************************************
// Assembly         : DRAKEDM-EIMSFileCompare
// Author           : Conan D. Foster
// Created          : 04-05-2016
//
// Last Modified By : Conan D. Foster
// Last Modified On : 04-07-2016
// ***********************************************************************
// <copyright file="RelayCommand.cs" company="Blackdrake Inc.">
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
using System.Diagnostics;
using System.Windows.Input;

namespace DRAKEFileCompare
{
    /// <summary>
    /// Class RelayCommand.
    /// RelayCommand class relays its functionality to other objects by 
    /// invoking delegates.
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class RelayCommand : ICommand
    {
        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// RelayCommand constructor creates a new command which can always execute.
        /// </summary>
        /// <param name="execute">The execute action.</param>
        public RelayCommand(Action execute) : this(execute, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// RelayCommand constructor creates a new command with boolean logic.
        /// </summary>
        /// <param name="execute">The execute action.</param>
        /// <param name="canExecute">The can execute boolean func.</param>
        /// <exception cref="ArgumentNullException">execute</exception>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region fields

        /// <summary>
        /// Execute Action
        /// Action delegate type field to hold execute value
        /// </summary>
        readonly Action _execute;
        /// <summary>
        /// CanExecute Boolean Func
        /// Func delegate type field to hold boolean can execute value
        /// </summary>
        readonly Func<bool> _canExecute;

        #endregion

        #region ICommand members

        /// <summary>
        /// EventHandler for CanExecuteChanged event.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        /// <summary>
        /// Determines whether this instance can execute the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns><c>true</c> if this instance can execute the specified parameter; otherwise, <c>false</c>.</returns>
        [DebuggerStepThrough]

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        /// <summary>
        /// Executes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public void Execute(object parameter)
        {
            _execute();
        }

        #endregion
    }
}
