   M S B A M L   `   `   `  ����F  BGsbRapports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GsbRapportsGsbRapports  5   	   '    !GsbRapports.filtrerRapportsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:GsbRapports     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ filtrerRapportsWindow��5	   	   $	��450��6'   $	��800��64   ���	#FFF0F0F0.��5
      � .+�5   
   �� $��249,-27,522.6,263q�6   	 �� X1$ 10��5      	 �� Y1$	 300��6   	 �� X2$ 10��5      	 �� Y2$ 50��6   ���	#FF1A69A0$	��0.5��5      �� 5   
   $
��Bold"�6   $��276,38,326.6,361q�6&   ���	#FF6EA7CE�� 6Y   $"�Selectionner entre deux date��6]   �� 6�   $� :��6�   6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $��276,59,30.6,319q�6.   .+�5      �� $��76��6   $
��Bold"�6#   $��	0,0,0,0.6q�65   �� 6I   $�Date ��6M   �� 6\   $�d��6`   �� 6k   $�é��6o   �� 6z   $	�but��6~   �� 6�   $� :��6�   6�   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 	dateDebut��5      $��
0,0,0,-0.2q�6-   ��6A   Z� �� 5      $��60��6   $
��Bold"�6#   $��50,0,0,-1.6q�65   �� 6K   $	�Dat��6O   �� 6\   $�e fin :��6`   6r     5      -   5        $ dateFin��5      $��
0,0,0,-0.2q�6+   ��6?   Z� 5      �� 5   
   $ 
Horizontal=�6   $��16,59,536.6,331q�6.   .+�5      �� $��	Visiteurs��6   $��97��6)   $
��Bold"�64   �� 5      -   5         ��Name$ cmbVisiteur��5      $��50,0,0,-0.4q�6,   $��83��6A   $��22��5      $	��Top=�6#   5      5      �� 5   
   $ 
Horizontal=�6   $��16,101,536.6,277q�6.   .+�5       �� $��	Médecin ��6   $��70��6(   $
��Bold"�63   $��
0,0,0,-0.4q�6E   �� 5!      -   5        	 ��Name$	 
txtMedecin��5!      $��10,0,0,0q�6*   $��47��6<   $	��Top=�6b   $��22��6z   �� 5"      -   5        $ 
cmbMedecin��5"      $��20,0,0,-0.4q�6+   $��83��6@   $	��Top=�6K   6c   5#      �� 5$   
   $��Source Sans Pro Semibold)�6   $��628,0,-0.4,380q�6;   �� 6T   ���	#FF1A69A0$��32(�6o   $�FILTRER��6}   6�   &   System.Windows.Controls.DataGrid  5%   
   -   5        
  Name$	
 dtg��5%         AutoGenerateColumns .  $��10,202,9.6,50q�6<      AlternatingRowBackground
 ��ح�$��0q�6{   
�������   Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6%      
Foreground
 �   �1  +System.Windows.Controls.DataGridBoundColumn   Binding 5(      �� *	idRapport+63     5)      $
 Date��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 64   
 �   � 5*      �� *date+6.     5+      $ Visiteur��6%   $	 120 68   
 �   � 5,      �� *concatVisiteur+68     5-      $ Medecin��6%   $	 120 67   
 �   � 5.      �� *concatMedecin+67     5/      $ Motif��6%   $	 200 65   
 �   � 50      �� *motif+6/     51      $ Bilan��6%   $	 205 65   
 �   � 52      �� *bilan+6/   54      � 55   
   $��737,56,3.6,319q�6   .+�56      �� -   5         ��Name$ 
btnValider��56      $��OK��6)   $��28��66   $��Right=�6A   $��Center=�6]   $��21��57      $
��Bold"�6<   $��0,0,0,9q�6N   59      � 5:   
   $��693,375,9.6,2q�6   .+�5;      �� -   5        $ btnSeria��5;      $��
Serializer��6'   $��80��6<   $��Right=�6G   $��Center=�6c   $��28��6~   $
��Bold"�6�   6�   5<      5?      5@      