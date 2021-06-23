Sub CommandButton1_Click()
    Sheets("Sheet1").DisplayRightToLeft = True
    Call CreateWorksheets(Sheets("Sheet1").Range("A2:A613"))

End Sub

Sub CreateWorksheets(Names_Of_Sheets As Range)
Dim No_Of_Sheets_to_be_Added As Integer
Dim Sheet_Name As String
Dim i As Integer

No_Of_Sheets_to_be_Added = Names_Of_Sheets.Rows.Count

For i = 1 To No_Of_Sheets_to_be_Added

    Sheet_Name = Names_Of_Sheets.Cells(i, 1).Value

'Only add sheet if it doesn't exist already and the name is longer than zero characters

    If (WorksheetExists(Sheet_Name) = False) And (Sheet_Name <> "") Then
        Worksheets.Add().Name = Sheet_Name
        Worksheets(Sheet_Name).DisplayRightToLeft = True
        Sheets("Sheet1").Rows.EntireRow(1).Copy
        Worksheets(Sheet_Name).Rows(1).Insert
        Names_Of_Sheets.EntireRow(i).Cut
        Worksheets(Sheet_Name).Rows(2).Insert
        'Worksheets(Sheet_Name).Range("A1").EntireRow.Insert
    
    ElseIf (WorksheetExists(Sheet_Name) = True) And (Sheet_Name <> "") Then
        Names_Of_Sheets.EntireRow(i).Cut
        Worksheets(Sheet_Name).Rows(2).Insert
        'Worksheets(Sheet_Name).Range("A1").End(xlDown).Offset(1, 0).EntireRow.Insert
    End If

Next i

End Sub
Function Sheet_Exists(WorkSheet_Name As String) As Boolean
Dim Work_sheet As Worksheet

Sheet_Exists = False

For Each Work_sheet In ThisWorkbook.Worksheets

    If Work_sheet.Name = WorkSheet_Name Then
        Sheet_Exists = True
    End If

Next

End Function
Function WorksheetExists(shtName As String, Optional wb As Workbook) As Boolean
    Dim sht As Worksheet

    If wb Is Nothing Then Set wb = ThisWorkbook
    On Error Resume Next
    Set sht = wb.Sheets(shtName)
    On Error GoTo 0
    WorksheetExists = Not sht Is Nothing
End Function
