   M S B A M L   `   `   `  ����H  DWpfAppEditeur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfAppEditeurWpfAppEditeur  5   	   #    WpfAppEditeur.WinGestionnaire   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfAppEditeur     5   	     � Title$#  Paramètes d'accès à la Bdd��5   	   $	��450��6,   $	��800��69   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��297* �6   �� 5      $
��107* �6   �� 5      $
��388* �6   .+�5   
   �� -   5         ��Name$ lblUser��5      $��Utilisateur:��6!   $��67,160,74,0q�68   $	��Top=�6M   $��37��6e   $
��Bold"�6q   $��14(�6�   ���	#FFCAEAE1 J� RenderTransformOrigin$ 
0.61,5.063&�6�   �� 5   
   -   5        $ lblMdp��5      $��Mot de passe:��6    $��67,232,74,0q�68   $	��Top=�6M   $��37��6e   $
��Bold"�6q   $��14(�6�   ���	#FFCAEAE16�   �� 5   
   -   5         ��Name$ txtUser��5      $��37��6#   $��6,166,222,0q�6/    �� TextWrapping$
 Wrap=�6D   $��TextBox��6X   $	��Top=�6g   ���	#FFA5C9BF$��2��6�   �� 5   
   -   5        $ txtMdp��5      $��37��6"   $��6,232,222,0q�6.   $
 Wrap=�6C   $��TextBox��6W   $	��Top=�6f   ���	#FFA5C9BF$��2��6�   �� 5   
   -   5         ��Name$ btnEnregistrer��5      $��Enregistrer��6)   $��193,337,54,0q�6?   $	��Top=�6U   $��35��6m   $
��Bold"�6y   $��14(�6�   $��2��6�   6�   �� 5   
   -   5        $ 
btnAnnuler��5      $��Annuler��6&   $��73,337,166,0q�68   $	��Top=�6N   $��35��6f   $��2��6r   $��14(�6�   $
��Bold"�6�   6�   5      5      