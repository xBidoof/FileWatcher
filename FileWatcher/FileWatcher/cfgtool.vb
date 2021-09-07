﻿Imports System.IO
Public Class cfgtool
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox1.ReadOnly = False
        Else
            TextBox1.ReadOnly = True
        End If
    End Sub

    Private Sub cfgtool_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dlg As New FolderBrowserDialog()
        If dlg.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = dlg.SelectedPath
        Else

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Directory.Exists(TextBox1.Text) Then
            MessageBox.Show("This folder exists !", "Check folder")
        Else
            MessageBox.Show("This folder does not exist !", "Check folder")
        End If
    End Sub
End Class