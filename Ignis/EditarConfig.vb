Public Class EditarConfig
    Private Sub EditarConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tTempo.Value = CInt(GetSetting("Ignis", "Configurações", "TempoLimite_Malha", "10"))
        Select Case GetSetting("Ignis", "Configurações", "SolverPadrao", "1")
            Case "1"
                rSimples.Checked = True
            Case "2"
                rDecompQR.Checked = True
            Case Else
                rDecompLU.Checked = True
        End Select
        Select Case GetSetting("Ignis", "Configurações", "VisualizacaoPadrao", "1")
            Case "1"
                rGradColor.Checked = True
            Case "2"
                rGradEC.Checked = True
            Case Else
                rIsotermas.Checked = True
        End Select
    End Sub

    Private Sub bAceitar_Click(sender As Object, e As EventArgs) Handles bAceitar.Click
        SaveSetting("Ignis", "Configurações", "TempoLimite_Malha", CStr(tTempo.Value))
        SaveSetting("Ignis", "Configurações", "SolverPadrao", IIf(rSimples.Checked, "1", IIf(rDecompQR.Checked, "2", "3")))
        SaveSetting("Ignis", "Configurações", "VisualizacaoPadrao", IIf(rGradColor.Checked, "1", IIf(rGradEC.Checked, "2", "3")))
        Me.Close()
    End Sub

    Private Sub EditarConfig_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class
