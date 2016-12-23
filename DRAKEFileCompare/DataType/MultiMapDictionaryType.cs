// ***********************************************************************
// Assembly         : DRAKEFileCompare
// Author           : Conan D. Foster
// Created          : 04-05-2016
//
// Last Modified By : Conan D. Foster
// Last Modified On : 12-08-2016
// ***********************************************************************
// <copyright file="MultiMapDictionaryType.cs" company="Blackdrake Inc.">
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
using System.Collections.Generic;
using DRAKEFileCompare.Model;

namespace DRAKEFileCompare.DataType
{
    /// <summary>
    /// Class MultiMapDictionaryType.
    /// Data Type with a Dictionary field with string key and generic list value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MultiMapDictionaryType<T>
    {
        #region constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiMapDictionaryType{T}"/> class.
        /// Default constructor
        /// initializes _multiMapDictionary field
        /// </summary>
        public MultiMapDictionaryType() { this._multiMapDictionary = new Dictionary<string, List<T>>(); }

        #endregion

        #region fields

        /// <summary>
        /// The multimap dictionary
        /// Dictionary type with string key and generic list value
        /// </summary>
        private Dictionary<string, List<T>> _multiMapDictionary;

        #endregion

        #region properties

        /// <summary>
        /// Gets the keys.
        /// IEnumerable Keys property gives read only enumerated access to all keys in dictionary
        /// </summary>
        /// <value>The keys.</value>
        public IEnumerable<string> Keys
        {
            get { return this._multiMapDictionary.Keys; }
        }

        /// <summary>
        /// Gets the <see cref="List{T}"/> with the specified key.
        /// List of type T gives access to list value at key location
        /// returns list value at key location, void if dictionary does not contain key
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public List<T> this[string key]
        {
            get
            {
                List<T> list = null;

                if (!this._multiMapDictionary.TryGetValue(key, out list))
                {
                    list = new List<T>();
                    this._multiMapDictionary[key] = list;
                }

                return list;
            }
        }

        #endregion

        #region public methods

        /// <summary>
        /// Add dictionary entry method
        /// Adds the specified key.
        /// searches for key value in list
        /// if key exists, adds value to list at key
        /// else, creates new entry with key and new list value
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(string key, T value)
        {
            try
            {
                List<T> list = null;

                if (this._multiMapDictionary.TryGetValue(key, out list))
                {
                    list.Add(value);
                    list.Sort();
                }
                else
                {
                    list = new List<T>();
                    list.Add(value);
                    list.Sort();
                    this._multiMapDictionary[key] = list;
                }
            }
            catch (Exception e)
            {
                string title = "MultimapDictionaryType -> Add(string " + key + ", T " + value.ToString() + ")";
                Utilities.WriteErrorLog(title, e);
            }
        }

        /// <summary>
        /// Find key method
        /// Finds the specified key.
        /// Searches dictionary for key value returns true if successful.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if key found, <c>false</c> otherwise.</returns>
        public bool Find(string key)
        {
            List<T> list;
            bool found = false;

            try
            {
                this._multiMapDictionary.TryGetValue(key, out list);
                if (list != null)
                    found = true;
            }
            catch (Exception e)
            {
                string title = "MultimapDictionaryType -> Find(string " + key + ")";
                Utilities.WriteErrorLog(title, e);
            }

            return found;
        }

        #endregion
    }
}
