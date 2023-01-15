namespace Tema.Models.DTOs.TransferOwnership
{
    public interface ITransferOwnershipDTO
    {
        string CurrentOwnerEmail { get; set; }
        string NewOwnerEmail { get; set; }
    }
}
