# Simple HTML mailer
Works With EASendMail

1. SET SETTINGS:

' Set email subject
oMail.Subject = "Mail Subject Here"

' Set email body
oMail.HtmlBody = "Your HTML Content"

' Your SMTP server address
Dim oServer As New SmtpServer("SMTP Server Here")

' User and password for ESMTP authentication
oServer.User = "SMTP Username Here (Most of the time its a E-Mailadress)"
oServer.Password = "Password Here"

2. LOAD EMAILS

3. START SENDING
