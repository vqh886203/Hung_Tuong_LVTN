   M S B A M L   `   `   `  ����J  FHung_Tuong_LVTN, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Hung_Tuong_LVTNHung_Tuong_LVTN  5          Hung_Tuong_LVTN.UCNVList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Hung_Tuong_LVTN     5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5      ] YDevExpress.Mvvm.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   5	      ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5
      j	 fDevExpress.Xpf.LayoutControl.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol 	 5      ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      .��5      0 	 *DevExpress.Xpf.LayoutControl.LayoutControl  . 	 (DevExpress.Xpf.LayoutControl.LayoutGroup    Orientation$  Vertical=�6   $	��Top=�60   .+�5   
   �� $��Danh Sách Nhân Viên��6   $
��Bold"�6/   $��14(�6A   $	��Top=�6O   (  "DevExpress.Xpf.Bars.ToolBarControl  5   
   ,  &DevExpress.Xpf.Bars.ToolBarControlBase   Caption$ listnvtb��6   $
��Left=�60      IsCollapsed .     RotateWhenVertical .     AllowQuickCustomization .    	AllowHide .     AllowCustomizationMenu .     BarItemDisplayMode$ ContentAndGlyph=�6�   $
��Bold"�6�   $��10(�6�    J� OpacityMask
 �   �$��2q�6  $��Right=�63  	   Items.	 5      '  !DevExpress.Xpf.Bars.BarButtonItem  -   5        
  Name$

 bicn��5       !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$    Cập Nhật    6.      GlyphAlignment$
 Left=�6�      Glyph 6G   *  $DevExpress.Xpf.Core.DXImageExtension     Image1	  +DevExpress.Xpf.Core.Native.DXImageConverter$ Cut_16x16.png	    
LargeGlyph 6p     $ Refresh_32x32.png	 6�     5      -   5        $
 biThem��5       $
 Left=�61   $ Thêm Nhân Viên 6G   $[ Upack://application:,,,/Hung_Tuong_LVTN;component/img/Ampeross-Qetto-2-Add-contact.ico��6}     5      -   5        $
 bixoa��5          CommandParameter$
 Xóa��6�   $      Xóa      6�   $
 Left=�6�    6/     $ Copy_16x16.png	  6Y     $ Trash_32x32.png	 6�   5      � 5   
   .+�5      %
  DevExpress.Xpf.Grid.GridControl
  -   5         
 Name$
 grid��5      )  #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$
 None=�5         ItemsSource 60   �� *
DSNVList+ 
  View 5      #  DevExpress.Xpf.Grid.TableView  5      -   5          Name$ 	tableView��5   %      AllowPerPixelScrolling .    EditFormColumnCount$ 3��5           EditFormShowMode$ Inline=�68   &   DevExpress.Xpf.Grid.DataViewBase   NavigationStyle$	 Row=�5!   !       AllowMoveColumnToDropArea .     	AutoWidth .     ShowEditFormOnDoubleClick .     ShowEditFormOnEnterKey . 5#   C    
  Columns. 5'      $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$
 nvid��6"       EditFormStartNewRow  . $  DevExpress.Xpf.Grid.BaseColumn!   Header$! ID 6N   '"    HorizontalHeaderContentAlignment$" Center=�6\   #   AllowEditing]
 YDevExpress.Data.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a5 
 /DevExpress.Utils.Design.DefaultBooleanConverter$# False 6�   $   ReadOnly$ . %   EditFormVisible$% FalseX�6�     5(      $ tennv��6"   &   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$
& auto 64     . $! 	Họ Tên 6\   $" Center=�6m     5)      $ diachi��6"   $! Địa Chỉ 65   '   EditFormVisibleIndex$' 2��6F   $" Center=�6_     5*      $ ngaysinh��6"   $! 
Ngày Sinh 67   $' 2��6J   $" Center=�6c     5+      $	 sdt��6"   $! Số Điện Thoại 62   $" Center=�6J     5,      $ gioitinh��6"   $! Giới Tính 67   $" Center=�6K   (   EditSettings( 5-      :  4DevExpress.Xpf.Editors.Settings.ComboBoxEditSettings  5.      -   5        ) �Name$	) cbo��5.   3   50        51      $ email��6"   $! Email 64   $" Center=�6D     52      $ taikhoan��6"   $! Tài Khoản 67   $" Center=�6K   $ . $# False 6�   $% FalseX�6�     53      $ doanhthu��6"   $! 	Doanh Thu 67   $" Center=�6K   $ . $# False 6�   $% FalseX�6�     54      $ quyen��6"   $! Quyền 64   $" Center=�6E   $' 2��6o   ( 56      7  1DevExpress.Xpf.Editors.Settings.CheckEditSettings  57      59        5:      *   AllowResizing$* False 6!   +   AllowMoving$+ False 68   $
% TrueX�5;   !   $
 hinh��68   $! Hình Đại Diện 6I   ,   ShowInColumnChooser, . -   Visible- . ( 5=      <  6DevExpress.Xpf.Editors.Settings.PopupImageEditSettings  5>      6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings.   MaxWidth$	. 100Q�65   /   Stretch$
/ Fill=�6D    0   ShowLoadDialogOnClickMode$0 Always=�5?   5   1   ShowMenu1 . 2   ShowMenuMode$2 Always=�5@   5   5B      5C      5E      5F      5G      