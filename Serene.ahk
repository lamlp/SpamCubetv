RequireAdmin()
#NoEnv
#SingleInstance Force
playing:=0
SetWorkingDir %A_ScriptDir%
CoordMode Mouse,Window
SetControlDelay -1

MsgBox Made by Serene

Gui,+Alwaysontop
Gui Add, Text, x16 y8, Hành động:
Gui Add, DropDownList, x81 y5 w120 vModeClick, Left||Middle|Right|Text
Gui Add, Text, x215 y8 ,Delay:
Gui Add, Edit, x250 y5 w120 h21 vDelayTime number,100
Gui Add, Text, x374 y11 ,(ms)
Gui Add, Text, x16 y32 w60 h23 +0x200, Số lần chạy: ; Đặt 0 để chạy vô hạn lần
Gui Add, Edit, x81 y34 w65 h21 number vCount,
Gui Add, UpDown, x128 y32 w18 h21, 1
Gui Add, ListView, x16 y62 w391 h150 vMyListView, X|Y|Hành động|Delay|Cửa sổ
Gui Add, Button, x152 y222 w80 h23 gRunAuto , Chạy (F3)
Gui Add, Button, x240 y224 w80 h23 gStopAuto , Dừng (F4)
Gui Add, Button, x328 y224 w80 h23 gDellList, Xóa
Gui Show, , Serene

Menu, MyContextMenu, Add, Xóa, DellList
Menu, MyContextMenu, Add, Xóa tất cả, DellList

Return

F2::
if playing
   return
Gui,Submit,Nohide
MouseGetPos,,,WinHWND
WinActivate,ahk_id %WinHWND%
MouseGetPos,X,Y,
LV_Add("",X,Y,ModeClick,DelayTime,WinHWND)
LV_ModifyCol(1)
LV_ModifyCol(2)
return


F3::
RunAuto:
Dem:=0
Chay:=0
fileline:=0
Loop, Read, abc.txt
{
   total_lines = %A_Index%
}
Gui,Submit,Nohide
if (LV_GetCount()=0)
   return
if (Count=0)
   Count=-1
playing:=1
Loop
{
   if (Dem=LV_GetCount())
   {
     Dem:=0
     Chay++
   }
   if (Stop || Count=Chay)
     break
   Dem++
   Loop % LV_GetCount("Col")
     LV_GetText(Data_%A_Index%,Dem,A_Index)
   Sleep,% Data_4
   if Stop
     break
   Temp=%Data_3%
   if (Temp="Text")
   {
   fileline++
   FileReadLine, line, abc.txt, fileline
   if ErrorLevel
        break
   Send, %line%
   if (fileline=total_lines)
   fileline:=0
   }
   else
   ControlClick,x%Data_1% y%Data_2%,ahk_id %Data_5%,,%Data_3%,,NA

}
stop:=0
playing:=0
return

F4::
StopAuto:
if not playing
   return
Stop:=1
playing:=0
return

GuiContextMenu:
if A_GuiControl <> MyListView
  return
Menu, MyContextMenu, Show, %A_GuiX%, %A_GuiY%
return


DellList:
RowNumber = 0
if (A_ThisMenuItem="Xóa")
Loop
{
  RowNumber := LV_GetNext(RowNumber - 1)
  if not RowNumber
  break
  LV_Delete(RowNumber)
}
else
   LV_Delete()
return


GuiEscape:
GuiClose:
Esc::
  ExitApp

RequireAdmin()
{
CommandLine := DllCall("GetCommandLine", "Str")

If !(A_IsAdmin || RegExMatch(CommandLine, " /restart(?!\S)")) {
    Try {
        If (A_IsCompiled) {
            Run *RunAs "%A_ScriptFullPath%" /restart
        } Else {
            Run *RunAs "%A_AhkPath%" /restart "%A_ScriptFullPath%"
        }
    }
    ExitApp
}
}
 