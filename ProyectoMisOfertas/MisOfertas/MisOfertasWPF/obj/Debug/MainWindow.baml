   M S B A M L   `   `   `  ����H  DMisOfertasWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MisOfertasWPFMisOfertasWPF  5   	       MisOfertasWPF.MainWindow   5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:MisOfertasWPF     5   	     � Title$  
MainWindow��5	   	   $	��800��6   $
��1280��6)    � AllowsTransparency . (  "MahApps.Metro.Controls.MetroWindow*   #WindowButtonCommandsOverlayBehavior$ Never=�6P    � 
ResizeMode$ NoResize=�6|      ResizeBorderThickness$ 0q�6�    � WindowStartupLocation$ CenterScreen=�6�   
������  � WindowStyle$
 None=�6�      ShowDialogsOverTitleBar .     ShowIconOnTitleBar .  	   ShowTitleBar	 .  
   NonActiveBorderBrush
 5
      �� 5   
   ��5      �� 5   
   .��5      � .+�5   
   �� ���	#FFFFE9D6 �� CornerRadius$ 30��6(   �� 5   
      BarraSuperior#���   6   �� 5   
   $��10,10,1008,577q�6   $(��"Imagenes/logo-removebg-preview.png��6)   ,  &MahApps.Metro.Controls.MetroTabControl  5   
   -   5        $��TCPrincipal��5      
������ /  )MahApps.Metro.Controls.ScrollViewerHelper%   IsHorizontalScrollWheelEnabled . .@�5      )  #MahApps.Metro.Controls.MetroTabItem  $��• Productos��6   $��288,85,-288,-84q�64   .��5      � .+�5      �� ���	#FFBD6F29 J� Opacity$	 0.4Q�64   $��40,184,40,20q�6B   $ 30��6X   �� 5      -   5         ��Name$ lboxProductos��5      
������ $��50,193,50,29q�6N   $��Disabled=�6d     ProductoTemplate#���  6�     ProductoItemContainerStyle#��[ 6�   ��5      �� 5      .R�5    "   �  � Orientation$ 
Horizontal=�6,   5!      5#      �� 5$      ���	#FFBD6F29$��249,100,40,591q�64   $	 0.7Q�6L   $ 10��6Z   ._�5%      �  � ColumnDefinitions 5&      �� 5'   "   $
��267* �63   �� 5(   "   $
��724* �63   .+�5*      �� -   5         ��Name$ 	btn_todos��5*   %   $��50,10,42,10q�68   $��Todos��6M     BotonFiltro#���  6]   6�   �� 5+      -   5        $ btn_alimentos��5+   %   $��230,10,586,10q�6<   $��	Alimentos��6S   #���  6g   $��2��6�   �� 5,      -   5        $ btn_electronica��5,   %   $��143,10,406,10q�6>   $��Electronica��6U   #���  6k   $��1��6�   �� 5-      -   5        $ 
btn_blanca��5-   %   $��323,10,226,10q�69   $��Linea Blanca��6P   #���  6g   $��1��6�   �� 5.      -   5        $ btn_ropa��5.   %   $��503,10,46,10q�67   $
��Ropa��6M   #���  6\   $��1��6�   50      51      52      54        55      $��• Ofertas��6   $��312,85,-312,-86q�62   .��56      � .+�57      �� ���	#FFBD6F29$	 0.4Q�64   $��40,184,40,20q�6B   $ 30��6X   �� 58      -   5        $ lboxOfertas��58      
������ $��50,193,50,29q�6L   $��Disabled=�6b     OfertaTemplate#���  6�     OfertaItemContainerStyle#��[ 6�   ��59      �� 5:      .R�5;   "   � $ 
Horizontal=�6,   5<      5>      �� 5?      ���	#FFBD6F29$��249,100,40,591q�64   $	 0.7Q�6L   $ 10��6Z   ._�5@      �  5A      �� 5B   "   $
��267* �63   �� 5C   "   $
��724* �63   .+�5E      �� -	   5        $ btn_todosOfer��5E   %   $��50,10,42,10q�6<   $��Todos��6Q   #���  6a   6�   �� 5F      -
   5        $ btn_alimentosOfer��5F   %   $��230,10,586,10q�6@   $��	Alimentos��6W   #���  6k   $��2��6�   6�   �� 5G      -   5        $ btn_electronicaOfer��5G   %   $��143,10,406,10q�6B   $��Electronica��6Y   #���  6o   $��1��6�   6�   �� 5H      -   5        $ btn_blancaOfer��5H   %   $��323,10,226,10q�6=   $��Linea Blanca��6T   #���  6k   $��1��6�   6�   �� 5I      -   5        $ btn_ropaOfer��5I   %   $��503,10,46,10q�6;   $
��Ropa��6Q   #���  6`   $��1��6�   6�   5K      5L      5M      5O      5Q      �� 5S   
   -   5        $ Btn_iniciarS��5S      
�������$��30(�6:     BotonSinFondo#���  6H   $��1123,83,0,686q�6p   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��31��6�   $��Center=�6  $	��157��6,  .��5T      �� $��31��6    �� Orientation$ 
Horizontal=�6%   $	��188��6>   .+�5U      �� $!��Imagenes/Login Door2-WF.png��6   $��Center=�6=   $	��Top=�6Z   $��38��6r   �� 5V      $��Iniciar Sesiòn��6   $��20(�62   
�������$	��116��6S   5W      5X      �� 5Y   
   -   5        $��20��5Y      $��20��6     BotonMinimal#���  6)   $��14(�6P   $��X��6^   $��1240,10,20,770q�6j   $��Center=�6�   $��Center=�6�   ���	#FF3C3C3C6�   5`      5b      