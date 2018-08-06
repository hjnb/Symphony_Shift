Imports System
Imports System.Windows.Forms

Public Class ShiftDgv
    Inherits DataGridView
    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        '編集時Enterを押したらTabキーが押されたようにする
        If TypeOf Me.EditingControl Is DataGridViewComboBoxEditingControl = True Then
            Dim tb As DataGridViewComboBoxEditingControl = CType(Me.EditingControl, DataGridViewComboBoxEditingControl)
            Dim cell As DataGridViewCell = Me.CurrentCell

            If Not IsNothing(tb) AndAlso ((keyData = Keys.Left AndAlso tb.SelectionStart = 0) OrElse (keyData = Keys.Right AndAlso tb.SelectionStart = tb.Text.Length)) Then
                Return False
            ElseIf keyData = Keys.Enter Then
                Return Me.ProcessTabKey(keyData)
            Else
                Return MyBase.ProcessDialogKey(keyData)
            End If

            Return MyBase.ProcessDialogKey(keyData)
        ElseIf TypeOf Me.EditingControl Is DataGridViewTextBoxEditingControl = True Then
            Dim tb As DataGridViewTextBoxEditingControl = CType(Me.EditingControl, DataGridViewTextBoxEditingControl)
            Dim cell As DataGridViewCell = Me.CurrentCell
            If (keyData And Keys.KeyCode) = Keys.Enter Then

                Dim strWork As String
                strWork = tb.Text
                'strWork = strWork.Replace("10", "休日")
                strWork = strWork.Replace("5", "半")
                strWork = strWork.Replace("0", "7.5")
                strWork = strWork.Replace("1", "早")
                strWork = strWork.Replace("2", "遅")
                strWork = strWork.Replace("3", "休")
                strWork = strWork.Replace("4", "有")
                strWork = strWork.Replace("6", "研")

                tb.Text = strWork

                Return Me.ProcessTabKey(keyData)

            ElseIf keyData = Keys.Back Then
                cell.Value = ""
            End If

            'Dim tb As DataGridViewTextBoxEditingControl = CType(Me.EditingControl, DataGridViewTextBoxEditingControl)
            If Not IsNothing(tb) AndAlso ((keyData = Keys.Left AndAlso tb.SelectionStart = 0) OrElse (keyData = Keys.Right AndAlso tb.SelectionStart = tb.TextLength)) Then
                Return False
            Else
                Return MyBase.ProcessDialogKey(keyData)
            End If
        Else
            Return MyBase.ProcessDialogKey(keyData)
        End If


    End Function

    Protected Overrides Function ProcessDataGridViewKey(ByVal e As KeyEventArgs) As Boolean
        '編集時以外でEnterを押したらTabキーが押されたようにする
        Dim cell As DataGridViewCell = Me.CurrentCell
        If e.KeyCode = Keys.Enter Then
            Return Me.ProcessTabKey(e.KeyCode)
        ElseIf e.KeyCode = Keys.Delete Then
            cell.Value = ""
        End If

        Return MyBase.ProcessDataGridViewKey(e)
    End Function

    
End Class
