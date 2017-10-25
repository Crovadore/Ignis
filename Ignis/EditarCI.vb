Public Class EditarCI

    Private Sub EditarCI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tTemperatura.Value = IIf(Principal.TemperaturaInicial = -999999999.999, 0, Principal.TemperaturaInicial)
    End Sub

    Private Sub bAceitar_Click(sender As Object, e As EventArgs) Handles bAceitar.Click
        Principal.TemperaturaInicial = tTemperatura.Value
        Me.Close()
    End Sub

    Private Sub EditarCI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class
