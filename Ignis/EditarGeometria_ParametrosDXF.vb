Imports System.Windows.Forms

Public Class EditarGeometria_ParametrosDXF

    Dim Circulo As New Bitmap(270, 270)
    Dim g As Graphics

    Private Sub DarkButton4_Click(sender As Object, e As EventArgs) Handles bLocalizar.Click
        Dim ofd As New OpenFileDialog()

        ofd.Filter = "Arquivo DXF (*.dxf)|*.dxf"
        ofd.FilterIndex = 1
        ofd.FileName = ""

        If ofd.ShowDialog() = DialogResult.OK Then
            EditarGeometria.ImportarDXF(ofd.FileName, NumericUpDown1.Value, NumericUpDown2.Value)
        End If
        Me.Close()
    End Sub

    Private Sub EditarGeometria_ParametrosDXF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Circulo.MakeTransparent()
        NumericUpDown1.Value = 30
    End Sub

    Private Sub EditarGeometria_ParametrosDXF_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        If NumericUpDown1.Value >= 1 AndAlso NumericUpDown1.Value <= 120 Then
            Circulo.Dispose()
            Circulo = New Bitmap(270, 270)
            g = Graphics.FromImage(Circulo)
            Dim graypen As New Pen(Color.DarkGray, 1)
            g.DrawArc(graypen, New Rectangle(0, 0, 269, 269), 0, 360)
            Dim Ponto_Central_X As Single = 134
            Dim Ponto_Central_Y As Single = 134
            Dim Raio As Single = 134
            Dim QuantidadeDeQuebras As Single = Math.Ceiling(360 / NumericUpDown1.Value)
            Dim AnguloDeQuebra_Real As Single = ((360 / QuantidadeDeQuebras) * Math.PI) / 180
            Dim Ponto_Inicial_X As Single = Ponto_Central_X
            Dim Ponto_Inicial_Y As Single = 0 'Começa no topo do círculo
            Dim PontosDoArco As New List(Of Single())
            PontosDoArco.Add({Ponto_Inicial_X, Ponto_Inicial_Y})
            Dim AnguloAtual As Single = AnguloDeQuebra_Real
            For i_Linha = 0 To QuantidadeDeQuebras - 1
                Ponto_Inicial_X = Ponto_Central_X + (Raio * Math.Sin(AnguloAtual))
                Ponto_Inicial_Y = Ponto_Central_Y - (Raio * Math.Cos(AnguloAtual))
                PontosDoArco.Add({Ponto_Inicial_X, Ponto_Inicial_Y})
                AnguloAtual += AnguloDeQuebra_Real
            Next
            Dim whitepen As New Pen(Color.White, 2)
            For i_Linha = 0 To PontosDoArco.Count - 2
                g.DrawLine(whitepen, New PointF(PontosDoArco(i_Linha)(0), PontosDoArco(i_Linha)(1)), New PointF(PontosDoArco(i_Linha + 1)(0), PontosDoArco(i_Linha + 1)(1)))
            Next
            g.Dispose()
            Panel1.BackgroundImage = Circulo
        End If
    End Sub
End Class
