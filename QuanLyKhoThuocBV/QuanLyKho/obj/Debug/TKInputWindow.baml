   M S B A M L   `   `   `  ����D  @QuanLyKho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:QuanLyKho	QuanLyKho  5   	   ?$clr-namespace:QuanLyKho.UserControlTQuanLyKho.UserControlT  5   	       QuanLyKho.TKInputWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:QuanLyKho     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   -uc$clr-namespace:QuanLyKho.UserControlT  5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��tkinputWindow��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignFont#���  5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$ icon.ico��5   	     	TKInputVM � DataContext# [ 5   	    � Title$ Thống kê nhập hàng��5   	   $	��500��6$   $	��750��61   ��5      �� 5   
    �� ImageSource$ background.jpg��6   .��5      �  J� InputBindings 5   
   �� 5      
	 �� Key$	 F4��6   
 �� Command
 6"   �� *DeleteCommand+�� 5      $	 F7��6   
 6"   �� *ExportExcelCommand+�� 5       $	 F8��6   
 6"   �� *SearchCommand+ � RowDefinitions 5"   
   �� 5#      $
��auto �6   6,   �� 5$      6   .+�5&   
   � $��0��6   .+�5'      )   #QuanLyKho.UserControlT.ControlBarUC  
 � Tag 6   �� *Title+ �� ElementName$ tkinputWindow��6Q   5(      � 5)   
   $��1��6    5*      �� 5+      $
��auto �6    60   �� 5,      6"   .+�5.      #  MaterialDesignThemes.Wpf.Card  $��0��6"   $��5q�6/   .��5/      � $��5q�6    � ColumnDefinitions 50      �� 51      $
��auto �6+   6:   �� 52      $
��auto �6+   6:   �� 53      $
��auto �6+   6:   �� 54      $
��auto �6+   6:   �� 55      6-   .+�57      � $��0��6   .+�58      (  "System.Windows.Controls.DatePicker  $��Center=�6�   $
��Left=�6�   $	��100��6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Ngày bắt đầu��6�    ( $MaterialDesignFloatingHintDatePicker#��[ 6     SelectedDate 6%   �� *	StartDate+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� StringFormat$ 
dd/MM/yyyy��6  59      � 5:      $��1��6   .+�5;        $��Center=�6�   $
��Left=�6�   $	��100��6�   $ Ngày kết thúc��6�   #��[ 6   6%   �� *	EndDate+$ TwoWay=�$ PropertyChanged=�$ 
dd/MM/yyyy��6  5<      � 5=      $��2��6   .+�5>      ��   MaterialDesignRaisedButton#��[ 6!   $��5q�6U   $	��100��6`   
����  �
����  �$��
_Lọc(F8)��5?   N    � ToolTip$/ )Resource name: MaterialDesignRaisedButton��6b   ��6,   �� *SearchCommand+6�   5@      � 5A      $��3��6   .+�5B      �� #��[ 6H   $	��160��6|   $��-16 4 -16 4q�6�   $��5q�6�   
����  �
����  ���6!   �� *ExportExcelCommand+.��5C      � $��Center=�6#    5D   "   �� 5E   &   69   �� 5F   &   69   .+�5H   "   � $��0��6'   .+�5I   &   '  !MaterialDesignThemes.Wpf.PackIcon  $��20��6>   $��28��6I   $��0 0 7 3q�6V   $��Center=�6g   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=null]]   Kind$ 	FileExcel=�6�   5J   #   � 5K   "   $��1��6'   .+�5L   &   �� $��Xuất excel(F7)��60   $��Center=�6F   6c   5M   #   5N      5O      5P      � 5Q      $��4��6   $��Right=�6+   .+�5R      �� #��[ 6!   $��5q�6U   $��80��6`   
����  �
����  �$��	_Xóa(F4)��5S   N   ��6,   �� *DeleteCommand+6c   5T      5U      5V        5X      $��1��6"   $��5q�6/   $��Stretch=�6:   .��5Y      �� $
��Auto=�6   .��5Z      �� ��6   �� *List+ �� SelectedItem 6<   �� *SelectedItem+$ OneWayToSource=� �� View 5[      �� 5\      .P�5]   "   ��  �� Width$ 55��6U    �� DisplayMemberBinding 61   �� *Id+.��5^   &   �� $��Right=�6<   ��6X   �� *SortIdCommand+.��6z   ID5`   '   5a   #   �� 5b   "    61   �� *Object.DisplayName+.��5c   &   �� ��6;   �� *SortObjectDisplayNameCommand+.��6l   Sản phẩm5e   '   5f   #   �� 5g   "    61   �� *Input.DateInput+$ 
dd/MM/yyyy��.��5h   &   �� ��6;   �� *SortDateInputCommand+.��6d   Ngày nhập5j   '   5k   #   �� 5l   "    61   �� *Count+$ TwoWay=�.��5m   &   �� $��Right=�6`   ��6;   �� *SortCountCommand+.��6|   Số lượng5o   '   5p   #   �� 5q   "    61   �� *
InputPrice+.��5r   &   �� ��6;   �� *SortInputPriceCommand+.��6e   Giá nhập5t   '   5u   #   �� 5v   "    61   �� *Status+.��5w   &   �� ��6;   �� *SortStatusCommand+.��6a   Trạng thái nhập5y   '   5z   #   5{       �� 
GroupStyle 5}      (  "System.Windows.Controls.GroupStyle  5~         HeaderTemplate 5   "   �� 5�   &   .R�5�   *   ��  �� Orientation$ 
Horizontal=�65   .+�5�   .   �� $
��Bold"�68   $��13(�6J   $��18 5 0 0q�6X   $��Mã đơn nhập: ��6j   �� 5�   .   $
��Bold"�68   $��58��6J   $��13(�6U   $��0 5 0 0q�6c   ��6t   �� *Name+5�   +   5�   '   5�      5�      5�      5�      5�      5�      5�      