   M S B A M L   `   `   `  ����R  NSales_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Sales_Management_System.ViewSales_Management_System.View  5      ,    &Sales_Management_System.View.UCProduct   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome5.WPF, Version=1.0.5.65, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      6local*clr-namespace:Sales_Management_System.View  5      .��5      � ���#23664d.+�5   
   ��   �� CornerRadius$  10��6   
�������$	��230��66   $	��Top=�6C   $��10q�6[   ._�5      �� $  10��6   
�������$	��210��6?   $	��Top=�6L   $��10q�6d   ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      ��   FontAwesome5.WPF.Awesome   Content$ Solid_ShoppingBasket=�6   $	��150(�6G   ���#23664d$��Center=�6k   �� 5      $��Product Details��6    $��50(�67   $��times new roman)�6E   $��20,100,400,20q�6b   ���#23664d$��Center=�6�   �� 5      $ Vertical=�6!   .+�5      �� $ 
Horizontal=�6%   $	��Top=�6>   $��Right=�6V   $��00,20,30,00q�6r   .+�5      �� ���#23664d$��40��6=   $	��100��6I   $��30(�6U   $��times new roman)�6c   $��Search��6�   �� 5      ���#23664d$��40��6<   $	��250��6H   $��20(�6T   $��times new roman)�6b    �� Text 6   �� *Field+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.@�5   "   �� $��
Product ID��6/   �� 5   "   $��Product Name��6/   �� 5   "   $��Product Price��6/   5      �� 5      ���#23664d$��40��6<   $	��300��6H   $��20(�6T   $��times new roman)�6b   
���������6�   �� *Find+$ TwoWay=�$ PropertyChanged=��� 5      $��40��6D   $��50��6P   $��20(�6[   $��times new roman)�6i   
���������6&   �� *	cmdSearch+.��5    "   �� $ Solid_Search=�6(   ���#23664d6K   5!      5#      �� 5$      
����������#23664d$ 
Solid_Undo=�6p   
����  �$��00,10,30,00q�6�   $��40��6�   $��50��6�   $��20(�6�   $	��Top=�6�   $��Right=�6�   ��6"   �� *cmdProductreset+6�   �� 5&      ���#23664d
�������$ Solid_PlusSquare=�6l   
����  �$��40��6�   $��50��6�   $��30(�6�   $	��Top=�6�   $��Right=�6�   $��00,10,30,00q�6�   ��6J   �� *cmdAddProduct+6�   5-      5/      51      52      � 53   
   .+�54      � 
�������$��10,250,10,10q�6&   $	��800��6<   .+�55      �� $  10 10 00 00��6   ���#23664d$��10,10,10,10q�6I   ._�57      �� $ 
Horizontal=�6!   .+�58      �� $��
Product ID��6$      product#���   66   $	��160��6X   �� 59      $��Product Name��6$   #���   68   $	��250��6Z   �� 5:      $��Supplier��6$   $	��250��64   #���   6@   �� 5;      $��Price��6$   $	��200��61   #���   6=   �� 5<      $��Quantity��6$   $	��200��64   #���   6@   �� 5=      $
��Edit��6$   $	��200��60   #���   6<   �� 5>      $��Delete��6$   $	��200��62   #���   6>   5?      5@      �� 5A      -   5         ��Name$ Product��5B        ListViewTemplate1#���  5A        List#���  6K   $��10,70,10,10q�5B   *   $	��720��6_   
����������#2c698d$��3q�6�   ��6?   �� *	Product+��5C      �� 5D      .R�5E      � $��50��6#   $��6q�6/   .+�5F   "   �� $��1��6-   $ 
Horizontal=�6:   $��10q�6T   .+�5G   &   �� $��NoWrap=�6K   $	��200��6b   ��60   �� *	ProductId+6b   �� 5H   &   $��NoWrap=�6M   $	��280��6c   ��60   �� *ProductName+6c   �� 5I   &   $��NoWrap=�6N   $	��280��6d   ��60   �� *SupplierName+6d   �� 5J   &   $	��230��6N   ��60   �� *ProductPrice+6N   �� 5K   &   $	��150��6Q   ��60   �� *ProductQuantity+6Q   �� 5L   &   $ 
Solid_Edit=�6-   
����  �
������ $��25(�6z   
������ $��80,00,00,00q�6�   ��6�   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" ��	 �� Path$	 DataContext.cmdUpdate���64  �� �� 5M   &   $ Solid_Trash=�6-   
���  ��$��25(�6`   $��200,00,00,00q�6n   
������ 
������ ��6�   ��  �� *FindAncestor+" ��$"	 DataContext.cmdProductDelete���6;  �� 5N   #   5O      5P      5R      5S      5T      5U      5V      