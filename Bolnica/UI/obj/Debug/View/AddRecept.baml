   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UI.ViewUI.View  5   	       UI.View.AddRecept   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:UI.View     5   	     � Title$  	AddRecept��5   	   $	��300��6   $	��300��6(   .��5	      � $��0,0,2,0q�6   .+�5
   
   �� $
��Left=�6   $��23��6-   $��	87,88,0,0q�69    �� TextWrapping$
 Wrap=�6L   $	��Top=�6�   $	��120��6�   ��6`   �� *Naziv+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   -   5         ��Name$ imelbl��5   u   
���  ��$
��Bold"�6c   $
��Left=�6�   $��
75,111,0,0q�6�   $	��Top=�6�   $	��205��6�   $��24��6�   ��6   �� *
Nazivlbl+$ PropertyChanged=�6�   �� 5   
   $��Naziv recepta:��6   $
��Bold"�6)   $
��Left=�6;   $��	87,62,0,0q�6V   $	��Top=�6i    J� RenderTransformOrigin$ -0.244,0.548&�6�   $	��120��6�   �� 5   
   $
��Left=�6�   $��
87,153,0,0q�6�   $	��Top=�6�   $	��119��6�   $��33��6�   ��6   �� *AddButtonContent+$ TwoWay=�$ PropertyChanged=���6h   �� *AddReceptCommand+6�   5      5      