<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarParamProc
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
        Me.rCondPerm = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rCondTrans = New System.Windows.Forms.RadioButton()
        Me.bAceitar = New MeshExplorer.Controls.DarkButton()
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
        Me.Label2.Text = "Definição dos parâmetros de processamento:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(12, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(290, 36)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Nesta janela, define-se o tipo de processamento do problema, conforme lista abaix" &
    "o."
        '
        'rCondPerm
        '
        Me.rCondPerm.AutoSize = True
        Me.rCondPerm.Checked = True
        Me.rCondPerm.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rCondPerm.ForeColor = System.Drawing.Color.Silver
        Me.rCondPerm.Location = New System.Drawing.Point(15, 96)
        Me.rCondPerm.Name = "rCondPerm"
        Me.rCondPerm.Size = New System.Drawing.Size(257, 19)
        Me.rCondPerm.TabIndex = 34
        Me.rCondPerm.TabStop = True
        Me.rCondPerm.Text = "Condução de Calor em Regime Permanente"
        Me.rCondPerm.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(12, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(290, 17)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Tipo de análise:"
        '
        'rCondTrans
        '
        Me.rCondTrans.AutoSize = True
        Me.rCondTrans.Enabled = False
        Me.rCondTrans.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rCondTrans.ForeColor = System.Drawing.Color.Silver
        Me.rCondTrans.Location = New System.Drawing.Point(15, 121)
        Me.rCondTrans.Name = "rCondTrans"
        Me.rCondTrans.Size = New System.Drawing.Size(247, 19)
        Me.rCondTrans.TabIndex = 36
        Me.rCondTrans.Text = "Condução de Calor em Regime Transiente"
        Me.rCondTrans.UseVisualStyleBackColor = True
        '
        'bAceitar
        '
        Me.bAceitar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAceitar.Location = New System.Drawing.Point(15, 152)
        Me.bAceitar.Name = "bAceitar"
        Me.bAceitar.Size = New System.Drawing.Size(287, 27)
        Me.bAceitar.TabIndex = 37
        Me.bAceitar.Text = "Aceitar e Sair"
        Me.bAceitar.UseVisualStyleBackColor = True
        '
        'EditarParamProc
        '
        Me.AcceptButton = Me.bAceitar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(314, 191)
        Me.Controls.Add(Me.bAceitar)
        Me.Controls.Add(Me.rCondTrans)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.rCondPerm)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditarParamProc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Editar Parâmetros de Processamento"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents rCondPerm As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents rCondTrans As RadioButton
    Private WithEvents bAceitar As MeshExplorer.Controls.DarkButton
End Class
