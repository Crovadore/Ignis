Imports Microsoft.VisualBasic.FileIO.FileSystem

Public Class RenomearSimulacao

    Private Sub RenomearSimulacao_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Partes() As String = Split(Principal.ArquivoIgnisAtual, "\")
        tNome.Text = Partes(UBound(Partes)).Replace(".ignis", "")
    End Sub

    Private Sub tNome_TextChanged(sender As Object, e As EventArgs) Handles tNome.TextChanged
        tNome.Text = tNome.Text.Replace("\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace(ChrW(34), "").Replace("<", "").Replace(">", "").Replace("|", "").Replace(".ignis", "")
    End Sub

    Private Sub bConfirmar_Click(sender As Object, e As EventArgs) Handles bConfirmar.Click
        Try
            Dim Partes() As String = Split(Principal.ArquivoIgnisAtual, "\")
            RenameFile(Principal.ArquivoIgnisAtual, tNome.Text & ".ignis")
            Principal.ArquivoIgnisAtual = Principal.ArquivoIgnisAtual.Replace(Partes(UBound(Partes)), tNome.Text & ".ignis")
            Principal.TreeView1.Nodes(0).Text = " " & tNome.Text & ".ignis"
        Catch ex As Exception
            MsgBox("Ocorreu um erro desconhecido ao tentar renomear o arquivo!" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical)
        End Try
        Me.Close()
    End Sub

    Private Sub bSair_Click(sender As Object, e As EventArgs) Handles bSair.Click
        Me.Close()
    End Sub

    Private Sub RenomearSimulacao_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class
