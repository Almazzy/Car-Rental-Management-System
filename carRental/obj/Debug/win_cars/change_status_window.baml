   M S B A M L   `   `   `  ����D  @carRental, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:carRental.win_carscarRental.win_cars  5   	   -    'carRental.win_cars.change_status_window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:carRental.win_cars     5   	     � Title$5  / e-carRent - zmień status wybranego samochodu.��5   
   $	��600��6A   $	��517��6N    � WindowStyle$ 
ToolWindow=�6Z   ���	#FFE8E8E8 � 
ResizeMode$ CanResizeWithGrip=�5	   	   .��5
      � .+�5   
   �� ���	#FFD8D8D8$
��Left=�6%   $	��122��6@   
���   �$	��Top=�6\   $	��509��6t   �� 5   
   ���	#FF454553$
��Left=�6%   $��63��6@   $��	0,507,0,0q�6L   
���   �$	��Top=�6n   $	��509��6�   �� 5   
   ���	#FF9ABF7F$
��Left=�6%   $	��100��6@   
���   �$	��Top=�6\   $	��301��6t   $��
104,22,0,0q�6�   �� 5   
   ���	#FF9ABF7F$
��Left=�6%   $��10��6@   $��
45,122,0,0q�6L   
���   �$	��Top=�6o   $	��415��6�   �� 5   
   $��wyszukaj pojazd:��6   $
��Left=�6+   $��
40,153,0,0q�6F   $	��Top=�6Z   $��Rockwell Nova Cond)�6r   $��16(�6�   �� 5   
   $��marka:��6   $
��Left=�6!   $��
40,254,0,0q�6<   $	��Top=�6P   $��Rockwell Nova Cond)�6h   $��16(�6�   �� 5   
   -   5         ��Name$ 	combo_car��5      $
��Left=�6&   $��104,192,0,0q�6A   $	��Top=�6V   $	��301��6n   $��41��6z   $��Rockwell Nova Light)�6�   $��16(�6�   6�   �� 5   
   -   5         ��Name$ 
btn_change��5      $ ��d o k o n a j  z m i a n y��6%   $
��Left=�6J   $��104,512,0,0q�6e   $	��Top=�6z   $	��301��6�   $��42��6�   $��Rockwell Nova Light)�6�   $��16(�6�   ���	#FF7FB1BF
�������6  �� 5   
   $
��Left=�6   $��21��6/   $��
45,171,0,0q�6;   $	��Top=�6O   $	��131��6g   ���	#FF9ABF7F6s   �� 5   
   -   5         ��Name$ lbl_inf1��5   3   $��Right=�6   $��-��6E   $
��Left=�6Q   $��167,254,0,0q�6l   $	��Top=�6�   $��Rockwell Nova Light)�6�   $��16(�6�   $	��238��6�   �� 5   
   $��model:��6   $
��Left=�6!   $��
40,296,0,0q�6<   $	��Top=�6P   $��Rockwell Nova Cond)�6h   $��16(�6�   �� 5   
   -   5        $ lbl_inf2��5   3   $��Right=�6   $��-��6E   $
��Left=�6Q   $��167,296,0,0q�6l   $	��Top=�6�   $��Rockwell Nova Light)�6�   $��16(�6�   $	��238��6�   �� 5   
   $
��Left=�6   $��21��6/   $��
45,270,0,0q�6;   $	��Top=�6O   $��51��6g   ���	#FF9ABF7F6r   �� 5   
   $
��Left=�6   $��21��6/   $��
45,312,0,0q�6;   $	��Top=�6O   $��51��6g   ���	#FF9ABF7F6r   �� 5   
   $ ��zmien status
     pojazdu��6   $
��Left=�6>   $��
104,36,0,0q�6Y   $	��Top=�6m   $��25(�6�   $��Perpetua Titling MT)�6�   
�������$��Center=�6�   $	��301��6�   $��70��6�   �� 5   
   $��stan:��6   $
��Left=�6    $��
40,337,0,0q�6;   $	��Top=�6O   $��Rockwell Nova Cond)�6g   $��16(�6�   �� 5   
   -   5        $ lbl_inf5��5   3   $��Right=�6   $��-��6E   $
��Left=�6Q   $��167,337,0,0q�6l   $	��Top=�6�   $��Rockwell Nova Light)�6�   $��16(�6�   $	��238��6�   �� 5   
   $
��Left=�6   $��20��6/   $��
45,353,0,0q�6;   $	��Top=�6O   $��32��6g   ���	#FF9ABF7F6r   �� 5   
   -   5        $ combo_status��5      $
��Left=�6)   $��104,432,0,0q�6D   $	��Top=�6Y   $	��301��6q   $��41��6}   $��Rockwell Nova Light)�6�   $��16(�6�   .@�5      �� $��Serwis��6   �� 5      $��Dyzur��6   5       �� 5!   
   $��wybierz status:��6   $
��Left=�6*   $��
35,393,0,0q�6E   $	��Top=�6Y   $��Rockwell Nova Cond)�6q   $��16(�6�   �� 5"   
   $
��Left=�6   $��21��6/   $��
40,411,0,0q�6;   $	��Top=�6O   $	��114��6g   ���	#FF9ABF7F6s   5#      5$      