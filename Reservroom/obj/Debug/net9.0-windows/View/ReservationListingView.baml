   M S B A M L   `   `   `  ����E  AReservroom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Reservroom.ViewReservroom.View  5      =#clr-namespace:Reservroom.ConvertersReservroom.Converters  5      P LLoadingSpinnerControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null\Bclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControlLoadingSpinnerControl 6E   ,    &Reservroom.View.ReservationListingView   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Reservroom.View     5      :
converters#clr-namespace:Reservroom.Converters     5      UcustomBclr-namespace:LoadingSpinnerControl;assembly=LoadingSpinnerControl     6E     � 	Resources  5
          BooleanToVisibilityConverter?   9Reservroom.Converters.InverseBooleanToVisibilityConverter ' #InverseBooleanToVisibilityConverter��%:   &	        &	      �� 5   
   6'     5   
   6g   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��auto �6#   .+�5      �� $��0��6   $��View Reservations��6(    
 Header#��[ 6A   �� 5      $��1��6   $��Make Reservation��6%   $��10 0 0 0q�6@   ��6R   �� *MakeReservationCommand+5      � 5    
   $��1��6   $��0 25 0 0q�6   .+�5"      *  $LoadingSpinnerControl.LoadingSpinner     Diameter$	 100Q�5#         	Thickness$ 5Q�5$         Color
 �   �   	IsLoading 5%      �� *	IsLoading+5&      � 5(      y�6   �� *	IsLoading+ �� 	Converter# [ .+�5*      �� 
���  ��$��16(�6G   $��10 0 0 0q�6U   ��6   �� *
ErrorMsg+y�6g   �� *HasErrorMsg+# [  �� 5,      ��6   �� *Reservations+y�6@   �� *HasErrorMsg+# [ ��5-      �� 5.       �� 
TargetType" ��6    .�5/      �� 	 �� Property	 � ��
 �� Value$
 Center=�6K   50       �� View 52      �� 53      .P�54      �� $��Room ID��6-    �� CellTemplate 55   "   �� 56   &   .R�57   *   �� ��64   �� *RoomID+58   '   5:      �� 5<      $��Username��6-    5=   "   �� 5>   &   .R�5?   *   �� ��64   �� *
Username+5@   '   5B      �� 5D      $��
Start Date��6-    5E   "   �� 5F   &   .R�5G   *   �� ��64   �� *StartDateFormatted+5H   '   5J      �� 5L      $��End Date��6-    5M   "   �� 5N   &   .R�5O   *   �� ��64   �� *EndDateFormatted+5P   '   5R      5S      5U      5V      5W      5X      5Y      