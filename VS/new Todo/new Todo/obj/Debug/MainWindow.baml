   M S B A M L   `   `   `  ����C  ?new Todo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:new_Todonew_Todo  5   	       new_Todo.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:new_Todo     5   	   -   5          �Name$  window��5   5   
������  � Language$ English�5   @    � 
ResizeMode$ CanResizeWithGrip=�5   F    � Icon$ ico.ico��5   .    � ShowActivated .   � WindowStyle$
 None=�5       � AllowsTransparency . $	��200��6G   $	��200��6W    � Title$ 
MainWindow��5   	   $	��300��6   $	��220��6)   .��5	      � -   5         �Name$ G��5	      	 � RowDefinitions	 5
   
   �� 5      $��22 �6   �� 5      .+�5   
   A� $��20��6   $��20��6   $
��Left=�6)   $	��Top=�6D   
�������6\   A� 5   
   $��20��6   $��20��6   $��Right=�6)   $	��Top=�6E   
�������6]   �� 5   
   -   5        
 ��Name$	
 top��5      $��20��6"   
�������$	��top=�6:   $	��225��6R   �� 5   
   -   5        $
 bottom��5      
�������$��0��60   $��2��6=   $��0 12 0 0q�6N   A� 5   
   -   5         A�Name$	 red��5      
���  ��$��15��6*   $��15��66   $
��Left=�6A   $��5 0 0 0q�6\   A� 5   
   -   5        $ yellow��5      
��� ���$��15��61   $��15��6=   $
��Left=�6H   $��25 0 0 0q�6c   A� 5   
   -   5        $ green��5      
��� � �$��15��6.   $��15��6:   $
��Left=�6E   $��45 0 0 0q�6`   �� 5   
   -   5         ��Name$ scroll��5   $   $��2��6   $
��Auto=�64   $
��Auto=�6W   .��5      � -	   5        $ grid1��5      $
��Auto=�6"   $
��Auto=�6R   ��.  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��30 �6#   �� 5      $��30 �6#   .+�5      �� -
   5         ��Name$ input��5       J� Opacity$	 0.8Q�5      $	��top=�6$   
�������
�������$��center=�5      $��2��68   $y�	collapsed=�6L   $��30��5   %   $��16(�62    K� ZIndex$	 100��6@   �� 5      -   5         ��Name$ 	configBtn��5   '   $	 0.8Q�6   $��30��6:   $	��top=�6F   $y�	collapsed=�6_   $
��Bold"�5       $��+��6'   $��20(�63   
�������
����  �$��0q�5!      $��2��6)   $	 100��69   5"      5#      5$       � TaskbarItemInfo 5%      *  $System.Windows.Shell.TaskbarItemInfo  5&   
   -   5        taskBar��   Overlay$ ico.ico��5'         ThumbButtonInfos 5)      *  $System.Windows.Shell.ThumbButtonInfo     ImageSource$ ico.ico��6"     5*      $ ico.ico��6#     5+      $ ico.ico��6"     5,      $ ico.ico��6#     5-      $ ico.ico��6#     5.      $ ico.ico��6#     5/      $ ico.ico��6$   51      53      