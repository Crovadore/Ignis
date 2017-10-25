<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarPropFis
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarPropFis))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tEspessura = New Ignis.NumericUpDownEx()
        Me.tMassaEspecifica = New Ignis.NumericUpDownEx()
        Me.tCondutividade = New Ignis.NumericUpDownEx()
        Me.bAceitar = New MeshExplorer.Controls.DarkButton()
        Me.tGeracao = New Ignis.NumericUpDownEx()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tCalorEspecifico = New Ignis.NumericUpDownEx()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.tEspessura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tMassaEspecifica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tCondutividade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tGeracao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tCalorEspecifico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(174, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 17)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Condutiv. Térmica (k):"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(174, 198)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 17)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Massa Específica:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(12, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(290, 17)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Definição das propriedades físicas do problema:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(12, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(290, 97)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = resources.GetString("Label4.Text")
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(12, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 17)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Espessura do corpo:"
        '
        'tEspessura
        '
        Me.tEspessura.DecimalPlaces = 4
        Me.tEspessura.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tEspessura.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.tEspessura.InterceptMouseWheel = Ignis.NumericUpDownEx.InterceptMouseWheelMode.Never
        Me.tEspessura.Location = New System.Drawing.Point(15, 157)
        Me.tEspessura.Maximum = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.tEspessura.Name = "tEspessura"
        Me.tEspessura.ShowUpDownButtons = Ignis.NumericUpDownEx.ShowUpDownButtonsMode.Never
        Me.tEspessura.Size = New System.Drawing.Size(125, 23)
        Me.tEspessura.TabIndex = 36
        '
        'tMassaEspecifica
        '
        Me.tMassaEspecifica.DecimalPlaces = 4
        Me.tMassaEspecifica.Enabled = False
        Me.tMassaEspecifica.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tMassaEspecifica.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.tMassaEspecifica.InterceptMouseWheel = Ignis.NumericUpDownEx.InterceptMouseWheelMode.Never
        Me.tMassaEspecifica.Location = New System.Drawing.Point(177, 219)
        Me.tMassaEspecifica.Maximum = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.tMassaEspecifica.Name = "tMassaEspecifica"
        Me.tMassaEspecifica.ShowUpDownButtons = Ignis.NumericUpDownEx.ShowUpDownButtonsMode.Never
        Me.tMassaEspecifica.Size = New System.Drawing.Size(125, 23)
        Me.tMassaEspecifica.TabIndex = 37
        Me.tMassaEspecifica.Value = New Decimal(New Integer() {1, 0, 0, 327680})
        '
        'tCondutividade
        '
        Me.tCondutividade.DecimalPlaces = 4
        Me.tCondutividade.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCondutividade.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.tCondutividade.InterceptMouseWheel = Ignis.NumericUpDownEx.InterceptMouseWheelMode.Never
        Me.tCondutividade.Location = New System.Drawing.Point(177, 157)
        Me.tCondutividade.Maximum = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.tCondutividade.Name = "tCondutividade"
        Me.tCondutividade.ShowUpDownButtons = Ignis.NumericUpDownEx.ShowUpDownButtonsMode.Never
        Me.tCondutividade.Size = New System.Drawing.Size(125, 23)
        Me.tCondutividade.TabIndex = 38
        '
        'bAceitar
        '
        Me.bAceitar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAceitar.Location = New System.Drawing.Point(15, 326)
        Me.bAceitar.Name = "bAceitar"
        Me.bAceitar.Size = New System.Drawing.Size(287, 27)
        Me.bAceitar.TabIndex = 35
        Me.bAceitar.Text = "Aceitar e Sair"
        Me.bAceitar.UseVisualStyleBackColor = True
        '
        'tGeracao
        '
        Me.tGeracao.DecimalPlaces = 4
        Me.tGeracao.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tGeracao.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.tGeracao.InterceptMouseWheel = Ignis.NumericUpDownEx.InterceptMouseWheelMode.Never
        Me.tGeracao.Location = New System.Drawing.Point(15, 219)
        Me.tGeracao.Maximum = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.tGeracao.Name = "tGeracao"
        Me.tGeracao.ShowUpDownButtons = Ignis.NumericUpDownEx.ShowUpDownButtonsMode.Never
        Me.tGeracao.Size = New System.Drawing.Size(125, 23)
        Me.tGeracao.TabIndex = 40
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Location = New System.Drawing.Point(12, 199)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 17)
        Me.Label6.TabIndex = 39
        Me.Label6.Text = "Geração de Calor:"
        '
        'tCalorEspecifico
        '
        Me.tCalorEspecifico.DecimalPlaces = 4
        Me.tCalorEspecifico.Enabled = False
        Me.tCalorEspecifico.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCalorEspecifico.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.tCalorEspecifico.InterceptMouseWheel = Ignis.NumericUpDownEx.InterceptMouseWheelMode.Never
        Me.tCalorEspecifico.Location = New System.Drawing.Point(15, 282)
        Me.tCalorEspecifico.Maximum = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.tCalorEspecifico.Name = "tCalorEspecifico"
        Me.tCalorEspecifico.ShowUpDownButtons = Ignis.NumericUpDownEx.ShowUpDownButtonsMode.Never
        Me.tCalorEspecifico.Size = New System.Drawing.Size(125, 23)
        Me.tCalorEspecifico.TabIndex = 42
        Me.tCalorEspecifico.Value = New Decimal(New Integer() {1, 0, 0, 327680})
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Location = New System.Drawing.Point(12, 261)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 17)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "Calor Específico:"
        '
        'EditarPropFis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(319, 367)
        Me.Controls.Add(Me.tCalorEspecifico)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tGeracao)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tCondutividade)
        Me.Controls.Add(Me.tMassaEspecifica)
        Me.Controls.Add(Me.tEspessura)
        Me.Controls.Add(Me.bAceitar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditarPropFis"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Propriedades Físicas"
        CType(Me.tEspessura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tMassaEspecifica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tCondutividade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tGeracao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tCalorEspecifico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents tEspessura As NumericUpDownEx
    Friend WithEvents tMassaEspecifica As NumericUpDownEx
    Friend WithEvents tCondutividade As NumericUpDownEx
    Private WithEvents bAceitar As MeshExplorer.Controls.DarkButton
    Friend WithEvents tGeracao As NumericUpDownEx
    Friend WithEvents Label6 As Label
    Friend WithEvents tCalorEspecifico As NumericUpDownEx
    Friend WithEvents Label7 As Label
End Class
