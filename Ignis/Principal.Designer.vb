<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.tMax = New System.Windows.Forms.Label()
        Me.tMin = New System.Windows.Forms.Label()
        Me.PlotArea = New System.Windows.Forms.Panel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ListaDeImagens = New System.Windows.Forms.ImageList(Me.components)
        Me.BarraDeStatus = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusDoProblema = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuPrincipal = New System.Windows.Forms.MenuStrip()
        Me.ArquivoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FecharSimulaçãoAtualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SairDoIgnisToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConfiguraçõesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SimulaçãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalvarImagemToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResultadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjudaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SobreOIgnisToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Marcador = New System.Windows.Forms.Panel()
        Me.tAtual = New System.Windows.Forms.Label()
        Me.MenuSecundario = New System.Windows.Forms.ToolStrip()
        Me.bNovaSimulacao = New System.Windows.Forms.ToolStripButton()
        Me.bAbrir = New System.Windows.Forms.ToolStripButton()
        Me.bSalvar = New System.Windows.Forms.ToolStripSplitButton()
        Me.SalvarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalvarComoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bIniciarSimulacao = New System.Windows.Forms.ToolStripButton()
        Me.CMS_Renomear = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CMS_Renomear_R = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirArquivoIgnis = New System.Windows.Forms.OpenFileDialog()
        Me.SalvarImagem = New System.Windows.Forms.SaveFileDialog()
        Me.SalvarSimulacao = New System.Windows.Forms.SaveFileDialog()
        Me.Escala = New System.Windows.Forms.PictureBox()
        Me.BarraDeStatus.SuspendLayout()
        Me.MenuPrincipal.SuspendLayout()
        Me.MenuSecundario.SuspendLayout()
        Me.CMS_Renomear.SuspendLayout()
        CType(Me.Escala, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tMax
        '
        Me.tMax.Location = New System.Drawing.Point(735, 608)
        Me.tMax.Name = "tMax"
        Me.tMax.Size = New System.Drawing.Size(100, 23)
        Me.tMax.TabIndex = 48
        Me.tMax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tMin
        '
        Me.tMin.Location = New System.Drawing.Point(332, 608)
        Me.tMin.Name = "tMin"
        Me.tMin.Size = New System.Drawing.Size(100, 23)
        Me.tMin.TabIndex = 47
        Me.tMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PlotArea
        '
        Me.PlotArea.BackColor = System.Drawing.SystemColors.Window
        Me.PlotArea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PlotArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PlotArea.Location = New System.Drawing.Point(335, 59)
        Me.PlotArea.Name = "PlotArea"
        Me.PlotArea.Size = New System.Drawing.Size(500, 500)
        Me.PlotArea.TabIndex = 45
        '
        'TreeView1
        '
        Me.TreeView1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.Indent = 30
        Me.TreeView1.ItemHeight = 25
        Me.TreeView1.Location = New System.Drawing.Point(12, 59)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(310, 546)
        Me.TreeView1.StateImageList = Me.ListaDeImagens
        Me.TreeView1.TabIndex = 50
        '
        'ListaDeImagens
        '
        Me.ListaDeImagens.ImageStream = CType(resources.GetObject("ListaDeImagens.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListaDeImagens.TransparentColor = System.Drawing.Color.Transparent
        Me.ListaDeImagens.Images.SetKeyName(0, "Apply.png")
        Me.ListaDeImagens.Images.SetKeyName(1, "Danger.png")
        Me.ListaDeImagens.Images.SetKeyName(2, "Delete.png")
        Me.ListaDeImagens.Images.SetKeyName(3, "Disaster.png")
        Me.ListaDeImagens.Images.SetKeyName(4, "Erase.png")
        Me.ListaDeImagens.Images.SetKeyName(5, "Error.png")
        Me.ListaDeImagens.Images.SetKeyName(6, "Info.png")
        Me.ListaDeImagens.Images.SetKeyName(7, "Lightning.png")
        Me.ListaDeImagens.Images.SetKeyName(8, "No.png")
        Me.ListaDeImagens.Images.SetKeyName(9, "No-entry.png")
        Me.ListaDeImagens.Images.SetKeyName(10, "OK.png")
        Me.ListaDeImagens.Images.SetKeyName(11, "question-mark-icon-41629.png")
        Me.ListaDeImagens.Images.SetKeyName(12, "question-mark-icon-41653.png")
        Me.ListaDeImagens.Images.SetKeyName(13, "Question.png")
        '
        'BarraDeStatus
        '
        Me.BarraDeStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.StatusDoProblema})
        Me.BarraDeStatus.Location = New System.Drawing.Point(0, 643)
        Me.BarraDeStatus.Name = "BarraDeStatus"
        Me.BarraDeStatus.Size = New System.Drawing.Size(847, 27)
        Me.BarraDeStatus.SizingGrip = False
        Me.BarraDeStatus.Stretch = False
        Me.BarraDeStatus.TabIndex = 52
        Me.BarraDeStatus.Text = "BarraDeStatus"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(3)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Padding = New System.Windows.Forms.Padding(3)
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(48, 21)
        Me.ToolStripStatusLabel1.Text = "Status:"
        '
        'StatusDoProblema
        '
        Me.StatusDoProblema.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusDoProblema.ForeColor = System.Drawing.Color.Coral
        Me.StatusDoProblema.Name = "StatusDoProblema"
        Me.StatusDoProblema.Size = New System.Drawing.Size(137, 22)
        Me.StatusDoProblema.Text = "Parâmetros Pendentes!"
        '
        'MenuPrincipal
        '
        Me.MenuPrincipal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.MenuPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArquivoToolStripMenuItem1, Me.EditarToolStripMenuItem1, Me.SimulaçãoToolStripMenuItem, Me.AjudaToolStripMenuItem1})
        Me.MenuPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.MenuPrincipal.Name = "MenuPrincipal"
        Me.MenuPrincipal.Size = New System.Drawing.Size(847, 24)
        Me.MenuPrincipal.TabIndex = 53
        Me.MenuPrincipal.Text = "MenuPrincipal"
        '
        'ArquivoToolStripMenuItem1
        '
        Me.ArquivoToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FecharSimulaçãoAtualToolStripMenuItem, Me.SairDoIgnisToolStripMenuItem1})
        Me.ArquivoToolStripMenuItem1.Name = "ArquivoToolStripMenuItem1"
        Me.ArquivoToolStripMenuItem1.Size = New System.Drawing.Size(61, 20)
        Me.ArquivoToolStripMenuItem1.Text = "Arquivo"
        '
        'FecharSimulaçãoAtualToolStripMenuItem
        '
        Me.FecharSimulaçãoAtualToolStripMenuItem.Enabled = False
        Me.FecharSimulaçãoAtualToolStripMenuItem.Image = Global.Ignis.My.Resources.Resources._Erase
        Me.FecharSimulaçãoAtualToolStripMenuItem.Name = "FecharSimulaçãoAtualToolStripMenuItem"
        Me.FecharSimulaçãoAtualToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.FecharSimulaçãoAtualToolStripMenuItem.Text = "Fechar Simulação Atual"
        '
        'SairDoIgnisToolStripMenuItem1
        '
        Me.SairDoIgnisToolStripMenuItem1.Image = Global.Ignis.My.Resources.Resources._Exit
        Me.SairDoIgnisToolStripMenuItem1.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.SairDoIgnisToolStripMenuItem1.Name = "SairDoIgnisToolStripMenuItem1"
        Me.SairDoIgnisToolStripMenuItem1.Size = New System.Drawing.Size(198, 22)
        Me.SairDoIgnisToolStripMenuItem1.Text = "Sair do Ignis"
        '
        'EditarToolStripMenuItem1
        '
        Me.EditarToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfiguraçõesToolStripMenuItem1})
        Me.EditarToolStripMenuItem1.Name = "EditarToolStripMenuItem1"
        Me.EditarToolStripMenuItem1.Size = New System.Drawing.Size(49, 20)
        Me.EditarToolStripMenuItem1.Text = "Editar"
        '
        'ConfiguraçõesToolStripMenuItem1
        '
        Me.ConfiguraçõesToolStripMenuItem1.Image = Global.Ignis.My.Resources.Resources.Application
        Me.ConfiguraçõesToolStripMenuItem1.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.ConfiguraçõesToolStripMenuItem1.Name = "ConfiguraçõesToolStripMenuItem1"
        Me.ConfiguraçõesToolStripMenuItem1.Size = New System.Drawing.Size(151, 22)
        Me.ConfiguraçõesToolStripMenuItem1.Text = "Configurações"
        '
        'SimulaçãoToolStripMenuItem
        '
        Me.SimulaçãoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalvarImagemToolStripMenuItem1, Me.ResultadosToolStripMenuItem})
        Me.SimulaçãoToolStripMenuItem.Name = "SimulaçãoToolStripMenuItem"
        Me.SimulaçãoToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.SimulaçãoToolStripMenuItem.Text = "Simulação"
        '
        'SalvarImagemToolStripMenuItem1
        '
        Me.SalvarImagemToolStripMenuItem1.Enabled = False
        Me.SalvarImagemToolStripMenuItem1.Image = Global.Ignis.My.Resources.Resources.Save1
        Me.SalvarImagemToolStripMenuItem1.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.SalvarImagemToolStripMenuItem1.Name = "SalvarImagemToolStripMenuItem1"
        Me.SalvarImagemToolStripMenuItem1.Size = New System.Drawing.Size(192, 22)
        Me.SalvarImagemToolStripMenuItem1.Text = "Salvar Imagem"
        '
        'ResultadosToolStripMenuItem
        '
        Me.ResultadosToolStripMenuItem.Enabled = False
        Me.ResultadosToolStripMenuItem.Image = Global.Ignis.My.Resources.Resources.Report
        Me.ResultadosToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.ResultadosToolStripMenuItem.Name = "ResultadosToolStripMenuItem"
        Me.ResultadosToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.ResultadosToolStripMenuItem.Text = "Resultados Numéricos"
        '
        'AjudaToolStripMenuItem1
        '
        Me.AjudaToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SobreOIgnisToolStripMenuItem1})
        Me.AjudaToolStripMenuItem1.Name = "AjudaToolStripMenuItem1"
        Me.AjudaToolStripMenuItem1.Size = New System.Drawing.Size(50, 20)
        Me.AjudaToolStripMenuItem1.Text = "Ajuda"
        '
        'SobreOIgnisToolStripMenuItem1
        '
        Me.SobreOIgnisToolStripMenuItem1.Image = Global.Ignis.My.Resources.Resources.About
        Me.SobreOIgnisToolStripMenuItem1.Margin = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.SobreOIgnisToolStripMenuItem1.Name = "SobreOIgnisToolStripMenuItem1"
        Me.SobreOIgnisToolStripMenuItem1.Size = New System.Drawing.Size(142, 22)
        Me.SobreOIgnisToolStripMenuItem1.Text = "Sobre o Ignis"
        '
        'Marcador
        '
        Me.Marcador.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Marcador.Location = New System.Drawing.Point(428, 575)
        Me.Marcador.Name = "Marcador"
        Me.Marcador.Size = New System.Drawing.Size(2, 30)
        Me.Marcador.TabIndex = 54
        Me.Marcador.Visible = False
        '
        'tAtual
        '
        Me.tAtual.BackColor = System.Drawing.Color.Transparent
        Me.tAtual.Location = New System.Drawing.Point(385, 608)
        Me.tAtual.Name = "tAtual"
        Me.tAtual.Size = New System.Drawing.Size(90, 23)
        Me.tAtual.TabIndex = 55
        Me.tAtual.Text = "T"
        Me.tAtual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.tAtual.Visible = False
        '
        'MenuSecundario
        '
        Me.MenuSecundario.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.MenuSecundario.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bNovaSimulacao, Me.bAbrir, Me.bSalvar, Me.bIniciarSimulacao})
        Me.MenuSecundario.Location = New System.Drawing.Point(0, 24)
        Me.MenuSecundario.Name = "MenuSecundario"
        Me.MenuSecundario.Size = New System.Drawing.Size(847, 31)
        Me.MenuSecundario.Stretch = True
        Me.MenuSecundario.TabIndex = 56
        Me.MenuSecundario.Text = "MenuSecundario"
        '
        'bNovaSimulacao
        '
        Me.bNovaSimulacao.Image = Global.Ignis.My.Resources.Resources.New_document
        Me.bNovaSimulacao.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bNovaSimulacao.Margin = New System.Windows.Forms.Padding(6, 1, 0, 2)
        Me.bNovaSimulacao.Name = "bNovaSimulacao"
        Me.bNovaSimulacao.Padding = New System.Windows.Forms.Padding(4)
        Me.bNovaSimulacao.Size = New System.Drawing.Size(121, 28)
        Me.bNovaSimulacao.Text = "Nova Simulação"
        Me.bNovaSimulacao.ToolTipText = "Iniciar nova simulação"
        '
        'bAbrir
        '
        Me.bAbrir.Image = Global.Ignis.My.Resources.Resources.Folder
        Me.bAbrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bAbrir.Name = "bAbrir"
        Me.bAbrir.Padding = New System.Windows.Forms.Padding(4)
        Me.bAbrir.Size = New System.Drawing.Size(64, 28)
        Me.bAbrir.Text = " Abrir"
        Me.bAbrir.ToolTipText = "Abrir simulação existente (arquivo .ignis)"
        '
        'bSalvar
        '
        Me.bSalvar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SalvarToolStripMenuItem, Me.SalvarComoToolStripMenuItem})
        Me.bSalvar.Enabled = False
        Me.bSalvar.Image = Global.Ignis.My.Resources.Resources.Save
        Me.bSalvar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bSalvar.Name = "bSalvar"
        Me.bSalvar.Padding = New System.Windows.Forms.Padding(4)
        Me.bSalvar.Size = New System.Drawing.Size(81, 28)
        Me.bSalvar.Text = " Salvar"
        Me.bSalvar.ToolTipText = "Salvar simulação atual"
        '
        'SalvarToolStripMenuItem
        '
        Me.SalvarToolStripMenuItem.Name = "SalvarToolStripMenuItem"
        Me.SalvarToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.SalvarToolStripMenuItem.Text = "Salvar"
        '
        'SalvarComoToolStripMenuItem
        '
        Me.SalvarComoToolStripMenuItem.Name = "SalvarComoToolStripMenuItem"
        Me.SalvarComoToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.SalvarComoToolStripMenuItem.Text = "Salvar como..."
        '
        'bIniciarSimulacao
        '
        Me.bIniciarSimulacao.Enabled = False
        Me.bIniciarSimulacao.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bIniciarSimulacao.Image = Global.Ignis.My.Resources.Resources.Lightning
        Me.bIniciarSimulacao.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.bIniciarSimulacao.Name = "bIniciarSimulacao"
        Me.bIniciarSimulacao.Padding = New System.Windows.Forms.Padding(4)
        Me.bIniciarSimulacao.Size = New System.Drawing.Size(128, 28)
        Me.bIniciarSimulacao.Text = "Iniciar Simulação"
        Me.bIniciarSimulacao.ToolTipText = "Rodar simulação atual"
        '
        'CMS_Renomear
        '
        Me.CMS_Renomear.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMS_Renomear_R})
        Me.CMS_Renomear.Name = "CMS_Editar"
        Me.CMS_Renomear.Size = New System.Drawing.Size(138, 26)
        Me.CMS_Renomear.Text = "CMS_Renomear"
        '
        'CMS_Renomear_R
        '
        Me.CMS_Renomear_R.Name = "CMS_Renomear_R"
        Me.CMS_Renomear_R.Size = New System.Drawing.Size(137, 22)
        Me.CMS_Renomear_R.Text = "Renomear..."
        '
        'AbrirArquivoIgnis
        '
        Me.AbrirArquivoIgnis.DefaultExt = "ignis"
        Me.AbrirArquivoIgnis.Filter = "Arquivos Ignis|*.ignis"
        Me.AbrirArquivoIgnis.Title = "Abrir Simulação Existente"
        '
        'SalvarImagem
        '
        Me.SalvarImagem.AddExtension = False
        Me.SalvarImagem.Filter = "Arquivo PNG|*.png"
        '
        'SalvarSimulacao
        '
        Me.SalvarSimulacao.AddExtension = False
        Me.SalvarSimulacao.Filter = "Arquivo Ignis|*.ignis"
        '
        'Escala
        '
        Me.Escala.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Escala.Location = New System.Drawing.Point(335, 575)
        Me.Escala.Name = "Escala"
        Me.Escala.Size = New System.Drawing.Size(500, 30)
        Me.Escala.TabIndex = 46
        Me.Escala.TabStop = False
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(847, 670)
        Me.Controls.Add(Me.MenuSecundario)
        Me.Controls.Add(Me.Marcador)
        Me.Controls.Add(Me.BarraDeStatus)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.MenuPrincipal)
        Me.Controls.Add(Me.tMax)
        Me.Controls.Add(Me.tMin)
        Me.Controls.Add(Me.Escala)
        Me.Controls.Add(Me.PlotArea)
        Me.Controls.Add(Me.tAtual)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuPrincipal
        Me.MaximizeBox = False
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ignis"
        Me.BarraDeStatus.ResumeLayout(False)
        Me.BarraDeStatus.PerformLayout()
        Me.MenuPrincipal.ResumeLayout(False)
        Me.MenuPrincipal.PerformLayout()
        Me.MenuSecundario.ResumeLayout(False)
        Me.MenuSecundario.PerformLayout()
        Me.CMS_Renomear.ResumeLayout(False)
        CType(Me.Escala, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tMax As Label
    Friend WithEvents tMin As Label
    Friend WithEvents Escala As PictureBox
    Friend WithEvents PlotArea As Panel
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents BarraDeStatus As StatusStrip
    Friend WithEvents ListaDeImagens As ImageList
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents MenuPrincipal As MenuStrip
    Friend WithEvents ArquivoToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ConfiguraçõesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SimulaçãoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalvarImagemToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ResultadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AjudaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SobreOIgnisToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SairDoIgnisToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Marcador As Panel
    Friend WithEvents tAtual As Label
    Friend WithEvents StatusDoProblema As ToolStripStatusLabel
    Friend WithEvents MenuSecundario As ToolStrip
    Friend WithEvents bNovaSimulacao As ToolStripButton
    Friend WithEvents bAbrir As ToolStripButton
    Friend WithEvents bIniciarSimulacao As ToolStripButton
    Friend WithEvents bSalvar As ToolStripSplitButton
    Friend WithEvents SalvarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalvarComoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CMS_Renomear As ContextMenuStrip
    Friend WithEvents CMS_Renomear_R As ToolStripMenuItem
    Friend WithEvents FecharSimulaçãoAtualToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AbrirArquivoIgnis As OpenFileDialog
    Friend WithEvents SalvarImagem As SaveFileDialog
    Friend WithEvents SalvarSimulacao As SaveFileDialog
End Class
