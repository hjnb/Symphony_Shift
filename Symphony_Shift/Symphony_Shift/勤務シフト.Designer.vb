<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 勤務シフト
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
        Me.components = New System.ComponentModel.Container()
        Me.YmdBox1 = New ymdBox.ymdBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.btnTouroku = New System.Windows.Forms.Button()
        Me.btnSakujo = New System.Windows.Forms.Button()
        Me.btnInnsatu = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnKuria = New System.Windows.Forms.Button()
        Me.lblNissuu = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNamae = New System.Windows.Forms.Label()
        Me.DataGridView1 = New Symphony_Shift.ShiftDgv(Me.components)
        Me.btnKousin = New System.Windows.Forms.Button()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'YmdBox1
        '
        Me.YmdBox1.boxType = 7
        Me.YmdBox1.DateText = ""
        Me.YmdBox1.EraLabelText = "H30"
        Me.YmdBox1.EraText = ""
        Me.YmdBox1.Location = New System.Drawing.Point(49, 38)
        Me.YmdBox1.MonthLabelText = "08"
        Me.YmdBox1.MonthText = ""
        Me.YmdBox1.Name = "YmdBox1"
        Me.YmdBox1.Size = New System.Drawing.Size(120, 46)
        Me.YmdBox1.TabIndex = 0
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(729, 51)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(10, 10)
        Me.DataGridView2.TabIndex = 2
        '
        'btnTouroku
        '
        Me.btnTouroku.Location = New System.Drawing.Point(675, 44)
        Me.btnTouroku.Name = "btnTouroku"
        Me.btnTouroku.Size = New System.Drawing.Size(64, 30)
        Me.btnTouroku.TabIndex = 3
        Me.btnTouroku.Text = "登録"
        Me.btnTouroku.UseVisualStyleBackColor = True
        '
        'btnSakujo
        '
        Me.btnSakujo.Location = New System.Drawing.Point(757, 44)
        Me.btnSakujo.Name = "btnSakujo"
        Me.btnSakujo.Size = New System.Drawing.Size(64, 30)
        Me.btnSakujo.TabIndex = 4
        Me.btnSakujo.Text = "削除"
        Me.btnSakujo.UseVisualStyleBackColor = True
        '
        'btnInnsatu
        '
        Me.btnInnsatu.Location = New System.Drawing.Point(836, 44)
        Me.btnInnsatu.Name = "btnInnsatu"
        Me.btnInnsatu.Size = New System.Drawing.Size(64, 30)
        Me.btnInnsatu.TabIndex = 5
        Me.btnInnsatu.Text = "印刷"
        Me.btnInnsatu.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(708, 365)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "0 : 日　　1 : 早　　2 : 遅　　3 : 休　　4 : 有　　5 : 半　　6 : 研"
        '
        'btnKuria
        '
        Me.btnKuria.Location = New System.Drawing.Point(675, 57)
        Me.btnKuria.Name = "btnKuria"
        Me.btnKuria.Size = New System.Drawing.Size(10, 10)
        Me.btnKuria.TabIndex = 8
        Me.btnKuria.Text = "クリア"
        Me.btnKuria.UseVisualStyleBackColor = True
        '
        'lblNissuu
        '
        Me.lblNissuu.AutoSize = True
        Me.lblNissuu.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNissuu.ForeColor = System.Drawing.Color.Blue
        Me.lblNissuu.Location = New System.Drawing.Point(974, 54)
        Me.lblNissuu.Name = "lblNissuu"
        Me.lblNissuu.Size = New System.Drawing.Size(24, 13)
        Me.lblNissuu.TabIndex = 9
        Me.lblNissuu.Text = "0.0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(927, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "公休"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(971, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "▲"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(971, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "▼"
        '
        'lblNamae
        '
        Me.lblNamae.AutoSize = True
        Me.lblNamae.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblNamae.ForeColor = System.Drawing.Color.Blue
        Me.lblNamae.Location = New System.Drawing.Point(178, 51)
        Me.lblNamae.Name = "lblNamae"
        Me.lblNamae.Size = New System.Drawing.Size(28, 19)
        Me.lblNamae.TabIndex = 13
        Me.lblNamae.Text = "名"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(37, 90)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(978, 263)
        Me.DataGridView1.TabIndex = 6
        '
        'btnKousin
        '
        Me.btnKousin.Location = New System.Drawing.Point(691, 58)
        Me.btnKousin.Name = "btnKousin"
        Me.btnKousin.Size = New System.Drawing.Size(10, 10)
        Me.btnKousin.TabIndex = 14
        Me.btnKousin.Text = "更新"
        Me.btnKousin.UseVisualStyleBackColor = True
        '
        '勤務シフト
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1425, 710)
        Me.Controls.Add(Me.btnTouroku)
        Me.Controls.Add(Me.btnKousin)
        Me.Controls.Add(Me.lblNamae)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblNissuu)
        Me.Controls.Add(Me.btnKuria)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnInnsatu)
        Me.Controls.Add(Me.btnSakujo)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.YmdBox1)
        Me.Name = "勤務シフト"
        Me.Text = "勤務シフト"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents YmdBox1 As ymdBox.ymdBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents btnTouroku As System.Windows.Forms.Button
    Friend WithEvents btnSakujo As System.Windows.Forms.Button
    Friend WithEvents btnInnsatu As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As Symphony_Shift.ShiftDgv
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnKuria As System.Windows.Forms.Button
    Friend WithEvents lblNissuu As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNamae As System.Windows.Forms.Label
    Friend WithEvents btnKousin As System.Windows.Forms.Button
End Class
