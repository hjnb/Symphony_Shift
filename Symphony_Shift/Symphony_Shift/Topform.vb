
Public Class frmTopform
    'データベースのパス
    Public dbFilePath As String = My.Application.Info.DirectoryPath & "\Shift.mdb"
    Public DB_Shift As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFilePath

    'エクセルのパス
    Public excelFilePass As String = My.Application.Info.DirectoryPath & "\Shift.xls"

    '.iniファイルのパス
    Public iniFilePath As String = My.Application.Info.DirectoryPath & "\Shift.ini"

    'フォーム
    Private frmMasuta As マスタ
    Private frmKinmu As 勤務シフト

    Private Sub frmTopform_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'データベース、エクセル、構成ファイルの存在チェック
        If Not System.IO.File.Exists(dbFilePath) Then
            MsgBox("データベースファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(excelFilePass) Then
            MsgBox("エクセルファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(iniFilePath) Then
            MsgBox("構成ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        Dim s As System.Windows.Forms.Screen = System.Windows.Forms.Screen.FromControl(Me)
        'ディスプレイの高さと幅を取得
        Dim h As Integer = s.Bounds.Height
        Dim w As Integer = s.Bounds.Width

        Me.StartPosition = FormStartPosition.Manual
        Me.DesktopLocation = New Point(w / 2 - 200, h / 2 - 200)

    End Sub

    Private Sub btnKinnmu_Click(sender As System.Object, e As System.EventArgs) Handles btnKinnmu.Click
        If IsNothing(frmKinmu) OrElse frmKinmu.IsDisposed Then
            frmKinmu = New 勤務シフト()
            frmKinmu.Owner = Me
            frmKinmu.Show()
        End If
    End Sub

    Private Sub btnMasuta_Click(sender As System.Object, e As System.EventArgs) Handles btnMasuta.Click
        If IsNothing(frmMasuta) OrElse frmMasuta.IsDisposed Then
            frmMasuta = New マスタ()
            frmMasuta.Owner = Me
            frmMasuta.StartPosition = FormStartPosition.CenterScreen
            frmMasuta.Show()
        End If
    End Sub

    
End Class
