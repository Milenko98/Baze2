   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UI.ViewUI.View  5   	       UI.View.AddObezbedjenje   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:UI.View     5   	     � Title$  AddObezbedjenje��5   	   $	��400��6!   $	��400��6.   .��5	      � .+�5
   
   �� $
��Left=�6   $��23��6-   $��	72,62,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6�   $	��120��6�   ��6`   �� *Ime+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $
��Left=�6   $��23��6-   $��
69,161,0,0q�69   $
 Wrap=�6M   $	��Top=�6�   $	��120��6�   ��6a   �� *	Prezime+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $
��Left=�6   $��23��6-   $��
69,254,0,0q�69   $
 Wrap=�6M   $	��Top=�6�   $	��120��6�   ��6a   �� *
Radni_staz+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   -   5         ��Name$ imelbl��5   s   
���  ��$
��Bold"�6a   $
��Left=�6�   $��	55,85,0,0q�6�   $	��Top=�6�   $	��205��6�   $��26��6�   ��6   �� *Imelbl+$ PropertyChanged=�6�   �� 5   
   -   5        $ 
prezimelbl��5   w   
���  ��$
��Bold"�6e   $
��Left=�6�   $��
55,184,0,0q�6�   $	��Top=�6�   $	��205��6�   $��28��6�   ��6   �� *
Prezimelbl+$ PropertyChanged=�6�   �� 5   
   -   5        $ radnistazlbl��5   y   
���  ��$
��Bold"�6g   $
��Left=�6�   $��
55,277,0,0q�6�   $	��Top=�6�   $	��300��6�   $��33��6�   ��6   �� *Radnistazlbl+$ PropertyChanged=�6�   �� 5   
   $
��Ime:��6   $
��Bold"�6   $
��Left=�61   $��	72,36,0,0q�6L   $	��Top=�6_    J� RenderTransformOrigin$ -0.244,0.548&�6w   $	��120��6�   �� 5   
   $��Radni staz:��6   $
��Bold"�6&   $
��Left=�68   $��
69,228,0,0q�6S   $	��Top=�6g   $ -0.244,0.548&�6   $	��120��6�   �� 5   
   $��Prezime:��6   $
��Bold"�6#   $
��Left=�65   $��
69,135,0,0q�6P   $	��Top=�6d   $ -0.244,0.548&�6|   $	��120��6�   �� 5   
   $
��Left=�6�   $��135,315,0,0q�6�   $	��Top=�6�   $	��119��6�   $��33��6�   ��6   �� *AddButtonContent+$ TwoWay=�$ PropertyChanged=���6h   �� *AddObezbedjenjeCommand+6�   �� 5   
   -   5         ��Name$ cmbBolnica_Copy��5      $
��Left=�6,   $��
248,64,0,0q�6G   $	��Top=�6�   $	��120��6�    �� SelectedItem 6[   �� *SelectedBolnica+��6�   �� *	Bolnice+6�   �� 5   
   -   5        $ cmbMesto��5      $
��Left=�6%   $��248,137,0,0q�6@   $	��Top=�6�   $	��120��6�    6U   �� *SelectedMesto+��6|   �� *Mesta+6�   �� 5   
   $��Radno mesto:��6   $
��Bold"�6'   $
��Left=�69   $��
248,38,0,0q�6T   $	��Top=�6h   $ -0.002,0.844&�6�   $	��120��6�   �� 5   
   $��Mesto prebivalista:��6   $
��Bold"�6.   $
��Left=�6@   $��248,111,0,0q�6[   $	��Top=�6p   $	��120��6�   5      5      