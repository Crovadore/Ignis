Imports System.IO.File
Imports TriangleNet.Geometry
Imports MeshRenderer.Core

Public Class EditarGeometria

    Private Pontos As List(Of Double()) = Principal.PontosDaGeometria
    Private Linhas As List(Of Integer()) = Principal.LinhasDaGeometria
    Private Fronteiras As List(Of Integer()) = Principal.FronteirasDaGeometria
    Private PontosEmFuros As List(Of Object()) = Principal.PontosEmFurosDaGeometria

    Public WithEvents input As New InputGeometry
    Public WithEvents renderData As New RenderData
    Public renderManager As New RenderManager

    Private Carregado As Boolean = False

    Public GeometriaDefinida As Boolean = False

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles bImportar.Click
        If P_Lista.Items.Count > 0 Then
            If Not MsgBox("Ao fazer a importação de um arquivo DXF, todas as informações serão perdidas, mesmo que o processo de importação não seja concluído por algum motivo." & vbNewLine & vbNewLine & "Deseja continuar?", vbQuestion + MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then Exit Sub
        End If
        EditarGeometria_ParametrosDXF.ShowDialog()
    End Sub

    Public Sub ImportarDXF(ByVal CaminhoDoArquivo As String, ByVal AnguloDeQuebra_Max As Double, ByVal Precisao As Integer)
        Try
            Dim Conteudo() As String = ReadAllLines(CaminhoDoArquivo)

            Pontos.Clear()
            Linhas.Clear()
            Fronteiras.Clear()
            PontosEmFuros.Clear()

            input.Clear()

            Dim Ponto_Inicial_X As Double = 0.0
            Dim Ponto_Inicial_Y As Double = 0.0
            Dim Ponto_Final_X As Double = 0.0
            Dim Ponto_Final_Y As Double = 0.0

            Dim k As Integer = 0

            Dim i_Ponto_Inicial As Integer = -1
            Dim i_Ponto_Final As Integer = -1

            Dim PontosDoArco As New List(Of Double())
            Dim Ponto_Central_X As Double = 0.0
            Dim Ponto_Central_Y As Double = 0.0
            Dim Raio As Double
            Dim QuantidadeDeQuebras As Integer
            Dim AnguloAtual As Double
            Dim AnguloDeQuebra_Real As Double
            Dim AnguloDeInicio As Double
            Dim AnguloDeTermino As Double

            Dim NovaFronteira(0) As Integer

            'LISTAGEM DE TODOS OS PONTOS E LINHAS DO DESENHO, DIVIDINDO ARCOS E CÍRCULOS EM LINHAS
            For i = 0 To UBound(Conteudo)
                If Conteudo(i).ToUpper = "ENTITIES" Then
                    For j = i + 2 To UBound(Conteudo) 'Início das entidades do desenho
                        If Conteudo(j).ToUpper.Contains("ENDSEC") Then GoTo A 'Marca o fim das entidades do desenho

                        If Conteudo(j).ToUpper.Equals("LINE") Then 'LINHA
                            Ponto_Inicial_X = -999999999.999
                            Ponto_Inicial_Y = -999999999.999
                            Ponto_Final_X = -999999999.999
                            Ponto_Final_Y = -999999999.999
                            For k = j To UBound(Conteudo)
                                If Conteudo(k).Equals("  0") Then Exit For 'Fim das propriedades da linha
                                If Conteudo(k).Equals(" 10") Then Ponto_Inicial_X = Math.Round(CDbl(Conteudo(k + 1).Replace(".", ",")), Precisao, MidpointRounding.ToEven)
                                If Conteudo(k).Equals(" 20") Then Ponto_Inicial_Y = Math.Round(CDbl(Conteudo(k + 1).Replace(".", ",")), Precisao, MidpointRounding.ToEven)
                                If Conteudo(k).Equals(" 11") Then Ponto_Final_X = Math.Round(CDbl(Conteudo(k + 1).Replace(".", ",")), Precisao, MidpointRounding.ToEven)
                                If Conteudo(k).Equals(" 21") Then Ponto_Final_Y = Math.Round(CDbl(Conteudo(k + 1).Replace(".", ",")), Precisao, MidpointRounding.ToEven)
                            Next
                            If Not (Ponto_Inicial_X <> -999999999.999 AndAlso Ponto_Inicial_Y <> -999999999.999 AndAlso Ponto_Final_X <> -999999999.999 AndAlso Ponto_Final_Y <> -999999999.999) Then
                                MsgBox("Ocorreu um erro de leitura do arquivo DXF. É impossível continuar.", MsgBoxStyle.Critical)
                                Pontos.Clear()
                                Linhas.Clear()
                                Fronteiras.Clear()
                                PontosEmFuros.Clear()
                                Exit Sub
                            End If
                            j = k
                            If Pontos.Count = 0 Then
                                Pontos.Add({Ponto_Inicial_X, Ponto_Inicial_Y})
                                Pontos.Add({Ponto_Final_X, Ponto_Final_Y})
                                Linhas.Add({0, 1})
                            Else
                                i_Ponto_Inicial = -1
                                i_Ponto_Final = -1
                                For i_Ponto = 0 To Pontos.Count - 1
                                    If Pontos(i_Ponto)(0).Equals(Ponto_Inicial_X) AndAlso Pontos(i_Ponto)(1).Equals(Ponto_Inicial_Y) Then i_Ponto_Inicial = i_Ponto
                                    If Pontos(i_Ponto)(0).Equals(Ponto_Final_X) AndAlso Pontos(i_Ponto)(1).Equals(Ponto_Final_Y) Then i_Ponto_Final = i_Ponto
                                    If i_Ponto_Inicial <> -1 AndAlso i_Ponto_Final <> -1 Then Exit For
                                Next
                                If i_Ponto_Inicial = -1 Then
                                    Pontos.Add({Ponto_Inicial_X, Ponto_Inicial_Y})
                                    i_Ponto_Inicial = Pontos.Count - 1
                                End If
                                If i_Ponto_Final = -1 Then
                                    Pontos.Add({Ponto_Final_X, Ponto_Final_Y})
                                    i_Ponto_Final = Pontos.Count - 1
                                End If
                                Linhas.Add({i_Ponto_Inicial, i_Ponto_Final})
                            End If
                        End If

                    Next

A:                  For j = i + 2 To UBound(Conteudo)
                        If Conteudo(j).ToUpper.Contains("ENDSEC") Then GoTo B 'Marca o fim das entidades do desenho

                        If Conteudo(j).ToUpper.Equals("CIRCLE") Then 'CÍRCULO
                            Ponto_Central_X = -999999999.999
                            Ponto_Central_Y = -999999999.999
                            Raio = -999999999.999
                            PontosDoArco.Clear()
                            For k = j To UBound(Conteudo)
                                If Conteudo(k).Equals("  0") Then Exit For 'Fim das propriedades do círculo
                                If Conteudo(k).Equals(" 10") Then Ponto_Central_X = Math.Round(CDbl(Conteudo(k + 1).Replace(".", ",")), Precisao, MidpointRounding.ToEven)
                                If Conteudo(k).Equals(" 20") Then Ponto_Central_Y = Math.Round(CDbl(Conteudo(k + 1).Replace(".", ",")), Precisao, MidpointRounding.ToEven)
                                If Conteudo(k).Equals(" 40") Then Raio = Math.Round(CDbl(Conteudo(k + 1).Replace(".", ",")), Precisao, MidpointRounding.ToEven)
                            Next
                            If Not (Ponto_Central_X <> -999999999.999 AndAlso Ponto_Central_Y <> -999999999.999 AndAlso Raio <> -999999999.999) Then
                                MsgBox("Ocorreu um erro de leitura do arquivo DXF. É impossível continuar.", MsgBoxStyle.Critical)
                                Pontos.Clear()
                                Linhas.Clear()
                                Fronteiras.Clear()
                                PontosEmFuros.Clear()
                                Exit Sub
                            End If
                            j = k
                            QuantidadeDeQuebras = Math.Ceiling(360 / AnguloDeQuebra_Max)
                            AnguloDeQuebra_Real = ((360 / QuantidadeDeQuebras) * Math.PI) / 180
                            If QuantidadeDeQuebras < 3 Then
                                MsgBox("Em função do Ângulo de Quebra Máximo especificado, há ao menos um círculo na geometria que não pôde ser dividido em segmentos de reta. Por favor, altere este parâmetro e tente novamente.", MsgBoxStyle.Critical)
                                Pontos.Clear()
                                Linhas.Clear()
                                Fronteiras.Clear()
                                PontosEmFuros.Clear()
                                Exit Sub
                            End If
                            Ponto_Inicial_X = Ponto_Central_X 'Começa no topo do círculo, onde X = Xcentro e Y = Ycentro + Raio
                            Ponto_Inicial_Y = Ponto_Central_Y + Raio
                            PontosDoArco.Add({Ponto_Inicial_X, Ponto_Inicial_Y})
                            AnguloAtual = AnguloDeQuebra_Real
                            For i_Linha = 1 To QuantidadeDeQuebras - 1
                                Ponto_Inicial_X = Ponto_Central_X + Math.Round((Raio * Math.Sin(AnguloAtual)), Precisao, MidpointRounding.ToEven)
                                Ponto_Inicial_Y = Ponto_Central_Y + Math.Round((Raio * Math.Cos(AnguloAtual)), Precisao, MidpointRounding.ToEven)
                                PontosDoArco.Add({Ponto_Inicial_X, Ponto_Inicial_Y})
                                AnguloAtual += AnguloDeQuebra_Real
                            Next
                            For i_Ponto = 0 To Pontos.Count - 1
                                For i_Ponto_Arco = 0 To PontosDoArco.Count - 1
                                    If Pontos(i_Ponto)(0).Equals(PontosDoArco(i_Ponto_Arco)(0)) AndAlso Pontos(i_Ponto)(1).Equals(PontosDoArco(i_Ponto_Arco)(1)) Then
                                        MsgBox("Há alguma intersecção de áreas na geometria (há ao menos um círculo com pontos em comum a outra fronteira). Por favor, corrija e tente novamente.", MsgBoxStyle.Critical)
                                        Pontos.Clear()
                                        Linhas.Clear()
                                        Fronteiras.Clear()
                                        PontosEmFuros.Clear()
                                        Exit Sub
                                    End If
                                Next
                            Next
                            For i_Ponto_Circulo = 0 To PontosDoArco.Count - 1
                                Pontos.Add(PontosDoArco(i_Ponto_Circulo))
                                If Not i_Ponto_Circulo = PontosDoArco.Count - 1 Then Linhas.Add({Pontos.Count - 1, Pontos.Count}) Else Linhas.Add({Pontos.Count - 1, Pontos.Count - PontosDoArco.Count})
                            Next
                        End If

                    Next

B:                  For j = i + 2 To UBound(Conteudo)
                        If Conteudo(j).ToUpper.Contains("ENDSEC") Then GoTo C 'Marca o fim das entidades do desenho

                        If Conteudo(j).ToUpper.Equals("ARC") Then 'ARCO
                            Ponto_Central_X = -999999999.999
                            Ponto_Central_Y = -999999999.999
                            Raio = -999999999.999
                            AnguloDeInicio = -999999999.999
                            AnguloDeTermino = -999999999.999
                            PontosDoArco.Clear()
                            For k = j To UBound(Conteudo)
                                If Conteudo(k).Equals("  0") Then Exit For 'Fim das propriedades do arco
                                If Conteudo(k).Equals(" 10") Then Ponto_Central_X = Math.Round(CDbl(Conteudo(k + 1).Replace(".", ",")), Precisao, MidpointRounding.ToEven)
                                If Conteudo(k).Equals(" 20") Then Ponto_Central_Y = Math.Round(CDbl(Conteudo(k + 1).Replace(".", ",")), Precisao, MidpointRounding.ToEven)
                                If Conteudo(k).Equals(" 40") Then Raio = Math.Round(CDbl(Conteudo(k + 1).Replace(".", ",")), Precisao, MidpointRounding.ToEven)
                                If Conteudo(k).Equals(" 50") Then AnguloDeInicio = Math.Round(CDbl(Conteudo(k + 1).Replace(".", ",")), Precisao, MidpointRounding.ToEven)
                                If Conteudo(k).Equals(" 51") Then AnguloDeTermino = Math.Round(CDbl(Conteudo(k + 1).Replace(".", ",")), Precisao, MidpointRounding.ToEven) 'Sentido Anti-horário
                            Next
                            If Not (Ponto_Central_X <> -999999999.999 AndAlso Ponto_Central_Y <> -999999999.999 AndAlso Raio <> -999999999.999 AndAlso AnguloDeInicio <> -999999999.999 AndAlso AnguloDeTermino <> -999999999.999) Then
                                MsgBox("Ocorreu um erro de leitura do arquivo DXF. É impossível continuar.", MsgBoxStyle.Critical)
                                Pontos.Clear()
                                Linhas.Clear()
                                Fronteiras.Clear()
                                PontosEmFuros.Clear()
                                Exit Sub
                            End If
                            j = k
                            If AnguloDeTermino < AnguloDeInicio Then AnguloDeTermino += 360
                            QuantidadeDeQuebras = Math.Ceiling((AnguloDeTermino - AnguloDeInicio) / AnguloDeQuebra_Max)
                            AnguloDeInicio = (AnguloDeInicio * Math.PI) / 180 'Radianos
                            AnguloDeTermino = (AnguloDeTermino * Math.PI) / 180 'Radianos
                            AnguloDeQuebra_Real = (AnguloDeTermino - AnguloDeInicio) / QuantidadeDeQuebras
                            Ponto_Inicial_X = Math.Round(Ponto_Central_X + (Raio * Math.Cos(AnguloDeInicio)), Precisao, MidpointRounding.ToEven) 'Começa no ângulo inicial, onde X = Xc + (Raio * Cos(AnguloDeInicio)) e Y = Yc + (Raio * Sen(AnguloDeInicio))
                            Ponto_Inicial_Y = Math.Round(Ponto_Central_Y + (Raio * Math.Sin(AnguloDeInicio)), Precisao, MidpointRounding.ToEven)
                            PontosDoArco.Add({Ponto_Inicial_X, Ponto_Inicial_Y})
                            AnguloAtual = AnguloDeInicio + AnguloDeQuebra_Real
                            For i_Linha = 1 To QuantidadeDeQuebras - 1
                                Ponto_Inicial_X = Ponto_Central_X + Math.Round((Raio * Math.Cos(AnguloAtual)), Precisao, MidpointRounding.ToEven)
                                Ponto_Inicial_Y = Ponto_Central_Y + Math.Round((Raio * Math.Sin(AnguloAtual)), Precisao, MidpointRounding.ToEven)
                                PontosDoArco.Add({Ponto_Inicial_X, Ponto_Inicial_Y})
                                AnguloAtual += AnguloDeQuebra_Real
                            Next
                            Ponto_Final_X = Ponto_Central_X + Math.Round((Raio * Math.Cos(AnguloDeTermino)), Precisao, MidpointRounding.ToEven)
                            Ponto_Final_Y = Ponto_Central_Y + Math.Round((Raio * Math.Sin(AnguloDeTermino)), Precisao, MidpointRounding.ToEven)
                            PontosDoArco.Add({Ponto_Final_X, Ponto_Final_Y})
                            i_Ponto_Inicial = -1
                            i_Ponto_Final = -1
                            For i_Ponto = 0 To Pontos.Count - 1
                                If Math.Max(Pontos(i_Ponto)(0), PontosDoArco(0)(0)) - Math.Min(Pontos(i_Ponto)(0), PontosDoArco(0)(0)) <= (10 ^ (-Precisao + 1)) AndAlso Math.Max(Pontos(i_Ponto)(1), PontosDoArco(0)(1)) - Math.Min(Pontos(i_Ponto)(1), PontosDoArco(0)(1)) <= (10 ^ (-Precisao + 1)) Then i_Ponto_Inicial = i_Ponto
                                If Math.Max(Pontos(i_Ponto)(0), PontosDoArco(PontosDoArco.Count - 1)(0)) - Math.Min(Pontos(i_Ponto)(0), PontosDoArco(PontosDoArco.Count - 1)(0)) <= (10 ^ (-Precisao + 1)) AndAlso Math.Max(Pontos(i_Ponto)(1), PontosDoArco(PontosDoArco.Count - 1)(1)) - Math.Min(Pontos(i_Ponto)(1), PontosDoArco(PontosDoArco.Count - 1)(1)) <= (10 ^ (-Precisao + 1)) Then i_Ponto_Final = i_Ponto
                                If PontosDoArco.Count > 2 Then
                                    For i_Ponto_Arco = 1 To PontosDoArco.Count - 2
                                        If Pontos(i_Ponto)(0).Equals(PontosDoArco(i_Ponto_Arco)(0)) AndAlso Pontos(i_Ponto)(1).Equals(PontosDoArco(i_Ponto_Arco)(1)) Then
                                            MsgBox("Há alguma intersecção de áreas na geometria (há ao menos um arco com pontos em comum a outra fronteira). Por favor, corrija e tente novamente.", MsgBoxStyle.Critical)
                                            Pontos.Clear()
                                            Linhas.Clear()
                                            Fronteiras.Clear()
                                            PontosEmFuros.Clear()
                                            Exit Sub
                                        End If
                                    Next
                                End If
                            Next

                            If i_Ponto_Inicial = -1 OrElse i_Ponto_Final = -1 Then
                                MsgBox("Ocorreu um erro ao tentar dividir um arco em segmentos de reta." & vbNewLine & vbNewLine & "Não foi possível correlacionar o ponto de " & IIf(i_Ponto_Inicial = -1, IIf(i_Ponto_Final = -1, "início e o de término do arco ", "início do arco "), "término do arco ") & " com pontos já listados na geometria." & vbNewLine & vbNewLine & "Por favor, altere a geometria e tente novamente.", MsgBoxStyle.Critical)
                                Pontos.Clear()
                                Linhas.Clear()
                                Fronteiras.Clear()
                                PontosEmFuros.Clear()
                                Exit Sub
                            End If

                            If PontosDoArco.Count = 2 Then
                                Linhas.Add({i_Ponto_Inicial, i_Ponto_Final})
                            Else
                                For i_Ponto_Arco = 0 To PontosDoArco.Count - 1
                                    If Not i_Ponto_Arco = 0 AndAlso Not i_Ponto_Arco = PontosDoArco.Count - 1 Then Pontos.Add(PontosDoArco(i_Ponto_Arco))
                                    If i_Ponto_Arco = 1 Then
                                        Linhas.Add({i_Ponto_Inicial, Pontos.Count - 1})
                                    ElseIf i_Ponto_Arco = PontosDoArco.Count - 1 Then
                                        Linhas.Add({Pontos.Count - 1, i_Ponto_Final})
                                    ElseIf i_Ponto_Arco <> 0 Then
                                        Linhas.Add({Pontos.Count - 2, Pontos.Count - 1})
                                    End If
                                Next
                            End If

                        End If

                    Next
                End If
            Next

C:          If Linhas.Count = 0 Then
                MsgBox("Não foi possível encontrar nenhuma entidade de desenho (linhas e arcos) no arquivo indicado!", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'TRANSLAÇÃO DO DESENHO, PARA QUE Xmin e Ymin = 0
            Dim Xmin As Double = 999999999.999
            Dim Ymin As Double = 999999999.999
            For i_Ponto = 0 To Pontos.Count - 1
                If Pontos(i_Ponto)(0) < Xmin Then Xmin = Pontos(i_Ponto)(0)
                If Pontos(i_Ponto)(1) < Ymin Then Ymin = Pontos(i_Ponto)(1)
            Next
            For i_Ponto = 0 To Pontos.Count - 1
                Pontos(i_Ponto)(0) -= Xmin
                Pontos(i_Ponto)(1) -= Ymin
            Next

            'VERIFICA SE TODOS OS PONTOS FORAM USADOS EXATAMENTE 2 VEZES
            Dim Utilizacoes As Integer = 0
            For i_Ponto = 0 To Pontos.Count - 1
                For i_Linha = 0 To Linhas.Count - 1
                    If Linhas(i_Linha)(0).Equals(i_Ponto) Then Utilizacoes += 1
                    If Linhas(i_Linha)(1).Equals(i_Ponto) Then Utilizacoes += 1
                Next
                If Utilizacoes < 2 Then
                    MsgBox("Há ao menos 1 (um) ponto utilizado apenas uma vez, indicando que há alguma fronteira aberta na geometria. Por favor, corrija o desenho e tente novamente.", MsgBoxStyle.Critical)
                    Pontos.Clear()
                    Linhas.Clear()
                    Fronteiras.Clear()
                    PontosEmFuros.Clear()
                    Exit Sub
                ElseIf Utilizacoes > 2 Then
                    MsgBox("Há ao menos 1 (um) ponto utilizado mais de duas vezes, indicando que há alguma intersecção entre fronteiras na geometria. Por favor, corrija o desenho e tente novamente.", MsgBoxStyle.Critical)
                    Pontos.Clear()
                    Linhas.Clear()
                    Fronteiras.Clear()
                    PontosEmFuros.Clear()
                    Exit Sub
                End If
                Utilizacoes = 0
            Next

            'LISTAGEM DE TODAS AS FRONTEIRAS DA GEOMETRIA
            Dim _Linhas As New List(Of Integer())
            _Linhas.AddRange(Linhas)
            Dim i_Linha_Final As Integer = _Linhas.Count - 1
            Dim Fim As Boolean = False

            Do Until Fim = True
                Dim Ponto_Atual As Integer = -2
                Dim Ponto_Ultimo As Integer = -2
                Dim Nova_Fronteira As New List(Of Integer)
                Dim i_Linha_Atual As Integer = 0
                For i_Linha_Atual = 0 To _Linhas.Count - 1
                    Fim = True
                    If _Linhas(i_Linha_Atual)(0) <> -1 AndAlso _Linhas(i_Linha_Atual)(1) <> -1 Then
                        Fim = False
                        Ponto_Atual = _Linhas(i_Linha_Atual)(1)
                        Ponto_Ultimo = _Linhas(i_Linha_Atual)(0)
                        Nova_Fronteira.Add(i_Linha_Atual)
                        _Linhas(i_Linha_Atual) = {-1, -1}
                        Exit For
                    End If
                Next
                If Fim = True Then GoTo D

                For i_Linha_Atual = 0 To i_Linha_Final
                    If _Linhas(i_Linha_Atual)(0) <> -1 AndAlso _Linhas(i_Linha_Atual)(1) <> -1 Then
                        If _Linhas(i_Linha_Atual)(0) = Ponto_Atual Then 'Se a linha atual contém o ponto em questão...
                            If Ponto_Atual = Ponto_Ultimo Then 'Fim da fronteira
                                _Linhas(i_Linha_Atual) = {-1, -1}
                                Exit For
                            Else
                                Nova_Fronteira.Add(i_Linha_Atual)
                                Ponto_Atual = _Linhas(i_Linha_Atual)(1)
                                _Linhas(i_Linha_Atual) = {-1, -1}
                                i_Linha_Atual = -1
                            End If
                        ElseIf _Linhas(i_Linha_Atual)(1) = Ponto_Atual Then 'Se a linha atual contém o ponto em questão...
                            If Ponto_Atual = Ponto_Ultimo Then 'Fim da fronteira
                                _Linhas(i_Linha_Atual) = {-1, -1}
                                Exit For
                            Else
                                Nova_Fronteira.Add(i_Linha_Atual)
                                Ponto_Atual = _Linhas(i_Linha_Atual)(0)
                                _Linhas(i_Linha_Atual) = {-1, -1}
                                i_Linha_Atual = -1
                            End If
                        End If
                    End If
                Next
                If Ponto_Atual = Ponto_Ultimo Then
                    Dim NovoItem(Nova_Fronteira.Count - 1) As Integer
                    For n = 0 To Nova_Fronteira.Count - 1
                        NovoItem(n) = Nova_Fronteira(n)
                    Next
                    Fronteiras.Add(NovoItem)
                Else
                    MsgBox("Ocorreu um erro desconhecido ao tentar mapear as fronteiras da geometria.", MsgBoxStyle.Critical)
                    Pontos.Clear()
                    Linhas.Clear()
                    Fronteiras.Clear()
                    PontosEmFuros.Clear()
                    Exit Sub
                End If

D:          Loop

            'MAPEAMENTO DE UM PONTO QUALQUER NO INTERIOR DE CADA UM DOS FUROS CONTIDOS NA GEOMETRIA (SE HOUVER)
            Dim iFronteiraExterna = -1
            If Fronteiras.Count = 0 Then
                MsgBox("Nenhuma fronteira completa foi mapeada! Por favor, verifique a geometria e tente novamente.", MsgBoxStyle.Critical)
                Pontos.Clear()
                Linhas.Clear()
                Fronteiras.Clear()
                PontosEmFuros.Clear()
                Exit Sub
            ElseIf Fronteiras.Count > 1 Then 'Se houver mais de uma fronteira, há furos na geometria...
                Dim iPontoXMinimo = -1 'Índice do ponto com X = 0
                For i = 0 To Pontos.Count - 1
                    If Pontos(i)(0) = 0 Then
                        iPontoXMinimo = i
                        Exit For
                    End If
                Next
                If iPontoXMinimo = -1 Then
                    MsgBox("Ocorreu um erro desconhecido ao tentar localizar o ponto onde X = Xmin.", MsgBoxStyle.Critical)
                    Pontos.Clear()
                    Linhas.Clear()
                    Fronteiras.Clear()
                    PontosEmFuros.Clear()
                    Exit Sub
                End If
                Dim iLinhaPontoXMinimo = -1
                For i = 0 To Linhas.Count - 1
                    If Linhas(i)(0) = iPontoXMinimo OrElse Linhas(i)(1) = iPontoXMinimo Then
                        iLinhaPontoXMinimo = i
                        Exit For
                    End If
                Next
                If iLinhaPontoXMinimo = -1 Then
                    MsgBox("Ocorreu um erro desconhecido ao tentar localizar uma linha que contenha o ponto onde X = Xmin.", MsgBoxStyle.Critical)
                    Pontos.Clear()
                    Linhas.Clear()
                    Fronteiras.Clear()
                    PontosEmFuros.Clear()
                    Exit Sub
                End If
                iFronteiraExterna = -1
                For i = 0 To Fronteiras.Count - 1
                    For j = 0 To UBound(Fronteiras(i))
                        If Fronteiras(i)(j) = iLinhaPontoXMinimo Then
                            iFronteiraExterna = i
                            Exit For
                        End If
                    Next
                    If iFronteiraExterna <> -1 Then Exit For
                Next
                If iFronteiraExterna = -1 Then
                    MsgBox("Ocorreu um erro desconhecido ao tentar localizar a fronteira externa da geometria.", MsgBoxStyle.Critical)
                    Pontos.Clear()
                    Linhas.Clear()
                    Fronteiras.Clear()
                    PontosEmFuros.Clear()
                    Exit Sub
                End If
                For i = 0 To Fronteiras.Count - 1
                    If Not i = iFronteiraExterna Then 'Caso não seja a fronteira externa, é a fronteira de um furo
                        Dim NumeroDeVertices As Integer = UBound(Fronteiras(i))
                        Dim CoordenadasX(NumeroDeVertices) As Double
                        Dim CoordenadasY(NumeroDeVertices) As Double
                        Dim UltimoPonto As Integer = -1
                        If Linhas(Fronteiras(i)(0))(0) = Linhas(Fronteiras(i)(UBound(Fronteiras(i))))(0) Then
                            CoordenadasX(0) = Pontos(Linhas(Fronteiras(i)(0))(1))(0)
                            CoordenadasY(0) = Pontos(Linhas(Fronteiras(i)(0))(1))(1)
                            UltimoPonto = Linhas(Fronteiras(i)(0))(1)
                        ElseIf Linhas(Fronteiras(i)(0))(0) = Linhas(Fronteiras(i)(UBound(Fronteiras(i))))(1) Then
                            CoordenadasX(0) = Pontos(Linhas(Fronteiras(i)(0))(1))(0)
                            CoordenadasY(0) = Pontos(Linhas(Fronteiras(i)(0))(1))(1)
                            UltimoPonto = Linhas(Fronteiras(i)(0))(1)
                        ElseIf Linhas(Fronteiras(i)(0))(1) = Linhas(Fronteiras(i)(UBound(Fronteiras(i))))(0) Then
                            CoordenadasX(0) = Pontos(Linhas(Fronteiras(i)(0))(0))(0)
                            CoordenadasY(0) = Pontos(Linhas(Fronteiras(i)(0))(0))(1)
                            UltimoPonto = Linhas(Fronteiras(i)(0))(0)
                        Else
                            MsgBox("Foi detectada uma inconsistência em uma das fronteiras. É impossível continuar.", MsgBoxStyle.Critical)
                            Pontos.Clear()
                            Linhas.Clear()
                            Fronteiras.Clear()
                            PontosEmFuros.Clear()
                            Exit Sub
                        End If

                        For j = 1 To UBound(Fronteiras(i)) 'Para cada linha que forma o furo...
                            If Linhas(Fronteiras(i)(j))(0) = UltimoPonto Then
                                CoordenadasX(j) = Pontos(Linhas(Fronteiras(i)(j))(1))(0)
                                CoordenadasY(j) = Pontos(Linhas(Fronteiras(i)(j))(1))(1)
                                UltimoPonto = Linhas(Fronteiras(i)(j))(1)
                            ElseIf Linhas(Fronteiras(i)(j))(1) = UltimoPonto Then
                                CoordenadasX(j) = Pontos(Linhas(Fronteiras(i)(j))(0))(0)
                                CoordenadasY(j) = Pontos(Linhas(Fronteiras(i)(j))(0))(1)
                                UltimoPonto = Linhas(Fronteiras(i)(j))(0)
                            End If
                        Next

                        Dim PontoLocalizado As Boolean = False
                        Dim Centroide_X As Double = 0.0
                        Dim Centroide_Y As Double = 0.0
                        For j = 0 To UBound(CoordenadasX) 'Verifica se o centroide está localizado no interior da fronteira analisada
                            Centroide_X += CoordenadasX(j)
                            Centroide_Y += CoordenadasY(j)
                        Next
                        Centroide_X = Centroide_X / CoordenadasX.Length
                        Centroide_Y = Centroide_Y / CoordenadasX.Length
                        If PontoNoPoligono({Centroide_X, Centroide_Y}, CoordenadasX, CoordenadasY) = True Then
                            PontoLocalizado = True
                        Else
                            For j = 0 To UBound(CoordenadasX) - 2
                                Centroide_X = (CoordenadasX(j) + CoordenadasX(j + 1) + CoordenadasX(j + 2)) / 3
                                Centroide_Y = (CoordenadasY(j) + CoordenadasY(j + 1) + CoordenadasY(j + 2)) / 3
                                If PontoNoPoligono({Centroide_X, Centroide_Y}, CoordenadasX, CoordenadasY) = True Then
                                    PontoLocalizado = True
                                    Exit For
                                End If
                            Next
                        End If
                        If Not PontoLocalizado Then
                            MsgBox("Não foi possível encontrar automaticamente nenhum ponto contido em um dos furos da geometria. É impossível continuar.", MsgBoxStyle.Critical)
                            Pontos.Clear()
                            Linhas.Clear()
                            Fronteiras.Clear()
                            PontosEmFuros.Clear()
                            Exit Sub
                        End If
                        PontosEmFuros.Add({i, Centroide_X, Centroide_Y})
                    End If
                Next
            End If

            'FORNECIMENTO DOS PARÂMETROS DA GEOMETRIA AO GERADOR DE MALHAS TRIANGLE.NET

            CarregarAmbienteGrafico()

            'CARREGAMENTO DAS LISTAS DE PONTOS, LINHAS E FRONTEIRAS

            CarregarListas()

            'MUDA O STATUS DA GEOMETRIA, JÁ QUE A IMPORTAÇÃO FOI BEM SUCEDIDA

            VerificarStatusDaGeometria(True)

        Catch ex As Exception
            MsgBox("Ocorreu um erro desconhecido durante a importação do arquivo DXF!" & vbNewLine & vbNewLine & "Por favor, tente novamente.", MsgBoxStyle.Critical)
            Pontos.Clear()
            Linhas.Clear()
            Fronteiras.Clear()
            PontosEmFuros.Clear()
        End Try

    End Sub

    Public Sub VerificarStatusDaGeometria(ByVal Importada As Boolean)
        Try
            GeometriaDefinida = True
            If Not Importada Then
                If Pontos.Count < 3 Then
                    GeometriaDefinida = False
                    GoTo A
                End If
                If Linhas.Count < 3 Then
                    GeometriaDefinida = False
                    GoTo A
                End If
                If Fronteiras.Count < 1 Then
                    GeometriaDefinida = False
                    GoTo A
                End If

                'VERIFICA SE TODOS OS PONTOS FORAM USADOS EXATAMENTE 2 VEZES
                Dim Utilizacoes As Integer = 0
                For i_Ponto = 0 To Pontos.Count - 1
                    For i_Linha = 0 To Linhas.Count - 1
                        If Linhas(i_Linha)(0).Equals(i_Ponto) Then Utilizacoes += 1
                        If Linhas(i_Linha)(1).Equals(i_Ponto) Then Utilizacoes += 1
                    Next
                    If Utilizacoes < 2 Then
                        GeometriaDefinida = False
                        GoTo A
                    ElseIf Utilizacoes > 2 Then
                        GeometriaDefinida = False
                        GoTo A
                    End If
                    Utilizacoes = 0
                Next

                'VERIFICA SE TODAS AS LINHAS ESTÃO CONTIDAS EM FRONTEIRAS DEFINIDAS
                Dim QuantidadeDeLinhas As Integer = 0
                For i_Fronteira = 0 To Fronteiras.Count - 1
                    QuantidadeDeLinhas += Fronteiras(i_Fronteira).Length
                Next
                If Linhas.Count <> QuantidadeDeLinhas Then
                    GeometriaDefinida = False
                    GoTo A
                End If

                'TENTA ENCONTRAR UM PONTO QUALQUER NO INTERIOR DE CADA FURO DA GEOMETRIA, SE HOUVER
                PontosEmFuros.Clear()

                If Fronteiras.Count > 1 Then 'Se houver mais de uma fronteira, há furos na geometria...
                    Dim iPontoXMinimo = -1 'Índice do ponto com X = Xmin
                    Dim Xmin As Double = 999999999.999
                    For i = 0 To Pontos.Count - 1
                        If Pontos(i)(0) < Xmin Then
                            Xmin = Pontos(i)(0)
                            iPontoXMinimo = i
                        End If
                    Next
                    If iPontoXMinimo = -1 Then
                        GeometriaDefinida = False
                        GoTo A
                    End If
                    Dim iLinhaPontoXMinimo = -1
                    For i = 0 To Linhas.Count - 1
                        If Linhas(i)(0) = iPontoXMinimo OrElse Linhas(i)(1) = iPontoXMinimo Then
                            iLinhaPontoXMinimo = i
                            Exit For
                        End If
                    Next
                    If iLinhaPontoXMinimo = -1 Then
                        GeometriaDefinida = False
                        GoTo A
                    End If
                    Dim iFronteiraExterna As Integer = -1
                    For i = 0 To Fronteiras.Count - 1
                        For j = 0 To UBound(Fronteiras(i))
                            If Fronteiras(i)(j) = iLinhaPontoXMinimo Then
                                iFronteiraExterna = i
                                Exit For
                            End If
                        Next
                        If iFronteiraExterna <> -1 Then Exit For
                    Next
                    If iFronteiraExterna = -1 Then
                        GeometriaDefinida = False
                        GoTo A
                    End If
                    For i = 0 To Fronteiras.Count - 1
                        If Not i = iFronteiraExterna Then 'Caso não seja a fronteira externa, é a fronteira de um furo
                            Dim NumeroDeVertices As Integer = UBound(Fronteiras(i))
                            Dim CoordenadasX(NumeroDeVertices) As Double
                            Dim CoordenadasY(NumeroDeVertices) As Double
                            Dim UltimoPonto As Integer = -1
                            If Linhas(Fronteiras(i)(0))(0) = Linhas(Fronteiras(i)(UBound(Fronteiras(i))))(0) Then
                                CoordenadasX(0) = Pontos(Linhas(Fronteiras(i)(0))(1))(0)
                                CoordenadasY(0) = Pontos(Linhas(Fronteiras(i)(0))(1))(1)
                                UltimoPonto = Linhas(Fronteiras(i)(0))(1)
                            ElseIf Linhas(Fronteiras(i)(0))(0) = Linhas(Fronteiras(i)(UBound(Fronteiras(i))))(1) Then
                                CoordenadasX(0) = Pontos(Linhas(Fronteiras(i)(0))(1))(0)
                                CoordenadasY(0) = Pontos(Linhas(Fronteiras(i)(0))(1))(1)
                                UltimoPonto = Linhas(Fronteiras(i)(0))(1)
                            ElseIf Linhas(Fronteiras(i)(0))(1) = Linhas(Fronteiras(i)(UBound(Fronteiras(i))))(0) Then
                                CoordenadasX(0) = Pontos(Linhas(Fronteiras(i)(0))(0))(0)
                                CoordenadasY(0) = Pontos(Linhas(Fronteiras(i)(0))(0))(1)
                                UltimoPonto = Linhas(Fronteiras(i)(0))(0)
                            Else
                                GeometriaDefinida = False
                                GoTo A
                            End If

                            For j = 1 To UBound(Fronteiras(i)) 'Para cada linha que forma o furo...
                                If Linhas(Fronteiras(i)(j))(0) = UltimoPonto Then
                                    CoordenadasX(j) = Pontos(Linhas(Fronteiras(i)(j))(1))(0)
                                    CoordenadasY(j) = Pontos(Linhas(Fronteiras(i)(j))(1))(1)
                                    UltimoPonto = Linhas(Fronteiras(i)(j))(1)
                                ElseIf Linhas(Fronteiras(i)(j))(1) = UltimoPonto Then
                                    CoordenadasX(j) = Pontos(Linhas(Fronteiras(i)(j))(0))(0)
                                    CoordenadasY(j) = Pontos(Linhas(Fronteiras(i)(j))(0))(1)
                                    UltimoPonto = Linhas(Fronteiras(i)(j))(0)
                                End If
                            Next

                            Dim PontoLocalizado As Boolean = False
                            Dim Centroide_X As Double = 0.0
                            Dim Centroide_Y As Double = 0.0
                            For j = 0 To UBound(CoordenadasX) 'Verifica se o centroide está localizado no interior da fronteira analisada
                                Centroide_X += CoordenadasX(j)
                                Centroide_X += CoordenadasY(j)
                            Next
                            Centroide_X = Centroide_X / CoordenadasX.Length
                            Centroide_Y = Centroide_Y / CoordenadasY.Length
                            If PontoNoPoligono({Centroide_X, Centroide_Y}, CoordenadasX, CoordenadasY) = True Then
                                PontoLocalizado = True
                            Else
                                For j = 0 To UBound(CoordenadasX) - 2
                                    Centroide_X = (CoordenadasX(j) + CoordenadasX(j + 1) + CoordenadasX(j + 2)) / 3
                                    Centroide_Y = (CoordenadasY(j) + CoordenadasY(j + 1) + CoordenadasY(j + 2)) / 3
                                    If PontoNoPoligono({Centroide_X, Centroide_Y}, CoordenadasX, CoordenadasY) = True Then
                                        PontoLocalizado = True
                                        Exit For
                                    End If
                                Next
                            End If
                            If Not PontoLocalizado Then
                                GeometriaDefinida = False
                                GoTo A
                            End If
                            PontosEmFuros.Add({i, Centroide_X, Centroide_Y})
                        End If
                    Next
                End If

                If PontosEmFuros.Count <> Fronteiras.Count - 1 Then
                    GeometriaDefinida = False
                    GoTo A
                End If

            End If

            'ORDENAÇÃO DOS PONTOS REFERENTES ÀS FRONTEIRAS
            Dim Troca As Integer = -1
            Dim PontoSeguinte As Integer = -1
            For Each Fronteira In Fronteiras
                PontoSeguinte = Linhas(Fronteira(0))(1)
                For i = 1 To UBound(Fronteira)
                    If Not Linhas(Fronteira(i))(0).Equals(PontoSeguinte) Then
                        Troca = Linhas(Fronteira(i))(0)
                        Linhas(Fronteira(i))(0) = Linhas(Fronteira(i))(1)
                        Linhas(Fronteira(i))(1) = Troca
                    End If
                    PontoSeguinte = Linhas(Fronteira(i))(1)
                Next
            Next

A:          If GeometriaDefinida = True Then
                lStatus.Text = "Geometria Definida"
                lStatus.ForeColor = Color.LimeGreen
            Else
                lStatus.Text = "Geometria Indefinida"
                lStatus.ForeColor = Color.OrangeRed
            End If
        Catch ex As Exception
            MsgBox("Ocorreu um erro desconhecido ao realizar a verificação da definição da geometria!" & vbNewLine & vbNewLine & "Recomenda-se limpar a geometria e tentar novamente.", MsgBoxStyle.Critical)
            lStatus.Text = "Geometria Indefinida"
            lStatus.ForeColor = Color.OrangeRed
        End Try
    End Sub

    Private Sub CarregarAmbienteGrafico()
        Try
            input = New InputGeometry(Pontos.Count)
            Dim iPonto As Integer = 0

            If Pontos.Count > 0 Then
                For i = 0 To Pontos.Count - 1
                    input.AddPoint(Pontos(i)(0), Pontos(i)(1))
                Next

                If Linhas.Count > 0 Then
                    For i = 0 To Linhas.Count - 1
                        Dim FronteiraAtual = Fronteiras.Count
                        If Fronteiras.Count > 0 Then
                            For j = 0 To Fronteiras.Count - 1
                                For k = 0 To UBound(Fronteiras(j))
                                    If Fronteiras(j)(k) = Linhas(i)(0) OrElse Fronteiras(j)(k) = Linhas(i)(1) Then
                                        FronteiraAtual = j
                                        GoTo A
                                    End If
                                Next
                            Next
                        End If
A:                      input.AddSegment(Linhas(i)(0), Linhas(i)(1), FronteiraAtual + 1)
                    Next
                End If

            End If
            If PontosEmFuros.Count > 0 Then
                For i = 0 To PontosEmFuros.Count - 1
                    input.AddHole(PontosEmFuros(i)(1), PontosEmFuros(i)(2))
                Next
            End If
            renderData.SetInputGeometry(input)
            renderManager.SetData(renderData)
        Catch ex As Exception
            MsgBox("Ocorreu um erro desconhecido ao gerar a geometria graficamente para visualização!" & vbNewLine & vbNewLine & "Recomenda-se limpar a geometria e tentar novamente.", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Shared Function PontoNoPoligono(ByRef PontoDeTeste() As Double, ByRef CoordenadasX() As Double, ByRef CoordenadasY() As Double) As Boolean
        Dim cn As Integer = 0
        For i As Integer = 0 To UBound(CoordenadasX)
            If ((CoordenadasY(i) <= PontoDeTeste(1)) AndAlso (CoordenadasY((i + 1) Mod (UBound(CoordenadasX) + 1)) > PontoDeTeste(1))) OrElse ((CoordenadasY(i) > PontoDeTeste(1)) AndAlso (CoordenadasY((i + 1) Mod (UBound(CoordenadasX) + 1)) <= PontoDeTeste(1))) Then
                Dim vt As Single = CDbl(PontoDeTeste(1) - CoordenadasY(i)) / (CoordenadasY((i + 1) Mod (UBound(CoordenadasX) + 1)) - CoordenadasY(i))
                If PontoDeTeste(0) < CoordenadasX(i) + vt * (CoordenadasX((i + 1) Mod (UBound(CoordenadasX) + 1)) - CoordenadasX(i)) Then cn += 1
            End If
        Next
        Return (cn Mod 2 = 1)
    End Function

    Private Sub EditarGeometria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        VerificarStatusDaGeometria(False)

        oldClientSize = Me.ClientSize

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

        CarregarListas()
        CarregarAmbienteGrafico()

        Carregado = True
    End Sub

    Private Sub CarregarListas(Optional ByVal ListarPontos As Boolean = True, Optional ByVal ListarComboBox As Boolean = True, Optional ByVal ListarLinhas As Boolean = True, Optional ByVal ListarFronteiras As Boolean = True)
        Try
            If ListarPontos Then P_Lista.Items.Clear()
            If ListarLinhas Then L_Lista.Items.Clear()
            If ListarFronteiras Then F_Lista.Items.Clear()
            If ListarComboBox Then L_Ponto1.Items.Clear()
            If ListarComboBox Then L_Ponto2.Items.Clear()
            If ListarPontos Then
                For i_Ponto = 0 To Pontos.Count - 1
                    Dim NovoItem As New ListViewItem
                    NovoItem.Text = CStr(i_Ponto + 1)
                    NovoItem.SubItems.Add(CStr(Pontos(i_Ponto)(0)))
                    NovoItem.SubItems.Add(CStr(Pontos(i_Ponto)(1)))
                    P_Lista.Items.Add(NovoItem)
                    If ListarComboBox Then
                        L_Ponto1.Items.Add(CStr(i_Ponto + 1))
                        L_Ponto2.Items.Add(CStr(i_Ponto + 1))
                    End If
                Next
            End If
            If Not ListarPontos AndAlso ListarComboBox Then
                For i_Ponto = 0 To Pontos.Count - 1
                    L_Ponto1.Items.Add(CStr(i_Ponto + 1))
                    L_Ponto2.Items.Add(CStr(i_Ponto + 1))
                Next
            End If
            If ListarLinhas Then
                For i_Linha = 0 To Linhas.Count - 1
                    Dim NovoItem As New ListViewItem
                    NovoItem.Text = CStr(i_Linha + 1)
                    NovoItem.SubItems.Add(CStr(Linhas(i_Linha)(0) + 1))
                    NovoItem.SubItems.Add(CStr(Linhas(i_Linha)(1) + 1))
                    L_Lista.Items.Add(NovoItem)
                Next
            End If
            If ListarFronteiras Then
                For i_Fronteira = 0 To Fronteiras.Count - 1
                    Dim NovoItem As New ListViewItem
                    NovoItem.Text = CStr(i_Fronteira + 1)
                    NovoItem.SubItems.Add(CStr(Fronteiras(i_Fronteira).Length))
                    NovoItem.Tag = Fronteiras(i_Fronteira)
                    F_Lista.Items.Add(NovoItem)
                Next
            End If
        Catch ex As Exception
            MsgBox("Ocorreu um erro desconhecido no carregamento das listas de informações." & vbNewLine & vbNewLine & "Recomenda-se limpar a geometria e tentar novamente.", MsgBoxStyle.Critical)
        End Try

    End Sub

#Region "Resize event handler"

    Private isResizing As Boolean = False
    Private oldClientSize As Size

    Private Sub ResizeHandler(sender As Object, e As EventArgs) Handles MyBase.Resize
        If Carregado Then
            ' Handle window minimize and maximize
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

#End Region

    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
        Dim container = Me.splitContainer1.Panel2.ClientRectangle

        Dim pt As System.Drawing.Point = e.Location
        pt.Offset(-splitContainer1.SplitterDistance, 0)

        If container.Contains(pt) Then
            renderManager.Zoom(CSng(pt.X) / container.Width, CSng(pt.Y) / container.Height, e.Delta)
        End If
        MyBase.OnMouseWheel(e)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        MsgBox("Usando")
    End Sub

    Private Sub bSair_Click(sender As Object, e As EventArgs) Handles bSair.Click
        Me.Close()
    End Sub

    Private Sub EditarGeometria_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If GeometriaDefinida = False Then
            If Not MsgBox("A geometria ainda está indefinida! Deseja mesmo sair?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then e.Cancel = True
        End If
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If MsgBox("Tem certeza que deseja LIMPAR TODAS AS INFORMAÇÕES do desenho?" & vbNewLine & vbNewLine & "Esse processo é IRREVERSÍVEL!", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            input.Clear()
            renderData.SetInputGeometry(input)
            renderManager.SetData(renderData)
            Pontos.Clear()
            Linhas.Clear()
            Fronteiras.Clear()
            PontosEmFuros.Clear()
            P_Lista.Items.Clear()
            L_Lista.Items.Clear()
            F_Lista.Items.Clear()
            VerificarStatusDaGeometria(False)
        End If
    End Sub

    Private Sub P_Lista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles P_Lista.SelectedIndexChanged
        If P_Lista.SelectedItems.Count = 1 Then
            P_Remover.Enabled = True
            P_Editar.Enabled = True
        ElseIf P_Lista.SelectedItems.Count > 1 Then
            P_Remover.Enabled = True
            P_Editar.Enabled = False
        Else
            P_Remover.Enabled = False
            P_Editar.Enabled = False
        End If
    End Sub

    Private Sub P_Lista_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles P_Lista.MouseDoubleClick
        If P_Lista.SelectedItems.Count = 1 Then
            EditarPonto(P_Lista.SelectedItems(0))
        End If
    End Sub

    Private Sub P_Lista_KeyDown(sender As Object, e As KeyEventArgs) Handles P_Lista.KeyDown
        If P_Lista.SelectedItems.Count > 0 Then
            If e.KeyCode = Keys.Delete Then
                If MsgBox("Deseja remover o(s) ponto(s) selecionado(s)?" & vbNewLine & vbNewLine & "Quaisquer associações deste(s) ponto(s) com linhas e fronteiras também serão desfeitas e isso poderá comprometer a definição da geometria!" & vbNewLine & vbNewLine & "Esta ação é irreversível!", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    Dim PontosRemovidos As New List(Of Integer)
                    For Each Ponto As ListViewItem In P_Lista.SelectedItems
                        PontosRemovidos.Add(CLng(Ponto.Text) - 1)
                    Next
                    For i = PontosRemovidos.Count - 1 To 0 Step -1
                        Pontos.RemoveAt(PontosRemovidos(i))
                        RemoverPonto(PontosRemovidos(i))
                    Next
                    DetectarFronteiras(True)
                    CarregarListas()
                    VerificarStatusDaGeometria(False)
                    CarregarAmbienteGrafico()
                End If
            End If
        End If
        If e.KeyCode = Keys.A AndAlso e.Control = True Then
            For Each item As ListViewItem In P_Lista.Items
                item.Selected = True
            Next
        End If
    End Sub

    Private Sub P_Remover_Click(sender As Object, e As EventArgs) Handles P_Remover.Click
        If P_Lista.SelectedItems.Count = 0 Then Exit Sub
        If MsgBox("Deseja remover o(s) ponto(s) selecionado(s)?" & vbNewLine & vbNewLine & "Quaisquer associações deste(s) ponto(s) com linhas e fronteiras também serão desfeitas e isso poderá comprometer a definição da geometria!" & vbNewLine & vbNewLine & "Esta ação é irreversível!", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            Dim PontosRemovidos As New List(Of Integer)
            For Each Ponto As ListViewItem In P_Lista.SelectedItems
                PontosRemovidos.Add(CLng(Ponto.Text) - 1)
            Next
            For i = PontosRemovidos.Count - 1 To 0 Step -1
                Pontos.RemoveAt(PontosRemovidos(i))
                RemoverPonto(PontosRemovidos(i))
            Next
            DetectarFronteiras(True)
            CarregarListas()
            VerificarStatusDaGeometria(False)
            CarregarAmbienteGrafico()
        End If
    End Sub

    Private Sub P_Editar_Click(sender As Object, e As EventArgs) Handles P_Editar.Click
        If P_Lista.SelectedItems.Count = 0 Then Exit Sub
        EditarPonto(P_Lista.SelectedItems(0))
    End Sub

    Private Sub RemoverPonto(ByVal Indice As Integer)
        Try
            Dim LinhasRemovidas As New List(Of Integer)
            If Linhas.Count <> 0 Then
                For i_Linha = Linhas.Count - 1 To 0 Step -1
                    If Linhas(i_Linha)(0).Equals(Indice) Then
                        LinhasRemovidas.Add(i_Linha)
                        Linhas.RemoveAt(i_Linha)
                    ElseIf Linhas(i_Linha)(1).Equals(Indice) Then
                        LinhasRemovidas.Add(i_Linha)
                        Linhas.RemoveAt(i_Linha)
                    End If
                Next
            End If
            If Linhas.Count <> 0 Then
                For i_Linha = 0 To Linhas.Count - 1
                    If Linhas(i_Linha)(0) > Indice Then
                        Linhas(i_Linha)(0) -= 1
                    End If
                    If Linhas(i_Linha)(1) > Indice Then
                        Linhas(i_Linha)(1) -= 1
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox("Ocorreu um erro desconhecido ao tentar remover um ponto da geometria." & vbNewLine & vbNewLine & "Recomenda-se limpar a geometria e tentar novamente.", MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub EditarPonto(ByRef Item As ListViewItem)
        Dim Coord() As Double = {CDbl(Item.SubItems(1).Text), CDbl(Item.SubItems(2).Text)}
        EditarGeometria_EditarPonto.Coord = Coord
        EditarGeometria_EditarPonto.tPonto.Text = Item.Text
        If EditarGeometria_EditarPonto.ShowDialog = DialogResult.OK Then
            Item.SubItems(1).Text = CStr(Coord(0))
            Item.SubItems(2).Text = CStr(Coord(1))
            Pontos(CLng(Item.Text) - 1)(0) = Coord(0)
            Pontos(CLng(Item.Text) - 1)(1) = Coord(1)
            VerificarStatusDaGeometria(False)
            CarregarAmbienteGrafico()
        End If
    End Sub

    Private Sub P_Cadastrar_Click(sender As Object, e As EventArgs) Handles P_Cadastrar.Click
        If IsNumeric(P_CoordX.Text) AndAlso IsNumeric(P_CoordY.Text) Then
            If CDbl(P_CoordX.Text) < 0 OrElse CDbl(P_CoordX.Text) < 0 Then
                MsgBox("Insira apenas coordenadas positivas!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
            If Pontos.Count > 0 Then
                For i = 0 To Pontos.Count - 1
                    If Pontos(i)(0).Equals(CDbl(P_CoordX.Text)) AndAlso Pontos(i)(1).Equals(CDbl(P_CoordY.Text)) Then
                        MsgBox("As coordenadas indicadas pertencem a um ponto já cadastrado!", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                Next
            End If
            P_Lista.SelectedItems.Clear()
            Pontos.Add({CDbl(P_CoordX.Text), CDbl(P_CoordY.Text)})
            Dim NovoPonto As New ListViewItem
            NovoPonto.Text = P_Lista.Items.Count + 1
            NovoPonto.SubItems.Add(CStr(CDbl(P_CoordX.Text)))
            NovoPonto.SubItems.Add(CStr(CDbl(P_CoordY.Text)))
            NovoPonto.Selected = True
            P_Lista.Items.Add(NovoPonto)
            L_Ponto1.Items.Add(NovoPonto.Text)
            L_Ponto2.Items.Add(NovoPonto.Text)
            VerificarStatusDaGeometria(False)
            CarregarListas(False, False)
            CarregarAmbienteGrafico()
            P_CoordX.Select()
            P_Lista.SelectedItems(0).EnsureVisible()
            P_CoordX.Text = ""
            P_CoordY.Text = ""
        Else
            MsgBox("Digite coordenadas válidas!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub L_Lista_KeyDown(sender As Object, e As KeyEventArgs) Handles L_Lista.KeyDown
        If L_Lista.SelectedItems.Count > 0 Then
            If e.KeyCode = Keys.Delete Then
                If MsgBox("Deseja remover a(s) linha(s) selecionada(s)?" & vbNewLine & vbNewLine & "Quaisquer associações desta(s) linha(s) com fronteiras também serão desfeitas e isso poderá comprometer a definição da geometria!" & vbNewLine & vbNewLine & "Esta ação é irreversível!", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    Dim LinhasRemovidas As New List(Of Integer)
                    For Each Linha As ListViewItem In L_Lista.SelectedItems
                        LinhasRemovidas.Add(CLng(Linha.Text) - 1)
                    Next
                    For i = LinhasRemovidas.Count - 1 To 0 Step -1
                        Linhas.RemoveAt(LinhasRemovidas(i))
                    Next
                    DetectarFronteiras(True)
                    CarregarListas(False, False)
                    VerificarStatusDaGeometria(False)
                    CarregarAmbienteGrafico()
                End If
            End If
        End If
        If e.KeyCode = Keys.A AndAlso e.Control = True Then
            For Each item As ListViewItem In L_Lista.Items
                item.Selected = True
            Next
        End If
    End Sub

    Private Sub L_Lista_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles L_Lista.MouseDoubleClick
        If L_Lista.SelectedItems.Count = 1 Then
            EditarLinha(L_Lista.SelectedItems(0))
        End If
    End Sub

    Private Sub L_Lista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles L_Lista.SelectedIndexChanged
        If L_Lista.SelectedItems.Count = 1 Then
            L_Remover.Enabled = True
            L_Editar.Enabled = True
        ElseIf L_Lista.SelectedItems.Count > 1 Then
            L_Remover.Enabled = True
            L_Editar.Enabled = False
        Else
            L_Remover.Enabled = False
            L_Editar.Enabled = False
        End If
    End Sub

    Private Sub EditarLinha(ByRef Item As ListViewItem)
        Dim Linha() As Integer = {CDbl(Item.SubItems(1).Text), CDbl(Item.SubItems(2).Text)}
        EditarGeometria_EditarLinha.Linha = Linha
        EditarGeometria_EditarLinha.tLinha.Text = Item.Text
        For Each Ponto In L_Ponto1.Items
            EditarGeometria_EditarLinha.L_Ponto1.Items.Add(Ponto)
            EditarGeometria_EditarLinha.L_Ponto2.Items.Add(Ponto)
        Next
        If EditarGeometria_EditarLinha.ShowDialog = DialogResult.OK Then
            Item.SubItems(1).Text = CStr(Linha(0))
            Item.SubItems(2).Text = CStr(Linha(1))
            Linhas(CLng(Item.Text) - 1)(0) = Linha(0) - 1
            Linhas(CLng(Item.Text) - 1)(1) = Linha(1) - 1
            DetectarFronteiras(True)
            CarregarListas(False, False)
            VerificarStatusDaGeometria(False)
            CarregarAmbienteGrafico()
        End If
    End Sub

    Private Sub L_Remover_Click(sender As Object, e As EventArgs) Handles L_Remover.Click
        If L_Lista.SelectedItems.Count = 0 Then Exit Sub
        If MsgBox("Deseja remover a(s) linha(s) selecionada(s)?" & vbNewLine & vbNewLine & "Quaisquer associações desta(s) linha(s) com fronteiras também serão desfeitas e isso poderá comprometer a definição da geometria!" & vbNewLine & vbNewLine & "Esta ação é irreversível!", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            Dim LinhasRemovidas As New List(Of Integer)
            For Each Linha As ListViewItem In L_Lista.SelectedItems
                LinhasRemovidas.Add(CLng(Linha.Text) - 1)
            Next
            For i = LinhasRemovidas.Count - 1 To 0 Step -1
                Linhas.RemoveAt(LinhasRemovidas(i))
            Next
            DetectarFronteiras(True)
            CarregarListas(False, False)
            VerificarStatusDaGeometria(False)
            CarregarAmbienteGrafico()
        End If
    End Sub

    Private Sub L_Editar_Click(sender As Object, e As EventArgs) Handles L_Editar.Click
        If L_Lista.SelectedItems.Count = 0 Then Exit Sub
        EditarLinha(L_Lista.SelectedItems(0))
    End Sub

    Private Sub L_Cadastrar_Click(sender As Object, e As EventArgs) Handles L_Cadastrar.Click
        If IsNumeric(L_Ponto1.Text) AndAlso IsNumeric(L_Ponto2.Text) AndAlso L_Ponto1.Text <> L_Ponto2.Text AndAlso L_Ponto1.Items.Contains(L_Ponto1.Text) AndAlso L_Ponto2.Items.Contains(L_Ponto2.Text) Then
            If Linhas.Count > 0 Then
                For i = 0 To Linhas.Count - 1
                    If Linhas(i)(0).Equals(CLng(L_Ponto1.Text)) AndAlso Linhas(i)(1).Equals(CLng(L_Ponto2.Text)) Then
                        MsgBox("Os pontos indicados correspondem a uma linha já cadastrada!", MsgBoxStyle.Exclamation)
                        Exit Sub
                    ElseIf Linhas(i)(1).Equals(CLng(L_Ponto1.Text)) AndAlso Linhas(i)(0).Equals(CLng(L_Ponto2.Text)) Then
                        MsgBox("Os pontos indicados correspondem a uma linha já cadastrada!", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                Next
            End If
            L_Lista.SelectedItems.Clear()
            Linhas.Add({CLng(L_Ponto1.Text) - 1, CLng(L_Ponto2.Text) - 1})
            Dim NovoPonto As New ListViewItem
            NovoPonto.Text = L_Lista.Items.Count + 1
            NovoPonto.SubItems.Add(L_Ponto1.Text)
            NovoPonto.SubItems.Add(L_Ponto2.Text)
            NovoPonto.Selected = True
            L_Lista.Items.Add(NovoPonto)
            DetectarFronteiras(True)
            CarregarListas(False, False, False)
            VerificarStatusDaGeometria(False)
            CarregarAmbienteGrafico()
            L_Lista.SelectedItems(0).EnsureVisible()
            L_Ponto1.Text = ""
            L_Ponto2.Text = ""
            L_Ponto1.Select()
        Else
            MsgBox("Selecione pontos válidos!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub F_Lista_KeyDown(sender As Object, e As KeyEventArgs) Handles F_Lista.KeyDown
        If e.KeyCode = Keys.A AndAlso e.Control = True Then
            For Each item As ListViewItem In F_Lista.Items
                item.Selected = True
            Next
        End If
    End Sub

    Private Sub F_Lista_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles F_Lista.MouseDoubleClick
        If F_Lista.SelectedItems.Count = 1 Then
            VisualizarFronteira(F_Lista.SelectedItems(0))
        End If
    End Sub

    Private Sub VisualizarFronteira(ByRef Item As ListViewItem)
        Dim Fronteira() As Integer = Item.Tag
        EditarGeometria_VisualizarFronteira.Fronteira = Fronteira
        EditarGeometria_VisualizarFronteira.tFronteira.Text = Item.Text
        EditarGeometria_VisualizarFronteira.CarregarLista(Linhas)
        EditarGeometria_VisualizarFronteira.ShowDialog()
    End Sub

    Private Sub F_DetectarFronteiras_Click(sender As Object, e As EventArgs) Handles F_DetectarFronteiras.Click
        DetectarFronteiras()
        VerificarStatusDaGeometria(False)
        CarregarListas(False, False, False)
    End Sub

    Private Sub DetectarFronteiras(Optional ByVal Silencioso As Boolean = False)
        Try
            If Linhas.Count > 0 Then
                Fronteiras.Clear()
                Dim _Linhas As New List(Of Integer())
                _Linhas.AddRange(Linhas)
                Dim i_Linha_Final As Integer = _Linhas.Count - 1
                Dim Fim As Boolean = False

                Do Until Fim = True
                    Dim Ponto_Atual As Integer = -2
                    Dim Ponto_Ultimo As Integer = -2
                    Dim Nova_Fronteira As New List(Of Integer)
                    Dim i_Linha_Atual As Integer = 0
                    For i_Linha_Atual = 0 To _Linhas.Count - 1
                        Fim = True
                        If _Linhas(i_Linha_Atual)(0) <> -1 AndAlso _Linhas(i_Linha_Atual)(1) <> -1 Then
                            Fim = False
                            Ponto_Atual = _Linhas(i_Linha_Atual)(1)
                            Ponto_Ultimo = _Linhas(i_Linha_Atual)(0)
                            Nova_Fronteira.Add(i_Linha_Atual)
                            _Linhas(i_Linha_Atual) = {-1, -1}
                            Exit For
                        End If
                    Next
                    If Fim = True Then GoTo D

                    For i_Linha_Atual = 0 To i_Linha_Final
                        If _Linhas(i_Linha_Atual)(0) <> -1 AndAlso _Linhas(i_Linha_Atual)(1) <> -1 Then
                            If _Linhas(i_Linha_Atual)(0) = Ponto_Atual Then 'Se a linha atual contém o ponto em questão...
                                If Ponto_Atual = Ponto_Ultimo Then 'Fim da fronteira
                                    _Linhas(i_Linha_Atual) = {-1, -1}
                                    Exit For
                                Else
                                    Nova_Fronteira.Add(i_Linha_Atual)
                                    Ponto_Atual = _Linhas(i_Linha_Atual)(1)
                                    _Linhas(i_Linha_Atual) = {-1, -1}
                                    i_Linha_Atual = -1
                                End If
                            ElseIf _Linhas(i_Linha_Atual)(1) = Ponto_Atual Then 'Se a linha atual contém o ponto em questão...
                                If Ponto_Atual = Ponto_Ultimo Then 'Fim da fronteira
                                    _Linhas(i_Linha_Atual) = {-1, -1}
                                    Exit For
                                Else
                                    Nova_Fronteira.Add(i_Linha_Atual)
                                    Ponto_Atual = _Linhas(i_Linha_Atual)(0)
                                    _Linhas(i_Linha_Atual) = {-1, -1}
                                    i_Linha_Atual = -1
                                End If
                            End If
                        End If
                    Next
                    If Ponto_Atual = Ponto_Ultimo Then
                        Dim NovoItem(Nova_Fronteira.Count - 1) As Integer
                        For n = 0 To Nova_Fronteira.Count - 1
                            NovoItem(n) = Nova_Fronteira(n)
                        Next
                        Fronteiras.Add(NovoItem)
                    End If
D:              Loop
            End If
            If Not Silencioso Then
                If Fronteiras.Count = 1 Then
                    MsgBox("Foi encontrada 1 fronteira fechada/completa na geometria atual.", MsgBoxStyle.Information)
                ElseIf Fronteiras.Count > 1 Then
                    MsgBox("Foram encontradas " & CStr(Fronteiras.Count) & " fronteiras fechadas/completas na geometria atual.", MsgBoxStyle.Information)
                Else
                    MsgBox("Não foi possível encontrar nenhuma fronteira fechada/completa na geometria atual!", MsgBoxStyle.Exclamation)
                End If
            End If
        Catch ex As Exception
            If Not Silencioso Then
                MsgBox("Ocorreu um erro ao tentar listar automaticamente as fronteiras da geometria." & vbNewLine & vbNewLine & "Recomenda-se limpar a geometria e tentar novamente.", MsgBoxStyle.Critical)
            End If
            Fronteiras.Clear()
        End Try
    End Sub

    Private Sub P_CoordY_KeyDown(sender As Object, e As KeyEventArgs) Handles P_CoordY.KeyDown
        If e.KeyCode = Keys.Enter Then
            P_Cadastrar_Click(sender, Nothing)
        End If
    End Sub

    Private Sub L_Ponto2_KeyDown(sender As Object, e As KeyEventArgs) Handles L_Ponto2.KeyDown
        If e.KeyCode = Keys.Enter Then
            L_Cadastrar_Click(sender, Nothing)
        End If
    End Sub
End Class
