using Application.Contarcts;
using Application.DTOs;

namespace Document_API.API.Contacts
{
    public class DocumentErrorMessage : ErrorMessage<DocumentDTO>
    {
        public DocumentErrorMessage(string code, string message, DocumentDTO contract) : base(code, message, contract)
        {
        }
    }
}
