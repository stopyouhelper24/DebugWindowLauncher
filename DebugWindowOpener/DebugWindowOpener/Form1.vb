Public Class Form1
    Public MajerVersion As String = Nothing
    Public MinorVersion As String = Nothing
    Public PatchVersion As String = Nothing
    Public BuildVersion As String = Nothing

    Public Sub LoadCVData()
        Dim VersionString As String = Nothing
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\VersionManager.dll") Then
            DoVersion()
        ElseIf My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Sebs SW CV.exe") Then
            Try
                Dim UIForm As New CV.UI
                MajerVersion = UIForm.MajerVersion
                MinorVersion = UIForm.MinorVersion
                PatchVersion = UIForm.PatchVersion
                BuildVersion = UIForm.BuildVersion
                Label2.Text = UIForm.MinorVersion
                Label1.Text = "[" & UIForm.MajerVersion & "." & UIForm.MinorVersion & "." & UIForm.PatchVersion & "." & UIForm.BuildVersion & "]"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Failed to find the need data.")
        End If
    End Sub

    Private Sub DoVersion()
        Try
            Dim Int1 As Int64 = 0
            Int1 = VersionManager.VersionContainer.GetVersionInt(1)
            Dim Int2 As Int64 = 0
            Int2 = VersionManager.VersionContainer.GetVersionInt(2)
            Dim Int3 As Int64 = 0
            Int3 = VersionManager.VersionContainer.GetVersionInt(3)
            Dim Int4 As Int64 = 0
            Int4 = VersionManager.VersionContainer.GetVersionInt(4)
            If Int4 < 456 Then
                MsgBox("The ""VersionManager.dll"" contains a older version data, then what this program supports.")
            End If
            Label2.Text = Int2.ToString
            Label1.Text = "[" & Int1.ToString & "." & Int2.ToString & "." & Int3.ToString & "." & Int4.ToString & "]"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadCVData()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCVData()
        If My.Settings.DebugTools = True Then
            Button4.Visible = True
            Button5.Visible = True
            Label2.Visible = True
        End If
    End Sub

    Public Form47 As Form
    Public ProgramTester As Form
    Public A_Test_Thing As Form

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Sebs SW CV.exe") Then
            Try
                Form47 = New CV.Form47
                Form47.Show()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub LoadProgramTester()
        Try
            ProgramTester = New CV.ProgramTester
            ProgramTester.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadA_Test_Thing()
        Try
            A_Test_Thing = New CV.A_Test_Thing
            A_Test_Thing.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Sebs SW CV.exe") Then

            Dim jj As String = Nothing
            If Label2.Text = "0" Then
                'Does not exist in this version
            ElseIf Label2.Text = "1" Then
                LoadA_Test_Thing()
            ElseIf Label2.Text = "2" Then
                LoadA_Test_Thing()
            ElseIf Label2.Text = "3" Then
                LoadA_Test_Thing()
            ElseIf Label2.Text = "4" Then
                'This does not have any leak of it's exe
            ElseIf Label2.Text = "5" Then
                LoadProgramTester()
            ElseIf Label2.Text = "6" Then
                LoadProgramTester()
            End If
            'MsgBox(MinorVersion)
        End If
    End Sub

    Public UI As Object

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            UI = New CV.UI
            MajerVersion = UI.MajerVersion
            MinorVersion = UI.MinorVersion
            PatchVersion = UI.PatchVersion
            BuildVersion = UI.BuildVersion
            Label2.Text = UI.MinorVersion
            Label1.Text = "[" & UI.MajerVersion & "." & UI.MinorVersion & "." & UI.PatchVersion & "." & UI.BuildVersion & "]"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Label1.Text = "[3.1.2.284]"
        Label2.Text = "1"
    End Sub
End Class
