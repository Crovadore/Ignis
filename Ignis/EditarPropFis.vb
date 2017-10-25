Public Class EditarPropFis

    Private Sub EditarPropFis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tEspessura.Value = Principal.Espessura
        tMassaEspecifica.Value = Principal.MassaEspecifica
        tCondutividade.Value = Principal.CondutividadeTermica
        tGeracao.Value = Principal.GeracaoDeCalor
    End Sub

    Private Sub bAceitar_Click(sender As Object, e As EventArgs) Handles bAceitar.Click
        If tEspessura.Value > 0 Then
            If tMassaEspecifica.Value > 0 Then
                If tCondutividade.Value > 0 Then
                    Principal.Espessura = tEspessura.Value
                    Principal.MassaEspecifica = tMassaEspecifica.Value
                    Principal.CondutividadeTermica = tCondutividade.Value
                    Principal.GeracaoDeCalor = tGeracao.Value
                    Me.Close()
                Else
                    MsgBox("Digite um valor válido para a Condutividade Térmica!", MsgBoxStyle.Exclamation)
                    tCondutividade.Select()
                End If
            Else
                MsgBox("Digite um valor válido para a Densidade!", MsgBoxStyle.Exclamation)
                tMassaEspecifica.Select()
            End If
        Else
            MsgBox("Digite um valor válido para a Espessura!", MsgBoxStyle.Exclamation)
            tEspessura.Select()
        End If
    End Sub

    Private Sub EditarPropFis_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class
