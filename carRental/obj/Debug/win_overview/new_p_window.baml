   M S B A M L   `   `   `  ����D  @carRental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:carRental.win_overviewcarRental.win_overview  5   	   )    #carRental.win_overview.new_p_window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:carRental.win_overview     5   	     � Title$,  & e-carRent - wprowadź nowy przegląd.��5   	   $	��600��66   $	��517��6C    � WindowStyle$ 
ToolWindow=�6O   ���	#FFE8E8E8 � 
ResizeMode$ CanResizeWithGrip=�5	   	   .��5
      � .+�5   
   �� ���	#FFD8D8D8$
��Left=�6%   $	��122��6@   
���   �$	��Top=�6\   $	��509��6t   �� 5   
   ���	#FF454553$
��Left=�6%   $��63��6@   $��	0,507,0,0q�6L   
���   �$	��Top=�6n   $	��509��6�   �� 5   
   ���	#FFA69FC7$
��Left=�6%   $	��100��6@   
���   �$	��Top=�6\   $	��301��6t   $��
104,22,0,0q�6�   �� 5   
   ���	#FFA69FC7$
��Left=�6%   $��10��6@   $��
45,122,0,0q�6L   
���   �$	��Top=�6o   $	��415��6�   �� 5   
   $(��"    wprowadzanie
nowego przegladu��6   $
��Left=�6F   $��
104,36,0,0q�6a   $	��Top=�6u   $��25(�6�   $��Perpetua Titling MT)�6�   
�������$��Center=�6�   $	��301��6�   $��70��6�   �� 5   
   $$��wyszukaj warsztat wykonujący:��6   $
��Left=�68   $��
35,154,0,0q�6S   $	��Top=�6g   $��Rockwell Nova Cond)�6   $��16(�6�   �� 5   
   -   5         ��Name$ 	combo_ser��5      $
��Left=�6&   $��104,195,0,0q�6A   $	��Top=�6V   $	��301��6n   $��41��6z   $��Rockwell Nova Light)�6�   $��16(�6�   �� 5   
   $
��Left=�6   $��21��6/   $��
40,172,0,0q�6;   $	��Top=�6O   $	��244��6g   ���	#FFA69FC76s   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ date_do��5      $
��Left=�6&   $��258,300,0,0q�6A   $	��Top=�6V   $	��147��6n      SelectedDateFormat$ Short=�6z   $��24��6�   �� 5   
   $��data od:��6   $
��Left=�6#   $��
40,261,0,0q�6>   $	��Top=�6R   $��Rockwell Nova Cond)�6j   $��16(�6�   �� 5   
   $
��Left=�6   $��21��6/   $��
45,279,0,0q�6;   $	��Top=�6O   $��59��6g   ���	#FFA69FC76r   �� 5   
   $��data do:��6   $
��Left=�6#   $��253,261,0,0q�6>   $	��Top=�6S   $��Rockwell Nova Cond)�6k   $��16(�6�   �� 5   
   $
��Left=�6   $��21��6/   $��258,279,0,0q�6;   $	��Top=�6P   $��59��6h   ���	#FFA69FC76s     5   
   -   5        $ date_od��5      $
��Left=�6&   $��
45,300,0,0q�6A   $	��Top=�6U   $	��147��6m   $ Short=�6y   $��24��6�   �� 5   
   $��notatka:��6   $
��Left=�6#   $��
30,353,0,0q�6>   $	��Top=�6R   $��Rockwell Nova Cond)�6j   $��16(�6�   �� 5   
   $
��Left=�6   $��21��6/   $��
35,371,0,0q�6;   $	��Top=�6O   $��58��6g   ���	#FFA69FC76r   �� 5   
   -   5         ��Name$ txt_text��5      $
��Left=�6$   $	��106��6?   $��104,392,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��301��6�   $��18(�6�   $��Rockwell Nova Light)�6�   �� 5   
   -   5         ��Name$ btn_add��5      $!��d o d a j  p r z e g l ą d��6"   $
��Left=�6G   $��104,512,0,0q�6b   $	��Top=�6w   $	��301��6�   $��42��6�   ���	#FF7FB1BF
�������$��16(�6�   $��Rockwell Nova Light)�6�   6   5      5      