Structure Punto ' definisco una struttura punto , che a differenza di quello base e' con i numeri con virgola.
    Dim X As Double
    Dim Y As Double
End Structure
Module moduloFunzioni
    Public Function ordinaPuntiMIN(ByVal puntoJunction As Punto, ByRef puntoA As Punto, ByRef puntoB As Punto) As Boolean
        ' questa funzione mi ordina i due punti in modo che puntoA sia sempre quello a distanza minore da puntoJunct
        Dim distA, distB As Double
        'calcolo distanza A 
        distA = Math.Sqrt((puntoJunction.X - puntoA.X) ^ 2 + (puntoJunction.Y - puntoA.Y) ^ 2)
        distB = Math.Sqrt((puntoJunction.X - puntoB.X) ^ 2 + (puntoJunction.Y - puntoB.Y) ^ 2)
        If distA > distB Then ' altrimenti sono 
            Dim puntoC As Punto
            puntoC.X = puntoA.X
            puntoC.Y = puntoA.Y
            puntoA.X = puntoB.X
            puntoA.Y = puntoB.Y
            puntoB.X = puntoC.X
            puntoB.Y = puntoC.Y
            Return True
        End If
        Return True
    End Function
    Public Function calcLastPoint(ByVal p1 As Punto, ByVal p2 As Punto, diff As Double) As Punto
        Dim PX As Punto
        Dim m As Double = (p2.Y - p1.Y) / (p2.X - p1.X)
        Dim q As Double = p1.Y - m * p1.X
        Dim a As Double = (1 + m ^ 2)
        Dim b As Double = (-2 * p1.X + 2 * m * (q - p1.Y))
        Dim c As Double = p1.X ^ 2 + (q - p1.Y) ^ 2 - diff ^ 2
        PX.X = (-b + Math.Sqrt(b ^ 2 - 4 * a * c)) / (2 * a) ' attenzione , ho due soluzioni per x , quindi ho 2 punti
        PX.Y = m * PX.X + q
        Return PX
    End Function
End Module
