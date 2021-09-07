Imports System.IO

Public Class Form1

    Dim WatchedAut As Boolean = False
    Private Sub FileSystemWatcher1_Changed(sender As Object, e As IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed
        If WatchedAut = True Then
            Dim getFolderPath As String = e.FullPath
            Dim JustGetFolderParent As String = Path.GetDirectoryName(getFolderPath)
            For i As Integer = 0 To cfgtool.RichTextBox1.Lines.Count - 1
                If cfgtool.RichTextBox1.Lines(i) = JustGetFolderParent Then
                    Return
                End If
            Next
            Invoke(New MethodInvoker(Sub() RichTextBox1.AppendText("A file has been changed !" & Chr(13) & "==================================" & Chr(13) & ">>> Name: " & e.Name & Chr(13) & ">>> Change Type: " & e.ChangeType & Chr(13) & ">>> Full Path: " & e.FullPath & Chr(13) & "==================================" & Chr(13) & Chr(13))))
        End If
    End Sub
    Private Sub FileSystemWatcher1_Created(sender As Object, e As FileSystemEventArgs) Handles FileSystemWatcher1.Created
        If WatchedAut = True Then
            Dim getFolderPath As String = e.FullPath
            Dim JustGetFolderParent As String = Path.GetDirectoryName(getFolderPath)
            For i As Integer = 0 To cfgtool.RichTextBox1.Lines.Count - 1
                If cfgtool.RichTextBox1.Lines(i) = JustGetFolderParent Then
                    Return
                End If
            Next
            Invoke(New MethodInvoker(Sub() RichTextBox1.AppendText("A new file has been created !" & Chr(13) & "==================================" & Chr(13) & ">>> Name: " & e.Name & Chr(13) & ">>> Change Type: " & e.ChangeType & Chr(13) & ">>> Full Path: " & e.FullPath & Chr(13) & "==================================" & Chr(13) & Chr(13))))
        End If
    End Sub

    Private Sub FileSystemWatcher1_Deleted(sender As Object, e As FileSystemEventArgs) Handles FileSystemWatcher1.Deleted
        If WatchedAut = True Then
            Dim getFolderPath As String = e.FullPath
            Dim JustGetFolderParent As String = Path.GetDirectoryName(getFolderPath)
            For i As Integer = 0 To cfgtool.RichTextBox1.Lines.Count - 1
                If cfgtool.RichTextBox1.Lines(i) = JustGetFolderParent Then
                    Return
                End If
            Next
            Invoke(New MethodInvoker(Sub() RichTextBox1.AppendText("A file has been delete !" & Chr(13) & "==================================" & Chr(13) & ">>> Name: " & e.Name & Chr(13) & ">>> Change Type: " & e.ChangeType & Chr(13) & ">>> Full Path: " & e.FullPath & Chr(13) & "==================================" & Chr(13) & Chr(13))))
        End If
    End Sub

    Private Sub FileSystemWatcher1_Renamed(sender As Object, e As RenamedEventArgs) Handles FileSystemWatcher1.Renamed
        If WatchedAut = True Then
            Dim getFolderPath As String = e.FullPath
            Dim JustGetFolderParent As String = Path.GetDirectoryName(getFolderPath)
            For i As Integer = 0 To cfgtool.RichTextBox1.Lines.Count - 1
                If cfgtool.RichTextBox1.Lines(i) = JustGetFolderParent Then
                    Return
                End If
            Next
            Invoke(New MethodInvoker(Sub() RichTextBox1.AppendText("A file has been renamed !" & Chr(13) & "==================================" & Chr(13) & ">>> Name: " & e.Name & Chr(13) & ">>> Old Name: " & e.OldName & Chr(13) & ">>> Change Type: " & e.ChangeType & Chr(13) & ">>> Full Path: " & e.FullPath & Chr(13) & ">>> Old Full Path: " & e.OldFullPath & Chr(13) & "==================================" & Chr(13) & Chr(13))))
        End If
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        cfgtool.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Clear()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Startlistening()
        Else
            WatchedAut = False
            RichTextBox1.AppendText("Listening was stopped !" & Chr(13))
            CheckBox2.Enabled = True
        End If
    End Sub

    Sub Startlistening()
        If Directory.Exists(cfgtool.TextBox1.Text) Then
            RichTextBox1.AppendText("Listening started !" & Chr(13) & "Target: " & cfgtool.TextBox1.Text & Chr(13) & "listening..." & Chr(13))
            FileSystemWatcher1.Path = cfgtool.TextBox1.Text
            WatchedAut = True
            If CheckBox2.Checked = True Then
                FileSystemWatcher1.IncludeSubdirectories = True
            Else
                FileSystemWatcher1.IncludeSubdirectories = False
            End If
            CheckBox2.Enabled = False
        Else
            RichTextBox1.AppendText("Listening started !" & Chr(13) & "ERROR ! target folder cannot be found !" & Chr(13))
            CheckBox1.Checked = False
            WatchedAut = False
            CheckBox2.Enabled = True
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            Me.TopMost = True
        Else
            Me.TopMost = False
        End If
    End Sub
End Class
