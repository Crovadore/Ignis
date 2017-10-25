Public Class EditarParamProc

    Private Sub EditarParamProc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case Principal.TipoDeAnalise
            Case 1 'Condução de Calor em Regime Permanente
                rCondPerm.Checked = True
            Case 2 'Condução de Calor em Regime Transiente
                rCondTrans.Checked = True
            Case Else 'Não implementado...
                rCondPerm.Checked = True
        End Select
    End Sub

    Private Sub bAceitar_Click(sender As Object, e As EventArgs) Handles bAceitar.Click
        If rCondPerm.Checked = True Then
            Principal.TipoDeAnalise = 1
        ElseIf rCondTrans.Checked = True Then
            Principal.TipoDeAnalise = 2
        Else
            Principal.TipoDeAnalise = 1
        End If
        Me.Close()
    End Sub

    Private Sub EditarParamProc_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class
