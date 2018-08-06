<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTopform
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
        Me.btnKinnmu = New System.Windows.Forms.Button()
        Me.btnMasuta = New System.Windows.Forms.Button()
        Me.rbnPreview = New System.Windows.Forms.RadioButton()
        Me.rbnInnsatu = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'btnKinnmu
        '
        Me.btnKinnmu.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnKinnmu.ForeColor = System.Drawing.Color.Blue
        Me.btnKinnmu.Location = New System.Drawing.Point(28, 22)
        Me.btnKinnmu.Name = "btnKinnmu"
        Me.btnKinnmu.Size = New System.Drawing.Size(100, 89)
        Me.btnKinnmu.TabIndex = 0
        Me.btnKinnmu.Text = "勤務シフト"
        Me.btnKinnmu.UseVisualStyleBackColor = True
        '
        'btnMasuta
        '
        Me.btnMasuta.Font = New System.Drawing.Font("MS UI Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnMasuta.ForeColor = System.Drawing.Color.Blue
        Me.btnMasuta.Location = New System.Drawing.Point(155, 50)
        Me.btnMasuta.Name = "btnMasuta"
        Me.btnMasuta.Size = New System.Drawing.Size(73, 61)
        Me.btnMasuta.TabIndex = 1
        Me.btnMasuta.Text = "マスタ"
        Me.btnMasuta.UseVisualStyleBackColor = True
        '
        'rbnPreview
        '
        Me.rbnPreview.AutoSize = True
        Me.rbnPreview.Checked = True
        Me.rbnPreview.Location = New System.Drawing.Point(44, 126)
        Me.rbnPreview.Name = "rbnPreview"
        Me.rbnPreview.Size = New System.Drawing.Size(63, 16)
        Me.rbnPreview.TabIndex = 2
        Me.rbnPreview.TabStop = True
        Me.rbnPreview.Text = "ﾌﾟﾚﾋﾞｭｰ"
        Me.rbnPreview.UseVisualStyleBackColor = True
        '
        'rbnInnsatu
        '
        Me.rbnInnsatu.AutoSize = True
        Me.rbnInnsatu.Location = New System.Drawing.Point(44, 148)
        Me.rbnInnsatu.Name = "rbnInnsatu"
        Me.rbnInnsatu.Size = New System.Drawing.Size(47, 16)
        Me.rbnInnsatu.TabIndex = 3
        Me.rbnInnsatu.Text = "印刷"
        Me.rbnInnsatu.UseVisualStyleBackColor = True
        '
        'frmTopform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(257, 186)
        Me.Controls.Add(Me.rbnInnsatu)
        Me.Controls.Add(Me.rbnPreview)
        Me.Controls.Add(Me.btnMasuta)
        Me.Controls.Add(Me.btnKinnmu)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTopform"
        Me.Text = "Shift　看護師シフト"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnKinnmu As System.Windows.Forms.Button
    Friend WithEvents btnMasuta As System.Windows.Forms.Button
    Friend WithEvents rbnPreview As System.Windows.Forms.RadioButton
    Friend WithEvents rbnInnsatu As System.Windows.Forms.RadioButton

End Class
