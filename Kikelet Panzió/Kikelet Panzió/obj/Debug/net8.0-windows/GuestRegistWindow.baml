   M S B A M L   `   `   `  ����J  FKikelet Panzió, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Kikelet_PanzióKikelet_Panzió  5   	   '    !Kikelet_Panzió.GuestRegistWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Kikelet_Panzió     5   	     � Title$  GuestRegistWindow��5   	   $	��450��6#   $	��800��60   .��5	      �� .+�5
   
   �� .��6   Vendég regisztrálása6&   �� 5   
   .+�5      �� .��6   Név:6   �� 5      -   5         ��Name$ tbName��5      5      �� 5   
   .+�5      �� .��6   Születési dátum:6&   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpBirth��5      5      �� 5   
   .+�5      �� .��6   E-mail cím6    �� 5      -   5        $ tbEmail��5      5      �� 5   
   .+�5      �� .��6   	Ország6   �� 5      -   5        $ 	tbCountry��5      5      �� 5   
   .+�5      �� .��6   Irányító szám6#   �� 5      -   5        $ tbZip��5      5      �� 5   
   .+�5       �� .��6   Város6   �� 5!      -   5        $ tbCity��5!      5"      �� 5#   
   .+�5$      �� .��6   Cím6   �� 5%      -   5        $ 	tbAddress��5%      5&      �� 5'   
   .+�5(      �� -   5         ��Name$ cbVIP��5(      $	��VIP��6&   �� 5)      -	   5        $ cbBanned��5)      $��Banned��6)   5*      �� 5+   
   -
   5         ��Name$ btnRegister��5+      $��Regisztrálás��6&   6=   5,      5-      