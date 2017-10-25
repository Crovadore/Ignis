Public Class VisualizarResultados

    Private Sub VisualizarResultados_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub bAceitar_Click(sender As Object, e As EventArgs) Handles bAceitar.Click
        Me.Close()
    End Sub

    Private Sub bObter_Click(sender As Object, e As EventArgs) Handles bObter.Click
        Try
            If Not IsNumeric(tPosX.Text) OrElse Not IsNumeric(tPosY.Text) Then
                tFluxoX.Text = "---"
                tFluxoY.Text = "---"
                tTemperatura.Text = "---"
                MsgBox("Digite uma posição válida!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Dim No As Integer = NoNaPosicao({CDbl(tPosX.Text), CDbl(tPosY.Text)})
            If No <> -1 Then
                tFluxoX.Text = "---"
                tFluxoY.Text = "---"
                tTemperatura.Text = CStr(Principal.VetorDeTemperaturas(No, 0))
            Else
                Dim Elemento As Integer = ElementoNaPosicao({CDbl(tPosX.Text), CDbl(tPosY.Text)})
                If Elemento <> -1 Then
                    Dim N_1, N_2, N_3, T_1, T_2, T_3, Temperatura, Temp_Max, Temp_Min, FluxoX, FluxoY As Double
                    N_1 = Math.Abs((Principal.MatrizDeFuncoesDeForma(0, Elemento) + (Principal.MatrizDeFuncoesDeForma(3, Elemento) * CDbl(tPosX.Text)) + (Principal.MatrizDeFuncoesDeForma(6, Elemento) * CDbl(tPosY.Text))) / Principal.MatrizDeFuncoesDeForma(9, Elemento))
                    N_2 = Math.Abs((Principal.MatrizDeFuncoesDeForma(1, Elemento) + (Principal.MatrizDeFuncoesDeForma(4, Elemento) * CDbl(tPosX.Text)) + (Principal.MatrizDeFuncoesDeForma(7, Elemento) * CDbl(tPosY.Text))) / Principal.MatrizDeFuncoesDeForma(9, Elemento))
                    N_3 = Math.Abs((Principal.MatrizDeFuncoesDeForma(2, Elemento) + (Principal.MatrizDeFuncoesDeForma(5, Elemento) * CDbl(tPosX.Text)) + (Principal.MatrizDeFuncoesDeForma(8, Elemento) * CDbl(tPosY.Text))) / Principal.MatrizDeFuncoesDeForma(9, Elemento))
                    T_1 = Principal.VetorDeTemperaturas(Principal.TriangulosDaMalha(Elemento)(0), 0)
                    T_2 = Principal.VetorDeTemperaturas(Principal.TriangulosDaMalha(Elemento)(1), 0)
                    T_3 = Principal.VetorDeTemperaturas(Principal.TriangulosDaMalha(Elemento)(2), 0)
                    Temperatura = ((N_1 * T_1) + (N_2 * T_2) + (N_3 * T_3))
                    Temp_Max = Math.Max(T_1, Math.Max(T_2, T_3))
                    Temp_Min = Math.Min(T_1, Math.Min(T_2, T_3))
                    If Temperatura > Temp_Max Then Temperatura = Temp_Max
                    If Temperatura < Temp_Min Then Temperatura = Temp_Min
                    FluxoX = (Principal.CondutividadeTermica * -1 / Principal.MatrizDeFuncoesDeForma(9, Elemento)) * ((Principal.MatrizDeFuncoesDeForma(3, Elemento) * T_1) + (Principal.MatrizDeFuncoesDeForma(4, Elemento) * T_2) + (Principal.MatrizDeFuncoesDeForma(5, Elemento) * T_3))
                    FluxoY = (Principal.CondutividadeTermica * -1 / Principal.MatrizDeFuncoesDeForma(9, Elemento)) * ((Principal.MatrizDeFuncoesDeForma(6, Elemento) * T_1) + (Principal.MatrizDeFuncoesDeForma(7, Elemento) * T_2) + (Principal.MatrizDeFuncoesDeForma(8, Elemento) * T_3))
                    tFluxoX.Text = CStr(FluxoX)
                    tFluxoY.Text = CStr(FluxoY)
                    tTemperatura.Text = CStr(Temperatura)
                Else
                    tFluxoX.Text = "---"
                    tFluxoY.Text = "---"
                    tTemperatura.Text = "---"
                End If
            End If
        Catch ex As Exception
            MsgBox("Ocorreu um erro desconhecido!" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Function ElementoNaPosicao(ByRef Pos() As Double) As Integer
        Dim CoordX(1), CoordY(1) As Double
        Dim minX, maxX, minY, maxY As Double
        For i = 0 To Principal.TriangulosDaMalha.Count - 1
            CoordX = {Principal.PontosDaMalha(Principal.TriangulosDaMalha(i)(0))(0), Principal.PontosDaMalha(Principal.TriangulosDaMalha(i)(1))(0), Principal.PontosDaMalha(Principal.TriangulosDaMalha(i)(2))(0)}
            CoordY = {Principal.PontosDaMalha(Principal.TriangulosDaMalha(i)(0))(1), Principal.PontosDaMalha(Principal.TriangulosDaMalha(i)(1))(1), Principal.PontosDaMalha(Principal.TriangulosDaMalha(i)(2))(1)}
            minX = Math.Min(CoordX(0), Math.Min(CoordX(1), CoordX(2)))
            maxX = Math.Max(CoordX(0), Math.Max(CoordX(1), CoordX(2)))
            minY = Math.Min(CoordY(0), Math.Min(CoordY(1), CoordY(2)))
            maxY = Math.Max(CoordY(0), Math.Max(CoordY(1), CoordY(2)))
            If Pos(0) < minX OrElse Pos(0) > maxX OrElse Pos(1) < minY OrElse Pos(1) > maxY Then
                Continue For
            End If
            If Principal.PontoNoPoligono(Pos, CoordX, CoordY) Then
                Return i
                Exit Function
            End If
        Next
        Return -1
    End Function

    Private Function NoNaPosicao(ByRef Pos() As Double) As Integer
        For i = 0 To Principal.PontosDaMalha.Count - 1
            If Principal.PontosDaMalha(i)(0).Equals(Pos(0)) AndAlso Principal.PontosDaMalha(i)(1).Equals(Pos(1)) Then
                Return i
                Exit Function
            End If
        Next
        Return -1
    End Function
End Class
