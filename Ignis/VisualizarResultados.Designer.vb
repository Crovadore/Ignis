<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VisualizarResultados
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bObter = New MeshExplorer.Controls.DarkButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bAceitar = New MeshExplorer.Controls.DarkButton()
        Me.tFluxoX = New System.Windows.Forms.TextBox()
        Me.tFluxoY = New System.Windows.Forms.TextBox()
        Me.tTemperatura = New System.Windows.Forms.TextBox()
        Me.tPosY = New System.Windows.Forms.TextBox()
        Me.tPosX = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tPosX)
        Me.GroupBox1.Controls.Add(Me.tPosY)
        Me.GroupBox1.Controls.Add(Me.tTemperatura)
        Me.GroupBox1.Controls.Add(Me.tFluxoY)
        Me.GroupBox1.Controls.Add(Me.tFluxoX)
        Me.GroupBox1.Controls.Add(Me.bObter)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox1.Location = New System.Drawing.Point(13, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(478, 161)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Temperatura e Fluxo na posição"
        '
        'bObter
        '
        Me.bObter.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bObter.Location = New System.Drawing.Point(323, 51)
        Me.bObter.Name = "bObter"
        Me.bObter.Size = New System.Drawing.Size(140, 26)
        Me.bObter.TabIndex = 4
        Me.bObter.Text = "Obter"
        Me.bObter.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label7.Location = New System.Drawing.Point(320, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 17)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Temperatura:"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Location = New System.Drawing.Point(12, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 17)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Fluxo X:"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(166, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fluxo Y:"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(166, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Posição Y:"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(12, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Posição X:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(12, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(474, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Visualização de resultados numéricos:"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Silver
        Me.Label4.Location = New System.Drawing.Point(12, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(479, 24)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Aqui é possível obter os resultados numéricos em coordenadas específicas da geome" &
    "tria."
        '
        'bAceitar
        '
        Me.bAceitar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAceitar.Location = New System.Drawing.Point(13, 228)
        Me.bAceitar.Name = "bAceitar"
        Me.bAceitar.Size = New System.Drawing.Size(478, 27)
        Me.bAceitar.TabIndex = 3
        Me.bAceitar.Text = "Aceitar e Sair"
        Me.bAceitar.UseVisualStyleBackColor = True
        '
        'tFluxoX
        '
        Me.tFluxoX.Location = New System.Drawing.Point(15, 114)
        Me.tFluxoX.Name = "tFluxoX"
        Me.tFluxoX.ReadOnly = True
        Me.tFluxoX.Size = New System.Drawing.Size(140, 23)
        Me.tFluxoX.TabIndex = 6
        Me.tFluxoX.Text = "---"
        '
        'tFluxoY
        '
        Me.tFluxoY.Location = New System.Drawing.Point(169, 114)
        Me.tFluxoY.Name = "tFluxoY"
        Me.tFluxoY.ReadOnly = True
        Me.tFluxoY.Size = New System.Drawing.Size(140, 23)
        Me.tFluxoY.TabIndex = 8
        Me.tFluxoY.Text = "---"
        '
        'tTemperatura
        '
        Me.tTemperatura.Location = New System.Drawing.Point(323, 114)
        Me.tTemperatura.Name = "tTemperatura"
        Me.tTemperatura.ReadOnly = True
        Me.tTemperatura.Size = New System.Drawing.Size(140, 23)
        Me.tTemperatura.TabIndex = 10
        Me.tTemperatura.Text = "---"
        '
        'tPosY
        '
        Me.tPosY.Location = New System.Drawing.Point(169, 52)
        Me.tPosY.Name = "tPosY"
        Me.tPosY.Size = New System.Drawing.Size(140, 23)
        Me.tPosY.TabIndex = 3
        '
        'tPosX
        '
        Me.tPosX.Location = New System.Drawing.Point(15, 52)
        Me.tPosX.Name = "tPosX"
        Me.tPosX.Size = New System.Drawing.Size(140, 23)
        Me.tPosX.TabIndex = 1
        '
        'VisualizarResultados
        '
        Me.AcceptButton = Me.bAceitar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(504, 268)
        Me.Controls.Add(Me.bAceitar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VisualizarResultados"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Visualizar Resultados Numéricos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Private WithEvents bAceitar As MeshExplorer.Controls.DarkButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Private WithEvents bObter As MeshExplorer.Controls.DarkButton
    Friend WithEvents Label7 As Label
    Friend WithEvents tPosX As TextBox
    Friend WithEvents tPosY As TextBox
    Friend WithEvents tTemperatura As TextBox
    Friend WithEvents tFluxoY As TextBox
    Friend WithEvents tFluxoX As TextBox
End Class
