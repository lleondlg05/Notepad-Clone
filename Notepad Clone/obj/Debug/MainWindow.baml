   M S B A M L   `   `   `  ����H  DNotepad Clone, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Notepad_CloneNotepad_Clone  5   	       Notepad_Clone.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Notepad_Clone     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5      �  � RowDefinitions 5   
   �� 5      $��32 �6   �� 5      �� 5      $��32 �6   .+�5   
   ��    HeaderFooter#��[  6   o� 5   
   
������ $��Center=�6(   $��Center=�6C   .@�5      m� $
��File��6   $��Center=�6%   .@�5      m� -   5         m�Name$ NewTab_MenuItem��5   ,   $��New tab��6    m� InputGestureText$ Ctrl+N��6E   6_   m� 5      -   5        $ NewWindow_MenuItem��5   /   $��
New window��6   $ Ctrl+Shift+N��6K   6k   m� 5      -   5        $ Open_MenuItem��5   )   $
��Open��6   $ Ctrl+O��6@   6Z   m� 5      -   5        $ Save_MenuItem��5   )   $
��Save��6   $ Ctrl+S��6@   6Z   m� 5      -   5        $ SaveAs_MenuItem��5   ,   $��Save as��6   $ Ctrl+Shift+S��6E   6e   m� 5       $��Save all��6   $ 
Ctrl+Alt+S��6-   �� 5!      m� 5"      -   5        $ PageSetupMenuItem��5"   /   $��
Page setup��6   6J   m� 5#      $��Print��6   $ Ctrl+P��6*   �� 5$      m� 5%      $��	Close tab��6   $ Ctrl+W��6.   m� 5&      $��Close window��6   $ Ctrl+Shift+W��61   m� 5'      -   5        $ Exit_MenuItem��5'   )   $
��Exit��6   6@   5(      m� 5*      $
��Edit��6   $��Center=�6%   .@�5+      m� -	   5        $ Undo_MenuItem��5+   )   $
��Undo��6   $ Ctrl+Z��6@   6Z   �� 5,      m� 5-      -
   5        $ Cut_MenuItem��5-   (   $	��Cut��6   $ Ctrl+X��6?   6Y   m� 5.      -   5        $ Copy_MenuItem��5.   )   $
��Copy��6   $ Ctrl+C��6@   6Z   m� 5/      -   5        $ Paste_MenuItem��5/   *   $��Paste��6   $ Ctrl+V��6B   6\   m� 50      -   5        $ Delete_MenuItem��50   +   $��Delete��6   $	 Del��6D   6[   �� 51      m� 52      $
��Find��6   $ Ctrl+F��6)   m� 53      $��	Find next��6   $ F3��6.   m� 54      $��Find previous��6   $ Shift+F3��62   m� 55      -   5        $ Replace_MenuItem��55   ,   $��Replace��6   $ Ctrl+H��6F   6`   m� 56      $��Go to��6   $ Ctrl+G��6*   �� 57      m� 58      -   5        $ SelectAll_MenuItem��58   /   $��
Select all��6   $ Ctrl+A��6K   6e   m� 59      -   5        $ TimeDate_MenuItem��59   .   $��	Time/Date��6   $ F5��6I   6_   �� 5:      m� 5;      $
��Font��6   5<      m� 5>      $
��View��6   $��Center=�6%   .@�5?      m� $
��Zoom��6   .@�5@      m� -   5        $ ZoomIn_MenuItem��5@   0   $��Zoom in��6   $ 	Ctrl+Plus��6I   6f   m� 5A      -   5        $ ZoomOut_MenuItem��5A   1   $��Zoom out��6   $ 
Ctrl+Minus��6K   6i   m� 5B      -   5        $! RestoreDefaultZoom_MenuItem��5B   =   $��Restore default zoom��6   $ Ctrl+0��6b   6|   5C      m� 5D      -   5        $ StatusBar_MenuItem��5D   /   $��
Status bar��6    m� IsCheckable .  m� 	IsChecked . 6o   m� 5E      -   5        $ WordWrap_MenuItem��5E   .   $��	Word wrap��6    .  . 6m   5F      5G      �� 5J   
     Body#��[ 6   $��1��61   �� 5K   
   -   5         ��Name$ TextArea��5K      $��1��6   
������   BodyText#��[ 6J   $��0q�5L      $��20q�6&   $��16(�63   $��Lucida Console)�6A    �� 
CaretBrush# [ 5M       �� AcceptsReturn . 	 �� TextWrapping$
	 Wrap=�6N   "
 �� VerticalScrollBarVisibility$

 Auto=�5N   5   �� 5Q   
   $��2��6   #��[  6!   � 5S   
   -   5         �Name$ 	statusBar��5S      $��2��6"    � ColumnDefinitions 5T      �� 5U      $��* �6#   �� 5V      $	��120 �6#   �� 5W      $	��120 �6#   �� 5X      $	��120 �6#   .+�5\      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $
��10,0q�6B   .+�5]      �� -   5         ��Name$ LineText��5]      $	��Ln:��6.   �� 5^      -   5        $ LineCountText��5^      $��0��63   �� 5_      -   5        $
 Coma��5_      $��,��6*   $��
-10,0,10,0q�63   �� 5`      -   5        $ 
ColumnText��5`      $
��Col:��60   �� 5a      -   5        $ ColumnCountText��5a      $��0��65   5b      �� 5d      $��1��6   $
��Left=�6(   $��1��6C   $��25��6M     Menu.Static.Border#��[ 6Y   $��-10,0q�6�   �� 5e      $��1��6   $��	Zoom 100%��6(   �� 5g      $��2��6   $
��Left=�6(   $��1��6C   $��25��6M   #��[ 6Y   $��-10,0q�6�   �� 5h      $��2��6   $��Windows (CRLF)��6(   �� 5j      $��3��6   $
��Left=�6(   $��1��6C   $��25��6M   #��[ 6Y   $��-10,0q�6�   �� 5k      $��3��6   $��UTF-8��6(   5l      5m      5n      