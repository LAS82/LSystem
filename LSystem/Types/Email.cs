using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LSystem.Types
{
    /// <summary>
    /// Structure to store an email address
    /// </summary>
    [DebuggerDisplay("Address = {Address}")]
    public struct Email
    {
        #region [Constructor]

        /// <summary>
        /// Alternative constructor that already receives an address
        /// </summary>
        /// <param name="address">Email address</param>
        public Email(string address) : this()
        {
            Address = address;
        }

        #endregion

        #region [Properties]

        public string _address { get; set; }
        /// <summary>
        /// Stores the address
        /// </summary>
        public string Address {
            get
            {
                return _address;
            }

            set 
            {
                if (value != null)
                    _address = value.Trim();
                else
                    throw new ArgumentException("Email address cannot be set to null", "address");
            } 
        }

        /// <summary>
        /// Check whether the email is valid.
        /// </summary>
        public bool IsValid {
            get
            {
                return 
                    Regex.IsMatch(
                        Address, 
                        @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", 
                        RegexOptions.IgnoreCase
                    );
            }
        }

        #endregion

        #region [Static Methods]

        /// <summary>
        /// Compares two addresses
        /// </summary>
        /// <param name="lEmail">Email</param>
        /// <param name="rEmail">Email</param>
        /// <returns>Comparison result</returns>
        public static bool operator ==(Email lEmail, Email rEmail)
        {
            return Email.CheckEmailsAreEqual(lEmail, rEmail);
        }

        /// <summary>
        /// Compares two addresses
        /// </summary>
        /// <param name="lEmail">Email</param>
        /// <param name="rEmail">Email</param>
        /// <returns>Comparison result</returns>
        public static bool operator !=(Email lEmail, Email rEmail)
        {
            return !Email.CheckEmailsAreEqual(lEmail, rEmail);
        }

        /// <summary>
        /// Check if both email addresses are equal.
        /// </summary>
        /// <param name="lEmail">Email</param>
        /// <param name="rEmail">Email</param>
        /// <returns>Comparison result</returns>
        private static bool CheckEmailsAreEqual(Email lEmail, Email rEmail)
        {
            bool lEmailAddressIsNull = lEmail.CheckAddressIsNull();
            bool rEmailAddressIsNull = rEmail.CheckAddressIsNull();

            if (lEmailAddressIsNull && rEmailAddressIsNull)
                return true;

            if (lEmailAddressIsNull || rEmailAddressIsNull)
                return false;

            return lEmail.Address.ToLower() == rEmail.Address.ToLower();
        }

        #endregion

        #region [Public Methods]

        /// <summary>
        /// Calls the base equals.
        /// </summary>
        /// <param name="obj">Object to compare</param>
        /// <returns>Comparison result</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// Returns the email address.
        /// </summary>
        /// <returns>Email address</returns>
        public override string ToString()
        {
            return Address;
        }

        /// <summary>
        /// Returns the hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            if (this.CheckAddressIsNull())
                return base.GetHashCode();

            return Address.GetHashCode();
        }

        #endregion

        #region [Private Methods]

        /// <summary>
        /// Checks if the address was not yet set
        /// </summary>
        /// <returns>Result</returns>
        private bool CheckAddressIsNull()
        {
            return this.Address == null;
        }

        #endregion

    }
}
