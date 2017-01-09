﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKotstein.Net.Http.Context
{
    /// <summary>
    /// Encapsulates the header fields of an HTTP request.
    /// </summary>
    public class HttpRequestHeaders
    {
        private IDictionary<string,string> _headers;

        /// <summary>
        /// Constructor
        /// </summary>
        internal HttpRequestHeaders()
        {
            _headers = new Dictionary<string, string>();
        }

        /// <summary>
        /// Checks whether a header field is existing or not.
        /// </summary>
        /// <param name="name">name of the header field</param>
        /// <returns>true or false</returns>
        public bool Has(string name)
        {
            return _headers.ContainsKey(name);
        }

        /// <summary>
        /// Sets a header field
        /// </summary>
        /// <param name="name">name of the header</param>
        /// <param name="value">its value</param>
        /// <returns>true if the field has been created, false if it has already been created before</returns>
        internal bool Set(string name, string value)
        {
            if (Has(name))
            {
                _headers[name] = value;
                return false;
            }
            else
            {
                _headers.Add(name, value);
                return true;
            }
        }
        /// <summary>
        /// Returns the value of a header field or null, if the header field is not exisiting.
        /// </summary>
        /// <param name="name">name of the header</param>
        /// <returns>value of the header or null</returns>
        public string Get(string name)
        {
            if (Has(name))
            {
                return _headers[name];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns a list with existing header field names.
        /// </summary>
        /// <returns>list with header field names</returns>
        public IList<string> GetHeaderNames()
        {
            IList<string> headers = new List<string>();
            foreach(string header in _headers.Keys)
            {
                headers.Add(header);
            }
            return headers;
        }
    }
}
