#Region "IMPORTAÇÃO DE BIBLIOTECAS"
Imports MathNet.Numerics.LinearAlgebra.Double
Imports Microsoft.VisualBasic.FileIO.FileSystem
Imports System.Drawing.Drawing2D
Imports System.Threading
Imports System.Linq
#End Region

Public Class Principal

#Region "CONFIGURAÇÕES DO IGNIS"
    Public TempoLimite_Malha As Integer = CInt(GetSetting("Ignis", "Configurações", "TempoLimite_Malha", "-1")) 'Tempo limite, em segundos, para processamento da triangulação, refinamento e suavização da malha
    Public SolverPadrao As Integer = CInt(GetSetting("Ignis", "Configurações", "SolverPadrao", "-1")) 'Solver padrão para novas análises
    Public VisualizacaoPadrao As Integer = CInt(GetSetting("Ignis", "Configurações", "VisualizacaoPadrao", "-1")) 'Tipo de visualização padrão para novas análises
#End Region

#Region "DADOS DO PROBLEMA"
#Region "GEOMETRIA"
    Public PontosDaGeometria As New List(Of Double()) 'Guarda todos os pontos DA GEOMETRIA encontrados no desenho
    Public LinhasDaGeometria As New List(Of Integer()) 'Guarda quais pontos formam cada linha da geometria no desenho
    Public FronteirasDaGeometria As New List(Of Integer()) 'Guarda quais linhas formam cada fronteira da geometria no desenho
    Public PontosEmFurosDaGeometria As New List(Of Object()) 'Guarda os índices de fronteiras identificadas como furos e um ponto qualquer contido nos mesmos
#End Region

#Region "MALHA"
    Public PontosDaMalha As New List(Of Double()) 'Matriz que guarda todos os pontos da malha
    Public LinhasDeContornoDaMalha As New List(Of Integer()) 'Matriz que guarda quais pontos da malha (renumerados) formam cada fronteira da geometria
    Public TriangulosDaMalha As New List(Of Integer()) 'Matriz que guarda quais pontos formam cada triângulo da malha
#End Region

#Region "PROPRIEDADES FÍSICAS"
    Public Espessura As Double = 0.0 'Valor da espessura do corpo analisado
    Public MassaEspecifica As Double = 0.00001 'Valor da massa específica do material do corpo utilizado na análise
    Public CondutividadeTermica As Double = 0.0 'Valor da condutividade térmica do material do corpo utilizado na análise
    Public GeracaoDeCalor As Double = 0.0 'Taxa de geração de calor por unidade de volume
#End Region

#Region "CONDIÇÕES INICIAIS"
    Public TemperaturaInicial As Double = -999999999.999 'Valor da temperatura inicial do corpo, utilizado nas simulações em regime transiente
#End Region

#Region "CONDIÇÕES DE CONTORNO"
    Public Linhas_CC_1 As New List(Of Object()) 'Lista das linhas com condição de contorno 01 (Dirichlet) e seus parâmetros
    Public Linhas_CC_2 As New List(Of Object()) 'Lista das linhas com condição de contorno 02 (Neumann) e seus parâmetros
    Public Linhas_CC_3 As New List(Of Object()) 'Lista das linhas com condição de contorno 03 (Robin) e seus parâmetros
#End Region

#Region "PARÂMETROS DE PROCESSAMENTO"
    Public TipoDeAnalise As Integer = 1 'Índice referente ao tipo de análise a ser realizada. 1 = Condução de Calor em Regime Permanente e 2 = Condução de Calor em Regime Transiente
#End Region

#Region "SOLVER"
    Public TipoDeSolver As Integer = 1 'Índice referente ao tipo de Solver (método de solução do conjunto de equações) a ser utilizado. 1 = Simples (Inversão de Matriz), 2 = Decomposição QR e 3 = Decomposição LU
    Private Tempo_Proc_1 As Stopwatch 'Marca o tempo para realização do pré-processamento
    Private Tempo_Proc_2 As Stopwatch 'Marca o tempo para aplicação das condições de contorno
    Private Tempo_Proc_3 As Stopwatch 'Marca o tempo para solução do sistema de equações
    Private Tempo_Proc_4 As Stopwatch 'Marca o tempo para renderização dos resultados
#End Region

#Region "PARÂMETROS DE PÓS-PROCESSAMENTO"
    Public TipoDeVisualizacao As Integer = 1 'Índice referente ao tipo de visualização dos resultados da simulação. 1 = Gradiente de Cores e 2 = Linhas Isotérmicas
    Public EscalaDeCinza As Boolean = False 'Indica se o gradiente de temperaturas será exibido em escala de cinza
    Public PassoEntreIsotermas As Integer = 10 'Valor, em unidades de temperatura, referente ao passo entre as isotermas
    Public Imagem_Tamanho As Integer = 500 'Tamanho das imagens processadas, em pixels, nas dimensões X e Y

#Region "CORES DA INTERFACE GRÁFICA"
    Public Cor_01 As Color = Color.FromArgb(255, 45, 45) 'Vermelho
    Public Cor_02 As Color = Color.FromArgb(255, 85, 45)
    Public Cor_03 As Color = Color.FromArgb(255, 125, 45)
    Public Cor_04 As Color = Color.FromArgb(255, 168, 45)
    Public Cor_05 As Color = Color.FromArgb(255, 210, 45)
    Public Cor_06 As Color = Color.FromArgb(255, 233, 45)
    Public Cor_07 As Color = Color.FromArgb(255, 245, 45)
    Public Cor_08 As Color = Color.FromArgb(255, 250, 45)
    Public Cor_09 As Color = Color.FromArgb(225, 255, 45)
    Public Cor_10 As Color = Color.FromArgb(185, 255, 45)
    Public Cor_11 As Color = Color.FromArgb(145, 255, 45)
    Public Cor_12 As Color = Color.FromArgb(95, 255, 78)
    Public Cor_13 As Color = Color.FromArgb(45, 255, 110)
    Public Cor_14 As Color = Color.FromArgb(45, 255, 153)
    Public Cor_15 As Color = Color.FromArgb(45, 255, 195)
    Public Cor_16 As Color = Color.FromArgb(45, 247, 225)
    Public Cor_17 As Color = Color.FromArgb(45, 240, 255)
    Public Cor_18 As Color = Color.FromArgb(45, 200, 255)
    Public Cor_19 As Color = Color.FromArgb(45, 160, 255)
    Public Cor_20 As Color = Color.FromArgb(45, 140, 255)
    Public Cor_21 As Color = Color.FromArgb(45, 80, 255)
    Public Cor_22 As Color = Color.FromArgb(45, 60, 255)
    Public Cor_23 As Color = Color.FromArgb(45, 40, 255) 'Azul
    Public ES_01 As Color = Color.Black 'Preto
    Public ES_02 As Color = Color.FromArgb(238, Color.Black)
    Public ES_03 As Color = Color.FromArgb(220, Color.Black)
    Public ES_04 As Color = Color.FromArgb(202, Color.Black)
    Public ES_05 As Color = Color.FromArgb(184, Color.Black)
    Public ES_06 As Color = Color.FromArgb(166, Color.Black)
    Public ES_07 As Color = Color.FromArgb(148, Color.Black)
    Public ES_08 As Color = Color.FromArgb(130, Color.Black)
    Public ES_09 As Color = Color.FromArgb(112, Color.Black)
    Public ES_10 As Color = Color.FromArgb(94, Color.Black)
    Public ES_11 As Color = Color.FromArgb(76, Color.Black)
    Public ES_12 As Color = Color.FromArgb(58, Color.Black) 'Cinza Claro
#End Region
#End Region

#Region "IMAGENS"
    Private Imagens As New List(Of Bitmap)
    Private EscalaDeCores As New Bitmap(501, 31) 'Escala de cores processada
#End Region

#Region "PARÂMETROS DIVERSOS"
    Public ArquivoIgnisAtual As String 'Guarda o caminho do arquivo .ignis referente ao problema atual

    Private minX, maxX, minY, maxY, Denominador, a, b, c, Distancia_P1_P2_AoQuadrado, Distancia_P_P1_AoQuadrado, ProdutoEscalar As Double

    Private N_1, N_2, N_3, T_1, T_2, T_3 As Double
    Private tmpElemento As Integer
    Private CoordX(2), CoordY(2) As Double

    Private TemperaturaPontual As Double = 0.0
    Private Temp_Max As Double = 0.0
    Private Temp_Min As Double = 0.0

    Private Maior_X As Double = 0.0 'Maior coordenada X da geometria
    Private Maior_Y As Double = 0.0 'Maior coordenada Y da geometria
    Private Maior_Temperatura As Double = -100000.0 'Maior temperatura calculada
    Private Menor_Temperatura As Double = 100000.0 'Menor temperatura calculada

    Private Proporcao_X As Double
    Private Proporcao_Y As Double
    Private Proporcao_Geral As Double
#End Region

#Region "MATRIZES E VETORES PRINCIPAIS"
    Public MatrizDeCondutividadeGlobal = Nothing 'Matriz [K]
    Public VetorDeCargaTermicaGlobal = Nothing 'Vetor {f}
    Public VetorDeTemperaturas = Nothing 'Vetor {T} (resultado)

    Public MatrizDeFuncoesDeForma As Double(,) 'Matriz que armazena as funções de forma dos elementos, utilizada para renderização dos resultados

#End Region

#Region "PROCESSOS DE SEGUNDO PLANO"
    Private AEF_SegundoPlano As Thread
#End Region
#End Region

#Region "ABERTURA / ENCERRAMENTO DO IGNIS"
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TempoLimite_Malha = -1 Then
            SaveSetting("Ignis", "Configurações", "TempoLimite_Malha", "10")
            TempoLimite_Malha = 10
        End If
        If SolverPadrao = -1 Then
            SaveSetting("Ignis", "Configurações", "SolverPadrao", "1")
            SolverPadrao = 1
        End If
        If VisualizacaoPadrao = -1 Then
            SaveSetting("Ignis", "Configurações", "VisualizacaoPadrao", "1")
            VisualizacaoPadrao = 1
        End If
        LimparProblema()
    End Sub

    Private Sub Principal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If TreeView1.Nodes.Count > 0 Then
            Dim resultado As MsgBoxResult = MsgBox("Deseja salvar a simulação atual?" & vbNewLine & vbNewLine & "Todas as alterações realizadas serão perdidas!", vbQuestion + MsgBoxStyle.YesNoCancel, "Deseja salvar a simulação?")
            If resultado = MsgBoxResult.Cancel Then
                e.Cancel = True
            ElseIf resultado = MsgBoxResult.Yes Then
                If Not SalvarProblemaAtual() Then Exit Sub
            End If
        End If
    End Sub
#End Region

#Region "LEITURA E GRAVAÇÃO DE ARQUIVO .IGNIS"
    Private Function StringArquivoIgnis() As String
        Dim Pontos_Geometria As String = ""
        Dim Linhas_Geometria As String = ""
        Dim Fronteiras_Geometria As String = ""
        Dim Furos_Geometria As String = ""
        Dim Pontos_Malha As String = ""
        Dim Linhas_Malha As String = ""
        Dim Triangulos_Malha As String = ""
        Dim PropriedadesFisicas As String = CStr(Espessura) & "|" & CStr(MassaEspecifica) & "|" & CStr(CondutividadeTermica) & "|" & CStr(GeracaoDeCalor)
        Dim CondicoesIniciais As String = CStr(TemperaturaInicial)
        Dim CondicoesDeContorno1 As String = ""
        Dim CondicoesDeContorno2 As String = ""
        Dim CondicoesDeContorno3 As String = ""
        Dim ParametrosDeProcessamento As String = CStr(TipoDeAnalise)
        Dim Solver As String = CStr(TipoDeSolver)
        Dim ParametrosDePosProcessamento As String = CStr(TipoDeVisualizacao) & "|" & IIf(EscalaDeCinza, 1, 0) & "|" & CStr(PassoEntreIsotermas) & "|" & CStr(Imagem_Tamanho)
        Dim Imagens_Resultado As String = ""
        Dim ParametrosDiversos As String = CStr(TempoLimite_Malha) & "|" & CStr(Maior_X) & "|" & CStr(Maior_Y) & "|" & CStr(Maior_Temperatura) & "|" & CStr(Menor_Temperatura)
        Dim MatrizK As String = ""
        Dim VetorF As String = ""
        Dim VetorT As String = ""
        Dim MatrizFuncoesDeForma As String = ""

        For Each Ponto In PontosDaGeometria
            Pontos_Geometria &= IIf(Pontos_Geometria = "", "", vbNewLine) & String.Join("|", Ponto)
        Next

        For Each Linha In LinhasDaGeometria
            Linhas_Geometria &= IIf(Linhas_Geometria = "", "", vbNewLine) & String.Join("|", Linha)
        Next

        For Each Fronteira In FronteirasDaGeometria
            Fronteiras_Geometria &= IIf(Fronteiras_Geometria = "", "", vbNewLine) & String.Join("|", Fronteira)
        Next

        For Each Furo In PontosEmFurosDaGeometria
            Furos_Geometria &= IIf(Furos_Geometria = "", "", vbNewLine) & String.Join("|", Furo)
        Next

        For Each Ponto In PontosDaMalha
            Pontos_Malha &= IIf(Pontos_Malha = "", "", vbNewLine) & String.Join("|", Ponto)
        Next

        For Each Linha In LinhasDeContornoDaMalha
            Linhas_Malha &= IIf(Linhas_Malha = "", "", vbNewLine) & String.Join("|", Linha)
        Next

        For Each Triangulo In TriangulosDaMalha
            Triangulos_Malha &= IIf(Triangulos_Malha = "", "", vbNewLine) & String.Join("|", Triangulo)
        Next

        For Each CC In Linhas_CC_1
            Dim Linhas As String = ""
            For Each Linha As Integer In CC(0)
                Linhas &= CStr(Linha) & "|"
            Next
            CondicoesDeContorno1 &= IIf(CondicoesDeContorno1 = "", "", vbNewLine) & Linhas & CC(1) & "#" & CC(2) & "#" & CC(3) & "#" & CC(4)
        Next

        For Each CC In Linhas_CC_2
            Dim Linhas As String = ""
            For Each Linha As Integer In CC(0)
                Linhas &= CStr(Linha) & "|"
            Next
            CondicoesDeContorno2 &= IIf(CondicoesDeContorno2 = "", "", vbNewLine) & Linhas & CC(1) & "#" & CC(2) & "#" & CC(3) & "#" & CC(4)
        Next

        For Each CC In Linhas_CC_3
            Dim Linhas As String = ""
            For Each Linha As Integer In CC(0)
                Linhas &= CStr(Linha) & "|"
            Next
            CondicoesDeContorno3 &= IIf(CondicoesDeContorno3 = "", "", vbNewLine) & Linhas & CC(1) & "#" & CC(2) & "#" & CC(3) & "#" & CC(4) & "#" & CC(5)
        Next

        Dim ms As System.IO.MemoryStream
        For Each Imagem In Imagens
            ms = New System.IO.MemoryStream
            Imagem.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Imagens_Resultado &= IIf(Imagens_Resultado = "", "", vbNewLine) & Convert.ToBase64String(ms.ToArray)
            ms.Dispose()
        Next

        If MatrizDeCondutividadeGlobal IsNot Nothing AndAlso VetorDeCargaTermicaGlobal IsNot Nothing AndAlso VetorDeTemperaturas IsNot Nothing Then
            For i = 0 To PontosDaMalha.Count - 1
                Dim NovaLinha As String = CStr(CDbl(MatrizDeCondutividadeGlobal(i, 0)))
                For j = 1 To PontosDaMalha.Count - 1
                    NovaLinha &= "|" & CStr(CDbl(MatrizDeCondutividadeGlobal(i, j)))
                Next
                MatrizK &= IIf(MatrizK = "", "", vbNewLine) & NovaLinha
                VetorF &= IIf(VetorF = "", "", "|") & CStr(VetorDeCargaTermicaGlobal(i, 0))
                VetorT &= IIf(VetorT = "", "", "|") & CStr(VetorDeTemperaturas(i, 0))
            Next
        End If

        If UBound(MatrizDeFuncoesDeForma, 2) > 0 Then
            For i = 0 To UBound(MatrizDeFuncoesDeForma, 2)
                Dim NovaLinha As String = CStr(MatrizDeFuncoesDeForma(0, i))
                For j = 1 To UBound(MatrizDeFuncoesDeForma, 1)
                    NovaLinha &= "|" & CStr(MatrizDeFuncoesDeForma(j, i))
                Next
                MatrizFuncoesDeForma &= IIf(MatrizFuncoesDeForma = "", "", vbNewLine) & NovaLinha
            Next
        End If

        Return Pontos_Geometria & vbNewLine & "&" & vbNewLine & Linhas_Geometria & vbNewLine & "&" & vbNewLine & Fronteiras_Geometria & vbNewLine & "&" & vbNewLine & Furos_Geometria & vbNewLine & "&" & vbNewLine & Pontos_Malha & vbNewLine & "&" & vbNewLine & Linhas_Malha & vbNewLine & "&" & vbNewLine & Triangulos_Malha & vbNewLine & "&" & vbNewLine & PropriedadesFisicas & vbNewLine & "&" & vbNewLine & CondicoesIniciais & vbNewLine & "&" & vbNewLine & CondicoesDeContorno1 & vbNewLine & "&" & vbNewLine & CondicoesDeContorno2 & vbNewLine & "&" & vbNewLine & CondicoesDeContorno3 & vbNewLine & "&" & vbNewLine & ParametrosDeProcessamento & vbNewLine & "&" & vbNewLine & Solver & vbNewLine & "&" & vbNewLine & ParametrosDePosProcessamento & vbNewLine & "&" & vbNewLine & Imagens_Resultado & vbNewLine & "&" & vbNewLine & ParametrosDiversos & vbNewLine & "&" & vbNewLine & MatrizK & vbNewLine & "&" & vbNewLine & VetorF & vbNewLine & "&" & vbNewLine & VetorT & vbNewLine & "&" & vbNewLine & MatrizFuncoesDeForma
    End Function

    Private Function LerArquivoIgnis(ByVal Caminho As String) As Boolean
        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Try
            If FileExists(Caminho) Then
                Dim ArquivoIgnis As String = ReadAllText(Caminho)
                Dim Partes() As String = Split(ArquivoIgnis, vbNewLine & "&" & vbNewLine)

                If Not Partes(0) = "" Then
                    Dim Pontos() As String = Split(Partes(0), vbNewLine)
                    For i = 0 To UBound(Pontos)
                        Dim Ponto() As String = Split(Pontos(i), "|")
                        PontosDaGeometria.Add({CDbl(Ponto(0)), CDbl(Ponto(1))})
                    Next
                End If

                If Not Partes(1) = "" Then
                    Dim Linhas() As String = Split(Partes(1), vbNewLine)
                    For i = 0 To UBound(Linhas)
                        Dim Linha() As String = Split(Linhas(i), "|")
                        LinhasDaGeometria.Add({CDbl(Linha(0)), CDbl(Linha(1))})
                    Next
                End If

                If Not Partes(2) = "" Then
                    Dim Fronteiras() As String = Split(Partes(2), vbNewLine)
                    For i = 0 To UBound(Fronteiras)
                        Dim Fronteira() As String = Split(Fronteiras(i), "|")
                        Dim NovaFronteira(UBound(Fronteira)) As Integer
                        For j = 0 To UBound(Fronteira)
                            NovaFronteira(j) = CDbl(Fronteira(j))
                        Next
                        FronteirasDaGeometria.Add(NovaFronteira)
                    Next
                End If

                If Not Partes(3) = "" Then
                    Dim Furos() As String = Split(Partes(3), vbNewLine)
                    For i = 0 To UBound(Furos)
                        Dim Furo() As String = Split(Furos(i), "|")
                        Dim NovoFuro() As Object = {CInt(Furo(0)), CDbl(Furo(1)), CDbl(Furo(2))}
                        PontosEmFurosDaGeometria.Add(NovoFuro)
                    Next
                End If

                If Not Partes(4) = "" Then
                    Dim Pontos() As String = Split(Partes(4), vbNewLine)
                    For i = 0 To UBound(Pontos)
                        Dim Ponto() As String = Split(Pontos(i), "|")
                        PontosDaMalha.Add({CDbl(Ponto(0)), CDbl(Ponto(1)), CDbl(Ponto(2))})
                    Next
                End If

                If Not Partes(5) = "" Then
                    Dim Linhas() As String = Split(Partes(5), vbNewLine)
                    For i = 0 To UBound(Linhas)
                        Dim Linha() As String = Split(Linhas(i), "|")
                        LinhasDeContornoDaMalha.Add({CDbl(Linha(0)), CDbl(Linha(1)), CDbl(Linha(2))})
                    Next
                End If

                If Not Partes(6) = "" Then
                    Dim Triangulos() As String = Split(Partes(6), vbNewLine)
                    For i = 0 To UBound(Triangulos)
                        Dim Triangulo() As String = Split(Triangulos(i), "|")
                        TriangulosDaMalha.Add({CDbl(Triangulo(0)), CDbl(Triangulo(1)), CDbl(Triangulo(2))})
                    Next
                End If

                Dim PropriedadesFisicas() As String = Split(Partes(7), "|")
                Espessura = CDbl(PropriedadesFisicas(0))
                MassaEspecifica = CDbl(PropriedadesFisicas(1))
                CondutividadeTermica = CDbl(PropriedadesFisicas(2))
                GeracaoDeCalor = CDbl(PropriedadesFisicas(3))

                TemperaturaInicial = CDbl(Partes(8))

                If Not Partes(9) = "" Then
                    Dim CC() As String = Split(Partes(9), vbNewLine)
                    For i = 0 To UBound(CC)
                        Dim Linhas() As String = Split(CC(i), "|")
                        Dim Parametros() As String = Split(Linhas(UBound(Linhas)), "#")
                        Dim Linhas_NovaCC(UBound(Linhas) - 1) As Integer
                        For j = 0 To UBound(Linhas) - 1
                            Linhas_NovaCC(j) = CInt(Linhas(j))
                        Next
                        Linhas_CC_1.Add({Linhas_NovaCC, CDbl(Parametros(0)), CInt(Parametros(1)), Parametros(2), CInt(Parametros(3))})
                    Next
                End If

                If Not Partes(10) = "" Then
                    Dim CC() As String = Split(Partes(10), vbNewLine)
                    For i = 0 To UBound(CC)
                        Dim Linhas() As String = Split(CC(i), "|")
                        Dim Parametros() As String = Split(Linhas(UBound(Linhas)), "#")
                        Dim Linhas_NovaCC(UBound(Linhas) - 1) As Integer
                        For j = 0 To UBound(Linhas) - 1
                            Linhas_NovaCC(j) = CInt(Linhas(j))
                        Next
                        Linhas_CC_2.Add({Linhas_NovaCC, CDbl(Parametros(0)), CInt(Parametros(1)), Parametros(2), CInt(Parametros(3))})
                    Next
                End If

                If Not Partes(11) = "" Then
                    Dim CC() As String = Split(Partes(11), vbNewLine)
                    For i = 0 To UBound(CC)
                        Dim Linhas() As String = Split(CC(i), "|")
                        Dim Parametros() As String = Split(Linhas(UBound(Linhas)), "#")
                        Dim Linhas_NovaCC(UBound(Linhas) - 1) As Integer
                        For j = 0 To UBound(Linhas) - 1
                            Linhas_NovaCC(j) = CInt(Linhas(j))
                        Next
                        Linhas_CC_3.Add({Linhas_NovaCC, CDbl(Parametros(0)), CDbl(Parametros(1)), CInt(Parametros(2)), Parametros(3), CInt(Parametros(4))})
                    Next
                End If

                TipoDeAnalise = CInt(Partes(12))

                TipoDeSolver = CInt(Partes(13))

                Dim ParametrosDePosProcessamento() As String = Split(Partes(14), "|")
                TipoDeVisualizacao = CInt(ParametrosDePosProcessamento(0))
                EscalaDeCinza = CBool(ParametrosDePosProcessamento(1))
                PassoEntreIsotermas = CInt(ParametrosDePosProcessamento(2))
                Imagem_Tamanho = CInt(ParametrosDePosProcessamento(3))

                If Not Partes(15) = "" Then
                    Dim Imag() As String = Split(Partes(15), vbNewLine)
                    For i = 0 To UBound(Imag)
                        Dim Imagem As Bitmap = Bitmap.FromStream(New System.IO.MemoryStream(Convert.FromBase64String(Imag(i))))
                        Imagens.Add(Imagem)
                    Next
                End If

                Dim ParametrosDiversos() As String = Split(Partes(16), "|")
                TempoLimite_Malha = CInt(ParametrosDiversos(0))
                Maior_X = CDbl(ParametrosDiversos(1))
                Maior_Y = CDbl(ParametrosDiversos(2))
                Maior_Temperatura = CDbl(ParametrosDiversos(3))
                Menor_Temperatura = CDbl(ParametrosDiversos(4))
                Proporcao_X = Imagem_Tamanho / Maior_X
                Proporcao_Y = Imagem_Tamanho / Maior_Y
                Proporcao_Geral = Math.Min(Proporcao_X, Proporcao_Y)

                If Not Partes(17) = "" Then
                    Dim Linhas() As String = Split(Partes(17), vbNewLine)
                    If UsarDenseMatrix() Then
                        MatrizDeCondutividadeGlobal = New DenseMatrix(UBound(Linhas) + 1)
                    Else
                        Dim tmp(UBound(Linhas), UBound(Linhas)) As Double
                        MatrizDeCondutividadeGlobal = tmp
                    End If
                    For i = 0 To UBound(Linhas)
                        Dim Colunas() As String = Split(Linhas(i), "|")
                        For j = 0 To UBound(Colunas)
                            MatrizDeCondutividadeGlobal(i, j) = CDbl(Colunas(j))
                        Next
                    Next
                End If

                If Not Partes(18) = "" Then
                    Dim Linhas() As String = Split(Partes(18), "|")
                    If UsarDenseMatrix() Then
                        VetorDeCargaTermicaGlobal = New DenseMatrix(UBound(Linhas) + 1, 0)
                    Else
                        Dim tmp(UBound(Linhas), 0) As Double
                        VetorDeCargaTermicaGlobal = tmp

                    End If
                    For i = 0 To UBound(Linhas)
                        VetorDeCargaTermicaGlobal(i, 0) = CDbl(Linhas(i))
                    Next
                End If

                If Not Partes(19) = "" Then
                    Dim Linhas() As String = Split(Partes(19), "|")
                    If UsarDenseMatrix() Then
                        VetorDeTemperaturas = New DenseMatrix(UBound(Linhas) + 1, 0)
                    Else
                        Dim tmp(UBound(Linhas), 0) As Double
                        VetorDeTemperaturas = tmp
                    End If
                    For i = 0 To UBound(Linhas)
                        VetorDeTemperaturas(i, 0) = CDbl(Linhas(i))
                    Next
                End If

                If Not Partes(20) = "" Then
                    Dim Linhas() As String = Split(Partes(20), vbNewLine)
                    ReDim MatrizDeFuncoesDeForma(9, TriangulosDaMalha.Count - 1)
                    For i = 0 To UBound(Linhas)
                        Dim Colunas() As String = Split(Linhas(i), "|")
                        For j = 0 To 9
                            MatrizDeFuncoesDeForma(j, i) = CDbl(Colunas(j))
                        Next
                    Next
                End If

                VerificarStatusDaImportacao()

                Me.Enabled = True
                Me.Cursor = Cursors.Arrow
            End If
        Catch ex As Exception
            Me.Enabled = True
            Me.Cursor = Cursors.Arrow
            FecharProblemaAtual(False)
            MsgBox("Ocorreu um erro desconhecido ao tentar carregar o arquivo Ignis indicado!" & vbNewLine & vbNewLine & "Por favor, tente novamente.", MsgBoxStyle.Critical)
            Return False
            Exit Function
        End Try

        Return True
    End Function
#End Region

#Region "FUNÇÕES DE MANIPULAÇÃO DO PROBLEMA (CRIAÇÃO / VERIFICAÇÃO / LIMPEZA)"
    Public Sub LimparProblema()
        PontosDaGeometria.Clear()
        LinhasDaGeometria.Clear()
        FronteirasDaGeometria.Clear()
        PontosEmFurosDaGeometria.Clear()
        PontosDaMalha.Clear()
        LinhasDeContornoDaMalha.Clear()
        TriangulosDaMalha.Clear()
        Espessura = 0.0
        MassaEspecifica = 0.00001
        CondutividadeTermica = 0.0
        GeracaoDeCalor = 0.0
        TemperaturaInicial = -999999999.999
        Linhas_CC_1.Clear()
        Linhas_CC_2.Clear()
        Linhas_CC_3.Clear()
        TipoDeAnalise = 1
        TipoDeSolver = 1
        TipoDeVisualizacao = 1
        EscalaDeCinza = False
        PassoEntreIsotermas = 10
        Imagem_Tamanho = 500
        Imagens.Clear()
        ArquivoIgnisAtual = ""
        MatrizDeCondutividadeGlobal = Nothing
        VetorDeCargaTermicaGlobal = Nothing
        VetorDeTemperaturas = Nothing
        ReDim MatrizDeFuncoesDeForma(0, 0)
        PlotArea.BackgroundImage = Nothing
        Escala.Image = Nothing
        Maior_Temperatura = -100000.0
        Menor_Temperatura = 100000.0
    End Sub

    Public Sub LimparMalha()
        PontosDaMalha.Clear()
        LinhasDeContornoDaMalha.Clear()
        TriangulosDaMalha.Clear()
    End Sub

    Public Sub LimparCC()
        Linhas_CC_1.Clear()
        Linhas_CC_2.Clear()
        Linhas_CC_3.Clear()
    End Sub

    Public Sub LimparResultados()
        Imagens.Clear()
        MatrizDeCondutividadeGlobal = Nothing
        VetorDeCargaTermicaGlobal = Nothing
        VetorDeTemperaturas = Nothing
        ReDim MatrizDeFuncoesDeForma(0, 0)
        PlotArea.BackgroundImage = Nothing
        Escala.Image = Nothing
        Maior_Temperatura = -100000.0
        Menor_Temperatura = 100000.0
        tMin.Text = ""
        tMax.Text = ""
    End Sub

    Private Sub FecharProblemaAtual(ByVal Salvar As Boolean)
        If Salvar Then
            If Not SalvarProblemaAtual() Then Exit Sub
        End If
        LimparProblema()
        TreeView1.Nodes.Clear()
        bSalvar.Enabled = False
        bIniciarSimulacao.Enabled = False
        FecharSimulaçãoAtualToolStripMenuItem.Enabled = False
        SalvarImagemToolStripMenuItem1.Enabled = False
        ResultadosToolStripMenuItem.Enabled = False
    End Sub

    Private Function SalvarProblemaAtual(Optional ByVal ForcarNovoCaminho As Boolean = False) As Boolean
        Me.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Try
            If FileExists(ArquivoIgnisAtual) AndAlso Not ForcarNovoCaminho Then
                WriteAllText(ArquivoIgnisAtual, StringArquivoIgnis, False)
                MsgBox("Problema salvo com sucesso!", MsgBoxStyle.Information)
                Me.Enabled = True
                Me.Cursor = Cursors.Arrow
                Return True
            Else
                If SalvarSimulacao.ShowDialog = DialogResult.OK Then
                    WriteAllText(SalvarSimulacao.FileName, StringArquivoIgnis, False)
                    ArquivoIgnisAtual = SalvarSimulacao.FileName
                    Dim Parts() As String = Split(ArquivoIgnisAtual, "\")
                    TreeView1.Nodes(0).Text = " " & Parts(UBound(Parts))
                    MsgBox("Problema salvo com sucesso!", MsgBoxStyle.Information)
                    Me.Enabled = True
                    Me.Cursor = Cursors.Arrow
                    Return True
                Else
                    Me.Enabled = True
                    Me.Cursor = Cursors.Arrow
                    Return False
                End If
            End If
        Catch ex As Exception
            Me.Enabled = True
            Me.Cursor = Cursors.Arrow
            MsgBox("Ocorreu um erro desconhecido ao tentar salvar o problema atual!" & vbNewLine & vbNewLine & "Por favor, tente novamente.", MsgBoxStyle.Critical)
            Return False
        End Try
    End Function

    Private Sub NovoProblema(ByVal Carregar As Boolean, Optional ByVal CaminhoDoProblema As String = "")
        TreeView1.SuspendLayout()
        TreeView1.Nodes.Clear()

        Dim NomeDaSimulacao As New TreeNode
        NomeDaSimulacao.Text = " NovaSimulação.ignis"
        NomeDaSimulacao.NodeFont = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        NomeDaSimulacao.ContextMenuStrip = CMS_Renomear
        TreeView1.Nodes.Add(NomeDaSimulacao)

        Dim PreProcessamento As New TreeNode
        PreProcessamento.Text = " Pré-Processamento"
        PreProcessamento.StateImageIndex = 13

        Dim PreProcessamento_Geometria As New TreeNode
        PreProcessamento_Geometria.Name = "P_1"
        PreProcessamento_Geometria.Text = " Geometria"
        PreProcessamento_Geometria.StateImageIndex = 13

        Dim PreProcessamento_Malha As New TreeNode
        PreProcessamento_Malha.Name = "P_2"
        PreProcessamento_Malha.Text = " Malha"
        PreProcessamento_Malha.StateImageIndex = 13

        Dim PreProcessamento_PropFis As New TreeNode
        PreProcessamento_PropFis.Name = "P_3"
        PreProcessamento_PropFis.Text = " Propriedades Físicas"
        PreProcessamento_PropFis.StateImageIndex = 13

        Dim PreProcessamento_CI As New TreeNode
        PreProcessamento_CI.Name = "P_4"
        PreProcessamento_CI.Text = " Condições Iniciais"
        PreProcessamento_CI.StateImageIndex = 0

        Dim PreProcessamento_CC As New TreeNode
        PreProcessamento_CC.Name = "P_5"
        PreProcessamento_CC.Text = " Condições de Contorno"
        PreProcessamento_CC.StateImageIndex = 13

        PreProcessamento.Nodes.AddRange({PreProcessamento_Geometria, PreProcessamento_Malha, PreProcessamento_PropFis, PreProcessamento_CI, PreProcessamento_CC})

        Dim Processamento As New TreeNode
        Processamento.Text = " Processamento / Solução"
        Processamento.StateImageIndex = 0

        Dim Processamento_Parametros As New TreeNode
        Processamento_Parametros.Name = "P_6"
        Processamento_Parametros.Text = " Parâmetros"
        Processamento_Parametros.StateImageIndex = 0

        Dim Processamento_Solver As New TreeNode
        Processamento_Solver.Name = "P_7"
        Processamento_Solver.Text = " Solver"
        Processamento_Solver.StateImageIndex = 0

        Processamento.Nodes.AddRange({Processamento_Parametros, Processamento_Solver})

        Dim PosProcessamento As New TreeNode
        PosProcessamento.Text = " Pós-Processamento"
        PosProcessamento.StateImageIndex = 0

        Dim PosProcessamento_Parametros As New TreeNode
        PosProcessamento_Parametros.Name = "P_8"
        PosProcessamento_Parametros.Text = " Parâmetros de Visualização"
        PosProcessamento_Parametros.StateImageIndex = 0

        PosProcessamento.Nodes.AddRange({PosProcessamento_Parametros})

        TreeView1.Nodes.AddRange({PreProcessamento, Processamento, PosProcessamento})
        TreeView1.ExpandAll()

        TipoDeSolver = SolverPadrao
        TipoDeVisualizacao = IIf(VisualizacaoPadrao = 1, 1, IIf(VisualizacaoPadrao = 2, 1, 2))
        EscalaDeCinza = VisualizacaoPadrao.Equals(2)

        ArquivoIgnisAtual = "\NovaSimulação.ignis"

        If Carregar Then
            If LerArquivoIgnis(CaminhoDoProblema) Then
                ArquivoIgnisAtual = CaminhoDoProblema
                Dim Arquivo() As String = Split(CaminhoDoProblema, "\")
                NomeDaSimulacao.Text = " " & Arquivo(UBound(Arquivo))
                MsgBox("Arquivo Ignis carregado com sucesso!", MsgBoxStyle.Information)
            End If
        End If

        TreeView1.ResumeLayout()

        bSalvar.Enabled = True
        FecharSimulaçãoAtualToolStripMenuItem.Enabled = True
        SalvarImagemToolStripMenuItem1.Enabled = True
        ResultadosToolStripMenuItem.Enabled = True
    End Sub

    Private Sub VerificarStatusDaImportacao()
        If FronteirasDaGeometria.Count > 0 Then
            EditarGeometria.VerificarStatusDaGeometria(False)
            If EditarGeometria.GeometriaDefinida = True Then TreeView1.Nodes(1).Nodes(0).StateImageIndex = 0
            EditarGeometria.Dispose()
        End If
        If TriangulosDaMalha.Count > 1 Then
            TreeView1.Nodes(1).Nodes(1).StateImageIndex = 0
        End If
        If Espessura <> 0.0 AndAlso MassaEspecifica <> 0.0 AndAlso CondutividadeTermica <> 0.0 Then
            TreeView1.Nodes(1).Nodes(2).StateImageIndex = 0
        End If
        If Linhas_CC_1.Count > 0 OrElse Linhas_CC_3.Count > 0 Then
            TreeView1.Nodes(1).Nodes(4).StateImageIndex = 0
        End If
        CriarEscalaDeCores()
        If Imagens.Count > 0 Then
            AtualizarImagem(0, TipoDeVisualizacao.Equals(1))
        End If
        VerificarStatusDaSimulacao()
    End Sub

    Private Sub VerificarStatusDaSimulacao()
        'VERIFICAR PRÉ-PROCESSAMENTO
        Dim Definido As Boolean = True
        For i = 0 To 4
            If TreeView1.Nodes(1).Nodes(i).StateImageIndex = 13 Then
                Definido = False
                Exit For
            End If
        Next
        If Definido Then
            TreeView1.Nodes(1).StateImageIndex = 0
            StatusDoProblema.Text = "Tudo pronto!"
            StatusDoProblema.ForeColor = Color.DarkGreen
            bIniciarSimulacao.Enabled = True
        Else
            TreeView1.Nodes(1).StateImageIndex = 13
            StatusDoProblema.Text = "Parâmetros pendentes!"
            StatusDoProblema.ForeColor = Color.Coral
            bIniciarSimulacao.Enabled = False
        End If
    End Sub

    Public Sub CriarEscalaDeCores()
        If EscalaDeCinza Then
            Dim GradienteGeral As New LinearGradientBrush(New Point(0, 0), New Point(500, 0), ES_12, ES_01)
            GradienteGeral.WrapMode = WrapMode.Tile
            Dim color_blend As New ColorBlend
            color_blend.Colors = New Color() {ES_12, ES_11, ES_10, ES_09, ES_08, ES_07, ES_06, ES_05, ES_04, ES_03, ES_02, ES_01}
            color_blend.Positions = New Single() {0.0, (1 / 11) * 1, (1 / 11) * 2, (1 / 11) * 3, (1 / 11) * 4, (1 / 11) * 5, (1 / 11) * 6, (1 / 11) * 7, (1 / 11) * 8, (1 / 11) * 9, (1 / 11) * 10, 1.0}
            GradienteGeral.InterpolationColors = color_blend
            GradienteGeral.GammaCorrection = True
            EscalaDeCores.Dispose()
            EscalaDeCores = New Bitmap(501, 31)
            Dim Retangulo As Graphics = Graphics.FromImage(EscalaDeCores)
            Retangulo.FillRectangle(GradienteGeral, 0, 0, 501, 31)
            Retangulo.Dispose()
            GradienteGeral.Dispose()
        Else
            Dim GradienteGeral As New LinearGradientBrush(New Point(0, 0), New Point(500, 0), Cor_23, Cor_01)
            GradienteGeral.WrapMode = WrapMode.Tile
            Dim color_blend As New ColorBlend
            color_blend.Colors = New Color() {Cor_23, Cor_22, Cor_21, Cor_20, Cor_19, Cor_18, Cor_17, Cor_16, Cor_15, Cor_14, Cor_13, Cor_12, Cor_11, Cor_10, Cor_09, Cor_08, Cor_07, Cor_06, Cor_05, Cor_04, Cor_03, Cor_02, Cor_01}
            color_blend.Positions = New Single() {0.0, (1 / 22) * 1, (1 / 22) * 2, (1 / 22) * 3, (1 / 22) * 4, (1 / 22) * 5, (1 / 22) * 6, (1 / 22) * 7, (1 / 22) * 8, (1 / 22) * 9, (1 / 22) * 10, (1 / 22) * 11, (1 / 22) * 12, (1 / 22) * 13, (1 / 22) * 14, (1 / 22) * 15, (1 / 22) * 16, (1 / 22) * 17, (1 / 22) * 18, (1 / 22) * 19, (1 / 22) * 20, (1 / 22) * 21, 1.0}
            GradienteGeral.InterpolationColors = color_blend
            GradienteGeral.GammaCorrection = True
            EscalaDeCores.Dispose()
            EscalaDeCores = New Bitmap(501, 31)
            Dim Retangulo As Graphics = Graphics.FromImage(EscalaDeCores)
            Retangulo.FillRectangle(GradienteGeral, 0, 0, 501, 31)
            Retangulo.Dispose()
            GradienteGeral.Dispose()
        End If
    End Sub
#End Region

#Region "INTERATIVIDADE COM INTERFACE DE USUÁRIO"

    Private PosicaoDoMarcador As New Point(428, 575)
    Private PosicaoDoIndicador As New Point(385, 608)

    Private Sub Escala_MouseEnter(sender As Object, e As EventArgs) Handles Escala.MouseEnter
        If Not Maior_Temperatura = -100000.0 AndAlso Not Menor_Temperatura = 100000.0 Then
            tMin.Hide()
            tMax.Hide()
            Marcador.Show()
            tAtual.Show()
        End If
    End Sub

    Private Sub Escala_MouseLeave(sender As Object, e As EventArgs) Handles Escala.MouseLeave
        If Not Maior_Temperatura = -100000.0 AndAlso Not Menor_Temperatura = 100000.0 Then
            tMin.Show()
            tMax.Show()
            Marcador.Hide()
            tAtual.Hide()
        End If
    End Sub

    Private Sub Escala_MouseMove(sender As Object, e As MouseEventArgs) Handles Escala.MouseMove
        If Not Maior_Temperatura = -100000.0 AndAlso Not Menor_Temperatura = 100000.0 Then
            PosicaoDoMarcador.X = e.X + Escala.Location.X + 2
            PosicaoDoIndicador.X = e.X + Escala.Location.X - 41
            Marcador.Location = PosicaoDoMarcador
            tAtual.Location = PosicaoDoIndicador
            tAtual.Text = CStr(Math.Round(Menor_Temperatura + (e.X * ((Maior_Temperatura - Menor_Temperatura) / Escala.Width)), 2))
        End If
    End Sub

    Private Sub PlotArea_MouseDown(sender As Object, e As MouseEventArgs) Handles PlotArea.MouseDown
        Try
            Dim Temperatura As Double = TemperaturaNaPosicao({(e.X * (Imagem_Tamanho / 500)) / Proporcao_Geral, ((500 - e.Y) * (Imagem_Tamanho / 500)) / Proporcao_Geral})
            If Not Temperatura = -100000.0 Then
                PosicaoDoMarcador.X = (Math.Round(500 * (Temperatura - (Menor_Temperatura)) / (Maior_Temperatura - (Menor_Temperatura)), 0, MidpointRounding.ToEven)) + Escala.Location.X
                PosicaoDoIndicador.X = (Math.Round(500 * (Temperatura - (Menor_Temperatura)) / (Maior_Temperatura - (Menor_Temperatura)), 0, MidpointRounding.ToEven)) + Escala.Location.X - 39
                Marcador.Location = PosicaoDoMarcador
                tAtual.Location = PosicaoDoIndicador
                tAtual.Text = CStr(Math.Round(Temperatura, 2))
                tMin.Hide()
                tMax.Hide()
                Marcador.Show()
                tAtual.Show()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub PlotArea_MouseUp(sender As Object, e As MouseEventArgs) Handles PlotArea.MouseUp
        tMin.Show()
        tMax.Show()
        Marcador.Hide()
        tAtual.Hide()
    End Sub

    Private Sub TreeView1_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseDoubleClick
        Select Case e.Node.Name
            Case "P_1" ' PRÉ-PROCESSAMENTO - GEOMETRIA
                If TreeView1.Nodes(1).Nodes(1).StateImageIndex = 0 OrElse Linhas_CC_1.Count > 0 OrElse Linhas_CC_2.Count > 0 OrElse Linhas_CC_3.Count > 0 Then
                    If MsgBox("Ao acessar o Editor de Geometria, a malha, condições de contorno e resultados serão resetados." & vbNewLine & vbNewLine & "Deseja continuar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub
                    LimparMalha()
                    LimparCC()
                    LimparResultados()
                    TreeView1.Nodes(1).Nodes(1).StateImageIndex = 13
                    TreeView1.Nodes(1).Nodes(4).StateImageIndex = 13
                End If
                EditarGeometria.ShowDialog()
                If EditarGeometria.GeometriaDefinida = True Then
                    e.Node.StateImageIndex = 0
                Else
                    LimparMalha()
                    LimparCC()
                    LimparResultados()
                    TreeView1.Nodes(1).Nodes(1).StateImageIndex = 13
                    TreeView1.Nodes(1).Nodes(4).StateImageIndex = 13
                    e.Node.StateImageIndex = 13
                End If
                EditarGeometria.Dispose()
                VerificarStatusDaSimulacao()
            Case "P_2" ' PRÉ-PROCESSAMENTO - MALHA
                If TreeView1.Nodes(1).Nodes(0).StateImageIndex = 13 Then
                    MsgBox("Não é possível editar a malha antes de definir a geometria corretamente!", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                If Not Maior_Temperatura = -100000.0 AndAlso Not Menor_Temperatura = 100000.0 Then
                    If MsgBox("Ao acessar o Editor de Malha, todos os resultados serão resetados." & vbNewLine & vbNewLine & "Deseja continuar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub
                    LimparResultados()
                End If
                EditarMalha.ShowDialog()
                If EditarMalha.MalhaDefinida = True Then
                    e.Node.StateImageIndex = 0
                    If PontosDaMalha.Count > 16384 Then 'Limite de nós numa matriz de formato DenseMatrix
                        If TipoDeSolver = 1 OrElse TipoDeSolver = 2 Then
                            TipoDeSolver = 3 'Decomposição LU
                            MsgBox("O tipo de solver foi alterado para 'Decomposição LU', pois o método previamente selecionado requer o uso de matrizes no formato DenseMatrix, as quais suportam somente 16.384 nós, menos do que a malha atualmente definida.", MsgBoxStyle.Information)
                        End If
                    End If
                Else
                    e.Node.StateImageIndex = 13
                End If
                EditarMalha.Dispose()
                VerificarStatusDaSimulacao()
            Case "P_3" ' PRÉ-PROCESSAMENTO - PROPRIEDADES FÍSICAS
                If Not Maior_Temperatura = -100000.0 AndAlso Not Menor_Temperatura = 100000.0 Then
                    If MsgBox("Ao acessar o Editor de Propriedades Físicas, todos os resultados serão resetados." & vbNewLine & vbNewLine & "Deseja continuar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub
                    LimparResultados()
                End If
                EditarPropFis.ShowDialog()
                If Espessura > 0 AndAlso MassaEspecifica > 0 AndAlso CondutividadeTermica > 0 Then e.Node.StateImageIndex = 0 Else e.Node.StateImageIndex = 13
                VerificarStatusDaSimulacao()
            Case "P_4" ' PRÉ-PROCESSAMENTO - CONDIÇÕES INICIAIS
                Select Case TipoDeAnalise
                    Case 1 'Condução de Calor em Regime Permanente
                        MsgBox("Disponível somente para análises em Regime Transiente.", MsgBoxStyle.Information)
                    Case 2 'Condução de Calor em Regime Transiente
                        If Not Maior_Temperatura = -100000.0 AndAlso Not Menor_Temperatura = 100000.0 Then
                            If MsgBox("Ao acessar o Editor de Condições Iniciais, todos os resultados serão resetados." & vbNewLine & vbNewLine & "Deseja continuar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub
                            LimparResultados()
                        End If
                        EditarCI.ShowDialog()
                        If TemperaturaInicial > -999999999.999 Then e.Node.StateImageIndex = 0 Else e.Node.StateImageIndex = 13
                        VerificarStatusDaSimulacao()
                End Select
            Case "P_5" ' PRÉ-PROCESSAMENTO - CONDIÇÕES DE CONTORNO
                If TreeView1.Nodes(1).Nodes(0).StateImageIndex = 13 Then
                    MsgBox("Não é possível editar as condições de contorno antes de definir a geometria corretamente!", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
                If Not Maior_Temperatura = -100000.0 AndAlso Not Menor_Temperatura = 100000.0 Then
                    If MsgBox("Ao acessar o Editor de Condições de Contorno, todos os resultados serão resetados." & vbNewLine & vbNewLine & "Deseja continuar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub
                    LimparResultados()
                End If
                EditarCC.ShowDialog()
                If Linhas_CC_1.Count > 0 OrElse Linhas_CC_3.Count > 0 Then e.Node.StateImageIndex = 0 Else e.Node.StateImageIndex = 13
                VerificarStatusDaSimulacao()
            Case "P_6" ' PROCESSAMENTO / SOLUÇÃO - PARÂMETROS
                If Not Maior_Temperatura = -100000.0 AndAlso Not Menor_Temperatura = 100000.0 Then
                    If MsgBox("Ao acessar o Editor de Parâmetros do Solver, todos os resultados serão resetados." & vbNewLine & vbNewLine & "Deseja continuar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub
                    LimparResultados()
                End If
                EditarParamProc.ShowDialog()
                Select Case TipoDeAnalise
                    Case 1 'Condução de Calor em Regime Permanente
                        TreeView1.Nodes(1).Nodes(3).StateImageIndex = 0
                    Case 2 'Condução de Calor em Regime Transiente
                        If TemperaturaInicial = -999999999.999 Then TreeView1.Nodes(1).Nodes(3).StateImageIndex = 13 Else TreeView1.Nodes(1).Nodes(3).StateImageIndex = 0
                End Select
                VerificarStatusDaSimulacao()
            Case "P_7" ' PROCESSAMENTO / SOLUÇÃO - SOLVER
                If Not Maior_Temperatura = -100000.0 AndAlso Not Menor_Temperatura = 100000.0 Then
                    If MsgBox("Ao acessar o Editor de Solver, todos os resultados serão resetados." & vbNewLine & vbNewLine & "Deseja continuar?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then Exit Sub
                    LimparResultados()
                End If
                EditarSolver.ShowDialog()
            Case "P_8" ' PÓS-PROCESSAMENTO - PARÂMETROS
                EditarParamPosProc.ShowDialog()
                If EditarParamPosProc.Alterado AndAlso Maior_Temperatura <> -100000.0 AndAlso Menor_Temperatura <> 100000.0 Then
                    If MsgBox("Deseja atualizar os resultados gráficos?", MsgBoxStyle.Question + MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                        AEF_SegundoPlano = New Thread(AddressOf AtualizarResultadosGraficos)
                        IniciarAnalise()
                    End If
                End If
                EditarParamPosProc.Dispose()
        End Select
    End Sub

    Private Sub StatusDoProblema_TextChanged(sender As Object, e As EventArgs) Handles StatusDoProblema.TextChanged
        If StatusDoProblema.Text = "Análise concluída!" Then
            MsgBox("Análise concluída!" & vbNewLine & vbNewLine & "Pré-processamento: " & (Tempo_Proc_1.Elapsed.TotalMilliseconds / 1000) & " segundo(s)" & vbNewLine & vbNewLine & "Aplicação das C.C.'s: " & (Tempo_Proc_2.Elapsed.TotalMilliseconds / 1000) & " segundo(s)" & vbNewLine & vbNewLine & "Solver: " & (Tempo_Proc_3.Elapsed.TotalMilliseconds / 1000) & " segundo(s)" & vbNewLine & vbNewLine & "Renderização: " & (Tempo_Proc_4.Elapsed.TotalMilliseconds / 1000) & " segundo(s)", MsgBoxStyle.Information)
            StatusDaJanela(True)
        ElseIf StatusDoProblema.Text = "Plotagem concluída!" Then
            StatusDaJanela(True)
        ElseIf StatusDoProblema.Text = "Erro!" Then
            MsgBox("Ocorreu um erro desconhecido durante a solução do problema. Tente novamente.", MsgBoxStyle.Critical)
            StatusDaJanela(True)
        End If
    End Sub

    Private Sub StatusDaJanela(ByVal Ativa As Boolean)
        If Ativa Then
            TreeView1.Enabled = True
            PlotArea.Enabled = True
            Escala.Enabled = True
            bNovaSimulacao.Enabled = True
            bAbrir.Enabled = True
            bSalvar.Enabled = True
            MenuPrincipal.Enabled = True
            StatusDoProblema.Text = "Tudo pronto!"
            StatusDoProblema.ForeColor = Color.DarkGreen
            bIniciarSimulacao.Enabled = True
            bIniciarSimulacao.Text = "Iniciar Simulação"
        Else
            TreeView1.Enabled = False
            PlotArea.Enabled = False
            Escala.Enabled = False
            PlotArea.BackgroundImage = Nothing
            bNovaSimulacao.Enabled = False
            bAbrir.Enabled = False
            bSalvar.Enabled = False
            MenuPrincipal.Enabled = False
            StatusDoProblema.Text = "Resolvendo o problema..."
            StatusDoProblema.ForeColor = Color.Black
            bIniciarSimulacao.Text = "Parar Simulação"
        End If
    End Sub

#End Region

#Region "BOTÕES DA TELA"
    Private Sub bNovaSimulacao_Click(sender As Object, e As EventArgs) Handles bNovaSimulacao.Click
        If TreeView1.Nodes.Count > 0 Then
            Dim resultado As MsgBoxResult = MsgBox("Deseja salvar a simulação atual?" & vbNewLine & vbNewLine & "Todas as alterações realizadas serão perdidas!", vbQuestion + MsgBoxStyle.YesNoCancel, "Deseja salvar a simulação?")
            If resultado = MsgBoxResult.Cancel Then
                Exit Sub
            ElseIf resultado = MsgBoxResult.Yes Then
                If Not SalvarProblemaAtual() Then Exit Sub
            End If
        End If
        FecharProblemaAtual(False)
        NovoProblema(False)
    End Sub

    Private Sub SairDoIgnisToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SairDoIgnisToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub FecharSimulaçãoAtualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FecharSimulaçãoAtualToolStripMenuItem.Click
        Dim resultado As MsgBoxResult = MsgBox("Deseja salvar a simulação atual?" & vbNewLine & vbNewLine & "Todas as alterações realizadas serão perdidas!", vbQuestion + MsgBoxStyle.YesNoCancel, "Deseja salvar a simulação?")
        If resultado = MsgBoxResult.Cancel Then
            Exit Sub
        ElseIf resultado = MsgBoxResult.Yes Then
            If Not SalvarProblemaAtual() Then Exit Sub
        End If
        FecharProblemaAtual(False)
    End Sub

    Private Sub bAbrir_Click(sender As Object, e As EventArgs) Handles bAbrir.Click
        If TreeView1.Nodes.Count > 0 Then
            Dim resultado As MsgBoxResult = MsgBox("Deseja salvar a simulação atual?" & vbNewLine & vbNewLine & "Todas as alterações realizadas serão perdidas!", vbQuestion + MsgBoxStyle.YesNoCancel, "Deseja salvar a simulação?")
            If resultado = MsgBoxResult.Cancel Then
                Exit Sub
            ElseIf resultado = MsgBoxResult.Yes Then
                If Not SalvarProblemaAtual() Then Exit Sub
            End If
        End If
        Dim dr As DialogResult = AbrirArquivoIgnis.ShowDialog()
        If dr = DialogResult.OK Then
            FecharProblemaAtual(False)
            NovoProblema(True, AbrirArquivoIgnis.FileName)
        End If
    End Sub

    Private Sub CMS_Renomear_R_Click(sender As Object, e As EventArgs) Handles CMS_Renomear_R.Click
        RenomearSimulacao.ShowDialog()
    End Sub

    Private Sub bIniciarSimulacao_Click(sender As Object, e As EventArgs) Handles bIniciarSimulacao.Click
        If bIniciarSimulacao.Text = "Iniciar Simulação" Then
            AEF_SegundoPlano = New Thread(AddressOf AnaliseDeElementosFinitos)
            IniciarAnalise()
        Else
            bIniciarSimulacao.Enabled = False
            PararAnalise()
        End If
    End Sub

    Private Sub SalvarImagemToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SalvarImagemToolStripMenuItem1.Click
        If Imagens.Count > 0 Then
            Dim Partes() As String = Split(ArquivoIgnisAtual, "\")
            SalvarImagem.FileName = Partes(UBound(Partes)).Replace(".ignis", "")
            If SalvarImagem.ShowDialog() = DialogResult.OK Then
                Dim IncluirEscala As Boolean = False
                If MsgBox("Deseja incluir a escala de temperaturas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then IncluirEscala = True
                Dim ImagemParaSalvar As New Bitmap(Imagem_Tamanho + IIf(IncluirEscala, 141, 0), Imagem_Tamanho + 1)
                Dim g1 As Graphics = Graphics.FromImage(ImagemParaSalvar)
                Dim res As Image = PlotArea.BackgroundImage.Clone
                Dim Fundo As New SolidBrush(Color.White)
                Dim Caneta As New SolidBrush(Color.Black)
                g1.FillRectangle(Fundo, 0, 0, Imagem_Tamanho + 141, Imagem_Tamanho + 1)
                g1.DrawImage(res, 0, 0)
                If IncluirEscala Then
                    If Escala.Image IsNot Nothing Then
                        Dim esc As Image = Escala.Image.Clone
                        esc.RotateFlip(RotateFlipType.Rotate270FlipNone)
                        g1.DrawImage(esc, Imagem_Tamanho + 40, 0)
                    End If
                    g1.DrawRectangle(New Pen(Caneta), Imagem_Tamanho + 40, 0, 30, 500)
                    g1.DrawString(tMax.Text, New Font("Segoe UI", 10.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte)), Caneta, New PointF(Imagem_Tamanho + 78, 0))
                    g1.DrawString(tMin.Text, New Font("Segoe UI", 10.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte)), Caneta, New PointF(Imagem_Tamanho + 78, 482))
                End If
                g1.Dispose()
                ImagemParaSalvar.Save(SalvarImagem.FileName)
                MsgBox("Imagem salva com sucesso!", MsgBoxStyle.Information)
            End If
        Else
            MsgBox("Não há nenhuma imagem disponível!", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub bSalvar_ButtonClick(sender As Object, e As EventArgs) Handles bSalvar.ButtonClick
        SalvarProblemaAtual()
    End Sub

    Private Sub SalvarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvarToolStripMenuItem.Click
        SalvarProblemaAtual()
    End Sub

    Private Sub SalvarComoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalvarComoToolStripMenuItem.Click
        SalvarProblemaAtual(True)
    End Sub

    Private Sub ConfiguraçõesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ConfiguraçõesToolStripMenuItem1.Click
        EditarConfig.ShowDialog()
    End Sub

    Private Sub SobreOIgnisToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SobreOIgnisToolStripMenuItem1.Click
        MsgBox("O Ignis é um software didático para análises de condução de calor baseado no Método dos Elementos Finitos (MEF), criado na linguagem VB.NET." & vbNewLine & vbNewLine & "Foi criado no ano de 2017 como produto de um Trabalho de Conclusão de Curso de Engenharia Mecânica da Universidade Positivo, em Curitiba, Paraná." & vbNewLine & vbNewLine & "Seus autores são:" & vbNewLine & "Diego Oliveira Kunrath (do_kunrath@hotmail.com)" & vbNewLine & "Gustavo Crovador (gustavo.crovador@gmail.com)" & vbNewLine & vbNewLine & "Este software é completamente gratuito e seu código fonte pode ser acessado em: https://github.com/Crovadore/Ignis" & vbNewLine & vbNewLine & "Este trabalho foi orientado pelo M. Eng. Antonio Carlos Foltran.", MsgBoxStyle.Information)
    End Sub

    Private Sub ResultadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResultadosToolStripMenuItem.Click
        If Imagens.Count > 0 Then
            VisualizarResultados.ShowDialog()
        Else
            MsgBox("Não há nenhum resultado disponível!", MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region

#Region "FUNÇÕES DA ANÁLISE DE ELEMENTOS FINITOS"
    Private Sub IniciarAnalise()
        StatusDaJanela(False)
        AEF_SegundoPlano.Start()
    End Sub

    Private Sub PararAnalise()
        AEF_SegundoPlano.Suspend()
        StatusDaJanela(True)
    End Sub

    Private Sub AnaliseDeElementosFinitos()
        Try
            Invoke(Sub()
                       StatusDoProblema.Text = "Pré-processamento..."
                   End Sub)
            Tempo_Proc_1 = Stopwatch.StartNew
            PreProcessamento(UsarDenseMatrix)
            Tempo_Proc_1.Stop()

            Invoke(Sub()
                       StatusDoProblema.Text = "Aplicando condições de contorno..."
                   End Sub)
            Tempo_Proc_2 = Stopwatch.StartNew
            AplicarCondicoesDeContorno()
            Tempo_Proc_2.Stop()

            Invoke(Sub()
                       StatusDoProblema.Text = "Resolvendo sistema de equações..."
                   End Sub)
            Tempo_Proc_3 = Stopwatch.StartNew()
            ResolverSistema()
            Tempo_Proc_3.Stop()

            Maior_Temperatura = -100000.0 'Maior temperatura calculada
            Menor_Temperatura = 100000.0 'Menor temperatura calculada

            For i = 0 To PontosDaMalha.Count - 1
                If VetorDeTemperaturas(i, 0) < Menor_Temperatura Then Menor_Temperatura = VetorDeTemperaturas(i, 0)
                If VetorDeTemperaturas(i, 0) > Maior_Temperatura Then Maior_Temperatura = VetorDeTemperaturas(i, 0)
            Next

            Invoke(Sub()
                       StatusDoProblema.Text = "Renderizando resultados..."
                       CriarEscalaDeCores()
                   End Sub)
            Tempo_Proc_4 = Stopwatch.StartNew()
            PlotarResultados()
            Tempo_Proc_4.Stop()

            Invoke(Sub()
                       StatusDoProblema.Text = "Análise concluída!"
                   End Sub)
        Catch ex As Exception
            Invoke(Sub()
                       StatusDoProblema.ForeColor = Color.Red
                       StatusDoProblema.Text = "Erro!"
                   End Sub)
        End Try
    End Sub

    Private Function UsarDenseMatrix() As Boolean
        Select Case TipoDeSolver
            Case 1 'Simples
                Return True
            Case 2 'Decomposição QR
                Return True
            Case 3 'Decomposição LU
                Return False
            Case Else 'Não implementado
                Return False
        End Select
    End Function

    Private Sub PreProcessamento(ByVal UsarDenseMatrix As Boolean)
        Dim QuantidadeDeElementos As Integer = TriangulosDaMalha.Count
        Dim QuantidadeDeNos As Integer = PontosDaMalha.Count

        '--------- Dimensionamento da Matriz de Condutividade Global [K], do Vetor de Carga Térmica Global {f} e da Matriz de Funções de Forma

        MatrizDeCondutividadeGlobal = Nothing
        VetorDeCargaTermicaGlobal = Nothing
        VetorDeTemperaturas = Nothing
        If UsarDenseMatrix Then
            MatrizDeCondutividadeGlobal = New DenseMatrix(QuantidadeDeNos, QuantidadeDeNos)
            VetorDeCargaTermicaGlobal = New DenseMatrix(QuantidadeDeNos, 1)
            VetorDeTemperaturas = New DenseMatrix(QuantidadeDeNos, 1)
        Else
            Dim tmp(0, 0) As Double
            MatrizDeCondutividadeGlobal = tmp
            VetorDeCargaTermicaGlobal = tmp
            VetorDeTemperaturas = tmp
            ReDim MatrizDeCondutividadeGlobal(QuantidadeDeNos - 1, QuantidadeDeNos - 1)
            ReDim VetorDeCargaTermicaGlobal(QuantidadeDeNos - 1, 0)
            ReDim VetorDeTemperaturas(QuantidadeDeNos - 1, 0)
        End If

        ReDim MatrizDeFuncoesDeForma(9, QuantidadeDeElementos - 1)

        '--------- Declaração de variáveis auxiliares

        Dim a_1, a_2, a_3, b_1, b_2, b_3, c_1, c_2, c_3 As Double ' Variáveis auxiliares para cálculo das funções de forma
        Dim x(2), y(2) As Double ' Guardam as coordenadas x e y de cada um dos 3 nós de um elemento
        Dim AreaVezesDois As Double ' 2x Área do elemento

        '--------- Dimensionamento das matrizes de rigidez e dos vetores de carga térmica individuais 

        Maior_X = 0.0
        Maior_Y = 0.0
        For i_Elemento = 0 To QuantidadeDeElementos - 1 'Para cada triângulo da malha...
            For i_No = 0 To 2 'Para cada nó do triângulo...
                x(i_No) = PontosDaMalha(TriangulosDaMalha(i_Elemento)(i_No))(0)
                If Maior_X < x(i_No) Then Maior_X = x(i_No)
                y(i_No) = PontosDaMalha(TriangulosDaMalha(i_Elemento)(i_No))(1)
                If Maior_Y < y(i_No) Then Maior_Y = y(i_No)
            Next

            a_1 = (x(1) * y(2)) - (x(2) * y(1))
            a_2 = (x(2) * y(0)) - (x(0) * y(2))
            a_3 = (x(0) * y(1)) - (x(1) * y(0))

            b_1 = y(1) - y(2)
            b_2 = y(2) - y(0)
            b_3 = y(0) - y(1)

            c_1 = x(2) - x(1)
            c_2 = x(0) - x(2)
            c_3 = x(1) - x(0)

            AreaVezesDois = Math.Abs((x(0) * y(1)) - (x(1) * y(0)) + (x(2) * y(0)) - (x(0) * y(2)) + (x(1) * y(2)) - (x(2) * y(1)))

            MatrizDeFuncoesDeForma(0, i_Elemento) = a_1
            MatrizDeFuncoesDeForma(1, i_Elemento) = a_2
            MatrizDeFuncoesDeForma(2, i_Elemento) = a_3
            MatrizDeFuncoesDeForma(3, i_Elemento) = b_1
            MatrizDeFuncoesDeForma(4, i_Elemento) = b_2
            MatrizDeFuncoesDeForma(5, i_Elemento) = b_3
            MatrizDeFuncoesDeForma(6, i_Elemento) = c_1
            MatrizDeFuncoesDeForma(7, i_Elemento) = c_2
            MatrizDeFuncoesDeForma(8, i_Elemento) = c_3
            MatrizDeFuncoesDeForma(9, i_Elemento) = AreaVezesDois

            MatrizDeCondutividadeGlobal(TriangulosDaMalha(i_Elemento)(0), TriangulosDaMalha(i_Elemento)(0)) += CondutividadeTermica * Espessura * ((b_1 ^ 2) + (c_1 ^ 2)) / (2 * AreaVezesDois)
            MatrizDeCondutividadeGlobal(TriangulosDaMalha(i_Elemento)(0), TriangulosDaMalha(i_Elemento)(1)) += CondutividadeTermica * Espessura * ((b_1 * b_2) + (c_1 * c_2)) / (2 * AreaVezesDois)
            MatrizDeCondutividadeGlobal(TriangulosDaMalha(i_Elemento)(0), TriangulosDaMalha(i_Elemento)(2)) += CondutividadeTermica * Espessura * ((b_1 * b_3) + (c_1 * c_3)) / (2 * AreaVezesDois)
            MatrizDeCondutividadeGlobal(TriangulosDaMalha(i_Elemento)(1), TriangulosDaMalha(i_Elemento)(0)) += CondutividadeTermica * Espessura * ((b_1 * b_2) + (c_1 * c_2)) / (2 * AreaVezesDois)
            MatrizDeCondutividadeGlobal(TriangulosDaMalha(i_Elemento)(1), TriangulosDaMalha(i_Elemento)(1)) += CondutividadeTermica * Espessura * ((b_2 ^ 2) + (c_2 ^ 2)) / (2 * AreaVezesDois)
            MatrizDeCondutividadeGlobal(TriangulosDaMalha(i_Elemento)(1), TriangulosDaMalha(i_Elemento)(2)) += CondutividadeTermica * Espessura * ((b_2 * b_3) + (c_2 * c_3)) / (2 * AreaVezesDois)
            MatrizDeCondutividadeGlobal(TriangulosDaMalha(i_Elemento)(2), TriangulosDaMalha(i_Elemento)(0)) += CondutividadeTermica * Espessura * ((b_1 * b_3) + (c_1 * c_3)) / (2 * AreaVezesDois)
            MatrizDeCondutividadeGlobal(TriangulosDaMalha(i_Elemento)(2), TriangulosDaMalha(i_Elemento)(1)) += CondutividadeTermica * Espessura * ((b_2 * b_3) + (c_2 * c_3)) / (2 * AreaVezesDois)
            MatrizDeCondutividadeGlobal(TriangulosDaMalha(i_Elemento)(2), TriangulosDaMalha(i_Elemento)(2)) += CondutividadeTermica * Espessura * ((b_3 ^ 2) + (c_3 ^ 2)) / (2 * AreaVezesDois)

            VetorDeCargaTermicaGlobal(TriangulosDaMalha(i_Elemento)(0), 0) += (GeracaoDeCalor * Espessura * (AreaVezesDois / 2)) / 3
            VetorDeCargaTermicaGlobal(TriangulosDaMalha(i_Elemento)(1), 0) += (GeracaoDeCalor * Espessura * (AreaVezesDois / 2)) / 3
            VetorDeCargaTermicaGlobal(TriangulosDaMalha(i_Elemento)(2), 0) += (GeracaoDeCalor * Espessura * (AreaVezesDois / 2)) / 3
        Next
    End Sub

    Private Sub AplicarCondicoesDeContorno()

        '--------- Declaração de variáveis auxiliares

        Dim QuantidadeDeNos As Integer = PontosDaMalha.Count
        Dim dx, dy, ComprimentoDaLinha As Double

        '--------- Aplicação das Condições de Contorno

        'MsgBox(CStr(VetorDeCargaTermicaGlobal(0, 0)) & vbNewLine & CStr(VetorDeCargaTermicaGlobal(1, 0)) & vbNewLine & CStr(VetorDeCargaTermicaGlobal(2, 0)) & vbNewLine & CStr(VetorDeCargaTermicaGlobal(3, 0)))
        'MsgBox(MatrizDeCondutividadeGlobal.ToString)
        'Dim NosAfetados As New List(Of Integer)

        For Each CC In Linhas_CC_2 'Neumann ({Linhas} | Fluxo | Fronteira | Descrição)
            For Each LinhaDeContornoDaMalha In LinhasDeContornoDaMalha 'Para cada linha de contorno da malha (segmentos das linhas de contorno da geometria)...
                For Each LinhaDeContornoDaGeometria As Integer In CC(0) 'Para cada linha de contorno da geometria com condição de contorno especificada...
                    If LinhaDeContornoDaGeometria.Equals(LinhaDeContornoDaMalha(2) - 1) Then 'Se a linha de contorno da malha atual pertencer (estiver contida) na linha de contorno da geometria...
                        dx = PontosDaMalha(LinhaDeContornoDaMalha(0))(0) - PontosDaMalha(LinhaDeContornoDaMalha(1))(0) 'Comprimento da linha em X
                        dy = PontosDaMalha(LinhaDeContornoDaMalha(0))(1) - PontosDaMalha(LinhaDeContornoDaMalha(1))(1) 'Comprimento da linha em Y
                        ComprimentoDaLinha = Math.Sqrt((dx ^ 2) + (dy ^ 2))
                        'If Not NosAfetados.Contains(LinhaDeContornoDaMalha(0)) Then
                        VetorDeCargaTermicaGlobal(LinhaDeContornoDaMalha(0), 0) -= (CDbl(CC(1)) * Espessura * ComprimentoDaLinha) / 2 'Aplica a condição de contorno do primeiro nó no vetor {f}
                        'NosAfetados.Add(LinhaDeContornoDaMalha(0))
                        'End If
                        'If Not NosAfetados.Contains(LinhaDeContornoDaMalha(1)) Then
                        VetorDeCargaTermicaGlobal(LinhaDeContornoDaMalha(1), 0) -= (CDbl(CC(1)) * Espessura * ComprimentoDaLinha) / 2 'Aplica a condição de contorno do segundo nó no vetor {f}
                        'NosAfetados.Add(LinhaDeContornoDaMalha(1))
                        'End If
                        Exit For
                    End If
                Next
            Next
        Next
        'NosAfetados.Clear()
        For Each CC In Linhas_CC_3 'Robin ({Linhas} | Coef. de Convec. | Temp. do Fluido | Fronteira | Descrição)
            For Each LinhaDeContornoDaMalha In LinhasDeContornoDaMalha 'Para cada linha de contorno da malha (segmentos das linhas de contorno da geometria)...
                For Each LinhaDeContornoDaGeometria As Integer In CC(0) 'Para cada linha de contorno da geometria com condição de contorno especificada...
                    If LinhaDeContornoDaGeometria.Equals(LinhaDeContornoDaMalha(2) - 1) Then 'Se a linha de contorno da malha atual pertencer (estiver contida) na linha de contorno da geometria...
                        dx = PontosDaMalha(LinhaDeContornoDaMalha(0))(0) - PontosDaMalha(LinhaDeContornoDaMalha(1))(0) 'Comprimento da linha em X
                        dy = PontosDaMalha(LinhaDeContornoDaMalha(0))(1) - PontosDaMalha(LinhaDeContornoDaMalha(1))(1) 'Comprimento da linha em Y
                        ComprimentoDaLinha = Math.Sqrt((dx ^ 2) + (dy ^ 2))
                        'If Not NosAfetados.Contains(LinhaDeContornoDaMalha(0)) Then
                        MatrizDeCondutividadeGlobal(LinhaDeContornoDaMalha(0), LinhaDeContornoDaMalha(0)) += ((CDbl(CC(1)) * Espessura * ComprimentoDaLinha) / 6) * 2
                        MatrizDeCondutividadeGlobal(LinhaDeContornoDaMalha(0), LinhaDeContornoDaMalha(1)) += ((CDbl(CC(1)) * Espessura * ComprimentoDaLinha) / 6)
                        VetorDeCargaTermicaGlobal(LinhaDeContornoDaMalha(0), 0) += (CDbl(CC(1)) * CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 2 'Aplica a condição de contorno do primeiro nó no vetor {f}
                        'NosAfetados.Add(LinhaDeContornoDaMalha(0))
                        'End If
                        'If Not NosAfetados.Contains(LinhaDeContornoDaMalha(1)) Then
                        MatrizDeCondutividadeGlobal(LinhaDeContornoDaMalha(1), LinhaDeContornoDaMalha(0)) += ((CDbl(CC(1)) * Espessura * ComprimentoDaLinha) / 6)
                        MatrizDeCondutividadeGlobal(LinhaDeContornoDaMalha(1), LinhaDeContornoDaMalha(1)) += ((CDbl(CC(1)) * Espessura * ComprimentoDaLinha) / 6) * 2
                        VetorDeCargaTermicaGlobal(LinhaDeContornoDaMalha(1), 0) += (CDbl(CC(1)) * CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 2 'Aplica a condição de contorno do segundo nó no vetor {f}
                        'NosAfetados.Add(LinhaDeContornoDaMalha(1))
                        'End If
                        Exit For
                    End If
                Next
            Next
        Next
        'MsgBox(CStr(VetorDeCargaTermicaGlobal(0, 0)) & vbNewLine & CStr(VetorDeCargaTermicaGlobal(1, 0)) & vbNewLine & CStr(VetorDeCargaTermicaGlobal(2, 0)) & vbNewLine & CStr(VetorDeCargaTermicaGlobal(3, 0)))
        'MsgBox(MatrizDeCondutividadeGlobal.ToString)
        'NosAfetados.Clear()
        For Each CC In Linhas_CC_1 'Dirichlet ({Linhas} | Temperatura | Fronteira | Descrição) (sobrepõe outras condições de contorno!)
            For Each LinhaDeContornoDaMalha In LinhasDeContornoDaMalha 'Para cada linha de contorno da malha (segmentos das linhas de contorno da geometria)...
                For Each LinhaDeContornoDaGeometria As Integer In CC(0) 'Para cada linha de contorno da geometria com condição de contorno especificada...
                    If LinhaDeContornoDaGeometria.Equals(LinhaDeContornoDaMalha(2) - 1) Then 'Se a linha de contorno da malha atual pertencer (estiver contida) na linha de contorno da geometria...
                        VetorDeCargaTermicaGlobal(LinhaDeContornoDaMalha(0), 0) = CC(1) 'Insere a temperatura do primeiro nó (contido nas linhas da C.C.) no vetor {f}
                        VetorDeCargaTermicaGlobal(LinhaDeContornoDaMalha(1), 0) = CC(1) 'Insere a temperatura do segundo nó (contido nas linhas da C.C.) no vetor {f}
                        For j = 0 To QuantidadeDeNos - 1 'Para cada coluna da matriz [K]
                            MatrizDeCondutividadeGlobal(LinhaDeContornoDaMalha(0), j) = 0.0 'Zera toda a linha cujo índice é igual ao número do primeiro nó da linha
                            MatrizDeCondutividadeGlobal(LinhaDeContornoDaMalha(1), j) = 0.0 'Zera toda a linha cujo índice é igual ao número do segundo nó da linha
                        Next
                        MatrizDeCondutividadeGlobal(LinhaDeContornoDaMalha(0), LinhaDeContornoDaMalha(0)) = 1 'Define como 1 o valor do item da matriz com índice [1º nó, 1º nó].
                        MatrizDeCondutividadeGlobal(LinhaDeContornoDaMalha(1), LinhaDeContornoDaMalha(1)) = 1 'Define como 1 o valor do item da matriz com índice [2º nó, 2º nó].
                        Exit For
                    End If
                Next
            Next
        Next
        'MsgBox(CStr(VetorDeCargaTermicaGlobal(0, 0)) & vbNewLine & CStr(VetorDeCargaTermicaGlobal(1, 0)) & vbNewLine & CStr(VetorDeCargaTermicaGlobal(2, 0)) & vbNewLine & CStr(VetorDeCargaTermicaGlobal(3, 0)))
        'MsgBox(MatrizDeCondutividadeGlobal.ToString)
    End Sub

    Private Sub ResolverSistema()
        Select Case TipoDeSolver
            Case 1 'Simples
                SolverSimples()
            Case 2 'Decomposição QR
                SolverQR()
            Case 3 'Decomposição LU
                SolverLU()
        End Select
    End Sub

    Private Sub SolverSimples()
        VetorDeTemperaturas = MatrizDeCondutividadeGlobal.Inverse.Multiply(VetorDeCargaTermicaGlobal)
    End Sub

    Private Sub SolverQR()
        MatrizDeCondutividadeGlobal.Solve(VetorDeCargaTermicaGlobal, VetorDeTemperaturas)
    End Sub

    Private Sub SolverLU()
        ' Decomposição da Matriz
        Dim n As Integer = UBound(MatrizDeCondutividadeGlobal, 1)
        Dim LU(n, n) As Double
        Dim Soma As Double = 0
        For i As Integer = 0 To n

            Parallel.For(i, n + 1,
                         Sub(j As Integer)
                             Dim Sum As Double = 0.0
                             For k As Integer = 0 To i - 1
                                 Sum += LU(i, k) * LU(k, j)
                             Next
                             LU(i, j) = MatrizDeCondutividadeGlobal(i, j) - Sum
                         End Sub)

            Parallel.For(i + 1, n + 1,
                         Sub(j As Integer)
                             Dim Sum As Double = 0.0
                             For k As Integer = 0 To i - 1
                                 Sum += LU(j, k) * LU(k, i)
                             Next
                             LU(j, i) = (1 / LU(i, i)) * (MatrizDeCondutividadeGlobal(j, i) - Sum)
                         End Sub)

        Next

        ' Encontrar Solução de Ly = b
        Dim y(n, 0) As Double
        For i As Integer = 0 To n
            Soma = 0
            For k As Integer = 0 To i - 1
                Soma += LU(i, k) * y(k, 0)
            Next
            y(i, 0) = VetorDeCargaTermicaGlobal(i, 0) - Soma
        Next

        ' Encontrar Solução de  Ux = y
        'ReDim VetorDeTemperaturas(n, 0)
        For i As Integer = n To 0 Step -1
            Soma = 0
            For k As Integer = i + 1 To n
                Soma += LU(i, k) * VetorDeTemperaturas(k, 0)
            Next
            VetorDeTemperaturas(i, 0) = (1 / LU(i, i)) * (y(i, 0) - Soma)
        Next
    End Sub

    Private Sub AtualizarResultadosGraficos()
        Try
            Invoke(Sub()
                       StatusDoProblema.Text = "Atualizando resultados..."
                       CriarEscalaDeCores()
                   End Sub)
            Tempo_Proc_4 = Stopwatch.StartNew()
            PlotarResultados()
            Tempo_Proc_4.Stop()

            Invoke(Sub()
                       StatusDoProblema.Text = "Plotagem concluída!"
                   End Sub)
        Catch ex As Exception
            Invoke(Sub()
                       StatusDoProblema.ForeColor = Color.Red
                       StatusDoProblema.Text = "Erro!"
                   End Sub)
        End Try
    End Sub

    Private Sub PlotarResultados()
        Select Case TipoDeVisualizacao
            Case 1 'Gradiente de Temperaturas
                RenderizarGradiente()
                AtualizarImagem(0, True)
            Case 2 'Linhas Isotérmicas
                DesenharIsotermas()
                AtualizarImagem(0, False)
        End Select
    End Sub

    Private Sub RenderizarGradiente()
        Imagens.Clear()
        Dim Imagem_Resultado As New Bitmap(Imagem_Tamanho + 1, Imagem_Tamanho + 1)
        Imagem_Resultado.MakeTransparent()
        Proporcao_X = Imagem_Tamanho / Maior_X
        Proporcao_Y = Imagem_Tamanho / Maior_Y
        Proporcao_Geral = Math.Min(Proporcao_X, Proporcao_Y)

        Dim _Escala As Integer = 0

        Dim CoordenadasX(UBound(FronteirasDaGeometria(0))) As Double
        Dim CoordenadasY(UBound(FronteirasDaGeometria(0))) As Double

        Dim MapaDaImagem(Imagem_Tamanho * Imagem_Tamanho) As Integer

        For j = 0 To UBound(FronteirasDaGeometria(0))
            CoordenadasX(j) = PontosDaGeometria(LinhasDaGeometria(FronteirasDaGeometria(0)(j))(0))(0)
            CoordenadasY(j) = PontosDaGeometria(LinhasDaGeometria(FronteirasDaGeometria(0)(j))(0))(1)
        Next

        Dim InteriorDaGeometria As Boolean = False

        'Processamento paralelo dos pixels da imagem
        Parallel.For(0,
                     (Imagem_Tamanho * Imagem_Tamanho) + 1,
                     Sub(pixel As Integer)
                         Dim x As Integer = pixel Mod Imagem_Tamanho
                         Dim tmp As Integer = 0
                         Dim y As Integer = Math.DivRem(pixel, Imagem_Tamanho, tmp)
                         If tmp = 0 AndAlso pixel > 0 Then y -= 1
                         Dim PontoDeTeste() As Double = {(x / Proporcao_Geral), (y / Proporcao_Geral)}

                         'VERIFICA SE O PONTO ESTÁ CONTIDO NA GEOMETRIA, DESCONSIDERANDO FUROS
                         Dim cn As Integer = 0
                         For k = 0 To UBound(CoordenadasX)
                             If ((CoordenadasY(k) <= PontoDeTeste(1)) AndAlso (CoordenadasY((k + 1) Mod (UBound(CoordenadasX) + 1)) > PontoDeTeste(1))) OrElse ((CoordenadasY(k) > PontoDeTeste(1)) AndAlso (CoordenadasY((k + 1) Mod (UBound(CoordenadasX) + 1)) <= PontoDeTeste(1))) Then
                                 Dim vt As Single = CDbl(PontoDeTeste(1) - CoordenadasY(k)) / (CoordenadasY((k + 1) Mod (UBound(CoordenadasX) + 1)) - CoordenadasY(k))
                                 If PontoDeTeste(0) < CoordenadasX(k) + vt * (CoordenadasX((k + 1) Mod (UBound(CoordenadasX) + 1)) - CoordenadasX(k)) Then cn += 1
                             End If
                         Next
                         If (cn Mod 2 = 1) Then
                             Dim NoFuro As Boolean = False
                             'VERIFICA SE O PONTO ESTÁ DENTRO DE ALGUM FURO (POR CONSEQUÊNCIA, FORA DA GEOMETRIA)
                             If FronteirasDaGeometria.Count > 1 Then
                                 For f = 1 To FronteirasDaGeometria.Count - 1
                                     Dim CoordenadasX_F(UBound(FronteirasDaGeometria(f)))
                                     Dim CoordenadasY_F(UBound(FronteirasDaGeometria(f)))
                                     Dim Linha As Integer = 0
                                     For Linha = 0 To UBound(FronteirasDaGeometria(f))
                                         CoordenadasX_F(Linha) = PontosDaGeometria(LinhasDaGeometria(FronteirasDaGeometria(f)(Linha))(0))(0)
                                         CoordenadasY_F(Linha) = PontosDaGeometria(LinhasDaGeometria(FronteirasDaGeometria(f)(Linha))(0))(1)
                                     Next
                                     cn = 0
                                     For k = 0 To UBound(CoordenadasX_F)
                                         If ((CoordenadasY_F(k) <= PontoDeTeste(1)) AndAlso (CoordenadasY_F((k + 1) Mod (UBound(CoordenadasX_F) + 1)) > PontoDeTeste(1))) OrElse ((CoordenadasY_F(k) > PontoDeTeste(1)) AndAlso (CoordenadasY_F((k + 1) Mod (UBound(CoordenadasX_F) + 1)) <= PontoDeTeste(1))) Then
                                             Dim vt As Single = CDbl(PontoDeTeste(1) - CoordenadasY_F(k)) / (CoordenadasY_F((k + 1) Mod (UBound(CoordenadasX_F) + 1)) - CoordenadasY_F(k))
                                             If PontoDeTeste(0) < CoordenadasX_F(k) + vt * (CoordenadasX_F((k + 1) Mod (UBound(CoordenadasX_F) + 1)) - CoordenadasX_F(k)) Then cn += 1
                                         End If
                                     Next
                                     If (cn Mod 2 = 1) Then 'Está dentro de algum furo
                                         NoFuro = True
                                         Exit For
                                     End If
                                 Next
                             End If
                             If Not NoFuro Then
                                 Dim CoordsX(1) As Double
                                 Dim CoordsY(1) As Double
                                 Dim NumeroDoElemento As Integer = -1
                                 Dim j As Integer = 0
                                 Dim i As Integer = 0
                                 For j = 0 To TriangulosDaMalha.Count - 1
                                     NumeroDoElemento = -1
                                     CoordsX = {PontosDaMalha(TriangulosDaMalha(j)(0))(0), PontosDaMalha(TriangulosDaMalha(j)(1))(0), PontosDaMalha(TriangulosDaMalha(j)(2))(0)}
                                     CoordsY = {PontosDaMalha(TriangulosDaMalha(j)(0))(1), PontosDaMalha(TriangulosDaMalha(j)(1))(1), PontosDaMalha(TriangulosDaMalha(j)(2))(1)}
                                     Dim minX As Double = Math.Min(CoordsX(0), Math.Min(CoordsX(1), CoordsX(2)))
                                     Dim maxX As Double = Math.Max(CoordsX(0), Math.Max(CoordsX(1), CoordsX(2)))
                                     Dim minY As Double = Math.Min(CoordsY(0), Math.Min(CoordsY(1), CoordsY(2)))
                                     Dim maxY As Double = Math.Max(CoordsY(0), Math.Max(CoordsY(1), CoordsY(2)))
                                     If PontoDeTeste(0) < minX OrElse PontoDeTeste(0) > maxX OrElse PontoDeTeste(1) < minY OrElse PontoDeTeste(1) > maxY Then
                                         Continue For
                                     End If
                                     cn = 0
                                     For i = 0 To UBound(CoordsX)
                                         If ((CoordsY(i) <= PontoDeTeste(1)) AndAlso (CoordsY((i + 1) Mod (UBound(CoordsX) + 1)) > PontoDeTeste(1))) OrElse ((CoordsY(i) > PontoDeTeste(1)) AndAlso (CoordsY((i + 1) Mod (UBound(CoordsX) + 1)) <= PontoDeTeste(1))) Then
                                             Dim vt As Single = CDbl(PontoDeTeste(1) - CoordsY(i)) / (CoordsY((i + 1) Mod (UBound(CoordsX) + 1)) - CoordsY(i))
                                             If PontoDeTeste(0) < CoordsX(i) + vt * (CoordsX((i + 1) Mod (UBound(CoordsX) + 1)) - CoordsX(i)) Then cn += 1
                                         End If
                                     Next
                                     If (cn Mod 2 = 1) Then
                                         NumeroDoElemento = j
                                         Exit For
                                     End If
                                 Next
                                 If NumeroDoElemento <> -1 Then
                                     Dim N_1 As Double = Math.Abs((MatrizDeFuncoesDeForma(0, NumeroDoElemento) + (MatrizDeFuncoesDeForma(3, NumeroDoElemento) * PontoDeTeste(0)) + (MatrizDeFuncoesDeForma(6, NumeroDoElemento) * PontoDeTeste(1))) / MatrizDeFuncoesDeForma(9, NumeroDoElemento))
                                     Dim N_2 As Double = Math.Abs((MatrizDeFuncoesDeForma(1, NumeroDoElemento) + (MatrizDeFuncoesDeForma(4, NumeroDoElemento) * PontoDeTeste(0)) + (MatrizDeFuncoesDeForma(7, NumeroDoElemento) * PontoDeTeste(1))) / MatrizDeFuncoesDeForma(9, NumeroDoElemento))
                                     Dim N_3 As Double = Math.Abs((MatrizDeFuncoesDeForma(2, NumeroDoElemento) + (MatrizDeFuncoesDeForma(5, NumeroDoElemento) * PontoDeTeste(0)) + (MatrizDeFuncoesDeForma(8, NumeroDoElemento) * PontoDeTeste(1))) / MatrizDeFuncoesDeForma(9, NumeroDoElemento))
                                     Dim T_1 As Double = VetorDeTemperaturas(TriangulosDaMalha(NumeroDoElemento)(0), 0)
                                     Dim T_2 As Double = VetorDeTemperaturas(TriangulosDaMalha(NumeroDoElemento)(1), 0)
                                     Dim T_3 As Double = VetorDeTemperaturas(TriangulosDaMalha(NumeroDoElemento)(2), 0)
                                     Dim TemperaturaPontual As Double = ((N_1 * T_1) + (N_2 * T_2) + (N_3 * T_3))
                                     Dim Temp_Max As Double = Math.Max(T_1, Math.Max(T_2, T_3))
                                     Dim Temp_Min As Double = Math.Min(T_1, Math.Min(T_2, T_3))
                                     If TemperaturaPontual > Temp_Max Then TemperaturaPontual = Temp_Max
                                     If TemperaturaPontual < Temp_Min Then TemperaturaPontual = Temp_Min
                                     Dim Esc As Integer = Math.Round(500 * (TemperaturaPontual - (Menor_Temperatura)) / (Maior_Temperatura - (Menor_Temperatura)), 0, MidpointRounding.ToEven)
                                     MapaDaImagem(pixel) = Esc
                                 Else 'Pixel não mapeado...
                                     MapaDaImagem(pixel) = -1 'Pixel indefinido
                                 End If
                             Else
                                 MapaDaImagem(pixel) = -2 'Pixel não está contido na seção do corpo analisado
                             End If
                         Else
                             MapaDaImagem(pixel) = -2 'Pixel não está contido na seção do corpo analisado
                         End If
                     End Sub)

        For pixel = 0 To UBound(MapaDaImagem)
            If MapaDaImagem(pixel) > -2 Then
                Dim x As Integer = pixel Mod Imagem_Tamanho
                Dim tmp As Integer = 0
                Dim y As Integer = Math.DivRem(pixel, Imagem_Tamanho, tmp)
                If tmp = 0 AndAlso pixel > 0 Then y -= 1
                If MapaDaImagem(pixel) > -1 Then
                    Imagem_Resultado.SetPixel(x, y, EscalaDeCores.GetPixel(MapaDaImagem(pixel), 15))
                Else
                    Imagem_Resultado.SetPixel(x, y, Imagem_Resultado.GetPixel(x, y - 1))
                End If
            End If
        Next

#Region "Código Antigo (mais lento)"
        'For x = 0 To Imagem_Tamanho
        '    For y = 0 To Imagem_Tamanho
        '        'Verifica se a posição relativa do pixel está contida na geometria
        '        If PontoNoPoligono({x / Proporcao_Geral, y / Proporcao_Geral}, CoordenadasX, CoordenadasY) Then
        '            InteriorDaGeometria = True
        '            If FronteirasDaGeometria.Count > 1 Then
        '                For i = 1 To FronteirasDaGeometria.Count - 1
        '                    ReDim CoordenadasX_F(UBound(FronteirasDaGeometria(i)))
        '                    ReDim CoordenadasY_F(UBound(FronteirasDaGeometria(i)))

        '                    PontosExternos.Clear()

        '                    For j = 0 To UBound(FronteirasDaGeometria(i))
        '                        If Not PontosExternos.Contains(LinhasDaGeometria(FronteirasDaGeometria(i)(j))(0)) Then
        '                            PontosExternos.Add(LinhasDaGeometria(FronteirasDaGeometria(i)(j))(0))
        '                            CoordenadasX_F(j) = PontosDaGeometria(LinhasDaGeometria(FronteirasDaGeometria(i)(j))(0))(0)
        '                            CoordenadasY_F(j) = PontosDaGeometria(LinhasDaGeometria(FronteirasDaGeometria(i)(j))(0))(1)
        '                        ElseIf Not PontosExternos.Contains(LinhasDaGeometria(FronteirasDaGeometria(i)(j))(1)) Then
        '                            PontosExternos.Add(LinhasDaGeometria(FronteirasDaGeometria(i)(j))(1))
        '                            CoordenadasX_F(j) = PontosDaGeometria(LinhasDaGeometria(FronteirasDaGeometria(i)(j))(1))(0)
        '                            CoordenadasY_F(j) = PontosDaGeometria(LinhasDaGeometria(FronteirasDaGeometria(i)(j))(1))(1)
        '                        End If
        '                    Next

        '                    If PontoNoPoligono({x / Proporcao_Geral, y / Proporcao_Geral}, CoordenadasX_F, CoordenadasY_F) Then
        '                        InteriorDaGeometria = False
        '                        Exit For
        '                    End If
        '                Next
        '            End If
        '        Else
        '            InteriorDaGeometria = False
        '        End If

        '        PontosExternos.Clear()

        '        If InteriorDaGeometria Then
        '            Dim TemperaturaNoPixel As Double = TemperaturaNaPosicao({x / Proporcao_Geral, y / Proporcao_Geral})
        '            If TemperaturaNoPixel <> -100000.0 Then
        '                _Escala = Math.Round(500 * (TemperaturaNoPixel - (Menor_Temperatura)) / (Maior_Temperatura - (Menor_Temperatura)), 0, MidpointRounding.ToEven)
        '                Imagem_Resultado.SetPixel(x, y, EscalaDeCores.GetPixel(_Escala, 15))
        '            Else
        '                If x > 0 AndAlso y > 0 Then
        '                    TemperaturaNoPixel = TemperaturaNaPosicao({x / Proporcao_Geral, (y - 1) / Proporcao_Geral})
        '                    If TemperaturaNoPixel <> -100000.0 Then
        '                        _Escala = Math.Round(500 * (TemperaturaNoPixel - (Menor_Temperatura)) / (Maior_Temperatura - (Menor_Temperatura)), 0, MidpointRounding.ToEven)
        '                        Imagem_Resultado.SetPixel(x, y, EscalaDeCores.GetPixel(_Escala, 15))
        '                    End If
        '                End If
        '            End If
        '        End If
        '    Next
        'Next
#End Region

        Dim g As Graphics = Graphics.FromImage(Imagem_Resultado)
        g.CompositingQuality = CompositingQuality.HighQuality
        g.SmoothingMode = SmoothingMode.HighQuality
        For Each Fronteira In FronteirasDaGeometria
            For i = 0 To UBound(Fronteira)
                g.DrawLine(New Pen(Color.Black, 1), New PointF(PontosDaGeometria(LinhasDaGeometria(Fronteira(i))(0))(0) * Proporcao_Geral, PontosDaGeometria(LinhasDaGeometria(Fronteira(i))(0))(1) * Proporcao_Geral), New PointF(PontosDaGeometria(LinhasDaGeometria(Fronteira(i))(1))(0) * Proporcao_Geral, PontosDaGeometria(LinhasDaGeometria(Fronteira(i))(1))(1) * Proporcao_Geral))
            Next
        Next
        g.Dispose()

        Imagem_Resultado.RotateFlip(RotateFlipType.RotateNoneFlipY)
        Imagens.Add(Imagem_Resultado)
    End Sub

    Private Sub DesenharIsotermas()
        Imagens.Clear()
        Dim Imagem_Resultado As New Bitmap(Imagem_Tamanho + 1, Imagem_Tamanho + 1)
        Proporcao_X = Imagem_Tamanho / Maior_X
        Proporcao_Y = Imagem_Tamanho / Maior_Y
        Proporcao_Geral = Math.Min(Proporcao_X, Proporcao_Y)

        Dim Caneta_Isotermas As New Pen(Color.DimGray, (Imagem_Tamanho / 500))
        Dim Isoterma_Ponto_Inicial As New PointF
        Dim Isoterma_Ponto_Final As New PointF
        Dim Segundo As Boolean = False

        Dim g As Graphics = Graphics.FromImage(Imagem_Resultado)
        g.CompositingQuality = CompositingQuality.HighQuality
        g.SmoothingMode = SmoothingMode.HighQuality
        Dim Fundo As Brush = New SolidBrush(Color.White)
        Dim Tamanho As New Drawing.Size(Imagem_Tamanho + 1, Imagem_Tamanho + 1)
        g.FillRectangle(Fundo, New Rectangle(New Point(0, 0), Tamanho))
        Dim QuantidadeDeIsotermas As Integer = CInt(Math.Floor((Maior_Temperatura - Menor_Temperatura) / PassoEntreIsotermas))
        Dim Temperatura_No1, Temperatura_No2, Temperatura_No3 As Double
        Dim Posicao_No1(1), Posicao_No2(1), Posicao_No3(1) As Double
        For i = 1 To QuantidadeDeIsotermas
            Dim IsotermaAtual As Double = Menor_Temperatura + (i * PassoEntreIsotermas)
            For j = 0 To TriangulosDaMalha.Count - 1
                Temperatura_No1 = VetorDeTemperaturas(TriangulosDaMalha(j)(0), 0)
                Temperatura_No2 = VetorDeTemperaturas(TriangulosDaMalha(j)(1), 0)
                Temperatura_No3 = VetorDeTemperaturas(TriangulosDaMalha(j)(2), 0)
                Posicao_No1 = {PontosDaMalha(TriangulosDaMalha(j)(0))(0), PontosDaMalha(TriangulosDaMalha(j)(0))(1)}
                Posicao_No2 = {PontosDaMalha(TriangulosDaMalha(j)(1))(0), PontosDaMalha(TriangulosDaMalha(j)(1))(1)}
                Posicao_No3 = {PontosDaMalha(TriangulosDaMalha(j)(2))(0), PontosDaMalha(TriangulosDaMalha(j)(2))(1)}
                Isoterma_Ponto_Inicial.X = -1000000000.0
                Isoterma_Ponto_Inicial.Y = -1000000000.0
                Isoterma_Ponto_Final.X = -1000000000.0
                Isoterma_Ponto_Final.Y = -1000000000.0
                Segundo = False
                If Temperatura_No1 <= IsotermaAtual AndAlso Temperatura_No2 <= IsotermaAtual AndAlso Temperatura_No3 <= IsotermaAtual Then Continue For
                If Temperatura_No1 > IsotermaAtual AndAlso Temperatura_No2 > IsotermaAtual AndAlso Temperatura_No3 > IsotermaAtual Then Continue For
                If (Temperatura_No1 > IsotermaAtual AndAlso Temperatura_No2 < IsotermaAtual) OrElse (Temperatura_No1 < IsotermaAtual AndAlso Temperatura_No2 > IsotermaAtual) Then 'Entre nó 1 e 2
                    Isoterma_Ponto_Inicial.X = Posicao_No1(0) + (((Posicao_No2(0) - Posicao_No1(0)) * (IsotermaAtual - Temperatura_No1)) / (Temperatura_No2 - Temperatura_No1))
                    Isoterma_Ponto_Inicial.Y = Posicao_No1(1) + (((Posicao_No2(1) - Posicao_No1(1)) * (IsotermaAtual - Temperatura_No1)) / (Temperatura_No2 - Temperatura_No1))
                    Segundo = True
                End If
                If (Temperatura_No2 > IsotermaAtual AndAlso Temperatura_No3 < IsotermaAtual) OrElse (Temperatura_No2 < IsotermaAtual AndAlso Temperatura_No3 > IsotermaAtual) Then 'Entre nó 2 e 3
                    If Segundo Then
                        Isoterma_Ponto_Final.X = Posicao_No2(0) + (((Posicao_No3(0) - Posicao_No2(0)) * (IsotermaAtual - Temperatura_No2)) / (Temperatura_No3 - Temperatura_No2))
                        Isoterma_Ponto_Final.Y = Posicao_No2(1) + (((Posicao_No3(1) - Posicao_No2(1)) * (IsotermaAtual - Temperatura_No2)) / (Temperatura_No3 - Temperatura_No2))
                        GoTo A
                    Else
                        Isoterma_Ponto_Inicial.X = Posicao_No2(0) + (((Posicao_No3(0) - Posicao_No2(0)) * (IsotermaAtual - Temperatura_No2)) / (Temperatura_No3 - Temperatura_No2))
                        Isoterma_Ponto_Inicial.Y = Posicao_No2(1) + (((Posicao_No3(1) - Posicao_No2(1)) * (IsotermaAtual - Temperatura_No2)) / (Temperatura_No3 - Temperatura_No2))
                        Segundo = True
                    End If
                End If
                If (Temperatura_No1 > IsotermaAtual AndAlso Temperatura_No3 < IsotermaAtual) OrElse (Temperatura_No1 < IsotermaAtual AndAlso Temperatura_No3 > IsotermaAtual) Then 'Entre nó 1 e 3
                    If Segundo Then
                        Isoterma_Ponto_Final.X = Posicao_No1(0) + (((Posicao_No3(0) - Posicao_No1(0)) * (IsotermaAtual - Temperatura_No1)) / (Temperatura_No3 - Temperatura_No1))
                        Isoterma_Ponto_Final.Y = Posicao_No1(1) + (((Posicao_No3(1) - Posicao_No1(1)) * (IsotermaAtual - Temperatura_No1)) / (Temperatura_No3 - Temperatura_No1))
                        GoTo A
                    Else
                        Isoterma_Ponto_Inicial.X = Posicao_No1(0) + (((Posicao_No3(0) - Posicao_No1(0)) * (IsotermaAtual - Temperatura_No1)) / (Temperatura_No3 - Temperatura_No1))
                        Isoterma_Ponto_Inicial.Y = Posicao_No1(1) + (((Posicao_No3(1) - Posicao_No1(1)) * (IsotermaAtual - Temperatura_No1)) / (Temperatura_No3 - Temperatura_No1))
                        Segundo = True
                    End If
                End If
                If Temperatura_No1 = IsotermaAtual Then
                    If Segundo Then
                        Isoterma_Ponto_Final.X = Posicao_No1(0)
                        Isoterma_Ponto_Final.Y = Posicao_No1(1)
                        GoTo A
                    Else
                        Isoterma_Ponto_Inicial.X = Posicao_No1(0)
                        Isoterma_Ponto_Inicial.Y = Posicao_No1(1)
                        Segundo = True
                    End If
                End If
                If Temperatura_No2 = IsotermaAtual Then
                    If Segundo Then
                        Isoterma_Ponto_Final.X = Posicao_No2(0)
                        Isoterma_Ponto_Final.Y = Posicao_No2(1)
                        GoTo A
                    Else
                        Isoterma_Ponto_Inicial.X = Posicao_No2(0)
                        Isoterma_Ponto_Inicial.Y = Posicao_No2(1)
                        Segundo = True
                    End If
                End If
                If Temperatura_No3 = IsotermaAtual Then
                    If Segundo Then
                        Isoterma_Ponto_Final.X = Posicao_No3(0)
                        Isoterma_Ponto_Final.Y = Posicao_No3(1)
                    Else
                        Isoterma_Ponto_Inicial.X = Posicao_No3(0)
                        Isoterma_Ponto_Inicial.Y = Posicao_No3(1)
                        Segundo = True
                    End If
                End If
A:              If Isoterma_Ponto_Inicial.X = -1000000000.0 OrElse Isoterma_Ponto_Inicial.Y = -1000000000.0 OrElse Isoterma_Ponto_Final.X = -1000000000.0 OrElse Isoterma_Ponto_Final.Y = -1000000000.0 Then Continue For
                Isoterma_Ponto_Inicial.X = Isoterma_Ponto_Inicial.X * Proporcao_Geral
                Isoterma_Ponto_Inicial.Y = Isoterma_Ponto_Inicial.Y * Proporcao_Geral
                Isoterma_Ponto_Final.X = Isoterma_Ponto_Final.X * Proporcao_Geral
                Isoterma_Ponto_Final.Y = Isoterma_Ponto_Final.Y * Proporcao_Geral
                g.DrawLine(Caneta_Isotermas, Isoterma_Ponto_Inicial, Isoterma_Ponto_Final)
            Next
        Next

        For Each Fronteira In FronteirasDaGeometria
            For i = 0 To UBound(Fronteira)
                g.DrawLine(New Pen(Color.Black, (Imagem_Tamanho / 500)), New PointF(PontosDaGeometria(LinhasDaGeometria(Fronteira(i))(0))(0) * Proporcao_Geral, PontosDaGeometria(LinhasDaGeometria(Fronteira(i))(0))(1) * Proporcao_Geral), New PointF(PontosDaGeometria(LinhasDaGeometria(Fronteira(i))(1))(0) * Proporcao_Geral, PontosDaGeometria(LinhasDaGeometria(Fronteira(i))(1))(1) * Proporcao_Geral))
            Next
        Next

        g.Dispose()
        Imagem_Resultado.RotateFlip(RotateFlipType.RotateNoneFlipY)
        Imagens.Add(Imagem_Resultado)
    End Sub

    Private Sub AtualizarImagem(ByVal Index As Integer, ByVal MostrarEscala As Boolean, Optional ByVal Limpar As Boolean = False)
        Invoke(Sub()
                   If Limpar Then
                       PlotArea.BackgroundImage = Nothing
                       Escala.Image = Nothing
                       tMin.Hide()
                       tMax.Hide()
                   Else
                       PlotArea.BackgroundImage = Imagens(Index)
                       If MostrarEscala Then
                           Escala.Image = EscalaDeCores
                           tMin.Text = FormatNumber(Menor_Temperatura, 2, TriState.True, TriState.False, TriState.True)
                           tMax.Text = FormatNumber(Maior_Temperatura, 2, TriState.True, TriState.False, TriState.True)
                           tMin.Show()
                           tMax.Show()
                       Else
                           Escala.Image = Nothing
                           tMin.Text = FormatNumber(Menor_Temperatura, 2, TriState.True, TriState.False, TriState.True)
                           tMax.Text = FormatNumber(Maior_Temperatura, 2, TriState.True, TriState.False, TriState.True)
                           tMin.Show()
                           tMax.Show()
                       End If
                   End If
               End Sub)
    End Sub

#End Region

#Region "FUNÇÕES AUXILIARES DA AEF"
    Public Function PontoNoPoligono(ByRef PontoDeTeste() As Double, ByRef CoordenadasX() As Double, ByRef CoordenadasY() As Double) As Boolean
        Dim cn As Integer = 0
        For i As Integer = 0 To UBound(CoordenadasX)
            If ((CoordenadasY(i) <= PontoDeTeste(1)) AndAlso (CoordenadasY((i + 1) Mod (UBound(CoordenadasX) + 1)) > PontoDeTeste(1))) OrElse ((CoordenadasY(i) > PontoDeTeste(1)) AndAlso (CoordenadasY((i + 1) Mod (UBound(CoordenadasX) + 1)) <= PontoDeTeste(1))) Then
                Dim vt As Single = CDbl(PontoDeTeste(1) - CoordenadasY(i)) / (CoordenadasY((i + 1) Mod (UBound(CoordenadasX) + 1)) - CoordenadasY(i))
                If PontoDeTeste(0) < CoordenadasX(i) + vt * (CoordenadasX((i + 1) Mod (UBound(CoordenadasX) + 1)) - CoordenadasX(i)) Then cn += 1
            End If
        Next
        Return (cn Mod 2 = 1)
    End Function

    Public Function TemperaturaNaPosicao(ByVal Pos() As Double) As Double
        ' Determinar se ponto está dentro da área analisada
        tmpElemento = -1
        For i = 0 To TriangulosDaMalha.Count - 1
            CoordX = {PontosDaMalha(TriangulosDaMalha(i)(0))(0), PontosDaMalha(TriangulosDaMalha(i)(1))(0), PontosDaMalha(TriangulosDaMalha(i)(2))(0)}
            CoordY = {PontosDaMalha(TriangulosDaMalha(i)(0))(1), PontosDaMalha(TriangulosDaMalha(i)(1))(1), PontosDaMalha(TriangulosDaMalha(i)(2))(1)}
            minX = Math.Min(CoordX(0), Math.Min(CoordX(1), CoordX(2)))
            maxX = Math.Max(CoordX(0), Math.Max(CoordX(1), CoordX(2)))
            minY = Math.Min(CoordY(0), Math.Min(CoordY(1), CoordY(2)))
            maxY = Math.Max(CoordY(0), Math.Max(CoordY(1), CoordY(2)))
            If Pos(0) < minX OrElse Pos(0) > maxX OrElse Pos(1) < minY OrElse Pos(1) > maxY Then
                Continue For
            End If
            If PontoNoPoligono(Pos, CoordX, CoordY) Then
                tmpElemento = i
                Exit For
            End If
        Next
        If tmpElemento <> -1 Then
            N_1 = Math.Abs((MatrizDeFuncoesDeForma(0, tmpElemento) + (MatrizDeFuncoesDeForma(3, tmpElemento) * Pos(0)) + (MatrizDeFuncoesDeForma(6, tmpElemento) * Pos(1))) / MatrizDeFuncoesDeForma(9, tmpElemento))
            N_2 = Math.Abs((MatrizDeFuncoesDeForma(1, tmpElemento) + (MatrizDeFuncoesDeForma(4, tmpElemento) * Pos(0)) + (MatrizDeFuncoesDeForma(7, tmpElemento) * Pos(1))) / MatrizDeFuncoesDeForma(9, tmpElemento))
            N_3 = Math.Abs((MatrizDeFuncoesDeForma(2, tmpElemento) + (MatrizDeFuncoesDeForma(5, tmpElemento) * Pos(0)) + (MatrizDeFuncoesDeForma(8, tmpElemento) * Pos(1))) / MatrizDeFuncoesDeForma(9, tmpElemento))
            T_1 = VetorDeTemperaturas(TriangulosDaMalha(tmpElemento)(0), 0)
            T_2 = VetorDeTemperaturas(TriangulosDaMalha(tmpElemento)(1), 0)
            T_3 = VetorDeTemperaturas(TriangulosDaMalha(tmpElemento)(2), 0)
            TemperaturaPontual = ((N_1 * T_1) + (N_2 * T_2) + (N_3 * T_3))
            Temp_Max = Math.Max(T_1, Math.Max(T_2, T_3))
            Temp_Min = Math.Min(T_1, Math.Min(T_2, T_3))
            If TemperaturaPontual > Temp_Max Then TemperaturaPontual = Temp_Max
            If TemperaturaPontual < Temp_Min Then TemperaturaPontual = Temp_Min
            Return TemperaturaPontual
        Else
            Return -100000.0
        End If
    End Function
#End Region

End Class
