using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
