using System.Runtime.Serialization;

namespace Server_API.Models.Entity
{
    public enum Status
    {
        [EnumMember(Value = "PAID")]
        PAID,
        [EnumMember(Value = "NOTPAID")]
        NOTPAID,
    }
}
