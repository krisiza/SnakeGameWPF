   M S B A M L   `   `   `  ����C  ?SnakeWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:SnakeWPFSnakeWPF  5   	       SnakeWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:SnakeWPF     5   	     � Title$  Snake��5   	   $	��600��6   $	��800��6$   .��5	      �� -   5         ��Name$ myCanvas��5	      |�. ��5
   
   �� 5       �� ImageSource$� {C:\Users\kristiyana.za\source\repos\SnakeWPF\SnakeWPF\Snake\nahtloses-strukturiertes-gras-naturrasenmuster_172107-1308.webp��6   .+�5   
   �� -   5         ��Name$ 
SnakeScore��5       �� Left$ 10��6)   $
��Wrap=�6:   $��Your Score:��6N   
 �� Top$ 10��6a    J� RenderTransformOrigin$ 0.418,1.055&�6q   $
��Bold"�6�   $��14(�6�   $
��Left=�6�   $��Center=�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      � 	 � Color$	 	#FF486809��6#   
 � Offset$
 1Q�65   � 5      $	 	#FF0828FC��6#   $
 0.005Q�65   5      5      �� 5   
   -   5        $ MonsterScore��5      $	 630��6+   $
��Wrap=�6=   $��Monster Score:��6Q   $ 10��6g   $ 0.418,1.055&�6w   $
��Bold"�6�   $��14(�6�   $��Center=�6�   $��Center=�6�   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $	 	#FF486809��6#   $
 1Q�65   � 5      $	 	#FFBB3713��6#   $
 0.005Q�65   � 5      $	 	#FF761C4D��6#   $
 0.958Q�65   5      5      �� 5   
   -   5        $ _monsterScore��5      $	 734��6+   $
��Wrap=�6=   $ 10��6Q   $
��Left=�6a   $��14(�6|   $
��Bold"�6�   $ 0.435,0.034&�6�   $	��Top=�6�   $��17��6�   ��5      �� 5       $ 0.5,1&�6&   $ 0.5,0&�67   .��5!      � $	 	#FF5B0C0C��6#   � 5"      $	 White��6#   $
 1Q�61   � 5#      $	 	#FF8D124C��6#   $
 0.972Q�65   5$      5&      �� 5'   
   -   5        $ _snakeScore��5'      $ 89��6)   $
��Wrap=�6:   $ 7��6N   $
��Bold"�6]   $��16(�6o   $ 0.036,0.867&�6}   $
��Left=�6�   $��Center=�6�   $��20��6�   ��5(      �� 5)      $ 0.5,1&�6&   $ 0.5,0&�67   .��5*      � $	 Black��6#   � 5+      $	 	#FF173ED4��6#   $
 1Q�65   5,      5.      5/      51      