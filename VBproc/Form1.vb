Imports System.IO
Imports System.Xml

Public Class Form1
    Dim AppStatus As Short = 0
    'status 0 = FILE NON CARICATO
    '1= FILE CARICATO

    Dim sumopath As String = ""
    Dim filepath As String
    Dim filename1 As String
    Dim fileINI As String
    Dim ODstdNode As XmlDocument = New XmlDocument() ' qui salvo il nodo veicType standard , in modo da non doverlo rigenerare successivamente
    '->salvo tutto il documento per sicurezza.

    Dim tab3Action As Short = 0 ' qui ho una flag che mi indica quale azione sto svolgendo sulla tab3
    Dim tab3Tag As String = "" ' qui segno dati che potrebbero essere utili per la gestione delle azioni 
    Dim tab2Action As Short = 0 ' indica se e' stato modificato qualche valore oppure no
    Dim tab2Tag As Short = 0 ' indico l'indice precedente del cmbVeic 
    'se action=1 segno l'id del nodo da modificare

    Public connSelez As Short = -1

    Public Sub SalvaSetts()
        SaveSetting("VBproc", "PercFiles", "xml1", txtPerc1.Text)
        SaveSetting("VBproc", "PercFiles", "xml2", txtPercSave.Text)
        SaveSetting("VBproc", "PercFiles", "xml3", txtPercOSM.Text)
        SaveSetting("VBproc", "PercFiles", "xml4", txtPercSUmo.Text)
        SaveSetting("VBproc", "Sett", "laneLen", txtLunghTronchi.Text)
        SaveSetting("VBproc", "Sett", "simDur", txtSimDurata.Text)
        SaveSetting("VBproc", "Sett", "Samples", txtCampiona.Text)
        Dim checksett As Boolean
        If chkGUI.Checked = True Then
            checksett = True
        Else
            checksett = False
        End If
        SaveSetting("VBproc", "Sett", "guiCheck", checksett)
    End Sub
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'evento unload form
        SalvaSetts()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPerc1.Text = GetSetting("VBproc", "PercFiles", "xml1")
        txtPercSave.Text = GetSetting("VBproc", "PercFiles", "xml2")
        txtPercOSM.Text = GetSetting("VBproc", "PercFiles", "xml3")
        txtCampiona.Text = GetSetting("VBproc", "Sett", "Samples")
        txtLunghTronchi.Text = GetSetting("VBproc", "Sett", "laneLen")
        txtSimDurata.Text = GetSetting("VBproc", "Sett", "simDur")
        txtPercSUMO.Text = GetSetting("VBproc", "PercFiles", "xml4")

        Dim checksett As String = GetSetting("VBproc", "Sett", "guiCheck")
        If checksett <> "" Then
            If checksett = True Then
                chkGUI.Checked = True
            Else
                chkGUI.Checked = False
            End If
        End If
        filepath = Path.GetDirectoryName(txtPercSave.Text)
        filename1 = Path.GetFileNameWithoutExtension(txtPercSave.Text)
        fileINI = filepath & "/" & filename1 & ".simcfg"



    End Sub
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        txtPerc1.Text = OpenFileDialog1.FileName
        SalvaSetts()
    End Sub
    Private Sub btnOpenDialog_Click(sender As Object, e As EventArgs) Handles btnOpenDialog.Click
        OpenFileDialog1.ShowDialog()
    End Sub
    Private Sub btnPercSave_Click(sender As Object, e As EventArgs) Handles btnPercSave.Click
        OpenFileDialog2.ShowDialog()
    End Sub
    Private Sub btnPercOSM_Click(sender As Object, e As EventArgs) Handles btnPercOSM.Click
        OpenFileDialog3.ShowDialog()
    End Sub
    Private Sub OpenFileDialog2_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk
        txtPercSave.Text = OpenFileDialog2.FileName
        SalvaSetts()
    End Sub
    Private Sub OpenFileDialog3_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog3.FileOk
        txtPercOSM.Text = OpenFileDialog3.FileName
        SalvaSetts()
    End Sub
    Private Sub btnExec1_Click(sender As Object, e As EventArgs) Handles btnExec1.Click
        btnExec1.Enabled = False
        'leggo il file xml
        'prova?
        '   Try
        Dim filepath As String = Path.GetDirectoryName(txtPercSave.Text)
        Dim filename As String = Path.GetFileNameWithoutExtension(txtPercSave.Text)
        txtPercCSV1.Text = filepath & "/" & filename & ".OUTcampionamenti.csv"
        txtPercCSV2.Text = filepath & "/" & filename & ".OUTinfoVeic.csv"
        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node, m_node1 As XmlNode
        Dim m_net As XmlNode
        Dim lunghezzaTronchi As Short = txtLunghTronchi.Text

        'Create il documento (vuoto)
        m_xmld = New XmlDocument()
        'Carico il file XML della rete
        m_xmld.Load(txtPerc1.Text) ' carico il percorso della textbox
        'Leggo i nodi che mi interessano
        m_nodelist = m_xmld.SelectNodes("net/junction")
        m_net = m_xmld.SelectSingleNode("net")
        'Controllo tutti i nodi letti
        For Each m_node In m_nodelist
            'Get the Gender Attribute Value
            Dim includeLanes = m_node.Attributes.GetNamedItem("incLanes").Value
            Dim junctype = m_node.Attributes.GetNamedItem("type").Value
            If junctype = "priority" Or junctype = "traffic_light" Then  'se la junction non e' di tipo internal 
                Dim links() As String = includeLanes.Split(" ")
                If links.Count > 2 Then ' sto processando l'incrocio principale
                    'se l'id della linea e' indicato con - allora la strada proviene dall'alto verso il basso o da 
                    'destra verso sinistra
                    'arrivato qui ho individuato l' incrocio di interesse
                    'elimino i junction che non mi servono

                    'recupero dati sulle possibili svolte
                    Dim buffLincJ(links.Length - 1) As String
                    Dim contaElem As Short = 0
                    Dim connlist As XmlNodeList
                    connlist = m_xmld.SelectNodes("net/connection")
                    Dim rouNUM As Short = 0
                    For i = 0 To links.Length - 1 'devo prendere solo le strade senza tener conto del numero di linea
                        'di cui si occupera' automaticamente il simulator
                        Dim flagF As Boolean = False
                        Dim s() As String = links(i).Split("_")
                        For t = 0 To links.Length - 1
                            If buffLincJ(t) = s(0) Then
                                flagF = True
                                Exit For
                            End If
                        Next
                        If flagF = False Then
                            buffLincJ(contaElem) = s(0) 'salvo l'ordine delle lanes per trovare una corrispondenza
                            contaElem += 1
                        End If

                    Next
                    ReDim listaIncLanesJunction(contaElem - 1)
                    For i = 0 To contaElem - 1
                        listaIncLanesJunction(i) = buffLincJ(i)
                    Next

                    Dim buffListaConn(connlist.Count - 1) As String
                    Dim numConn As Short
                    For Each m_connNode In connlist
                        Dim fromAttr = m_connNode.Attributes.GetNamedItem("from").Value
                        Dim toAttr = m_connNode.Attributes.GetNamedItem("to").Value
                        Dim stateAttr = m_connNode.Attributes.GetNamedItem("state").Value
                        Dim fromLane As Short = m_connNode.Attributes.GetNamedItem("fromLane").Value
                        Dim toLane As Short = m_connNode.Attributes.GetNamedItem("toLane").Value
                        If stateAttr = "o" Then ' devo includerlo nel file ROU.XML , 
                            'devo escludere le connessioni che rappresentano le stesse svolte su corsie diverse
                            Dim flagF As Boolean = False
                            For i = 0 To numConn - 1
                                If buffListaConn(i) = fromAttr & toAttr Then
                                    flagF = True
                                    Exit For
                                End If
                            Next
                            If flagF = False Then
                                buffListaConn(numConn) = fromAttr & toAttr
                                numConn += 1
                                TrovaCorrispondenzaLineaPercorso(fromAttr, toAttr, rouNUM, fromLane, toLane) 'trova corrispondenza con l' ID della linea della junction
                                'aggiungo le voci della tabella in TAB4
                                lstFasi.Columns.Add(rouNUM.ToString, 25, HorizontalAlignment.Left)
                                'aggiungo gli elementi label 
                                generaLabelFasi(fromAttr & " -> " & toAttr)
                                rouNUM += 1
                            End If
                        End If
                    Next

                    'salvo le origini destinazioni delle varie strade nel file di configurazione , nella tab infine riapro
                    ' il file 
                    'creo il file di impostazione con informazioni sui tipi di veicoli e sugli arrivi/destinazioni.
                    'Sotto gestione dei veicoli riapro questo file invece di ricreare le impostazioni
                    'saveXMLconfig(fileINI, "prova", 10.33453, 0.6)

                    Dim fileINIexists As Boolean = False
                    If Not System.IO.File.Exists(fileINI) Then
                        System.IO.File.Create(fileINI).Dispose()
                    Else
                        fileINIexists = True
                    End If
                    'salvo il file come un XML per mantenere lo stile del progetto e avere maggiore flessibilita'
                    Dim m_xmld2 As XmlDocument = New XmlDocument()
                    'Dim prova1 As XmlNode = m_xmld.CreateXmlDeclaration("1.0", "UTF-8", "")
                    'm_xmld.AppendChild(prova1)

                    Dim cfgNode As XmlNode = m_xmld2.CreateElement("cfgVeic") ' creo nodo di configurazione principale
                    m_xmld2.AppendChild(cfgNode)

                    Dim VeicNode As XmlNode = m_xmld2.CreateElement("vType") ' per ogni tipo di veicolo 
                    Dim veicAttribute1 As XmlAttribute = m_xmld2.CreateAttribute("id") ' scrivo gli attributi
                    veicAttribute1.Value = "Standard_Auto"
                    VeicNode.Attributes.Append(veicAttribute1)
                    Dim veicAttribute As XmlAttribute = m_xmld2.CreateAttribute("accel") ' scrivo gli attributi
                    veicAttribute.Value = "0.8"
                    VeicNode.Attributes.Append(veicAttribute)
                    veicAttribute = m_xmld2.CreateAttribute("decel") ' scrivo gli attributi
                    veicAttribute.Value = "4,5"
                    VeicNode.Attributes.Append(veicAttribute)
                    veicAttribute = m_xmld2.CreateAttribute("sigma")
                    veicAttribute.Value = "0.5"
                    VeicNode.Attributes.Append(veicAttribute)
                    veicAttribute = m_xmld2.CreateAttribute("length")
                    veicAttribute.Value = "5"
                    VeicNode.Attributes.Append(veicAttribute)
                    veicAttribute = m_xmld2.CreateAttribute("minGap")
                    veicAttribute.Value = "0.5"
                    VeicNode.Attributes.Append(veicAttribute)
                    veicAttribute = m_xmld2.CreateAttribute("maxSpeed")
                    veicAttribute.Value = "30"
                    VeicNode.Attributes.Append(veicAttribute)
                    veicAttribute = m_xmld2.CreateAttribute("guiShape")
                    veicAttribute.Value = "0"
                    VeicNode.Attributes.Append(veicAttribute)



                    Dim toIDELEM As XmlNode
                    For i = 0 To listaIncLanesJunction.Length - 1
                        generaBoxArrivi(listaIncLanesJunction(i))
                        Dim ADinfo As XmlNode = m_xmld2.CreateElement("trafficInfo")
                        Dim loadAttr As XmlAttribute = m_xmld2.CreateAttribute("trafficLoad")
                        loadAttr.Value = "100"
                        ADinfo.Attributes.Append(loadAttr)
                        VeicNode.AppendChild(ADinfo)
                        Dim fromID As XmlAttribute = m_xmld2.CreateAttribute("fromLane")
                        fromID.Value = listaIncLanesJunction(i) ' setto l'origine , 

                        ADinfo.Attributes.Append(fromID)
                        Dim numDest As Short = 0 ' inizio a calcolare la equiprobabilita' di svolta
                        Dim probDest As Double = 0
                        For f = 0 To rouNUM - 1
                            If corrispondenzaLanes(f) = i Then ' dovra' essere modificato il valore manualmente
                                numDest += 1
                            End If
                        Next
                        probDest = 1 / numDest
                        For m = 0 To rouNUM - 1
                            If corrispondenzaLanes(m) = i Then
                                generaBoxDestinazioni(i, m, corrispondenzaDest(m), probDest.ToString("#.##"))
                                toIDELEM = m_xmld2.CreateElement("toLane")
                                Dim toid As XmlAttribute = m_xmld2.CreateAttribute("toID")
                                toid.Value = corrispondenzaDest(m)
                                toIDELEM.Attributes.Append(toid)
                                toid = m_xmld2.CreateAttribute("prob")
                                toid.Value = probDest.ToString("n3").Replace(",", ".")
                                toIDELEM.Attributes.Append(toid)
                                ADinfo.AppendChild(toIDELEM)
                            End If
                        Next
                    Next

                    ODstdNode = m_xmld2
                    cfgNode.AppendChild(VeicNode)
                    If fileINIexists = False Then
                        m_xmld2.Save(fileINI)
                    End If

                    'devo creare solo i box dei dATI di traffico qui se il file gia' esiste

                    'For i = 0 To links.Length - 1 ' VECCHIA  VERSIONE CHE CREAVA IL BOX PRIMA DEL FILE 
                    '    generaBoxArrivi(links(i)) ' messi nello stesso ordine del file originale
                    '    Dim numDest As Short = 0
                    '    Dim probDest As Double = 0
                    '    For f = 0 To rouNUM - 1 ' calcolo probabilita' di ogni svolta , Setto inizialmente equiprobabilità
                    '        If corrispondenzaLanes(f) = i Then ' dovra' essere modificato il valore manualmente
                    '            numDest += 1
                    '        End If
                    '    Next
                    '    probDest = 1 / numDest
                    '    For m = 0 To rouNUM - 1
                    '        If corrispondenzaLanes(m) = i Then
                    '            generaBoxDestinazioni(i, m, corrispondenzaDest(m) & "_0", probDest.ToString("#.##"))
                    '        End If
                    '    Next
                    '    ' qui devo aggiungere informazioni riguardo le possibili svolte 
                    '    'quando vado a generare gli arrivi all'intersezione
                    'Next

                    'devo considerare tutte le direzioni dei links inclusi
                    'Dim buff() As String = links
                    'ReDim links(links.Count * 2 - 1)
                    ReDim puntiJunction(links.Count * 2 - 1, 1)  ' qui salvo i punti della junction man mano che li trovo
                    ReDim versi(links.Count * 2 - 1) 'qui dentro mi segno i versi delle junction
                    Dim j As Short = 0

                    'For i = 0 To buff.Length - 1
                    '    links(j) = buff(i).Replace("-", "")
                    '    links(j + 1) = "-" & buff(i).Replace("-", "")
                    '    j += 2
                    'Next

                    txtDebug.Text &= "Lunghezza Strade adiacenti l'incrocio di interesse: " & vbCrLf
                    For i = 0 To links.Count - 1
                        'calcolo la lunghezza della strada 

                        m_node1 = m_net.SelectSingleNode("//lane[@id='" & links(i) & "']") 'seleziono il nodo che mi interessa
                        Dim debtest As String = m_node1.Attributes.GetNamedItem("length").Value
                        Dim lunghezza As Double = m_node1.Attributes.GetNamedItem("length").Value.Replace(".", ",")

                        txtDebug.Text &= "ID:" & links(i).ToString & " , Lunghezza: " & lunghezza & vbCrLf
                        'se la lunghezza non e' 50 metri devo tagliare / accorciare l'ultimo tratto 
                        'per iniziare devo individuare il punto piu' vicino alla junction 
                        Dim ptJunct As Punto
                        ptJunct.X = m_node.Attributes.GetNamedItem("x").Value.Replace(".", ",")
                        ptJunct.Y = m_node.Attributes.GetNamedItem("y").Value.Replace(".", ",")
                        'a priori non so quale sia il punto iniziale e quello finale , devo verificarli
                        Dim puntiSTR() As String = m_node1.Attributes.GetNamedItem("shape").Value.Split(" ")
                        Dim punti(puntiSTR.Length - 1) As Punto
                        'devo inserire tutti i nodi della strada in un unico array
                        For j = 0 To puntiSTR.Length - 1
                            Dim ptbuf() As String = puntiSTR(j).Split(",")
                            punti(j).X = ptbuf(0).Replace(".", ",")
                            punti(j).Y = ptbuf(1).Replace(".", ",")
                        Next
                        Dim pta, ptb As Punto
                        pta.X = punti(0).X
                        pta.Y = punti(0).Y
                        ptb.X = punti(punti.Length - 1).X
                        ptb.Y = punti(punti.Length - 1).Y
                        Dim verso As Boolean = ordinaPuntiMIN(ptJunct, punti)
                        ' con questa funzione  ordino i punti estremali della strada, ptA e' sempre il pt vicino all'incrocio
                        ' inoltre mi restituisce il verso della successione di nodi rispetto l'incrocio T
                        'True se il verso e' opposto 
                        'devo individuare i nodi che non mi servono
                        Dim distanza As Double
                        Dim pi As Punto
                        Dim pf As Punto
                        Dim puntiSTRMod As String = "" ' la stringa finale modificata da reinserire nel file .net.xml
                        Dim diff As Double
                        distanza = 0
                        puntiSTRMod &= punti(0).X.ToString("#.##").Replace(",", ".") & _
                                    "," & punti(0).Y.ToString("#.##").Replace(",", ".") & " "
                        For j = 0 To punti.Length - 2
                            'calcolo iterativamente la distanza dal punto iniziale 
                            pi.X = punti(j).X
                            pi.Y = punti(j).Y
                            pf.X = punti(j + 1).X
                            pf.Y = punti(j + 1).Y

                            distanza += Math.Sqrt((pi.X - pf.X) ^ 2 + (pi.Y - pf.Y) ^ 2)
                            If distanza > lunghezzaTronchi Then
                                'arrivato qui dentro ho trovato l'ultimo punto da modificare
                                Dim punto As Punto = calcLastPoint(pi, pf, lunghezzaTronchi - distanza, verso, i)
                                pf.X = punto.X
                                pf.Y = punto.Y
                                puntiSTRMod &= punto.X.ToString("#.##").Replace(",", ".") & _
                                "," & punto.Y.ToString("#.##").Replace(",", ".") & " "
                                distanza = lunghezzaTronchi
                                Exit For
                            End If
                            diff = distanza
                            puntiSTRMod &= pf.X.ToString("#.##").Replace(",", ".") & _
                                "," & pf.Y.ToString("#.##").Replace(",", ".") & " "
                        Next
                        If distanza < lunghezzaTronchi Then ' se sono uscito dal loop senza effettuare modifiche
                            Dim punto As Punto = calcLastPoint(pi, pf, lunghezzaTronchi - distanza, verso, i) ' in teoria lo allunga
                            puntiSTRMod &= punto.X.ToString("#.##").Replace(",", ".") & _
                                "," & punto.Y.ToString("#.##").Replace(",", ".") & " "
                        End If

                        If verso = True Then
                            'se l'ultimo punto della lista non e' quello vicino all'incrocio allora devo 
                            ' invertire l'ordine di tutti i punti 
                            puntiSTRMod = invertiPunti(puntiSTRMod)
                        End If
                        m_node1.Attributes.GetNamedItem("shape").Value = puntiSTRMod
                        m_node1.Attributes.GetNamedItem("length").Value = lunghezzaTronchi.ToString
                        ' costruzione della junction :
                    Next

                    Dim lnkA As String, lnkB As String 'metto in ordine la stringa , lnkA va per primo
                    'For j = 0 To links.Length - 1 Step 1
                    '    ' devo trovare la junction , per trovare junction di linee

                    '    Dim m_nodeJ As XmlNode = m_net.SelectSingleNode("//junction[@incLanes='" & _
                    '            links(j) & "']")
                    '    If IsNothing(m_nodeJ) Then
                    '        m_nodeJ = m_net.SelectSingleNode("//junction[@incLanes='" & _
                    '            links(j + 1) & "']")
                    '    End If
                    '    If versi(j) = True Then
                    '        lnkA = puntiJunction(j, 0) & " " & puntiJunction(j, 1)
                    '    Else
                    '        lnkB = puntiJunction(j, 0) & " " & puntiJunction(j, 1)
                    '    End If
                    '    If versi(j + 1) = True Then
                    '        lnkA = puntiJunction(j + 1, 0) & " " & puntiJunction(j + 1, 1)
                    '    Else
                    '        lnkB = puntiJunction(j + 1, 0) & " " & puntiJunction(j + 1, 1)
                    '    End If
                    '    m_nodeJ.Attributes.GetNamedItem("shape").Value = lnkA & " " & lnkB
                    'Next
                End If
            End If
        Next
        m_xmld.Save(txtPercSave.Text) 'salvo il file .net.xml in una nuova posizione
        btnStartSim.Enabled = True
        'Catch errorVariable As Exception
        '    txtDebug.Text &= "Errore XML: " & (errorVariable.ToString()) & vbCrLf
        'End Try
        ricaricaListaFasi(0)
        AppStatus = 1
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs)
        ' Dim dist = Math.Sqrt((350 - 467) ^ 2 + (456 - 760) ^ 2)
        ' Dim punto As Point = calcLastPoint(New Point(467, 760), New Point(350, 456), 70)
        'txtDebug.Text &= punto.ToString & vbCrLf
        ' Dim dist2 = Math.Sqrt((350 - punto.X) ^ 2 + (456 - punto.Y) ^ 2)
        'txtDebug.Text &= "dist " & dist & " --> " & dist2 & vbCrLf

        'Dim x1 As Double = 123.61
        'Dim y1 As Double = 48.92
        'Dim x2 As Double = 123.33
        'Dim y2 As Double = 45.63
        'Dim dist As Double = Math.Sqrt((x1 - x2) ^ 2 + (y1 - y2) ^ 2)
        'txtDebug.Text &= dist & vbCrLf

        'provo a richiamare python
        Dim filepath As String = Path.GetDirectoryName(txtPercSave.Text)
        Dim filename As String = Path.GetFileNameWithoutExtension(txtPercSave.Text)
        Dim pospto As Short = Strings.InStr(filename, ".") ' rimuovo la seconda parte di estensione se e' presente 
        If pospto > 0 Then
            filename = filename.Remove(pospto - 1)
        End If
        Dim percfg As String = "gui " & """" & filepath & "\" & filename & ".sumocfg"""
        Dim filenamePY As String = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName)
        filenamePY = filenamePY & "\VBproc\PythonScript\PythonScript.py"
        Dim scriptPY As New ProcessStartInfo
        scriptPY.Arguments = percfg
        scriptPY.FileName = """" & filenamePY & """"
        Process.Start(scriptPY)
    End Sub

    Private Sub btnTest_Click_1(sender As Object, e As EventArgs) Handles btnTest.Click
        'Dim filepath As String = Path.GetDirectoryName(txtPercSave.Text)
        'Dim filename As String = Path.GetFileNameWithoutExtension(txtPercSave.Text)
        'Dim fileINI As String = filepath & "/" & filename & ".simcfg"
        ''saveXMLconfig(fileINI, "prova", 10.33453, 0.6)
        ricaricaListaFasi(0)
    End Sub

    Public Sub creaXMLconfig(fileINI As String, veicName As String, accel As Double, decel As Double, sigma As Double, _
                             length As Double, mingap As Double, maxSpeed As Double, guyShape As Short)
        'creo il file di impostazione con informazioni sui tipi di veicoli e sugli arrivi/destinazioni.
        'Sotto gestione dei veicoli riapro questo file invece di ricreare le impostazioni
        If Not System.IO.File.Exists(fileINI) Then
            System.IO.File.Create(fileINI).Dispose()
        End If
        'salvo il file come un XML per mantenere lo stile del progetto e avere maggiore flessibilita'
        Dim m_xmld As XmlDocument = New XmlDocument()
        'Dim prova1 As XmlNode = m_xmld.CreateXmlDeclaration("1.0", "UTF-8", "")
        'm_xmld.AppendChild(prova1)

        Dim cfgNode As XmlNode = m_xmld.CreateElement("cfg") ' creo nodo di configurazione principale
        m_xmld.AppendChild(cfgNode)

        Dim VeicNode As XmlNode = m_xmld.CreateElement("vType") ' per ogni tipo di veicolo 
        Dim veicAttribute1 As XmlAttribute = m_xmld.CreateAttribute("id") ' scrivo gli attributi
        veicAttribute1.Value = veicName
        VeicNode.Attributes.Append(veicAttribute1)
        Dim veicAttribute As XmlAttribute = m_xmld.CreateAttribute("accel") ' scrivo gli attributi
        veicAttribute.Value = accel.ToString.Replace(",", ".")
        VeicNode.Attributes.Append(veicAttribute)
        veicAttribute = m_xmld.CreateAttribute("decel") ' scrivo gli attributi
        veicAttribute.Value = decel.ToString.Replace(",", ".")
        VeicNode.Attributes.Append(veicAttribute)
        veicAttribute = m_xmld.CreateAttribute("sigma")
        veicAttribute.Value = sigma.ToString.Replace(",", ".")
        VeicNode.Attributes.Append(veicAttribute)
        veicAttribute = m_xmld.CreateAttribute("length")
        veicAttribute.Value = length.ToString.Replace(",", ".")
        VeicNode.Attributes.Append(veicAttribute)
        veicAttribute = m_xmld.CreateAttribute("minGap")
        veicAttribute.Value = mingap.ToString.Replace(",", ".")
        VeicNode.Attributes.Append(veicAttribute)
        veicAttribute = m_xmld.CreateAttribute("maxSpeed")
        veicAttribute.Value = maxSpeed.ToString.Replace(",", ".")
        VeicNode.Attributes.Append(veicAttribute)
        veicAttribute = m_xmld.CreateAttribute("guiShape")
        veicAttribute.Value = guyShape.ToString
        VeicNode.Attributes.Append(veicAttribute)
        cfgNode.AppendChild(VeicNode)
        Dim ADinfo As XmlNode = m_xmld.CreateElement("routeInfo")
        Dim fromID As XmlAttribute = m_xmld.CreateAttribute("fromID")
        m_xmld.Save(fileINI)

    End Sub


    Private Sub btnStartSim_Click(sender As Object, e As EventArgs) Handles btnStartSim.Click
        ' controllo che sia stata immessa la variabile di ambiente
        Dim ctrlp As String = Environment.GetEnvironmentVariable("SUMO_HOME")
        'C:\Users\LoscoPc\Desktop\TESI\sumo-0.21.0
        If ctrlp = Nothing Then
            Dim percorsoVar As String = Directory.GetParent((Path.GetDirectoryName(txtPercSUMO.Text))).FullName
            Environment.SetEnvironmentVariable("SUMO_HOME", percorsoVar)
        End If

        btnStartSim.Enabled = False
        Dim campionamenti As Short = txtCampiona.Text
        Dim m_xmld As XmlDocument
        'Create il documento (vuoto)
        m_xmld = New XmlDocument()
        'Carico il file XML della rete
        m_xmld.Load(fileINI) ' carico il percorso della textbox
        'da qui in poi genero il routefile con le informazioni su ogni automobile che passa sull'incrocio nell'arco di tempo considerato
        'creo il nuovo file per la generazione di tutti i percorsi di tutte le automobili della simulazione 
        Dim filepath As String = Path.GetDirectoryName(txtPercSave.Text)
        Dim filename As String = Path.GetFileNameWithoutExtension(txtPercSave.Text)

        Dim pospto As Short = Strings.InStr(filename, ".") ' rimuovo la seconda parte di estensione se e' presente 
        If pospto > 0 Then
            filename = filename.Remove(pospto - 1)
        End If

        Dim nuovofile As String = filepath & "\" & filename & ".rou.xml"
        If Not System.IO.File.Exists(nuovofile) Then
            System.IO.File.Create(nuovofile).Dispose()
        Else
            IO.File.Delete(nuovofile)
        End If
        Dim objWriter As New System.IO.StreamWriter(nuovofile, True)
        Dim stringOUTPUT As String = "<routes>" & vbCrLf

        Dim m_nodelist, m_nodlistchild As XmlNodeList
        Dim m_node, m_node1 As XmlNode
        Dim m_nodeChild As XmlNode
        Dim num_vehicle As Short = 0
        m_nodelist = m_xmld.SelectNodes("cfgVeic/vType")
        For Each m_node1 In m_nodelist
            Dim gshape As String
            Dim numS As Short = m_node1.Attributes.GetNamedItem("guiShape").Value
            Select Case numS
                Case 0
                    gshape = "passenger"
                Case 1
                    gshape = "bus"
            End Select
            stringOUTPUT &= "<vType id=""" & m_node1.Attributes.GetNamedItem("id").Value _
                & """ accel=""" & m_node1.Attributes.GetNamedItem("accel").Value _
                & """ decel=""" & m_node1.Attributes.GetNamedItem("decel").Value _
                & """ sigma=""" & m_node1.Attributes.GetNamedItem("sigma").Value _
                & """ length=""" & m_node1.Attributes.GetNamedItem("length").Value _
                & """ minGap=""" & m_node1.Attributes.GetNamedItem("minGap").Value _
                & """ maxSpeed=""" & m_node1.Attributes.GetNamedItem("maxSpeed").Value _
                & """ guiShape=""" & gshape & """/>" & vbCrLf & vbCrLf
            num_vehicle += 1
        Next

        m_nodelist = m_nodelist(0).SelectNodes("trafficInfo")
        Dim rouNUM As Short = 0

        Dim svoltaNum As Short = 0
        Dim numTronchi As Short = listaIncLanesJunction.Length
        For Each m_nodeChild In m_nodelist ' qui ricavo solo rouNum
            m_nodlistchild = m_nodeChild.SelectNodes("toLane")
            For Each m_node1 In m_nodeChild
                ' i dati ricavati qui sono esattamente nello stesso ordine dei box della tab
                rouNUM += 1 ' HA LO STESSO indice dei textbox nella tab2
            Next
        Next
        ' devo salvare su una matrice i valori di prob e arrivi , partendo di nuovo da 0
        Dim m_nodelist1, m_nodelist2 As XmlNodeList
        Dim a, b, c As Short
        Dim matrice_valori(num_vehicle - 1, numTronchi + rouNUM - 1) As String ' le converte dopo automaticamente in double 
        Dim matrice_veicoli(num_vehicle - 1) As String ' solo il nome del veicolo
        m_nodelist = m_xmld.SelectNodes("cfgVeic/vType")
        a = 0
        For Each m_node In m_nodelist
            matrice_veicoli(a) = m_node.Attributes.GetNamedItem("id").Value

            m_nodelist1 = m_node.SelectNodes("trafficInfo")
            b = 0
            c = 0
            For Each m_nodeChild In m_nodelist1
                matrice_valori(a, b) = m_nodeChild.Attributes.GetNamedItem("trafficLoad").Value ' salva il numero di arrivi per il tronco di ingresso per il veicolo corrente
                m_nodelist2 = m_nodeChild.SelectNodes("toLane")
                For Each m_node1 In m_nodelist2
                    matrice_valori(a, c + numTronchi) = m_node1.Attributes.GetNamedItem("prob").Value
                    c += 1
                Next
                b += 1
            Next
            a += 1
        Next

        Dim r As Short = 0
        '############################
        '###########################
        '############################
        'definisco tutte le possibili svolte QUI 
        ' queste sono tutte le possibili combinazioni I-O , sono le stesse informazioni che avrei sul file net.xml
        'di sumo , semplicemente le riporto qui nel giusto formato . Sono tutte le connection con state "o"
        'Ho deciso dall'inizio di non implementare la possibilita' di modificare queste connessioni.
        Dim xmld As XmlDocument = New XmlDocument
        xmld.Load(txtPerc1.Text)
        Dim rouID As Short = 0
        m_nodelist = xmld.SelectNodes("net/connection")
        For Each m_node In m_nodelist
            Dim fromAttr = m_node.Attributes.GetNamedItem("from").Value
            Dim toAttr = m_node.Attributes.GetNamedItem("to").Value
            Dim stateAttr = m_node.Attributes.GetNamedItem("state").Value
            If stateAttr = "o" Then ' devo includerlo nel file ROU.XML
                stringOUTPUT &= "<route id=""route" & rouID & """ edges=""" & fromAttr & " " & toAttr & """ />" & vbCrLf & vbCrLf
                'devo trovare qui la corrispondenza con la linea della junction
                TrovaCorrispondenzaLineaPercorso(fromAttr, toAttr, rouID, 0, 0) 'trova corrispondenza con l' ID della linea della junction
                rouID += 1
            End If
        Next

        'definisco OGNI POSSIBILE autoveicolo che attraversa la junction secondo una distribuzione definita 
        Dim numCICLI As Short = txtSimDurata.Text 'TEST , devo sceglierlo a runtime

        'ho degli arrivi con distribuzione di POISSON di parametro Q = numero di arrivi/h ,
        'questa ipotesi cade se all'arrivo di una linea mi ritrovo un altro semaforo , in quel caso gli arrivi non sono
        'completamente casuali e non hanno distribuzione poissoniana
        'devo  capire con quale probabilita' un veicolo svoltera' in una direzione piuttosto che un'altra 

        Dim rand As New Random() ' qui andrebbe specificato il SEED se occorre , dare la possibilita' di specificarlo runtime
        Randomize()
        Dim veicNUM As Short = 0 'indice veicolo creato 

        'per capire quanti veicoli arrivano in quell'intervallo temporale devo creare degli intervalli di probabilita' 
        'con approssimazione 

        For i = 1 To numCICLI
            'devo calcolare iterativamente la probabilita' degli arrivi

            Dim arraySvolte(listaIncLanesJunction.Length - 1, rouNUM - 1) As Short 'matrice delle coincidenze linea arrivo-svolta
            For j = 0 To rouNUM - 1
                'rouNum sono il numero di connessioni specificato sul file net.xml , 
                'devo trovare una corrispondenza con le Lanes della junction principale 
                arraySvolte(corrispondenzaLanes(j), j) = 1
            Next
            For v = 0 To num_vehicle - 1 ' per ogni tipo di veicolo devo verificare l'evento di ingresso al tronco
                For j = 0 To listaIncLanesJunction.Length - 1 ' per ogni linea di accesso dell'intersezione
                    'calcolo la probabilita' della svolta su una delle possibili direzioni possibili
                    'TEST , ipotizzo per ora equiprobabilita' su tutte le possibili svolte ###########
                    'Dim numSvolte As Short = 0
                    'For k = 0 To rouNUM - 1
                    '    If arraySvolte(j, k) = 1 Then
                    '        numSvolte += 1
                    '    End If
                    'Next
                    'devo recuperare le informazioni sulla probabilita' di svolta/ accessi

                    Dim probCumulata As Double = 0
                    Dim valoreRandom As Double = rand.NextDouble 'casuale da 0 a 1
                    Dim overflowProtectContatore As Short = 0
                    Dim numArrivi As Short = 0
                    Dim n As Short = 0 ' contatore arrivi
                    'probabilita' degli arrivi
                    Dim q As Double ' inserisco il valore di q e creo la prob cumulata della distribuzione 
                    q = matrice_valori(v, j).Replace(".", ",") ' txtArriviArray(j).Text 'arrivi medi all'ora
                    probCumulata = (Math.Exp(-q / 3600) * (q / 3600) ^ n) / Factorial(n)
                    While Not valoreRandom <= probCumulata
                        n += 1
                        If overflowProtectContatore > 100 Then
                            Exit While ' se prendo percentuali improbabili tipo 99.9999% , devo uscire prima di andare in overflow
                        End If
                        overflowProtectContatore += 1
                        probCumulata += (Math.Exp(-q / 3600) * (q / 3600) ^ n) / Factorial(n) ' distribuzione poissoniana arrivi
                    End While


                    'inserisco nel file della simulazione i dati della vettura in arrivo e calcolo dove andra' a svoltare
                    'calcolo su quale linea andra' a svoltare
                    'questo per ogni vettura in arrivo , anche se scrivo sul file che arrivano piu' auto nello stesso momento ,
                    ' e' il software  che ne gestisce l'arrivo effettivo
                    For y = 0 To n - 1 ' per ogni veicolo in arrivo
                        valoreRandom = rand.NextDouble

                        'indice arrivo :j indice destinazione da calcolare: de
                        Dim indest As Short = 0
                        For z = 0 To rouNUM - 1 ' non ho piu' connessioni qui di quante ne ho nel file net.xml
                            Dim infoMAt() As String = txtDestinazArray(z).Name.Split("_") ' controllo le info riguardo la matrice che ho lasciato nel nome della textbox
                            If infoMAt(1) = j Then ' se e' il tetbox che riguarda la stessa origine
                                indest = z ' ho trovato il mio indice di partenza
                                Exit For
                            End If
                        Next

                        probCumulata = matrice_valori(v, numTronchi + indest).Replace(".", ",") ' txtDestinazArray(indest).Text ' probabilita' di svolta della prima destinzazione possibile
                        Dim s As Short = 1 ' e' l'indice della svolta che prendera' la macchina , uso questo 'trucco' perche' non 
                        'ho una corrispondenza ordinata tra l'indice dei textbox txtdestinazarray e
                        'arraysvolte
                        While Not valoreRandom <= probCumulata
                            s += 1 'in realta' ora ho direttamente il numero della connection sull'xml quindi s non serve piu'
                            indest += 1 ' arrivo alla prima casella della prima simulazione
                            If indest <= rouNUM - 1 Then ' non devo sforare senno' mi da overflow sull'array di textbox
                                Dim infoMAt() As String = txtDestinazArray(indest).Name.Split("_")
                                If infoMAt(1) = j Then 'mi devo fermare quando finiscono le destinazioni per la mia origine j
                                    probCumulata += matrice_valori(v, numTronchi + indest).Replace(".", ",")
                                Else
                                    s -= 1
                                    Exit While
                                End If
                            Else
                                s -= 1
                                Exit While
                            End If
                        End While

                        'devo ritrovare la corrispondenza dell ' indice della svolta con l'id della "connection" del file net.xml
                        Dim conta As Short = 0
                        For t = 0 To rouNUM - 1
                            If arraySvolte(j, t) = 1 Then
                                conta += 1
                                If conta = s Then
                                    ' quando trovo la corrispondenza aggiungo i dati sul trip nell'apposito file
                                    stringOUTPUT &= "<vehicle id=""veic_" & veicNUM & """ type=""" & matrice_veicoli(v) & """ route=""route" & t & _
                                                           """ depart=""" & i & """ />" & vbCrLf
                                    'stringOUTPUT &= "<vehicle id=""veic_" & veicNUM & """ type=""" & matrice_veicoli(v) & """ route=""route" & 6 & _
                                    '                        """ depart=""" & i & """ />" & vbCrLf 'TEST
                                    veicNUM += 1

                                End If
                            End If
                        Next
                    Next

                Next
            Next


        Next
        stringOUTPUT &= "</routes>"
        'ho concluso la costruzione del file 


        objWriter.WriteLine(stringOUTPUT) 'salvo  file .rou.xml e lo chiudo 
        objWriter.Close()

        txtDebug.Text &= "File output salvato!" & vbCrLf

        'creo il file di configurazione di sumo
        creaFileCfg(filename)


        'arrivato qui devo inizializzare sumo attraverso python , in quanto le librerie traci non sono compatibili con .net
        Dim filenamePY As String = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName)
        filenamePY = filenamePY & "\VBproc\PythonScript\PythonScript.py"
        Dim scriptPY As New System.Diagnostics.Process
        'devo passare il sumocfg con percorso completo
        Dim guistr As String = ""
        Dim filepath1 As String = Path.GetDirectoryName(txtPercSUMO.Text)
        If chkGUI.Checked = True Then
            guistr = filepath1 & "\sumo-gui.exe"
        Else
            guistr = filepath1 & "\sumo.exe"
        End If
        Dim percfg As String = """" & guistr & """" & " " & """" & filepath & """ " & filename & """.sumocfg""" & " """ & filename & """" & " " & campionamenti
        scriptPY.StartInfo.Arguments = percfg
        scriptPY.StartInfo.FileName = filenamePY
        scriptPY.Start()
        scriptPY.WaitForExit()
        scriptPY.Close()
        scriptPY.Dispose()

        'Da qui in poi posso processare l'output
        'creo 3 files di output, uno generato da python, a cui passo il nome,
        'uno con le info aggregate tipo max coda , coda media , tempo medio in attesa
        '########################################################################################################################
        'Try
        Dim fout0 As String = filepath & "\" & filename & ".OUTcampionamenti.csv"
        Dim riga As String = ""
        Dim objReader As New System.IO.StreamReader(fout0, True)
        Dim idLanes() As String
        Dim codaMax() As Short
        If Not (objReader Is Nothing) Then
            riga = objReader.ReadLine ' prima riga , da scartare
            'recupero l'ordine delle linee
            Dim elem() As String = riga.Split(";")
            ReDim idLanes(elem.Count - 3)
            ReDim codaMax(elem.Count - 3)
            Dim d As Short = 0
            While d + 2 < elem.Count
                idLanes(d) = elem(d + 2).Replace("""", "") ' tolgo 
                d += 1
            End While
        End If
        riga = objReader.ReadLine 'inizio a processare dalla seconda
        While Not riga Is Nothing
            Dim elem() As String = riga.Split(";")
            Dim n As Short = 0
            While n + 2 < elem.Count
                If elem(n + 2) > codaMax(n) Then
                    codaMax(n) = elem(n + 2)
                End If
                n += 1
            End While
            riga = objReader.ReadLine
        End While
        '########################################################################################################################
        Dim fout1 As String = filepath & "\" & filename & ".OUTinfoVeic.csv"
        If Not System.IO.File.Exists(fout1) Then
            System.IO.File.Create(fout1).Dispose()
        Else
            IO.File.Delete(fout1)
        End If
        Dim objWriter1 As New System.IO.StreamWriter(fout1, True) ' scrivo il tripinfo output del
        m_xmld.Load(filepath & "\" & "tripinfo.xml") ' carico il percorso della textbox
        m_nodelist = m_xmld.SelectNodes("tripinfos/tripinfo")
        Dim waitmax(idLanes.Count - 1) As Integer  ' massima attesa
        Dim mediaNum(idLanes.Count - 1) As Integer
        Dim mediaSomma(idLanes.Count - 1) As Double
        Dim line1 As String = "Veicolo num" & ";" & "tipo di mezzo" & ";" & "Linea di partenza" & ";" & "Linea di arrivo" & ";" & "T partenza" & ";" & "T arrivo" & ";" & "T in coda (s)" & ";" & "Ritardo ingresso (s)"
        objWriter1.WriteLine(line1) 'salvo  file .rou.xml e lo chiudo 
        For Each m_node In m_nodelist
            Dim linea As String = ""
            Dim l1() As String = m_node.Attributes.GetNamedItem("id").Value.Split("_") 'veicolo num. ...solo numero
            Dim l2 As String = m_node.Attributes.GetNamedItem("depart").Value  'tempo di partenza
            Dim l3 As String = m_node.Attributes.GetNamedItem("departLane").Value  'linea partenza
            Dim l4 As String = m_node.Attributes.GetNamedItem("departDelay").Value  'ritardo di partenza
            Dim l5 As String = m_node.Attributes.GetNamedItem("arrival").Value  'tempo di arrivo
            Dim l6 As String = m_node.Attributes.GetNamedItem("arrivalLane").Value  'linea di arrivo
            Dim l7 As Integer = m_node.Attributes.GetNamedItem("waitSteps").Value  'tempo fermo in coda
            'trovo l'indice della departline 
            Dim index = 0
            For i = 0 To idLanes.Count - 1
                If l3 = idLanes(i) & "_0" Then
                    index = i
                End If
            Next

            If l7 > waitmax(index) Then
                waitmax(index) = l7
            End If
            'alternativa
            mediaSomma(index) += l7
            mediaNum(index) += 1
            Dim l8 As String = m_node.Attributes.GetNamedItem("vType").Value  'tipo di mezzo
            linea = l1(1) & ";" & l8 & ";" & """" & l3 & """" & ";" & """" & l6 & """" & ";" & l2 & ";" & l5 & ";" & l7 & ";" & l4
            objWriter1.WriteLine(linea) 'salvo  file .rou.xml e lo chiudo 
        Next
        For i = 0 To idLanes.Count - 1
            If mediaNum(i) > 0 Then ' attenzione a divisione per 0
                mediaSomma(i) = mediaSomma(i) / mediaNum(i) ' deve venire lo stesso risultato
            Else
                mediaSomma(i) = 0
            End If

        Next
        objWriter1.WriteLine("")
        objWriter1.Close()
        txtDebug.Text = ""
        txtDebug.Text &= "Simulazione Terminata! " & vbCrLf & " Files di output salvati." & vbCrLf
        For i = 0 To idLanes.Count - 1
            txtDebug.Text &= "Coda massima rilevata su linea " & idLanes(i) & ": " & codaMax(i) & vbCrLf
        Next
        For i = 0 To idLanes.Count - 1
            txtDebug.Text &= "Tempo di attesa massimo su linea " & idLanes(i) & ": " & waitmax(i) & " (s)" & vbCrLf
        Next
        For i = 0 To idLanes.Count - 1
            txtDebug.Text &= "Tempo di attesa medio su linea " & idLanes(i) & ": " & mediaSomma(i).ToString("n1") & " (s)" & vbCrLf
        Next
        'Catch ex As Exception
        '    txtDebug.Text &= "E' stato rilevato un errore durante l'analisi della simulazione" & vbCrLf
        '    txtDebug.Text &= "Errore: " & ex.Message & vbCrLf
        'End Try

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Environment.GetEnvironmentVariable("SUMO_HOME") & "/bin/sumo-gui.exe"
        Dim percorsoSumo As String = Directory.GetParent((Path.GetDirectoryName(txtPercSUMO.Text))).FullName & "/bin/sumo-gui.exe"
        Dim sumoguiProc As New ProcessStartInfo
        'devo passare il sumocfg con percorso completo
        Dim cfg As String = "-n " & """" & txtPercSave.Text & """"
        sumoguiProc.Arguments = cfg
        sumoguiProc.FileName = percorsoSumo
        Process.Start(sumoguiProc)
    End Sub
#Region "AddVeichle"
    Private Sub btnAddVeic_Click(sender As Object, e As EventArgs) Handles btnAddVeic.Click
        Panel1.Visible = True
        btnAddVeic.Visible = False
        btnAddVeic.Text = "AGGIUNGI"
        tab3Action = 2
    End Sub
    Private Sub btnSaveVeic_Click(sender As Object, e As EventArgs) Handles btnSaveVeic.Click
        Dim itemAdd As ListViewItem = New ListViewItem(txtVeicName.Text)
        ' dovrei verificare che non ci sia gia un item con questo nome
        For i = 0 To lstVeicoli.Items.Count - 1
            If txtVeicName.Text = lstVeicoli.Items(i).Text Then
                MsgBox("Nella lista e' gia' presente il tipo di veicolo " & txtVeicName.Text)
                txtVeicName.Focus()
                Exit Sub
            End If
        Next
        Panel1.Visible = False
        itemAdd.SubItems.Add(txtAcc.Text)
        itemAdd.SubItems.Add(txtDecel.Text)
        itemAdd.SubItems.Add(txtLenght.Text)
        itemAdd.SubItems.Add(txtMinGap.Text)
        itemAdd.SubItems.Add(txtSigma.Text)
        itemAdd.SubItems.Add(txtVelMax.Text)
        itemAdd.SubItems.Add(cmbVeicType.SelectedItem.ToString).Tag = cmbVeicType.SelectedIndex ' -> salva sia testo che tag!
        'aggiungo nella lista il veicolo
        'salvo da qualche parte il veicolo in memoria statica = FILE
        ' Write this array to the file.
        lstVeicoli.Items.Add(itemAdd) ' aggiungo infine l'item
        'Lo devo salvare ore 
        Dim m_xmld As XmlDocument = New XmlDocument()
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode
        m_xmld.Load(fileINI) ' carico il percorso della textbox
        Select Case tab3Action
            Case 1 ' modifica
                'seleziono l'id del nodo che devo modificare
                m_nodelist = m_xmld.SelectNodes("cfgVeic/vType")
                For Each m_node In m_nodelist
                    If m_node.Attributes.GetNamedItem("id").Value = tab3Tag Then
                        'modifico questo nodo
                        modAttrNodo(m_node)
                        Exit Select
                    End If
                Next
            Case 2 ' aggiungi 
                Dim nodeCopy As XmlElement = m_xmld.ImportNode(ODstdNode.SelectSingleNode("cfgVeic/vType").Clone(), True)
                modAttrNodo(nodeCopy)
                m_node = m_xmld.SelectSingleNode("cfgVeic")
                m_node.AppendChild(nodeCopy)
                btnAddVeic.Visible = True
        End Select
        m_xmld.Save(fileINI)
    End Sub

    Private Sub modAttrNodo(ByRef nodo As XmlNode)
        nodo.Attributes.GetNamedItem("id").Value = txtVeicName.Text
        nodo.Attributes.GetNamedItem("decel").Value = txtDecel.Text
        nodo.Attributes.GetNamedItem("accel").Value = txtAcc.Text
        nodo.Attributes.GetNamedItem("sigma").Value = txtSigma.Text
        nodo.Attributes.GetNamedItem("length").Value = txtLenght.Text
        nodo.Attributes.GetNamedItem("minGap").Value = txtMinGap.Text
        nodo.Attributes.GetNamedItem("maxSpeed").Value = txtVelMax.Text
        nodo.Attributes.GetNamedItem("guiShape").Value = cmbVeicType.SelectedIndex
    End Sub
    Private Sub btnDeleteVeic_Click(sender As Object, e As EventArgs) Handles btnDeleteVeic.Click
        Panel1.Visible = False
        'cancello il veicolo dalla lista e dalla memoria 0 FILE Di salvataggio
        Dim m_xmld As XmlDocument = New XmlDocument()
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode
        m_xmld.Load(fileINI) ' carico il percorso della textbox
        m_nodelist = m_xmld.SelectNodes("cfgVeic/vType")
        For Each m_node In m_nodelist
            If m_node.Attributes.GetNamedItem("id").Value = tab3Tag Then
                'modifico questo nodo
                m_xmld.SelectSingleNode("cfgVeic").RemoveChild(m_node)
                Exit For
            End If
        Next
        m_xmld.Save(fileINI)
    End Sub
#End Region

    Private Sub lstVeicoli_DoubleClick(sender As Object, e As EventArgs) Handles lstVeicoli.DoubleClick
        'questo evento non e' quello esatto ! vedi progetto vecchio

        ' devo poter salvare dati sui veicoli per ogni progetto scrivendo su disco un file con le impostazioni!
        'Il file mi salva anche le info per quanto riguarda le probabilita' di arrivo/svolta per ogni tipo di veicolo
        Panel1.Visible = True
        txtVeicName.Text = lstVeicoli.FocusedItem.Text
        txtAcc.Text = lstVeicoli.FocusedItem.SubItems(1).Text
        txtDecel.Text = lstVeicoli.FocusedItem.SubItems(2).Text
        txtLenght.Text = lstVeicoli.FocusedItem.SubItems(3).Text
        txtMinGap.Text = lstVeicoli.FocusedItem.SubItems(4).Text
        txtVelMax.Text = lstVeicoli.FocusedItem.SubItems(6).Text
        txtSigma.Text = lstVeicoli.FocusedItem.SubItems(5).Text
        cmbVeicType.SelectedIndex = lstVeicoli.FocusedItem.SubItems(7).Tag ' setto tag = 0 come automobile , 1 come mezzo pesante
        lstVeicoli.FocusedItem.Remove()
        tab3Action = 1 ' flag a 1 = sto modificando il veicolo 
        tab3Tag = txtVeicName.Text
        btnSaveVeic.Text = "MODIFICA"

    End Sub
    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter
        If AppStatus = 0 Then Exit Sub ' esco se non ho ancora il file caricato
        'Carico il file qui.
        Dim m_xmld As XmlDocument = New XmlDocument()
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode
        'Carico il file XML della rete
        m_xmld.Load(fileINI) ' carico il percorso della textbox
        'Leggo i nodi che mi interessano
        m_nodelist = m_xmld.SelectNodes("cfgVeic/vType")
        'Controllo tutti i nodi letti
        lstVeicoli.Items.Clear()
        For Each m_node In m_nodelist ' per ogni veicolo nella lista
            'Get the Gender Attribute Value
            Dim itemAddr As ListViewItem = New ListViewItem(m_node.Attributes.GetNamedItem("id").Value)
            Panel1.Visible = False
            itemAddr.SubItems.Add(m_node.Attributes.GetNamedItem("accel").Value)
            itemAddr.SubItems.Add(m_node.Attributes.GetNamedItem("decel").Value)
            itemAddr.SubItems.Add(m_node.Attributes.GetNamedItem("length").Value)
            itemAddr.SubItems.Add(m_node.Attributes.GetNamedItem("minGap").Value)
            itemAddr.SubItems.Add(m_node.Attributes.GetNamedItem("sigma").Value)
            itemAddr.SubItems.Add(m_node.Attributes.GetNamedItem("maxSpeed").Value)
            Select Case m_node.Attributes.GetNamedItem("guiShape").Value
                Case 0
                    itemAddr.SubItems.Add("Automobile1").Tag = m_node.Attributes.GetNamedItem("guiShape").Value
                Case 1
                    itemAddr.SubItems.Add("Mezzo pesante").Tag = m_node.Attributes.GetNamedItem("guiShape").Value
                Case Else
                    'eventuali altri casi 
            End Select
            lstVeicoli.Items.Add(itemAddr)
            ' -> salva sia testo che tag
        Next
    End Sub
    Private Sub TabPage3_Leave(sender As Object, e As EventArgs) Handles TabPage3.Leave
        'salvo il file qui
    End Sub


    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
        ' entro nella TAB gestione veicoli 
        'carico il file xml con le impostazioni 
        'il file esiste perche' lo creo dopo la prima apertura del file net
        ' se non ci sono veicoli disponibili dissabilito le labels
        'For i = 0 To lstVeicoli.Items.Count - 1 'ERRORE
        '    cmbVeic.Items.Add(lstVeicoli.Items(i).Text)
        'Next
        'If lstVeicoli.Items.Count > 1 Then
        '    cmbVeic.SelectedIndex = 0
        'End If

        If AppStatus = 0 Then Exit Sub ' esco se non ho ancora il file caricato
        'Carico il file qui.
        Dim m_xmld As XmlDocument = New XmlDocument()
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode
        'Carico il file XML della rete
        m_xmld.Load(fileINI) ' carico il percorso della textbox
        'Leggo i nodi che mi interessano
        m_nodelist = m_xmld.SelectNodes("cfgVeic/vType")
        'Controllo tutti i nodi letti
        cmbVeic.Items.Clear()
        Dim i As Short = 0
        For Each m_node In m_nodelist 'carico i textbox partendo dai dati del primo veicolo nella lista
            cmbVeic.Items.Add(m_node.Attributes.GetNamedItem("id").Value)

            i += 1
        Next
        If tab2Tag <> -1 Then
            LoadTrafficData(tab2Tag)
        End If
        If cmbVeic.Items.Count > 0 Then
            cmbVeic.SelectedIndex = tab2Tag
            'carico i dati
        End If
    End Sub

    Public Sub LoadTrafficData(index As Short)
        Dim m_xmld As XmlDocument = New XmlDocument()
        Dim m_nodelist, m_nodlistchild As XmlNodeList
        Dim m_node, m_node1 As XmlNode
        Dim m_nodeChild As XmlNode
        'Carico il file XML della rete
        m_xmld.Load(fileINI) ' carico il percorso della textbox
        m_node = m_xmld.SelectNodes("cfgVeic/vType").Item(index)
        m_nodelist = m_node.SelectNodes("trafficInfo")
        Dim arriviNum As Short = 0
        Dim destNum As Short = 0
        For Each m_nodeChild In m_nodelist
            m_nodlistchild = m_nodeChild.SelectNodes("toLane")
            txtArriviArray(arriviNum).Text = m_nodeChild.Attributes.GetNamedItem("trafficLoad").Value
            arriviNum += 1
            For Each m_node1 In m_nodeChild
                ' i dati ricavati qui sono esattamente nello stesso ordine dei box della tab2
                txtDestinazArray(destNum).Text = m_node1.Attributes.GetNamedItem("prob").Value
                destNum += 1
            Next
        Next
    End Sub

    Public Sub SaveTrafficData(index As Short)
        If AppStatus = 0 Then Exit Sub ' esco se non ho ancora il file caricato
        Dim m_xmld As XmlDocument = New XmlDocument()
        Dim m_nodelist, m_nodlistchild As XmlNodeList
        Dim m_node, m_node1 As XmlNode
        Dim m_nodeChild As XmlNode
        'Carico il file XML della rete
        m_xmld.Load(fileINI) ' carico il percorso della textbox
        m_node = m_xmld.SelectNodes("cfgVeic/vType").Item(index)
        m_nodelist = m_node.SelectNodes("trafficInfo")
        Dim arriviNum As Short = 0
        Dim destNum As Short = 0
        For Each m_nodeChild In m_nodelist
            m_nodlistchild = m_nodeChild.SelectNodes("toLane")
            m_nodeChild.Attributes.GetNamedItem("trafficLoad").Value = txtArriviArray(arriviNum).Text
            arriviNum += 1
            For Each m_node1 In m_nodeChild
                ' i dati ricavati qui sono esattamente nello stesso ordine dei box della tab2
                m_node1.Attributes.GetNamedItem("prob").Value = txtDestinazArray(destNum).Text
                destNum += 1
            Next
        Next
        m_xmld.Save(fileINI)
    End Sub

    Private Sub TabPage2_Leave(sender As Object, e As EventArgs) Handles TabPage2.Leave
        'qui aggiorno il file di impostazione dei veicoli 
        SaveTrafficData(cmbVeic.SelectedIndex)
    End Sub

    Private Sub cmbVeic_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVeic.SelectedIndexChanged
        If cmbVeic.SelectedIndex <> tab2Tag Then
            SaveTrafficData(tab2Tag)
            tab2Tag = cmbVeic.SelectedIndex
        End If
        LoadTrafficData(tab2Tag)
    End Sub

    Public Sub ricaricaListaFasi(seleziona As Short)
        'popola il grafico nella tab4
        lstFasi.Items.Clear()
        btnSavePhase.Enabled = False
        Dim m_xmld As XmlDocument = New XmlDocument
        m_xmld.Load(txtPerc1.Text) ' carico il percorso della textbox
        Dim connlist As XmlNodeList
        connlist = m_xmld.SelectNodes("net/tlLogic/phase")
        Dim connNum As Short = 0
        For Each m_connNode In connlist
            Dim durata = m_connNode.Attributes.GetNamedItem("duration").Value
            Dim stato = m_connNode.Attributes.GetNamedItem("state").Value
            'aggiungo la fase nella tabella0
            Dim itemAdd As ListViewItem = New ListViewItem(connNum.ToString)
            itemAdd.SubItems.Add(durata)
            Dim cArr As Char() = stato
            For t = 0 To cArr.Count - 1
                itemAdd.SubItems.Add(cArr(t))
                itemAdd.UseItemStyleForSubItems = False
                Select Case cArr(t)
                    Case "G"
                        itemAdd.SubItems(itemAdd.SubItems.Count - 1).BackColor = Color.LimeGreen
                        itemAdd.SubItems(itemAdd.SubItems.Count - 1).ForeColor = Color.Red
                    Case "g"
                        itemAdd.SubItems(itemAdd.SubItems.Count - 1).BackColor = Color.LimeGreen
                        itemAdd.SubItems(itemAdd.SubItems.Count - 1).ForeColor = Color.Black
                    Case "y"
                        itemAdd.SubItems(itemAdd.SubItems.Count - 1).BackColor = Color.Yellow
                        itemAdd.SubItems(itemAdd.SubItems.Count - 1).ForeColor = Color.Black
                    Case "r"
                        itemAdd.SubItems(itemAdd.SubItems.Count - 1).BackColor = Color.Red
                        itemAdd.SubItems(itemAdd.SubItems.Count - 1).ForeColor = Color.Black
                End Select
                itemAdd.SubItems(itemAdd.SubItems.Count - 1).Font = New System.Drawing.Font _
                ("arial", 11, System.Drawing.FontStyle.Bold)
            Next
            lstFasi.Items.Add(itemAdd)
            connNum += 1
        Next

        'seleziono la prima voce 
        If lstFasi.Items.Count > 0 Then
            Panel2.Visible = True
            lstFasi.Items(seleziona).SubItems(0).BackColor = Color.Gray
            lstFasi.Items(seleziona).SubItems(1).BackColor = Color.Gray
            selezionaFase(seleziona)
        End If

    End Sub

    Private Sub lstFasi_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstFasi.MouseDown
        Dim info As ListViewHitTestInfo = lstFasi.HitTest(e.X, e.Y)
        If Not IsNothing(info.SubItem) Then
            'info will contain the information of the clicked listview column. You can then go through it's subitems for more information, if any.
            For i = 0 To lstFasi.Items.Count - 1
                If i = info.Item.Index Then
                    lstFasi.Items(i).SubItems(0).BackColor = Color.Gray
                    lstFasi.Items(i).SubItems(1).BackColor = Color.Gray
                Else
                    lstFasi.Items(i).SubItems(0).BackColor = Color.Transparent
                    lstFasi.Items(i).SubItems(1).BackColor = Color.Transparent
                End If
            Next
            selezionaFase(info.Item.Index)
        End If
    End Sub

    Private Sub selezionaFase(index As Short)
        'devo aggiornare index 
        lblPhaseNum.Text = index
        txtPhaseDur.Text = lstFasi.Items(index).SubItems(1).Text
        For i = 0 To numLabelConn - 1
            lblConnColor(i).Text = lstFasi.Items(index).SubItems(2 + i).Text
            lblConnColor(i).Font = lstFasi.Items(index).SubItems(2 + i).Font
            lblConnColor(i).BackColor = lstFasi.Items(index).SubItems(2 + i).BackColor
            lblConnColor(i).ForeColor = lstFasi.Items(index).SubItems(2 + i).ForeColor
        Next
        selezionaConn(0) ' seleziono la prima connessione
        btnSavePhase.Enabled = False
        connSelez = 0
    End Sub
    Public Sub selezionaConn(index As Short)
        lblConnTitle.Text = lblConn(index).Text
        For i = 0 To numLabelConn - 1
            If i = index Then
                lblConn(i).BackColor = Color.Gray
            Else
                lblConn(i).BackColor = Color.Transparent
            End If
        Next
        Select Case lblConnColor(index).Text
            Case "G"
                RadioButton1.Checked = True
            Case "g"
                RadioButton2.Checked = True
            Case "y"
                RadioButton3.Checked = True
            Case "r"
                RadioButton4.Checked = True
        End Select
        'FINO A QUI
    End Sub

    Private Sub btnDelPhase_Click(sender As Object, e As EventArgs) Handles btnDelPhase.Click
        Dim result1 As Short, numphase As Short
        numphase = lblPhaseNum.Text
        result1 = MessageBox.Show("Eliminare fase " & numphase & " dalla lista?", "Attenzione", MessageBoxButtons.OKCancel)
        If result1 = DialogResult.OK Then
            'elimino la fase dalla lista e dal file
            'devo rinumerare quindi tutte le altre voci presenti --> ricarico tutto
            'popola il grafico nella tab4
            Dim m_xmld As XmlDocument = New XmlDocument
            m_xmld.Load(txtPerc1.Text)
            Dim connlist As XmlNodeList
            connlist = m_xmld.SelectNodes("net/tlLogic/phase")
            connlist.Item(0).ParentNode.RemoveChild(connlist.Item(numphase))
            m_xmld.Save(txtPerc1.Text)
            'devo riaprire tutto
            ricaricaListaFasi(0)
        ElseIf result1 = DialogResult.Cancel Then
            'non fare niente se cancella
        End If
    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click

        If connSelez <> -1 Then
            btnSavePhase.Enabled = True
            lblConnColor(connSelez).Text = "g"
            lblConnColor(connSelez).BackColor = Color.LimeGreen
            lblConnColor(connSelez).ForeColor = Color.Black
        End If
    End Sub
    Private Sub RadioButton3_Click(sender As Object, e As EventArgs) Handles RadioButton3.Click
        If connSelez <> -1 Then
            btnSavePhase.Enabled = True
            lblConnColor(connSelez).Text = "y"
            lblConnColor(connSelez).BackColor = Color.Yellow
            lblConnColor(connSelez).ForeColor = Color.Black
        End If
    End Sub
    Private Sub RadioButton4_Click(sender As Object, e As EventArgs) Handles RadioButton4.Click
        If connSelez <> -1 Then
            btnSavePhase.Enabled = True
            lblConnColor(connSelez).Text = "r"
            lblConnColor(connSelez).BackColor = Color.Red
            lblConnColor(connSelez).ForeColor = Color.Black
        End If
    End Sub

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        If connSelez <> -1 Then
            btnSavePhase.Enabled = True
            lblConnColor(connSelez).Text = "G"
            lblConnColor(connSelez).ForeColor = Color.Red
            lblConnColor(connSelez).BackColor = Color.LimeGreen
        End If
    End Sub

    Private Sub btnSavePhase_Click(sender As Object, e As EventArgs) Handles btnSavePhase.Click
        'salvo le modifiche effettuate , 
        Dim result1 As Short, numphase As Short
        numphase = lblPhaseNum.Text
        result1 = MessageBox.Show("Salvare le modifiche della fase " & numphase & " ?", "Attenzione", MessageBoxButtons.OKCancel)
        If result1 = DialogResult.OK Then
            'elimino la fase dalla lista e dal file
            'devo rinumerare quindi tutte le altre voci presenti --> ricarico tutto
            'popola il grafico nella tab4
            Dim m_xmld As XmlDocument = New XmlDocument
            m_xmld.Load(txtPerc1.Text)
            Dim connlist As XmlNodeList
            connlist = m_xmld.SelectNodes("net/tlLogic/phase")
            Dim attrs As XmlAttribute = connlist.Item(numphase).Attributes.GetNamedItem("state")
            Dim durata As Short = txtPhaseDur.Text
            Dim stringval As String = ""
            For i = 0 To numLabelConn - 1
                stringval &= lblConnColor(i).Text
            Next
            attrs.Value = stringval
            attrs = connlist.Item(numphase).Attributes.GetNamedItem("duration")
            attrs.Value = durata
            m_xmld.Save(txtPerc1.Text)
            'devo riaprire tutto
            ricaricaListaFasi(numphase)
        ElseIf result1 = DialogResult.Cancel Then
            'non fare niente se cancella
        End If
    End Sub

    Private Sub txtPhaseDur_TextChanged(sender As Object, e As EventArgs) Handles txtPhaseDur.TextChanged
        btnSavePhase.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'crea uno stato vuoto allo slot 0, che poi andra' modificato e messo al posto giusto
        Dim m_xmld As XmlDocument = New XmlDocument
        m_xmld.Load(txtPerc1.Text)
        Dim connlist As XmlNodeList
        connlist = m_xmld.SelectNodes("net/tlLogic/phase")

        Dim durata As Short = 0
        Dim stringval As String = ""
        For i = 0 To numLabelConn - 1
            stringval &= "r"
        Next
        Dim nodocreat As XmlNode = m_xmld.CreateElement("phase")
        Dim attrs As XmlAttribute = m_xmld.CreateAttribute("duration")
        attrs.Value = 0
        nodocreat.Attributes.Append(attrs)
        attrs = m_xmld.CreateAttribute("state")
        attrs.Value = stringval
        nodocreat.Attributes.Append(attrs)
        connlist.Item(0).ParentNode.InsertBefore(nodocreat, connlist.Item(0))
        m_xmld.Save(txtPerc1.Text)
        'devo riaprire tutto
        ricaricaListaFasi(0)
    End Sub


    Private Sub btnGiu_Click(sender As Object, e As EventArgs) Handles btnGiu.Click
        spostaSuGiu(True)
    End Sub
    Private Sub btnSu_Click(sender As Object, e As EventArgs) Handles btnSu.Click
        spostaSuGiu(False)
    End Sub
    Private Sub spostaSuGiu(Direzione As Boolean)
        Dim numphase As Short = lblPhaseNum.Text
        If Direzione = False And numphase = 0 Then Exit Sub ' sono gia' a 0 , non posso andare su
        If Direzione = True And numphase = lstFasi.Items.Count - 1 Then Exit Sub ' stessa cosa se voglio andare giu con l'ultimo elem
        Dim m_xmld As XmlDocument = New XmlDocument
        m_xmld.Load(txtPerc1.Text)
        Dim connlist As XmlNodeList
        connlist = m_xmld.SelectNodes("net/tlLogic/phase")

        Dim durata As Short = 0
        Dim stringval As String = ""
        For i = 0 To numLabelConn - 1
            stringval &= "r"
        Next

        Dim parentN As XmlNode = connlist.Item(numphase).ParentNode
        Dim previousNode As XmlNode
        If Direzione = False Then
            previousNode = connlist.Item(numphase).PreviousSibling
            parentN.InsertBefore(connlist.Item(numphase), previousNode)
        Else
            previousNode = connlist.Item(numphase).NextSibling
            parentN.InsertAfter(connlist.Item(numphase), previousNode)
        End If
        m_xmld.Save(txtPerc1.Text)
        'devo riaprire tutto
        If Direzione = True Then
            numphase += 1
        Else
            numphase -= 1
        End If
        ricaricaListaFasi(numphase)
    End Sub




    Private Sub btnConvertOSM_Click(sender As Object, e As EventArgs) Handles btnConvertOSM.Click
        Dim filename As String = Path.GetDirectoryName(txtPercSUMO.Text) & "/netconvert.exe"
        Dim scriptPY As New System.Diagnostics.Process
        Dim foutn As String = Path.GetFileNameWithoutExtension(txtPercOSM.Text)
        Dim percn As String = Path.GetDirectoryName(txtPercOSM.Text)
        'devo passare il sumocfg con percorso completo' 
        scriptPY.StartInfo.Arguments =
        "--osm-files " & """" & txtPercOSM.Text & """ " & _
        "-o " & """" & percn & "/" & foutn & ".net.xml"" " & _
        "--log " & """" & percn & "/" & "log.txt"" " & _
        "--remove-edges.isolated true " & _
        "--try-join-tls " & _
        "--tls.guess-signals.dist 100 " & _
        "--tls.guess-signals true " & _
        "--remove-edges.by-vclass hov,taxi,bus,delivery,transport,lightrail,cityrail,rail_slow,rail_fast,motorcycle,bicycle,pedestrian " & _
        "--tls.guess true " & _
        "--no-turnarounds " & _
        "--junctions.join true " & _
        "--junctions.join-dist 40 "
        scriptPY.StartInfo.FileName = filename
        scriptPY.Start()
        scriptPY.WaitForExit()
        scriptPY.Close()
        scriptPY.Dispose()
        txtDebug.Text &= "Conversione conclusa , log dell'operazione nel file " & vbCrLf & percn & "\log.txt"
        '--log <FILE>
        '"--tls.guess-signals.dist 35 " & _
        '
        '    "--remove-edges.by-vclass hov,taxi,bus,delivery,transport,lightrail,cityrail,rail_slow,rail_fast,motorcycle,bicycle,pedestrian " & _
        '
        '
        '"--junctions.join-dist 25 " & _
        '
        '"--tls.join true " & _
        '"--tls.guess-signals true " & _
    End Sub

    Private Sub btnPercSUMO_Click(sender As Object, e As EventArgs) Handles btnPercSUMO.Click
        OpenFileDialog4.ShowDialog()
    End Sub

    Private Sub OpenFileDialog4_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog4.FileOk
        Dim filepath As String = Path.GetDirectoryName(OpenFileDialog4.FileName)
        Dim filename As String = Path.GetFileNameWithoutExtension(OpenFileDialog4.FileName)
        Dim filesok As Boolean = True
        If System.IO.File.Exists(filepath & "/sumo.exe") = False Or _
           System.IO.File.Exists(filepath & "/sumo-gui.exe") = False Or
           System.IO.File.Exists(filepath & "/netconvert.exe") = False Then
            filesok = False
        End If
        If filesok = True Then
            txtPercSUMO.Text = filepath & "/sumo.exe"
            SalvaSetts()
        Else
            MsgBox("Attenzione , alcuni files eseguibili essenziali per il funzionamento del programma non sono stati trovati" _
                & vbCr & "Assicurati di aver selezionato il file eseguibile di SUMO all'interno della cartella 'bin' del pacchetto originale")
        End If
    End Sub


End Class
