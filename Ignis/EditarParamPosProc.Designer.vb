<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarParamPosProc
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cTipoExib = New System.Windows.Forms.ComboBox()
        Me.cEsqCores = New System.Windows.Forms.ComboBox()
        Me.lEsquema = New System.Windows.Forms.Label()
        Me.lPasso = New System.Windows.Forms.Label()
        Me.lUT = New System.Windows.Forms.Label()
        Me.bAceitar = New MeshExplorer.Controls.DarkButton()
        Me.tPasso = New Ignis.NumericUpDownEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cTamanho = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.tPasso, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(12, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(344, 17)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Definição dos parâmetros de pós-processamento:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(12, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(344, 54)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Nesta janela, definem-se as configurações de pós-processamento referentes à exibi" &
    "ção dos resultados da simulação em forma gráfica."
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(12, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(178, 17)
        Me.Label5.TabIndex = 38
        Me.Label5.Text = "Tipo de visualização:"
        '
        'cTipoExib
        '
        Me.cTipoExib.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cTipoExib.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cTipoExib.FormattingEnabled = True
        Me.cTipoExib.Items.AddRange(New Object() {"Gradiente de Temperaturas", "Linhas Isotérmicas"})
        Me.cTipoExib.Location = New System.Drawing.Point(15, 113)
        Me.cTipoExib.Name = "cTipoExib"
        Me.cTipoExib.Size = New System.Drawing.Size(175, 23)
        Me.cTipoExib.TabIndex = 39
        '
        'cEsqCores
        '
        Me.cEsqCores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cEsqCores.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cEsqCores.FormattingEnabled = True
        Me.cEsqCores.Items.AddRange(New Object() {"Colorido", "Escala de Cinza"})
        Me.cEsqCores.Location = New System.Drawing.Point(201, 113)
        Me.cEsqCores.Name = "cEsqCores"
        Me.cEsqCores.Size = New System.Drawing.Size(155, 23)
        Me.cEsqCores.TabIndex = 41
        '
        'lEsquema
        '
        Me.lEsquema.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lEsquema.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lEsquema.Location = New System.Drawing.Point(198, 93)
        Me.lEsquema.Name = "lEsquema"
        Me.lEsquema.Size = New System.Drawing.Size(158, 17)
        Me.lEsquema.TabIndex = 40
        Me.lEsquema.Text = "Esquema de cores:"
        '
        'lPasso
        '
        Me.lPasso.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lPasso.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lPasso.Location = New System.Drawing.Point(198, 93)
        Me.lPasso.Name = "lPasso"
        Me.lPasso.Size = New System.Drawing.Size(158, 17)
        Me.lPasso.TabIndex = 42
        Me.lPasso.Text = "Passo entre isotermas:"
        Me.lPasso.Visible = False
        '
        'lUT
        '
        Me.lUT.AutoSize = True
        Me.lUT.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lUT.ForeColor = System.Drawing.Color.Silver
        Me.lUT.Location = New System.Drawing.Point(303, 117)
        Me.lUT.Name = "lUT"
        Me.lUT.Size = New System.Drawing.Size(31, 15)
        Me.lUT.TabIndex = 44
        Me.lUT.Text = "U. T."
        Me.ToolTip1.SetToolTip(Me.lUT, "Unidades de Temperatura")
        Me.lUT.Visible = False
        '
        'bAceitar
        '
        Me.bAceitar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAceitar.Location = New System.Drawing.Point(15, 209)
        Me.bAceitar.Name = "bAceitar"
        Me.bAceitar.Size = New System.Drawing.Size(341, 27)
        Me.bAceitar.TabIndex = 45
        Me.bAceitar.Text = "Aceitar e Sair"
        Me.bAceitar.UseVisualStyleBackColor = True
        '
        'tPasso
        '
        Me.tPasso.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPasso.InterceptMouseWheel = Ignis.NumericUpDownEx.InterceptMouseWheelMode.Never
        Me.tPasso.Location = New System.Drawing.Point(201, 113)
        Me.tPasso.Maximum = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.tPasso.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.tPasso.Name = "tPasso"
        Me.tPasso.ShowUpDownButtons = Ignis.NumericUpDownEx.ShowUpDownButtonsMode.Never
        Me.tPasso.Size = New System.Drawing.Size(97, 23)
        Me.tPasso.TabIndex = 43
        Me.tPasso.Value = New Decimal(New Integer() {1, 0, 0, 0})
        Me.tPasso.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(12, 148)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(344, 17)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Tamanho da imagem, em pixels:"
        '
        'cTamanho
        '
        Me.cTamanho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cTamanho.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cTamanho.FormattingEnabled = True
        Me.cTamanho.Items.AddRange(New Object() {"500 x 500 (1x)", "1000 x 1000 (2x)", "1500 x 1500 (3x)", "2000 x 2000 (4x)"})
        Me.cTamanho.Location = New System.Drawing.Point(15, 168)
        Me.cTamanho.Name = "cTamanho"
        Me.cTamanho.Size = New System.Drawing.Size(175, 23)
        Me.cTamanho.TabIndex = 47
        '
        'EditarParamPosProc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(368, 248)
        Me.Controls.Add(Me.cTamanho)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bAceitar)
        Me.Controls.Add(Me.lUT)
        Me.Controls.Add(Me.tPasso)
        Me.Controls.Add(Me.cEsqCores)
        Me.Controls.Add(Me.cTipoExib)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lPasso)
        Me.Controls.Add(Me.lEsquema)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditarParamPosProc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Editar Parâmetros de Pós-Processamento"
        CType(Me.tPasso, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cTipoExib As ComboBox
    Friend WithEvents cEsqCores As ComboBox
    Friend WithEvents lEsquema As Label
    Friend WithEvents lPasso As Label
    Friend WithEvents tPasso As NumericUpDownEx
    Friend WithEvents lUT As Label
    Private WithEvents bAceitar As MeshExplorer.Controls.DarkButton
    Friend WithEvents Label1 As Label
    Friend WithEvents cTamanho As ComboBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
