 Public Sub ShowOdbcException()
     Dim mySelectQuery As String = "SELECT column1 FROM table1"
     Dim myConnection As New OdbcConnection _
        ("DRIVER={SQL Server};SERVER=MyServer;Trusted_connection=yes;DATABASE=northwind;")
     Dim myCommand As New OdbcCommand(mySelectQuery, myConnection)
     Try
         myCommand.Connection.Open()
     Catch e As OdbcException
         Dim errorMessage As String = "Message: " & e.Message & vbCrLf & _
                                      "Source: " & e.Source

        Dim log As System.Diagnostics.EventLog = New System.Diagnostics.EventLog()
        log.Source = "My Application"
        log.WriteEntry(errorMessage)
        Console.WriteLine("An exception occurred. Please contact your system administrator.")
     End Try
 End Sub