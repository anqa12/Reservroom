   M S B A M L   `   `   `  ����E  AReservroom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Reservroom.ViewReservroom.View  5      =#clr-namespace:Reservroom.ViewModelsReservroom.ViewModels  6:   )    #Reservroom.View.MakeReservationView   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Reservroom.View     5      :
viewmodels#clr-namespace:Reservroom.ViewModels     6:   .��5	      �   � IsSharedSizeScope$
  True��6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��5      $��Make a Reservation��5       
  Header#��[  5      � 5   
   $��1��6   $��0 25 0 0q�6    5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��0��5      $��	Username:��5      $��16(�5      $��10q�5       �� 5!      $��1��5"      $��16(�5$      $��0 5 0 0q�5%      ��5#      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5%      5'      � 5)   
   $��2��6   $��0 10 0 0q�6    5*      �� 5+      $
��Auto �6    �� 5,      $
��Auto �6     � ColumnDefinitions 5.      �� 5/      $
��Auto �6#    z� SharedSizeGroup$ FirstCol��60   �� 50      $
��Auto �6#   $ 	SecondCol��60   .+�52      �� $��0��53      $��0��54      $��	Floor No.��55      $��16(�56      $��10q�57      �� 58      $��1��59      $��0��5:      $��16(�5<      $��0 5 0 0q�5=      ��5;      �� *FloorNumber+$ PropertyChanged=�5=      �� 5?      $��0��5@      $��1��5A      $��Room No.��5B      $��16(�5C      $��10q�5D      �� 5E      $��1��5F      $��1��5G      $��16(�5I      $��10 5 0 0q�5J      ��5H      �� *
RoomNumber+$ PropertyChanged=�5J      5K      � 5M   
   $��3��6   $��0 10 0 0q�6    5N      �� 5O      $
��Auto �6    �� 5P      $
��Auto �6     5R      �� 5S      $
��Auto �6#   $ FirstCol��60   �� 5T      $
��Auto �6#   $ 	SecondCol��60   .+�5V      �� $��0��5W      $��0��5X      $��
Start Date��5Y      $��16(�5Z      $��10q�5[      (  "System.Windows.Controls.DatePicker  5\      $��1��5]      $��0��5^      $��16(�5`      $��0 5 0 0q�5a         SelectedDate 5_      �� *	StartDate+$ PropertyChanged=�5a      �� 5c      $��0��5d      $��1��5e      $��End Date��5f      $��16(�5g      $��10q�5h        5i      $��1��5j      $��1��5k      $��16(�5m      $��10 5 0 0q�5n       5l      �� *	EndDate+$ PropertyChanged=�5n      5o      �� 5q   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $��0 25 0 0q�6;   .+�5r      �� $��Submit��6   ��6&   �� *SubmitCommand+�� 5s      $��Cancel��6   $��10 0 0 0q�6&   ��68   �� *CancelCommand+5t      5u      5v      