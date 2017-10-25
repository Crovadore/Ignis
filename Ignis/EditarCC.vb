Imports TriangleNet.Geometry
Imports MeshExplorer
Imports MeshRenderer.Core

Public Class EditarCC

    Private Linhas_CC_1 As List(Of Object()) = Principal.Linhas_CC_1 'Dirichlet ({Linhas} | Temperatura | Fronteira | Descrição | ID)
    Private Linhas_CC_2 As List(Of Object()) = Principal.Linhas_CC_2 'Neumann ({Linhas} | Fluxo | Fronteira | Descrição | ID)
    Private Linhas_CC_3 As List(Of Object()) = Principal.Linhas_CC_3 'Robin ({Linhas} | Coef. de Convec. | Temp. do Fluido | Fronteira | Descrição | ID)
    Private LinhasUsadas As New List(Of Integer)

    Private Carregado As Boolean = False

    Public renderManager As New RenderManager
    Public WithEvents renderData As New RenderData
    Public settings As New Settings

    Public WithEvents input As New InputGeometry

    Private isResizing As Boolean = False
    Private oldClientSize As Size

    Private Sub EditarCC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            controle.Text = "RenderizadorDeGeometria"

            renderManager.Initialize()
        Else
            MsgBox("Ocorreu um erro ao inicializar o renderizador de geometrias do sistema.", MsgBoxStyle.Critical)
        End If

        renderData = New RenderData

        CarregarAmbienteGrafico()

        Carregado = True

        cTipo.SelectedIndex = 0
        ListarCC()
        ListarLinhasDisponiveis()
    End Sub

    Private Sub CarregarAmbienteGrafico()
        Try
            input = New InputGeometry(Principal.PontosDaGeometria.Count)
            Dim iPonto As Integer = 0

            If Principal.PontosDaGeometria.Count > 0 Then
                For i = 0 To Principal.PontosDaGeometria.Count - 1
                    input.AddPoint(Principal.PontosDaGeometria(i)(0), Principal.PontosDaGeometria(i)(1))
                Next

                If Principal.LinhasDaGeometria.Count > 0 Then
                    For i = 0 To Principal.LinhasDaGeometria.Count - 1
                        Dim FronteiraAtual = Principal.FronteirasDaGeometria.Count
                        If Principal.FronteirasDaGeometria.Count > 0 Then
                            For j = 0 To Principal.FronteirasDaGeometria.Count - 1
                                For k = 0 To UBound(Principal.FronteirasDaGeometria(j))
                                    If Principal.FronteirasDaGeometria(j)(k) = Principal.LinhasDaGeometria(i)(0) OrElse Principal.FronteirasDaGeometria(j)(k) = Principal.LinhasDaGeometria(i)(1) Then
                                        FronteiraAtual = j
                                        GoTo A
                                    End If
                                Next
                            Next
                        End If
A:                      input.AddSegment(Principal.LinhasDaGeometria(i)(0), Principal.LinhasDaGeometria(i)(1), FronteiraAtual + 1)
                    Next
                End If

            End If
            If Principal.PontosEmFurosDaGeometria.Count > 0 Then
                For i = 0 To Principal.PontosEmFurosDaGeometria.Count - 1
                    input.AddHole(Principal.PontosEmFurosDaGeometria(i)(1), Principal.PontosEmFurosDaGeometria(i)(2))
                Next
            End If
            renderData.SetInputGeometry(input)
            renderManager.SetData(renderData)
        Catch ex As Exception
            MsgBox("Ocorreu um erro desconhecido ao gerar a geometria graficamente para visualização!" & vbNewLine & vbNewLine & "Recomenda-se limpar a geometria e tentar novamente.", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ListarCC()
        Dim ListaTemporaria As New List(Of Object)
        lCC.Items.Clear()
        LinhasUsadas.Clear()
        If Linhas_CC_1.Count > 0 Then
            For i = 0 To Linhas_CC_1.Count - 1 'Dirichlet
                Dim NovoItem As New ListViewItem
                NovoItem.Text = "Dirichlet"
                NovoItem.SubItems.Add(CStr(Linhas_CC_1(i)(2) + 1))
                NovoItem.SubItems.Add(Linhas_CC_1(i)(3))
                NovoItem.Tag = {Linhas_CC_1(i), 1, Linhas_CC_1(i)(0)(0)}
                For j = 0 To UBound(Linhas_CC_1(i)(0))
                    LinhasUsadas.Add(Linhas_CC_1(i)(0)(j))
                Next
                ListaTemporaria.Add({NovoItem, Linhas_CC_1(i)(4)})
            Next
        End If
        If Linhas_CC_2.Count > 0 Then
            For i = 0 To Linhas_CC_2.Count - 1 'Neumann
                Dim NovoItem As New ListViewItem
                NovoItem.Text = "Neumann"
                NovoItem.SubItems.Add(CStr(Linhas_CC_2(i)(2) + 1))
                NovoItem.SubItems.Add(Linhas_CC_2(i)(3))
                NovoItem.Tag = {Linhas_CC_2(i), 2, Linhas_CC_2(i)(0)(0)}
                For j = 0 To UBound(Linhas_CC_2(i)(0))
                    LinhasUsadas.Add(Linhas_CC_2(i)(0)(j))
                Next
                ListaTemporaria.Add({NovoItem, Linhas_CC_2(i)(4)})
            Next
        End If
        If Linhas_CC_3.Count > 0 Then
            For i = 0 To Linhas_CC_3.Count - 1 'Robin
                Dim NovoItem As New ListViewItem
                NovoItem.Text = "Robin"
                NovoItem.SubItems.Add(CStr(Linhas_CC_3(i)(3) + 1))
                NovoItem.SubItems.Add(Linhas_CC_3(i)(4))
                NovoItem.Tag = {Linhas_CC_3(i), 3, Linhas_CC_3(i)(0)(0)}
                For j = 0 To UBound(Linhas_CC_3(i)(0))
                    LinhasUsadas.Add(Linhas_CC_3(i)(0)(j))
                Next
                ListaTemporaria.Add({NovoItem, Linhas_CC_3(i)(5)})
            Next
        End If

        ListaTemporaria.Sort(Function(elementA As Object, elementB As Object)
                                 Return CInt(elementA(1)).CompareTo(CInt(elementB(1)))
                             End Function)

        For Each CC In ListaTemporaria
            lCC.Items.Add(CC(0))
        Next
        ListaTemporaria.Clear()
    End Sub

    Private Sub ListarLinhasDisponiveis(Optional ByVal Editando As Boolean = False)
        lLinhasDisponiveis.Items.Clear()
        lLinhasDisponiveis.Groups.Clear()
        If Principal.FronteirasDaGeometria.Count > 0 Then
            For i = 0 To Principal.FronteirasDaGeometria.Count - 1
                Dim NovoGrupo As New ListViewGroup
                NovoGrupo.Header = "Fronteira " & CStr(i + 1)
                NovoGrupo.HeaderAlignment = HorizontalAlignment.Center
                Dim GrupoAdicionado As Boolean = False
                For j = 0 To UBound(Principal.FronteirasDaGeometria(i))
                    If Not LinhasUsadas.Contains(Principal.FronteirasDaGeometria(i)(j)) Then
                        Dim NovoItem As New ListViewItem
                        NovoItem.Text = "Linha " & CStr(Principal.FronteirasDaGeometria(i)(j) + 1)
                        NovoItem.Tag = {i, Principal.FronteirasDaGeometria(i)(j)}
                        NovoItem.Group = NovoGrupo
                        If Not GrupoAdicionado Then
                            GrupoAdicionado = True
                            lLinhasDisponiveis.Groups.Add(NovoGrupo)
                        End If
                        lLinhasDisponiveis.Items.Add(NovoItem)
                    ElseIf Editando Then
                        For k = 0 To UBound(lCC.SelectedItems(0).Tag(0)(0))
                            If Principal.FronteirasDaGeometria(i)(j).Equals(lCC.SelectedItems(0).Tag(0)(0)(k)) Then
                                Dim NovoItem As New ListViewItem
                                NovoItem.Text = "Linha " & CStr(Principal.FronteirasDaGeometria(i)(j) + 1)
                                NovoItem.Tag = {i, Principal.FronteirasDaGeometria(i)(j)}
                                NovoItem.Group = NovoGrupo
                                NovoItem.Checked = True
                                If Not GrupoAdicionado Then
                                    GrupoAdicionado = True
                                    lLinhasDisponiveis.Groups.Add(NovoGrupo)
                                End If
                                lLinhasDisponiveis.Items.Add(NovoItem)
                            End If
                        Next
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub cTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cTipo.SelectedIndexChanged
        Select Case cTipo.SelectedIndex
            Case 0
                lParametro1.Text = "Temperatura:"
                tParametro1.Value = 0
                lParametro2.Hide()
                tParametro2.Hide()
                tParametro2.Enabled = False
                tDescricao.Text = ""
            Case 1
                lParametro1.Text = "Fluxo (q" & ChrW(34) & "):"
                tParametro1.Value = 0
                lParametro2.Hide()
                tParametro2.Hide()
                tParametro2.Enabled = False
                tDescricao.Text = ""
            Case 2
                lParametro1.Text = "Coef. de Convecção:"
                lParametro2.Text = "Temperatura do Fluido:"
                tParametro1.Value = 0
                tParametro2.Value = 0
                lParametro2.Show()
                tParametro2.Show()
                tParametro2.Enabled = True
                tDescricao.Text = ""
        End Select
    End Sub

    Private Sub bVoltar_Click(sender As Object, e As EventArgs) Handles bVoltar.Click
        cTipo.SelectedIndex = 1
        cTipo.SelectedIndex = 0
        For Each item As ListViewItem In lLinhasDisponiveis.SelectedItems
            item.Checked = False
        Next
        bMarcar.Text = "Marcar Selecionadas (0)"
        If bCadastrar.Text = "Confirmar Edição" Then ListarLinhasDisponiveis()
        bCadastrar.Text = "Cadastrar Condição de Contorno"
        lLinhasDisponiveis.SelectedIndices.Clear()
        PainelCadastro.Hide()
        PainelCadastro.Enabled = False
        PainelConsulta.Show()
        PainelConsulta.Enabled = True
    End Sub

    Private Sub P_Cadastrar_Click(sender As Object, e As EventArgs) Handles bAdicionar.Click
        PainelConsulta.Hide()
        PainelConsulta.Enabled = False
        PainelCadastro.Show()
        PainelCadastro.Enabled = True
    End Sub

    Private Sub lLinhasDisponiveis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lLinhasDisponiveis.SelectedIndexChanged
        bMarcar.Text = "Marcar Selecionadas (" & CStr(lLinhasDisponiveis.SelectedIndices.Count) & ")"
        bMarcar.Enabled = True
        input.LinhasDestacadas.Clear()
        If lLinhasDisponiveis.SelectedItems.Count > 0 Then
            For Each linha As ListViewItem In lLinhasDisponiveis.SelectedItems
                input.AddLinhaDestacada(Principal.LinhasDaGeometria(linha.Tag(1))(0), Principal.LinhasDaGeometria(linha.Tag(1))(1))
            Next
        End If
        HandleNewInput()
    End Sub

    Private Sub bDesmarcar_Click(sender As Object, e As EventArgs) Handles bDesmarcar.Click
        For Each item As ListViewItem In lLinhasDisponiveis.CheckedItems
            item.Checked = False
        Next
    End Sub

    Private Sub bMarcar_Click(sender As Object, e As EventArgs) Handles bMarcar.Click
        For Each item As ListViewItem In lLinhasDisponiveis.SelectedItems
            item.Checked = True
        Next
        lLinhasDisponiveis.SelectedIndices.Clear()
        bMarcar.Enabled = False
    End Sub

    Private Sub bCadastrar_Click(sender As Object, e As EventArgs) Handles bCadastrar.Click
        Try
            Dim Linhas(lLinhasDisponiveis.CheckedItems.Count - 1) As Integer
            Dim Fronteira As Integer = lLinhasDisponiveis.CheckedItems(0).Tag(0)
            For i = 0 To lLinhasDisponiveis.CheckedItems.Count - 1
                If lLinhasDisponiveis.CheckedItems(i).Tag(0) <> Fronteira Then
                    MsgBox("Escolha apenas linhas de uma mesma fronteira!", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                Linhas(i) = lLinhasDisponiveis.CheckedItems(i).Tag(1)
            Next
            Dim ID As Integer = lCC.Items.Count
            If bCadastrar.Text = "Confirmar Edição" Then
                ID = lCC.SelectedIndices(0)
                If Not RemoverCC(True) = True Then
                    MsgBox("Ocorreu um erro desconhecido durante a edição da condição de contorno. Por favor, tente novamente.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
            End If

            Select Case cTipo.SelectedIndex
                Case 0 'Dirichlet
                    Linhas_CC_1.Add({Linhas, CDbl(tParametro1.Value), Fronteira, tDescricao.Text, ID})
                Case 1 'Neumann
                    Linhas_CC_2.Add({Linhas, CDbl(tParametro1.Value), Fronteira, tDescricao.Text, ID})
                Case 2 'Robin
                    Linhas_CC_3.Add({Linhas, CDbl(tParametro1.Value), CDbl(tParametro2.Value), Fronteira, tDescricao.Text, ID})
            End Select
A:          ListarCC()
            ListarLinhasDisponiveis()
            Call bVoltar_Click(Nothing, Nothing)
            MsgBox("Condição de contorno cadastrada/editada com sucesso!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Ocorreu um erro desconhecido ao tentar cadastrar/editar a nova condição de contorno." & vbNewLine & vbNewLine & "Por favor, tente novamente com novos parâmetros.", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub EditarCC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub lLinhasDisponiveis_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles lLinhasDisponiveis.ItemChecked
        If lLinhasDisponiveis.CheckedItems.Count > 0 Then bCadastrar.Enabled = True Else bCadastrar.Enabled = False
    End Sub

    Private Sub lCC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lCC.SelectedIndexChanged
        input.LinhasDestacadas.Clear()
        If lCC.SelectedIndices.Count = 0 Then
            bRemover.Enabled = False
            bEditar.Enabled = False
        ElseIf lCC.SelectedIndices.Count = 1 Then
            For Each linha In lCC.SelectedItems(0).Tag(0)(0)
                input.AddLinhaDestacada(Principal.LinhasDaGeometria(linha)(0), Principal.LinhasDaGeometria(linha)(1))
            Next
            bRemover.Enabled = True
            bEditar.Enabled = True
        Else
            For Each cc As ListViewItem In lCC.SelectedItems
                For Each linha In cc.Tag(0)(0)
                    input.AddLinhaDestacada(Principal.LinhasDaGeometria(linha)(0), Principal.LinhasDaGeometria(linha)(1))
                Next
            Next
            bRemover.Enabled = True
            bEditar.Enabled = False
        End If
        HandleNewInput()
    End Sub

    Private Function RemoverCC(ByVal Editando As Boolean) As Boolean
        Try
            If lCC.SelectedIndices.Count = 0 Then
                Return False
                Exit Function
            End If
            For i = lCC.SelectedIndices.Count - 1 To 0 Step -1
                Select Case lCC.Items(lCC.SelectedIndices(i)).Tag(1)
                    Case 1 'Dirichlet
                        For j = 0 To Linhas_CC_1.Count - 1
                            If Linhas_CC_1(j)(4).Equals(lCC.SelectedIndices(i)) Then
                                Linhas_CC_1.RemoveAt(j)
                                Exit For
                            End If
                        Next
                    Case 2 'Neumann
                        For j = 0 To Linhas_CC_2.Count - 1
                            If Linhas_CC_2(j)(4).Equals(lCC.SelectedIndices(i)) Then
                                Linhas_CC_2.RemoveAt(j)
                                Exit For
                            End If
                        Next
                    Case 3 'Robin
                        For j = 0 To Linhas_CC_3.Count - 1
                            If Linhas_CC_3(j)(5).Equals(lCC.SelectedIndices(i)) Then
                                Linhas_CC_3.RemoveAt(j)
                                Exit For
                            End If
                        Next
                End Select
                If Not Editando Then
                    For j = 0 To Linhas_CC_1.Count - 1
                        If Linhas_CC_1(j)(4) > lCC.SelectedIndices(i) Then Linhas_CC_1(j)(4) = CInt(Linhas_CC_1(j)(4)) - 1
                    Next
                    For j = 0 To Linhas_CC_2.Count - 1
                        If Linhas_CC_2(j)(4) > lCC.SelectedIndices(i) Then Linhas_CC_2(j)(4) = CInt(Linhas_CC_2(j)(4)) - 1
                    Next
                    For j = 0 To Linhas_CC_3.Count - 1
                        If Linhas_CC_3(j)(5) > lCC.SelectedIndices(i) Then Linhas_CC_3(j)(5) = CInt(Linhas_CC_3(j)(5)) - 1
                    Next
                End If
            Next

            If Not Editando Then ListarCC()
            If Not Editando Then ListarLinhasDisponiveis()
            If Not Editando Then MsgBox("Condição(ões) de contorno removida(s) com sucesso!", MsgBoxStyle.Information)
            Return True
        Catch ex As Exception
            If Not Editando Then MsgBox("Ocorreu um erro desconhecido ao tentar remover a(s) condição(ões) de contorno selecionada(s)." & vbNewLine & vbNewLine & "Por favor, tente novamente.", MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    Private Sub bRemover_Click(sender As Object, e As EventArgs) Handles bRemover.Click
        If lCC.SelectedItems.Count > 0 Then
            If MsgBox("Deseja remover a(s) condição(ões) de contorno selecionada(s)?" & vbNewLine & vbNewLine & "Esta ação é irreversível!", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                RemoverCC(False)
            End If
        End If
    End Sub

    Private Sub lCC_KeyDown(sender As Object, e As KeyEventArgs) Handles lCC.KeyDown
        If lCC.SelectedItems.Count > 0 Then
            If e.KeyCode = Keys.Delete Then
                If MsgBox("Deseja remover a(s) condição(ões) de contorno selecionada(s)?" & vbNewLine & vbNewLine & "Esta ação é irreversível!", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    RemoverCC(False)
                End If
            End If
        End If
        If e.KeyCode = Keys.A AndAlso e.Control = True Then
            For Each item As ListViewItem In lCC.Items
                item.Selected = True
            Next
        End If
    End Sub

    Private Sub bEditar_Click(sender As Object, e As EventArgs) Handles bEditar.Click
        If lCC.SelectedItems.Count <> 1 Then Exit Sub
        bCadastrar.Text = "Confirmar Edição"
        cTipo.SelectedIndex = lCC.SelectedItems(0).Tag(1) - 1
        tDescricao.Text = lCC.SelectedItems(0).SubItems(2).Text
        tParametro1.Value = lCC.SelectedItems(0).Tag(0)(1)
        If lCC.SelectedItems(0).Tag(1) = 3 Then tParametro2.Value = lCC.SelectedItems(0).Tag(0)(2)
        ListarLinhasDisponiveis(True)
        PainelConsulta.Hide()
        PainelConsulta.Enabled = False
        PainelCadastro.Show()
        PainelCadastro.Enabled = True
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

    Private Sub HandleNewInput()
        renderData.SetInputGeometry(input)
        renderManager.SetData(renderData)
    End Sub

    Private Sub lCC_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lCC.MouseDoubleClick
        Call bEditar_Click(Nothing, Nothing)
    End Sub

    Private Sub EditarCC_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Linhas_CC_1.Count = 0 AndAlso Linhas_CC_3.Count = 0 Then
            If MsgBox("Para que a simulação produza um único resultado, é necessário especificar ao menos 1 (uma) condição de contorno Dirichlet ou Robin." & vbNewLine & vbNewLine & "Deseja mesmo sair?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then e.Cancel = True
        End If
    End Sub
End Class
