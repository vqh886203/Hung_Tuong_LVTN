   M S B A M L   `   `   `  ����J  FHung_Tuong_LVTN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Hung_Tuong_LVTNHung_Tuong_LVTN  5   	       Hung_Tuong_LVTN.SuaBDS   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   j fDevExpress.Xpf.LayoutControl.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  6R   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  6�   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   )localclr-namespace:Hung_Tuong_LVTN  5   	   -   5        $��Windows��5	   j     � Title$*  $SỬA THÔNG TIN BẤT ĐỘNG SẢN��6	    � WindowStartupLocation$ CenterScreen=�6,   $	��644��6Q   $	��700��6^    � Icon 6y   *  $DevExpress.Xpf.Core.DXImageExtension     Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$ Home_16x16.png .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��357* �6   �� 5      $
��335* �6    � RowDefinitions 5   
   �� 5      $	��67* �6   �� 5      $	��39* �6   �� 5      $	��12* �6   .+�5   
   .  (DevExpress.Xpf.LayoutControl.LayoutGroup     Orientation$ 
Horizontal=�6   $��0��64   $��2��6A   .+�5      -  'DevExpress.Xpf.LayoutControl.LayoutItem  $
��Left=�6   $	��320��69      Label$ Hình Ảnh��6F      LabelPosition$	 Top=�6W   	   LabelHorizontalAlignment$	 Center=�6k   $��0,0,-14,-194q�6�   $	��285��6�   
   Content.
 5      &   DevExpress.Xpf.Editors.ImageEdit  -   5        $	��img��5       $	��271��6+   5      0  *DevExpress.Xpf.LayoutControl.LayoutControl  5      $ Vertical=�6!   $
��Auto��68   $��10,0,0,0q�6F   .+�5        .+�5        -   5          Name$ layoutGroup��5   '   $ Vertical=�6<   $	��Top=�6S   .+�5           
IsRequired . $ Chiều Dài: ��6<   $	 Top=�6P   .
 5      %  DevExpress.Xpf.Editors.TextEdit  -   5        $��txtDai��5   +   $	��200��69      MaskType$ Numeric=�6H   5        5        . $ Chiều Rộng:��6<   $	 Top=�6P   .
 5!        -   5        $��txtRong��5!   +   $	��200��6:   $ Numeric=�6I   5"        5#       . $ Đơn Giá: ��6<   $	 Top=�6N   .
 5$        -   5        $��	txtDongia��5$   +   $	��200��6=   $ Numeric=�6L   5%      5'      5)        5*         Header$ 
Chi Tiết��6#   $ Vertical=�65    � UseLayoutRounding .    View$ GroupBox=�6e   $��0,5,0,0q�6u   .+�5+         . $ Tình Trạng:��68   .
 5,      )  #DevExpress.Xpf.Editors.ComboBoxEdit  -   5        $��cboTt��5,   ,   ��69   ��  �� ElementName$ layoutGroup��5-        5.       . $ Sở Hữu Của:��68   .
 5/      �� -   5        $��cboKh��5/   #    �� 
IsReadOnly . ��60   �� $ layoutGroup��6Z   50        51       . $ Loại BĐS: ��68   .
 52      �� -	   5        $��cboLoai��52   #    . ��62   �� $ layoutGroup��6\   53        54      $ Hoa Hồng:��6(   .
 55        -
   5        $��txtHh��55   '   $ Numeric=�64   ��6G   �� $ layoutGroup��56        57      $ Mã số QSDĐ:��6'   .
 58        -   5        $��	txtMsqsdd��58   '   ��68   �� $ layoutGroup��59      5<      5>      5?        5@   
   -   5        $��layoutGroup2��5@      $��1��62   $��0��6?   .+�5A        -   5        $��layoutGroup3��5A      $ 	Vị Trí��63   $ Vertical=�6C    . $ GroupBox=�6s   .+�5B        $ 
Số Nhà:��6"   $	��Top=�62   .
 5C        -   5        $��txtSonha��5C   #   $	��Top=�6^   ��63   �� $ layoutGroup2��6^   5D        5E      $ Tên Đường:��6"   .
 5F        -   5        $��txtDuong��5F   #   ��63   �� $ layoutGroup2��5G        5H      $ 
Phường:��6"   .
 5I        -   5        $��	txtPhuong��5I   #   ��64   �� $ layoutGroup2��5J        5K      $ Quận:��6"   .
 5L        -   5        $��txtQuan��5L   #   ��62   �� $ layoutGroup2��5M        5N      $ Thành Phố: ��6"   .
 5O        -   5        $��txtTP��5O   #   %	  DevExpress.Xpf.Editors.BaseEdit 	  AllowNullInput . ��60   �� $ layoutGroup2��6[   5P      5Q      5R      �� 5S   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��Center=�6;   $��142,0,140,5q�6X   $	��410��6m   $��2��6y   .+�5T      �� $ 
Horizontal=�6   $��50��62   $��0,5,0,0q�6>   $��Center=�6O   .+�5U      �� -   5        $��btnThem��5U      $	��200��6)   $��50��65   .��5V      �� $ 
Horizontal=�6!   $
��Auto��6:   $
��Auto��6G   .+�5W      �� $��60��6!   $��2q�6,   ��67     $ Apply_32x32.png 6f   �� 5X      $��Center=�6$   $��25(�6?   $��2q�6M   $��
Đồng Ý��6X   6h   5Y      5Z      �� 5[      -   5        $��btnXoa��5[      $	��200��6(   $��50��64   $��10,0,0,0q�6@   .��5\      �� $ 
Horizontal=�6!   $
��Auto��6:   $
��Auto��6G   .+�5]      �� $��60��6!   $��2q�6,   $��img/images.jpg��67   6R   �� 5^      $��Center=�6$   $��25(�6?   $��2q�6M   $��Thoát��6X   6g   5_      5`      5a      5b        5c   
   -   5        $��lcMota��5c      $��1��6+   $��1��68   .+�5d        $ Mô Tả��6   $ Vertical=�6.   $	��170��5e   D    . $ GroupBox=�6j   $	��Top=�6z   ��6   �� $ lcMota��.+�5f        -   5        $��txtMota��5f      $��0,0,0,10q�6.   �� 5g      -   5        $��btnThemHinh��5g   O   $��50��6   $
��Auto��6%   $��Center=�62   .��5h      �� $ 
Horizontal=�6!   .+�5i      �� $��60��6    ��6+     $ ImportImage_32x32.png 6_   �� 5j      $��Center=�6$   $��25(�6?   $��2q�6M   $��Thêm Hình��6X   6k   5k      5l      5m      5n      5p      5q      