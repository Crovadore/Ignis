<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditarGeometria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditarGeometria))
        Me.flatTabControl1 = New MeshExplorer.Controls.DarkTabControl()
        Me.P_Aba = New System.Windows.Forms.TabPage()
        Me.P_Cadastrar = New MeshExplorer.Controls.DarkButton()
        Me.P_Editar = New MeshExplorer.Controls.DarkButton()
        Me.P_Remover = New MeshExplorer.Controls.DarkButton()
        Me.P_CoordY = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.P_CoordX = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.P_Lista = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.L_Aba = New System.Windows.Forms.TabPage()
        Me.L_Cadastrar = New MeshExplorer.Controls.DarkButton()
        Me.L_Editar = New MeshExplorer.Controls.DarkButton()
        Me.L_Remover = New MeshExplorer.Controls.DarkButton()
        Me.L_Ponto2 = New System.Windows.Forms.ComboBox()
        Me.L_Ponto1 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.L_Lista = New System.Windows.Forms.ListView()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.F_Aba = New System.Windows.Forms.TabPage()
        Me.F_DetectarFronteiras = New MeshExplorer.Controls.DarkButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.F_Lista = New System.Windows.Forms.ListView()
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.bImportar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.bSair = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.lStatus = New System.Windows.Forms.ToolStripLabel()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.flatTabControl1.SuspendLayout()
        Me.P_Aba.SuspendLayout()
        Me.L_Aba.SuspendLayout()
        Me.F_Aba.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'flatTabControl1
        '
        Me.flatTabControl1.Controls.Add(Me.P_Aba)
        Me.flatTabControl1.Controls.Add(Me.L_Aba)
        Me.flatTabControl1.Controls.Add(Me.F_Aba)
        Me.flatTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flatTabControl1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.flatTabControl1.ItemSize = New System.Drawing.Size(132, 35)
        Me.flatTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.flatTabControl1.Name = "flatTabControl1"
        Me.flatTabControl1.SelectedIndex = 0
        Me.flatTabControl1.Size = New System.Drawing.Size(399, 508)
        Me.flatTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.flatTabControl1.TabIndex = 1
        '
        'P_Aba
        '
        Me.P_Aba.BackColor = System.Drawing.Color.DimGray
        Me.P_Aba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.P_Aba.Controls.Add(Me.P_Cadastrar)
        Me.P_Aba.Controls.Add(Me.P_Editar)
        Me.P_Aba.Controls.Add(Me.P_Remover)
        Me.P_Aba.Controls.Add(Me.P_CoordY)
        Me.P_Aba.Controls.Add(Me.Label4)
        Me.P_Aba.Controls.Add(Me.P_CoordX)
        Me.P_Aba.Controls.Add(Me.Label3)
        Me.P_Aba.Controls.Add(Me.Label2)
        Me.P_Aba.Controls.Add(Me.P_Lista)
        Me.P_Aba.Controls.Add(Me.Label1)
        Me.P_Aba.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_Aba.ForeColor = System.Drawing.Color.DarkGray
        Me.P_Aba.Location = New System.Drawing.Point(4, 39)
        Me.P_Aba.Margin = New System.Windows.Forms.Padding(5)
        Me.P_Aba.Name = "P_Aba"
        Me.P_Aba.Padding = New System.Windows.Forms.Padding(4)
        Me.P_Aba.Size = New System.Drawing.Size(391, 465)
        Me.P_Aba.TabIndex = 0
        Me.P_Aba.Text = "Pontos"
        '
        'P_Cadastrar
        '
        Me.P_Cadastrar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_Cadastrar.Location = New System.Drawing.Point(291, 427)
        Me.P_Cadastrar.Name = "P_Cadastrar"
        Me.P_Cadastrar.Size = New System.Drawing.Size(83, 23)
        Me.P_Cadastrar.TabIndex = 17
        Me.P_Cadastrar.Text = "Cadastrar"
        Me.P_Cadastrar.UseVisualStyleBackColor = True
        '
        'P_Editar
        '
        Me.P_Editar.Enabled = False
        Me.P_Editar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_Editar.Location = New System.Drawing.Point(203, 343)
        Me.P_Editar.Name = "P_Editar"
        Me.P_Editar.Size = New System.Drawing.Size(171, 25)
        Me.P_Editar.TabIndex = 14
        Me.P_Editar.Text = "Editar"
        Me.P_Editar.UseVisualStyleBackColor = True
        '
        'P_Remover
        '
        Me.P_Remover.Enabled = False
        Me.P_Remover.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_Remover.Location = New System.Drawing.Point(14, 343)
        Me.P_Remover.Name = "P_Remover"
        Me.P_Remover.Size = New System.Drawing.Size(183, 25)
        Me.P_Remover.TabIndex = 13
        Me.P_Remover.Text = "Remover"
        Me.P_Remover.UseVisualStyleBackColor = True
        '
        'P_CoordY
        '
        Me.P_CoordY.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_CoordY.Location = New System.Drawing.Point(154, 427)
        Me.P_CoordY.Name = "P_CoordY"
        Me.P_CoordY.Size = New System.Drawing.Size(129, 23)
        Me.P_CoordY.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(151, 409)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Coord. Y:"
        '
        'P_CoordX
        '
        Me.P_CoordX.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_CoordX.Location = New System.Drawing.Point(14, 427)
        Me.P_CoordX.Name = "P_CoordX"
        Me.P_CoordX.Size = New System.Drawing.Size(129, 23)
        Me.P_CoordX.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Location = New System.Drawing.Point(11, 409)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Coord. X:"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.LightGray
        Me.Label2.Location = New System.Drawing.Point(11, 386)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(363, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Cadastrar novo ponto:"
        '
        'P_Lista
        '
        Me.P_Lista.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.P_Lista.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.P_Lista.FullRowSelect = True
        Me.P_Lista.GridLines = True
        Me.P_Lista.HideSelection = False
        Me.P_Lista.Location = New System.Drawing.Point(14, 36)
        Me.P_Lista.Name = "P_Lista"
        Me.P_Lista.Size = New System.Drawing.Size(360, 301)
        Me.P_Lista.TabIndex = 1
        Me.P_Lista.UseCompatibleStateImageBehavior = False
        Me.P_Lista.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Ponto"
        Me.ColumnHeader1.Width = 76
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Coord. X"
        Me.ColumnHeader2.Width = 140
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Coord. Y"
        Me.ColumnHeader3.Width = 140
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.LightGray
        Me.Label1.Location = New System.Drawing.Point(11, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Lista de pontos da geometria:"
        '
        'L_Aba
        '
        Me.L_Aba.BackColor = System.Drawing.Color.DimGray
        Me.L_Aba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.L_Aba.Controls.Add(Me.L_Cadastrar)
        Me.L_Aba.Controls.Add(Me.L_Editar)
        Me.L_Aba.Controls.Add(Me.L_Remover)
        Me.L_Aba.Controls.Add(Me.L_Ponto2)
        Me.L_Aba.Controls.Add(Me.L_Ponto1)
        Me.L_Aba.Controls.Add(Me.Label5)
        Me.L_Aba.Controls.Add(Me.Label6)
        Me.L_Aba.Controls.Add(Me.Label7)
        Me.L_Aba.Controls.Add(Me.L_Lista)
        Me.L_Aba.Controls.Add(Me.Label8)
        Me.L_Aba.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Aba.ForeColor = System.Drawing.Color.White
        Me.L_Aba.Location = New System.Drawing.Point(4, 39)
        Me.L_Aba.Margin = New System.Windows.Forms.Padding(5)
        Me.L_Aba.Name = "L_Aba"
        Me.L_Aba.Padding = New System.Windows.Forms.Padding(4)
        Me.L_Aba.Size = New System.Drawing.Size(391, 465)
        Me.L_Aba.TabIndex = 1
        Me.L_Aba.Text = "Linhas"
        '
        'L_Cadastrar
        '
        Me.L_Cadastrar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Cadastrar.Location = New System.Drawing.Point(291, 427)
        Me.L_Cadastrar.Name = "L_Cadastrar"
        Me.L_Cadastrar.Size = New System.Drawing.Size(83, 23)
        Me.L_Cadastrar.TabIndex = 30
        Me.L_Cadastrar.Text = "Cadastrar"
        Me.L_Cadastrar.UseVisualStyleBackColor = True
        '
        'L_Editar
        '
        Me.L_Editar.Enabled = False
        Me.L_Editar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Editar.Location = New System.Drawing.Point(203, 343)
        Me.L_Editar.Name = "L_Editar"
        Me.L_Editar.Size = New System.Drawing.Size(171, 25)
        Me.L_Editar.TabIndex = 27
        Me.L_Editar.Text = "Editar"
        Me.L_Editar.UseVisualStyleBackColor = True
        '
        'L_Remover
        '
        Me.L_Remover.Enabled = False
        Me.L_Remover.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Remover.Location = New System.Drawing.Point(14, 343)
        Me.L_Remover.Name = "L_Remover"
        Me.L_Remover.Size = New System.Drawing.Size(183, 25)
        Me.L_Remover.TabIndex = 26
        Me.L_Remover.Text = "Remover"
        Me.L_Remover.UseVisualStyleBackColor = True
        '
        'L_Ponto2
        '
        Me.L_Ponto2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.L_Ponto2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.L_Ponto2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Ponto2.FormattingEnabled = True
        Me.L_Ponto2.Location = New System.Drawing.Point(154, 427)
        Me.L_Ponto2.Name = "L_Ponto2"
        Me.L_Ponto2.Size = New System.Drawing.Size(129, 23)
        Me.L_Ponto2.TabIndex = 25
        '
        'L_Ponto1
        '
        Me.L_Ponto1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.L_Ponto1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.L_Ponto1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Ponto1.FormattingEnabled = True
        Me.L_Ponto1.Location = New System.Drawing.Point(14, 427)
        Me.L_Ponto1.Name = "L_Ponto1"
        Me.L_Ponto1.Size = New System.Drawing.Size(129, 23)
        Me.L_Ponto1.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(151, 409)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 15)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Ponto 2:"
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label6.Location = New System.Drawing.Point(11, 409)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Ponto 1:"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.LightGray
        Me.Label7.Location = New System.Drawing.Point(11, 386)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(363, 17)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Cadastrar nova linha:"
        '
        'L_Lista
        '
        Me.L_Lista.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
        Me.L_Lista.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.L_Lista.FullRowSelect = True
        Me.L_Lista.GridLines = True
        Me.L_Lista.HideSelection = False
        Me.L_Lista.Location = New System.Drawing.Point(14, 36)
        Me.L_Lista.Name = "L_Lista"
        Me.L_Lista.Size = New System.Drawing.Size(360, 301)
        Me.L_Lista.TabIndex = 15
        Me.L_Lista.UseCompatibleStateImageBehavior = False
        Me.L_Lista.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Linha"
        Me.ColumnHeader4.Width = 76
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Ponto 1"
        Me.ColumnHeader5.Width = 140
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Ponto 2"
        Me.ColumnHeader6.Width = 140
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.LightGray
        Me.Label8.Location = New System.Drawing.Point(11, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(163, 15)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Lista de linhas da geometria:"
        '
        'F_Aba
        '
        Me.F_Aba.BackColor = System.Drawing.Color.DimGray
        Me.F_Aba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.F_Aba.Controls.Add(Me.F_DetectarFronteiras)
        Me.F_Aba.Controls.Add(Me.Label11)
        Me.F_Aba.Controls.Add(Me.F_Lista)
        Me.F_Aba.Controls.Add(Me.Label12)
        Me.F_Aba.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F_Aba.Location = New System.Drawing.Point(4, 39)
        Me.F_Aba.Margin = New System.Windows.Forms.Padding(5)
        Me.F_Aba.Name = "F_Aba"
        Me.F_Aba.Padding = New System.Windows.Forms.Padding(4)
        Me.F_Aba.Size = New System.Drawing.Size(391, 465)
        Me.F_Aba.TabIndex = 2
        Me.F_Aba.Text = "Fronteiras"
        '
        'F_DetectarFronteiras
        '
        Me.F_DetectarFronteiras.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F_DetectarFronteiras.Location = New System.Drawing.Point(14, 425)
        Me.F_DetectarFronteiras.Name = "F_DetectarFronteiras"
        Me.F_DetectarFronteiras.Size = New System.Drawing.Size(360, 25)
        Me.F_DetectarFronteiras.TabIndex = 44
        Me.F_DetectarFronteiras.Text = "DETECTAR FRONTEIRAS AUTOMATICAMENTE"
        Me.F_DetectarFronteiras.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.LightGray
        Me.Label11.Location = New System.Drawing.Point(11, 401)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(363, 17)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Cadastrar fronteiras:"
        '
        'F_Lista
        '
        Me.F_Lista.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader7, Me.ColumnHeader8})
        Me.F_Lista.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.F_Lista.FullRowSelect = True
        Me.F_Lista.GridLines = True
        Me.F_Lista.HideSelection = False
        Me.F_Lista.Location = New System.Drawing.Point(14, 36)
        Me.F_Lista.Name = "F_Lista"
        Me.F_Lista.Size = New System.Drawing.Size(360, 345)
        Me.F_Lista.TabIndex = 29
        Me.F_Lista.UseCompatibleStateImageBehavior = False
        Me.F_Lista.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Fronteira"
        Me.ColumnHeader7.Width = 76
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Quantidade de Linhas"
        Me.ColumnHeader8.Width = 280
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.LightGray
        Me.Label12.Location = New System.Drawing.Point(11, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(187, 15)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Lista de fronteiras da geometria:"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowMerge = False
        Me.ToolStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ToolStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bImportar, Me.ToolStripButton1, Me.bSair, Me.ToolStripLabel1, Me.lStatus})
        Me.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(399, 74)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'bImportar
        '
        Me.bImportar.ForeColor = System.Drawing.SystemColors.Window
        Me.bImportar.Image = Global.Ignis.My.Resources.Resources.Sync
        Me.bImportar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bImportar.Margin = New System.Windows.Forms.Padding(3, 3, 0, 2)
        Me.bImportar.Name = "bImportar"
        Me.bImportar.Padding = New System.Windows.Forms.Padding(9, 6, 5, 6)
        Me.bImportar.Size = New System.Drawing.Size(159, 32)
        Me.bImportar.Text = " Importar Arquivo DXF"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.ForeColor = System.Drawing.SystemColors.Window
        Me.ToolStripButton1.Image = Global.Ignis.My.Resources.Resources._Erase
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Margin = New System.Windows.Forms.Padding(3, 3, 0, 2)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Padding = New System.Windows.Forms.Padding(9, 6, 5, 6)
        Me.ToolStripButton1.Size = New System.Drawing.Size(112, 32)
        Me.ToolStripButton1.Text = " Limpar Tudo"
        '
        'bSair
        '
        Me.bSair.ForeColor = System.Drawing.SystemColors.Window
        Me.bSair.Image = Global.Ignis.My.Resources.Resources._Exit
        Me.bSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bSair.Margin = New System.Windows.Forms.Padding(3, 3, 0, 2)
        Me.bSair.Name = "bSair"
        Me.bSair.Padding = New System.Windows.Forms.Padding(9, 6, 5, 6)
        Me.bSair.Size = New System.Drawing.Size(114, 32)
        Me.bSair.Text = " Sair do Editor"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel1.Margin = New System.Windows.Forms.Padding(3, 1, 0, 2)
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Padding = New System.Windows.Forms.Padding(10, 10, 0, 9)
        Me.ToolStripLabel1.Size = New System.Drawing.Size(87, 34)
        Me.ToolStripLabel1.Text = "Status Atual:"
        '
        'lStatus
        '
        Me.lStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lStatus.ForeColor = System.Drawing.Color.OrangeRed
        Me.lStatus.Name = "lStatus"
        Me.lStatus.Padding = New System.Windows.Forms.Padding(0, 10, 0, 9)
        Me.lStatus.Size = New System.Drawing.Size(126, 34)
        Me.lStatus.Text = "Geometria Indefinida"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.flatTabControl1)
        Me.SplitContainer3.Size = New System.Drawing.Size(399, 581)
        Me.SplitContainer3.SplitterDistance = 72
        Me.SplitContainer3.SplitterWidth = 1
        Me.SplitContainer3.TabIndex = 4
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
        Me.splitContainer1.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.BackColor = System.Drawing.Color.Black
        Me.splitContainer1.Size = New System.Drawing.Size(984, 581)
        Me.splitContainer1.SplitterDistance = 399
        Me.splitContainer1.SplitterWidth = 1
        Me.splitContainer1.TabIndex = 2
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Image = Global.Ignis.My.Resources.Resources.Up
        Me.Button3.Location = New System.Drawing.Point(0, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(43, 25)
        Me.Button3.TabIndex = 9
        Me.Button3.UseVisualStyleBackColor = True
        '
        'EditarGeometria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(984, 581)
        Me.Controls.Add(Me.splitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 620)
        Me.Name = "EditarGeometria"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Geometria do Problema"
        Me.flatTabControl1.ResumeLayout(False)
        Me.P_Aba.ResumeLayout(False)
        Me.P_Aba.PerformLayout()
        Me.L_Aba.ResumeLayout(False)
        Me.L_Aba.PerformLayout()
        Me.F_Aba.ResumeLayout(False)
        Me.F_Aba.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.splitContainer1.Panel1.ResumeLayout(False)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents flatTabControl1 As MeshExplorer.Controls.DarkTabControl
    Private WithEvents P_Aba As TabPage
    Private WithEvents L_Aba As TabPage
    Private WithEvents F_Aba As TabPage
    Friend WithEvents P_Lista As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents P_CoordY As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents P_CoordX As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents L_Lista As ListView
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents Label8 As Label
    Friend WithEvents L_Ponto2 As ComboBox
    Friend WithEvents L_Ponto1 As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents F_Lista As ListView
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents Label12 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents bImportar As ToolStripButton
    Private WithEvents P_Remover As MeshExplorer.Controls.DarkButton
    Private WithEvents P_Editar As MeshExplorer.Controls.DarkButton
    Private WithEvents P_Cadastrar As MeshExplorer.Controls.DarkButton
    Private WithEvents L_Cadastrar As MeshExplorer.Controls.DarkButton
    Private WithEvents L_Editar As MeshExplorer.Controls.DarkButton
    Private WithEvents L_Remover As MeshExplorer.Controls.DarkButton
    Friend WithEvents SplitContainer3 As SplitContainer
    Private WithEvents splitContainer1 As SplitContainer
    Friend WithEvents bSair As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents lStatus As ToolStripLabel
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Private WithEvents F_DetectarFronteiras As MeshExplorer.Controls.DarkButton
End Class
