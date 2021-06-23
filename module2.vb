Sub Sort_Active_Book()
Dim i As Integer
Dim j As Integer
Dim key As String
Dim iAnswer As VbMsgBoxResult
'
' Prompt the user as which direction they wish to
' sort the worksheets.
'
   iAnswer = MsgBox("Sort Sheets in Ascending Order?" & Chr(10) _
     & "Clicking No will sort in Descending Order", _
     vbYesNoCancel + vbQuestion + vbDefaultButton1, "Sort Worksheets")
   
   For i = 2 To Sheets.Count
      key = Sheets(i).Name
      j = i - 1
'
' If the answer is Yes, then sort in ascending order.
'
         If iAnswer = vbYes Then
            While j >= 1 And Sheets(j).Name > key
               Sheets(j + 1).Move After:=Sheets(j)
               j = j - 1
            Wend
            Sheets(key).Move After:=Sheets(j + 1)
'
' If the answer is No, then sort in descending order.
'
         ElseIf iAnswer = vbNo Then
            While j >= 1 And Sheets(j).Name < key
               Sheets(j).Move After:=Sheets(j + 1)
               j = j - 1
            Wend
            Sheets(key).Move After:=Sheets(j + 1)
         End If
   Next i
End Sub

