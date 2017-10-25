<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarGeometria_EditarPonto
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tPonto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tCoordX = New System.Windows.Forms.TextBox()
        Me.tCoordY = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bAceitar = New MeshExplorer.Controls.DarkButton()
        Me.bCancelar = New MeshExplorer.Controls.DarkButton()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(16, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 17)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Ponto Selecionado:"
        '
        'tPonto
        '
        Me.tPonto.Enabled = False
        Me.tPonto.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tPonto.Location = New System.Drawing.Point(19, 35)
        Me.tPonto.Name = "tPonto"
        Me.tPonto.Size = New System.Drawing.Size(108, 23)
        Me.tPonto.TabIndex = 27
        Me.tPonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(140, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 17)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Coord. X:"
        '
        'tCoordX
        '
        Me.tCoordX.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCoordX.Location = New System.Drawing.Point(143, 35)
        Me.tCoordX.Name = "tCoordX"
        Me.tCoordX.Size = New System.Drawing.Size(108, 23)
        Me.tCoordX.TabIndex = 29
        Me.tCoordX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tCoordY
        '
        Me.tCoordY.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tCoordY.Location = New System.Drawing.Point(267, 35)
        Me.tCoordY.Name = "tCoordY"
        Me.tCoordY.Size = New System.Drawing.Size(108, 23)
        Me.tCoordY.TabIndex = 31
        Me.tCoordY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(264, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 17)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Coord. Y:"
        '
        'bAceitar
        '
        Me.bAceitar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAceitar.Location = New System.Drawing.Point(143, 73)
        Me.bAceitar.Name = "bAceitar"
        Me.bAceitar.Size = New System.Drawing.Size(232, 25)
        Me.bAceitar.TabIndex = 32
        Me.bAceitar.Text = "Aceitar"
        Me.bAceitar.UseVisualStyleBackColor = True
        '
        'bCancelar
        '
        Me.bCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bCancelar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCancelar.Location = New System.Drawing.Point(19, 73)
        Me.bCancelar.Name = "bCancelar"
        Me.bCancelar.Size = New System.Drawing.Size(108, 25)
        Me.bCancelar.TabIndex = 33
        Me.bCancelar.Text = "Cancelar"
        Me.bCancelar.UseVisualStyleBackColor = True
        '
        'EditarGeometria_EditarPonto
        '
        Me.AcceptButton = Me.bAceitar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.CancelButton = Me.bCancelar
        Me.ClientSize = New System.Drawing.Size(391, 113)
        Me.Controls.Add(Me.bCancelar)
        Me.Controls.Add(Me.bAceitar)
        Me.Controls.Add(Me.tCoordY)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tCoordX)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tPonto)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditarGeometria_EditarPonto"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Editar Ponto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents tPonto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tCoordX As TextBox
    Friend WithEvents tCoordY As TextBox
    Friend WithEvents Label2 As Label
    Private WithEvents bAceitar As MeshExplorer.Controls.DarkButton
    Private WithEvents bCancelar As MeshExplorer.Controls.DarkButton
End Class
