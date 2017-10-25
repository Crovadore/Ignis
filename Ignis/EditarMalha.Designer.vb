<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditarMalha
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
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DarkButton1 = New MeshExplorer.Controls.DarkButton()
        Me.btnSmooth = New MeshExplorer.Controls.DarkButton()
        Me.btnMesh = New MeshExplorer.Controls.DarkButton()
        Me.meshControlView = New MeshExplorer.Views.MeshControlView()
        Me.TempoLimite = New System.Windows.Forms.Timer(Me.components)
        Me.VerificaStatus = New System.Windows.Forms.Timer(Me.components)
        Me.ExpandableGroupbox1 = New Ignis.ExpandableGroupbox()
        Me.StatisticView1 = New MeshExplorer.Views.StatisticView()
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.ExpandableGroupbox1.SuspendLayout()
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
        Me.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.splitContainer1.Panel1.Controls.Add(Me.ExpandableGroupbox1)
        Me.splitContainer1.Panel1.Controls.Add(Me.DarkButton1)
        Me.splitContainer1.Panel1.Controls.Add(Me.btnSmooth)
        Me.splitContainer1.Panel1.Controls.Add(Me.btnMesh)
        Me.splitContainer1.Panel1.Controls.Add(Me.meshControlView)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.BackColor = System.Drawing.Color.Black
        Me.splitContainer1.Size = New System.Drawing.Size(984, 616)
        Me.splitContainer1.SplitterDistance = 280
        Me.splitContainer1.SplitterWidth = 1
        Me.splitContainer1.TabIndex = 1
        '
        'DarkButton1
        '
        Me.DarkButton1.Location = New System.Drawing.Point(12, 274)
        Me.DarkButton1.Name = "DarkButton1"
        Me.DarkButton1.Size = New System.Drawing.Size(257, 23)
        Me.DarkButton1.TabIndex = 18
        Me.DarkButton1.Text = "Limpar Malha"
        Me.DarkButton1.UseVisualStyleBackColor = True
        '
        'btnSmooth
        '
        Me.btnSmooth.Enabled = False
        Me.btnSmooth.Location = New System.Drawing.Point(139, 242)
        Me.btnSmooth.Name = "btnSmooth"
        Me.btnSmooth.Size = New System.Drawing.Size(130, 23)
        Me.btnSmooth.TabIndex = 16
        Me.btnSmooth.Text = "Suavizar"
        Me.btnSmooth.UseVisualStyleBackColor = True
        '
        'btnMesh
        '
        Me.btnMesh.Location = New System.Drawing.Point(12, 242)
        Me.btnMesh.Name = "btnMesh"
        Me.btnMesh.Size = New System.Drawing.Size(121, 23)
        Me.btnMesh.TabIndex = 17
        Me.btnMesh.Text = "Gerar Malha"
        Me.btnMesh.UseVisualStyleBackColor = True
        '
        'meshControlView
        '
        Me.meshControlView.BackColor = System.Drawing.Color.DimGray
        Me.meshControlView.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.meshControlView.ForeColor = System.Drawing.Color.DarkGray
        Me.meshControlView.Location = New System.Drawing.Point(4, 5)
        Me.meshControlView.Name = "meshControlView"
        Me.meshControlView.Size = New System.Drawing.Size(272, 606)
        Me.meshControlView.TabIndex = 15
        '
        'TempoLimite
        '
        Me.TempoLimite.Interval = 10000
        '
        'VerificaStatus
        '
        '
        'ExpandableGroupbox1
        '
        Me.ExpandableGroupbox1.BackColor = System.Drawing.Color.DimGray
        Me.ExpandableGroupbox1.Caption = "Estatísticas da Malha"
        Me.ExpandableGroupbox1.CaptionColor = System.Drawing.SystemColors.Menu
        Me.ExpandableGroupbox1.Controls.Add(Me.StatisticView1)
        Me.ExpandableGroupbox1.Expanded = False
        Me.ExpandableGroupbox1.ExpandedSize = New System.Drawing.Size(257, 289)
        Me.ExpandableGroupbox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpandableGroupbox1.ForeColor = System.Drawing.Color.White
        Me.ExpandableGroupbox1.HeaderClickExpand = True
        Me.ExpandableGroupbox1.Location = New System.Drawing.Point(12, 311)
        Me.ExpandableGroupbox1.Name = "ExpandableGroupbox1"
        Me.ExpandableGroupbox1.Size = New System.Drawing.Size(257, 21)
        Me.ExpandableGroupbox1.TabIndex = 20
        '
        'StatisticView1
        '
        Me.StatisticView1.BackColor = System.Drawing.Color.DimGray
        Me.StatisticView1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatisticView1.ForeColor = System.Drawing.Color.DarkGray
        Me.StatisticView1.Location = New System.Drawing.Point(8, 24)
        Me.StatisticView1.Name = "StatisticView1"
        Me.StatisticView1.Size = New System.Drawing.Size(242, 259)
        Me.StatisticView1.TabIndex = 19
        '
        'EditarMalha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 616)
        Me.Controls.Add(Me.splitContainer1)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1000, 655)
        Me.Name = "EditarMalha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Malha do Problema (Triangle.NET)"
        Me.splitContainer1.Panel1.ResumeLayout(False)
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.ResumeLayout(False)
        Me.ExpandableGroupbox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents splitContainer1 As SplitContainer
    Private WithEvents StatisticView1 As MeshExplorer.Views.StatisticView
    Private WithEvents DarkButton1 As MeshExplorer.Controls.DarkButton
    Private WithEvents btnSmooth As MeshExplorer.Controls.DarkButton
    Private WithEvents btnMesh As MeshExplorer.Controls.DarkButton
    Private WithEvents meshControlView As MeshExplorer.Views.MeshControlView
    Friend WithEvents ExpandableGroupbox1 As ExpandableGroupbox
    Friend WithEvents TempoLimite As Timer
    Friend WithEvents VerificaStatus As Timer
End Class
