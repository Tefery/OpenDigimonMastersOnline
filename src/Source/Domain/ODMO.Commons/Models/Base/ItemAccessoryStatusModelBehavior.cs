using ODMO.Commons.Enums;

namespace ODMO.Commons.Models.Base
{
    public partial class ItemAccessoryStatusModel
    {
        /// <summary>
        /// Sets the status type enumeration.
        /// </summary>
        /// <param name="type"></param>
        public void SetType(AccessoryStatusTypeEnum type) => Type = type;

        /// <summary>
        /// Sets the status value.
        /// </summary>
        /// <param name="value"></param>
        public void SetValue(short value) => Value = value;
    }
}