   M S B A M L   `   `   `  ����J  FKikelet Panzió, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Kikelet_PanzióKikelet_Panzió  5   	   '    !Kikelet_Panzió.ReservationWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Kikelet_Panzió     5   	     � Title$  ReservationWindow��5   	   $	��450��6#   $	��800��60   .��5	      �� .+�5
   
   �� $��Vendég:��6   �� 5   
   -   5         ��Name$ cbGuest��5       �� SelectedIndex$ 0��6P   ��6$   �� *registeredGuestList+6P   �� 5   
   $��Szoba:��6   �� 5   
   -   5        $ cbRoom��5      $ 0��6#   �� 5   
   $��-Tól��6   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpFrom��5      �� 5   
   $	��-ig��6     5   
   -   5        $
 dpTo��5      �� 5   
   -   5         ��Name$ 
btnReserve��5      $��	Foglalás��6%   68   5      5      