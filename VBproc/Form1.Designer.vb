<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtPerc1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnOpenDialog = New System.Windows.Forms.Button()
        Me.btnExec1 = New System.Windows.Forms.Button()
        Me.txtDebug = New System.Windows.Forms.TextBox()
        Me.btnPercSave = New System.Windows.Forms.Button()
        Me.txtPercSave = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtPerc1
        '
        Me.txtPerc1.Location = New System.Drawing.Point(15, 25)
        Me.txtPerc1.Name = "txtPerc1"
        Me.txtPerc1.Size = New System.Drawing.Size(563, 20)
        Me.txtPerc1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Percorso file (XML)"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnOpenDialog
        '
        Me.btnOpenDialog.Location = New System.Drawing.Point(584, 26)
        Me.btnOpenDialog.Name = "btnOpenDialog"
        Me.btnOpenDialog.Size = New System.Drawing.Size(25, 19)
        Me.btnOpenDialog.TabIndex = 2
        Me.btnOpenDialog.Text = "..."
        Me.btnOpenDialog.UseVisualStyleBackColor = True
        '
        'btnExec1
        '
        Me.btnExec1.Location = New System.Drawing.Point(628, 12)
        Me.btnExec1.Name = "btnExec1"
        Me.btnExec1.Size = New System.Drawing.Size(109, 46)
        Me.btnExec1.TabIndex = 3
        Me.btnExec1.Text = "EXEC"
        Me.btnExec1.UseVisualStyleBackColor = True
        '
        'txtDebug
        '
        Me.txtDebug.Location = New System.Drawing.Point(15, 95)
        Me.txtDebug.Multiline = True
        Me.txtDebug.Name = "txtDebug"
        Me.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDebug.Size = New System.Drawing.Size(597, 181)
        Me.txtDebug.TabIndex = 4
        '
        'btnPercSave
        '
        Me.btnPercSave.Location = New System.Drawing.Point(584, 65)
        Me.btnPercSave.Name = "btnPercSave"
        Me.btnPercSave.Size = New System.Drawing.Size(25, 19)
        Me.btnPercSave.TabIndex = 6
        Me.btnPercSave.Text = "..."
        Me.btnPercSave.UseVisualStyleBackColor = True
        '
        'txtPercSave
        '
        Me.txtPercSave.Location = New System.Drawing.Point(15, 64)
        Me.txtPercSave.Name = "txtPercSave"
        Me.txtPercSave.Size = New System.Drawing.Size(563, 20)
        Me.txtPercSave.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Output"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.CheckFileExists = False
        Me.OpenFileDialog2.DefaultExt = "net.xml"
        Me.OpenFileDialog2.FileName = "OpenFileDialog1"
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(628, 65)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(109, 46)
        Me.btnTest.TabIndex = 8
        Me.btnTest.Text = "TEST"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 313)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnPercSave)
        Me.Controls.Add(Me.txtPercSave)
        Me.Controls.Add(Me.txtDebug)
        Me.Controls.Add(Me.btnExec1)
        Me.Controls.Add(Me.btnOpenDialog)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPerc1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Form1"
        Me.Text = "Software di prova SimGen in VB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPerc1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnOpenDialog As System.Windows.Forms.Button
    Friend WithEvents btnExec1 As System.Windows.Forms.Button
    Friend WithEvents txtDebug As System.Windows.Forms.TextBox
    Friend WithEvents btnPercSave As System.Windows.Forms.Button
    Friend WithEvents txtPercSave As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnTest As System.Windows.Forms.Button

End Class
