   M S B A M L   `   `   `  ���� @  <WPFUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFUIWPFUI      WPFUI.TradeScreen   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:WPFUI       � WindowStartupLocation$  CenterOwner=� � Title$ Trade Screen��$	��420��$	��400��.��� 
���/kU� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $��* ��� $��* �.+��� $��0��$��0��$��2��$��Center=����� *CurrentTrader.TraderName+�� $��1��$��1��$��Center=�$��Your Inventory���� $��1��$��0��$��Center=�$��Trader's Inventory��&   System.Windows.Controls.DataGrid     
IsReadOnly . $��2��$��1��$��12q�   AutoGenerateColumns .     HeadersVisibility$ Column=�   CanUserAddRows .     CanUserDeleteRows .  "	   VerticalScrollBarVisibility$
	 Auto=����� * StandardPlayer.PlayerInventory+
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Description��   
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ ItemName�  $ Price�� . $
 Auto  �� $ 	ItemValue�4  .System.Windows.Controls.DataGridTemplateColumn     MinWidth$ 60Q�   CellTemplate �� .R��� -   $
��Sell��$��40��  $��2��$��0��$��12q� .  $ Column=� .   .  $
	 Auto=����� *CurrentTrader.TraderInventory+
   $ Description�� . $ *  �� $ ItemName�  $ Price�� . $
 Auto  �� $ 	ItemValue�  $ 60Q� �� .R��� -   $	��Buy��$��40���� -   $��3��$��1��$��Right=�$��70��$��5q�$��Close��
���""��