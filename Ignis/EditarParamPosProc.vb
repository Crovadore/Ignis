Public Class EditarParamPosProc

    Public Alterado As Boolean = False

    Private Sub EditarParamPosProc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case Principal.TipoDeVisualizacao
            Case 1 'Gradiente de Temperaturas
                cTipoExib.SelectedIndex = 0
            Case 2 'Linhas Isotérmicas
                cTipoExib.SelectedIndex = 1
            Case Else 'Não implementado...
                cTipoExib.SelectedIndex = 0
        End Select
        If Principal.EscalaDeCinza = True Then cEsqCores.SelectedIndex = 1 Else cEsqCores.SelectedIndex = 0
        tPasso.Value = Principal.PassoEntreIsotermas
        Select Case Principal.Imagem_Tamanho
            Case 500 '500 x 500 pixels
                cTamanho.SelectedIndex = 0
            Case 1000 '1000 x 1000 pixels
                cTamanho.SelectedIndex = 1
            Case 1500 '1500 x 1500 pixels
                cTamanho.SelectedIndex = 2
            Case 2000 '2000 x 2000 pixels
                cTamanho.SelectedIndex = 3
            Case Else 'Desconhecido, 500 x 500 pixels
                cTamanho.SelectedIndex = 0
        End Select
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTipoExib.SelectedIndexChanged
        Select Case cTipoExib.SelectedIndex
            Case 0 'Gradiente de Temperaturas
                lPasso.Enabled = False
                lPasso.Hide()
                lEsquema.Enabled = True
                lEsquema.Show()
                tPasso.Enabled = False
                tPasso.Hide()
                lUT.Enabled = False
                lUT.Hide()
                cEsqCores.Enabled = True
                cEsqCores.Show()
            Case 1 'Linhas Isotérmicas
                lEsquema.Enabled = False
                lEsquema.Hide()
                lPasso.Enabled = True
                lPasso.Show()
                cEsqCores.Enabled = False
                cEsqCores.Hide()
                tPasso.Enabled = True
                tPasso.Show()
                lUT.Enabled = True
                lUT.Show()
            Case Else 'Não implementado...
                lPasso.Enabled = False
                lPasso.Hide()
                lEsquema.Enabled = True
                lEsquema.Show()
                tPasso.Enabled = False
                tPasso.Hide()
                lUT.Enabled = False
                lUT.Hide()
                cEsqCores.Enabled = True
                cEsqCores.Show()
        End Select
    End Sub

    Private Sub bAceitar_Click(sender As Object, e As EventArgs) Handles bAceitar.Click
        Select Case cTipoExib.SelectedIndex
            Case 0 'Gradiente de Temperaturas
                If Principal.TipoDeVisualizacao <> 1 Then Alterado = True
                Principal.TipoDeVisualizacao = 1
            Case 1 'Linhas Isotérmicas
                If Principal.TipoDeVisualizacao <> 2 Then Alterado = True
                Principal.TipoDeVisualizacao = 2
            Case Else 'Não implementado...
                If Principal.TipoDeVisualizacao <> 1 Then Alterado = True
                Principal.TipoDeVisualizacao = 1
        End Select
        If cEsqCores.SelectedIndex = 0 Then
            If Principal.EscalaDeCinza <> False Then Alterado = True
            Principal.EscalaDeCinza = False
        Else
            If Principal.EscalaDeCinza <> True Then Alterado = True
            Principal.EscalaDeCinza = True
        End If
        If Principal.PassoEntreIsotermas <> tPasso.Value Then Alterado = True
        Principal.PassoEntreIsotermas = tPasso.Value
        Select Case cTamanho.SelectedIndex
            Case 0 '500 x 500 pixels
                If Principal.Imagem_Tamanho <> 500 Then Alterado = True
                Principal.Imagem_Tamanho = 500
            Case 1 '1000 x 1000 pixels
                If Principal.Imagem_Tamanho <> 1000 Then Alterado = True
                Principal.Imagem_Tamanho = 1000
            Case 2 '1500 x 1500 pixels
                If Principal.Imagem_Tamanho <> 1500 Then Alterado = True
                Principal.Imagem_Tamanho = 1500
            Case 3 '2000 x 2000 pixels
                If Principal.Imagem_Tamanho <> 2000 Then Alterado = True
                Principal.Imagem_Tamanho = 2000
            Case Else 'Desconhecido, 500 x 500 pixels
                If Principal.Imagem_Tamanho <> 500 Then Alterado = True
                Principal.Imagem_Tamanho = 500
        End Select
        Me.Close()
    End Sub

End Class
