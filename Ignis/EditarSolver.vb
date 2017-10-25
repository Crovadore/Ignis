Public Class EditarSolver

    Private Sub EditarSolver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Principal.PontosDaMalha.Count > 16384 Then
            rSolverSimples.Enabled = False
            rSolverDecompQR.Enabled = False
        End If
        Select Case Principal.TipoDeSolver
            Case 1 'Solver Simples (inversão de matriz)
                rSolverSimples.Checked = True
            Case 2 'Decomposição QR
                rSolverDecompQR.Checked = True
            Case 3 'Decomposição LU
                rSolverDecompLU.Checked = True
            Case Else 'Não implementado...
                rSolverSimples.Checked = True
        End Select
    End Sub

    Private Sub bAceitar_Click(sender As Object, e As EventArgs) Handles bAceitar.Click
        If rSolverSimples.Checked = True Then
            Principal.TipoDeSolver = 1
        ElseIf rSolverDecompQR.Checked = True Then
            Principal.TipoDeSolver = 2
        ElseIf rSolverDecompLU.Checked = True Then
            Principal.TipoDeSolver = 3
        Else
            Principal.TipoDeSolver = 1
        End If
        Me.Close()
    End Sub

    Private Sub EditarSolver_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub
End Class
