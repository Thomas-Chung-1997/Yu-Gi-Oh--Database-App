   M S B A M L   `   `   `  ����I  EYuGiOhDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:YuGiOhDatabaseYuGiOhDatabase  5   	       YuGiOhDatabase.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:YuGiOhDatabase     5   	   -   5          � Title$  Yu-Gi-Oh Database��5	   	   $	��450��6#   $	��800��60   $��14(�5
   	   ���#34495e$	��450��6,   $	��800��6<   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��/Yu-Gi-Oh!_Logo.png��6   $��0��6-   $��0��6:   $	��200��6J   � 5   
   $��0��6   $��1��6    5      �� 5      $��* �6    �� 5      $
��auto �6    �� 5      $��* �6     5      �� 5       $��* �6#   �� 5!      $
��auto �6#   �� 5"      $
��auto �6#   �� 5#      $��* �6#   .+�5%      �� -   5         ��Name$ 
tbx_Search��5%      $��1��6G   $��1��6T   $	��400��6d   $��0,0,20,0q�6s   ���#ecf0f16�   �� 5&      -   5         ��Name$ 
btn_Search��5&      $��1��6B   $��2��6O   $��Search��6_   $	��100��6p   ���#e67e22$��DemiBold"�6�   
������ ���#e67e22$��1q�6�   5'      �� 5(   
   $��1��6   $��0��6"   $��20q�62   ���#ecf0f1.+�5)      �� -   5        $ btn_Database��5)      $��1��6F   $��2��6S   $��Database��6c   $	��100��6v   ���#e67e22$��DemiBold"�6�   
������ ���#e67e22$��1q�6�   $��0,10,0,0q�6�   �� 5*      -   5        $ btn_Collection��5*      $��1��6J   $��2��6W   $��
Collection��6g   $	��100��6|   ���#e67e22$��DemiBold"�6�   
������ ���#e67e22$��1q�6�   $��0,10,0,0q�6�   �� 5+      -   5        $ btn_Save��5+      $��1��6>   $��2��6K   $
��Save��6[   $	��100��6j   ���#e67e22$��DemiBold"�6�   
������ ���#e67e22$��1q�6�   $��0,10,0,0q�6�   5,      &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$ 	dtg_Cards��5-      $��1��6&   $��1��63   $��20q�6C   ���#ecf0f1   CanUserAddRows$ False��6d      AlternatingRowBackground �#e74c3c   AutoGenerateColumns$ False��6�   	   SelectionMode$	 Single=�6�   
   Columns
 5.      4  .System.Windows.Controls.DataGridTemplateColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ Action��6)      MinWidth$ 50Q�69      CellTemplate 50      �� 51      .R�52      �� .+�53   "   �� -   5        $��+1��53   )   66   �� 54   "   -	   5        $��-1��54   )   66   55      56      58      0  *System.Windows.Controls.DataGridTextColumn  59      $ Count��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6N      
Visibility$ Hidden=�6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *count+6Y     5:      $
 Name��6%   $	 100Q�6L   $
 auto 6[    63   �� *name+   	CellStyle 5;      �� 5<       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    .�5=      ��  �� Property �@�ToolTip �� Value 68   ��  �� RelativeSource �� *Self+ �� Path$ Content.Text�5>      5@        5A      $
 Type��6%   $	 100Q�6L   $
 auto 6[    63   �� *type+6[     5B      $
 Race��6%   $	 100Q�6L   $
 auto 6[    63   �� *race+6[     5C      $ Description��6%   $	 100Q�6S   $ * 6b    6:   �� *desc+ 5D      �� 5E      "  6    .�5F      ��  �@�ToolTip 68   ��  �� *Self+$ Content.Text�5G      5I        5J      $ ID��6%   $ Hidden=�6H    61   �� *id+6H   5L      5M      5N      