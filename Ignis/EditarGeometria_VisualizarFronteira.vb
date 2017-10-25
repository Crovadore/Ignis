Public Class EditarGeometria_VisualizarFronteira

    Public Fronteira As Integer()

    Private Sub bAceitar_Click(sender As Object, e As EventArgs) Handles bAceitar.Click
        Me.Close()
    End Sub

    Public Sub CarregarLista(ByRef Linhas As List(Of Integer()))
        For i_Linha = 0 To Linhas.Count - 1
            For Each Linha In Fronteira
                If CLng(i_Linha).Equals(Linha) Then
                    Dim NovoItem As New ListViewItem
                    NovoItem.Text = CStr(i_Linha + 1)
                    NovoItem.SubItems.Add(CStr(Linhas(i_Linha)(0)))
                    NovoItem.SubItems.Add(CStr(Linhas(i_Linha)(1)))
                    L_Lista.Items.Add(NovoItem)
                    Exit For
                End If
            Next
        Next
    End Sub

    Private Sub EditarGeometria_VisualizarFronteira_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class
