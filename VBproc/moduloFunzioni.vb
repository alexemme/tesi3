Structure Punto ' definisco una struttura punto , che a differenza di quello base e' con i numeri con virgola.
    Dim X As Double
    Dim Y As Double
End Structure


Module moduloFunzioni
    Public puntiJunction(,) As String ' qui salvo i punti della junction man mano che li trovo
    Public versi() As Boolean
    Public numTxtArrivi As Short = 0
    Public txtArriviArray(10) As TextBox ' gestisco fino a 10 linee ?
    Dim lblArriviArray(10) As Label
    Public listaIncLanesJunction(10) As String
    Public corrispondenzaLanes(100) As Short ' qui ho la corrispondenza numConnection<->numLinea

    'Public Function ordinaPuntiMIN(ByVal puntoJunction As Punto, ByRef puntoA As Punto, ByRef puntoB As Punto) As Boolean
    '    ' questa funzione mi ordina i due punti in modo che puntoA sia sempre quello a distanza minore da puntoJunct
    '    Dim distA, distB As Double
    '    'calcolo distanza A 
    '    distA = Math.Sqrt((puntoJunction.X - puntoA.X) ^ 2 + (puntoJunction.Y - puntoA.Y) ^ 2)
    '    distB = Math.Sqrt((puntoJunction.X - puntoB.X) ^ 2 + (puntoJunction.Y - puntoB.Y) ^ 2)
    '    If distA > distB Then ' altrimenti sono 
    '        Dim puntoC As Punto
    '        puntoC.X = puntoA.X
    '        puntoC.Y = puntoA.Y
    '        puntoA.X = puntoB.X
    '        puntoA.Y = puntoB.Y
    '        puntoB.X = puntoC.X
    '        puntoB.Y = puntoC.Y
    '        Return True
    '    End If
    '    Return True
    'End Function
    Public Function ordinaPuntiMIN(ByVal puntoJunction As Punto, ByRef arraypunti() As Punto) As Boolean
        'questa funzione mi ordina i punti dal piu vicino la junction al piu distante , inoltre restituisce un bool che se true mi indica che ho effettivamente modificato l'ordine dell'array
        Dim distA, distB As Double
        'calcolo distanza A 
        distA = Math.Sqrt((puntoJunction.X - arraypunti(0).X) ^ 2 + (puntoJunction.Y - arraypunti(0).Y) ^ 2)
        distB = Math.Sqrt((puntoJunction.X - arraypunti(arraypunti.Count - 1).X) ^ 2 + (puntoJunction.Y - arraypunti(arraypunti.Count - 1).Y) ^ 2)
        If distA > distB Then ' altrimenti sono gia ordinati bene
            'devo invertire i punti
            Dim buf(arraypunti.Length - 1) As Punto
            Dim a As Short = 0
            For i = arraypunti.Length - 1 To 0 Step -1
                buf(a) = arraypunti(i)
                a += 1
            Next
            arraypunti = buf
            Return True
        End If
        Return False
    End Function
    Public Function calcLastPoint(ByVal p2 As Punto, ByVal p1 As Punto, diff As Double, verso As Boolean, indiceJunct As Short) As Punto
        'calcolo sia il punto finale che i due punti che faranno parte della junction all'estremo
        Dim PX As Punto
        Dim m As Double = (p2.Y - p1.Y) / (p2.X - p1.X)
        Dim q As Double = p1.Y - m * p1.X
        Dim a As Double = (1 + m ^ 2)
        Dim b As Double = (-2 * p1.X + 2 * m * (q - p1.Y))
        Dim c As Double = p1.X ^ 2 + (q - p1.Y) ^ 2 - diff ^ 2
        ' attenzione , ho due soluzioni per x , quindi ho 2 punti , devo controllare che il punto scelto sia quello che effettivamente allunghi il segmento , non quello che lo accorcia
        Dim x1 As Double = (-b - Math.Sqrt(b ^ 2 - 4 * a * c)) / (2 * a)
        Dim x2 As Double = (-b + Math.Sqrt(b ^ 2 - 4 * a * c)) / (2 * a)

        Dim dist1 As Double = Math.Sqrt((x1 - p2.X) ^ 2 + ((m * x1 + q) - p2.Y) ^ 2)
        Dim dist2 As Double = Math.Sqrt((x2 - p2.X) ^ 2 + ((m * x2 + q) - p2.Y) ^ 2)
        If dist1 > dist2 Then
            If diff < 0 Then
                PX.X = x2 ' entra qui nel caso io stia accorciando a 50 il segmento
            Else
                PX.X = x1
            End If
        Else
            If diff < 0 Then
                PX.X = x1
            Else
                PX.X = x2
            End If

        End If
        PX.Y = m * PX.X + q

        'ora calcolo i punti della junction 
        diff = 1.6
        m = -1 / m
        q = -m * PX.X + PX.Y
        a = (1 + m ^ 2)
        b = (-2 * PX.X + 2 * m * (q - PX.Y))
        c = PX.X ^ 2 + (q - PX.Y) ^ 2 - diff ^ 2
        x1 = (-b - Math.Sqrt(b ^ 2 - 4 * a * c)) / (2 * a)
        Dim y1 As Double = m * x1 + q
        x2 = (-b + Math.Sqrt(b ^ 2 - 4 * a * c)) / (2 * a)
        Dim y2 As Double = m * x2 + q

        Dim ax As Short = Math.Abs(indiceJunct / 2)
        puntiJunction(indiceJunct, 0) = x1.ToString("#.##").Replace(",", ".") & "," & y1.ToString("#.##").Replace(",", ".") ' salvo i punti in un buffer 
        puntiJunction(indiceJunct, 1) = x2.ToString("#.##").Replace(",", ".") & "," & y2.ToString("#.##").Replace(",", ".") ' e li assemblo dopo su form1
        versi(indiceJunct) = verso ' mi devo ricordare del verso
        Return PX
    End Function




    Public Function invertiPunti(stringaPunti As String) As String
        Dim punti() As String = stringaPunti.Split(" ")
        Dim nuovastringa As String = ""
        For i = punti.Count - 1 To 0 Step -1
            nuovastringa &= punti(i)
            If i <> 0 Then
                nuovastringa &= " "
            End If
        Next
        Return nuovastringa
    End Function

    Public Sub creaFileCfg(nomefile As String)
        Dim filepath1 As String = IO.Path.GetDirectoryName(Form1.txtPercSave.Text)
        Dim filename1 As String = IO.Path.GetFileNameWithoutExtension(Form1.txtPercSave.Text)
        Dim pospto As Short = Strings.InStr(filename1, ".") ' rimuovo la seconda parte di estensione se e' presente 
        If pospto > 0 Then
            filename1 = filename1.Remove(pospto - 1)
        End If
        Dim nuovofile As String = filepath1 & "/" & filename1 & ".sumocfg"
        If Not System.IO.File.Exists(nuovofile) Then
            System.IO.File.Create(nuovofile).Dispose()
        Else
            IO.File.Delete(nuovofile)
        End If
        Dim objWriter As New System.IO.StreamWriter(nuovofile, True)
        Dim stringOUTPUT As String = "<configuration>" & vbCrLf & "<input>" & _
            vbCrLf & "<net-file value=""" & nomefile & ".net.xml""/>" & vbCrLf & _
         "<route-files value=""" & nomefile & ".rou.xml""/>" & vbCrLf & _
         "</input>" & vbCrLf & "<time>" & vbCrLf & "<begin value=""0""/>" & vbCrLf & _
        "</time>" & vbCrLf & "<report>" & vbCrLf & "<verbose value=""true""/>" & vbCrLf & _
        "<no-step-log value=""true""/>" & vbCrLf & "</report>" & vbCrLf & _
        "</configuration>"
        objWriter.WriteLine(stringOUTPUT) 'salvo  file .rou.xml e lo chiudo 
        objWriter.Close()

    End Sub


    Public Sub generaBoxArrivi(idLane As String)
        'creo il textbox e lo incollo nell'altra tab degli arrivi
        txtArriviArray(numTxtArrivi) = New TextBox
        txtArriviArray(numTxtArrivi).Name = "txtArrivi" & numTxtArrivi
        txtArriviArray(numTxtArrivi).Size = New Size(50, 20)
        txtArriviArray(numTxtArrivi).Location = New Point(200, 35 + 26 * numTxtArrivi)
        txtArriviArray(numTxtArrivi).Text = "100" 'arrivi/ora , valore di base da modificare
        Form1.TabPage2.Controls.Add(txtArriviArray(numTxtArrivi))

        lblArriviArray(numTxtArrivi) = New Label
        lblArriviArray(numTxtArrivi).Name = "lblArrivi" & numTxtArrivi
        lblArriviArray(numTxtArrivi).AutoSize = True
        lblArriviArray(numTxtArrivi).Location = New Point(8, 38 + 26 * numTxtArrivi)
        lblArriviArray(numTxtArrivi).Text = "Linea " & idLane
        Form1.TabPage2.Controls.Add(lblArriviArray(numTxtArrivi))
        numTxtArrivi += 1
    End Sub

    Public Sub TrovaCorrispondenzaLineaPercorso(id As String, numid As Short)
        For i = 0 To listaIncLanesJunction.Length - 1
            If id & "_0" = listaIncLanesJunction(i) Then
                'corrispondenza trovata
                corrispondenzaLanes(numid) = i
                Exit Sub
            End If
        Next
    End Sub

    Public Function Factorial(ByVal Factor As Byte) As Object
        '******************************************************
        'PURPOSE:
        'SOLVE FACTORIALS: N!, or N*(N-1)*(N-2)*...*2*1
        'Parameter: N
        'Returns: Factorial

        'EXAMPLE: 
        'MsgBox Factorial(6) 
        'Will display 720 because 6 * 5 * 4 * 3 * 2 * 1 = 720

        'NOTE: Overflow will occur with any parameter over 170
        '******************************************************

        On Error GoTo ErrorHandler

        If Factor = 0 Then
            Factorial = 1
        Else
            Factorial = Factor * Factorial(Factor - 1)
        End If
        Exit Function

ErrorHandler:
        If Err.Number = 6 Then 'oveflow
            Err.Raise(Err.Number, , _
           "Overflow: Number passed to function was too large")

        Else 'unknown reason for error, shouldn't occur
            Err.Raise(Err.Number, , Err.Description)
        End If
    End Function
End Module
