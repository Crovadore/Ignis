<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarCI
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.bAceitar = New MeshExplorer.Controls.DarkButton()
        Me.tTemperatura = New Ignis.NumericUpDownEx()
        CType(Me.tTemperatura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(12, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(290, 17)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Definição das condições iniciais do problema:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(12, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(290, 52)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Nesta janela, define-se a temperatura inicial do corpo analisado. Este parâmetro " &
    "é um requisito para análises em regime transiente."
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(12, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 17)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Temperatura Inicial:"
        '
        'bAceitar
        '
        Me.bAceitar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAceitar.Location = New System.Drawing.Point(15, 147)
        Me.bAceitar.Name = "bAceitar"
        Me.bAceitar.Size = New System.Drawing.Size(287, 27)
        Me.bAceitar.TabIndex = 39
        Me.bAceitar.Text = "Aceitar e Sair"
        Me.bAceitar.UseVisualStyleBackColor = True
        '
        'tTemperatura
        '
        Me.tTemperatura.DecimalPlaces = 4
        Me.tTemperatura.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tTemperatura.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.tTemperatura.InterceptMouseWheel = Ignis.NumericUpDownEx.InterceptMouseWheelMode.Never
        Me.tTemperatura.Location = New System.Drawing.Point(15, 111)
        Me.tTemperatura.Maximum = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.tTemperatura.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.tTemperatura.Name = "tTemperatura"
        Me.tTemperatura.ShowUpDownButtons = Ignis.NumericUpDownEx.ShowUpDownButtonsMode.Never
        Me.tTemperatura.Size = New System.Drawing.Size(120, 23)
        Me.tTemperatura.TabIndex = 38
        '
        'EditarCI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(314, 186)
        Me.Controls.Add(Me.bAceitar)
        Me.Controls.Add(Me.tTemperatura)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditarCI"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Editar Condições Iniciais"
        CType(Me.tTemperatura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tTemperatura As NumericUpDownEx
    Friend WithEvents Label5 As Label
    Private WithEvents bAceitar As MeshExplorer.Controls.DarkButton
End Class
