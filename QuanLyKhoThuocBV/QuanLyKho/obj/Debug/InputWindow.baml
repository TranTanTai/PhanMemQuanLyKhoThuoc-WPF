   M S B A M L   `   `   `  ����D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLyKho	QuanLyKho  5   	   ?$clr-namespace:QuanLyKho.UserControlTQuanLyKho.UserControlT  5	   	       QuanLyKho.InputWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QuanLyKho     5   	   3uc$clr-namespace:QuanLyKho.UserControlT     5	   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5          �Name$  window��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	     InputVM � DataContext# [ 5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$ icon.ico��5   	    � Title$ 
Nhập Kho��5   	   $	��650��6   $	��850��6'   ��5      �� 5   
    �� ImageSource$ background.jpg��6   .��5      � 	 J� InputBindings	 5   
   �� 5      

 �� Key$
 F2��6    �� Command 6"   �� *
AddCommand+�� 5      $
 F1��6    6"   �� *SaveCommand+�� 5      $
 F5��6    6"   �� *DeleteCommand+�� 5      $
 F6��6    6"   �� *	TKCommand+ � RowDefinitions 5!   
   �� 5"      $
��auto �6   6,   �� 5#      6   .+�5%   
   � $��0��6   .+�5&      )   #QuanLyKho.UserControlT.ControlBarUC  
 � Tag 6   �� *Title+ �� ElementName$ window��6J   5'      � 5)   
   $��1��6    5*      �� 5+      $
��auto �6    60   �� 5,      $
��auto �6    60   �� 5-      6"   .+�51      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��52      � $��0 0 0 10q�6   .+�53      �� $��5 5 15 5q�6    �� DisplayMemberPath$ DisplayName��61   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên sản phẩm��6�    �� 
IsEditable .  & "MaterialDesignFloatingHintComboBox#��[ 6
  ��6Q   �� *Object+ �� SelectedItem 6p   �� *SelectedObject+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6H  (  "System.Windows.Controls.DatePicker  54      $��Center=�6!   $	��100��6�   $��	5 5 15 -7q�6�   $ Ngày nhập��6�    ( $MaterialDesignFloatingHintDatePicker#��[ 6�      SelectedDate 6<   �� *	DateInput+$ TwoWay=�$ PropertyChanged=�6�   �� 55      $��5 5 15 5q�6g    �� 	MaxLength$ 10��6y   $ Số lượng��6�    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6   �� *Count+$ PropertyChanged=�$ TwoWay=�6�   �� 56      $��5 5 15 5q�6l   $ 20��6~   $ Giá nhập��6�   #��[ 6�   ��6   �� *
InputPrice+$ PropertyChanged=�$ TwoWay=�6�   �� 57      $��5 5 15 5q�6h   $ 40��6z   $ Trạng thái nhập��6�   #��[ 6�   ��6   �� *Status+$ PropertyChanged=�$ TwoWay=�6�   �� 58      $��	Thêm(F2)��6<   $��5 10 0 0q�6O   $	��100��6a   
����  �
����  � �� 	IsDefault . ��6   �� *
AddCommand+6�   59      5:        5<      $��1��6"   $��5 0 5 5q�6/   .��5=      � $��0��6   .+�5>      �� $��	_Lưu(F1)��6=   $��5q�6P   $	��100��6[   
����  �
����  ���6   �� *SaveCommand+6�   �� 5?      $��_Tạo lại(F5)��6?   $��5q�6V   $	��100��6a   
����  �
����  ���6   �� *DeleteCommand+6�   5@      5A        5C      $��2��6"   $��5q�6/   $��Stretch=�6:   .��5D      �  5E      �� 5F      6*   �� 5G      $
��auto �6(   68   .+�5I      �� $��0��6#   $
��Auto=�60   .��5J      &   System.Windows.Controls.DataGrid  $��0 8 0 0q�5K         CanUserSortColumns .    CanUserAddRows .     AutoGenerateColumns .  -  'MaterialDesignThemes.Wpf.DataGridAssist   ColumnHeaderPadding$ 8q�5Q      $ �� IsSynchronizedWithCurrentItem$
 TrueY�6S   ��5L      �� *NhapKhoList+ 5M      �� *SelectedItem+   Columns 5R      0  *System.Windows.Controls.DataGridTextColumn  5S   "   ,	  &System.Windows.Controls.DataGridColumn 	  Header$ Tên sản phẩm��5U   %    0 ,MaterialDesignDataGridTextColumnEditingStyle1
  +System.Windows.Controls.DataGridBoundColumn 
  EditingElementStyle# [ 5V   %     	  
IsReadOnly  . ! 
  Binding! 5T   %   �� *Object.DisplayName+5V   y   9  3MaterialDesignThemes.Wpf.MaterialDataGridTextColumn  5W   "   $ Số lượng��5Z   %   # [ 5[   %   "   	MaxLength$" 10��6y   ! 5X   %   �� *Count+$ PropertyChanged=�$ TwoWay=�# 
  ClipboardContentBinding# 5Y   %   �� *Count+$ 	  HeaderStyle$ 5\   &   �� 5]   *   % �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"%  5^   -    & "MaterialDesignDataGridColumnHeader& �� BasedOn#& [ 5_   -   .�5`   .   �� ' �� Property' � ��( �� Value$( Right=�6T   5a   +   ) 
  ElementStyle) 5c   &   �� 5d   *   "% ��60   .�5e   .   �� ' � ��$( Right=�6T   5f   +   5h   #     5i   "   $ Giá nhập��5l   %   # [ 5m   %   $" 20��6y   ! 5j   %   �� *
InputPrice+$ PropertyChanged=�$ TwoWay=�# 5k   %   �� *
InputPrice+$ 5n   &   �� 5o   *   "%  5p   -   #& [ 5q   -   .�5r   .   �� ' � ��$( Right=�6T   5s   +   ) 5u   &   �� 5v   *   "% ��60   .�5w   .   �� ' � ��$( Right=�6T   5x   +   5z   #     5{   "   $ Trạng thái nhập��5}   %   # [ 5~   %   $" 40��6y   ! 5|   %   �� *Status+$ PropertyChanged=�$ TwoWay=�5~   y   5�      5�      � 5�      $��1��6   $��5q�6(   $
��Left=�63   .+�5�      ��   MaterialDesignRaisedButton#��[ 6!   $��5q�6U   $	��235��6`   
����  �
����  �$*��$_Danh sách phiếu nhập hàng(F6)��5�   J   ��6,   �� *	TKCommand+6u   5�      5�      5�      5�      5�      5�      