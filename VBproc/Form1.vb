Imports System.IO
Imports System.Xml

Public Class Form1


    Public Sub SalvaSetts()
        SaveSetting("VBproc", "PercFiles", "xml1", txtPerc1.Text)
        SaveSetting("VBproc", "PercFiles", "xml2", txtPercSave.Text)
    End Sub
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'evento unload form
        SalvaSetts()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPerc1.Text = GetSetting("VBproc", "PercFiles", "xml1")
        txtPercSave.Text = GetSetting("VBproc", "PercFiles", "xml2")
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
    Private Sub OpenFileDialog2_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog2.FileOk
        txtPercSave.Text = OpenFileDialog2.FileName
        SalvaSetts()
    End Sub
    Private Sub btnExec1_Click(sender As Object, e As EventArgs) Handles btnExec1.Click
        'leggo il file xml
        'prova?
        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node, m_node1 As XmlNode
            Dim m_net As XmlNode
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
                    If links.Count > 3 Then ' sto processando l'incrocio principale
                        'se l'id della linea e' indicato con - allora la strada proviene dall'alto verso il basso o da 
                        'destra verso sinistra
                        'arrivato qui ho individuato l' incrocio di interesse
                        'elimino i junction che non mi servono



                        'devo considerare tutte le direzioni dei links inclusi
                        Dim buff() As String = links
                        ReDim links(links.Count * 2 - 1)
                        ReDim puntiJunction(links.Count * 2 - 1, 1)  ' qui salvo i punti della junction man mano che li trovo
                        ReDim versi(links.Count * 2 - 1) 'qui dentro mi segno i versi delle junction
                        Dim j As Short = 0

                        For i = 0 To buff.Length - 1
                            links(j) = buff(i).Replace("-", "")
                            links(j + 1) = "-" & buff(i).Replace("-", "")
                            j += 2
                        Next

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
                                If distanza > 50 Then
                                    'arrivato qui dentro ho trovato l'ultimo punto da modificare
                                    Dim punto As Punto = calcLastPoint(pi, pf, 50 - distanza, verso, i)
                                    pf.X = punto.X
                                    pf.Y = punto.Y
                                    puntiSTRMod &= punto.X.ToString("#.##").Replace(",", ".") & _
                                    "," & punto.Y.ToString("#.##").Replace(",", ".") & " "
                                    distanza = 50
                                    Exit For
                                End If
                                diff = distanza
                                puntiSTRMod &= pf.X.ToString("#.##").Replace(",", ".") & _
                                    "," & pf.Y.ToString("#.##").Replace(",", ".") & " "
                            Next
                            If distanza < 50 Then ' se sono uscito dal loop senza effettuare modifiche
                                Dim punto As Punto = calcLastPoint(pi, pf, 50 - distanza, verso, i) ' in teoria lo allunga
                                puntiSTRMod &= punto.X.ToString("#.##").Replace(",", ".") & _
                                    "," & punto.Y.ToString("#.##").Replace(",", ".") & " "
                            End If

                            If verso = True Then
                                'se l'ultimo punto della lista non e' quello vicino all'incrocio allora devo 
                                ' invertire l'ordine di tutti i punti 
                                puntiSTRMod = invertiPunti(puntiSTRMod)
                            End If
                            m_node1.Attributes.GetNamedItem("shape").Value = puntiSTRMod
                            m_node1.Attributes.GetNamedItem("length").Value = "50"

                            ' costruzione della junction :

                        Next


                        Dim lnkA As String, lnkB As String 'metto in ordine la stringa , lnkA va per primo
                        For j = 0 To links.Length - 1 Step 2
                            ' devo trovare la junction 

                            Dim m_nodeJ As XmlNode = m_net.SelectSingleNode("//junction[@incLanes='" & _
                                    links(j) & "']")
                            If IsNothing(m_nodeJ) Then
                                m_nodeJ = m_net.SelectSingleNode("//junction[@incLanes='" & _
                                    links(j + 1) & "']")
                            End If
                            If versi(j) = True Then
                                lnkA = puntiJunction(j, 0) & " " & puntiJunction(j, 1)
                            Else
                                lnkB = puntiJunction(j, 0) & " " & puntiJunction(j, 1)
                            End If
                            If versi(j + 1) = True Then
                                lnkA = puntiJunction(j + 1, 0) & " " & puntiJunction(j + 1, 1)
                            Else
                                lnkB = puntiJunction(j + 1, 0) & " " & puntiJunction(j + 1, 1)
                            End If
                            m_nodeJ.Attributes.GetNamedItem("shape").Value = lnkA & " " & lnkB
                        Next
                    End If
                End If
            Next
            'TODO , gestione delle svolte al semaforo , per ora sorvolo e lascio a SUMO il compito di regolarle


            'da qui in poi genero il routefile con le informazioni su ogni automobile che passa sull'incrocio nell'arco di tempo considerato
            'creo il nuovo file per la generazione di tutti i percorsi di tutte le automobili della simulazione 
            Dim filepath As String = Path.GetDirectoryName(txtPerc1.Text)
            Dim filename As String = Path.GetFileNameWithoutExtension(txtPerc1.Text)
            Dim nuovofile As String = filepath & "/" & filename & ".rou.xml"
            If Not System.IO.File.Exists(nuovofile) Then
                System.IO.File.Create(nuovofile).Dispose()
            End If
            Dim objWriter As New System.IO.StreamWriter(nuovofile, True)
            Dim stringOUTPUT As String = "<routes>" & vbCrLf
            'definisco come sono fatte le auto QUI
            stringOUTPUT &= "<vType id=""Auto1"" accel=""0.8"" decel=""4.5"" sigma=""0.5"" length=""5"" minGap=""2.5"" maxSpeed=""16.67"" guiShape=""passenger""/>" & vbCrLf & vbCrLf
            'definisco tutte le possibili svolte QUI 
            ' queste sono tutte le possibili combinazioni I-O , sono le stesse informazioni che avrei sul file net.xml
            'di sumo , semplicemente le riporto qui nel giusto formato . Sono tutte le connection con state "o"
            m_nodelist = m_xmld.SelectNodes("net/connection")
            Dim rouNUM As Short = 0
            For Each m_node In m_nodelist
                Dim fromAttr = m_node.Attributes.GetNamedItem("from").Value
                Dim toAttr = m_node.Attributes.GetNamedItem("to").Value
                Dim stateAttr = m_node.Attributes.GetNamedItem("state").Value
                If stateAttr = "o" Then ' devo includerlo nel file ROU.XML
                    stringOUTPUT &= "<route id=""route" & rouNUM & """ edges=""" & fromAttr & " " & toAttr & """ />" & vbCrLf & vbCrLf
                End If
                rouNUM += 1
            Next
            'definisco OGNI POSSIBILE autoveicolo che attraversa la junction secondo una distribuzione definita 
            Dim numCICLI As Short = 3600 'TEST , devo sceglierlo a runtime
            'per ogni direzione ho diverse probabilita' 
            Dim probGlobale As Double = 1 / 20 ' ipotizzo per ora la stessa probabilita' su ogni OD TEST
            Dim rand As New Random() ' qui andrebbe specificato il SEED se occorre
            Randomize()
            Dim veicNUM As Short = 0
            For i = 1 To numCICLI
                For j = 0 To rouNUM
                    If rand.NextDouble < probGlobale Then ' allora devo inserire la car nel circuito
                        '<vehicle id="left_0" type="typeWE" route="left" depart="0" />
                        stringOUTPUT &= "<vehicle id=""veic_" & veicNUM & " type=""auto1"" route=""route" & j & _
                            """ depart=""" & i & """ />" & vbCrLf
                    End If
                Next
            Next
            stringOUTPUT &= "</routes>"
            'ho concluso la costruzione del file 


            objWriter.WriteLine(stringOUTPUT) 'salvo  file .rou.xml e lo chiudo 
            objWriter.Close()
            m_xmld.Save(txtPercSave.Text) 'salvo il file .net.xml in una nuova posizione
            txtDebug.Text &= "File output salvato!" & vbCrLf

            'arrivato qui devo inizializzare sumo attraverso python , in quanto le librerie traci non sono compatibili con .net
        Catch errorVariable As Exception
            txtDebug.Text &= "Errore XML: " & (errorVariable.ToString()) & vbCrLf
        End Try
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click

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
        Dim filenamePY As String = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName)
        filenamePY = filenamePY & "\VBproc\PythonScript\PythonScript.py"
        Dim scriptPY As New System.Diagnostics.Process
        scriptPY = System.Diagnostics.Process.Start(filenamePY)

    End Sub
End Class
