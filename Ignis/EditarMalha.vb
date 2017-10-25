Imports TriangleNet
Imports TriangleNet.Geometry
Imports MeshExplorer
Imports MeshRenderer.Core
Imports MeshExplorer.IO
Imports TriangleNet.Data
Imports System.Threading

Public Class EditarMalha

    Private Pontos As List(Of Double()) = Principal.PontosDaGeometria
    Private Linhas As List(Of Integer()) = Principal.LinhasDaGeometria
    Private Fronteiras As List(Of Integer()) = Principal.FronteirasDaGeometria
    Private PontosEmFuros As List(Of Object()) = Principal.PontosEmFurosDaGeometria
    Private Malha As Mesh

    Private Carregado As Boolean = False

    Public MalhaDefinida As Boolean = False

    Public renderManager As New RenderManager
    Public WithEvents renderData As New RenderData
    Public settings As New Settings

    Public input As New InputGeometry

    Private Processo_SegundoPlano As Thread

    Private MensagemDeErro As String = ""

    Private isResizing As Boolean = False
    Private oldClientSize As Size

    Private Sub GeradorDeMalhas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TempoLimite.Interval = Principal.TempoLimite_Malha * 1000

        oldClientSize = Me.ClientSize
        settings = New Settings

        renderManager = New RenderManager
        renderManager.CreateDefaultControl()

        Dim controle As Control = renderManager.RenderControl

        If controle IsNot Nothing Then
            splitContainer1.Panel2.Controls.Add(controle)
            controle.BackColor = Color.Black
            controle.Dock = DockStyle.Fill
            controle.Font = New Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
            controle.Location = New Drawing.Point(0, 0)
            controle.Name = "Renderizador1"
            controle.Size = splitContainer1.Panel2.Size
            controle.TabIndex = 0
            controle.Text = "RenderizadorDeMalhas"

            renderManager.Initialize()
        Else
            MsgBox("Ocorreu um erro ao inicializar o renderizador de malhas do sistema.", MsgBoxStyle.Critical)
        End If

        renderData = New RenderData

        GetMalha()

        If Malha Is Nothing Then
            ResetarGeometria()
            CarregarGeometriaOriginal()
            TratarMudancaNaGeometria()
        End If

        Carregado = True
    End Sub

    Private Sub CarregarGeometriaOriginal()
        Try
            input = New InputGeometry(Pontos.Count)
            Dim iPonto As Integer = 0

            If Pontos.Count > 0 Then
                For i = 0 To Pontos.Count - 1
                    input.AddPoint(Pontos(i)(0), Pontos(i)(1), -1)
                Next

                If Linhas.Count > 0 Then
                    For i = 0 To Linhas.Count - 1
A:                      input.AddSegment(Linhas(i)(0), Linhas(i)(1), i + 1)
                    Next
                End If

            End If
            If PontosEmFuros.Count > 0 Then
                For i = 0 To PontosEmFuros.Count - 1
                    input.AddHole(PontosEmFuros(i)(1), PontosEmFuros(i)(2))
                Next
            End If
        Catch ex As Exception
            MalhaDefinida = False
            MsgBox("Ocorreu um erro desconhecido ao gerar a geometria graficamente para visualização!" & vbNewLine & vbNewLine & "Recomenda-se limpar a geometria e tentar novamente.", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ResetarGeometria()
        input.Clear()
        settings.RefineMode = False
        settings.ExceptionThrown = False
        StatisticView1.HandleNewInput(input)
    End Sub

    Private Sub ResetarMalha()
        If Malha IsNot Nothing Then
            Malha.ResetData()
            Malha = Nothing
        End If
        settings.RefineMode = False
        settings.ExceptionThrown = False
        btnMesh.Enabled = True
        btnMesh.Text = "Gerar Malha"
        btnSmooth.Enabled = False
    End Sub

    Private Sub TratarMudancaNaGeometria()
        renderData.SetInputGeometry(input)
        renderManager.SetData(renderData)
        StatisticView1.HandleNewInput(input)
    End Sub

    Private Sub TratarMudancaNaMalha()
        renderData.SetMesh(Malha)
        renderManager.SetData(renderData)
        StatisticView1.HandleMeshUpdate(Malha)
        StatisticView1.HandleMeshChange(Malha)
        If meshControlView.ParamQualityChecked Then
            settings.RefineMode = True
            btnMesh.Text = "Refinar Malha"
            btnSmooth.Enabled = Malha.IsPolygon
        End If
    End Sub

    Private Sub Recarregar()
        ResetarMalha()
        ResetarGeometria()
        CarregarGeometriaOriginal()
        TratarMudancaNaGeometria()
    End Sub

    Private Sub btnMesh_Click(sender As Object, e As EventArgs) Handles btnMesh.Click
        Try
            TriangularOuRefinar()
        Catch ex As Exception
            MsgBox("Ocorreu um erro crítico na triangulação da malha!" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            Recarregar()
        End Try
    End Sub

    Private Sub btnSmooth_Click(sender As Object, e As EventArgs) Handles btnSmooth.Click
        Try
            Suavizar()
        Catch ex As Exception
            MsgBox("Ocorreu um erro crítico na suavização da malha!" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            Recarregar()
        End Try
    End Sub

    Private Sub DarkButton1_Click(sender As Object, e As EventArgs) Handles DarkButton1.Click
        Try
            Recarregar()
        Catch ex As Exception
            MsgBox("Ocorreu um erro crítico ao recarregar a malha!" & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            Me.Close()
        End Try
    End Sub

    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
        Dim container = Me.splitContainer1.Panel2.ClientRectangle
        Dim pt As System.Drawing.Point = e.Location
        pt.Offset(-splitContainer1.SplitterDistance, 0)
        If container.Contains(pt) Then
            renderManager.Zoom(CSng(pt.X) / container.Width, CSng(pt.Y) / container.Height, e.Delta)
        End If
        MyBase.OnMouseWheel(e)
    End Sub

    Private Sub ResizeHandler(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Carregado Then
            If Not isResizing Then
                renderManager.HandleResize()
            End If
        End If
    End Sub

    Private Sub ResizeEndHandler(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        If Carregado Then
            isResizing = False
            If Me.ClientSize <> Me.oldClientSize Then
                Me.oldClientSize = Me.ClientSize
                renderManager.HandleResize()
            End If
        End If

    End Sub

    Private Sub ResizeBeginHandler(sender As Object, e As EventArgs) Handles MyBase.ResizeBegin
        If Carregado Then
            isResizing = True
        End If
    End Sub

    Private Sub TriangularOuRefinar()
        If (input Is Nothing AndAlso Not settings.RefineMode) OrElse settings.ExceptionThrown Then
            Return
        End If

        If settings.RefineMode = False Then
            Triangular()

            If meshControlView.ParamQualityChecked Then
                btnMesh.Text = "Refinar Malha"
                btnSmooth.Enabled = Malha.IsPolygon
            End If
        ElseIf meshControlView.ParamQualityChecked Then
            Refinar()
        End If
    End Sub

    Private Sub Triangular()
        If input Is Nothing Then
            Return
        End If

        Malha = New Mesh()

        If meshControlView.ParamConformDelChecked Then
            Malha.Behavior.ConformingDelaunay = True
        End If

        If meshControlView.ParamSweeplineChecked Then
            Malha.Behavior.Algorithm = TriangulationAlgorithm.SweepLine
        End If

        If meshControlView.ParamQualityChecked Then
            Malha.Behavior.Quality = True
            Malha.Behavior.MinAngle = meshControlView.ParamMinAngleValue
            Dim maxAngle As Double = meshControlView.ParamMaxAngleValue

            If maxAngle < 180 Then
                Malha.Behavior.MaxAngle = maxAngle
            End If
        End If

        If meshControlView.ParamConvexChecked Then
            Malha.Behavior.Convex = True
        End If

        Processo_SegundoPlano = New Thread(AddressOf _Triangular)
        IniciarVerificacaoDeStatus()
        Processo_SegundoPlano.Start()
    End Sub

    Private Sub Refinar()
        If Malha Is Nothing Then Exit Sub

        Dim area As Double = meshControlView.ParamMaxAreaValue

        If area > 0 AndAlso area < 1 Then
            Malha.Behavior.MaxArea = area * StatisticView1.Statistic.LargestArea
        End If

        Malha.Behavior.MinAngle = meshControlView.ParamMinAngleValue

        Dim maxAngle As Double = meshControlView.ParamMaxAngleValue

        If maxAngle < 180 Then
            Malha.Behavior.MaxAngle = maxAngle
        End If

        Processo_SegundoPlano = New Thread(AddressOf _Refinar)
        IniciarVerificacaoDeStatus()
        Processo_SegundoPlano.Start()
    End Sub

    Private Sub Suavizar()
        If Malha Is Nothing OrElse settings.ExceptionThrown Then Exit Sub

        If Not Malha.IsPolygon Then Exit Sub

        Processo_SegundoPlano = New Thread(AddressOf _Suavizar)
        IniciarVerificacaoDeStatus()
        Processo_SegundoPlano.Start()
    End Sub

    Private Sub IniciarVerificacaoDeStatus()
        MensagemDeErro = ""
        splitContainer1.Panel1.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        VerificaStatus.Start()
        TempoLimite.Start()
    End Sub

    Private Sub EncerrarVerificacaoDeStatus()
        VerificaStatus.Stop()
        TempoLimite.Stop()
        splitContainer1.Panel1.Enabled = True
        Me.Cursor = Cursors.Arrow
        If MensagemDeErro <> "" Then
            MsgBox("Ocorreu um erro crítico no processamento da malha!" & vbNewLine & vbNewLine & MensagemDeErro, MsgBoxStyle.Critical)
            Recarregar()
        End If
    End Sub

    Private Sub _Triangular()
        Try
            Malha.Triangulate(input)
        Catch ex As Exception
            MensagemDeErro = ex.Message
        End Try
    End Sub

    Private Sub _Refinar()
        Try
            Malha.Refine()
        Catch ex As Exception
            MensagemDeErro = ex.Message
        End Try
    End Sub

    Private Sub _Suavizar()
        Try
            Malha.Smooth()
        Catch ex As Exception
            MensagemDeErro = ex.Message
        End Try
    End Sub

    Private Sub TempoLimite_Tick(sender As Object, e As EventArgs) Handles TempoLimite.Tick
        If Processo_SegundoPlano IsNot Nothing Then
            If Processo_SegundoPlano.IsAlive Then Processo_SegundoPlano.Suspend()
        End If
        MensagemDeErro = "O processo foi abortado por ter excedido seu tempo limite, de " & CStr(TempoLimite.Interval / 1000) & " segundo(s)." & vbNewLine & vbNewLine & "A malha foi resetada."
        EncerrarVerificacaoDeStatus()
    End Sub

    Private Sub VerificaStatus_Tick(sender As Object, e As EventArgs) Handles VerificaStatus.Tick
        VerificaStatus.Stop()
        If Processo_SegundoPlano IsNot Nothing Then
            If Processo_SegundoPlano.IsAlive Then
                If MensagemDeErro <> "" Then EncerrarVerificacaoDeStatus() Else VerificaStatus.Start()
                Exit Sub
            End If
        End If
        EncerrarVerificacaoDeStatus()
        If Malha IsNot Nothing Then
            StatisticView1.UpdateStatistic(Malha)
            TratarMudancaNaMalha()
        End If
    End Sub

    Private Sub EditarMalha_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SetMalha()
        If Malha Is Nothing Then
            MalhaDefinida = False
        Else
            If Malha.Triangles.Count = 0 Then MalhaDefinida = False Else MalhaDefinida = True
            input.Clear()
            Malha.ResetData()
            Malha = Nothing
        End If
    End Sub

    Public Sub SetMalha()
        Principal.PontosDaMalha.Clear()
        Principal.LinhasDeContornoDaMalha.Clear()
        Principal.TriangulosDaMalha.Clear()

        If Malha Is Nothing Then Exit Sub
        If Malha.Triangles.Count = 0 Then Exit Sub

        If Malha.CurrentNumbering = NodeNumbering.None Then Malha.Renumber()

        For Each Ponto As Vertex In Malha.Vertices
            If Not Malha.Behavior.Jettison OrElse Ponto.Type <> VertexType.UndeadVertex Then
                Principal.PontosDaMalha.Add({Ponto.X, Ponto.Y, Ponto.Boundary})
            End If
        Next

        For Each Linha As Segment In Malha.Segments
            Principal.LinhasDeContornoDaMalha.Add({Linha.P0, Linha.P1, Linha.Boundary})
        Next

        For Each Triangulo As Triangle In Malha.Triangles
            Principal.TriangulosDaMalha.Add({Triangulo.P0, Triangulo.P1, Triangulo.P2})
        Next
    End Sub

    Public Sub GetMalha()
        Malha = Nothing
        If Principal.TriangulosDaMalha.Count > 0 Then
            Malha = New Mesh
            Malha.Carregar(Principal.PontosDaMalha, Principal.LinhasDeContornoDaMalha, Principal.TriangulosDaMalha, Principal.PontosEmFurosDaGeometria, input)
            Principal.PontosDaMalha.Clear()
            Principal.LinhasDeContornoDaMalha.Clear()
            Principal.TriangulosDaMalha.Clear()
            StatisticView1.UpdateStatistic(Malha)
            renderData.SetInputGeometry(input)
            renderData.SetMesh(Malha)
            renderManager.SetData(renderData)
            StatisticView1.HandleNewInput(input)
            StatisticView1.HandleMeshImport(input, Malha)
            StatisticView1.HandleMeshChange(Malha)
            btnMesh.Enabled = True
            settings.RefineMode = True
            btnMesh.Text = "Refinar Malha"
            btnSmooth.Enabled = True
        End If
    End Sub
End Class