   M S B A M L   `   `   `  ����N  JAnimalBehaviorVideo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:AnimalBehaviorVideoAnimalBehaviorVideo  5   	   !    AnimalBehaviorVideo.Syncbox   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:AnimalBehaviorVideo     5   	     � SizeToContent$  WidthAndHeight=�5       � WindowStartupLocation$ CenterScreen=�69    � Title$ Syncbox��5   	   $
��auto��6   $
��auto��6'   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� -   5        $��lbl_syncbox_msg��5      $��0��6   $1��+Please enter start time for synchronization��64   $��14(�6j   $��5q�6x   6�   �� 5   
   -   5        $��txt_time��5      $��1��6   $��hh:mm:ss��6/   $	��200��6?   $��Stretch=�6K   $��5q�6i   $��14(�6t   $��Center=�6�   $��Center=�6�   6  � 5   
   $��2��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5      �� -   5        $��btn_syncbox_OK��5   6   $��0��6    �� 	IsDefault$
 True��6%   $��OK��6L   $��20��6Y   $��4q�6e   6�   �� 5      -   5        $��btn_syncbox_Cancel��5   5   $��1��6    �� IsCancel$
 True��6%   $��Cancel��6O   $��20��6`   $��4q�6l   6y   5      5      5      