   M S B A M L   `   `   `  ����R  NSales_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Sales_Management_System.ViewSales_Management_System.View  5      *    $Sales_Management_System.View.UCStock   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:Sales_Management_System.View     5      X TFontAwesome5.WPF, Version=1.0.5.65, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      .��5      � ���#23664d.+�5   
   ��   �� CornerRadius$  10��6   
�������$	��230��66   $	��Top=�6C   $��10q�6[   ._�5      �� $  10��6   
�������$	��210��6?   $	��Top=�6L   $��10q�6d   ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      ��   FontAwesome5.WPF.Awesome   Content$ Solid_ShoppingCart=�6   $��Center=�6E   $	��120(�6`   ���#23664d6o   �� 5      $��Stock Details��6    $��35(�65   $��times new roman)�6C   $��00,120,60,20q�6`   $��Center=�6v   ���#23664d6�   �� 5      $ Vertical=�6!   .+�5      �� $ 
Horizontal=�6%   $	��Top=�6>   $��Right=�6V   $��00,50,30,00q�6r   .+�5      �� $��40��6(   $	��100��64   $��30(�6@   $��times new roman)�6N   $��Search��6k   $��00,20,00,00q�6y   ���#23664d6�   �� 5      ���#23664d$��40��6<   $	��150��6H   $��20(�6T   $��times new roman)�6b   $��00,20,00,00q�6    �� Text 6�   �� *Field+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.@�5   "   �� $��
Product ID��6/   �� 5   "   $��Product Name��6/   �� 5   "   $��Product Price��6/   5      �� 5      ���#23664d$��40��6;   $	��300��6G   $��20(�6S   $��times new roman)�6a   $��10,20,00,00q�6~   
���������6�   �� *Find+$ TwoWay=�$ PropertyChanged=��� 5      ���#23664d$��40��6:   $��50��6F   $��20(�6Q   $��times new roman)�6_   $��00,20,00,00q�6|   
���������6�   �� *	cmdSearch+.��5   "   �� $ Solid_Search=�6(   5      5       �� 5!      
����������#23664d$ 
Solid_Undo=�6n   
����  �$��00,10,30,00q�6�   $��40��6�   $��50��6�   $��20(�6�   $	��Top=�6�   $��Right=�6�   ��6"   �� *cmdStockReset+6�   5"      5$      5%      5&      � 5)   
   
�������$��10,250,10,10q�6"   $	��550��68   .+�5*      �� $  10��6   ���#23664d$��10,10,10,10q�6<   ._�5+      �� $ 
Horizontal=�6   .+�5,      �� $��
Product ID��6    $��30,20,00,00q�62   $	��160��6G      product#���   6S   �� 5-      $��Product Name��6    $��30,20,00,00q�64   $	��200��6I   #���   6U   �� 5.      $��Product Price��6    $��30,20,00,00q�65   $	��200��6J   #���   6V   �� 5/      $��Product Quantity��6    $��30,20,00,00q�68   $	��250��6M   #���   6Y   �� 50      $
��Edit��6    $��30,20,00,00q�6,   $	��100��6A   #���   6M   51      52      �� 54      -   5         ��Name$ Stock��55        ListViewTemplate1#���  54        List#���  6F   $��10,50,10,10q�55   "   $	��450��6U   
����������#23664d$��3q�6�   $
��Auto=�6�   ��67   �� *Stock+��56      �� 57      .R�58      � $
��auto��6   $��6q�6-   .+�59      �� $��1��6)   $ 
Horizontal=�66   $��5q�6P   .+�5:   "   �� $��NoWrap=�6G   $	��200��6^   ��6,   �� *	ProductId+6^   �� 5;   "   $��NoWrap=�6I   $	��225��6_   ��6,   �� *ProductName+6_   �� 5<   "   $	��230��6[   ��6,   �� *ProductPrice+ �� StringFormat$ C��6[   �� 5=   "   $	��250��6M   ��6,   �� *ProductQuantity+6M   �� 5>   "   $ 
Solid_Edit=�6)   
����  �$��40,00,00,00q�6]   
������ $��25(�6�   
������ ��6�   ��  �� RelativeSource �� *FindAncestor+	 �� AncestorType"	 ��
 �� Path$
 DataContext.cmdSUpdate���63  �� 5?      5@      5A      5C      5D      5G      5H      