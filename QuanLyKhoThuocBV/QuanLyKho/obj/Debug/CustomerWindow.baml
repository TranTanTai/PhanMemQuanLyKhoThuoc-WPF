   M S B A M L   `   `   `  ����D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLyKho	QuanLyKho  5   	   ?$clr-namespace:QuanLyKho.UserControlTQuanLyKho.UserControlT  5	   	       QuanLyKho.CustomerWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QuanLyKho     5   	   3uc$clr-namespace:QuanLyKho.UserControlT     5	   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5          �Name$  window��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	     
CustomerVM � DataContext# [ 5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$ icon.ico��5   	    � Title$ 
Phòng Ban��5   	   $	��500��6   $	��650��6(   ��5      �� 5   
    �� ImageSource$ background.jpg��6   .��5      � 	 J� InputBindings	 5   
   �� 5      

 �� Key$
 F2��6    �� Command 6"   �� *
AddCommand+�� 5      $
 F3��6    6"   �� *EditCommand+ � RowDefinitions 5   
   �� 5       $
��auto �6   6,   �� 5!      6   .+�5#   
   � $��0��6   .+�5$      )   #QuanLyKho.UserControlT.ControlBarUC  
 � Tag 6   �� *Title+ �� ElementName$ window��6J   5%      � 5'   
   $��1��6    5(      �� 5)      $
��auto �6    60   �� 5*      $
��auto �6    60   �� 5+      6"   .+�5/      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��50      � $��0 0 0 10q�6   .+�51      �� $��5 5 15 5q�6m   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên phòng ban��6    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6   �� *DisplayName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 52      $��5 5 15 5q�6g   $ Điện thoại��6y   #��[ 6�   ��6   �� *Phone+$ PropertyChanged=�$ TwoWay=�6�   �� 53      $��5 5 15 5q�6j   $ Thông tin thêm��6|   #��[ 6�   ��6   �� *
MoreInfo+$ PropertyChanged=�$ TwoWay=�6�   55      56        58      $��1��6"   $��5 0 5 5q�6/   .��59      � .+�5:      �� $��
_Thêm(F2)��6<   $��5q�6P   $	��100��6[   
����  �
����  � �� 	IsDefault . ��6   �� *
AddCommand+6�   �� 5;      $��_Sửa(F3)��6=   $��5q�6Q   $	��100��6\   
����  �
����  ���6   �� *EditCommand+6�   5<      5=        5?      $��2��6"   $��5q�6/   $��Stretch=�6:   .��5@      �� $
��Auto=�6   .��5A      �� ��6   �� *List+ �� SelectedItem 6<   �� *SelectedItem+$ OneWayToSource=� �� View 5B      �� 5C      .P�5D   "   ��  �� DisplayMemberBinding 61   �� *Id+.��5E   &   �� ��6;   �� *SortIdCommand+.��6]   Id5G   '   5H   #   �� 5I   "    61   �� *DisplayName+.��5J   &   �� ��6;   �� *SortDisplaynameCommand+.��6f   Tên phòng ban5L   '   5M   #   �� 5N   "    61   �� *Phone+.��5O   &   �� ��6;   �� *SortPhoneCommand+.��6`   Điện thoại5Q   '   5R   #   �� 5S   "    61   �� *
MoreInfo+.��5T   &   �� ��6;   �� *SortMoreInfoCommand+.��6c   Thông tin thêm5V   '   5W   #   5X      5Z      5[      5\      5]      5^      5_      