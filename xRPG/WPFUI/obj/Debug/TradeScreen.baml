   M S B A M L   `   `   `  ����@  <WPFUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFUIWPFUI  5   	       WPFUI.TradeScreen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:WPFUI     5   	     � WindowStartupLocation$  CenterOwner=�5   	    � Title$ Trade Screen��5	   	   $	��420��6   $	��400��6+   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��2��6-   $��Center=�6A   ��6^   �� *CurrentTrader.TraderName+�� 5   
   $��1��6   $��1��6   $��Center=�6-   $��Your Inventory��6J   �� 5   
   $��1��6   $��0��6   $��Center=�6-   $��Trader's Inventory��6J   &   System.Windows.Controls.DataGrid  5   
   $��2��6   $��1��6    $��12q�60      AutoGenerateColumns .     HeadersVisibility$ Column=�5   /      CanUserAddRows .     CanUserDeleteRows .  "   VerticalScrollBarVisibility$
 Auto=�6{   ��5   <   �� * StandardPlayer.PlayerInventory+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Description��6%      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6V   ��  �� Path$ ItemName�  5      $
 Price��6%    . $
 Auto 6F    6S   �� $ 	ItemValue�4  .System.Windows.Controls.DataGridTemplateColumn  5         MinWidth$ 60Q�6)      CellTemplate 5      �� 5       .R�5!      �� -   5        $
��Sell��5!   %   $��40��64   6?   5"      5$      5&        5'   
   $��2��6   $��0��6    $��12q�60    .  $ Column=�5(   /    .   .  $
 Auto=�6{   ��5'   <   �� * StandardPlayer.PlayerInventory+	 5)        5*      $
 Description��6%    . $ * 6L    6V   �� $ ItemName�  5+      $
 Price��6%    . $
 Auto 6F    6S   �� $ 	ItemValue�  5,      $ 60Q�6)    5-      �� 5.      .R�5/      �� -   5        $	��Buy��5/   %   $��40��63   6>   50      52      54      �� 55   
   -   5        $��3��55      $��1��6   $��Right=�6.   $��70��6J   $��5q�6U   $��Close��6`   6p   56      57      