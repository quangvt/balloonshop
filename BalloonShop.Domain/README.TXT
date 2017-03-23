1. Logging
- Can log to: Database, Text file, Windows Event Log, Send Mail...
- using: "Throw" statement to propagate exception to higher level
     Data Layer (Log) => Business Layer (if can not process => Throw to next level) => Present Layer (Log)
	 So that: Critial Error (affect to customer) will be logged 2 times.

*For Sending email:
// Configure mail client
SmtpClient smtpClient = new SmtpClient("SMTP server address");
smtpClient.Credentials = new System.Net.NetworkCredential("SMTP user name", ➥
"SMTP password");
// Create the mail message
MailMessage mailMessage = new MailMessage("from", "to", "subject", "body");
// Send mail
smtpClient.Send(mailMessage);

2. DbProviderFactory
=> expect to apply multiple database type


