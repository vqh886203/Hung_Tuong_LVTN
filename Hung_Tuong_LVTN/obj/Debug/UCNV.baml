   M S B A M L   `   `   `  ����J  FHung_Tuong_LVTN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Hung_Tuong_LVTNHung_Tuong_LVTN  5      =#clr-namespace:Hung_Tuong_LVTN.ModelHung_Tuong_LVTN.Model  5          Hung_Tuong_LVTN.UCNV   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      j fDevExpress.Xpf.LayoutControl.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  5      f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5	      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5
      )localclr-namespace:Hung_Tuong_LVTN  5      /Model#clr-namespace:Hung_Tuong_LVTN.Model  5      .��5      �   � DataContext  5   
   -  'Hung_Tuong_LVTN.Model.NhanVienModelView  5      .+�5   
   ]� .+�5      *  $DevExpress.Xpf.Bars.StatusBarControl  ,  &DevExpress.Xpf.Bars.ToolBarControlBase   Caption$ 	StatusBar��6#   $��Bottom=�67      ShowSizeGrip . 6O   0  *DevExpress.Xpf.LayoutControl.LayoutControl  5      .  (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�6!   $	��Top=�68   ��6P   Z� !   MovingItemPlaceHolderBrush 6f   Z� .+�5      �� $��Danh Sách Nhân Viên��6   $
��Bold"�67   $��14(�6I   $	��Top=�6W   � 5      .+�5        $	��Top=�6)   ��6A   Z�  6W   Z� .+�5        $	��800��6+   ��67   Z� .+�5      %  DevExpress.Xpf.Grid.GridControl  -   5          Name$ gridControl��5   .   )  #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�5   .      ItemsSource 5   C   �� *DSNV+   View 5    "   #  DevExpress.Xpf.Grid.TableView  5!   &   -   5        	   AllowPerPixelScrolling	 . &	   DevExpress.Xpf.Grid.DataViewBase
 	  ShowTotalSummary
 .    	AutoWidth .  	  AllowEditing .   	  NavigationStyle$	 Row=�5%   I      Columns. 5'   "   $
  DevExpress.Xpf.Grid.GridColumn
  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$
 idnv��61   $  DevExpress.Xpf.Grid.BaseColumn   Header)  #DevExpress.Xpf.Core.ObjectConverter$ ID 6B      Visible .  6N   
  5(   "   $ tennv��61   $ Tên Nhân Viên 6D   
  5)   "   $
 tuoi��61      IsSmart . $ Tuổi 6Q   
  5*   "   $ gioitinh��61    . $ Giới Tính 6U   
  5+   "   $ email��61    . $ E-mail 6R   
  5,   "   $	 sdt��61    . $ Số Điện Thoại 6P   5-      5.        5/      $ Vertical=�6+   $	��Top=�6B   ��6Z   Z� .+�50      &   DevExpress.Xpf.Editors.ImageEdit  -   5          Name$ image��50   F   $	��250��6,   $	��250��69      ShowMenu .      ShowLoadDialogOnClickMode$ Never=�6f      Stretch$
 Fill=�6�     51      $ Vertical=�61   ��6H   Z�  6^   Z� .+�52   "     ��63   Z� .+�53   &     $ Vertical=�67   $	��Top=�6N   $	��300��6f   $��17,0,0,0q�6s   .+�54   *   -  'DevExpress.Xpf.LayoutControl.LayoutItem  -   5          Name$ loten��54   :      Label$ Tên Nhân Viên:  ��6I   $��Center=�6b      LabelHorizontalAlignment$ Center=�6   $
��Bold"�6�   
���   ���6�   Z�    Content. 55   .   �� -   5         ��Name$ lbtennv��55   4   $��Vương Quang Hưng��6E   $��Normal"�6a   
���   �6u   56   +     57   *   -   5        $
 lons��57   :   $ Ngày Sinh:  ��6H   $��Center=�6]   $
��Bold"�6z   
���   ���6�   Z� . 58   .   �� -   5        $
 lbns��58   4   $��
19/09/1994��6B   $��Normal"�6W   59   +     5;   *   $ Địa chỉ:  ��6:   $��Center=�6M   $ Center=�6j   $
��Bold"�6�   
���   �. 5<   .   �� -   5        $ 	lbtdiachi��5<   4   $��An Giang��6G   $��Normal"�6Z   5=   +     5>   *   $ Doanh Thu:  ��6:   $��Center=�6O   $
��Bold"�6l   
���   �. 5?   .   �� -	   5        $
 lbdt��5?   4   $��
1000000000��6B   $��Normal"�6W   5@   +   5A   '     5B   &   $��Right=�66   $  ��6�      LabelPosition$	 Top=�6�   ��6R   �� *ActualHeight+ �� ElementName$ layoutGroup��6�   5C   #     5D   "   $ Vertical=�64    � UseLayoutRounding .    View$ GroupBox=�6d       	TabHeader#  � ��6t   ! J� OpacityMask
! �   ���6�   Z� "   Header" 5E   &   �� 5F   *   $��
Liên Hệ��60   .+�5H   &     $ 
Mobile:   ��66   
���   �. 5I   *   �� -
   5        $ lbsdt��5I   0   $��01644374917��6?   5J   '     5K   &   $ E-Mail:��66   
���   �. 5L   *   �� -   5        $ lbmail��5L   0   $"��vuongquang_hung@yahoo.com.vn��6@   5M   '   5N   #   5O      5P      5Q      5R      5S      5T      5V      5W      