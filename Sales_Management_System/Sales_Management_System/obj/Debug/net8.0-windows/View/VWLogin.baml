   M S B A M L   `   `   `  ����R  NSales_Management_System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Sales_Management_System.ViewSales_Management_System.View  5   	   *    $Sales_Management_System.View.VWLogin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:Sales_Management_System.View     5   	   X TFontAwesome5.WPF, Version=1.0.5.65, Culture=neutral, PublicKeyToken=9cfaf01297a008f8/fa5%http://schemas.fontawesome.com/icons/  5   	     � Title$  VWLogin��5	   	    � WindowState$ 	Maximized=�6    � WindowStyle$
 None=�61    � WindowStartupLocation$ CenterScreen=�6D    � AllowsTransparency$
 True��6i   ���#2c2c2c.��5
      � 
������� � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��0��6   ���#004D23 �� CornerRadius$ 10��66   ._�5      � .+�5      �� $��Center=�6   $��Center=�68   .+�5      �� $��/Images/login.png��6   $	��200��67   $	��200��6C   $��Center=�6P   �� 5      $��Welcome to the��6    
�������$��50(�6I   $
��Bold"�6W   $��Center=�6i   �� 5      $��MKP Super Market��6    
�������$��60(�6K   $
��Bold"�6Y   $��Center=�6k   5      �� 5      $��Developed by MKP��6   
�������$��28(�6K   $��Center=�6Y   $��Bottom=�6v   $��0,0,0,30q�6�   5      5      �� 5   
   $��1��6   
�������$ 15��64   $	��450��5   
   $��Center=�6   $��Center=�63   ._�5       �� $��Center=�6   .+�5"      ��   FontAwesome5.WPF.Awesome   Content$ 
Solid_User=�6   $��90(�69   ���#23664d$��Center=�6\   $��	0 15 0 15q�6y   �� 5%      $��Login to your account��6   $��Center=�69   $��24(�6V   ���#23664d$
��Bold"�6y   $��	0 15 0 25q�6�   �� 5(      .+�5)      �� $��Username��6    $��20(�60   $+��%pack://application:,,,/Fonts/#Poppins)�6>   
���   �$��0 0 0 8q�6�   �� 5*       �� DisplayMemberPath$ UserName��6m   $	��320��5+      $��40��6    $��20(�6,   $��Center=�6:   $��0 5 0 20q�6W   ��5*      �� *UserCollection+	 �� SelectedValue	 6F   �� *SelectedUser+5+   W   5,      �� 5/      .+�50      �� $��Password��6    $��20(�60   $+��%pack://application:,,,/Fonts/#Poppins)�6>   
���   �$��0 0 0 8q�6�   G� 51      -   5        
 G�Name$
 passwordBox��51   "   $	��320��67   $��40��6C   $��20(�6O   6]   52      �� 55       
  button#��[  6     ButtonTemplate2#���  69   $	��320��56   .   $��45��6:   $��20(�6F   $��0 25 0 0q�57      $��Login��6    $
��Bold"�60   $��Center=�6B   $+��%pack://application:,,,/Fonts/#Poppins)�6_   ��55   f   ��  �� ElementName$ Password����56      �� *cmdMainmenu+57   _   58      59      5;      5<      