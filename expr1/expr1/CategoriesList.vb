Public Class CategoriesList
    Shared category_instance As CategoriesList = Nothing
    Private Sub New()
    End Sub
    Public Shared ReadOnly Property Instance() As CategoriesList
        Get
            If category_instance Is Nothing Then
                category_instance = New CategoriesList()
            End If
            Return category_instance
        End Get
    End Property
    Private clothe1 As Commodity = New Commodity("幸福羊毛衫", 400, "30%")
    Private clothe2 As Commodity = New Commodity("幸福男裤", 350, "30%")
    Private clothe3 As Commodity = New Commodity("米奇T恤", 200, "30%")
    Private clothe4 As Commodity = New Commodity("真维斯衬衫", 180, "30%")
    Private shoe1 As Commodity = New Commodity("红蜻蜓女鞋", 500, "30%")
    Private shoe2 As Commodity = New Commodity("星期六女鞋", 600, "30%")
    Private shoe3 As Commodity = New Commodity("苹果男鞋", 550, "30%")
    Private shoe4 As Commodity = New Commodity("袋鼠男鞋", 400, "30%")
    Private shoe5 As Commodity = New Commodity("幸福童鞋", 260, "30%")
    Private bag1 As Commodity = New Commodity("鳄鱼皮包", 400, "30%")
    Private bag2 As Commodity = New Commodity("POLO女包", 500, "30%")
    Private bag3 As Commodity = New Commodity("米奇休闲包", 300, "30%")
    Private maquillage1 As Commodity = New Commodity("小护士大礼包", 100, "30%")
    Private maquillage2 As Commodity = New Commodity("欧莱雅保湿霜", 300, "30%")
    Private maquillage3 As Commodity = New Commodity("兰蔻眼霜", 350, "30%")
    Private bedding1 As Commodity = New Commodity("睡得香双人被", 400, "30%")
    Private bedding2 As Commodity = New Commodity("幸福4件套", 300, "30%")
    Private bedding3 As Commodity = New Commodity("舒服服按摩枕", 200, "30%")
    Private clothes() As Commodity = {clothe1, clothe2, clothe3, clothe4}
    Private shoes() As Commodity = {shoe1, shoe2, shoe3, shoe4, shoe5}
    Private bags() As Commodity = {bag1, bag2, bag3}
    Private maquillages() As Commodity = {maquillage1, maquillage2, maquillage3}
    Private beddings() As Commodity = {bedding1, bedding2, bedding3}
    Private clothing As Category = New Category("服装", clothes)
    Private shoe As Category = New Category("鞋子", shoes)
    Private bag As Category = New Category("箱包", bags)
    Private maquillage As Category = New Category("化妆品", maquillages)
    Private bedding As Category = New Category("床上用品", beddings)
    Private mjutilist() As Category = {clothing, shoe, bag, maquillage, bedding}
    Function Getkind(name As String) As Category
        For Each kindd In jutilist
            If kindd.Name.Equals(name) Then
                Return kindd
            End If
        Next
        Return Nothing
    End Function
    Function Getcommodity(name As String) As Commodity
        For Each kindd In jutilist
            If kindd.GetCommodity(name) IsNot Nothing Then
                Return kindd.GetCommodity(name)
            End If
        Next
        Return Nothing
    End Function
    Sub AllFirstTrue()
        For Each kindd In jutilist
            For Each commodity In kindd.CommodityList
                commodity.First = True
            Next
        Next
    End Sub
    Property jutilist() As Category()
        Get
            Return mjutilist
        End Get
        Set(value As Category())

        End Set
    End Property
End Class
