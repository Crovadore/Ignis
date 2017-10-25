Imports MathNet.Numerics.LinearAlgebra
Imports MathNet.Numerics.LinearAlgebra.Double
Imports System.IO.File
Imports System.Drawing.Drawing2D


Public Class OLD

    Public MatrizDeElementos As DenseMatrix
    Public MatrizDeCoordenadasDosNos As DenseMatrix
    'Public MatrizDeLinhasDeContorno As DenseMatrix
    Public MatrizDeParametros_CC1 As New List(Of Object()) 'Lista dos parâmetros das condições de contorno 01 (Dirichlet)
    Public MatrizDeParametros_CC2 As New List(Of Object()) 'Lista dos parâmetros das condições de contorno 02 (Neumann)
    Public MatrizDeParametros_CC3 As New List(Of Object()) 'Lista dos parâmetros das condições de contorno 03 (Robin)
    Public MatrizDeParametros_CC4 As New List(Of Object()) 'Lista dos parâmetros das condições de contorno 04 (Geração Uniforme)
    Public MatrizDeParametros_CC5 As New List(Of Object()) 'Lista dos parâmetros das condições de contorno 05 (Geração Pontual)
    Public MatrizDeFuncoesDeForma As DenseMatrix
    Public MatrizDePropriedadesGeometricas As DenseMatrix
    Public MatrizDePropriedadesGeometricasDeContorno As DenseMatrix

    Public MatrizDeRigidez_Termo_1 As DenseMatrix 'Condutividade
    Public MatrizDeRigidez_Termo_2 As DenseMatrix 'Convecção
    Public VetorDeCoeficientes_Termo_1 As DenseMatrix 'Geração de Calor
    Public VetorDeCoeficientes_Termo_2 As DenseMatrix 'Condução
    Public VetorDeCoeficientes_Termo_3 As DenseMatrix 'Convecção

    Private Maior_X As Double = 0.0
    Private Maior_Y As Double = 0.0
    Private Maior_Temperatura As Double = -100000.0
    Private Menor_Temperatura As Double = 100000.0

    Public VetorDeTemperaturas As DenseMatrix

    Dim Tamanho_X As Integer = 500 'Tamanho da Imagem Processada em X (pixels)
    Dim Tamanho_Y As Integer = 500 'Tamanho da Imagem Processada em Y (pixels)

    Dim ImagemProcessada As New Bitmap(Tamanho_X + 1, Tamanho_Y + 1)
    Dim MalhaProcessada As New Bitmap(Tamanho_X + 1, Tamanho_Y + 1)

#Region "Cores da Interface Gráfica"
    Dim Cor_01 As Color = Color.FromArgb(255, 45, 45) 'Vermelho
    Dim Cor_02 As Color = Color.FromArgb(255, 85, 45)
    Dim Cor_03 As Color = Color.FromArgb(255, 125, 45)
    Dim Cor_04 As Color = Color.FromArgb(255, 168, 45)
    Dim Cor_05 As Color = Color.FromArgb(255, 210, 45)
    Dim Cor_06 As Color = Color.FromArgb(255, 233, 45)
    Dim Cor_07 As Color = Color.FromArgb(255, 245, 45)
    Dim Cor_08 As Color = Color.FromArgb(255, 250, 45)
    Dim Cor_09 As Color = Color.FromArgb(225, 255, 45)
    Dim Cor_10 As Color = Color.FromArgb(185, 255, 45)
    Dim Cor_11 As Color = Color.FromArgb(145, 255, 45)
    Dim Cor_12 As Color = Color.FromArgb(95, 255, 78)
    Dim Cor_13 As Color = Color.FromArgb(45, 255, 110)
    Dim Cor_14 As Color = Color.FromArgb(45, 255, 153)
    Dim Cor_15 As Color = Color.FromArgb(45, 255, 195)
    Dim Cor_16 As Color = Color.FromArgb(45, 247, 225)
    Dim Cor_17 As Color = Color.FromArgb(45, 240, 255)
    Dim Cor_18 As Color = Color.FromArgb(45, 200, 255)
    Dim Cor_19 As Color = Color.FromArgb(45, 160, 255)
    Dim Cor_20 As Color = Color.FromArgb(45, 140, 255)
    Dim Cor_21 As Color = Color.FromArgb(45, 80, 255)
    Dim Cor_22 As Color = Color.FromArgb(45, 60, 255)
    Dim Cor_23 As Color = Color.FromArgb(45, 40, 255) 'Azul
#End Region

    Private Tolerancia As Double = 0.00001 'Define a tolerância de análise da função PontoNoTriangulo()
    Private ToleranciaAoQuadrado As Double = Tolerancia * Tolerancia

    Private minX, maxX, minY, maxY, Denominador, a, b, c, Distancia_P1_P2_AoQuadrado, Distancia_P_P1_AoQuadrado, ProdutoEscalar As Double

    Dim TempoDeProcessamento As Stopwatch

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        EditarMalha.Show()
    End Sub

    Public Function PreProcessamento() As Boolean

        'Try

        Maior_X = 0.0
        Maior_Y = 0.0
        Maior_Temperatura = -100000.0
        Menor_Temperatura = 100000.0

        '--------- Criação das Matrizes de Elementos, de Coordenadas dos Nós e de Linhas de Contorno

        Dim QuantidadeDeElementos As Integer = 0
        Dim QuantidadeDeNos As Integer = 0
        'Dim QuantidadeDeCondicoesDeContorno As Integer = 0

        For Each linha In TextBox1.Lines
            If linha.Contains(" | ") Then QuantidadeDeElementos += 1
        Next
        For Each linha In TextBox2.Lines
            If linha.Contains(" | ") Then QuantidadeDeNos += 1
        Next
        'For Each linha In TextBox3.Lines
        '    If linha.Contains(" | ") Then QuantidadeDeCondicoesDeContorno += 1
        'Next

        MatrizDeElementos = New DenseMatrix(3, QuantidadeDeElementos)
        MatrizDeCoordenadasDosNos = New DenseMatrix(2, QuantidadeDeNos)
        MatrizDeParametros_CC1.Clear()
        MatrizDeParametros_CC2.Clear()
        MatrizDeParametros_CC3.Clear()
        MatrizDeParametros_CC4.Clear()
        MatrizDeParametros_CC5.Clear()

        Dim contador As Integer = 0
        For Each linha In TextBox1.Lines
            If linha.Contains(" | ") Then
                Dim Partes() As String = Split(linha, " | ")
                MatrizDeElementos(0, contador) = Partes(1)
                MatrizDeElementos(1, contador) = Partes(2)
                MatrizDeElementos(2, contador) = Partes(3)
                contador += 1
            End If
        Next
        contador = 0
        For Each linha In TextBox2.Lines
            If linha.Contains(" | ") Then
                Dim Partes() As String = Split(linha, " | ")
                MatrizDeCoordenadasDosNos(0, contador) = CDbl(Partes(1))
                MatrizDeCoordenadasDosNos(1, contador) = CDbl(Partes(2))
                If Maior_X < CDbl(Partes(1)) Then Maior_X = CDbl(Partes(1))
                If Maior_Y < CDbl(Partes(2)) Then Maior_Y = CDbl(Partes(2))
                contador += 1
            End If
        Next
        contador = 0
        For Each linha In TextBox3.Lines
            If linha.Contains(" | ") Then
                Dim Partes() As String = Split(linha, " | ")
                Select Case Partes(0)
                    Case "1" 'Dirichlet (Temp. Prescrita)
                        MatrizDeParametros_CC1.Add({Partes(1), Partes(2)}) 'Nó, Temperatura
                    Case "2" 'Neumann (Fluxo de Calor Prescrito)
                        MatrizDeParametros_CC2.Add({Partes(1), Partes(2), Partes(3)}) 'Nó 1, Nó 2, Fluxo
                    Case "3" 'Robin (Temp. e Fluxo prescritos)
                        MatrizDeParametros_CC3.Add({Partes(1), Partes(2), Partes(3), Partes(4)}) 'Nó 1, Nó 2, Coef. de Convecção, Temp. do Fluido
                    Case "4" 'Geração de Calor Uniforme
                        MatrizDeParametros_CC4.Add({Partes(1), Partes(2)}) 'Elemento, Taxa de Geração
                    Case "5" 'Geração de Calor Pontual
                        MatrizDeParametros_CC5.Add({Partes(1), Partes(2), Partes(3)}) 'Posição X, Posição Y, Taxa de Geração
                End Select
                contador += 1
            End If
        Next

        '--------- Cálculo das Funções de Forma e Criação da Matriz de Condutividade (K)

        MatrizDePropriedadesGeometricas = New DenseMatrix(QuantidadeDeNos, QuantidadeDeNos)

        MatrizDeFuncoesDeForma = New DenseMatrix(10, QuantidadeDeElementos)

        Dim Check_1 As Integer = 0

        Dim dx, dy, ComprimentoDaLinha As Double

        Dim a_1, a_2, a_3, b_1, b_2, b_3, c_1, c_2, c_3 As Double 'Variáveis auxiliares para cálculo das funções de forma
        Dim x(2), y(2) As Double 'Guardam as coordenadas x e y de cada um dos 3 nós de um elemento
        Dim AreaVezesDois As Double

        VetorDeTemperaturas = New DenseMatrix(QuantidadeDeNos, 1)

        MatrizDeRigidez_Termo_1 = New DenseMatrix(3, 3)
        MatrizDeRigidez_Termo_2 = New DenseMatrix(3, 3)
        VetorDeCoeficientes_Termo_1 = New DenseMatrix(3, 1)
        VetorDeCoeficientes_Termo_2 = New DenseMatrix(3, 1)
        VetorDeCoeficientes_Termo_3 = New DenseMatrix(3, 1)

        Dim Espessura As Double = 1.0
        Dim CondutividadeXY As Double = 2.0

        For i_Elemento = 0 To QuantidadeDeElementos - 1
            For i_No = 0 To 2
                x(i_No) = MatrizDeCoordenadasDosNos(0, MatrizDeElementos(i_No, i_Elemento) - 1)
                y(i_No) = MatrizDeCoordenadasDosNos(1, MatrizDeElementos(i_No, i_Elemento) - 1)
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

            MatrizDeRigidez_Termo_1(0, 0) = CondutividadeXY * Espessura * ((b_1 ^ 2) + (c_1 ^ 2)) / (2 * AreaVezesDois)
            MatrizDeRigidez_Termo_1(0, 1) = CondutividadeXY * Espessura * ((b_1 * b_2) + (c_1 * c_2)) / (2 * AreaVezesDois)
            MatrizDeRigidez_Termo_1(0, 2) = CondutividadeXY * Espessura * ((b_1 * b_3) + (c_1 * c_3)) / (2 * AreaVezesDois)
            MatrizDeRigidez_Termo_1(1, 0) = CondutividadeXY * Espessura * ((b_1 * b_2) + (c_1 * c_2)) / (2 * AreaVezesDois)
            MatrizDeRigidez_Termo_1(1, 1) = CondutividadeXY * Espessura * ((b_2 ^ 2) + (c_2 ^ 2)) / (2 * AreaVezesDois)
            MatrizDeRigidez_Termo_1(1, 2) = CondutividadeXY * Espessura * ((b_2 * b_3) + (c_2 * c_3)) / (2 * AreaVezesDois)
            MatrizDeRigidez_Termo_1(2, 0) = CondutividadeXY * Espessura * ((b_1 * b_3) + (c_1 * c_3)) / (2 * AreaVezesDois)
            MatrizDeRigidez_Termo_1(2, 1) = CondutividadeXY * Espessura * ((b_2 * b_3) + (c_2 * c_3)) / (2 * AreaVezesDois)
            MatrizDeRigidez_Termo_1(2, 2) = CondutividadeXY * Espessura * ((b_3 ^ 2) + (c_3 ^ 2)) / (2 * AreaVezesDois)

            For Each CC In MatrizDeParametros_CC2 'Neumann
                Check_1 = 0
                For i_No = 0 To 2
                    If MatrizDeElementos(i_No, i_Elemento) = CC(0) OrElse MatrizDeElementos(i_No, i_Elemento) = CC(1) Then Check_1 += i_No + 2
                Next
                If Check_1 >= 5 Then
                    dx = MatrizDeCoordenadasDosNos(0, CC(0) - 1) - MatrizDeCoordenadasDosNos(0, CC(1) - 1) 'Comprimento da linha em X
                    dy = MatrizDeCoordenadasDosNos(1, CC(0) - 1) - MatrizDeCoordenadasDosNos(1, CC(1) - 1) 'Comprimento da linha em Y
                    ComprimentoDaLinha = Math.Sqrt((dx ^ 2) + (dy ^ 2))
                    Select Case Check_1
                        Case 5 'i - j
                            VetorDeCoeficientes_Termo_2(0, 0) = (CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 2
                            VetorDeCoeficientes_Termo_2(1, 0) = (CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 2
                            VetorDeCoeficientes_Termo_2(2, 0) = 0
                        Case 7 'j - k
                            VetorDeCoeficientes_Termo_2(0, 0) = 0
                            VetorDeCoeficientes_Termo_2(1, 0) = (CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 2
                            VetorDeCoeficientes_Termo_2(2, 0) = (CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 2
                        Case 6 'i - k
                            VetorDeCoeficientes_Termo_2(0, 0) = (CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 2
                            VetorDeCoeficientes_Termo_2(1, 0) = 0
                            VetorDeCoeficientes_Termo_2(2, 0) = (CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 2
                    End Select
                End If
            Next

            For Each CC In MatrizDeParametros_CC3 'Robin
                Check_1 = 0
                For i_No = 0 To 2
                    If MatrizDeElementos(i_No, i_Elemento) = CC(0) OrElse MatrizDeElementos(i_No, i_Elemento) = CC(1) Then Check_1 += i_No + 2
                Next
                If Check_1 >= 5 Then
                    dx = MatrizDeCoordenadasDosNos(0, CC(0) - 1) - MatrizDeCoordenadasDosNos(0, CC(1) - 1) 'Comprimento da linha em X
                    dy = MatrizDeCoordenadasDosNos(1, CC(0) - 1) - MatrizDeCoordenadasDosNos(1, CC(1) - 1) 'Comprimento da linha em Y
                    ComprimentoDaLinha = Math.Sqrt((dx ^ 2) + (dy ^ 2))
                    Select Case Check_1
                        Case 5 'i - j
                            MatrizDeRigidez_Termo_2(0, 0) = ((CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 6) * 2
                            MatrizDeRigidez_Termo_2(0, 1) = ((CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 6)
                            MatrizDeRigidez_Termo_2(0, 2) = 0
                            MatrizDeRigidez_Termo_2(1, 0) = ((CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 6)
                            MatrizDeRigidez_Termo_2(1, 1) = ((CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 6) * 2
                            MatrizDeRigidez_Termo_2(1, 2) = 0
                            MatrizDeRigidez_Termo_2(2, 0) = 0
                            MatrizDeRigidez_Termo_2(2, 1) = 0
                            MatrizDeRigidez_Termo_2(2, 2) = 0
                            VetorDeCoeficientes_Termo_3(0, 0) = (CDbl(CC(2)) * CDbl(CC(3)) * Espessura * ComprimentoDaLinha) / 2
                            VetorDeCoeficientes_Termo_3(1, 0) = (CDbl(CC(2)) * CDbl(CC(3)) * Espessura * ComprimentoDaLinha) / 2
                            VetorDeCoeficientes_Termo_3(2, 0) = 0
                        Case 7 'j - k
                            MatrizDeRigidez_Termo_2(0, 0) = 0
                            MatrizDeRigidez_Termo_2(0, 1) = 0
                            MatrizDeRigidez_Termo_2(0, 2) = 0
                            MatrizDeRigidez_Termo_2(1, 0) = 0
                            MatrizDeRigidez_Termo_2(1, 1) = ((CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 6) * 2
                            MatrizDeRigidez_Termo_2(1, 2) = ((CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 6)
                            MatrizDeRigidez_Termo_2(2, 0) = 0
                            MatrizDeRigidez_Termo_2(2, 1) = ((CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 6)
                            MatrizDeRigidez_Termo_2(2, 2) = ((CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 6) * 2
                            VetorDeCoeficientes_Termo_3(0, 0) = 0
                            VetorDeCoeficientes_Termo_3(1, 0) = (CDbl(CC(2)) * CDbl(CC(3)) * Espessura * ComprimentoDaLinha) / 2
                            VetorDeCoeficientes_Termo_3(2, 0) = (CDbl(CC(2)) * CDbl(CC(3)) * Espessura * ComprimentoDaLinha) / 2
                        Case 6 'i - k
                            MatrizDeRigidez_Termo_2(0, 0) = ((CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 6) * 2
                            MatrizDeRigidez_Termo_2(0, 1) = 0
                            MatrizDeRigidez_Termo_2(0, 2) = ((CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 6)
                            MatrizDeRigidez_Termo_2(1, 0) = 0
                            MatrizDeRigidez_Termo_2(1, 1) = 0
                            MatrizDeRigidez_Termo_2(1, 2) = 0
                            MatrizDeRigidez_Termo_2(2, 0) = ((CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 6)
                            MatrizDeRigidez_Termo_2(2, 1) = 0
                            MatrizDeRigidez_Termo_2(2, 2) = ((CDbl(CC(2)) * Espessura * ComprimentoDaLinha) / 6) * 2
                            VetorDeCoeficientes_Termo_3(0, 0) = (CDbl(CC(2)) * CDbl(CC(3)) * Espessura * ComprimentoDaLinha) / 2
                            VetorDeCoeficientes_Termo_3(1, 0) = 0
                            VetorDeCoeficientes_Termo_3(2, 0) = (CDbl(CC(2)) * CDbl(CC(3)) * Espessura * ComprimentoDaLinha) / 2
                    End Select
                End If
            Next

            For Each CC In MatrizDeParametros_CC4 'Geração de Calor Uniforme
                If CC(0) = i_Elemento + 1 Then
                    VetorDeCoeficientes_Termo_1(0, 0) = (CDbl(CC(1)) * Espessura * (AreaVezesDois / 2)) / 3
                    VetorDeCoeficientes_Termo_1(1, 0) = (CDbl(CC(1)) * Espessura * (AreaVezesDois / 2)) / 3
                    VetorDeCoeficientes_Termo_1(2, 0) = (CDbl(CC(1)) * Espessura * (AreaVezesDois / 2)) / 3
                End If
            Next

            For Each CC In MatrizDeParametros_CC5 'Geração de Calor Pontual

            Next

            'MsgBox(MatrizDeRigidez_Termo_1.Add(MatrizDeRigidez_Termo_2).ToString)

            MatrizDePropriedadesGeometricas(MatrizDeElementos(0, i_Elemento) - 1, MatrizDeElementos(0, i_Elemento) - 1) += MatrizDeRigidez_Termo_1(0, 0) + MatrizDeRigidez_Termo_2(0, 0)
            MatrizDePropriedadesGeometricas(MatrizDeElementos(0, i_Elemento) - 1, MatrizDeElementos(1, i_Elemento) - 1) += MatrizDeRigidez_Termo_1(0, 1) + MatrizDeRigidez_Termo_2(0, 1)
            MatrizDePropriedadesGeometricas(MatrizDeElementos(0, i_Elemento) - 1, MatrizDeElementos(2, i_Elemento) - 1) += MatrizDeRigidez_Termo_1(0, 2) + MatrizDeRigidez_Termo_2(0, 2)
            MatrizDePropriedadesGeometricas(MatrizDeElementos(1, i_Elemento) - 1, MatrizDeElementos(0, i_Elemento) - 1) += MatrizDeRigidez_Termo_1(1, 0) + MatrizDeRigidez_Termo_2(1, 0)
            MatrizDePropriedadesGeometricas(MatrizDeElementos(1, i_Elemento) - 1, MatrizDeElementos(1, i_Elemento) - 1) += MatrizDeRigidez_Termo_1(1, 1) + MatrizDeRigidez_Termo_2(1, 1)
            MatrizDePropriedadesGeometricas(MatrizDeElementos(1, i_Elemento) - 1, MatrizDeElementos(2, i_Elemento) - 1) += MatrizDeRigidez_Termo_1(1, 2) + MatrizDeRigidez_Termo_2(1, 2)
            MatrizDePropriedadesGeometricas(MatrizDeElementos(2, i_Elemento) - 1, MatrizDeElementos(0, i_Elemento) - 1) += MatrizDeRigidez_Termo_1(2, 0) + MatrizDeRigidez_Termo_2(2, 0)
            MatrizDePropriedadesGeometricas(MatrizDeElementos(2, i_Elemento) - 1, MatrizDeElementos(1, i_Elemento) - 1) += MatrizDeRigidez_Termo_1(2, 1) + MatrizDeRigidez_Termo_2(2, 1)
            MatrizDePropriedadesGeometricas(MatrizDeElementos(2, i_Elemento) - 1, MatrizDeElementos(2, i_Elemento) - 1) += MatrizDeRigidez_Termo_1(2, 2) + MatrizDeRigidez_Termo_2(2, 2)

            VetorDeTemperaturas(MatrizDeElementos(0, i_Elemento) - 1, 0) = VetorDeCoeficientes_Termo_1(0, 0) - VetorDeCoeficientes_Termo_2(0, 0) + VetorDeCoeficientes_Termo_3(0, 0)
            VetorDeTemperaturas(MatrizDeElementos(1, i_Elemento) - 1, 0) = VetorDeCoeficientes_Termo_1(1, 0) - VetorDeCoeficientes_Termo_2(1, 0) + VetorDeCoeficientes_Termo_3(1, 0)
            VetorDeTemperaturas(MatrizDeElementos(2, i_Elemento) - 1, 0) = VetorDeCoeficientes_Termo_1(2, 0) - VetorDeCoeficientes_Termo_2(2, 0) + VetorDeCoeficientes_Termo_3(2, 0)

            For Each CC In MatrizDeParametros_CC1 'Dirichlet (sobrepõe outras condições de contorno!)
                For i_No = 0 To 2
                    If MatrizDeElementos(i_No, i_Elemento) = CC(0) Then
                        VetorDeTemperaturas(MatrizDeElementos(i_No, i_Elemento) - 1, 0) = CC(1)
                        For i = 0 To QuantidadeDeNos - 1
                            MatrizDePropriedadesGeometricas(MatrizDeElementos(i_No, i_Elemento) - 1, i) = 0
                        Next
                        MatrizDePropriedadesGeometricas(MatrizDeElementos(i_No, i_Elemento) - 1, MatrizDeElementos(i_No, i_Elemento) - 1) = 1
                    End If
                Next
            Next

        Next

        'MsgBox(MatrizDePropriedadesGeometricas.ToString)

        '--------- Definição das Propriedades Geométricas dos Elementos de Contorno

        'MatrizDePropriedadesGeometricasDeContorno = New DenseMatrix(3, QuantidadeDeLinhasDeContorno)

        'For i_LinhaDeContorno = 0 To QuantidadeDeLinhasDeContorno - 1
        '    dx = MatrizDeCoordenadasDosNos(0, MatrizDeLinhasDeContorno(1, i_LinhaDeContorno) - 1) - MatrizDeCoordenadasDosNos(0, MatrizDeLinhasDeContorno(0, i_LinhaDeContorno) - 1) 'Comprimento da linha em X
        '    dy = MatrizDeCoordenadasDosNos(1, MatrizDeLinhasDeContorno(1, i_LinhaDeContorno) - 1) - MatrizDeCoordenadasDosNos(1, MatrizDeLinhasDeContorno(0, i_LinhaDeContorno) - 1) 'Comprimento da linha em Y
        '    ComprimentoDaLinha = Math.Sqrt((dx ^ 2) + (dy ^ 2))
        '    MatrizDePropriedadesGeometricasDeContorno(0, i_LinhaDeContorno) = dy / ComprimentoDaLinha
        '    MatrizDePropriedadesGeometricasDeContorno(1, i_LinhaDeContorno) = -dx / ComprimentoDaLinha
        '    MatrizDePropriedadesGeometricasDeContorno(2, i_LinhaDeContorno) = ComprimentoDaLinha
        'Next

        VetorDeTemperaturas = MatrizDePropriedadesGeometricas.Inverse.Multiply(VetorDeTemperaturas)

        For i = 0 To VetorDeTemperaturas.RowCount - 1
            If VetorDeTemperaturas(i, 0) < Menor_Temperatura Then Menor_Temperatura = VetorDeTemperaturas(i, 0)
            If VetorDeTemperaturas(i, 0) > Maior_Temperatura Then Maior_Temperatura = VetorDeTemperaturas(i, 0)
        Next

        Return True
        'MsgBox(Temperaturas.ToString)

        '--------- Fim do Pré-Processamento
        'MsgBox(MatrizDePropriedadesGeometricas.ToString)

        'Catch ex As Exception
        '    MsgBox("Ocorreu um erro.", MsgBoxStyle.Critical)
        '    Return False
        'End Try

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TempoDeProcessamento = Stopwatch.StartNew()
        Dim Sucesso As Boolean = PreProcessamento()
        TempoDeProcessamento.Stop()
        If Sucesso Then MsgBox("Pré-Processamento concluído em " & TempoDeProcessamento.Elapsed.TotalMilliseconds.ToString & " milissegundos.", MsgBoxStyle.Information)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim NumeroDoNo As Integer = CDbl(InputBox("Digite o número do nó:"))
            MsgBox("Temperatura no nó " & CStr(NumeroDoNo) & ":" & vbNewLine & vbNewLine & VetorDeTemperaturas(NumeroDoNo - 1, 0).ToString, MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Digite um número de nó válido!", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If OpenFileDialog1.ShowDialog = 1 Then
            Try
                Dim texto As String = ReadAllText(OpenFileDialog1.FileName)
                Dim partes() As String = Split(texto, vbNewLine & vbNewLine)
                TextBox1.Text = partes(0)
                TextBox2.Text = partes(1)
                TextBox3.Text = partes(2)
            Catch ex As Exception
                MsgBox("Ocorreu um erro.", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Button4.Tag = False Then
            DesenharMalha(True)
            Button4.Text = "Ocultar Malha"
            Button4.Tag = True
        Else
            DesenharMalha(False)
            Button4.Text = "Mostrar Malha"
            Button4.Tag = False
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        'PictureBox1.Image.Save("C:\Users\gustavo.crovador\Desktop\Resultado.png", Imaging.ImageFormat.Png)
    End Sub

    'Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
    '    Try

    '        Dim Ttopo As Double = 500.0 'Temperatura do topo
    '        Dim Tlado As Double = 100.0 'Temperatura dos lados
    '        Dim w As Double = 1.0 'Largura
    '        Dim H As Double = 1.0 'Altura
    '        Dim PosX As Double = 0.5 'Posição X na qual se deseja obter a temperatura
    '        Dim PosY As Double = 0.5 'Posição Y na qual se deseja obter a temperatura
    '        Dim IndiceFinal As Integer = CInt(TextBox6.Text) 'Limite superior do somatório
    '        Dim Somatorio As Double = 0.0 'Valor do termo referente ao somatório

    '        For n = 1 To IndiceFinal
    '            Somatorio += (((((-1) ^ (n + 1)) + 1) / n) * Math.Sin(n * Math.PI * PosX / w) * (Math.Sinh(n * Math.PI * PosY / w) / Math.Sinh(n * Math.PI * H / w)))
    '        Next

    '        Dim Resultado As Double = ((Ttopo - Tlado) * (2 / Math.PI) * Somatorio) + Tlado 'Resultado final

    '        Clipboard.SetText(Resultado.ToString)

    '    Catch ex As Exception
    '        MsgBox("Ocorreu um erro desconhecido!", MsgBoxStyle.Critical)
    '    End Try

    'End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Desenhar(RadioButton1.Checked, Button4.Tag)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MsgBox("Lista de condições de contorno disponíveis:" & vbNewLine & vbNewLine & "Dirichlet (Temp. Prescrita):" & vbNewLine & "1 | Nó | Temperatura Conhecida" & vbNewLine & vbNewLine & "Neumann (Fluxo de Calor Prescrito):" & vbNewLine & "2 | Nó 1 | Nó 2 | Fluxo (q" & ChrW(34) & ")" & vbNewLine & vbNewLine & "Robin (Temp. e Fluxo prescritos):" & vbNewLine & "3 | Nó 1 | Nó 2 | Coef. de convecção | Temp. Fluido" & vbNewLine & vbNewLine & "Geração de Calor Uniforme:" & vbNewLine & "4 | Elemento | Taxa de geração" & vbNewLine & vbNewLine & "Geração de Calor Pontual:" & vbNewLine & "5 | Posição X | Posição Y | Taxa de geração", MsgBoxStyle.Information)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button4.Tag = False
        ImagemProcessada.MakeTransparent()
        MalhaProcessada.MakeTransparent()
    End Sub

    Private Function DistanciaDoPontoAoSegmento_AoQuadrado(ByVal x1 As Double, y1 As Double, x2 As Double, y2 As Double, x As Double, y As Double) As Double
        Distancia_P1_P2_AoQuadrado = ((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1))
        ProdutoEscalar = (((x - x1) * (x2 - x1)) + ((y - y1) * (y2 - y1))) / Distancia_P1_P2_AoQuadrado
        If ProdutoEscalar < 0 Then
            Return (((x - x1) * (x - x1)) + ((y - y1) * (y - y1)))
        ElseIf ProdutoEscalar <= 1 Then
            Distancia_P_P1_AoQuadrado = ((x1 - x) * (x1 - x)) + ((y1 - y) * (y1 - y))
            Return (Distancia_P_P1_AoQuadrado - (ProdutoEscalar * ProdutoEscalar * Distancia_P1_P2_AoQuadrado))
        Else
            Return (((x - x2) * (x - x2)) + ((y - y2) * (y - y2)))
        End If
    End Function

    Public Function PontoNoTriangulo(ByVal Ponto() As Double, ByVal Triangulo As List(Of Double())) As Boolean
        minX = Math.Min(Triangulo(0)(0), Math.Min(Triangulo(1)(0), Triangulo(2)(0))) - Tolerancia
        maxX = Math.Max(Triangulo(0)(0), Math.Max(Triangulo(1)(0), Triangulo(2)(0))) + Tolerancia
        minY = Math.Min(Triangulo(0)(1), Math.Min(Triangulo(1)(1), Triangulo(2)(1))) - Tolerancia
        maxY = Math.Max(Triangulo(0)(1), Math.Max(Triangulo(1)(1), Triangulo(2)(1))) + Tolerancia

        If Ponto(0) < minX OrElse Ponto(0) > maxX OrElse Ponto(1) < minY OrElse Ponto(1) > maxY Then
            Return False
            Exit Function
        End If

        Denominador = ((Triangulo(1)(1) - Triangulo(2)(1)) * (Triangulo(0)(0) - Triangulo(2)(0))) + ((Triangulo(2)(0) - Triangulo(1)(0)) * (Triangulo(0)(1) - Triangulo(2)(1)))
        a = (((Triangulo(1)(1) - Triangulo(2)(1)) * (Ponto(0) - Triangulo(2)(0))) + ((Triangulo(2)(0) - Triangulo(1)(0)) * (Ponto(1) - Triangulo(2)(1)))) / Denominador
        b = (((Triangulo(2)(1) - Triangulo(0)(1)) * (Ponto(0) - Triangulo(2)(0))) + ((Triangulo(0)(0) - Triangulo(2)(0)) * (Ponto(1) - Triangulo(2)(1)))) / Denominador
        c = 1 - a - b

        If Not (a >= 0 AndAlso a <= 1 AndAlso b >= 0 AndAlso b <= 1 AndAlso c >= 0 AndAlso c <= 1) Then
            If DistanciaDoPontoAoSegmento_AoQuadrado(Triangulo(0)(0), Triangulo(0)(1), Triangulo(1)(0), Triangulo(1)(1), Ponto(0), Ponto(1)) <= ToleranciaAoQuadrado Then
                Return True
                Exit Function
            End If
            If DistanciaDoPontoAoSegmento_AoQuadrado(Triangulo(1)(0), Triangulo(1)(1), Triangulo(2)(0), Triangulo(2)(1), Ponto(0), Ponto(1)) <= ToleranciaAoQuadrado Then
                Return True
                Exit Function
            End If
            If DistanciaDoPontoAoSegmento_AoQuadrado(Triangulo(2)(0), Triangulo(2)(1), Triangulo(0)(0), Triangulo(0)(1), Ponto(0), Ponto(1)) <= ToleranciaAoQuadrado Then
                Return True
                Exit Function
            End If
        Else
            Return True
            Exit Function
        End If

        Return False

    End Function

    Private Function TemperaturaNaPosicao(ByVal Pos() As Double) As Double
        ' Determinar se ponto está dentro da área analisada
        Dim NumeroDoElemento As Integer = -1
        Dim Triangulo As New List(Of Double())
        For e = 0 To MatrizDeElementos.ColumnCount - 1
            Triangulo.Clear()
            Triangulo.Add({MatrizDeCoordenadasDosNos(0, MatrizDeElementos(0, e) - 1), MatrizDeCoordenadasDosNos(1, MatrizDeElementos(0, e) - 1)})
            Triangulo.Add({MatrizDeCoordenadasDosNos(0, MatrizDeElementos(1, e) - 1), MatrizDeCoordenadasDosNos(1, MatrizDeElementos(1, e) - 1)})
            Triangulo.Add({MatrizDeCoordenadasDosNos(0, MatrizDeElementos(2, e) - 1), MatrizDeCoordenadasDosNos(1, MatrizDeElementos(2, e) - 1)})
            If PontoNoTriangulo(Pos, Triangulo) = True Then
                NumeroDoElemento = e
                Exit For
            End If
        Next
        If NumeroDoElemento <> -1 Then
            Dim N_1, N_2, N_3, T_1, T_2, T_3 As Double
            N_1 = Math.Abs((MatrizDeFuncoesDeForma(0, NumeroDoElemento) + (MatrizDeFuncoesDeForma(3, NumeroDoElemento) * Pos(0)) + (MatrizDeFuncoesDeForma(6, NumeroDoElemento) * Pos(1))) / MatrizDeFuncoesDeForma(9, NumeroDoElemento))
            N_2 = Math.Abs((MatrizDeFuncoesDeForma(1, NumeroDoElemento) + (MatrizDeFuncoesDeForma(4, NumeroDoElemento) * Pos(0)) + (MatrizDeFuncoesDeForma(7, NumeroDoElemento) * Pos(1))) / MatrizDeFuncoesDeForma(9, NumeroDoElemento))
            N_3 = Math.Abs((MatrizDeFuncoesDeForma(2, NumeroDoElemento) + (MatrizDeFuncoesDeForma(5, NumeroDoElemento) * Pos(0)) + (MatrizDeFuncoesDeForma(8, NumeroDoElemento) * Pos(1))) / MatrizDeFuncoesDeForma(9, NumeroDoElemento))
            T_1 = VetorDeTemperaturas(MatrizDeElementos(0, NumeroDoElemento) - 1, 0)
            T_2 = VetorDeTemperaturas(MatrizDeElementos(1, NumeroDoElemento) - 1, 0)
            T_3 = VetorDeTemperaturas(MatrizDeElementos(2, NumeroDoElemento) - 1, 0)
            Dim TemperaturaPontual As Double = ((N_1 * T_1) + (N_2 * T_2) + (N_3 * T_3))
            Dim Temp_Max As Double = Math.Max(T_1, Math.Max(T_2, T_3))
            Dim Temp_Min As Double = Math.Min(T_1, Math.Min(T_2, T_3))
            If TemperaturaPontual > Temp_Max Then TemperaturaPontual = Temp_Max
            If TemperaturaPontual < Temp_Min Then TemperaturaPontual = Temp_Min
            Return TemperaturaPontual
        Else
            'MsgBox("O ponto indicado está fora da seção analisada!", MsgBoxStyle.Critical)
            Return -100000.0
        End If
    End Function

    Private Sub DesenharMalha(ByVal Desenhar As Boolean)

        MalhaProcessada = New Bitmap(Tamanho_X + 1, Tamanho_Y + 1)
        Dim g As Graphics = Graphics.FromImage(MalhaProcessada)
        g.DrawImage(ImagemProcessada, 0, 0)

        If Desenhar Then
            Dim Proporcao_X As Double = Tamanho_X / Maior_X
            Dim Proporcao_Y As Double = Tamanho_Y / Maior_Y
            Dim Proporcao_Geral As Double = Math.Min(Proporcao_X, Proporcao_Y)
            For i = 0 To MatrizDeElementos.ColumnCount - 1
                Dim NumeroDoNo_1 As Integer = MatrizDeElementos(0, i)
                Dim NumeroDoNo_2 As Integer = MatrizDeElementos(1, i)
                Dim NumeroDoNo_3 As Integer = MatrizDeElementos(2, i)
                Dim PosicaoDoNo_1() As Double = {CDbl(MatrizDeCoordenadasDosNos(0, NumeroDoNo_1 - 1)) * Proporcao_Geral, CDbl(MatrizDeCoordenadasDosNos(1, NumeroDoNo_1 - 1)) * Proporcao_Geral}
                Dim PosicaoDoNo_2() As Double = {CDbl(MatrizDeCoordenadasDosNos(0, NumeroDoNo_2 - 1)) * Proporcao_Geral, CDbl(MatrizDeCoordenadasDosNos(1, NumeroDoNo_2 - 1)) * Proporcao_Geral}
                Dim PosicaoDoNo_3() As Double = {CDbl(MatrizDeCoordenadasDosNos(0, NumeroDoNo_3 - 1)) * Proporcao_Geral, CDbl(MatrizDeCoordenadasDosNos(1, NumeroDoNo_3 - 1)) * Proporcao_Geral}
                Dim PontosDoTriangulo() As PointF = {New PointF(PosicaoDoNo_1(0), PosicaoDoNo_1(1)), New PointF(PosicaoDoNo_2(0), PosicaoDoNo_2(1)), New PointF(PosicaoDoNo_3(0), PosicaoDoNo_3(1))}
                g.DrawPolygon(New Pen(Color.Black, 1), PontosDoTriangulo)
            Next
        End If

        g.Dispose()
        Panel1.BackgroundImage = MalhaProcessada

    End Sub

    Private Sub Desenhar(ByVal Colorido As Boolean, ByVal MostrarMalha As Boolean)

        ImagemProcessada = New Bitmap(Tamanho_X + 1, Tamanho_Y + 1)

        Dim Proporcao_X As Double = Tamanho_X / Maior_X
        Dim Proporcao_Y As Double = Tamanho_Y / Maior_Y
        Dim Proporcao_Geral As Double = Math.Min(Proporcao_X, Proporcao_Y)

        tMin.Text = FormatNumber(Menor_Temperatura, 2, TriState.True, TriState.False, TriState.True)
        tMax.Text = FormatNumber(Maior_Temperatura, 2, TriState.True, TriState.False, TriState.True)

        If Colorido Then

            Dim GradienteGeral As New LinearGradientBrush(New Point(0, 0), New Point(500, 0), Cor_23, Cor_01)
            GradienteGeral.WrapMode = WrapMode.Tile
            Dim color_blend As New ColorBlend
            color_blend.Colors = New Color() {Cor_23, Cor_22, Cor_21, Cor_20, Cor_19, Cor_18, Cor_17, Cor_16, Cor_15, Cor_14, Cor_13, Cor_12, Cor_11, Cor_10, Cor_09, Cor_08, Cor_07, Cor_06, Cor_05, Cor_04, Cor_03, Cor_02, Cor_01}
            color_blend.Positions = New Single() {0.0, (1 / 22) * 1, (1 / 22) * 2, (1 / 22) * 3, (1 / 22) * 4, (1 / 22) * 5, (1 / 22) * 6, (1 / 22) * 7, (1 / 22) * 8, (1 / 22) * 9, (1 / 22) * 10, (1 / 22) * 11, (1 / 22) * 12, (1 / 22) * 13, (1 / 22) * 14, (1 / 22) * 15, (1 / 22) * 16, (1 / 22) * 17, (1 / 22) * 18, (1 / 22) * 19, (1 / 22) * 20, (1 / 22) * 21, 1.0}
            GradienteGeral.InterpolationColors = color_blend
            GradienteGeral.GammaCorrection = True
            Dim tmpbmp As New Bitmap(501, 31)
            Dim tmpcolorrec As Object = Graphics.FromImage(tmpbmp)
            tmpcolorrec.FillRectangle(GradienteGeral, 0, 0, 501, 31)
            PictureBox2.Image = tmpbmp

            Dim Escala As Integer = 0
            For x = 0 To Tamanho_X
                For y = 0 To Tamanho_Y
                    Dim TemperaturaNoPixel As Double = TemperaturaNaPosicao({x / Proporcao_Geral, y / Proporcao_Geral})
                    If Not TemperaturaNoPixel = -100000.0 Then
                        Escala = Math.Round(500 * (TemperaturaNoPixel - (Menor_Temperatura)) / (Maior_Temperatura - (Menor_Temperatura)), 0, MidpointRounding.ToEven)
                        If Escala <= 500 Then
                            ImagemProcessada.SetPixel(x, y, tmpbmp.GetPixel(Escala, 15))
                        End If
                        'Else
                        'bmp.SetPixel(x, y, Color.Transparent)
                    End If
                Next
            Next

        Else
            Dim tmpbmp As New Bitmap(501, 31)
            For x = 0 To 500
                For y = 0 To 30
                    If x = 0 Then
                        tmpbmp.SetPixel(x, y, Color.White)
                    ElseIf x = 500 Then
                        tmpbmp.SetPixel(x, y, Color.Black)
                    Else
                        tmpbmp.SetPixel(x, y, Color.FromArgb(Math.Round(256 / (500 / x), 0, MidpointRounding.ToEven), Color.Black))
                    End If
                Next
            Next
            PictureBox2.Image = tmpbmp

            Dim Proporcao_Temperatura As Double = 256 / Maior_Temperatura

            Dim Escala As Integer = 0
            For x = 0 To Tamanho_X
                For y = 0 To Tamanho_Y
                    Dim TemperaturaNoPixel As Double = TemperaturaNaPosicao({x / Proporcao_Geral, y / Proporcao_Geral})
                    If Not TemperaturaNoPixel = -100000.0 Then
                        Escala = Math.Round(256 * (TemperaturaNoPixel - (Menor_Temperatura)) / (Maior_Temperatura - (Menor_Temperatura)), 0, MidpointRounding.ToEven)
                        If Escala >= 256 Then
                            ImagemProcessada.SetPixel(x, y, Color.Black)
                        Else
                            ImagemProcessada.SetPixel(x, y, Color.FromArgb(Escala, Color.Black))
                        End If
                        'Else
                        'bmp.SetPixel(x, y, Color.Transparent)
                    End If
                Next
            Next

        End If

        DesenharMalha(MostrarMalha)

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            MsgBox("Temperatura: " & CStr(TemperaturaNaPosicao(CType({CDbl(TextBox5.Text), CDbl(TextBox4.Text)}, Double()))))
        Catch ex As Exception
            MsgBox("Erro!", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Dim Proporcao_X As Double = (ImagemProcessada.Width - 1) / Maior_X
            Dim Proporcao_Y As Double = (ImagemProcessada.Height - 1) / Maior_Y
            Dim Proporcao_Geral As Double = Math.Min(Proporcao_X, Proporcao_Y)
            Dim Pixel_X As Integer = Math.Round(CDbl(TextBox5.Text) * Proporcao_Geral, 0, MidpointRounding.ToEven)
            Dim Pixel_Y As Integer = Math.Round(CDbl(TextBox4.Text) * Proporcao_Geral, 0, MidpointRounding.ToEven)
            MsgBox("R: " & ImagemProcessada.GetPixel(Pixel_X, Pixel_Y).R.ToString & vbNewLine & "G: " & ImagemProcessada.GetPixel(Pixel_X, Pixel_Y).G.ToString & vbNewLine & "B: " & ImagemProcessada.GetPixel(Pixel_X, Pixel_Y).B.ToString & vbNewLine & "A: " & ImagemProcessada.GetPixel(Pixel_X, Pixel_Y).A.ToString)
        Catch ex As Exception
            MsgBox("Erro!", MsgBoxStyle.Critical)
        End Try
    End Sub

End Class
