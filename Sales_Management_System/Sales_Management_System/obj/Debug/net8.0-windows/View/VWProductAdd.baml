   M S B A M L   `   `   `  ����R  NSales_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Sales_Management_System.ViewSales_Management_System.View  5   	   U/clr-namespace:Sales_Management_System.ViewModel!Sales_Management_System.ViewModel  6B   /    )Sales_Management_System.View.VWProductAdd   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TFontAwesome5.WPF, Version=1.0.5.65, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5   	   6local*clr-namespace:Sales_Management_System.View  5   	   ?	viewmodel/clr-namespace:Sales_Management_System.ViewModel  6B     � Title$  VWProductAdd��5	   	   $	��400��6   $	��450��6+    � WindowStartupLocation$ CenterScreen=�67    � WindowStyle$
 None=�6\    � 
ResizeMode$ NoResize=�6o   .��5      � ���#23664d.+�5   
   � 
�������$	��390��6'   $	��440��64   .+�5      ��   FontAwesome5.WPF.Awesome   Content$ Solid_WindowClose=�68   $��15(�6`   $	��Top=�6n   $��Right=�6�   $��03 ,-2,00,00q�6�   $��20��6�   $��20��6�   
������ 
���  ��
������ ��6   �� *cmdProductExit+6�   �� 5      $	��360��6   $	��430��6"   ���#23664d �� CornerRadius$ 20��6C   ._�5      �  � ColumnDefinitions 5      �� 5      $	��160 �6+   �� 5       � RowDefinitions 5      �� 5      $��80 �6(   �� 5       $	��200 �6(   �� 5!      .+�5$      �� $��2��6!    �� Orientation$ 
Horizontal=�65   $��Center=�6N   $��Center=�6k   .+�5%      �� $��Product��6$   $��30(�63   $��times new roman)�6A   
�������6^   5&      �� 5'      $��1��6!   $ Vertical=�6.   $��Center=�6E   $��Center=�6b   .+�5(      �� $��Product ID ��6$   
�������$��times new roman)�6J   $��20(�6g   $��20,00,00,00q�6u   �� 5)      $��Product Name ��6$   
�������$��times new roman)�6L   $��20(�6i   $��20,20,00,00q�6w   �� 5*      $��Product Price ��6$   
�������$��times new roman)�6M   $��20(�6j   $��20,20,00,00q�6x   �� 5+      $��	Supplier ��6$   
�������$��times new roman)�6H   $��20(�6e   $��20,20,00,00q�6s   �� 5,      $��Product Quantity ��6$   
�������$��times new roman)�6P   $��20(�6m   $��20,20,00,00q�6{   y�6�   �� *	QtyEnable+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�5.      �� 5/      $��1��6!   $��1��61   $ Vertical=�6>   $��Center=�6U   $��Center=�6r   .+�50      �� $��30��6$   
�������$	��240��6C   $��times new roman)�6O   $��20(�6l   $��
5,00,00,00q�6z   ${�False��6�   ��6�   �� *Product.ProductId+$	 TwoWay=�$
 PropertyChanged=�6�   �� 51      $��30��6"   $	��240��6.   $��times new roman)�6:   $��20(�6W   $��
5,10,00,00q�6e   ��6y   �� *Product.ProductName+$	 TwoWay=�$
 PropertyChanged=��� 52      $��30��6"   $	��240��6.   $��times new roman)�6:   $��20(�6W   $��
5,10,00,00q�6e   ��6y   �� *Product.ProductPrice+$	 TwoWay=�$
 PropertyChanged=��� 53      $��
5,10,00,00q�6N   $��30��6b   $	��240��6n   $��times new roman)�6z   $��20(�6�    �� DisplayMemberPath$ SupplierName��6�   ��6#   �� *SupplierCollection+ �� SelectedValue 6�   �� *SelectedSupplier+6�   �� 54      $��30��6"   $	��240��6.   $��times new roman)�6:   $��20(�6W   $��
5,10,00,00q�6e   ��6y   �� *Product.ProductQuantity+$	 TwoWay=�$
 PropertyChanged=�y�6�   �� *	QtyEnable+$	 TwoWay=�$
 PropertyChanged=�56      �� 57      $ 
Horizontal=�6!   $��2��6:   $��1��6G   .+�58      �� $��30��6!   $	��100��6-   $��times new roman)�69   $��20(�6V   $��18,-20,00,00q�6d   ���#2c698d��6{   �� *cmdProductAdd+��6�   �� *btnAdd+6�   �� 59      $��30��6!   $	��100��6-   $��times new roman)�69   $��20(�6V   $��40,-20,00,00q�6d   ���#2c698d��6z   �� *cmdProductExit+��6�   �� *	btnCancel+6�   5:      5;      5>      5?      5@      5A      