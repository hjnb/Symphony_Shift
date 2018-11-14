Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Public Class 勤務シフト
    Private whiteCellStyle As DataGridViewCellStyle
    Private clearCellStyle As DataGridViewCellStyle
    Private SatCellStyle As DataGridViewCellStyle
    Private SunCellStyle As DataGridViewCellStyle
    Private DGV1Table As DataTable

    Private Sub MadeStyle()
        '各曜日のセルスタイル設定
        whiteCellStyle = New DataGridViewCellStyle()
        clearCellStyle = New DataGridViewCellStyle()
        SatCellStyle = New DataGridViewCellStyle()
        SunCellStyle = New DataGridViewCellStyle()
        whiteCellStyle.BackColor = Color.FromArgb(255, 255, 255)
        clearCellStyle.BackColor = Color.FromArgb(234, 234, 234)
        SatCellStyle.BackColor = Color.FromArgb(200, 200, 255)
        SunCellStyle.BackColor = Color.FromArgb(255, 200, 200)
    End Sub

    Private Sub 勤務シフト_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'セルスタイルの実行
        MadeStyle()

        Me.WindowState = FormWindowState.Maximized

        Dim Cn As New OleDbConnection(frmTopform.DB_Shift)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        DGV1Table = New DataTable()
        Util.EnableDoubleBuffering(DataGridView1)

        With DataGridView1
            .RowTemplate.Height = 20
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersVisible = False
            .RowHeadersVisible = False
            .DefaultCellStyle.SelectionForeColor = Color.Black
        End With

        Dim SQLCm2 As OleDbCommand = Cn.CreateCommand
        Dim Adapter2 As New OleDbDataAdapter(SQLCm2)
        Dim Table2 As New DataTable

        SQLCm2.CommandText = "SELECT Nam As 職員名, Kana As フリガナ, Dsp As 表示, Prp FROM Master ORDER BY Kana"
        Adapter2.Fill(Table2)
        DataGridView2.DataSource = Table2

        '列作成
        For i As Integer = 0 To 35
            DGV1Table.Columns.Add("a" & i, Type.GetType("System.String"))
        Next

        '行作成
        For i As Integer = 1 To 13
            DGV1Table.Rows.Add(DGV1Table.NewRow())
        Next

        '空を表示
        DataGridView1.DataSource = DGV1Table

        'データグリッドビューのコンボボックスの中身を作成
        Dim Nurse As New List(Of String)
        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            If DataGridView2(2, i).Value = 1 Then
                Nurse.Add(DataGridView2(0, i).Value)
            End If
        Next
        'データグリッドビューのコンボボックスに看護師名を挿入
        For cmbbox As Integer = 3 To 12
            Dim comboname As New DataGridViewComboBoxCell()
            comboname.Items.AddRange(Nurse.ToArray)
            DataGridView1(0, cmbbox) = comboname
            comboname.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
        Next
        'データグリッドビューの各セルの設定
        For i As Integer = 1 To 35
            With DataGridView1.Columns(i)
                .Width = 25
                .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End With
            If i > 31 Then
                With DataGridView1.Columns(i)
                    .DefaultCellStyle = clearCellStyle
                    .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ReadOnly = True
                End With
            End If
        Next
        'データグリッドビューの各セルの設定
        For i As Integer = 0 To 1
            With DataGridView1.Rows(i)
                .DefaultCellStyle = clearCellStyle
                .ReadOnly = True
            End With
        Next
        'データグリッドビューの各セルの設定
        With DataGridView1(0, 2)
            .Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Style.BackColor = Color.FromArgb(128, 255, 255)
            .Value = "夜間体制"
        End With

        DataGridView1(32, 0).Value = "休"
        DataGridView1(33, 0).Value = "半"
        DataGridView1(34, 0).Value = "有"
        DataGridView1(35, 0).Value = "計"

        YmdBox1.setADStr(Today.ToString("yyyy/MM/dd"))
        lblNamae.Text = ""

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        '夜間勤務看護師選択の処理
        Dim cell As DataGridViewCell = DataGridView1.CurrentCell
        If cell.ColumnIndex = 0 AndAlso cell.RowIndex > 2 Then
            lblNamae.Text = Strings.Left(Util.checkDBNullValue(cell.Value), 1)
        ElseIf cell.ColumnIndex > 0 AndAlso cell.RowIndex > 2 Then
            If lblKinmu.Visible = True Then
                If lblKinmu.Text = "日" Then
                    cell.Value = "7.5"
                Else
                    cell.Value = lblKinmu.Text
                End If
            End If
        Else
            If cell.ColumnIndex <> 0 AndAlso cell.RowIndex = 2 AndAlso lblNamae.Text <> "" Then
                cell.Value = lblNamae.Text
            End If
        End If

        Dim dgv As DataGridView = CType(sender, DataGridView)
        If TypeOf dgv(e.ColumnIndex, e.RowIndex) Is DataGridViewComboBoxCell Then
            'フォーム上の座標でマウスポインタの位置を取得する
            '画面座標でマウスポインタの位置を取得する
            Dim sp As System.Drawing.Point = System.Windows.Forms.Cursor.Position
            '画面座標をクライアント座標に変換する
            Dim cp As System.Drawing.Point = Me.PointToClient(sp)
            'X座標を取得する
            Dim x As Integer = cp.X


            If x > 120 Then
                'コンボボックスリスト開く
                Dim cb As DataGridViewComboBoxCell = CType(dgv(e.ColumnIndex, e.RowIndex), DataGridViewComboBoxCell)
                If cb.IsInEditMode = False Then
                    SendKeys.Send("{F4}")
                End If
            Else
                SendKeys.Send("{F2}")
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        '選択したセルに枠を付ける
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso (e.PaintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
            e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)

            If (e.PaintParts And DataGridViewPaintParts.SelectionBackground) = DataGridViewPaintParts.SelectionBackground AndAlso (e.State And DataGridViewElementStates.Selected) = DataGridViewElementStates.Selected Then
                e.Graphics.DrawRectangle(New Pen(Color.Black, 2I), e.CellBounds.X + 1I, e.CellBounds.Y + 1I, e.CellBounds.Width - 3I, e.CellBounds.Height - 3I)
            End If

            Dim pParts As DataGridViewPaintParts = e.PaintParts And Not DataGridViewPaintParts.Background
            e.Paint(e.ClipBounds, pParts)
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If TypeOf e.Control Is DataGridViewComboBoxEditingControl = True Then
            Dim text As DataGridViewComboBoxEditingControl = CType(e.Control, DataGridViewComboBoxEditingControl)
            text.DropDownStyle = ComboBoxStyle.DropDown
            text.ImeMode = Windows.Forms.ImeMode.Hiragana
        ElseIf TypeOf e.Control Is DataGridViewTextBoxEditingControl = True Then
            Dim text As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)
            text.ImeMode = Windows.Forms.ImeMode.NoControl
        End If
    End Sub

    Private Sub DataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
        Dim dgv As DataGridView = CType(sender, DataGridView)
        '該当するセルか調べる
        If TypeOf dgv(e.ColumnIndex, e.RowIndex) Is DataGridViewComboBoxCell Then
            Dim cbc As DataGridViewComboBoxCell = CType(dgv(e.ColumnIndex, e.RowIndex), DataGridViewComboBoxCell)
            'コンボボックスの項目に追加する
            If Not cbc.Items.Contains(e.FormattedValue) Then
                If e.FormattedValue = "" OrElse IsDBNull(e.FormattedValue) Then

                Else
                    dgv(e.ColumnIndex, e.RowIndex).Value = e.FormattedValue
                    cbc.Items.Add(e.FormattedValue)
                End If

            End If
            'セルの値を設定しないと、元に戻ってしまう
            dgv(e.ColumnIndex, e.RowIndex).Value = e.FormattedValue
        End If
    End Sub

    Private Sub YmdBox1_YmdTextChange(sender As Object, e As System.EventArgs) Handles YmdBox1.YmdTextChange
        '各月の曜日を設定していく
        btnKuria.PerformClick()
        Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))
        Dim Week() As String = {"", "日", "月", "火", "水", "木", "金", "土"}
        Dim oldDate As Date
        Dim oldWeekDay As Integer

        For dd As Integer = 1 To Getumatu
            DataGridView1(dd, 0).Value = dd
            oldDate = Strings.Left(YmdBox1.getADStr(), 7) & "/" & dd
            oldWeekDay = Weekday(oldDate)
            DataGridView1(dd, 1).Value = Week(oldWeekDay)
            DataGridView1.Columns(dd).ReadOnly = False
            DataGridView1.Columns(dd).DefaultCellStyle = whiteCellStyle
        Next

        For i As Integer = Getumatu + 1 To 32
            DataGridView1.Columns(i).ReadOnly = True
            DataGridView1.Columns(i).DefaultCellStyle = clearCellStyle
        Next

        '以下のコメントアウト部分　別のやり方
        'Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))
        'Dim Week() As String = {"日", "月", "火", "水", "木", "金", "土"}
        'oldDate = Strings.Left(YmdBox1.getADStr(), 7) & "/01"
        'oldWeekDay = Weekday(oldDate)

        'For i As Integer = 1 To Getumatu
        '    DataGridView1(i, 1).Value = Week(((oldWeekDay - 1) + (i - 1)) Mod 7)
        'Next

        '公休の数計算
        Dim koukyuu As String = "0"
        For i As Integer = 1 To 31
            If DataGridView1(i, 1).Value = "日" Then
                koukyuu = Val(koukyuu) + 1
            ElseIf DataGridView1(i, 1).Value = "土" Then
                koukyuu = Val(koukyuu) + 0.5
            End If
            lblNissuu.Text = Val(koukyuu)
        Next

        'datagridviewにデータを表示
        DataShow()

        '個人の休みの数等を計算
        If Util.checkDBNullValue(DataGridView1(0, 3).Value) <> "" Then
            Keisan()
        End If

        Dim cell As DataGridViewCell = DataGridView1.CurrentCell
        Dim r As Integer = DataGridView1.CurrentRow.Index
        For c As Integer = 0 To 31
            DataGridView1.CurrentCell = DataGridView1(c, r)
        Next
        DataGridView1.CurrentCell = cell

        For i As Integer = 1 To 35
            DataGridView1.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

    End Sub

    Private Sub DataShow()
        'データグリッドビューにデータを表示していく
        WeekColor()

        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select * from Mnth WHERE Ym = '" & Strings.Left(YmdBox1.getADStr(), 7) & "' order by Ym, Gyo"
        cnn.Open(frmTopform.DB_Shift)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockReadOnly)

        Dim columnNo As Integer = 0
        While Not rs.EOF
            If columnNo = 0 Then
                lblNissuu.Text = rs.Fields("D1").Value
            Else
                DGV1Table.Rows(2).Item("a" & columnNo) = rs.Fields("D1").Value
            End If

            For row As Integer = 3 To 12
                DGV1Table.Rows(row).Item("a" & columnNo) = rs.Fields("D" & row - 1).Value

                If rs.Fields("Gyo").Value = 0 Then
                    Dim cbc As DataGridViewComboBoxCell = CType(DataGridView1(0, row), DataGridViewComboBoxCell)
                    'コンボボックスの項目に追加する
                    If Not cbc.Items.Contains(rs.Fields("D" & row - 1).Value) Then
                        cbc.Items.Add(rs.Fields("D" & row - 1).Value)
                    End If
                End If
            Next

            rs.MoveNext()

            columnNo = columnNo + 1
        End While
        cnn.Close()


    End Sub

    Private Sub Keisan()
        Dim yasumi, hanniti, yuukyuu As Integer
        For r As Integer = 3 To 12
            yasumi = 0
            hanniti = 0
            yuukyuu = 0
            If Util.checkDBNullValue(DataGridView1(0, r).Value) <> "" Then
                For c As Integer = 1 To 31
                    If DataGridView1(c, r).Value = "休" Then
                        yasumi = yasumi + 1
                    ElseIf DataGridView1(c, r).Value = "半" Then
                        hanniti = hanniti + 1
                    ElseIf DataGridView1(c, r).Value = "有" Then
                        yuukyuu = yuukyuu + 1
                    End If
                Next
                DataGridView1(32, r).Value = yasumi
                DataGridView1(33, r).Value = hanniti
                DataGridView1(34, r).Value = yuukyuu
            End If
        Next
    End Sub

    Private Sub btnKuria_Click(sender As System.Object, e As System.EventArgs) Handles btnKuria.Click
        '各セルを空にして色を初期化
        For i As Integer = 3 To 12
            DataGridView1(0, i).Value = ""
        Next

        For r As Integer = 0 To 12
            If r < 3 Then
                For c As Integer = 1 To 31
                    DataGridView1(c, r).Value = ""
                    DataGridView1(c, 1).Style = clearCellStyle
                Next
            Else
                For c As Integer = 1 To 35
                    DataGridView1(c, r).Value = ""
                Next
            End If
        Next

        lblNamae.Text = ""

    End Sub

    Private Sub WeekColor()
        '土曜日曜の色付け
        Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))

        For dd As Integer = 1 To Getumatu
            If DataGridView1(dd, 1).Value = "土" Then
                DataGridView1(dd, 1).Style = SatCellStyle
            ElseIf DataGridView1(dd, 1).Value = "日" Then
                DataGridView1(dd, 1).Style = SunCellStyle
            End If
        Next
    End Sub

    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs) Handles Label3.Click
        lblNissuu.Text = Val(lblNissuu.Text) + 0.5
    End Sub

    Private Sub Label4_Click(sender As System.Object, e As System.EventArgs) Handles Label4.Click
        lblNissuu.Text = Val(lblNissuu.Text) - 0.5
    End Sub

    Private Sub btnTouroku_Click(sender As System.Object, e As System.EventArgs) Handles btnTouroku.Click
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select * from Mnth WHERE Ym = '" & Strings.Left(YmdBox1.getADStr(), 7) & "' order by Ym, Gyo"
        cnn.Open(frmTopform.DB_Shift)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.RecordCount > 0 Then
            Henkou()
        Else
            Tuika()
        End If

        btnKousin.PerformClick()
    End Sub
    Private Sub Henkou()
        Dim cnn As New ADODB.Connection
        cnn.Open(frmTopform.DB_Shift)

        Dim SQL As String = ""
        SQL = "DELETE FROM Mnth WHERE Ym = '" & Strings.Left(YmdBox1.getADStr(), 7) & "'"
        cnn.Execute(SQL)
        cnn.Close()

        Tuika()
    End Sub
    Private Sub Tuika()
        Dim cnn As New ADODB.Connection
        cnn.Open(frmTopform.DB_Shift)
        Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))
        Dim ym, d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11 As String
        Dim gyo As Integer

        For dd As Integer = 0 To Getumatu
            ym = Strings.Left(YmdBox1.getADStr(), 7)
            gyo = dd
            If dd = 0 Then
                d1 = lblNissuu.Text
            Else
                d1 = Util.checkDBNullValue(DataGridView1(dd, 2).Value)
            End If
            d2 = Util.checkDBNullValue(DataGridView1(dd, 3).Value)
            d3 = Util.checkDBNullValue(DataGridView1(dd, 4).Value)
            d4 = Util.checkDBNullValue(DataGridView1(dd, 5).Value)
            d5 = Util.checkDBNullValue(DataGridView1(dd, 6).Value)
            d6 = Util.checkDBNullValue(DataGridView1(dd, 7).Value)
            d7 = Util.checkDBNullValue(DataGridView1(dd, 8).Value)
            d8 = Util.checkDBNullValue(DataGridView1(dd, 9).Value)
            d9 = Util.checkDBNullValue(DataGridView1(dd, 10).Value)
            d10 = Util.checkDBNullValue(DataGridView1(dd, 11).Value)
            d11 = Util.checkDBNullValue(DataGridView1(dd, 12).Value)

            Dim SQL As String = ""
            SQL = "INSERT INTO Mnth (Ym, Gyo, D1, D2, D3, D4, D5, D6, D7, D8, D9, D10, D11) VALUES ('" & ym & "', " & gyo & ", '" & d1 & "', '" & d2 & "', '" & d3 & "', '" & d4 & "', '" & d5 & "', '" & d6 & "', '" & d7 & "', '" & d8 & "', '" & d9 & "', '" & d10 & "', '" & d11 & "')"

            cnn.Execute(SQL)
        Next

        cnn.Close()
    End Sub

    Private Sub btnSakujo_Click(sender As System.Object, e As System.EventArgs) Handles btnSakujo.Click
        If MsgBox("削除してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "削除確認") = MsgBoxResult.Yes Then
            Dim cnn As New ADODB.Connection
            cnn.Open(frmTopform.DB_Shift)

            Dim SQL As String = ""
            SQL = "DELETE FROM Mnth WHERE Ym = '" & Strings.Left(YmdBox1.getADStr(), 7) & "'"
            cnn.Execute(SQL)
            cnn.Close()

            btnKousin.PerformClick()
        End If
    End Sub

    Private Sub btnInnsatu_Click(sender As System.Object, e As System.EventArgs) Handles btnInnsatu.Click
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        Dim sql As String = "select * from Mnth WHERE Ym = '" & Strings.Left(YmdBox1.getADStr(), 7) & "' order by Ym, Gyo"
        cnn.Open(frmTopform.DB_Shift)
        rs.Open(sql, cnn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockReadOnly)

        If rs.RecordCount > 0 Then
            Dim objExcel As Object
            Dim objWorkBooks As Object
            Dim objWorkBook As Object
            Dim oSheets As Object
            Dim oSheet As Object

            objExcel = CreateObject("Excel.Application")
            objWorkBooks = objExcel.Workbooks
            objWorkBook = objWorkBooks.Open(frmTopform.excelFilePass)
            oSheets = objWorkBook.Worksheets
            oSheet = objWorkBook.Worksheets("6-31新")

            oSheet.Range("B1").Value = YmdBox1.getWarekiKanji() & " " & Strings.Mid(YmdBox1.getWarekiStr(), 2, 2) & " 年 " & Strings.Mid(YmdBox1.getWarekiStr(), 5, 2) & " 月 勤務割"
            oSheet.Range("AJ4").Value = lblNissuu.Text
            oSheet.Range("AJ6").Value = ""
            Dim YoubiCell() As String = {"D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH"}
            For r As Integer = 3 To 12
                oSheet.Range("C" & r + 3).Value = DataGridView1(0, r).Value
                For c As Integer = 1 To 31
                    oSheet.Range(YoubiCell(c - 1) & r + 1).Value = DataGridView1(c, r - 2).Value
                Next
            Next

            '保存
            objExcel.DisplayAlerts = False

            ' エクセル表示
            objExcel.Visible = True

            '印刷
            If frmTopform.rbnPreview.Checked = True Then
                oSheet.PrintPreview(1)
            ElseIf frmTopform.rbnInnsatu.Checked = True Then
                oSheet.Printout(1)
            End If

            ' EXCEL解放
            objExcel.Quit()
            Marshal.ReleaseComObject(oSheet)
            Marshal.ReleaseComObject(objWorkBook)
            Marshal.ReleaseComObject(objExcel)
            oSheet = Nothing
            objWorkBook = Nothing
            objExcel = Nothing
        Else
            MsgBox("出力するデータがありません")
        End If


    End Sub

    Private Sub btnKousin_Click(sender As System.Object, e As System.EventArgs) Handles btnKousin.Click
        btnKuria.PerformClick()

        Dim Getumatu As String = Date.DaysInMonth(Strings.Left(YmdBox1.getADStr(), 4), Val(Strings.Mid(YmdBox1.getADStr(), 6, 2)))
        Dim Week() As String = {"", "日", "月", "火", "水", "木", "金", "土"}
        Dim oldDate As Date
        Dim oldWeekDay As Integer

        For dd As Integer = 1 To Getumatu
            DataGridView1(dd, 0).Value = dd
            oldDate = Strings.Left(YmdBox1.getADStr(), 7) & "/" & dd
            oldWeekDay = Weekday(oldDate)
            DataGridView1(dd, 1).Value = Week(oldWeekDay)
        Next

        Dim koukyuu As String = "0"
        For i As Integer = 1 To 31
            If DataGridView1(i, 1).Value = "日" Then
                koukyuu = Val(koukyuu) + 1
            ElseIf DataGridView1(i, 1).Value = "土" Then
                koukyuu = Val(koukyuu) + 0.5
            End If
            lblNissuu.Text = Val(koukyuu)
        Next

        'datagridviewにデータを表示
        DataShow()

        '個人の休みの数等を計算
        If Util.checkDBNullValue(DataGridView1(0, 3).Value) <> "" Then
            Keisan()
        End If

        Dim cell As DataGridViewCell = DataGridView1.CurrentCell
        Dim r As Integer = DataGridView1.CurrentRow.Index
        For c As Integer = 0 To 31
            DataGridView1.CurrentCell = DataGridView1(c, r)
        Next
        DataGridView1.CurrentCell = cell
    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click
        lblKinmu.Visible = True
        lblKinmu.Text = "日"
    End Sub
    Private Sub Label6_Click(sender As System.Object, e As System.EventArgs) Handles Label6.Click
        lblKinmu.Visible = True
        lblKinmu.Text = "早"
    End Sub
    Private Sub Label7_Click(sender As System.Object, e As System.EventArgs) Handles Label7.Click
        lblKinmu.Visible = True
        lblKinmu.Text = "遅"
    End Sub
    Private Sub Label8_Click(sender As System.Object, e As System.EventArgs) Handles Label8.Click
        lblKinmu.Visible = True
        lblKinmu.Text = "休"
    End Sub
    Private Sub Label9_Click(sender As System.Object, e As System.EventArgs) Handles Label9.Click
        lblKinmu.Visible = True
        lblKinmu.Text = "有"
    End Sub
    Private Sub Label10_Click(sender As System.Object, e As System.EventArgs) Handles Label10.Click
        lblKinmu.Visible = True
        lblKinmu.Text = "半"
    End Sub
    Private Sub Label11_Click(sender As System.Object, e As System.EventArgs) Handles Label11.Click
        lblKinmu.Visible = True
        lblKinmu.Text = "研"
    End Sub

End Class