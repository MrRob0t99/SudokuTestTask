   M S B A M L   `   `   `  ����C  ?TestTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TestTask.MyTestTask.My  5   	       TestTask.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TestTask.My     5   	     � 
ResizeMode$  NoResize=�5	   	    � Title$ 
MainWindow��5
   	   $	��454��6   $	��773��6)   .��5      � $��0,0,0,0q�6   $
��Left=�6   $	��614��67   $	��358��6C   $��Bottom=�6P    � ColumnDefinitions 5   
   �� 5      $
��465* �6   �� 5      $
��149* �6   .+�5   
   � -   5         �Name$ myGrid��5   $    � ShowGridLines . $��Right=�65   $	��614��6Q   $��0,-25,-11,29q�6]   $	��354��6s   $��Bottom=�6�   $��2��6�    � RowDefinitions 5      �� 5      6"   �� 5      6"   �� 5      6"    5      �� 5      6%   �� 5      6%   �� 5      6%   5      �� 5   
   $��155,25,-161,163q�6   $��1��6/   .+�5      �� -   5         ��Name$ start��5      $��45��6E   $��Start��6Q   $��	15,0,25,0q�6a   ��6$   �� *StartCommand+6a   �� 5      -   5        $ 
clear_Copy��5      $��49��6I   $
��Stop��6U   $��0,0,25,0q�6d   $��Right=�6v   $	��115��6�   ��6)   �� *StopCommand+6�   �� 5       -   5        $ clear��5       $��50��6E   $��Clean��6Q   $��0,0,25,0q�6a   $��Right=�6s   $	��115��6�   ��6$   �� *CleanCommand+6�   �� 5"      $��StepMode��6   $��	15,0,25,0q�6�    d� 	IsChecked 6+   ��  �� Path$ CheckBoxIsChecked�	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=�6�   5#      �� 5%   
   $��170,280,-136,28q�6   $��1��6*   $
��Exit��6:   ��6I   �� *ExitCommand+5&      5(      