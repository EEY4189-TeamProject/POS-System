   M S B A M L   `   `   `  ����R  NSales_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Sales_Management_System.ViewSales_Management_System.View  5      -    'Sales_Management_System.View.UCSupplier   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TFontAwesome5.WPF, Version=1.0.5.65, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5      6local*clr-namespace:Sales_Management_System.View  5      .��5      � ���#23664d.+�5   
   ��   �� CornerRadius$  10��6   
�������$	��230��66   $	��Top=�6C   $��10q�6[   ._�5      �� $  10��6   
�������$	��210��6?   $	��Top=�6L   $��10q�6d   ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      ��   FontAwesome5.WPF.Awesome   Content$ Solid_Users=�6   ���#23664d$	��150(�6S   $��Center=�6b   �� 5      $��Supplier Details��6    $��50(�68   $��times new roman)�6F   $��Center=�6c   $��20,100,330,20q�6~   ���#23664d6�   �� 5      $ Vertical=�6!   .+�5      �� $ 
Horizontal=�6%   $	��Top=�6>   $��Right=�6V   $��00,20,30,00q�6r   .+�5!      �� $��40��6(   $	��100��64   $��30(�6@   $��times new roman)�6N   $��Search��6k   $��00,20,00,00q�6y   ���#23664d6�   �� 5$      ���#23664d$��40��6<   $	��250��6H   $��20(�6T   $��times new roman)�6b   $��00,20,00,00q�6    �� Text 6�   �� *Field+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.@�5%   "   �� $��Supplier ID��6/   �� 5&   "   $��Supplier Name��6/   �� 5'   "   $��Address��6/   5(      �� 5+      ���#23664d$��40��6;   $	��300��6G   $��20(�6S   $��times new roman)�6a   $��50,20,00,00q�6~   
���������6�   �� *Find+$ TwoWay=�$ PropertyChanged=��� 5.      $��40��6C   $��50��6O   $��20(�6Z   $��times new roman)�6h   $��00,20,00,00q�6�   
���������6%   �� *	cmdSearch+.��5/   "   �� $ Solid_Search=�6(   ���#23664d6K   50      51      �� 54      
����������#23664d$ 
Solid_Undo=�6o   
����  �$��00,10,30,00q�6�   $��40��6�   $��50��6�   $��20(�6�   $	��Top=�6�   $��Right=�6�   ��6!   �� *cmdSupplierReset+6�   �� 57      $ Solid_PlusSquare=�6!   
����  �$��40��6Z   $��50��6f   $��30(�6q   $��Right=�6   $��
00,10,30,0q�6�   
���������6�   �� *cmdAddSupplier+58      59      5;      5<      � 5?   
   
�������$��10,250,10,10q�6"   $	��800��68   .+�5B      �� $  10 10 00 00��6   ���#23664d$��10,10,10,10q�6E   ._�5C      �� $ 
Horizontal=�6   .+�5D      �� $��Supplier ID��6    $	��200��63      product#���   6?   �� 5E      $��Supplier Name��6    $	��380��65   #���   6A   �� 5F      $��Phone Number��6    $	��280��64   #���   6@   �� 5G      $��Address��6    $	��300��6/   #���   6;   �� 5H      $
��Edit��6    $	��160��6,   #���   68   �� 5I      $��Delete��6    #���   6.   5J      5K      �� 5N      -   5         ��Name$ Stock��5O        ListViewTemplate1#���  5N        List#���  6F   $��10,50,10,-20q�5O   &   $	��710��6]   
����������#2c698d$��3q�6�   ��6<   �� *
Supplier+��5Q      �� 5R      .R�5S      � $��50��6   $��6q�6+   .+�5T      �� $��1��6)   $ 
Horizontal=�66   $��10q�6O   .+�5W   "   �� $��NoWrap=�6H   $	��250��6^   ��6,   �� *
SupplierId+6^   �� 5X   "   $��NoWrap=�6J   $	��390��6`   ��6,   �� *SupplierName+6`   �� 5Y   "   $	��320��6I   ��6,   �� *PhoneNumber+6I   �� 5Z   "   $	��300��6M   ��6,   �� *SupplierAddress+6M   �� 5]   "   $ 
Solid_Edit=�6)   
����  �$��40,00,00,00q�6\   
������ $��25(�6�   
������ ��6�   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" ��	 �� Path$	 DataContext.cmdUpdate���6.  �� �� 5`   "   $ Solid_Trash=�6)   
���  ��$��180,00,00,00q�6\   $��25(�6r   
������ 
������ ��6�   ��  �� *FindAncestor+" ��$#	 DataContext.cmdSupplierDelete���67  �� 5a      5b      5c      5e      5f      5h      5j      