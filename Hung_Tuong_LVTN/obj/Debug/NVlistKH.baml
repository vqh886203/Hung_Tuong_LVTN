   M S B A M L   `   `   `  ����J  FHung_Tuong_LVTN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Hung_Tuong_LVTNHung_Tuong_LVTN  5
   	       Hung_Tuong_LVTN.NVlistKH   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   
   j fDevExpress.Xpf.LayoutControl.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5	   	   +localclr-namespace:Hung_Tuong_LVTN   5
   	     � Title$  NVlistKH��5   	   $	��700��6   $
��1000��6'    � WindowStartupLocation$ CenterScreen=�64   .��5      � .+�5   
   .  (DevExpress.Xpf.LayoutControl.LayoutGroup     Orientation$ Vertical=�6   ��62   Z� .+�5           View$ GroupBox=�6      Header$ Thông Tin Cá Nhân :��6/    � UseLayoutRounding . ��6e   Z� .+�5        .+�5      &   DevExpress.Xpf.Editors.ImageEdit  -   5        $	��img��5   $   %  DevExpress.Xpf.Editors.BaseEdit   
IsReadOnly . 6/   5        5      $ Vertical=�6$   $ GroupBox=�6;   .+�5      -  'DevExpress.Xpf.LayoutControl.LayoutItem     
IsRequired .    Label$) #- Tên Nhân Viên                :��69   	   LabelPosition$
	 Left=�6b   $��0,0,0,2q�6w   $
��Bold"�6�   $��14(�6�   
   Content.
 5      �� -   5        $��lbname��5       $��Normal"�6.   6E   5        5       . $* $- Ngày Sinh                       :��68   $
	 Left=�6d   $��0,0,0,2q�6y   $
��Bold"�6�   $��14(�6�   .
 5      �� -   5        $��
lbngaysinh��5       $��Normal"�62   6H   5        5        . $. (- Giới Tính                         :��68   $
	 Left=�6f   $��0,0,0,2q�6{   $
��Bold"�6�   $��14(�6�   .
 5!      �� -   5        $��
lbGioiTinh��5!       $��Normal"�62   6H   5#        5$       . $. (- Số Điện Thoại                 :��68   $
	 Left=�6b   $��0,0,0,2q�6w   $
��Bold"�6�   $��14(�6�   .
 5%      �� -   5        $��lbsdt��5%       $��Normal"�6-   6C   5&        5'       . $- '- E-mail                              :��68   $
	 Left=�6h   $��0,0,0,2q�6}   $
��Bold"�6�   $��14(�6�   .
 5(      �� -   5        $��lbemail��5(       $��Normal"�6/   6E   5)        5*       . $# - Doanh Thu Cá Nhân       :��68   $
	 Left=�6\   $��0,0,0,2q�6q   $
��Bold"�6�   $��14(�6�   .
 5+      �� -   5        $��
lbdoanhthu��5+       $��Normal"�62   6H   5,      5-      5.        50      $) #Danh Sách Khách Hàng Cá Nhân :��6   $��0,2,0,0q�6G   $ Vertical=�6X   $ GroupBox=�6o    . .+�52      %  DevExpress.Xpf.Grid.GridControl  -   5          Name$ gridControlkh��52   "   )  #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�69      ItemsSource 6O   �� *khnc+   Columns. 53      $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ hoten��6%   $	  DevExpress.Xpf.Grid.BaseColumn 	  Header)
  #DevExpress.Xpf.Core.ObjectConverter$ 	Họ Tên
 67     54      $ gioitinh��6%   $ Giới Tính
 6:     55      $ loaikh��6%   $ Loại Khách Hàng
 68     56      $	 sdt��6%   $ Số Điện Thoại
 65     57      $ diachi��6%   $ Địa Chỉ
 68     58      $ email��6%   $ E-mail
 67      View 59      #  DevExpress.Xpf.Grid.TableView  5:         	AutoWidth . &   DevExpress.Xpf.Grid.DataViewBase   AllowEditing .  &   DevExpress.Xpf.Grid.GridViewBase   AllowGrouping .     AllowColumnMoving .     NavigationStyle$	 Row=�6~      AllowFixedGroups]	 YDevExpress.Data.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 	 /DevExpress.Utils.Design.DefaultBooleanConverter$ False 6�      ShowGroupPanel .  6�   5=      5>      5?      5@      5A      