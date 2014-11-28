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
                                    Dim punto As Punto = calcLastPoint(pi, pf, 50 - distanza)
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
                                Dim punto As Punto = calcLastPoint(pi, pf, 50 - distanza) ' in teoria lo allunga
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
                            'devo controllare che il verso della strada sia uguale a quello originale , ergo 
                            'l'ultimo nodo della lista deve essere quello vicino all'incrocio





                        Next

                    End If
                    'If links.Count = 1 Then
                    '    m_net.RemoveChild(m_node) ' se volessi rimuovere un nodo,
                    'End If
                End If
            Next

            'TODO , eliminare le internal lanes edges dell'incrocio che non esiste piu' e inoltre tutte le referenze
            'se non funziona , occorre semplicemente allungare /accorciaere le strade e mettere i nuovi punti al termine 
            'di quelle strade!
            m_xmld.Save(txtPercSave.Text) 'salvo il file in una nuova posizione
            txtDebug.Text &= "File output salvato!" & vbCrLf
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


    End Sub
End Class
