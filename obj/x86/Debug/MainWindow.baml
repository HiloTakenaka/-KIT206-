   M S B A M L   `   `   `  ����M  IConsoleApplication, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:KIT206KIT206  5          KIT206.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:KIT206     5        � Title$  
MainWindow��5      $	��450��6!   $	��850��6.    � 	Resources 5	         KIT206.Unit   Unit 
 MyList S� ObjectInstance S� 
MethodName��%^   &	        &	      7     5
   
   6   S� 5   
   8   $ GetList��5      5      5      .��5      � -   5         �Name$ MainGrid��5      ���	#FFDADADA.+�5   
   �� -   5         ��Name$ Title��5      $
��Left=�6#   $
��Wrap=�6>   $	��Top=�6R   $��29��6j   $	��143��6v   $��	10,14,0,0q�6�   $��18(�6�   �� 6�    � Language$ en-au�6�   $�HRIS Database��6�   �� 6�   �� 6�   $ en-au�6�   6�   �� 5   
   -   5         ��Name$
 Home��5      $
��Home��6   $
��Left=�6.   $��
540,14,0,0q�6I   $	��Top=�6]    J� RenderTransformOrigin$ -0.876,0.325&�6u   $��29��6�   $��80��6�   $y�Visible=�6�   {�.  6�   �� 5   
   -   5        $ Units��5      $��Units��6    $
��Left=�60   $��
625,14,0,0q�6K   $	��Top=�6_   $ -0.876,0.325&�6w   $��29��6�   $��80��6�   6�   �� 5   
   -   5        $ Staff��5      $��Staff��6    $
��Left=�60   $��
710,14,0,0q�6K   $	��Top=�6_   $ -0.876,0.325&�6w   $��29��6�   $��80��6�   6�   � 5   
   -   5        $ HomeGrid��5      $��0,63,0,0q�6!   
�������	 � ColumnDefinitions	 5      �� 5      $
��133* �6#   �� 5      $
��133* �6#   �� 5      $
��133* �6#   .+�5      �� -   5        $ textAllUnits��5      $��Center=�6.   $��0,10,0,0q�6K   $
��Wrap=�6]   $��	All Units��6q   $	��Top=�6�   �� 5      -   5        $ textAllStaff��5      $��Center=�6.   $��0,10,0,0q�6K   $
��Wrap=�6]   $��	All Staff��6q   $	��Top=�6�   $��1��6�   �� 5      -	   5        $ textUnitsTaught��5      $��Center=�61   $��0,10,0,0q�6N   $
��Wrap=�6`   $��Units Taught��6t   $	��Top=�6�   $��2��6�   �� 5      -
   5        
 ��Name$
 	unitsList��5      $��0,34,0,0q�6`   $��Center=�6r   ��6)   ��  �� Source# [ 6r   �� 5      -   5        $
 	staffList��5      $��2��6T   $��
266,34,0,0q�6h   $��Stretch=�6|   �� 5       -   5        $
 
taughtList��5       $��2��6U   $��
266,34,0,0q�6i   $��Stretch=�6}   $��1��6�   5!      5"      5#      