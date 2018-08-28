Imports System.Net

Public Class BoxEngine
    Inherits ContainerControl
    Private g As Graphics
    Private WithEvents tmr As New Timer With {.Enabled = True, .Interval = 1}
    Public Boxs As New List(Of Box)
    Public Comments As New List(Of Comment)
    Public Boxtype As String = "box1"
    Dim sprint As Boolean = False
    Property Inputbox As TextBox
    Private LoginedIn As Boolean = False
    Private loginURL As String = "http://kevinprojects.tk/php/box_login.php"
    Private playersURL As String = "http://kevinprojects.tk/php/box_players.php"
    Private setURL As String = "http://kevinprojects.tk/php/box_set.php"
    Private logoutURL As String = "http://kevinprojects.tk/php/box_logout.php"
    Private costumeURL As String = "http://kevinprojects.tk/php/box_change.php"
    Private nickURL As String = "http://kevinprojects.tk/php/box_nick.php"
    Private commentURL As String = "http://kevinprojects.tk/php/box_comment.php"
    Private playerLocX As Double = 0
    Private playerLocY As Double = 0
    Private Actions As action = action.Idle
    Enum action
        Errorr
        waitLogin
        waitPlayers
        waitMoving
        waitLogout
        Idle
    End Enum
    Property BoxList As Dictionary(Of String, Box)
    Sub New()
        SetStyle(ControlStyles.ContainerControl Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.AllPaintingInWmPaint, True)
    End Sub
    Private Sub RequestPlayerLocations()
        Using playersClient As New Net.WebClient
            AddHandler playersClient.DownloadStringCompleted, AddressOf playersClientDone
            playersClient.DownloadStringAsync(New Uri(playersURL))
        End Using
        Me.Refresh()
    End Sub
    Public Sub cgDrawnBitmap(g As Graphics, Img As Image, rect As Rectangle)
        If Not Img Is Nothing Then
            Using bitmap As New Bitmap(Img)
                g.DrawImage(bitmap, rect)
            End Using
        End If
    End Sub
    Private Sub playersClientDone(sender As Object, e As DownloadStringCompletedEventArgs)
        'Try
        Boxs.Clear()
        Dim src As String() = e.Result.Split(New String() {"{/user}"}, StringSplitOptions.None)
        For Each line As String In src
            If line.Contains("{x}") Then
                Dim uid As String = line.Split(New String() {"{uid}"}, StringSplitOptions.None).Last.Split(New String() {"{/uid}"}, StringSplitOptions.None).First
                Dim x As String = line.Split(New String() {"{x}"}, StringSplitOptions.None).Last.Split(New String() {"{/x}"}, StringSplitOptions.None).First
                Dim y As String = line.Split(New String() {"{y}"}, StringSplitOptions.None).Last.Split(New String() {"{/y}"}, StringSplitOptions.None).First
                Dim boxt As String = line.Split(New String() {"{boxtype}"}, StringSplitOptions.None).Last.Split(New String() {"{/boxtype}"}, StringSplitOptions.None).First
                Dim comment As String = line.Split(New String() {"{Comment}"}, StringSplitOptions.None).Last.Split(New String() {"{/Comment}"}, StringSplitOptions.None).First
                Dim commentT As String = line.Split(New String() {"{CommentT}"}, StringSplitOptions.None).Last.Split(New String() {"{/CommentT}"}, StringSplitOptions.None).First
                Dim tempBox As New Box With {.x = x, .y = y, .UID = uid, .boxtype = boxt}
                Dim tempComment As New Comment With {.Comment = comment, .commentTime = commentT, .UID = uid}
                Dim i As Integer = 0
                Try
                    For Each box3 As Box In Boxs
                        If tempBox.UID = box3.UID Then
                            i += 1
                        End If
                    Next
                Catch ex As Exception

                End Try
                Dim i2 As Integer = 0
                Try
                    For Each comment2 As Comment In Comments
                        If tempComment.commentTime = comment2.commentTime Then
                            i2 += 1
                        End If
                    Next
                Catch ex As Exception

                End Try
                If i = 0 Then
                    Boxs.Add(tempBox)
                End If
                If i2 = 0 Then
                    Comments.Add(tempComment)
                End If
            End If
        Next
        'Catch ex As Exception

        'End Try
        Me.Refresh()
    End Sub
    Public Sub Logout()
        Actions = action.waitLogout
        Using logoutClient As New Net.WebClient
            AddHandler logoutClient.DownloadStringCompleted, AddressOf logoutClientDone
            logoutClient.DownloadStringAsync(New Uri(logoutURL))
        End Using
        Me.Refresh()
    End Sub

    Private Sub logoutClientDone(sender As Object, e As DownloadStringCompletedEventArgs)
        Actions = action.Idle
        Environment.Exit(0)
    End Sub

    Public Sub Login()
        Actions = action.waitLogin
        Using loginClient As New Net.WebClient
            AddHandler loginClient.DownloadStringCompleted, AddressOf loginClientDone
            loginClient.DownloadStringAsync(New Uri(loginURL))
        End Using
        Me.Refresh()
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        g = e.Graphics
        Try
            For Each box2 As Box In Boxs
                If box2.boxtype = "box1" Then
                    cgDrawnBitmap(g, My.Resources.box1, New Rectangle(box2.x, box2.y, 20, 20))
                ElseIf box2.Boxtype = "box2" Then
                    cgDrawnBitmap(g, My.Resources.box2, New Rectangle(box2.x, box2.y, 20, 20))
                ElseIf box2.Boxtype = "box3" Then
                    cgDrawnBitmap(g, My.Resources.box3, New Rectangle(box2.x, box2.y, 20, 20))
                ElseIf box2.Boxtype = "box4" Then
                    cgDrawnBitmap(g, My.Resources.box4, New Rectangle(box2.x, box2.y, 20, 20))
                Else
                    cgDrawnBitmap(g, My.Resources.box1, New Rectangle(box2.x, box2.y, 20, 20))
                End If
                e.Graphics.DrawString(box2.UID, New Font("Arial", 9, FontStyle.Regular), Brushes.Black, New Rectangle(box2.x - 12, box2.y - 12, 50, 12))
            Next
        Catch ex As Exception

        End Try
        Try
            Dim i As Integer = 0
            For Each comment As Comment In Comments
                g.DrawString(comment.UID & ":" & comment.Comment, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, New Rectangle(0, 15 * i, Me.Width / 3, Me.Height / 3))
                i += 1
            Next
        Catch ex As Exception

        End Try
        If Boxtype = "box1" Then
            cgDrawnBitmap(g, My.Resources.box1, New Rectangle(playerLocX, playerLocY, 20, 20))
        ElseIf Boxtype = "box2" Then
            cgDrawnBitmap(g, My.Resources.box2, New Rectangle(playerLocX, playerLocY, 20, 20))
        ElseIf Boxtype = "box3" Then
            cgDrawnBitmap(g, My.Resources.box3, New Rectangle(playerLocX, playerLocY, 20, 20))
        ElseIf Boxtype = "box4" Then
            cgDrawnBitmap(g, My.Resources.box4, New Rectangle(playerLocX, playerLocY, 20, 20))
        Else
            cgDrawnBitmap(g, My.Resources.box1, New Rectangle(playerLocX, playerLocY, 20, 20))
        End If
        g.FillRectangle(Brushes.Red, New Rectangle(0, Me.Height - 6, sprinti + 1, 5))
        g.DrawRectangle(Pens.Black, New Rectangle(0, Me.Height - 6, 100, 5))
    End Sub
    Private Sub loginClientDone(sender As Object, e As DownloadStringCompletedEventArgs)
        If e.Result.Substring(0, 1) = "2" Or e.Result.Substring(0, 1) = "1" Then
            LoginedIn = True
            tmr.Enabled = True
            Dim x As String = e.Result.Split(New String() {"{x}"}, StringSplitOptions.None).Last.Split(New String() {"{/x}"}, StringSplitOptions.None).First
            Dim y As String = e.Result.Split(New String() {"{y}"}, StringSplitOptions.None).Last.Split(New String() {"{/y}"}, StringSplitOptions.None).First
            Dim boxt As String = e.Result.Split(New String() {"{boxtype}"}, StringSplitOptions.None).Last.Split(New String() {"{/boxtype}"}, StringSplitOptions.None).First
            playerLocX = x
            playerLocY = y
            Boxtype = boxt
            Actions = action.Idle
            Me.Refresh()
        Else
            Actions = action.Errorr
        End If
    End Sub
    Public Sub PostComment(str As String)

        Using commentClient As New Net.WebClient
            AddHandler commentClient.DownloadStringCompleted, AddressOf commentClientDone
            commentClient.Headers.Add("comment", str)
            commentClient.DownloadStringAsync(New Uri(commentURL))
        End Using
        Dim tempComment As New Comment With {.UID = "You", .Comment = str, .commentTime = TimeOfDay}
        Comments.Add(tempComment)
        Me.Refresh()
    End Sub

    Private Sub commentClientDone(sender As Object, e As DownloadStringCompletedEventArgs)
        Me.Refresh()
    End Sub

    Public Sub ChangeName(name As String)
        Using nameClient As New Net.WebClient
            AddHandler nameClient.DownloadStringCompleted, AddressOf nameClientDone
            nameClient.Headers.Add("nick", name)
            nameClient.DownloadStringAsync(New Uri(nickURL))
        End Using
        Me.Refresh()
    End Sub
    Public Sub ChangeCostume(name As String)
        Using costumClient As New Net.WebClient
            AddHandler costumClient.DownloadStringCompleted, AddressOf costumClientDone
            costumClient.Headers.Add("custom", name)
            costumClient.DownloadStringAsync(New Uri(costumeURL))
        End Using
        Me.Refresh()
    End Sub

    Private Sub costumClientDone(sender As Object, e As DownloadStringCompletedEventArgs)
        Me.Refresh()
    End Sub

    Private Sub nameClientDone(sender As Object, e As DownloadStringCompletedEventArgs)
        Me.Refresh()
    End Sub

    Private Sub SendMyLocation()
        If Actions = action.Idle Then
            Actions = action.waitMoving
            Using setClient As New Net.WebClient
                AddHandler setClient.DownloadStringCompleted, AddressOf setClientDone
                setClient.Headers.Add("xloc", playerLocX.ToString)
                setClient.Headers.Add("yloc", playerLocY.ToString)
                setClient.DownloadStringAsync(New Uri(setURL))
            End Using
            Me.Refresh()
        End If
    End Sub
    Dim mUp As Boolean
    Dim mDown As Boolean
    Dim mRight As Boolean
    Dim mLeft As Boolean
    Private Sub setClientDone(sender As Object, e As DownloadStringCompletedEventArgs)
        If e.Result = "1" Then
            Actions = action.Idle
        Else
            Actions = action.Errorr
        End If
    End Sub
    Dim sprintmax As Integer = 100
    Dim sprinti As Integer = 0
    Private Sub tmr_Tick(sender As Object, e As EventArgs) Handles tmr.Tick
        If LoginedIn Then
            If sprint = False Or sprinti >= sprintmax Then
                If mUp Then
                    playerLocY -= 0.5
                    Me.Refresh()
                    If curClockSend >= clocksend Then
                        SendMyLocation()
                    End If
                End If
                If mDown Then
                    playerLocY += 0.5
                    Me.Refresh()
                    If curClockSend >= clocksend Then
                        SendMyLocation()
                    End If
                End If
                If mLeft And mUp = False And mDown = False Then
                    playerLocX -= 0.5
                    Me.Refresh()
                    If curClockSend >= clocksend Then
                        SendMyLocation()
                    End If
                End If
                If mRight And mUp = False And mDown = False Then
                    playerLocX += 0.5
                    Me.Refresh()
                    If curClockSend >= clocksend Then
                        SendMyLocation()
                    End If
                End If
            ElseIf sprint And sprinti < sprintmax Then
                sprinti += 1
                Debug.WriteLine(sprinti.ToString)
                If mUp Then
                    playerLocY -= 1
                    Me.Refresh()
                    If curClockSend >= clocksend Then
                        SendMyLocation()
                    End If
                End If
                If mDown Then
                    playerLocY += 1
                    Me.Refresh()
                    If curClockSend >= clocksend Then
                        SendMyLocation()
                    End If
                End If
                If mLeft And mUp = False And mDown = False Then
                    playerLocX -= 1
                    Me.Refresh()
                    If curClockSend >= clocksend Then
                        SendMyLocation()
                    End If
                End If
                If mRight And mUp = False And mDown = False Then
                    playerLocX += 1
                    Me.Refresh()
                    If curClockSend >= clocksend Then
                        SendMyLocation()
                    End If
                End If
            End If
            If sprint = False And Not sprinti = 0 Then
                sprinti -= 1
            End If
            If curClockSend >= clocksend Then
                RequestPlayerLocations()
                curClockSend = 0
            Else
                curClockSend += 1
            End If
        End If
    End Sub

    Private Sub BoxEngine_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'MsgBox("ye")
        If e.KeyCode = Keys.A Then
            mLeft = True
        End If
        If e.KeyCode = Keys.D Then
            mRight = True
        End If
        If e.KeyCode = Keys.W Then
            mUp = True
        End If
        If e.KeyCode = Keys.S Then
            mDown = True
        End If
        If e.KeyCode = Keys.ShiftKey Then
            sprint = True
        End If
        If e.KeyCode = Keys.T Then
            Inputbox.Visible = True
            Inputbox.Focus()
        End If
    End Sub
    Dim clocksend As Integer = 10
    Dim curClockSend As Integer = 0
    Private Sub BoxEngine_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.A Then
            mLeft = False
        End If
        If e.KeyCode = Keys.D Then
            mRight = False
        End If
        If e.KeyCode = Keys.W Then
            mUp = False
        End If
        If e.KeyCode = Keys.S Then
            mDown = False
        End If
        If e.KeyCode = Keys.ShiftKey Then
            sprint = False
        End If
    End Sub

    Private Sub BoxEngine_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus

    End Sub
End Class
Public Class Box
    Public x As Integer
    Public y As Integer
    Public UID As String
    Public boxtype As String
End Class
Public Class Comment
    Public UID As String
    Public Comment As String
    Public commentTime As String
End Class