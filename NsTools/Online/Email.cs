using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace NsTools.Online
{
    class Email
    {
        protected SmtpClient _smtpClient;
        private string _host { get; set; }
        private int _port { get; set; }
        private MailAddress _from;
        private MailAddress _to;
        private NetworkCredential _netCred;
        private string _userName { get; set; }
        private string _userPassword { get; set; }
        private MailMessage _mailMessage { get; set; }
        private string _subject { get; set; }
        private string _body { get; set; }
        private Attachment _attachment;
        private string _attachmentFilePath;
        public Email(string host, int port, string userName, string userPassword, string from, string to, string subject, string body, string attachmentFilePath)
        {
            _host = host;
            _port = port;
            _userName = userName;
            _attachmentFilePath = attachmentFilePath;
            _userPassword = userPassword;
            _from = new MailAddress(from);
            _to = new MailAddress(to);
            _mailMessage = new MailMessage(_from, _to);
            _mailMessage.Subject = subject;
            _mailMessage.Body = body;
            _attachment = new Attachment(_attachmentFilePath, MediaTypeNames.Application.Octet);
            _mailMessage.Attachments.Add(_attachment);
            _netCred = new NetworkCredential(userName, userPassword);
            
        }
        public void Sending()
        {
            _smtpClient = new SmtpClient();
            _smtpClient.Host = _host;
            _smtpClient.Credentials = _netCred;
            _smtpClient.Port = _port;
            _smtpClient.Send(_mailMessage);


        }

    }
}
