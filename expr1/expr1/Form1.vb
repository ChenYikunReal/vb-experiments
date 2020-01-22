Public Class Form1
    Dim counter As Integer = 0
    Dim nowkind As Category
    Dim nowcommodity As Commodity
    Dim nextkind As Category
    Dim lastcommodity As Commodity
    Public mkindlist As CategoriesList = CategoriesList.Instance
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each element In mkindlist.jutilist
            ComboBox1.Items.Add(element.Name)
            ComboBox3.Items.Add(element.Name)
        Next

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListBox1.Items.Clear()
        Dim name As String = ComboBox1.Text
        Dim names() As String = {""}
        For Each element In mkindlist.jutilist
            If name.Equals(element.Name) Then
                nowkind = element
                names = element.GetNames
                Exit For
            End If
        Next
        ListBox1.Items.AddRange(names)
    End Sub

    Private Sub ListBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseClick
        '得到当前所选择的商品
        nowcommodity = nowkind.GetCommodity(ListBox1.SelectedItem.ToString())
        If nowcommodity.First = True Then
            nowcommodity.SoldCount()
        End If
        '在上面的框里面把当前商品的各个属性写入(如名字价格等)
        NameTextBox.Text = nowcommodity.Name
        NumberTextBox.Text = "1"
        PriceTextBox.Text = nowcommodity.Price
        If nowcommodity.First = True And (nowcommodity.CountNumber >= 0) Then
            CountTextBox.Text = nowcommodity.Count
        Else
            CountTextBox.Text = "0%"
        End If
        Dim mCountDouble As Double = Convert.ToDouble(CountTextBox.Text.Replace("%", "")) / 100
        nowcommodity.First = False
        '将属性添加到表格里面
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.Rows.Add({nowcommodity.Name, "1", nowcommodity.Price, CountTextBox.Text, nowcommodity.Price * (1 - mCountDouble)})
        '计算总额的和并将其写入“应付款”里面
        Dim count As Integer = Me.DataGridView1.Rows.Count
        Dim sum As Double = 0
        For i = 0 To count - 1
            sum += Val(Me.DataGridView1.Item("总额", i).Value)
        Next
        TextBox7.Text = Convert.ToString(sum)
    End Sub

    Private Sub clearTextBoxes()
        NameTextBox.Text = ""
        NumberTextBox.Text = ""
        PriceTextBox.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox9.Text = "缴费不足或金额格式有误" Then
                MsgBox("支付金额不足！")
            ElseIf Convert.ToDouble(TextBox9.Text) > 100 Then
                MsgBox("零钱在100.00元以内才提供找零")
            ElseIf TextBox9.Text = "" Then
                MsgBox("输入错误！")
            Else
                MsgBox("结账成功！")
                clearTextBoxes()
                CountTextBox.Text = ""
                DataGridView1.Rows.Clear()
                TextBox7.Text = ""
                TextBox8.Text = ""
                TextBox9.Text = ""
                mkindlist.AllFirstTrue()
            End If
        Catch ex As Exception
            clearTextBoxes()
        End Try
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged
        Try
            If TextBox7.Text = "" Then
                'Do nothing
            ElseIf "" = TextBox8.Text Or Convert.ToDouble(TextBox7.Text) > Convert.ToDouble(TextBox8.Text) Then
                TextBox9.Text = "缴费不足或金额格式有误"
            Else
                TextBox9.Text = Convert.ToString(Convert.ToInt32(TextBox8.Text) - Convert.ToInt32(TextBox7.Text))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        ComboBox2.Items.Clear()
        ComboBox2.Text = ""
        Dim name As String = ComboBox3.Text
        Dim names() As String = {""}
        For Each element In mkindlist.jutilist
            If name.Equals(element.Name) Then
                nextkind = element
                names = element.GetNames
                Exit For
            End If
        Next
        ComboBox2.Items.AddRange(names)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim name As String = ComboBox2.Text
        TextBox2.Text = name
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '确认
        If Not TextBox5.ReadOnly Then
            MsgBox("请先确认产品信息")
            Return
        End If
        lastcommodity.Price = Convert.ToInt16(TextBox3.Text)
        lastcommodity.Count = TextBox1.Text
        TextBox5.ReadOnly = False
        TextBox5.Text = ""
        TextBox1.Text = ""
        TextBox3.Text = ""
        MsgBox("修改成功")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '查询
        Dim Flag As Boolean = False
        For Each element In mkindlist.jutilist
            For Each obj In element.CommodityList
                If TextBox5.Text = obj.Name Then
                    TextBox1.Text = obj.Count
                    TextBox3.Text = obj.Price
                    Flag = True
                    lastcommodity = obj
                End If
            Next
        Next
        If Not Flag Then
            MsgBox("找不到商品")
            Return
        End If
        MsgBox("查找成功")
        TextBox5.ReadOnly = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        '重查
        TextBox5.ReadOnly = False
        TextBox5.Text = ""
        TextBox1.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim text1 As String = ComboBox3.Text
        Dim text2 As String = ComboBox2.Text
        Dim text3 As String = TextBox2.Text
        If text1 = "" Or text1 = "请选择" Or text2 = "" Or text2 = "请选择" Or text3 = "" Then
            MsgBox("修改失败")
            Return
        End If
        For Each element In mkindlist.jutilist
            If text3 = element.Name Then
                MsgBox("修改失败")
                Return
            Else
                For Each obj In element.CommodityList
                    If text3 = obj.Name Then
                        MsgBox("修改失败")
                        Return
                    End If
                Next
            End If
        Next
        '检查后OK
        For Each element In nextkind.CommodityList
            If text2 = element.Name Then
                element.Name = text3
            End If
        Next
        '后续完善
        MsgBox("修改完成")
        ComboBox2.Text = ""
        ComboBox3.Text = ""
        TextBox2.Text = ""
    End Sub


End Class
