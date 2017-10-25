<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RenomearSimulacao
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
        Me.tNome = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bConfirmar = New MeshExplorer.Controls.DarkButton()
        Me.bSair = New MeshExplorer.Controls.DarkButton()
        Me.SuspendLayout()
        '
        'tNome
        '
        Me.tNome.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tNome.Location = New System.Drawing.Point(15, 30)
        Me.tNome.MaxLength = 33
        Me.tNome.Name = "tNome"
        Me.tNome.Size = New System.Drawing.Size(208, 23)
        Me.tNome.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.LightGray
        Me.Label3.Location = New System.Drawing.Point(12, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nome do Arquivo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LightGray
        Me.Label1.Location = New System.Drawing.Point(226, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = ".ignis"
        '
        'bConfirmar
        '
        Me.bConfirmar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bConfirmar.Location = New System.Drawing.Point(106, 67)
        Me.bConfirmar.Name = "bConfirmar"
        Me.bConfirmar.Size = New System.Drawing.Size(155, 25)
        Me.bConfirmar.TabIndex = 2
        Me.bConfirmar.Text = "Confirmar"
        Me.bConfirmar.UseVisualStyleBackColor = True
        '
        'bSair
        '
        Me.bSair.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bSair.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bSair.Location = New System.Drawing.Point(15, 67)
        Me.bSair.Name = "bSair"
        Me.bSair.Size = New System.Drawing.Size(85, 25)
        Me.bSair.TabIndex = 1
        Me.bSair.Text = "Sair"
        Me.bSair.UseVisualStyleBackColor = True
        '
        'RenomearSimulacao
        '
        Me.AcceptButton = Me.bConfirmar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.CancelButton = Me.bSair
        Me.ClientSize = New System.Drawing.Size(274, 109)
        Me.Controls.Add(Me.bSair)
        Me.Controls.Add(Me.bConfirmar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tNome)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RenomearSimulacao"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Renomear Simulação"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tNome As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Private WithEvents bConfirmar As MeshExplorer.Controls.DarkButton
    Private WithEvents bSair As MeshExplorer.Controls.DarkButton
End Class
