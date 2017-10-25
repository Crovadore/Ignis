Public Class EditarGeometria_EditarLinha

    Public Linha As Integer()

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Me.Close()
    End Sub

    Private Sub bAceitar_Click(sender As Object, e As EventArgs) Handles bAceitar.Click
        If L_Ponto1.Items.Contains(L_Ponto1.Text) AndAlso L_Ponto2.Items.Contains(L_Ponto2.Text) AndAlso L_Ponto1.Text <> L_Ponto2.Text AndAlso IsNumeric(L_Ponto1.Text) AndAlso IsNumeric(L_Ponto2.Text) Then
            Linha(0) = CLng(L_Ponto1.Text)
            Linha(1) = CLng(L_Ponto2.Text)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Selecione pontos válidos!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub EditarGeometria_EditarLinha_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub EditarGeometria_EditarLinha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        L_Ponto1.Text = CStr(Linha(0))
        L_Ponto2.Text = CStr(Linha(1))
    End Sub
End Class
