   M S B A M L   `   `   `  ����L  HBot_Administrator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Bot_AdministratorBot_Administrator  5   	   "    Bot_Administrator.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Bot_Administrator     5   	     � Title$  Admin��5   	   $	��350��6   $	��525��6$   
�������.��5	      � .+�5
   
   �� -   5         ��Name$ 
SaveButton��5
      $
��Save��6%   $
��Left=�64   $��423,230,0,0q�6O   $	��Top=�6d   $��75��6|   6�   o� 5   
   -   5         o�Name$
 menu��5      $
��Left=�6   $��24��68   $	��Top=�6D   $	��517��6\   $��0,-5,0,0q�6h   .@�5      m� $��Teachers��6   .@�5      m� $	��Add��6   $
��Left=�6(   $	��145��6C   m� 5      $
��Edit��6   $
��Left=�6)   $	��145��6D   m� 5      -   5        $��Delete��5      $
��Left=�6+   $	��145��6F   6R   5      m� 5      $��Events��6   .@�5      m� $	��Add��6   $
��Left=�6(   $	��145��6C   m� 5      $
��Edit��6   $
��Left=�6)   $	��145��6D   m� 5      $��Delete��6   $
��Left=�6+   $	��145��6F   5      m� 5      $��Show log��6   5      �� 5   
   -   5         ��Name$ 
AddTCanvas��5      $��40,40,240,101q�6%   .+�5      �� -   5         ��Name$ 	DepartBox��5      $
��Left=�6*   $	��Top=�6E   $	��120��6]    �� Left$	 117��6i   
 �� Top$ 84��6{   �� 5      -   5         ��Name$ NameBox��5      $
��Left=�6'   $��23��6B    �� TextWrapping$
 Wrap=�6N   $	��Top=�6b   $	��120��6z   $	 117��6�   �� 5      -   5        $ 	FatherBox��5      $
��Left=�6)   $��23��6D   $
 Wrap=�6P   $	��Top=�6d   $	��120��6|   $	 117��6�   $ 56��6�   �� 5      -   5        $ PositionBox��5      $
��Left=�6+   $��23��6F   $
 Wrap=�6R   $	��Top=�6f   $	��120��6~   $	 117��6�   $	 111��6�   �� 5      -	   5        $ PhotoButton��5      $��	Add photo��6*   $
��Left=�6>   $	��Top=�6Y   $	��120��6q   $	 117��6�   $	 157��6�   �� 5      -
   5        	 ��Name$	 NameLab��5      $��Name :��6%   $
��Left=�66   $	��Top=�6Q   $	��101��6i   $��23��6u   �� 5      -   5        $ DeleteTCanvas��5      $��84��6,   $ 28��68   $	��237��6H   .+�5       �� -   5        $ 
SurnameBox��5       $
��Left=�6.   $��23��6I   $
 Wrap=�6U   $	��Top=�6i   $	��120��6�   $	 117��6�   �� 5!      -   5        $	 
SurnameLab��5!      $��	Surname :��6,   $
��Left=�6@   $	��Top=�6[   $	��101��6s   $��23��6   �� 5"      -   5        $	 	FatherLab��5"      $��Father's name :��6+   $
��Left=�6E   $	��Top=�6`   $	��101��6x   $��23��6�   $ 28��6�   �� 5#      -   5        $	 	DepartLab��5#      $��Department :��6+   $
��Left=�6B   $	��Top=�6]   $	��101��6u   $��28��6�   $ 56��6�   5$      �� 5%      -   5        $	 PositionLab��5%      $��
Position :��6)   $
��Left=�6>   $	��Top=�6Y   $	��101��6q   $��23��6}   $	 112��6�   �� 5&      -   5        $ PositionBox_Copy��5&      $
��Left=�60   $��23��6K   $
 Wrap=�6W   $	��Top=�6k   $	��120��6�   $	 117��6�   $	 112��6�   5(      �� 5)   
   -   5        $ BiographyBox��5)      $
��Left=�6(   $	��183��6C   $��
387,24,0,0q�6P   $
 Wrap=�6d   $��Short biography��6x   $	��Top=�6�   $	��120��6�   
 �� 	UndoLimit$	
 500��6�   6�   5+      5,      