using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoffingDesign.Service.Models.Contact;
using DoffingDesign.Service.Models.MailChimp;
using iSynaptic.Commons;

namespace DoffingDesign.Service
{
    public interface INewsletterService
    {
        Task<Result<SubscribeOkResponse, SubscribeErrorResponse>> Subscribe(BasicInformation information);
    }
}
