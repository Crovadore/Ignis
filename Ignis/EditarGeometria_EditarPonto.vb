Public Class EditarGeometria_EditarPonto

    Public Coord As Double()

    Private Sub bCancelar_Click(sender As Object, e As EventArgs) Handles bCancelar.Click
        Me.Close()
    End Sub

    Private Sub bAceitar_Click(sender As Object, e As EventArgs) Handles bAceitar.Click
        If IsNumeric(tCoordX.Text) AndAlso IsNumeric(tCoordY.Text) Then
            If CDbl(tCoordX.Text) < 0 OrElse CDbl(tCoordY.Text) < 0 Then
                MsgBox("Insira apenas coordenadas positivas!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            Coord(0) = CDbl(tCoordX.Text)
            Coord(1) = CDbl(tCoordY.Text)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Digite coordenadas válidas!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub EditarGeometria_EditarPonto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub EditarGeometria_EditarPonto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tCoordX.Text = CStr(Coord(0))
        tCoordY.Text = CStr(Coord(1))
    End Sub
End Class
