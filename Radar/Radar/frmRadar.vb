Option Strict On

Public Class frmRadar

    Private Sub frmRadar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        lstSpeed.Items.Clear()
        lblAverage.Text = ""
        btnEnterSpeed.Enabled = True

    End Sub

    Private Sub btnEnterSpeed_Click(sender As System.Object, e As System.EventArgs) Handles btnEnterSpeed.Click
        Dim strSpeed As String
        Dim decSpeed As Decimal
        Dim decTotalSpeeds As Decimal = 0
        Dim decAverage As Decimal
        Dim strInputMessage As String = "Enter the speed for vehicle #"
        Dim strInputHeading As String = "Radar Speed"
        Dim strNormalMessage As String = "Error - Enter the speed for vehicle #"
        Dim strNonNumericError As String = "Error - Enter a number for the speed of vehicle #"
        Dim strNegativeError As String = "Error - Enter a posetive number for vihicle #"

        Dim strCancelClicked As String = ""
        Dim intMaxNumberOfEntries As Integer = 10
        Dim intNumberOfEntries As Integer = 1

        strSpeed = InputBox(strInputMessage & intNumberOfEntries, strInputHeading, " ")
        Do Until intNumberOfEntries > intMaxNumberOfEntries Or strSpeed = strCancelClicked
            If IsNumeric(strSpeed) Then
                decSpeed = Convert.ToDecimal(strSpeed)
                If decSpeed > 0 Then
                    lstSpeed.Items.Add(decSpeed)
                    decTotalSpeeds += decSpeed
                    intNumberOfEntries += 1
                    strInputMessage = strNormalMessage
                Else
                    strInputMessage = strNegativeError
                End If
            Else
                strInputMessage = strNonNumericError
            End If
            If intNumberOfEntries <= intMaxNumberOfEntries Then
                strSpeed = InputBox(strInputMessage & intNumberOfEntries, strInputHeading, " ")
            End If
        Loop
        lblAverage.Visible = True

        If intNumberOfEntries > 1 Then
            decAverage = decTotalSpeeds / (intNumberOfEntries - 1)
            lblAverage.Text = "Average speed at checkpoint is" & decAverage.ToString("F1") & " mph"
        Else
            lblAverage.Text = "No speed entered"
        End If
        btnEnterSpeed.Enabled = False
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ClearToolStripMenuItem.Click

        lstSpeed.Items.Clear()
        lblAverage.Text = ""
        btnEnterSpeed.Enabled = True

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Close()

    End Sub

    Private Sub EnterSpeedToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EnterSpeedToolStripMenuItem.Click
        btnEnterSpeed_Click(Nothing, e)
    End Sub
End Class
