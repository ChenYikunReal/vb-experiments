Imports System.IO
Imports System.Text

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using DRReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("D:\VB\expr2\expr2\MainInfo.txt", System.Text.Encoding.UTF8)
            DRReader.TextFieldType = FileIO.FieldType.Delimited
            DRReader.SetDelimiters("#")
            Dim currentRow As String()
            While Not DRReader.EndOfData
                Try
                    currentRow = DRReader.ReadFields()
                    TextBox1.Text = currentRow(0)
                    TextBox2.Text = currentRow(1)
                    TextBox3.Text = currentRow(2)
                    TextBox5.Text = currentRow(3)
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line" & "is not valid and will be skipped.")
                End Try
            End While
        End Using
        Using DRReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("D:\VB\expr2\expr2\FriendsInfo.txt", System.Text.Encoding.UTF8)
            DRReader.TextFieldType = FileIO.FieldType.Delimited
            DRReader.SetDelimiters("\n")
            Dim currentRow As String()
            While Not DRReader.EndOfData
                Try
                    currentRow = DRReader.ReadFields()
                    For Each element In currentRow
                        ListBox1.Items.Add(element)
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line" & "is not valid and will be skipped.")
                End Try
            End While
        End Using
        Using DRReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("D:\VB\expr2\expr2\NotebookInfo.txt", System.Text.Encoding.UTF8)
            DRReader.TextFieldType = FileIO.FieldType.Delimited
            DRReader.SetDelimiters("\n")
            Dim currentRow As String()
            While Not DRReader.EndOfData
                Try
                    currentRow = DRReader.ReadFields()
                    For Each element In currentRow
                        ListBox2.Items.Add(element)
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line" & "is not valid and will be skipped.")
                End Try
            End While
        End Using
        Using DRReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("D:\VB\expr2\expr2\AccountBookInfo.txt", System.Text.Encoding.UTF8)
            DRReader.TextFieldType = FileIO.FieldType.Delimited
            DRReader.SetDelimiters("\n")
            Dim currentRow As String()
            While Not DRReader.EndOfData
                Try
                    currentRow = DRReader.ReadFields()
                    For Each element In currentRow
                        ListBox3.Items.Add(element)
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line" & "is not valid and will be skipped.")
                End Try
            End While
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Then
            MsgBox("不能有空信息")
            Return
        ElseIf Not TextBox7.Text Like "[1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]" Then
            MsgBox("手机号不合法")
            Return
        End If
        '成功
        Dim tempStr As String = TextBox6.Text & "-" & TextBox7.Text & "-" & TextBox8.Text
        ListBox1.Items.Add(tempStr)
        Dim file As FileStream = New FileStream("D:\VB\expr2\expr2\FriendsInfo.txt", FileMode.Append)
        Dim fileWriter As New StreamWriter(file)
        fileWriter.WriteLine(tempStr)
        fileWriter.Flush()
        MsgBox("添加成功")
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox9.Text = "" Then
            MsgBox("写点东西吧")
            Return
        End If
        '成功
        ListBox2.Items.Add(TextBox9.Text)
        Dim file As FileStream = New FileStream("D:\VB\expr2\expr2\NotebookInfo.txt", FileMode.Append)
        Dim fileWriter As New StreamWriter(file)
        fileWriter.WriteLine(TextBox9.Text)
        fileWriter.Flush()
        MsgBox("添加成功")
        TextBox9.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox10.Text = "" Or TextBox11.Text = "" Then
            MsgBox("不能有空信息")
            Return
        End If
        '成功
        Dim tempStr As String = TextBox10.Text & "#$" & TextBox11.Text
        ListBox3.Items.Add(tempStr)
        Dim file As FileStream = New FileStream("D:\VB\expr2\expr2\AccountBookInfo.txt", FileMode.Append)
        Dim fileWriter As New StreamWriter(file)
        fileWriter.WriteLine(tempStr)
        fileWriter.Flush()
        MsgBox("添加成功")
        TextBox10.Text = ""
        TextBox11.Text = ""
    End Sub

    Private Sub Command1_Click()
        Shell("explorer.exe https://blog.csdn.net/weixin_43896318")
    End Sub

    Private Sub Command2_Click()
        Shell("explorer.exe https://github.com/ChenYikunSSS")
    End Sub

    Private Sub LinkLabel1_Click(sender As Object, e As EventArgs) Handles LinkLabel1.Click
        Command1_Click()
    End Sub

    Private Sub LinkLabel2_Click(sender As Object, e As EventArgs) Handles LinkLabel2.Click
        Command2_Click()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.ReadOnly = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox2.ReadOnly = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox5.ReadOnly = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MsgBox("想啥呢你")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If TextBox1.ReadOnly And TextBox2.ReadOnly And TextBox5.ReadOnly Then
            MsgBox("没有可改动的项目")
            Return
        ElseIf TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox5.Text = "" Then
            MsgBox("修改信息不能为空")
            Return
        End If
        Dim tempStr As String = TextBox1.Text & "#" & TextBox2.Text & "#" & TextBox3.Text & "#" & TextBox5.Text
        Dim file As FileStream = New FileStream("D:\VB\expr2\expr2\MainInfo.txt", FileMode.Create)
        Dim fileWriter As New StreamWriter(file)
        fileWriter.WriteLine(tempStr)
        fileWriter.Flush()
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox5.ReadOnly = True
        MsgBox("修改成功")
    End Sub

End Class
