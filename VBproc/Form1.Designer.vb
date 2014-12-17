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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.tabCTRL = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnStartSim = New System.Windows.Forms.Button()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPercSave = New System.Windows.Forms.Button()
        Me.txtPercSave = New System.Windows.Forms.TextBox()
        Me.txtDebug = New System.Windows.Forms.TextBox()
        Me.btnExec1 = New System.Windows.Forms.Button()
        Me.btnOpenDialog = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPerc1 = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tabCTRL.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.CheckFileExists = False
        Me.OpenFileDialog2.DefaultExt = "net.xml"
        Me.OpenFileDialog2.FileName = "OpenFileDialog1"
        '
        'tabCTRL
        '
        Me.tabCTRL.Controls.Add(Me.TabPage1)
        Me.tabCTRL.Controls.Add(Me.TabPage2)
        Me.tabCTRL.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabCTRL.Location = New System.Drawing.Point(0, 0)
        Me.tabCTRL.Name = "tabCTRL"
        Me.tabCTRL.SelectedIndex = 0
        Me.tabCTRL.Size = New System.Drawing.Size(791, 399)
        Me.tabCTRL.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.btnStartSim)
        Me.TabPage1.Controls.Add(Me.btnTest)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.btnPercSave)
        Me.TabPage1.Controls.Add(Me.txtPercSave)
        Me.TabPage1.Controls.Add(Me.txtDebug)
        Me.TabPage1.Controls.Add(Me.btnExec1)
        Me.TabPage1.Controls.Add(Me.btnOpenDialog)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtPerc1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(783, 373)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Generale"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Finestra debug"
        '
        'btnStartSim
        '
        Me.btnStartSim.Location = New System.Drawing.Point(621, 68)
        Me.btnStartSim.Name = "btnStartSim"
        Me.btnStartSim.Size = New System.Drawing.Size(109, 49)
        Me.btnStartSim.TabIndex = 18
        Me.btnStartSim.Text = "AVVIA SIMULAZIONE"
        Me.btnStartSim.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(621, 123)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(109, 46)
        Me.btnTest.TabIndex = 17
        Me.btnTest.Text = "TEST DEBUG"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Output"
        '
        'btnPercSave
        '
        Me.btnPercSave.Location = New System.Drawing.Point(577, 66)
        Me.btnPercSave.Name = "btnPercSave"
        Me.btnPercSave.Size = New System.Drawing.Size(25, 19)
        Me.btnPercSave.TabIndex = 15
        Me.btnPercSave.Text = "..."
        Me.btnPercSave.UseVisualStyleBackColor = True
        '
        'txtPercSave
        '
        Me.txtPercSave.Location = New System.Drawing.Point(8, 65)
        Me.txtPercSave.Name = "txtPercSave"
        Me.txtPercSave.Size = New System.Drawing.Size(563, 20)
        Me.txtPercSave.TabIndex = 14
        '
        'txtDebug
        '
        Me.txtDebug.Location = New System.Drawing.Point(8, 123)
        Me.txtDebug.Multiline = True
        Me.txtDebug.Name = "txtDebug"
        Me.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDebug.Size = New System.Drawing.Size(594, 181)
        Me.txtDebug.TabIndex = 13
        '
        'btnExec1
        '
        Me.btnExec1.Location = New System.Drawing.Point(621, 13)
        Me.btnExec1.Name = "btnExec1"
        Me.btnExec1.Size = New System.Drawing.Size(109, 49)
        Me.btnExec1.TabIndex = 12
        Me.btnExec1.Text = "APRI E PROCESSA NETWORK"
        Me.btnExec1.UseVisualStyleBackColor = True
        '
        'btnOpenDialog
        '
        Me.btnOpenDialog.Location = New System.Drawing.Point(577, 27)
        Me.btnOpenDialog.Name = "btnOpenDialog"
        Me.btnOpenDialog.Size = New System.Drawing.Size(25, 19)
        Me.btnOpenDialog.TabIndex = 11
        Me.btnOpenDialog.Text = "..."
        Me.btnOpenDialog.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Percorso file (XML)"
        '
        'txtPerc1
        '
        Me.txtPerc1.Location = New System.Drawing.Point(8, 26)
        Me.txtPerc1.Name = "txtPerc1"
        Me.txtPerc1.Size = New System.Drawing.Size(563, 20)
        Me.txtPerc1.TabIndex = 9
        '
        'TabPage2
        '
        Me.TabPage2.AutoScroll = True
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(783, 373)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Gestione Arrivi"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(533, 68)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 24)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Apri Network"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(387, 52)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(365, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Apri network in SUMO per trovare corrispondenza dei tratti stradali con gli ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(698, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Qui e' possibile specificare il numero di arrivi l'ora per ogni tratto stradale c" & _
    "he si immette sull'intersezione. I valori nelle caselle si intendono in [Veic/h]" & _
    ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 399)
        Me.Controls.Add(Me.tabCTRL)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Form1"
        Me.Text = "Software di prova SimGen in VB"
        Me.tabCTRL.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tabCTRL As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnPercSave As System.Windows.Forms.Button
    Friend WithEvents txtPercSave As System.Windows.Forms.TextBox
    Friend WithEvents txtDebug As System.Windows.Forms.TextBox
    Friend WithEvents btnExec1 As System.Windows.Forms.Button
    Friend WithEvents btnOpenDialog As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPerc1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnStartSim As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
