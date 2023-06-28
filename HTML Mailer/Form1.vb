''Imports System.Net.Mail
Imports System.IO
Imports EASendMail
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            Dim oMail As New SmtpMail("TryIt")


            ' Set sender email address, please change it to yours
            oMail.From = "From Name (Emailadress or Name)"
            ' Set recipient email address, please change it to yours
            oMail.To = ListBox1.Items(0).ToString


            If CheckBox1.Checked = True Then
                oMail.ReadReceipt = True

            End If

            ' Set email subject
            oMail.Subject = "Mail Subject Here"
            ' Set email body
            oMail.HtmlBody = ""

            ' Your SMTP server address
            Dim oServer As New SmtpServer("SMTP Server Here")

            ' User and password for ESMTP authentication
            oServer.User = "SMTP Username Here (Most of the time its a E-Mailadress)"
            oServer.Password = "Password Here"

            ' Set SSL 465 port
            oServer.Port = 465

            ' Set direct SSL connection, you can also use ConnectSSLAuto
            oServer.ConnectType = SmtpConnectType.ConnectDirectSSL
            oServer.DeliveryNotification = DeliveryNotificationOptions.OnSuccess
            oServer.DeliveryNotification = DeliveryNotificationOptions.OnFailure

            Console.WriteLine("start to send email ...")

            Dim oSmtp As New SmtpClient()
            oSmtp.SendMail(oServer, oMail)

            Console.WriteLine("email was sent successfully!")

            ListBox1.Items.RemoveAt(0)
            ToolStripStatusLabel2.Text = "Mail succesfully send"

        Catch ep As Exception
            Console.WriteLine("failed to send email with the following error:")
            Console.WriteLine(ep.Message)
            ToolStripStatusLabel2.Text = "Mail send failed"

        End Try







    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click



        Dim openfile = New OpenFileDialog()
        openfile.Filter = "Text (*.txt)|*.txt"
        If (openfile.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            Dim myfile As String = openfile.FileName
            Dim allLines As String() = File.ReadAllLines(myfile)
            For Each line As String In allLines
                ListBox1.Items.Add(line)
            Next
        End If



    End Sub
End Class
