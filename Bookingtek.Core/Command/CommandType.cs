using System;

namespace Bookingtek.Core.Command
{
    public enum CommandType
    {
        [StringValue("C")]
        C=1,
        [StringValue("L")]
        L =2,
        [StringValue("R")]
        R =3,
        [StringValue("Q")]
        Q =4
    }
    public class StringValueAttribute : Attribute
    {

        #region Properties

        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }

        #endregion

    }
}
