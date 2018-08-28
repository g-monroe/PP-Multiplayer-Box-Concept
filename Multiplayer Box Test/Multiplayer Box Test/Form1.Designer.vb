<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.BoxEngine1 = New Multiplayer_Box_Test.BoxEngine()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BoxEngine1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'BoxEngine1
        '
        Me.BoxEngine1.BoxList = Nothing
        Me.BoxEngine1.Controls.Add(Me.TextBox1)
        Me.BoxEngine1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BoxEngine1.Inputbox = Me.TextBox1
        Me.BoxEngine1.Location = New System.Drawing.Point(0, 0)
        Me.BoxEngine1.Name = "BoxEngine1"
        Me.BoxEngine1.Size = New System.Drawing.Size(704, 441)
        Me.BoxEngine1.TabIndex = 1
        Me.BoxEngine1.Text = "BoxEngine1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(535, 418)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(166, 20)
        Me.TextBox1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 441)
        Me.Controls.Add(Me.BoxEngine1)
        Me.Name = "Form1"
        Me.Text = "wda"
        Me.BoxEngine1.ResumeLayout(False)
        Me.BoxEngine1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents BoxEngine1 As BoxEngine
    Friend WithEvents TextBox1 As TextBox
End Class
