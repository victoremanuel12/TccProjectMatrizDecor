using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using TccMvc.ViewModel;

namespace TccMvc.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Email()
        {
            var emailViewModel = new EmailViewModel();
            return PartialView("_EmailPartial", emailViewModel);
           
        }
        [HttpPost]
        public IActionResult SendEmail(EmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Montar o email com os dados do formulário
                    string emailBody = $"Nome: {model.Name}\nEmail: {model.Email}\nAssunto: {model.Subject}\nMensagem: {model.Menssage}";

                    // Configurar as credenciais do email
                    string smtpServer = "smtp.live.com";
                    int smtpPort = 587;
                    string smtpUsername = "victoremannuel12@hotmail.com";
                    string smtpPassword = "Victor200306";

                    // Enviar o email
                    using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
                    {
                      
                        smtpClient.EnableSsl = true;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

                        using (MailMessage mailMessage = new MailMessage())
                        {
                            mailMessage.From = new MailAddress(smtpUsername);
                            mailMessage.To.Add("victoremannuel1156@gmail.com"); // Substitua pelo email da empresa
                            mailMessage.Subject = $"{model.Subject}";
                            mailMessage.Body = $"{emailBody}";

                            smtpClient.Send(mailMessage);
                        }
                    }
                    TempData["EmailSendSucess"] = "Email enviado com sucesso!";
                    // Redirecionar para uma página de confirmação ou retornar uma resposta adequada
                    return RedirectToAction("Index", "Home");
                }catch(SmtpException ex)
                {
                    TempData["ErrorAoEnviarEmail"] = "Não foi possivel enviar o email agora, tente mais tarde";
                    return RedirectToAction("Index", "Home");
                }
                

            }
            return RedirectToAction("Index", "Home");

        }
    }
}
