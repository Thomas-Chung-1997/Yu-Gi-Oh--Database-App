   M S B A M L   `   `   `  ���� I  EYuGiOhDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:YuGiOhDatabaseYuGiOhDatabase      YuGiOhDatabase.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:YuGiOhDatabase     -     � Title$  Yu-Gi-Oh Database��$	��450��$	��800��$��14(����#34495e$	��450��$	��800��.��� $��10q� � RowDefinitions �� $
��auto ��� $��* � � ColumnDefinitions �� $
��auto ��� $��* �.+��� $��/Yu-Gi-Oh!_Logo.png��$��0��$��0��$	��200��� $��0��$��1�� �� $��* ��� $
��auto ��� $��* � �� $��* ��� $
��auto ��� $
��auto ��� $��* �.+��� -    ��Name$ 
tbx_Search��$��1��$��1��$	��400��$��0,0,20,0q����#ecf0f1�� -    ��Name$ 
btn_Search��$��1��$��2��$��Search��$	��100�����#e67e22$��DemiBold"�
������ ���#e67e22$��1q��� $��1��$��0��$��20q����#ecf0f1.+��� -   $ btn_Database��$��1��$��2��$��Database��$	��100�����#e67e22$��DemiBold"�
������ ���#e67e22$��1q�$��0,10,0,0q��� -   $ btn_Collection��$��1��$��2��$��
Collection��$	��100�����#e67e22$��DemiBold"�
������ ���#e67e22$��1q�$��0,10,0,0q��� -   $ btn_Save��$��1��$��2��$
��Save��$	��100�����#e67e22$��DemiBold"�
������ ���#e67e22$��1q�$��0,10,0,0q�&   System.Windows.Controls.DataGrid  -     Name$ 	dtg_Cards��$��1��$��1��$��20q����#ecf0f1   CanUserAddRows$ False��   AlternatingRowBackground �#e74c3c   AutoGenerateColumns$ False��	   SelectionMode$	 Single=�
   Columns
 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Action��   MinWidth$ 50Q�   CellTemplate �� .R��� .+��� -   $��+1���� -	   $��-1��0  *System.Windows.Controls.DataGridTextColumn  $ Count��   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50    
Visibility$ Hidden=�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *count+  $
 Name��$	 100Q�$
 auto  �� *name+   	CellStyle ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property �@�ToolTip �� Value ��  �� RelativeSource �� *Self+ �� Path$ Content.Text�  $
 Type��$	 100Q�$
 auto  �� *type+  $
 Race��$	 100Q�$
 auto  �� *race+  $ Description��$	 100Q�$ *  �� *desc+ �� "  .���  �@�ToolTip ��  �� *Self+$ Content.Text�  $ ID��$ Hidden=� �� *id+