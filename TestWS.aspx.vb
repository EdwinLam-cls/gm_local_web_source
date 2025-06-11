Imports System.Xml.Serialization
Imports xmlService

Partial Class TestWS
    Inherits System.Web.UI.Page

    Protected Sub btnTest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Dim s1 As New Service1
        Dim dt As System.Data.DataTable
        Dim methodVals() As String = ddlForm.SelectedValue.Split("/")
        Select Case methodVals(0)
            Case "t_GeneralMills"
                dt = s1.t_GeneralMills("", "", "", "", "", "", "", "", "", "", "", "", tbVanNumber.Text, CalculateCheckCode("China Standard Time"), methodVals(1), tbAction.Text, "", "", "", tbTimeZone.Text)
                Dim ds As New System.Data.DataSet()
                ds.Tables.Add(dt)

                Dim sb As New StringBuilder
                sb.AppendFormat("There are {0} rows in this table{1}", dt.Rows.Count, Environment.NewLine)
                sb.Append(ds.GetXml())
                tbResult.Text = sb.ToString()
            Case "t_GeneralMills_q"
                tbResult.Text = s1.t_GeneralMills_q("", "", "", "", "", "", "", "", "", "", "", "", tbVanNumber.Text, CalculateCheckCode("China Standard Time"), methodVals(1), tbAction.Text, "", "", "", tbTimeZone.Text)

        End Select


    End Sub

    Protected Function CalculateCheckCode(ByVal tzID As String) As String
        Return CalculateCheckCode(TimeZoneInfo.FindSystemTimeZoneById(tzID))
    End Function

    Protected Function CalculateCheckCode(ByVal tzi As TimeZoneInfo) As String
        ' Check code
        Dim ck_code As String = String.Empty
        Dim dight As Integer
        Dim check_month As String = String.Empty
        Dim check_day As String = String.Empty
        Dim r1 As String = String.Empty
        Dim r2 As String = String.Empty
        Dim r3 As Integer = 0
        Dim clientDate As Date = TimeZoneInfo.ConvertTime(Now, tzi)

        r3 = Month(clientDate) + Day(clientDate) + Year(clientDate)
        dight = Int(r3 / 3)
        check_month = Month(clientDate)
        If check_month > 6 Then
            r1 = "@:"
        Else
            r1 = "#@"
        End If
        check_day = Day(clientDate)
        If check_day > 15 Then
            r2 = "^!"
        Else
            r2 = "$@"
        End If

        ' Generate Check code
        ck_code = CStr(Month(clientDate)) + r1 + CStr(Day(clientDate)) + r2 + CStr(Year(clientDate)) + CStr(dight)
        Return ck_code
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnTest.OnClientClick = "javascript:" & tbResult.ClientID & ".value=""reset"""

        m_txtDBConn.Text = "DBConn= " & DBConnUtil.GetConnectionString.ConnectionString
        m_txtEnv.Text = "GMIServer= " & System.Environment.GetEnvironmentVariable("GMIServer").ToUpper()
    End Sub


End Class
