using Fatec.LabEngSoftIII.Zhang.Api.Utils;
using System.Net;
using System.Net.Mail;

namespace Fatec.LabEngSoftIII.Zhang.API.Utils
{
    public class Email
    {
        private string _usuario { get; set; }
        private string _senha { get; set; }

        public Email()
        {
            Config config = new Config();
            this._usuario = config.Email;
            this._senha = config.SenhaEmail;
        }
        public void EnviarEmail(string para, string assunto, string mensagem)
        {
            var fromAddress = new MailAddress(this._usuario, "Envio Automático");
            var toAddress = new MailAddress(para);


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, this._senha)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = assunto,
                Body = mensagem,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }
    }
}
