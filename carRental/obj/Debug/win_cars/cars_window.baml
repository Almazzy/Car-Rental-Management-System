   M S B A M L   `   `   `  ����  	carRental$    carRental.win_cars.cars_window   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$   e-carRent - samochody.��5   	    � WindowStyle$ 
ToolWindow=�6)   ���	#FFEAE7DC � 
ResizeMode$ CanResizeWithGrip=�5   	   $
��1925��6(   $
��1050��68   $
��1925��6I   $
��1050��6V    � WindowStartupLocation$ CenterOwner=�6d    � Left$ -5��6�   
 � Top$ -5��6�    � 	Resources 5	       
  color1��%+   &	        ��5
   
   	#FFCB99C5��6*   5      .��5      � ���	#FFE8E8E8$��	-12,0,0,0q�6"    � RowDefinitions 5   
   �� 5      .+�5   
   �� ���	#FF454553$
��Left=�6%   $	��100��6@   $��	0,920,0,0q�6M   
���   �$	��Top=�6o   $
��1929��6�   �� 5   
   ���	#FFD8D8D8$
��Left=�6%   $	��162��6@   
�������$	��Top=�6`   $
��1929��6x    J� Opacity$	 0.5Q�6�   �� 5   
   $
��Left=�6   $	��100��6/   $��	495,0,0,0q�6<   $	��Top=�6O   $	��201��6g   ��5      �� 5      	 �� Color#	 �   6"   5      �� 5   
   $
��Left=�6   $	��100��6/   $��
495,87,0,0q�6<   $	��Top=�6P   $	��201��6h   ���	#FFCB99C56t   �� 5   
   $
��Left=�6   $	��100��6/   $��
451,44,0,0q�6<   $	��Top=�6P   $��88��6h   
 J� RenderTransformOrigin$
 0.5,0.5&�6s   ���	#FFCB99C5z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$	 -90Q�6&   T� 5      5      5!      �� 5"   
   $
��Left=�6   $	��100��6/   $��
652,44,0,0q�6<   $	��Top=�6P   $��88��6h   $
 0.5,0.5&�6s   ���	#FFCB99C5z�5#      V� 5$      .~�5%      �� �� 5&      �� 5'      $	 -90Q�6&   T� 5(      5)      5+      �� 5,   
   -   5         ��Name$ btn_all_cars��5,      $(��"


            wszystkie samochody��6'   $
��Left=�6`   $��116,228,0,0q�6{   $	��Top=�6�   $	��278��6�   $	��104��6�   ���	#FFE8E8E8$��16(�6�   $��Verdana Pro SemiBold)�6�   ���	#FF707070 � ToolTip$ wszystkie samochody��6:  �� 5-   
   -   5         ��Name$	 im1��5-      $,��&/carRental;component/pic/cars/twos.png��6   $
��Left=�6M   $��62��6h   $��128,246,0,0q�6t   $	��Top=�6�   $��62��6�   �� 5.   
   -   5         ��Name$ lbl_all_cars��5.      $�� ��6&   $
��Left=�61   $��299,212,0,0q�6L   $	��Top=�6a   $��88��6y   ���	#FF707070$��50(�6�   $��Yu Gothic Light)�6�   $��68��6�   $��Right=�6�   &   System.Windows.Controls.DataGrid  5/   
   -   5          Name$ 	dataGrid1��5/   /      AutoGenerateColumns .  $
��Left=�6B   $	��656��6]   $��413,228,0,0q�6j   $	��Top=�6   $
��1460��6�   $��Center=�6�      Columns 50      0  *System.Windows.Controls.DataGridTextColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ nr rejestracyjny��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 131 6d   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *nr_rejestracyjny+6d     52      $	 vin��6%   $	 131 6J    62   �� *vin+6J     53      $ marka��6%   $	 131 6N    64   �� *marka+6N     54      $ model��6%   $	 131 6N    64   �� *model+6N     55      $ rok produkcji��6%   $	 131 6^    6<   �� *rok_produkcji+6^     56      $ 	pojemnosc��6%   $	 131 6V    68   �� *	pojemnosc+6V     57      $ paliwo��6%   $	 131 6P    65   �� *paliwo+6P     58      $	 typ��6%   $	 131 6J    62   �� *typ+6J     59      $
 stan��6%   $	 131 6L    63   �� *stan+6L     5:      $ przegląd do��6%   $	 131 6W    6:   �� *
data_doo+6W     5;      $ 	polisa do��6%   $	 131 6T    68   �� *	data_do+6T   5=      �� 5>   
   -   5        $ btn_wy_cars��5>      $#��


          wydane samochody��6&   $
��Left=�6Z   $��116,337,0,0q�6u   $	��Top=�6�   $	��278��6�   $	��104��6�   ���	#FFE8E8E8$��16(�6�   $��Verdana Pro SemiBold)�6�   ���	#FF707070$ wydane samochody��63  �� 5?   
   -   5        $	 im2��5?      $0��*/carRental;component/pic/cars/manwcars.png��6   $
��Left=�6Q   $��62��6l   $��128,354,0,0q�6x   $	��Top=�6�   $��62��6�   �� 5@   
   -   5        $ lbl_wy_cars��5@      $�� ��6%   $
��Left=�60   $��298,320,0,0q�6K   $	��Top=�6`   $��88��6x   ���	#FF707070$��50(�6�   $��Yu Gothic Light)�6�   $��68��6�   $��Right=�6�   �� 5A   
   -   5        $ btn_wo_cars��5A      $"��


          wolne samochody��6&   $
��Left=�6Y   $��116,446,0,0q�6t   $	��Top=�6�   $	��278��6�   $	��104��6�   ���	#FFE8E8E8$��16(�6�   $��Verdana Pro SemiBold)�6�   ���	#FF707070$ wolne samochody��62  �� 5B   
   -	   5        $	 im3��5B      $,��&/carRental;component/pic/cars/wols.png��6   $
��Left=�6M   $��62��6h   $��128,462,0,0q�6t   $	��Top=�6�   $��62��6�   �� 5C   
   -
   5        $ lbl_wo_cars��5C      $�� ��6%   $
��Left=�60   $��299,428,0,0q�6K   $	��Top=�6`   $��88��6x   ���	#FF707070$��50(�6�   $��Yu Gothic Light)�6�   $��68��6�   $��Right=�6�   �� 5D   
   -   5        $ btn_res_cars��5D      $ ��


          zarezerwowane��6'   $
��Left=�6X   $��116,555,0,0q�6s   $	��Top=�6�   $	��278��6�   $	��102��6�   ���	#FFE8E8E8$��16(�6�   $��Verdana Pro SemiBold)�6�   ���	#FF707070$ zarezerowane samochody��62  �� 5E   
   -   5        $	 im4��5E      $,��&/carRental;component/pic/cars/ress.png��6   $
��Left=�6M   $��73��6h   $��123,575,0,0q�6t   $	��Top=�6�   $��69��6�   �� 5F   
   -   5        $ lbl_res_cars��5F      $�� ��6&   $
��Left=�61   $��299,538,0,0q�6L   $	��Top=�6a   $��88��6y   ���	#FF707070$��50(�6�   $��Yu Gothic Light)�6�   $��68��6�   $��Right=�6�   �� 5G   
   -   5        $ btn_a��5G      $��A��6    $
��Left=�6,   $��
25,228,0,0q�6G   $	��Top=�6[   $��60��6s   $��30��6~   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��16(�6�   $ klasa A��6�   $ 0.545Q�6  ���	#FF2E2E2E6  �� 5H   
   -   5        $ btn_b��5H      $��B��6    $
��Left=�6,   $��
25,263,0,0q�6G   $	��Top=�6[   $��60��6s   $��30��6~   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��16(�6�   $ klasa B��6�   $
 0.55Q�6  ���	#FF2E2E2E6  �� 5I   
   -   5        $ btn_c��5I      $��C��6    $
��Left=�6,   $��
25,298,0,0q�6G   $	��Top=�6[   $��60��6s   $��30��6~   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��16(�6�   $ klasa C��6�   $
 0.55Q�6  ���	#FF2E2E2E6  �� 5J   
   -   5        $ btn_d��5J      $��D��6    $
��Left=�6,   $��
25,333,0,0q�6G   $	��Top=�6[   $��60��6s   $��30��6~   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��16(�6�   $ klasa D��6�   $
 0.55Q�6  ���	#FF2E2E2E6  �� 5K   
   -   5        $ btn_e��5K      $��E��6    $
��Left=�6,   $��
25,368,0,0q�6G   $	��Top=�6[   $��60��6s   $��30��6~   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��16(�6�   $ klasa E��6�   $
 0.55Q�6  ���	#FF2E2E2E6  �� 5L   
   -   5        $ btn_p��5L      $��P��6    $
��Left=�6,   $��
25,403,0,0q�6G   $	��Top=�6[   $��60��6s   $��30��6~   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��16(�6�   $ klasa Premium��6�   $
 0.55Q�6  ���	#FF2E2E2E6#  �� 5M   
   -   5        $ btn_r��5M      $��R��6    $
��Left=�6,   $��
25,438,0,0q�6G   $	��Top=�6[   $��60��6s   $��30��6~   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��16(�6�   $ klasa R��6�   $
 0.57Q�6  ���	#FF2E2E2E6  �� 5N   
   -   5        $ btn_suv��5N      $	��SUV��6"   $
��Left=�60   $��
25,473,0,0q�6K   $	��Top=�6_   $��60��6w   $��30��6�   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��16(�6�   $ 	klasa SUV��6�   $
 0.55Q�6  ���	#FF2E2E2E6%  �� 5O   
   $
��Left=�6   $��16��6/   $��116,770,0,0q�6;   $	��Top=�6P   $	��278��6h   �� 5P   
   -   5        $ btn_ser_cars��5P      $$��


          dyżury / serwisy��6'   $
��Left=�6[   $��116,662,0,0q�6v   $	��Top=�6�   $	��278��6�   $	��104��6�   ���	#FFE8E8E8$��16(�6�   $��Verdana Pro SemiBold)�6�   ���	#FF707070$ dyżur / serwis ��65  �� 5Q   
   -   5        $	 im5��5Q      $,��&/carRental;component/pic/cars/sers.png��6   $
��Left=�6M   $��66��6h   $��123,680,0,0q�6t   $	��Top=�6�   $��67��6�   �� 5R   
   -   5        $ lbl_ser_cars��5R      $�� ��6&   $
��Left=�61   $��299,648,0,0q�6L   $	��Top=�6a   $��88��6y   ���	#FF707070$��50(�6�   $��Yu Gothic Light)�6�   $��68��6�   $��Right=�6�   �� 5S   
   $
��Left=�6   $��16��6/   $��-240,560,0,0q�6;   $	��Top=�6Q   $	��682��6i   $
 0.5,0.5&�6u   z�5T      V� 5U      .~�5V      �� �� 5W      �� 5X      $ 90.025Q�6&   T� 5Y      5Z      5\      �� 5]   
   $
��Left=�6   $��16��6/   $��
25,508,0,0q�6;   $	��Top=�6O   $��60��6g   �� 5^   
   $2��,/carRental;component/pic/cars/hatchbacks.png��6   $
��Left=�6F   $��45��6a   $��
32,522,0,0q�6m   $	��Top=�6�   $��45��6�   �� 5_   
   $.��(/carRental;component/pic/cars/sedans.png��6   $
��Left=�6B   $��54��6]   $��
28,553,0,0q�6i   $	��Top=�6}   $��54��6�   �� 5`   
   $.��(/carRental;component/pic/cars/kombis.png��6   $
��Left=�6B   $��55��6]   $��
28,588,0,0q�6i   $	��Top=�6}   $��54��6�   �� 5a   
   $.��(/carRental;component/pic/cars/sports.png��6   $
��Left=�6B   $��53��6]   $��
28,623,0,0q�6i   $	��Top=�6}   $��55��6�   �� 5b   
   $,��&/carRental;component/pic/cars/suvs.png��6   $
��Left=�6@   $��55��6[   $��
29,659,0,0q�6g   $	��Top=�6{   $��52��6�   �� 5c   
   $,��&/carRental;component/pic/cars/vans.png��6   $
��Left=�6@   $��43��6[   $��
33,698,0,0q�6g   $	��Top=�6{   $��43��6�   �� 5d   
   -   5        $ btn_hatchback��5d      $�� ��6(   $
��Left=�63   $��
25,529,0,0q�6N   $��Center=�6b   $	��Top=�6�   $��60��6�   $��30��6�   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��10(�6  $ 	hatchback��6  $
 0.75Q�6C  �� 5e   
   -   5        $ 	btn_sedan��5e      $�� ��6$   $
��Left=�6/   $��
25,564,0,0q�6J   $	��Top=�6^   $��60��6v   $��30��6�   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��16(�6�   $ sedan��6�   $
 0.75Q�6  �� 5f   
   -   5        $ 	btn_kombi��5f      $�� ��6$   $
��Left=�6/   $��
25,599,0,0q�6J   $	��Top=�6^   $��60��6v   $��30��6�   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��16(�6�   $ kombi��6�   $
 0.75Q�6  �� 5g   
   -   5        $ 	btn_sport��5g      $�� ��6$   $
��Left=�6/   $��
25,634,0,0q�6J   $	��Top=�6^   $��60��6v   $��30��6�   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��16(�6�   $ coupe / sportowe��6�   $
 0.75Q�6  �� 5h   
   -   5        $ btn_suvy��5h      $�� ��6#   $
��Left=�6.   $��
25,669,0,0q�6I   $	��Top=�6]   $��60��6u   $��30��6�   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��16(�6�   $	 SUV��6�   $
 0.75Q�6  �� 5i   
   -   5        $ btn_van��5i      $�� ��6"   $
��Left=�6-   $��
25,704,0,0q�6H   $	��Top=�6\   $��60��6t   $��30��6   ���	#FF707070���	#FFE8E8E8$��Verdana Pro SemiBold)�6�   $��16(�6�   $	 VAN��6�   $
 0.75Q�6  �� 5j   
   $
��Left=�6   $��16��6/   $��
25,740,0,0q�6;   $	��Top=�6O   $��60��6g   �� 5k   
   -   5         ��Name$ 
txt_search��5k      $
��Left=�6&   $��23��6A   $��676,200,0,0q�6M    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��131��6�   6�   �� 5l   
   -    5        $ txt_s4��5l      $
��Left=�6"   $��23��6=   $��807,200,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��131��6�   6�   �� 5m   
   -!   5        $ txt_s1��5m      $
��Left=�6"   $��23��6=   $��413,200,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��132��6�   6�   �� 5n   
   -"   5        $ txt_s2��5n      $
��Left=�6"   $��23��6=   $��545,200,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��131��6�   6�   �� 5o   
   -#   5        $ txt_s5��5o      $
��Left=�6"   $��23��6=   $��938,200,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��131��6�   6�   �� 5p   
   -$   5        $ txt_s6��5p      $
��Left=�6"   $��23��6=   $��1069,200,0,0q�6I   $
 Wrap=�6_   $	��Top=�6s   $	��131��6�   6�   �� 5q   
   -%   5        $ txt_s7��5q      $
��Left=�6"   $��23��6=   $��1200,200,0,0q�6I   $
 Wrap=�6_   $	��Top=�6s   $	��131��6�   6�   �� 5r   
   -&   5        $ txt_s8��5r      $
��Left=�6"   $��23��6=   $��1331,200,0,0q�6I   $
 Wrap=�6_   $	��Top=�6s   $	��131��6�   6�   �� 5s   
   -'   5        $ txt_s9��5s      $
��Left=�6"   $��23��6=   $��1462,200,0,0q�6I   $
 Wrap=�6_   $	��Top=�6s   $	��131��6�   6�   �� 5t   
   -(   5        $ txt_s11��5t      $
��Left=�6#   $��23��6>   $��1724,200,0,0q�6J   $
 Wrap=�6`   $	��Top=�6t   $	��131��6�   6�   �� 5u   
   -)   5        $ txt_s10��5u      $
��Left=�6#   $��23��6>   $��1593,200,0,0q�6J   $
 Wrap=�6`   $	��Top=�6t   $	��131��6�   6�   �� 5v   
   $
��Left=�6   $��23��6-   $��1855,200,0,0q�69   $
 Wrap=�6O   $	��Top=�6c   $��18��6{   �� 5w   
   -*   5        $ 	lbl_time1��5w      $�� ��6#   $
��Left=�6.   $��
10,984,0,0q�6I   $
��Left=�6]   $	��Top=�6   
�������$	��286��6�   �� 5x   
   -+   5        $ btn_rentals��5x      $��
   Wynajmy��6&   $
��Left=�6;   $��	38,54,0,0q�6V   $	��Top=�6i   $	��192��6�   $��80��6�   $��Center=�6�   ���	#FF9ABF7F$��18(�6�   
�������$��Verdana Pro SemiBold)�6�   6  �� 5y   
   -,   5        $ btn_customers��5y      $��
   Klienci��6(   $
��Left=�6=   $��
268,54,0,0q�6X   $	��Top=�6l   $	��192��6�   $��80��6�   $��Center=�6�   ���	#FFF0D264$��18(�6�   
�������$��Verdana Pro SemiBold)�6�   6  �� 5z   
   --   5        $ btn_cars��5z      $��      Samochody��6#   $
��Left=�6=   $��
500,54,0,0q�6X   $	��Top=�6l   $	��192��6�   $��80��6�   $��Center=�6�   ���	#FFCB99C5$��18(�6�   
�������$��Verdana Pro SemiBold)�6�   6  �� 5{   
   -.   5        $ btn_employees��5{      $��      Pracownicy��6(   $
��Left=�6C   $��1192,54,0,0q�6^   $	��Top=�6s   $	��192��6�   $��80��6�   $��Center=�6�   ���	#FF7FB1BF$��18(�6�   
�������$��Verdana Pro SemiBold)�6�   6!  �� 5|   
   $)��#/carRental;component/pic/emp/hb.png��6   $
��Left=�6=   $��40��6X   $��1205,74,0,0q�6d   $	��Top=�6y   $��38��6�   �� 5}   
   $&�� /carRental;component/pic/key.png��6   $
��Left=�6:   $��40��6U   $��	48,74,0,0q�6a   $	��Top=�6t   $��48��6�   �� 5~   
   $'��!/carRental;component/pic/team.png��6   $
��Left=�6;   $��40��6V   $��
276,74,0,0q�6b   $	��Top=�6v   $��48��6�   �� 5   
   $&�� /carRental;component/pic/car.png��6   $
��Left=�6:   $��40��6U   $��
508,74,0,0q�6a   $	��Top=�6u   $��48��6�   �� 5�   
   $
��Left=�6   $	��100��6/   $��
561,57,0,0q�6<   $	��Top=�6P   $	��109��6h   
�������6t   �� 5�   
   -/   5        $ btn_overview��5�      $#��     Polisy &
    Przęglądy��6'   $
��Left=�6U   $��
730,53,0,0q�6p   $	��Top=�6�   $	��192��6�   $��80��6�   $��Center=�6�   ���	#FFA69FC7$��18(�6�   
�������$��Verdana Pro SemiBold)�6  62  �� 5�   
   -0   5        $ btn_finance��5�      $��
   Faktury��6&   $
��Left=�6;   $��
962,53,0,0q�6V   $	��Top=�6j   $	��192��6�   $��80��6�   $��Center=�6�   ���	#FFBF7F7F$��18(�6�   
�������$��Verdana Pro SemiBold)�6�   6  �� 5�   
   $%��/carRental;component/pic/f1.png��6   $
��Left=�69   $��40��6T   $��
740,74,0,0q�6`   $	��Top=�6t   $��48��6�   �� 5�   
   $,��&/carRental;component/pic/inv/invib.png��6   $
��Left=�6@   $��40��6[   $��
974,74,0,0q�6g   $	��Top=�6{   $��48��6�   �� 5�   
   -1   5        $ btn_add_new_car��5�      $
��Left=�6*   $��1734,923,0,0q�6E   $	��Top=�6[   $��90��6s   $��90��6~   ���	#FF454553���	#FF454553$ dodaj nowy pojazd��6�   .��5�      �� $'��!/carRental;component/pic/addb.png��6   $
��Left=�6?   $��45��6Z   $	��Top=�6f   $��45��6~   5�      �� 5�   
   -2   5        $ btn_change_status��5�      $
��Left=�6,   $��1639,923,0,0q�6G   $	��Top=�6]   $��90��6u   $��90��6�   ���	#FF454553���	#FF454553$ zmień status pojazdu��6�   .��5�      �� $*��$/carRental;component/pic/changeb.png��6   $
��Left=�6B   $��45��6]   $	��Top=�6i   $��45��6�   5�      �� 5�   
   -3   5        $ btn_delete_car��5�      $
��Left=�6)   $��1829,923,0,0q�6D   $	��Top=�6Z   $��90��6r   $��90��6}   ���	#FF454553���	#FF454553$ dezaktywuj wybrany pojazd��6�   .��5�      �� $(��"/carRental;component/pic/signb.png��6   $
��Left=�6@   $��45��6[   $	��Top=�6g   $��45��6   5�      �� 5�   
   -4   5        $ 
btn_reload��5�      $
��Left=�6%   $��1864,59,0,0q�6@   $	��Top=�6U   $��50��6m   $��50��6�   $ 	odśwież��6�   ��6x   Z� ��6�   Z� .��5�      �� $*��$/carRental;component/pic/reload1.png��6   $
��Left=�6B   $��35��6]   $	��Top=�6i   $��35��6�   5�      �� 5�   
   -5   5        $ 
btn_logout��5�      $
��Left=�6%   $��
1864,4,0,0q�6@   $	��Top=�6T   $��50��6l   $��50��6�   $ wyloguj��6�   ��6w   Z� ��6�   Z� .��5�      �� $)��#/carRental;component/pic/logout.png��6   $
��Left=�6A   $��35��6\   $	��Top=�6h   $��35��6�   5�      �� 5�   
   $
��Left=�6   $	��100��6/   $��1774,30,0,0q�6<   $	��Top=�6Q   $	��150��6i   $
 0.5,0.5&�6u   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      $ 90.033Q�6&   T� 5�      5�      5�      5�      5�      