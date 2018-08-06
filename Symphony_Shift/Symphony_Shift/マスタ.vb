Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Public Class マスタ

    Private Sub マスタ_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim Cn As New OleDbConnection(frmTopform.DB_Shift)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable

        Util.EnableDoubleBuffering(DataGridView1)
        With DataGridView1
            .RowTemplate.Height = 16
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False
            .ReadOnly = True '編集禁止
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect 'クリック時に行選択
            .MultiSelect = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        SQLCm.CommandText = "SELECT Nam As 職員名, Kana As フリガナ, Dsp As 表示, Prp FROM Master ORDER BY Kana"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        With DataGridView1
            .RowHeadersWidth = 25
            .Columns(0).Width = 100
            .Columns(1).Width = 100
            .Columns(2).Width = 40
            .Columns(3).Visible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        KeyPreview = True

        DataGridView1.ClearSelection()

    End Sub

    Private Sub マスタ_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim forward As Boolean = e.Modifiers <> Keys.Shift
            Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        txtName.Text = Util.checkDBNullValue(DataGridView1(0, i).Value)
        txtKana.Text = Util.checkDBNullValue(DataGridView1(1, i).Value)
        If Util.checkDBNullValue(DataGridView1(2, i).Value) = "1" Then
            rbnAri.Checked = True
        ElseIf Util.checkDBNullValue(DataGridView1(2, i).Value) = "0" Then
            rbnNasi.Checked = False
        End If
    End Sub

    Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        '列ヘッダを対象外しておかないと列ヘッダにも番号を表示してしまう

        If e.ColumnIndex < 0 And e.RowIndex >= 0 Then

            'セルを描画する

            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する

            Dim idxRect As Rectangle = e.CellBounds

            'e.Padding(値を表示する境界線からの間隔)を考慮して描画位置を決める

            Dim rectHeight As Long = e.CellStyle.Padding.Top

            Dim rectLeft As Long = e.CellStyle.Padding.Left

            idxRect.Inflate(rectLeft, rectHeight)

            '行番号を描画する

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, idxRect, e.CellStyle.ForeColor, TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)

            '描画完了の通知

            e.Handled = True

        End If

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.Columns(e.ColumnIndex).Name = "表示" Then
            If Util.checkDBNullValue(e.Value) = 1 Then
                e.Value = "○"
                e.FormattingApplied = True
            ElseIf Util.checkDBNullValue(e.Value) = 0 Then
                e.Value = ""
                e.FormattingApplied = True
            End If
        End If
    End Sub

    Private Sub btnTouroku_Click(sender As System.Object, e As System.EventArgs) Handles btnTouroku.Click
        If txtName.Text = "" OrElse txtKana.Text = "" Then
            MsgBox("職員名とフリガナを入力してください。")
            Return
        End If

        Dim selectedrow As Boolean = False
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Selected = True Then
                selectedrow = True
                Exit For
            End If
        Next

        If selectedrow = True Then
            Hennkou()
            btnKousin.PerformClick()
            Exit Sub
        Else
            Tuika()
            btnKousin.PerformClick()
        End If

    End Sub

    Private Sub Hennkou()
        Dim i As Integer = DataGridView1.CurrentRow.Index
        Dim cnn As New ADODB.Connection
        cnn.Open(frmTopform.DB_Shift)
        Dim SQL As String = ""
        SQL = "DELETE FROM Master WHERE (Nam = '" & DataGridView1(0, i).Value & "') AND (kana ='" & DataGridView1(1, i).Value & "')"
        cnn.Execute(SQL)
        cnn.Close()

        Tuika()
    End Sub
    Private Sub Tuika()
        Dim cnn As New ADODB.Connection
        cnn.Open(frmTopform.DB_Shift)

        Dim nam, kana As String
        Dim dsp, prp As Integer

        nam = txtName.Text
        kana = txtKana.Text
        If rbnAri.Checked = True Then
            dsp = "1"
        ElseIf rbnNasi.Checked = False Then
            dsp = "0"
        End If
        prp = 0

        Dim SQL As String = ""
        SQL = "INSERT INTO Master (Nam, Kana, Dsp, Prp) VALUES ('" & nam & "', '" & kana & "', " & dsp & ", " & prp & ")"

        cnn.Execute(SQL)
        cnn.Close()
        
    End Sub

    Private Sub btnSakujo_Click(sender As System.Object, e As System.EventArgs) Handles btnSakujo.Click
        Dim selectedrow As Boolean = False
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Selected = True Then
                selectedrow = True
                Exit For
            End If
        Next

        If selectedrow = False Then
            MsgBox("削除する行を選択してください。", , "削除")
            Return
        End If

        If MsgBox("削除してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "削除確認") = MsgBoxResult.Yes Then
            Dim cnn As New ADODB.Connection
            cnn.Open(frmTopform.DB_Shift)

            Dim SQL As String = ""
            SQL = "DELETE FROM Master WHERE (Nam = '" & txtName.Text & "') AND (kana ='" & txtKana.Text & "')"
            cnn.Execute(SQL)
            cnn.Close()

            btnKousin.PerformClick()
        End If

    End Sub

    Private Sub btnKuria_Click(sender As System.Object, e As System.EventArgs) Handles btnKuria.Click
        txtName.Text = ""
        txtKana.Text = ""
        rbnAri.Checked = True
    End Sub

    Private Sub btnKousin_Click(sender As System.Object, e As System.EventArgs) Handles btnKousin.Click
        btnKuria.PerformClick()
        Dim Cn As New OleDbConnection(frmTopform.DB_Shift)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable

        Util.EnableDoubleBuffering(DataGridView1)
        With DataGridView1
            .RowTemplate.Height = 16
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False
            .ReadOnly = True '編集禁止
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect 'クリック時に行選択
            .MultiSelect = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        SQLCm.CommandText = "SELECT Nam As 職員名, Kana As フリガナ, Dsp As 表示, Prp FROM Master ORDER BY Kana"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        With DataGridView1
            .RowHeadersWidth = 25
            .Columns(0).Width = 100
            .Columns(1).Width = 100
            .Columns(2).Width = 40
            .Columns(3).Visible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        KeyPreview = True

        DataGridView1.CurrentCell = Nothing

        DataGridView1.ClearSelection()
    End Sub
End Class