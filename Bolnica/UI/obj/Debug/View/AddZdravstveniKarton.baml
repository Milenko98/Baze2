   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UI.ViewUI.View  5   	   "    UI.View.AddZdravstveniKarton   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:UI.View     5   	     � Title$  AddZdravstveniKarton��5   	   $	��300��6&   $	��300��63   .��5	      � .+�5
   
   �� -   5         ��Name$ cmbPacijent��5
      $
��Left=�6(   $��
66,138,0,0q�6C   $	��Top=�6�   $	��120��6�    �� SelectedItem 6W   �� *SelectedPacijent+��6�   �� *	Pacijenti+6�   �� 5   
   $��	Pacijent:��6   $
��Bold"�6$   $
��Left=�66   $��
66,112,0,0q�6Q   $	��Top=�6e    J� RenderTransformOrigin$ -0.002,0.844&�6}   $	��120��6�   �� 5   
   $
��Left=�6�   $��
67,208,0,0q�6�   $	��Top=�6�   $	��119��6�   $��33��6�   ��6   �� *AddButtonContent+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6h   �� *AddZdravstveniKartonCommand+6�   (  "System.Windows.Controls.DatePicker  5   
   $
��Left=�6   $��	66,66,0,0q�6�   $	��Top=�6�   $	��120��6�      SelectedDate 60   �� *IzabranDatum+$ TwoWay=�$ PropertyChanged=�6�   �� 5   
   $��Rok vazenja��6   $
��Bold"�6&   $
��Left=�68   $��	66,35,0,0q�6S   $	��Top=�6f   5      5      