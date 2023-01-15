using System.Text.Json.Serialization;

namespace Tema.Models.DTOs.TransferOwnership
{
    public class TransferOwnershipDTO : ITransferOwnershipDTO
    {
        public string CurrentOwnerEmail { get; set; }
        public string NewOwnerEmail { get; set; }

        [JsonConstructor]
        public TransferOwnershipDTO() { }
    }
}
