   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UI.ViewUI.View  5   	       UI.View.AddBolnica   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:UI.View     5   	     � Title$  
AddBolnica��5   	   $	��300��6   $	��300��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ cmbMesto��5
      $
��Left=�6%   $��
59,129,0,0q�6@   $	��Top=�6�   $	��120��6�    �� SelectedItem 6T   �� *SelectedMesto+��6{   �� *Mesta+6�   �� 5   
   $
��Left=�6   $��23��6-   $��	59,62,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6�   $	��120��6�   ��6`   �� *NazivBolnice+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5   
   $��Naziv bolnice:��6   $
��Bold"�6)   $
��Left=�6;   $��	69,36,0,0q�6V   $	��Top=�6i   �� 5   
   -   5        $��Nazivlbl��5   `   
���  ��$
��Bold"�6�   $
��Left=�6�   $��	51,85,0,0q�6�   $	��Top=�6�   $	��187��6�   $��23��6�   ��6   �� *
Nazivlbl+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
    �� 	IsDefault . $
��Left=�6�   $��
59,203,0,0q�6�   $	��Top=�6�   $	��120��6�    J� RenderTransformOrigin$ 0.077,0.576&�6�   $��31��6  ��6   �� *AddButtonContent+$ PropertyChanged=�$ TwoWay=���6y   �� *AddBolnicaCommand+6  5      5      