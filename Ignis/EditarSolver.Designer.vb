<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarSolver
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarSolver))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bAceitar = New MeshExplorer.Controls.DarkButton()
        Me.rSolverDecompQR = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rSolverSimples = New System.Windows.Forms.RadioButton()
        Me.rSolverDecompLU = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(12, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(290, 17)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Definição do Solver:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(12, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(290, 109)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = resources.GetString("Label4.Text")
        '
        'bAceitar
        '
        Me.bAceitar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAceitar.Location = New System.Drawing.Point(15, 252)
        Me.bAceitar.Name = "bAceitar"
        Me.bAceitar.Size = New System.Drawing.Size(287, 27)
        Me.bAceitar.TabIndex = 41
        Me.bAceitar.Text = "Aceitar e Sair"
        Me.bAceitar.UseVisualStyleBackColor = True
        '
        'rSolverDecompQR
        '
        Me.rSolverDecompQR.AutoSize = True
        Me.rSolverDecompQR.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rSolverDecompQR.ForeColor = System.Drawing.Color.Silver
        Me.rSolverDecompQR.Location = New System.Drawing.Point(15, 196)
        Me.rSolverDecompQR.Name = "rSolverDecompQR"
        Me.rSolverDecompQR.Size = New System.Drawing.Size(187, 19)
        Me.rSolverDecompQR.TabIndex = 40
        Me.rSolverDecompQR.Text = "Decomposição QR (Math.NET)"
        Me.rSolverDecompQR.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(12, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(290, 17)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Tipo de Solver:"
        '
        'rSolverSimples
        '
        Me.rSolverSimples.AutoSize = True
        Me.rSolverSimples.Checked = True
        Me.rSolverSimples.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rSolverSimples.ForeColor = System.Drawing.Color.Silver
        Me.rSolverSimples.Location = New System.Drawing.Point(15, 171)
        Me.rSolverSimples.Name = "rSolverSimples"
        Me.rSolverSimples.Size = New System.Drawing.Size(237, 19)
        Me.rSolverSimples.TabIndex = 38
        Me.rSolverSimples.TabStop = True
        Me.rSolverSimples.Text = "Simples (inversão de matriz) (Math.NET)"
        Me.rSolverSimples.UseVisualStyleBackColor = True
        '
        'rSolverDecompLU
        '
        Me.rSolverDecompLU.AutoSize = True
        Me.rSolverDecompLU.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rSolverDecompLU.ForeColor = System.Drawing.Color.Silver
        Me.rSolverDecompLU.Location = New System.Drawing.Point(15, 221)
        Me.rSolverDecompLU.Name = "rSolverDecompLU"
        Me.rSolverDecompLU.Size = New System.Drawing.Size(121, 19)
        Me.rSolverDecompLU.TabIndex = 42
        Me.rSolverDecompLU.Text = "Decomposição LU"
        Me.rSolverDecompLU.UseVisualStyleBackColor = True
        '
        'EditarSolver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(314, 291)
        Me.Controls.Add(Me.rSolverDecompLU)
        Me.Controls.Add(Me.bAceitar)
        Me.Controls.Add(Me.rSolverDecompQR)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.rSolverSimples)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditarSolver"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Editar Solver"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Private WithEvents bAceitar As MeshExplorer.Controls.DarkButton
    Friend WithEvents rSolverDecompQR As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents rSolverSimples As RadioButton
    Friend WithEvents rSolverDecompLU As RadioButton
End Class
