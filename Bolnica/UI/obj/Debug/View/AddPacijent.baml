   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UI.ViewUI.View  5   	       UI.View.AddPacijent   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:UI.View     5   	     � Title$  AddPacijent��5   	   $	��400��6   $	��400��6*   .��5	      � .+�5
   
   �� $
��Left=�6   $��23��6-   $��	63,51,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6�   $	��120��6�   ��6`   �� *Ime+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $
��Left=�6   $��23��6-   $��
60,150,0,0q�69   $
 Wrap=�6M   $	��Top=�6�   $	��120��6�   ��6a   �� *	Prezime+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $
��Left=�6   $��23��6-   $��
60,243,0,0q�69   $
 Wrap=�6M   $	��Top=�6�   $	��120��6�   ��6a   �� *
Radni_staz+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   -   5         ��Name$ imelbl��5   s   
���  ��$
��Bold"�6a   $
��Left=�6�   $��	44,74,0,0q�6�   $	��Top=�6�   $	��205��6�   $��24��6�   ��6   �� *Imelbl+$ PropertyChanged=�5      �� 5   
   -   5        $ 
prezimelbl��5   w   
���  ��$
��Bold"�6e   $
��Left=�6�   $��
44,173,0,0q�6�   $	��Top=�6�   $	��205��6�   $��25��6�   ��6   �� *
Prezimelbl+$ PropertyChanged=�5      �� 5   
   -   5        $ radnistazlbl��5   y   
���  ��$
��Bold"�6g   $
��Left=�6�   $��
44,266,0,0q�6�   $	��Top=�6�   $	��328��6�   $��27��6�   ��6   �� *Radnistazlbl+$ PropertyChanged=�5      �� 5   
   -   5         ��Name$ 
cmbBolnica��5      $
��Left=�6'   $��
232,51,0,0q�6B   $	��Top=�6�   $	��120��6�    �� SelectedItem 6V   �� *SelectedBolnica+��6   �� *	Bolnice+6�   �� 5   
   -   5        $ cmbMesto��5      $
��Left=�6%   $��232,124,0,0q�6@   $	��Top=�6�   $	��120��6�    6U   �� *SelectedMesto+��6|   �� *Mesta+6�   �� 5   
   $
��Ime:��6   $
��Bold"�6   $
��Left=�61   $��	63,25,0,0q�6L   $	��Top=�6_    J� RenderTransformOrigin$ -0.244,0.548&�6w   $	��120��6�   �� 5   
   $��Radni staz:��6   $
��Bold"�6&   $
��Left=�68   $��
60,217,0,0q�6S   $	��Top=�6g   $ -0.244,0.548&�6   $	��120��6�   �� 5   
   $��Prezime:��6   $
��Bold"�6#   $
��Left=�65   $��
60,124,0,0q�6P   $	��Top=�6d   $ -0.244,0.548&�6|   $	��120��6�   �� 5   
   $��Bolnica:��6   $
��Bold"�6#   $
��Left=�65   $��
232,25,0,0q�6P   $	��Top=�6d   $ -0.002,0.844&�6|   $	��120��6�   �� 5   
   $
��Left=�6�   $��130,315,0,0q�6�   $	��Top=�6�   $	��119��6�   $��33��6�   ��6   �� *AddButtonContent+$ TwoWay=�$ PropertyChanged=���6h   �� *AddLekarCommand+6�   �� 5   
   $��Mesto prebivalista:��6   $
��Bold"�6.   $
��Left=�6@   $��
232,98,0,0q�6[   $	��Top=�6o   $	��120��6�   5      5      