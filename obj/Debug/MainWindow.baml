   M S B A M L   `   `   `  ����M  ISystem, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089M3clr-namespace:System.ComponentModel;assembly=systemSystem.ComponentModel  5       WoW   WoW.MainWindow   5   	   :cm3clr-namespace:System.ComponentModel;assembly=system  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      $��328.8��6<   $	��440��6K     � 
ResizeMode$  CanMinimize=�6W   
������� � WindowStyle$ SingleBorderWindow=�6�   .��5      � $��
0,0,-0.2,0q�6   .+�5   
   �� -   5         ��Name$ ButtonWayOut��5      $��
путь 1��6'   $
��Left=�68   $��	23,74,0,0q�6S   $	��Top=�6f   $��51��6~   $��25��6�   �� 5   
   -   5        $ ButtonWayIn��5      $��
путь 2��6&   $
��Left=�67   $��
23,111,0,0q�6R   $	��Top=�6f   $��51��6~    J� RenderTransformOrigin$ -9.695,2.26&�6�   $��25��6�   �� 5   
   -   5        $ btnStart��5      $��выполнить��6#   $
��Left=�67   $��312,111,0,0q�6R   $��14(�6g   $	��Top=�6u   $	��112��6�   $��25��6�   {�.  6�   �� 5   
   -   5        $ btnRenameFile��5      $ ��переименовать��6(   $
��Left=�6@   $��
312,74,0,0q�6[   $��14(�6o   $	��Top=�6}   $	��112��6�   $��25��6�   {�.  6�   �� 5   
   -   5        $ btnInfoFile��5      $+��%получить информацию��6&   $
��Left=�6D   $��
10,182,0,0q�6_   $��12(�6s   $	��Top=�6�   $	��143��6�   $��20��6�   {�.  6�   �� 5   
   -   5         ��Name$ lName��5      $��Имя��6   $
��Left=�6-   $��
10,202,0,0q�6H   $	��Top=�6\   $	��409��6t   �� 5   
   -   5        $ lSize��5      $��Размер��6   $
��Left=�60   $��
10,233,0,0q�6K   $	��Top=�6_   $	��409��6w   �� 5   
   -   5        $ lCreateTime��5      $��Дата создания��6%   $
��Left=�6=   $��
10,264,0,0q�6X   $	��Top=�6l   $	��409��6�   �� 5   
   -	   5         ��Name$ cmbSelectedMode��5      $��Center=�6,   $��12(�6P   $
��Left=�6^   $��	74,11,0,0q�6y   $	��Top=�6�   $	��104��6�   $��25��6�   .@�5      �� $��
Файлы��6   $��12(�6$   �� 5      $��Директории��6   $��12(�6)   5      �� 5   
   -
   5         ��Name$ TextNewName��5       �� TextAlignment$ Right=�6'   $
��Left=�6=   $��25��6X   $��	92,74,0,0q�6d    �� TextWrapping$
 Wrap=�6w   $	��Top=�6�   $	��220��6�   $��14(�6�   �� 5   
   $��приоритет:��6   $
��Left=�6%   $��
234,10,0,0q�6@   $	��Top=�6T   �� 5   
   -   5        $ cmbPriorityThread1��5      $
��Left=�6/   $��
309,11,0,0q�6J   $	��Top=�6^   $	��110��6v   $��25��6�   .@�5       �� $��низкий��6   �� 5!      $��ниже среднего��6   �� 5"      $��средний��6   �� 5#      $��выше среднего��6   �� 5$      $��высокий��6   5%      �� 5&   
   $��задача:��6   $
��Left=�6"   $��	23,11,0,0q�6=   $	��Top=�6P   $��51��6h   �� 5'   
   -   5        $ cmbSelectedAction��5'      $��Center=�6.   $��12(�6R   $
��Left=�6`   $��
92,111,0,0q�6{   $	��Top=�6�   $	��220��6�   	 �� SelectedIndex$	 0��6�   $��25��6�   .@�5(      �� $��копировать��6   $��12(�6)   �� 5)      $��переместить��6   $��12(�6*   �� 5*      $��удалить��6   $��12(�6&   5+      �� 5,   
   -   5        
 ��Name$
 chWay1_selected��5,      $�� ��6,   $
��Left=�67   $��5,84,0,0q�6R   $	��Top=�6d   {�.  6|   �� 5-   
   -   5        $
 chWay2_selected��5-      $�� ��6,   $
��Left=�67   $��	5,111,0,0q�6R   $	��Top=�6e   $ 0.522,3.066&�6}   {�.  6�   5/      51      