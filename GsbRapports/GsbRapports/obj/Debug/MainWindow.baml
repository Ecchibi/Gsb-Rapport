   M S B A M L   `   `   `  ����F  BGsbRapports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GsbRapportsGsbRapports  5   	       GsbRapports.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:GsbRapports     5   	     � Title$)  #GSB gestion des rapports de visites��5   	   $	��450��65   $	��800��6B    � Icon$ gsb.jpg��6N   $��Center=�6]    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   ]� .+�5      o� -   5         o�Name$ DckMenu��5   (   $	��Top=�6   .@�5      m� $��_Fichier��6   .@�5      m� $��_Quitter��6   5      m� 5      $��
_Médecins��6   m� 5      $��_Visites��6   m� 5      $��_médicaments��6   m� 5      $��
_visiteurs��6   m� 5      $��	_Familles��6   .@�5      m� -   5        $��_Voir��5      6.   m� 5      -   5        $��	_Modifier��5      62   m� 5      -   5        $��_Ajouter��5      61   5      m� 5      $��	_Rapports��6   .@�5      m� -   5        $��_Ajouter��5      61   m� 5      -   5        $��	_Modifier��5      62   m� 5      -   5        $��_Filtrer��5      $��
2,0,-2.4,0q�6J   5      5      5"      �� 5#   
   -   5         ��Name$ imgLogo��5#   %   $��	logo2.png��6   $��267,28,284.6,235q�66   �� 5$   
   -	   5         ��Name$ txtConnexion��5$      $
��Bold"�6*   $��225,19,266.6,325q�6<   ���	#FF629FCF$��48(�6m   $��Segoe UI Light)�6{   �� 6�   $
�    ��6�   �� 6�   $�	Connexion��6�   6�   �� 5%   
   -
   5         ��Name$ 
txtBonjour��5%      $	��148��6'   $��25��63   $��317,185,0,0q�6?   $
��Left=�6T   $	��Top=�6o   ���	#FFADE693���	#FF267790$��Yu Gothic UI Semibold)�6�   $��Center=�6�   ��6�   Z� 6�   �� 5&   
    �� Orientation$ 
Horizontal=�6   $��	0,100,0,0q�60   .+�5'      �� -   5         ��Name$ stPanel��5'   1   $��250,52,110,132q�6   $	��302��6B   .+�5(      �� $ 
Horizontal=�6   .+�5)      �� $��20,0,0,0q�6    $��15(�62   $��62��6@   ���	#FF629FCF$��Segoe UI Light)�6b   �� 6   $�Login��6�   �� 6�   ���	#FFFF1818$�*��6�   �� 6�   $� :��6�   6�   �� 5*      -   5        $ txtLogin��5*      $��90��61   $��60,0,0,0q�6<   $��20��6N   	 � IsSharedSizeScope	 . 6Z   5+      �� 5,      $ 
Horizontal=�6   $��49��66   $��
0,20,0.4,0q�6B   .+�5-      �� $��15(�6    ���	#FF629FCF$��Segoe UI Light)�6E   $	��142��6a   $��
0,0,0,-0.2q�6m   �� 6�   $�Mot de passe��6�   �� 6�   ���	#FFFF1818$�*��6�   �� 6�   $� ��6�   �� 6�   $�:��6�   6�   G� 5.      -   5        
 G�Name$
 txtMdp��5.   "   $��90��63    J� RenderTransformOrigin$ 
0.332,1.58&�6>   $��
0,0,0,27.8q�6a   5/      �� 50      $ 
Horizontal=�6   $��35��66   $��	0,0,0.4,0q�6B   .+�51      �� -   5         ��Name$ 
btnValider��51      $��73��61   $��Valider��6<   $��26��6g   $��Bottom=�6s   
����������	#FF1A69A0���	#FF1A69A0$��100,0,0,0.2q�53      $��Center=�62   54      56      58      5:      5;      