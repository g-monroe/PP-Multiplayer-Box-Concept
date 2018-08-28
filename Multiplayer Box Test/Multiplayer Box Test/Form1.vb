Imports System.ComponentModel
Imports System.Net

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        BoxEngine1.Login()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        BoxEngine1.Logout()
        e.Cancel = True

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BoxEngine1.Login()
    End Sub
    Dim txtbox As TextBox = TextBox1
    Private Sub BoxEngine1_Click(sender As Object, e As EventArgs) Handles BoxEngine1.Click
        TextBox1.Visible = False
        BoxEngine1.Focus()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text.Substring(0, 1) = "/" Then
                Try
                    If TextBox1.Text.Substring(0, 5) = "/nick" And TextBox1.Text.Contains(" ") Then
                        BoxEngine1.ChangeName(TextBox1.Text.Split(" ").Last)
                    End If
                    If TextBox1.Text.Substring(0, 4) = "/box" And TextBox1.Text.Contains(" ") Then
                        Dim costume As String = TextBox1.Text.Split(" ").Last
                        If costume = "box1" Then
                            BoxEngine1.Boxtype = costume
                            BoxEngine1.ChangeCostume(costume)
                        ElseIf costume = "box2" Then
                            BoxEngine1.Boxtype = costume
                            BoxEngine1.ChangeCostume(costume)
                        ElseIf costume = "box3" Then
                            BoxEngine1.Boxtype = costume
                            BoxEngine1.ChangeCostume(costume)
                        ElseIf costume = "box4" Then
                            BoxEngine1.Boxtype = costume
                            BoxEngine1.ChangeCostume(costume)
                        End If
                    End If
                Catch ex As Exception
                End Try
            Else
                BoxEngine1.PostComment(TextBox1.Text)
            End If

            TextBox1.Visible = False
            TextBox1.Text = ""
            BoxEngine1.Focus()
        End If
    End Sub
End Class
