<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditarConfig
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.bAceitar = New MeshExplorer.Controls.DarkButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rDecompLU = New System.Windows.Forms.RadioButton()
        Me.rDecompQR = New System.Windows.Forms.RadioButton()
        Me.rSimples = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rIsotermas = New System.Windows.Forms.RadioButton()
        Me.rGradEC = New System.Windows.Forms.RadioButton()
        Me.rGradColor = New System.Windows.Forms.RadioButton()
        Me.tTempo = New Ignis.NumericUpDownEx()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.tTempo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bAceitar
        '
        Me.bAceitar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAceitar.Location = New System.Drawing.Point(15, 270)
        Me.bAceitar.Name = "bAceitar"
        Me.bAceitar.Size = New System.Drawing.Size(342, 27)
        Me.bAceitar.TabIndex = 44
        Me.bAceitar.Text = "Aceitar e Sair"
        Me.bAceitar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(12, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(345, 17)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Tempo máximo de espera para modificação da malha:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(12, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(345, 17)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Definição das configurações do Ignis:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(12, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(345, 54)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Nesta janela, é possível alterar algumas configurações referentes à funcionalidad" &
    "es do Ignis. Estas definições permanecerão salvas para o usuário da sessão atual" &
    " do Windows."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Silver
        Me.Label1.Location = New System.Drawing.Point(98, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "segundo(s)"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(12, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(345, 17)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Solver padrão para novas simulações:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rDecompLU)
        Me.Panel1.Controls.Add(Me.rDecompQR)
        Me.Panel1.Controls.Add(Me.rSimples)
        Me.Panel1.Location = New System.Drawing.Point(15, 171)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(342, 26)
        Me.Panel1.TabIndex = 47
        '
        'rDecompLU
        '
        Me.rDecompLU.AutoSize = True
        Me.rDecompLU.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rDecompLU.ForeColor = System.Drawing.Color.Silver
        Me.rDecompLU.Location = New System.Drawing.Point(193, 3)
        Me.rDecompLU.Name = "rDecompLU"
        Me.rDecompLU.Size = New System.Drawing.Size(90, 19)
        Me.rDecompLU.TabIndex = 37
        Me.rDecompLU.Text = "Decomp. LU"
        Me.rDecompLU.UseVisualStyleBackColor = True
        '
        'rDecompQR
        '
        Me.rDecompQR.AutoSize = True
        Me.rDecompQR.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rDecompQR.ForeColor = System.Drawing.Color.Silver
        Me.rDecompQR.Location = New System.Drawing.Point(85, 3)
        Me.rDecompQR.Name = "rDecompQR"
        Me.rDecompQR.Size = New System.Drawing.Size(92, 19)
        Me.rDecompQR.TabIndex = 36
        Me.rDecompQR.Text = "Decomp. QR"
        Me.rDecompQR.UseVisualStyleBackColor = True
        '
        'rSimples
        '
        Me.rSimples.AutoSize = True
        Me.rSimples.Checked = True
        Me.rSimples.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rSimples.ForeColor = System.Drawing.Color.Silver
        Me.rSimples.Location = New System.Drawing.Point(3, 3)
        Me.rSimples.Name = "rSimples"
        Me.rSimples.Size = New System.Drawing.Size(66, 19)
        Me.rSimples.TabIndex = 35
        Me.rSimples.TabStop = True
        Me.rSimples.Text = "Simples"
        Me.rSimples.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Location = New System.Drawing.Point(12, 212)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(345, 17)
        Me.Label6.TabIndex = 48
        Me.Label6.Text = "Visualização padrão para novas simulações:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rIsotermas)
        Me.Panel2.Controls.Add(Me.rGradEC)
        Me.Panel2.Controls.Add(Me.rGradColor)
        Me.Panel2.Location = New System.Drawing.Point(15, 232)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(342, 26)
        Me.Panel2.TabIndex = 49
        '
        'rIsotermas
        '
        Me.rIsotermas.AutoSize = True
        Me.rIsotermas.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rIsotermas.ForeColor = System.Drawing.Color.Silver
        Me.rIsotermas.Location = New System.Drawing.Point(259, 3)
        Me.rIsotermas.Name = "rIsotermas"
        Me.rIsotermas.Size = New System.Drawing.Size(76, 19)
        Me.rIsotermas.TabIndex = 37
        Me.rIsotermas.Text = "Isotermas"
        Me.rIsotermas.UseVisualStyleBackColor = True
        '
        'rGradEC
        '
        Me.rGradEC.AutoSize = True
        Me.rGradEC.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rGradEC.ForeColor = System.Drawing.Color.Silver
        Me.rGradEC.Location = New System.Drawing.Point(144, 3)
        Me.rGradEC.Name = "rGradEC"
        Me.rGradEC.Size = New System.Drawing.Size(99, 19)
        Me.rGradEC.TabIndex = 36
        Me.rGradEC.Text = "Gradiente E.C."
        Me.rGradEC.UseVisualStyleBackColor = True
        '
        'rGradColor
        '
        Me.rGradColor.AutoSize = True
        Me.rGradColor.Checked = True
        Me.rGradColor.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rGradColor.ForeColor = System.Drawing.Color.Silver
        Me.rGradColor.Location = New System.Drawing.Point(3, 3)
        Me.rGradColor.Name = "rGradColor"
        Me.rGradColor.Size = New System.Drawing.Size(125, 19)
        Me.rGradColor.TabIndex = 35
        Me.rGradColor.TabStop = True
        Me.rGradColor.Text = "Gradiente Colorido"
        Me.rGradColor.UseVisualStyleBackColor = True
        '
        'tTempo
        '
        Me.tTempo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTempo.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.tTempo.InterceptMouseWheel = Ignis.NumericUpDownEx.InterceptMouseWheelMode.Never
        Me.tTempo.Location = New System.Drawing.Point(15, 111)
        Me.tTempo.Maximum = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.tTempo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.tTempo.Name = "tTempo"
        Me.tTempo.ShowUpDownButtons = Ignis.NumericUpDownEx.ShowUpDownButtonsMode.Never
        Me.tTempo.Size = New System.Drawing.Size(77, 23)
        Me.tTempo.TabIndex = 43
        Me.tTempo.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'EditarConfig
        '
        Me.AcceptButton = Me.bAceitar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(374, 315)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bAceitar)
        Me.Controls.Add(Me.tTempo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditarConfig"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Editar Configurações do Ignis"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.tTempo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents bAceitar As MeshExplorer.Controls.DarkButton
    Friend WithEvents tTempo As NumericUpDownEx
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rDecompLU As RadioButton
    Friend WithEvents rDecompQR As RadioButton
    Friend WithEvents rSimples As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents rIsotermas As RadioButton
    Friend WithEvents rGradEC As RadioButton
    Friend WithEvents rGradColor As RadioButton
End Class
