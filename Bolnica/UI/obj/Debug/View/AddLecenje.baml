   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UI.ViewUI.View  5   	       UI.View.AddLecenje   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:UI.View     5   	     � Title$  
AddLecenje��5   	   $	��300��6   $	��300��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ cmbTerapija��5
      $
��Left=�6(   $��	70,60,0,0q�6C   $	��Top=�6�   $	��120��6�    �� SelectedItem 6V   �� *SelectedTerapija+��6�   �� *
Terapije+6�   �� 5   
   -   5        $ cmbDijagnoza��5      $
��Left=�6)   $��
70,133,0,0q�6D   $	��Top=�6�   $	��120��6�    6X   �� *SelectedDijagnoza+��6�   �� *	Dijagnoze+6�   �� 5   
   $��	Terapija:��6   $
��Bold"�6$   $
��Left=�66   $��	70,34,0,0q�6Q   $	��Top=�6d    J� RenderTransformOrigin$ -0.002,0.844&�6|   $	��120��6�   �� 5   
   $
��Left=�6�   $��
70,208,0,0q�6�   $	��Top=�6�   $	��119��6�   $��33��6�   ��6   �� *AddButtonContent+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6h   �� *AddLecenjeCommand+6�   �� 5   
   $��
Dijagnoza:��6   $
��Bold"�6%   $
��Left=�67   $��
70,107,0,0q�6R   $	��Top=�6f   $	��120��6~   5      5      