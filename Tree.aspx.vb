Imports System
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Web.Configuration

Partial Public Class Tree
	Inherits System.Web.UI.Page

	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
		If Not IsPostBack Then
            ' Check if there is any log in
			If TypeOf Session("mg_sid") Is String AndAlso TypeOf Session("mg_name") Is String Then
                ' TreeView 
				BuildTreeNode()
			End If
		End If
	End Sub

	Public Sub BuildTreeNode()
		Dim RootNode As New TreeNode()
        'Root 
		Dim TmpValue As String = ""
		Dim iCnt As Integer = -1
		Dim SqlString As String

        RootNode.Text = "Items"
		RootNode.Value = "0"
        ' RootNode.ToolTip = "Please click on items"
        RootNode.NavigateUrl = "javascript:chgcont('3001/3001.aspx')"

		tv_func.Nodes.Clear()
		tv_func.Nodes.Add(RootNode)

        If Session("mg_sid").ToString() = "1" Then
            ' System Admin
            SqlString = "Select f2.fi_no1, f1.fi_name1, f1.fi_name_eng1, 2.fi_no2, f2.fi_name2, f2.fi_name_eng2, f2.fi_url2"
            SqlString &= " From Func_Item2 f2"
            SqlString &= " Inner Join Func_Item1 f1 On f1.fi_no1 = f2.fi_no1"
            SqlString &= " Where f2.is_visible = 1 And f1.is_visible = 1"
            SqlString &= " Order by f1.fi_sort1, f2.fi_sort2"
        Else
            ' Regular user
            SqlString = "Select f1.fi_no1, f1.fi_name1, f1.fi_name_eng1, f2.fi_no2, f2.fi_name2, f2.fi_name_eng2, f2.fi_url2"
            SqlString &= " From Func_Power p"
            SqlString &= " Inner Join Func_Item2 f2 On f2.fi_no1 = p.fi_no1 And f2.fi_no2 = p.fi_no2"
            SqlString &= " Inner Join Func_Item1 f1 On f1.fi_no1 = p.fi_no1"
            SqlString &= " Where p.is_enable = 1 And f2.is_visible = 1 And f1.is_visible = 1 And p.mg_sid = " & Session("mg_sid").ToString()
            SqlString &= " Order by f1.fi_sort1, f2.fi_sort2"
        End If

		Using sql_conn As New SqlConnection(DBConnUtil.GetConnectionString().ConnectionString)
			sql_conn.Open()

			Using Sql_Command As New SqlCommand(SqlString, sql_conn)
				Using Sql_Reader As SqlDataReader = Sql_Command.ExecuteReader()
					While Sql_Reader.Read()
						If TmpValue <> Sql_Reader("fi_no1").ToString() Then
							iCnt += 1
							TmpValue = Sql_Reader("fi_no1").ToString()
							Dim ParentNode As New TreeNode()
                            ParentNode.Text = Sql_Reader("fi_name_eng1").ToString().Trim()

							ParentNode.Value = Sql_Reader("fi_no1").ToString()
                            ParentNode.NavigateUrl = "javascript:__doPostBack('tv_func','t0\\" & Sql_Reader("fi_no1").ToString & "')"
                            'ParentNode.NavigateUrl = "javascript:__doPostBack('tv_func','t0\\" & iCnt + 1 & "')"
							RootNode.ChildNodes.Add(ParentNode)
						End If
                        ' Build new node
						Dim ChildNode As New TreeNode()

                        ' Show text
                        ChildNode.Text = Sql_Reader("fi_name_eng2").ToString().Trim()

                        ' Set information
						ChildNode.Value = Sql_Reader("fi_no2").ToString()

                        ' Set URL
						ChildNode.NavigateUrl = "javascript:chgcont('" & Sql_Reader("fi_url2").ToString().Trim() & "')"
						RootNode.ChildNodes(iCnt).ChildNodes.Add(ChildNode)
					End While
					Sql_Reader.Close()
				End Using
			End Using
			sql_conn.Close()
		End Using
	End Sub
End Class