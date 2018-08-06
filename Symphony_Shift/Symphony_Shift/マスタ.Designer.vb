<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class マスタ
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtKana = New System.Windows.Forms.TextBox()
        Me.rbnAri = New System.Windows.Forms.RadioButton()
        Me.rbnNasi = New System.Windows.Forms.RadioButton()
        Me.btnTouroku = New System.Windows.Forms.Button()
        Me.btnSakujo = New System.Windows.Forms.Button()
        Me.btnKuria = New System.Windows.Forms.Button()
        Me.btnKousin = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "職員名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ﾌﾘｶﾞﾅ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "表示"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(24, 137)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(268, 249)
        Me.DataGridView1.TabIndex = 3
        '
        'txtName
        '
        Me.txtName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtName.Location = New System.Drawing.Point(74, 25)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(121, 19)
        Me.txtName.TabIndex = 4
        '
        'txtKana
        '
        Me.txtKana.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtKana.Location = New System.Drawing.Point(74, 63)
        Me.txtKana.Name = "txtKana"
        Me.txtKana.Size = New System.Drawing.Size(121, 19)
        Me.txtKana.TabIndex = 5
        '
        'rbnAri
        '
        Me.rbnAri.AutoSize = True
        Me.rbnAri.Checked = True
        Me.rbnAri.Location = New System.Drawing.Point(74, 104)
        Me.rbnAri.Name = "rbnAri"
        Me.rbnAri.Size = New System.Drawing.Size(35, 16)
        Me.rbnAri.TabIndex = 6
        Me.rbnAri.TabStop = True
        Me.rbnAri.Text = "有"
        Me.rbnAri.UseVisualStyleBackColor = True
        '
        'rbnNasi
        '
        Me.rbnNasi.AutoSize = True
        Me.rbnNasi.Location = New System.Drawing.Point(129, 104)
        Me.rbnNasi.Name = "rbnNasi"
        Me.rbnNasi.Size = New System.Drawing.Size(35, 16)
        Me.rbnNasi.TabIndex = 7
        Me.rbnNasi.Text = "無"
        Me.rbnNasi.UseVisualStyleBackColor = True
        '
        'btnTouroku
        '
        Me.btnTouroku.Location = New System.Drawing.Point(240, 25)
        Me.btnTouroku.Name = "btnTouroku"
        Me.btnTouroku.Size = New System.Drawing.Size(52, 29)
        Me.btnTouroku.TabIndex = 8
        Me.btnTouroku.Text = "登録"
        Me.btnTouroku.UseVisualStyleBackColor = True
        '
        'btnSakujo
        '
        Me.btnSakujo.Location = New System.Drawing.Point(240, 66)
        Me.btnSakujo.Name = "btnSakujo"
        Me.btnSakujo.Size = New System.Drawing.Size(52, 29)
        Me.btnSakujo.TabIndex = 9
        Me.btnSakujo.Text = "削除"
        Me.btnSakujo.UseVisualStyleBackColor = True
        '
        'btnKuria
        '
        Me.btnKuria.Location = New System.Drawing.Point(251, 34)
        Me.btnKuria.Name = "btnKuria"
        Me.btnKuria.Size = New System.Drawing.Size(10, 10)
        Me.btnKuria.TabIndex = 10
        Me.btnKuria.Text = "クリア"
        Me.btnKuria.UseVisualStyleBackColor = True
        '
        'btnKousin
        '
        Me.btnKousin.Location = New System.Drawing.Point(267, 34)
        Me.btnKousin.Name = "btnKousin"
        Me.btnKousin.Size = New System.Drawing.Size(10, 10)
        Me.btnKousin.TabIndex = 11
        Me.btnKousin.Text = "更新"
        Me.btnKousin.UseVisualStyleBackColor = True
        '
        'マスタ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 407)
        Me.Controls.Add(Me.btnTouroku)
        Me.Controls.Add(Me.btnKousin)
        Me.Controls.Add(Me.btnKuria)
        Me.Controls.Add(Me.btnSakujo)
        Me.Controls.Add(Me.rbnNasi)
        Me.Controls.Add(Me.rbnAri)
        Me.Controls.Add(Me.txtKana)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "マスタ"
        Me.Text = "マスタ"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtKana As System.Windows.Forms.TextBox
    Friend WithEvents rbnAri As System.Windows.Forms.RadioButton
    Friend WithEvents rbnNasi As System.Windows.Forms.RadioButton
    Friend WithEvents btnTouroku As System.Windows.Forms.Button
    Friend WithEvents btnSakujo As System.Windows.Forms.Button
    Friend WithEvents btnKuria As System.Windows.Forms.Button
    Friend WithEvents btnKousin As System.Windows.Forms.Button
End Class
