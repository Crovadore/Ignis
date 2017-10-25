<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditarGeometria_VisualizarFronteira
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tFronteira = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.L_Lista = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'bAceitar
        '
        Me.bAceitar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bAceitar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAceitar.Location = New System.Drawing.Point(19, 361)
        Me.bAceitar.Name = "bAceitar"
        Me.bAceitar.Size = New System.Drawing.Size(356, 25)
        Me.bAceitar.TabIndex = 45
        Me.bAceitar.Text = "Aceitar"
        Me.bAceitar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(16, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 17)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Linhas da Fronteira:"
        '
        'tFronteira
        '
        Me.tFronteira.Enabled = False
        Me.tFronteira.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tFronteira.Location = New System.Drawing.Point(19, 35)
        Me.tFronteira.Name = "tFronteira"
        Me.tFronteira.Size = New System.Drawing.Size(108, 23)
        Me.tFronteira.TabIndex = 43
        Me.tFronteira.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(16, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(165, 17)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Fronteira Selecionada:"
        '
        'L_Lista
        '
        Me.L_Lista.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.L_Lista.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Lista.FullRowSelect = True
        Me.L_Lista.GridLines = True
        Me.L_Lista.HideSelection = False
        Me.L_Lista.Location = New System.Drawing.Point(19, 91)
        Me.L_Lista.Name = "L_Lista"
        Me.L_Lista.Size = New System.Drawing.Size(356, 258)
        Me.L_Lista.TabIndex = 47
        Me.L_Lista.UseCompatibleStateImageBehavior = False
        Me.L_Lista.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Linha"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Ponto 1"
        Me.ColumnHeader5.Width = 126
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Ponto 2"
        Me.ColumnHeader6.Width = 126
        '
        'EditarGeometria_VisualizarFronteira
        '
        Me.AcceptButton = Me.bAceitar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.CancelButton = Me.bAceitar
        Me.ClientSize = New System.Drawing.Size(391, 401)
        Me.Controls.Add(Me.L_Lista)
        Me.Controls.Add(Me.bAceitar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tFronteira)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditarGeometria_VisualizarFronteira"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Linhas da Fronteira"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents bAceitar As MeshExplorer.Controls.DarkButton
    Friend WithEvents Label1 As Label
    Friend WithEvents tFronteira As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents L_Lista As ListView
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
End Class
