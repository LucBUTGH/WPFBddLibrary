   M S B A M L   `   `   `  ����H  DWpfAppEditeur, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfAppEditeurWpfAppEditeur  5   	       WpfAppEditeur.NewBook   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:WpfAppEditeur     5   	     � Title$  Ajouter un livre��5   	   $	��450��6"   $	��800��6/   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��297* �6   �� 5      $
��107* �6   �� 5      $
��388* �6   .+�5   
   �� -   5         ��Name$ lblISBN��5      $��ISBN:��6!   $��
71,99,70,0q�61   $	��Top=�6E   $��37��6]   $
��Bold"�6i   $��14(�6{   ���	#FFCAEAE1 J� RenderTransformOrigin$ 
0.61,5.063&�6�   �� 5   
   -   5        $ lblName��5      $��Nom du livre:��6!   $��70,166,70,0q�69   $	��Top=�6N   $��37��6f   $
��Bold"�6r   $��14(�6�   ���	#FFCAEAE1$ 
0.61,5.063&�6�   �� 5   
   -   5        $ lblDate��5      $��Date :��6!   $��67,232,74,0q�62   $	��Top=�6G   $��37��6_   $
��Bold"�6k   $��14(�6}   ���	#FFCAEAE16�   �� 5   
   -   5         ��Name$ txtISBN��5      $��37��6#   $��6,166,222,0q�6/    �� TextWrapping$
 Wrap=�6D   $��TextBox��6X   $	��Top=�6g   ���	#FFA5C9BF$��2��6�   �� 5   
   -   5        $ txtName��5      $��37��6#   $��
6,99,222,0q�6/   $
 Wrap=�6C   $��TextBox��6W   $	��Top=�6f   ���	#FFA5C9BF$��2��6�   �� 5   
   -   5        $ txtDate��5      $��37��6#   $��6,232,222,0q�6/   $
 Wrap=�6D   $��TextBox��6X   $	��Top=�6g   ���	#FFA5C9BF$��2��6�   �� 5   
   -   5         ��Name$ btnEnregistrer��5      $��Enregistrer��6)   $��193,337,54,0q�6?   $	��Top=�6U   $��35��6m   $
��Bold"�6y   $��14(�6�   $��2��6�   6�   �� 5   
   -   5        $ 
btnAnnuler��5      $��Annuler��6&   $��73,337,166,0q�68   $	��Top=�6N   $��35��6f   $��2��6r   $��14(�6�   $
��Bold"�6�   6�   5      5      