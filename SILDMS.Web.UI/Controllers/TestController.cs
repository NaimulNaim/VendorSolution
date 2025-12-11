using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using SILDMS.Model;

namespace SILDMS.Web.UI.Controllers
{
    public class TestController : Controller
    {
        private const string _BaseURL = "http://172.16.189.34/";
        private const string _ApplicationURL = "api/Email/StoreEMail";

        public async Task<ActionResult> Index()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_BaseURL);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                #region PreparePayload
                List<MessageRequestDTO> messageList = new List<MessageRequestDTO>();
                
                var message = new MessageRequestDTO()
                {
                    ProjectCode = "CBPS-Dev",
                    ProcessName = "CBPS-Dev",
                    MessageSubject = "Test",
                    MessageContent = "Test",
                    MessageFrom = "",
                    MessageTo = "hamza@squaregroup.com",
                    MessageCc = "",
                    MessageBcc = "",
                    TaskType = 3,
                    AttachmentCollection = new List<MessageAttachmentRequestDTO>
                    {
                        //new MessageAttachmentRequestDTO()
                        //{
                        //    AttachmentName = "FileName",
                        //    AttachmentUrl = "FileUrl with FileName",
                        //    AttachmentExtension = "File Extension"
                        //}
                    }
                };

                messageList.Add(message);
                #endregion

                //HttpResponseMessage response = await httpClient.PostAsJsonAsync(_ApplicationURL, messageList);
                HttpResponseMessage response = await httpClient.PostAsync(_ApplicationURL,
                    new StringContent(JsonConvert.SerializeObject(messageList), Encoding.UTF8, "application/json"));
                
                if (response.IsSuccessStatusCode)
                {

                }
            }

            return View();
        }
    }
}