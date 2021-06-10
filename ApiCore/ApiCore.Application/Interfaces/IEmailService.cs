using ApiCore.Application.DTOs.Email;
using System.Threading.Tasks;

namespace ApiCore.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
