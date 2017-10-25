<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarGeometria_EditarLinha
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
        Me.bCancelar = New MeshExplorer.Controls.DarkButton()
        Me.bAceitar = New MeshExplorer.Controls.DarkButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tLinha = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.L_Ponto2 = New System.Windows.Forms.ComboBox()
        Me.L_Ponto1 = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'bCancelar
        '
        Me.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.Location = New System.Drawing.Point(19, 73)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(108, 25)
        Me.bCancelar.TabIndex = 41
        Me.bCancelar.Text = "Cancelar"
        Me.bCancelar.UseVisualStyleBackColor = True
        '
        'bAceitar
        '
        Me.bAceitar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAceitar.Location = New System.Drawing.Point(143, 73)
        Me.bAceitar.Name = "bAceitar"
        Me.bAceitar.Size = New System.Drawing.Size(232, 25)
        Me.bAceitar.TabIndex = 40
        Me.bAceitar.Text = "Aceitar"
        Me.bAceitar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(264, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 17)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Ponto 2:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(140, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 17)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Ponto 1:"
        '
        'tLinha
        '
        Me.tLinha.Enabled = False
        Me.tLinha.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tLinha.Location = New System.Drawing.Point(19, 35)
        Me.tLinha.Name = "tLinha"
        Me.tLinha.Size = New System.Drawing.Size(108, 23)
        Me.tLinha.TabIndex = 35
        Me.tLinha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(16, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 17)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Linha Selecionada:"
        '
        'L_Ponto2
        '
        Me.L_Ponto2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.L_Ponto2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.L_Ponto2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Ponto2.FormattingEnabled = True
        Me.L_Ponto2.Location = New System.Drawing.Point(267, 35)
        Me.L_Ponto2.Name = "L_Ponto2"
        Me.L_Ponto2.Size = New System.Drawing.Size(108, 23)
        Me.L_Ponto2.TabIndex = 43
        '
        'L_Ponto1
        '
        Me.L_Ponto1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.L_Ponto1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.L_Ponto1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Ponto1.FormattingEnabled = True
        Me.L_Ponto1.Location = New System.Drawing.Point(143, 35)
        Me.L_Ponto1.Name = "L_Ponto1"
        Me.L_Ponto1.Size = New System.Drawing.Size(108, 23)
        Me.L_Ponto1.TabIndex = 42
        '
        'EditarGeometria_EditarLinha
        '
        Me.AcceptButton = Me.bAceitar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.CancelButton = Me.bCancelar
        Me.ClientSize = New System.Drawing.Size(391, 113)
        Me.Controls.Add(Me.L_Ponto2)
        Me.Controls.Add(Me.L_Ponto1)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.bAceitar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tLinha)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditarGeometria_EditarLinha"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Editar Linha"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents bCancelar As MeshExplorer.Controls.DarkButton
    Private WithEvents bAceitar As MeshExplorer.Controls.DarkButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tLinha As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents L_Ponto2 As ComboBox
    Friend WithEvents L_Ponto1 As ComboBox
End Class
