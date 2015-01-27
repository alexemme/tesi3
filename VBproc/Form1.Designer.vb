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
        Me.txtName = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.btnPercSUMO = New System.Windows.Forms.Button()
        Me.txtPercSUMO = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtSimDurata = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtLunghTronchi = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.chkGUI = New System.Windows.Forms.CheckBox()
        Me.btnConvertOSM = New System.Windows.Forms.Button()
        Me.btnPercOSM = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtPercOSM = New System.Windows.Forms.TextBox()
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
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbVeic = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnAddVeic = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDeleteVeic = New System.Windows.Forms.Button()
        Me.btnSaveVeic = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbVeicType = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtVelMax = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSigma = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMinGap = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtLenght = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtDecel = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAcc = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtVeicName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lstVeicoli = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnGiu = New System.Windows.Forms.Button()
        Me.btnSu = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtPhaseDur = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblPhaseNum = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.lblConnTitle = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.btnDelPhase = New System.Windows.Forms.Button()
        Me.btnSavePhase = New System.Windows.Forms.Button()
        Me.lstFasi = New System.Windows.Forms.ListView()
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCampiona = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtPercCSV2 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtPercCSV1 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.OpenFileDialog3 = New System.Windows.Forms.OpenFileDialog()
        Me.OpenFileDialog4 = New System.Windows.Forms.OpenFileDialog()
        Me.txtName.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
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
        'txtName
        '
        Me.txtName.Controls.Add(Me.TabPage1)
        Me.txtName.Controls.Add(Me.TabPage2)
        Me.txtName.Controls.Add(Me.TabPage3)
        Me.txtName.Controls.Add(Me.TabPage4)
        Me.txtName.Controls.Add(Me.TabPage5)
        Me.txtName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtName.Location = New System.Drawing.Point(0, 0)
        Me.txtName.Name = "txtName"
        Me.txtName.SelectedIndex = 0
        Me.txtName.Size = New System.Drawing.Size(791, 399)
        Me.txtName.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label33)
        Me.TabPage1.Controls.Add(Me.btnPercSUMO)
        Me.TabPage1.Controls.Add(Me.txtPercSUMO)
        Me.TabPage1.Controls.Add(Me.Label31)
        Me.TabPage1.Controls.Add(Me.txtSimDurata)
        Me.TabPage1.Controls.Add(Me.Label32)
        Me.TabPage1.Controls.Add(Me.Label30)
        Me.TabPage1.Controls.Add(Me.txtLunghTronchi)
        Me.TabPage1.Controls.Add(Me.Label29)
        Me.TabPage1.Controls.Add(Me.chkGUI)
        Me.TabPage1.Controls.Add(Me.btnConvertOSM)
        Me.TabPage1.Controls.Add(Me.btnPercOSM)
        Me.TabPage1.Controls.Add(Me.Label27)
        Me.TabPage1.Controls.Add(Me.txtPercOSM)
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
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(8, 5)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(164, 13)
        Me.Label33.TabIndex = 37
        Me.Label33.Text = "Percorso del simulatore sumo.exe"
        '
        'btnPercSUMO
        '
        Me.btnPercSUMO.Location = New System.Drawing.Point(580, 21)
        Me.btnPercSUMO.Name = "btnPercSUMO"
        Me.btnPercSUMO.Size = New System.Drawing.Size(25, 19)
        Me.btnPercSUMO.TabIndex = 36
        Me.btnPercSUMO.Text = "..."
        Me.btnPercSUMO.UseVisualStyleBackColor = True
        '
        'txtPercSUMO
        '
        Me.txtPercSUMO.Location = New System.Drawing.Point(11, 21)
        Me.txtPercSUMO.Name = "txtPercSUMO"
        Me.txtPercSUMO.Size = New System.Drawing.Size(563, 20)
        Me.txtPercSUMO.TabIndex = 35
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(555, 165)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(47, 13)
        Me.Label31.TabIndex = 34
        Me.Label31.Text = "secondi."
        '
        'txtSimDurata
        '
        Me.txtSimDurata.Location = New System.Drawing.Point(477, 162)
        Me.txtSimDurata.Name = "txtSimDurata"
        Me.txtSimDurata.Size = New System.Drawing.Size(72, 20)
        Me.txtSimDurata.TabIndex = 33
        Me.txtSimDurata.Text = "3600"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(372, 165)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(99, 13)
        Me.Label32.TabIndex = 32
        Me.Label32.Text = "Durata simulazione:"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(244, 165)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(32, 13)
        Me.Label30.TabIndex = 31
        Me.Label30.Text = "metri."
        '
        'txtLunghTronchi
        '
        Me.txtLunghTronchi.Location = New System.Drawing.Point(197, 162)
        Me.txtLunghTronchi.Name = "txtLunghTronchi"
        Me.txtLunghTronchi.Size = New System.Drawing.Size(41, 20)
        Me.txtLunghTronchi.TabIndex = 30
        Me.txtLunghTronchi.Text = "50"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(8, 165)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(183, 13)
        Me.Label29.TabIndex = 29
        Me.Label29.Text = "Uniforma lunghezza tronchi stradali a:"
        '
        'chkGUI
        '
        Me.chkGUI.AutoSize = True
        Me.chkGUI.Location = New System.Drawing.Point(671, 122)
        Me.chkGUI.Name = "chkGUI"
        Me.chkGUI.Size = New System.Drawing.Size(94, 17)
        Me.chkGUI.TabIndex = 28
        Me.chkGUI.Text = "Visualizza GUI"
        Me.chkGUI.UseVisualStyleBackColor = True
        '
        'btnConvertOSM
        '
        Me.btnConvertOSM.Location = New System.Drawing.Point(508, 59)
        Me.btnConvertOSM.Name = "btnConvertOSM"
        Me.btnConvertOSM.Size = New System.Drawing.Size(97, 19)
        Me.btnConvertOSM.TabIndex = 27
        Me.btnConvertOSM.Text = "Converti in XML"
        Me.btnConvertOSM.UseVisualStyleBackColor = True
        '
        'btnPercOSM
        '
        Me.btnPercOSM.Location = New System.Drawing.Point(477, 59)
        Me.btnPercOSM.Name = "btnPercOSM"
        Me.btnPercOSM.Size = New System.Drawing.Size(25, 19)
        Me.btnPercOSM.TabIndex = 26
        Me.btnPercOSM.Text = "..."
        Me.btnPercOSM.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(8, 42)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(133, 13)
        Me.Label27.TabIndex = 25
        Me.Label27.Text = "Percorso file mappa (OSM)"
        '
        'txtPercOSM
        '
        Me.txtPercOSM.Location = New System.Drawing.Point(11, 58)
        Me.txtPercOSM.Name = "txtPercOSM"
        Me.txtPercOSM.Size = New System.Drawing.Size(460, 20)
        Me.txtPercOSM.TabIndex = 24
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 193)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Info:"
        '
        'btnStartSim
        '
        Me.btnStartSim.Enabled = False
        Me.btnStartSim.Location = New System.Drawing.Point(666, 61)
        Me.btnStartSim.Name = "btnStartSim"
        Me.btnStartSim.Size = New System.Drawing.Size(109, 49)
        Me.btnStartSim.TabIndex = 18
        Me.btnStartSim.Text = "AVVIA SIMULAZIONE"
        Me.btnStartSim.UseVisualStyleBackColor = True
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(666, 319)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(109, 46)
        Me.btnTest.TabIndex = 17
        Me.btnTest.Text = "TEST DEBUG"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Output (XML)"
        '
        'btnPercSave
        '
        Me.btnPercSave.Location = New System.Drawing.Point(580, 136)
        Me.btnPercSave.Name = "btnPercSave"
        Me.btnPercSave.Size = New System.Drawing.Size(25, 19)
        Me.btnPercSave.TabIndex = 15
        Me.btnPercSave.Text = "..."
        Me.btnPercSave.UseVisualStyleBackColor = True
        '
        'txtPercSave
        '
        Me.txtPercSave.Location = New System.Drawing.Point(11, 136)
        Me.txtPercSave.Name = "txtPercSave"
        Me.txtPercSave.Size = New System.Drawing.Size(563, 20)
        Me.txtPercSave.TabIndex = 14
        '
        'txtDebug
        '
        Me.txtDebug.Location = New System.Drawing.Point(11, 209)
        Me.txtDebug.Multiline = True
        Me.txtDebug.Name = "txtDebug"
        Me.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDebug.Size = New System.Drawing.Size(594, 158)
        Me.txtDebug.TabIndex = 13
        '
        'btnExec1
        '
        Me.btnExec1.Location = New System.Drawing.Point(666, 6)
        Me.btnExec1.Name = "btnExec1"
        Me.btnExec1.Size = New System.Drawing.Size(109, 49)
        Me.btnExec1.TabIndex = 12
        Me.btnExec1.Text = "APRI E PROCESSA NETWORK"
        Me.btnExec1.UseVisualStyleBackColor = True
        '
        'btnOpenDialog
        '
        Me.btnOpenDialog.Location = New System.Drawing.Point(580, 98)
        Me.btnOpenDialog.Name = "btnOpenDialog"
        Me.btnOpenDialog.Size = New System.Drawing.Size(25, 19)
        Me.btnOpenDialog.TabIndex = 11
        Me.btnOpenDialog.Text = "..."
        Me.btnOpenDialog.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Percorso file (XML)"
        '
        'txtPerc1
        '
        Me.txtPerc1.Location = New System.Drawing.Point(11, 97)
        Me.txtPerc1.Name = "txtPerc1"
        Me.txtPerc1.Size = New System.Drawing.Size(563, 20)
        Me.txtPerc1.TabIndex = 9
        '
        'TabPage2
        '
        Me.TabPage2.AutoScroll = True
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.cmbVeic)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(783, 373)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Gestione Arrivi/Destinazioni"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 22)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(76, 13)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "Tipo di veicolo"
        '
        'cmbVeic
        '
        Me.cmbVeic.FormattingEnabled = True
        Me.cmbVeic.Location = New System.Drawing.Point(109, 19)
        Me.cmbVeic.Name = "cmbVeic"
        Me.cmbVeic.Size = New System.Drawing.Size(145, 21)
        Me.cmbVeic.TabIndex = 6
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
        Me.Label3.Size = New System.Drawing.Size(634, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Qui e' possibile specificare il numero di arrivi l'ora per ogni tipologia di veic" & _
    "olo e per ogni tratto stradale che si immette sull'intersezione. "
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnAddVeic)
        Me.TabPage3.Controls.Add(Me.Panel1)
        Me.TabPage3.Controls.Add(Me.lstVeicoli)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(783, 373)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Gestione veicoli"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnAddVeic
        '
        Me.btnAddVeic.Location = New System.Drawing.Point(681, 253)
        Me.btnAddVeic.Name = "btnAddVeic"
        Me.btnAddVeic.Size = New System.Drawing.Size(94, 35)
        Me.btnAddVeic.TabIndex = 23
        Me.btnAddVeic.Text = "Aggiungi Veicolo"
        Me.btnAddVeic.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnDeleteVeic)
        Me.Panel1.Controls.Add(Me.btnSaveVeic)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.cmbVeicType)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.txtVelMax)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.txtSigma)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtMinGap)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtLenght)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtDecel)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtAcc)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtVeicName)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(5, 253)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(649, 119)
        Me.Panel1.TabIndex = 3
        Me.Panel1.Visible = False
        '
        'btnDeleteVeic
        '
        Me.btnDeleteVeic.Location = New System.Drawing.Point(545, 65)
        Me.btnDeleteVeic.Name = "btnDeleteVeic"
        Me.btnDeleteVeic.Size = New System.Drawing.Size(80, 35)
        Me.btnDeleteVeic.TabIndex = 23
        Me.btnDeleteVeic.Text = "ELIMINA"
        Me.btnDeleteVeic.UseVisualStyleBackColor = True
        '
        'btnSaveVeic
        '
        Me.btnSaveVeic.Location = New System.Drawing.Point(545, 13)
        Me.btnSaveVeic.Name = "btnSaveVeic"
        Me.btnSaveVeic.Size = New System.Drawing.Size(80, 35)
        Me.btnSaveVeic.TabIndex = 22
        Me.btnSaveVeic.Text = "SALVA"
        Me.btnSaveVeic.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(253, 87)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(76, 13)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "Tipo di veicolo"
        '
        'cmbVeicType
        '
        Me.cmbVeicType.FormattingEnabled = True
        Me.cmbVeicType.Items.AddRange(New Object() {"Automobile", "Bus/Mezzo pesante"})
        Me.cmbVeicType.Location = New System.Drawing.Point(333, 83)
        Me.cmbVeicType.Name = "cmbVeicType"
        Me.cmbVeicType.Size = New System.Drawing.Size(119, 21)
        Me.cmbVeicType.TabIndex = 20
        Me.cmbVeicType.Text = "Automobile"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(395, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(25, 13)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "m/s"
        '
        'txtVelMax
        '
        Me.txtVelMax.Location = New System.Drawing.Point(333, 34)
        Me.txtVelMax.Name = "txtVelMax"
        Me.txtVelMax.Size = New System.Drawing.Size(56, 20)
        Me.txtVelMax.TabIndex = 17
        Me.txtVelMax.Text = "30"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(253, 37)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 13)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Velocità max"
        '
        'txtSigma
        '
        Me.txtSigma.Location = New System.Drawing.Point(333, 8)
        Me.txtSigma.Name = "txtSigma"
        Me.txtSigma.Size = New System.Drawing.Size(56, 20)
        Me.txtSigma.TabIndex = 15
        Me.txtSigma.Text = "0.5"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(253, 11)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 13)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Sigma"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(395, 61)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(15, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "m"
        '
        'txtMinGap
        '
        Me.txtMinGap.Location = New System.Drawing.Point(333, 58)
        Me.txtMinGap.Name = "txtMinGap"
        Me.txtMinGap.Size = New System.Drawing.Size(56, 20)
        Me.txtMinGap.TabIndex = 12
        Me.txtMinGap.Text = "0.5"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(253, 61)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(62, 13)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Gap minimo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(145, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "m"
        '
        'txtLenght
        '
        Me.txtLenght.Location = New System.Drawing.Point(83, 84)
        Me.txtLenght.Name = "txtLenght"
        Me.txtLenght.Size = New System.Drawing.Size(56, 20)
        Me.txtLenght.TabIndex = 9
        Me.txtLenght.Text = "5"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Lunghezza"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(145, 61)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "m/s^2"
        '
        'txtDecel
        '
        Me.txtDecel.Location = New System.Drawing.Point(83, 58)
        Me.txtDecel.Name = "txtDecel"
        Me.txtDecel.Size = New System.Drawing.Size(56, 20)
        Me.txtDecel.TabIndex = 6
        Me.txtDecel.Text = "4.5"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 61)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Decelerazione"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(145, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "m/s^2"
        '
        'txtAcc
        '
        Me.txtAcc.Location = New System.Drawing.Point(83, 32)
        Me.txtAcc.Name = "txtAcc"
        Me.txtAcc.Size = New System.Drawing.Size(56, 20)
        Me.txtAcc.TabIndex = 3
        Me.txtAcc.Text = "0.8"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Accelerazione"
        '
        'txtVeicName
        '
        Me.txtVeicName.Location = New System.Drawing.Point(83, 8)
        Me.txtVeicName.Name = "txtVeicName"
        Me.txtVeicName.Size = New System.Drawing.Size(99, 20)
        Me.txtVeicName.TabIndex = 1
        Me.txtVeicName.Text = "Auto1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Nome"
        '
        'lstVeicoli
        '
        Me.lstVeicoli.BackColor = System.Drawing.SystemColors.Window
        Me.lstVeicoli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lstVeicoli.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstVeicoli.HideSelection = False
        Me.lstVeicoli.Location = New System.Drawing.Point(3, 27)
        Me.lstVeicoli.MultiSelect = False
        Me.lstVeicoli.Name = "lstVeicoli"
        Me.lstVeicoli.Size = New System.Drawing.Size(772, 220)
        Me.lstVeicoli.TabIndex = 2
        Me.lstVeicoli.UseCompatibleStateImageBehavior = False
        Me.lstVeicoli.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Nome"
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Accelerazione"
        Me.ColumnHeader2.Width = 86
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Decelerazione"
        Me.ColumnHeader3.Width = 83
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Lunghezza"
        Me.ColumnHeader4.Width = 66
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Gap minimo con gli altri veicoli"
        Me.ColumnHeader5.Width = 154
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Sigma"
        Me.ColumnHeader6.Width = 49
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Velocita max"
        Me.ColumnHeader7.Width = 76
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Tipo veicolo"
        Me.ColumnHeader8.Width = 74
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(269, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Veicoli impostati   (doppio click per modificare/eliminare)"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Panel2)
        Me.TabPage4.Controls.Add(Me.lstFasi)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(783, 373)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Diagramma fasatura"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnGiu)
        Me.Panel2.Controls.Add(Me.btnSu)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.txtPhaseDur)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.lblPhaseNum)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.RadioButton4)
        Me.Panel2.Controls.Add(Me.RadioButton3)
        Me.Panel2.Controls.Add(Me.RadioButton2)
        Me.Panel2.Controls.Add(Me.lblConnTitle)
        Me.Panel2.Controls.Add(Me.RadioButton1)
        Me.Panel2.Controls.Add(Me.btnDelPhase)
        Me.Panel2.Controls.Add(Me.btnSavePhase)
        Me.Panel2.Location = New System.Drawing.Point(3, 201)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(772, 164)
        Me.Panel2.TabIndex = 4
        Me.Panel2.Visible = False
        '
        'btnGiu
        '
        Me.btnGiu.Location = New System.Drawing.Point(662, 128)
        Me.btnGiu.Name = "btnGiu"
        Me.btnGiu.Size = New System.Drawing.Size(91, 22)
        Me.btnGiu.TabIndex = 38
        Me.btnGiu.Text = "SPOSTA GIU"
        Me.btnGiu.UseVisualStyleBackColor = True
        '
        'btnSu
        '
        Me.btnSu.Location = New System.Drawing.Point(662, 99)
        Me.btnSu.Name = "btnSu"
        Me.btnSu.Size = New System.Drawing.Size(91, 23)
        Me.btnSu.TabIndex = 37
        Me.btnSu.Text = "SPOSTA SU"
        Me.btnSu.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(672, 73)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(69, 20)
        Me.Button2.TabIndex = 36
        Me.Button2.Text = "NUOVA"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtPhaseDur
        '
        Me.txtPhaseDur.Location = New System.Drawing.Point(74, 52)
        Me.txtPhaseDur.Name = "txtPhaseDur"
        Me.txtPhaseDur.Size = New System.Drawing.Size(49, 20)
        Me.txtPhaseDur.TabIndex = 35
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 55)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(65, 13)
        Me.Label26.TabIndex = 34
        Me.Label26.Text = "Durata fase:"
        '
        'lblPhaseNum
        '
        Me.lblPhaseNum.AutoSize = True
        Me.lblPhaseNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhaseNum.Location = New System.Drawing.Point(98, 11)
        Me.lblPhaseNum.Name = "lblPhaseNum"
        Me.lblPhaseNum.Size = New System.Drawing.Size(25, 25)
        Me.lblPhaseNum.TabIndex = 33
        Me.lblPhaseNum.Text = "1"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(209, 11)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(205, 13)
        Me.Label25.TabIndex = 32
        Me.Label25.Text = "Click su connessione per modificare stato:"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(-1, 10)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(83, 13)
        Me.Label24.TabIndex = 31
        Me.Label24.Text = "Modifica fase n°"
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(501, 94)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(55, 17)
        Me.RadioButton4.TabIndex = 30
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "Rosso"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(501, 71)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(51, 17)
        Me.RadioButton3.TabIndex = 29
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Giallo"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(501, 51)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(53, 17)
        Me.RadioButton2.TabIndex = 28
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Verde"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'lblConnTitle
        '
        Me.lblConnTitle.AutoSize = True
        Me.lblConnTitle.Location = New System.Drawing.Point(498, 10)
        Me.lblConnTitle.Name = "lblConnTitle"
        Me.lblConnTitle.Size = New System.Drawing.Size(136, 13)
        Me.lblConnTitle.TabIndex = 27
        Me.lblConnTitle.Text = "-121677292 -> -184817924"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(501, 28)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(97, 17)
        Me.RadioButton1.TabIndex = 26
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Verde + Priorità"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'btnDelPhase
        '
        Me.btnDelPhase.Location = New System.Drawing.Point(672, 43)
        Me.btnDelPhase.Name = "btnDelPhase"
        Me.btnDelPhase.Size = New System.Drawing.Size(70, 24)
        Me.btnDelPhase.TabIndex = 23
        Me.btnDelPhase.Text = "ELIMINA"
        Me.btnDelPhase.UseVisualStyleBackColor = True
        '
        'btnSavePhase
        '
        Me.btnSavePhase.Enabled = False
        Me.btnSavePhase.Location = New System.Drawing.Point(672, 16)
        Me.btnSavePhase.Name = "btnSavePhase"
        Me.btnSavePhase.Size = New System.Drawing.Size(69, 21)
        Me.btnSavePhase.TabIndex = 22
        Me.btnSavePhase.Text = "SALVA"
        Me.btnSavePhase.UseVisualStyleBackColor = True
        '
        'lstFasi
        '
        Me.lstFasi.BackColor = System.Drawing.SystemColors.Window
        Me.lstFasi.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader9, Me.ColumnHeader10})
        Me.lstFasi.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstFasi.HideSelection = False
        Me.lstFasi.Location = New System.Drawing.Point(3, 3)
        Me.lstFasi.MultiSelect = False
        Me.lstFasi.Name = "lstFasi"
        Me.lstFasi.Size = New System.Drawing.Size(777, 192)
        Me.lstFasi.TabIndex = 3
        Me.lstFasi.UseCompatibleStateImageBehavior = False
        Me.lstFasi.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "N°"
        Me.ColumnHeader9.Width = 31
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Durata"
        Me.ColumnHeader10.Width = 57
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Label28)
        Me.TabPage5.Controls.Add(Me.txtCampiona)
        Me.TabPage5.Controls.Add(Me.Label21)
        Me.TabPage5.Controls.Add(Me.txtPercCSV2)
        Me.TabPage5.Controls.Add(Me.Label23)
        Me.TabPage5.Controls.Add(Me.txtPercCSV1)
        Me.TabPage5.Controls.Add(Me.Label22)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(783, 373)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Impostazioni Variabili Output"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(677, 28)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(46, 13)
        Me.Label28.TabIndex = 30
        Me.Label28.Text = "Secondi"
        '
        'txtCampiona
        '
        Me.txtCampiona.Location = New System.Drawing.Point(615, 25)
        Me.txtCampiona.Name = "txtCampiona"
        Me.txtCampiona.Size = New System.Drawing.Size(56, 20)
        Me.txtCampiona.TabIndex = 29
        Me.txtCampiona.Text = "10"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(512, 28)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(83, 13)
        Me.Label21.TabIndex = 28
        Me.Label21.Text = "Campiona ogni :"
        '
        'txtPercCSV2
        '
        Me.txtPercCSV2.Enabled = False
        Me.txtPercCSV2.Location = New System.Drawing.Point(8, 64)
        Me.txtPercCSV2.Name = "txtPercCSV2"
        Me.txtPercCSV2.Size = New System.Drawing.Size(477, 20)
        Me.txtPercCSV2.TabIndex = 27
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 48)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(239, 13)
        Me.Label23.TabIndex = 26
        Me.Label23.Text = "Output simulazione , informazioni sui veicoli (CSV)"
        '
        'txtPercCSV1
        '
        Me.txtPercCSV1.Enabled = False
        Me.txtPercCSV1.Location = New System.Drawing.Point(8, 25)
        Me.txtPercCSV1.Name = "txtPercCSV1"
        Me.txtPercCSV1.Size = New System.Drawing.Size(477, 20)
        Me.txtPercCSV1.TabIndex = 25
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(8, 9)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(329, 13)
        Me.Label22.TabIndex = 24
        Me.Label22.Text = "Output simulazione ,campionamenti intersezione semaforizzata (CSV)"
        '
        'OpenFileDialog3
        '
        Me.OpenFileDialog3.FileName = "OpenFileDialog3"
        '
        'OpenFileDialog4
        '
        Me.OpenFileDialog4.FileName = "OpenFileDialog4"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 399)
        Me.Controls.Add(Me.txtName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Form1"
        Me.Text = "Simulatore di intersezioni semaforizzate semplici"
        Me.txtName.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtName As System.Windows.Forms.TabControl
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
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents lstVeicoli As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAddVeic As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnDeleteVeic As System.Windows.Forms.Button
    Friend WithEvents btnSaveVeic As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cmbVeicType As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtVelMax As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSigma As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMinGap As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtLenght As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtDecel As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAcc As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtVeicName As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmbVeic As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnDelPhase As System.Windows.Forms.Button
    Friend WithEvents btnSavePhase As System.Windows.Forms.Button
    Friend WithEvents lstFasi As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblConnTitle As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents txtPhaseDur As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents lblPhaseNum As System.Windows.Forms.Label
    Friend WithEvents btnSu As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnGiu As System.Windows.Forms.Button
    Friend WithEvents chkGUI As System.Windows.Forms.CheckBox
    Friend WithEvents btnConvertOSM As System.Windows.Forms.Button
    Friend WithEvents btnPercOSM As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtPercOSM As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtCampiona As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtPercCSV2 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtPercCSV1 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtLunghTronchi As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents txtSimDurata As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog3 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents btnPercSUMO As System.Windows.Forms.Button
    Friend WithEvents txtPercSUMO As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog4 As System.Windows.Forms.OpenFileDialog

End Class
