   M S B A M L   `   `   `  ����D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLyKho	QuanLyKho  5   	   ?$clr-namespace:QuanLyKho.UserControlTQuanLyKho.UserControlT  5	   	       QuanLyKho.UserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QuanLyKho     5   	   3uc$clr-namespace:QuanLyKho.UserControlT     5	   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5          �Name$  window��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    
 UserVM � DataContext# [ 5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$ icon.ico��5   	    � Title$ Tài khoản��5   	   $	��500��6   $	��700��6(   ��5      �� 5   
    �� ImageSource$ background.jpg��6   .��5      � 	 J� InputBindings	 5   
   �� 5      

 �� Key$
 F2��6    �� Command 6"   �� *
AddCommand+�� 5      $
 F4��6    6"   �� *DeleteCommand+�� 5      $
 F6��6    6"   �� *ChangePasswordCommand+ � RowDefinitions 5!   
   �� 5"      $
��auto �6   6,   �� 5#      6   .+�5%   
   � $��0��6   .+�5&      )   #QuanLyKho.UserControlT.ControlBarUC  
 � Tag 6   �� *Title+ �� ElementName$ window��6J   5'      � 5(   
   $��1��6    5)      �� 5*      $
��auto �6    60   �� 5+      $
��auto �6    60   �� 5,      6"   .+�5/      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��50      � $��0 0 0 10q�6   .+�51      �� $��5 5 15 5q�6]   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đăng nhập��6o    % !MaterialDesignFloatingHintTextBox#��[ 6�    �� 	MaxLength$ 20��6�   ��6   �� *
UserName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 52      $��5 5 15 5q�6    �� DisplayMemberPath$ DisplayName��61   $ Quyền��6�    �� 
IsEditable .  & "MaterialDesignFloatingHintComboBox#��[ 6   ��6Q   �� *Role+ �� SelectedItem 6n   �� *SelectedRole+ �� Mode$ TwoWay=�$ PropertyChanged=�6>  �� 53      $��5 5 15 5q�6`   $ Tên hiển thị��6r   #��[ 6�   ��6   �� *DisplayName+$ PropertyChanged=�6�   �� 54      $��
_Thêm(F2)��6<   $��5 0 0 2q�6P   $	��100��6a   
����  �
����  �$��Center=�6�   $��Bottom=�6�    �� 	IsDefault . ��6   �� *
AddCommand+6�   55      56        58      $��1��6"   $��5 0 5 5q�6/   .��59      � .+�5:      �� $��
_Xóa(F4)��6?   $��5q�6S   $��90��6^   
����  �
����  ���6   �� *DeleteCommand+6�   �� 5;      $!��_Thay đổi thông tin(F6)��6G   $��5q�6i   $	��165��6t   
����  �
����  �$	��5,4q�6�   ��6   �� *ChangePasswordCommand+6�   5<      5=        5?      $��2��6"   $��5q�6/   $��Stretch=�6:   .��5@      �� $
��Auto=�6   .��5A      �� ��6   �� *List+ 6<   �� *SelectedItem+$ OneWayToSource=� �� View 5B      �� 5C      .P�5D   "   �� $��Id��61    �� DisplayMemberBinding 6=   �� *Id+6c   �� 5E   "   $��Tên đăng nhập��61    6I   �� *
UserName+6u   �� 5F   "   $��Chức vụ��61    6D   �� *UserRole.DisplayName+6|   �� 5G   "   $��Tên hiển thị��61    6I   �� *DisplayName+6x   5H      5J      5K      5L      5M      5N      5O      