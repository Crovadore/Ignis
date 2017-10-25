<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditarCC
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
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PainelConsulta = New System.Windows.Forms.Panel()
        Me.bAdicionar = New MeshExplorer.Controls.DarkButton()
        Me.bEditar = New MeshExplorer.Controls.DarkButton()
        Me.bRemover = New MeshExplorer.Controls.DarkButton()
        Me.lCC = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PainelCadastro = New System.Windows.Forms.Panel()
        Me.tDescricao = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tParametro2 = New Ignis.NumericUpDownEx()
        Me.tParametro1 = New Ignis.NumericUpDownEx()
        Me.lParametro2 = New System.Windows.Forms.Label()
        Me.lParametro1 = New System.Windows.Forms.Label()
        Me.bVoltar = New MeshExplorer.Controls.DarkButton()
        Me.bDesmarcar = New MeshExplorer.Controls.DarkButton()
        Me.cTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bCadastrar = New MeshExplorer.Controls.DarkButton()
        Me.bMarcar = New MeshExplorer.Controls.DarkButton()
        Me.lLinhasDisponiveis = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.PainelConsulta.SuspendLayout()
        Me.PainelCadastro.SuspendLayout()
        CType(Me.tParametro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tParametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'splitContainer1
        '
        Me.splitContainer1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.splitContainer1.IsSplitterFixed = True
        Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.splitContainer1.Panel1.Controls.Add(Me.PainelCadastro)
        Me.splitContainer1.Panel1.Controls.Add(Me.PainelConsulta)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.BackColor = System.Drawing.Color.Black
        Me.splitContainer1.Size = New System.Drawing.Size(784, 461)
        Me.splitContainer1.SplitterDistance = 332
        Me.splitContainer1.SplitterWidth = 1
        Me.splitContainer1.TabIndex = 10
        '
        'PainelConsulta
        '
        Me.PainelConsulta.Controls.Add(Me.bAdicionar)
        Me.PainelConsulta.Controls.Add(Me.bEditar)
        Me.PainelConsulta.Controls.Add(Me.bRemover)
        Me.PainelConsulta.Controls.Add(Me.lCC)
        Me.PainelConsulta.Controls.Add(Me.Label8)
        Me.PainelConsulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PainelConsulta.Location = New System.Drawing.Point(0, 0)
        Me.PainelConsulta.Name = "PainelConsulta"
        Me.PainelConsulta.Size = New System.Drawing.Size(332, 461)
        Me.PainelConsulta.TabIndex = 27
        '
        'bAdicionar
        '
        Me.bAdicionar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bAdicionar.Location = New System.Drawing.Point(15, 419)
        Me.bAdicionar.Name = "bAdicionar"
        Me.bAdicionar.Size = New System.Drawing.Size(302, 30)
        Me.bAdicionar.TabIndex = 30
        Me.bAdicionar.Text = "Adicionar Nova Condição de Contorno"
        Me.bAdicionar.UseVisualStyleBackColor = True
        '
        'bEditar
        '
        Me.bEditar.Enabled = False
        Me.bEditar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bEditar.Location = New System.Drawing.Point(171, 382)
        Me.bEditar.Name = "bEditar"
        Me.bEditar.Size = New System.Drawing.Size(146, 25)
        Me.bEditar.TabIndex = 29
        Me.bEditar.Text = "Editar"
        Me.bEditar.UseVisualStyleBackColor = True
        '
        'bRemover
        '
        Me.bRemover.Enabled = False
        Me.bRemover.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bRemover.Location = New System.Drawing.Point(15, 382)
        Me.bRemover.Name = "bRemover"
        Me.bRemover.Size = New System.Drawing.Size(146, 25)
        Me.bRemover.TabIndex = 28
        Me.bRemover.Text = "Remover"
        Me.bRemover.UseVisualStyleBackColor = True
        '
        'lCC
        '
        Me.lCC.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader1, Me.ColumnHeader3})
        Me.lCC.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lCC.FullRowSelect = True
        Me.lCC.GridLines = True
        Me.lCC.HideSelection = False
        Me.lCC.Location = New System.Drawing.Point(15, 30)
        Me.lCC.Name = "lCC"
        Me.lCC.Size = New System.Drawing.Size(302, 343)
        Me.lCC.TabIndex = 27
        Me.lCC.UseCompatibleStateImageBehavior = False
        Me.lCC.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Tipo"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Fronteira"
        Me.ColumnHeader1.Width = 70
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Descrição"
        Me.ColumnHeader3.Width = 148
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.LightGray
        Me.Label8.Location = New System.Drawing.Point(12, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(193, 15)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Condições de Contorno Definidas:"
        '
        'PainelCadastro
        '
        Me.PainelCadastro.Controls.Add(Me.tDescricao)
        Me.PainelCadastro.Controls.Add(Me.Label3)
        Me.PainelCadastro.Controls.Add(Me.tParametro2)
        Me.PainelCadastro.Controls.Add(Me.tParametro1)
        Me.PainelCadastro.Controls.Add(Me.lParametro2)
        Me.PainelCadastro.Controls.Add(Me.lParametro1)
        Me.PainelCadastro.Controls.Add(Me.bVoltar)
        Me.PainelCadastro.Controls.Add(Me.bDesmarcar)
        Me.PainelCadastro.Controls.Add(Me.cTipo)
        Me.PainelCadastro.Controls.Add(Me.Label2)
        Me.PainelCadastro.Controls.Add(Me.bCadastrar)
        Me.PainelCadastro.Controls.Add(Me.bMarcar)
        Me.PainelCadastro.Controls.Add(Me.lLinhasDisponiveis)
        Me.PainelCadastro.Controls.Add(Me.Label1)
        Me.PainelCadastro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PainelCadastro.Location = New System.Drawing.Point(0, 0)
        Me.PainelCadastro.Name = "PainelCadastro"
        Me.PainelCadastro.Size = New System.Drawing.Size(332, 461)
        Me.PainelCadastro.TabIndex = 26
        Me.PainelCadastro.Visible = False
        '
        'tDescricao
        '
        Me.tDescricao.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tDescricao.Location = New System.Drawing.Point(169, 326)
        Me.tDescricao.MaxLength = 23
        Me.tDescricao.Name = "tDescricao"
        Me.tDescricao.Size = New System.Drawing.Size(148, 23)
        Me.tDescricao.TabIndex = 42
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.LightGray
        Me.Label3.Location = New System.Drawing.Point(166, 308)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 15)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Descrição:"
        '
        'tParametro2
        '
        Me.tParametro2.DecimalPlaces = 4
        Me.tParametro2.Enabled = False
        Me.tParametro2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tParametro2.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.tParametro2.InterceptMouseWheel = Ignis.NumericUpDownEx.InterceptMouseWheelMode.Never
        Me.tParametro2.Location = New System.Drawing.Point(169, 380)
        Me.tParametro2.Maximum = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.tParametro2.Minimum = New Decimal(New Integer() {-1530494977, 232830, 0, -2147483648})
        Me.tParametro2.Name = "tParametro2"
        Me.tParametro2.ShowUpDownButtons = Ignis.NumericUpDownEx.ShowUpDownButtonsMode.Never
        Me.tParametro2.Size = New System.Drawing.Size(148, 23)
        Me.tParametro2.TabIndex = 40
        Me.tParametro2.Visible = False
        '
        'tParametro1
        '
        Me.tParametro1.DecimalPlaces = 4
        Me.tParametro1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tParametro1.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.tParametro1.InterceptMouseWheel = Ignis.NumericUpDownEx.InterceptMouseWheelMode.Never
        Me.tParametro1.Location = New System.Drawing.Point(15, 380)
        Me.tParametro1.Maximum = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.tParametro1.Minimum = New Decimal(New Integer() {-1530494977, 232830, 0, -2147483648})
        Me.tParametro1.Name = "tParametro1"
        Me.tParametro1.ShowUpDownButtons = Ignis.NumericUpDownEx.ShowUpDownButtonsMode.Never
        Me.tParametro1.Size = New System.Drawing.Size(146, 23)
        Me.tParametro1.TabIndex = 39
        '
        'lParametro2
        '
        Me.lParametro2.AutoSize = True
        Me.lParametro2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lParametro2.ForeColor = System.Drawing.Color.LightGray
        Me.lParametro2.Location = New System.Drawing.Point(166, 362)
        Me.lParametro2.Name = "lParametro2"
        Me.lParametro2.Size = New System.Drawing.Size(79, 15)
        Me.lParametro2.TabIndex = 36
        Me.lParametro2.Text = "Parâmetro 2:"
        Me.lParametro2.Visible = False
        '
        'lParametro1
        '
        Me.lParametro1.AutoSize = True
        Me.lParametro1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lParametro1.ForeColor = System.Drawing.Color.LightGray
        Me.lParametro1.Location = New System.Drawing.Point(12, 362)
        Me.lParametro1.Name = "lParametro1"
        Me.lParametro1.Size = New System.Drawing.Size(79, 15)
        Me.lParametro1.TabIndex = 35
        Me.lParametro1.Text = "Parâmetro 1:"
        '
        'bVoltar
        '
        Me.bVoltar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bVoltar.Location = New System.Drawing.Point(15, 419)
        Me.bVoltar.Name = "bVoltar"
        Me.bVoltar.Size = New System.Drawing.Size(85, 30)
        Me.bVoltar.TabIndex = 34
        Me.bVoltar.Text = "Voltar"
        Me.bVoltar.UseVisualStyleBackColor = True
        '
        'bDesmarcar
        '
        Me.bDesmarcar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bDesmarcar.Location = New System.Drawing.Point(206, 268)
        Me.bDesmarcar.Name = "bDesmarcar"
        Me.bDesmarcar.Size = New System.Drawing.Size(111, 25)
        Me.bDesmarcar.TabIndex = 33
        Me.bDesmarcar.Text = "Desmarcar Todas"
        Me.bDesmarcar.UseVisualStyleBackColor = True
        '
        'cTipo
        '
        Me.cTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cTipo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cTipo.FormattingEnabled = True
        Me.cTipo.Items.AddRange(New Object() {"1 - Dirichlet", "2 - Neumann", "3 - Robin"})
        Me.cTipo.Location = New System.Drawing.Point(15, 326)
        Me.cTipo.Name = "cTipo"
        Me.cTipo.Size = New System.Drawing.Size(146, 23)
        Me.cTipo.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.LightGray
        Me.Label2.Location = New System.Drawing.Point(12, 308)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 15)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Tipo de C.C.:"
        '
        'bCadastrar
        '
        Me.bCadastrar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bCadastrar.Location = New System.Drawing.Point(106, 419)
        Me.bCadastrar.Name = "bCadastrar"
        Me.bCadastrar.Size = New System.Drawing.Size(211, 30)
        Me.bCadastrar.TabIndex = 30
        Me.bCadastrar.Text = "Cadastrar Condição de Contorno"
        Me.bCadastrar.UseVisualStyleBackColor = True
        '
        'bMarcar
        '
        Me.bMarcar.Enabled = False
        Me.bMarcar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bMarcar.Location = New System.Drawing.Point(15, 268)
        Me.bMarcar.Name = "bMarcar"
        Me.bMarcar.Size = New System.Drawing.Size(185, 25)
        Me.bMarcar.TabIndex = 28
        Me.bMarcar.Text = "Marcar Selecionadas (0)"
        Me.bMarcar.UseVisualStyleBackColor = True
        '
        'lLinhasDisponiveis
        '
        Me.lLinhasDisponiveis.CheckBoxes = True
        Me.lLinhasDisponiveis.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4})
        Me.lLinhasDisponiveis.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lLinhasDisponiveis.FullRowSelect = True
        Me.lLinhasDisponiveis.GridLines = True
        Me.lLinhasDisponiveis.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lLinhasDisponiveis.HideSelection = False
        Me.lLinhasDisponiveis.Location = New System.Drawing.Point(15, 30)
        Me.lLinhasDisponiveis.Name = "lLinhasDisponiveis"
        Me.lLinhasDisponiveis.Size = New System.Drawing.Size(302, 232)
        Me.lLinhasDisponiveis.TabIndex = 27
        Me.lLinhasDisponiveis.UseCompatibleStateImageBehavior = False
        Me.lLinhasDisponiveis.View = System.Windows.Forms.View.Details
        Me.lLinhasDisponiveis.VirtualMode = True
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = ""
        Me.ColumnHeader4.Width = 298
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LightGray
        Me.Label1.Location = New System.Drawing.Point(12, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 15)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Linhas disponíveis:"
        '
        'EditarCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 461)
        Me.Controls.Add(Me.splitContainer1)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 500)
        Me.Name = "EditarCC"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Condições de Contorno"
        Me.splitContainer1.Panel1.ResumeLayout(False)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.ResumeLayout(False)
        Me.PainelConsulta.ResumeLayout(False)
        Me.PainelConsulta.PerformLayout()
        Me.PainelCadastro.ResumeLayout(False)
        Me.PainelCadastro.PerformLayout()
        CType(Me.tParametro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tParametro1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents splitContainer1 As SplitContainer
    Friend WithEvents PainelCadastro As Panel
    Friend WithEvents cTipo As ComboBox
    Friend WithEvents Label2 As Label
    Private WithEvents bCadastrar As MeshExplorer.Controls.DarkButton
    Private WithEvents bMarcar As MeshExplorer.Controls.DarkButton
    Friend WithEvents lLinhasDisponiveis As ListView
    Friend WithEvents Label1 As Label
    Private WithEvents bDesmarcar As MeshExplorer.Controls.DarkButton
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Private WithEvents bVoltar As MeshExplorer.Controls.DarkButton
    Friend WithEvents lParametro2 As Label
    Friend WithEvents lParametro1 As Label
    Friend WithEvents tParametro1 As NumericUpDownEx
    Friend WithEvents tParametro2 As NumericUpDownEx
    Friend WithEvents tDescricao As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PainelConsulta As Panel
    Private WithEvents bAdicionar As MeshExplorer.Controls.DarkButton
    Private WithEvents bEditar As MeshExplorer.Controls.DarkButton
    Private WithEvents bRemover As MeshExplorer.Controls.DarkButton
    Friend WithEvents lCC As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents Label8 As Label
End Class
