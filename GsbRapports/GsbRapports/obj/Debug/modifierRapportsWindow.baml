   M S B A M L   `   `   `  ����F  BGsbRapports, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:GsbRapportsGsbRapports  5   	   (    "GsbRapports.modifierRapportsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:GsbRapports     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ modifierRapportsWindow��5	   	   $	��450��6(   $	��800��65   ���	#FFF0F0F0.��5
      �  � ColumnDefinitions 5   
   �� 5      $
��344* �6   �� 5      $	��53* �6   .+�5   
   �� $��Source Sans Pro Semibold)�6   $��628,0,-0.4,380q�6;   $��2��6S   �� 6h   ���	#FF1A69A0$��32(�6�   $�MODIFIER��6�   6�   �� 5   
   $��254,55,-19.4,-31q�6   	 �� X1$ 10��5      	 �� Y1$	 300��6   	 �� X2$ 10��5      	 �� Y2$ 50��6   ���	#FF1A69A0$	��0.5��5      $��2��6   �� 5   
   $��2��6   $��
0,0,-0.4,0q�6)   .+�5      � $��0,0,0,0q�6   .+�5      �� $��	Visiteurs��6   $��54��6-   $��29,40,710.6,348q�68   $
��Bold"�6Q   �� 5      -   5         ��Name$ cmbVisiteur��5      $��88,35,607.6,362q�60   6I   �� 5      $
��Date��6   $��221,40,535.6,348.2q�6(   $
��Bold"�6D   �� 5      -   5        $ cmbDate��5      $��258,35,437.6,362q�6,    J� RenderTransformOrigin$ 	0.502,0.5&�5   5   ��6   �� *date+65   �� 5      -   5        	 ��Name$	 btnChercher��5      $��Chercher��6.   $��59��6A   $��0,35,352.6,362.2q�6L   $��Right=�6f   $��Center=�6�   $��22��6�   6�   5      5      �� 5    
   $
��Bold"�6   $��26,121,507,274q�6&   ���	#FF1A69A0�� 6V   $� S��6Z   �� 6f   $�é��6j   �� 6u   $�lectionner ��6y   �� 6�   $	�un ��6�   �� 6�   $�	Rapport :��6�   6�   &   System.Windows.Controls.DataGrid  5!   
   -   5        
  Name$	
 dtg��5!         AutoGenerateColumns .  $��10,146,492,81q�6<      AlternatingRowBackground
 ��ح�$��0q�6{   
�������   Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Médecins��6%      
Foreground
 �   �1  +System.Windows.Controls.DataGridBoundColumn   Binding 5%   %   �� *concatMedecin+6H   5'      �� 5)   
   $��2��6   $��
0,0,-0.4,0q�6)   .+�5*      � $��
0,0,-0.4,0q�6   .+�5+      �� $��MOTIF��6   $��54��6)   $��282,150,458,246.8q�64   $
��Bold"�6O   �� 5,      -   5         ��Name$ txtMotif��5,       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6A   $��282,155,80,165q�6U   $��70��6m   
���   � � DataContext 5-      �� *SelectedItem+ �� ElementName$	 dtg����6N   �� *motif+6h   �� 5.      $��BILAN��6   $��282,249,456,147.8q�6)   $ 0.511,2.263&�6D   $
��Bold"�6h   �� 5/      -   5        $ txtBilan��5/       . $
 Wrap=�6B   $��282,258,80,71q�6V   $��70��6m   
���   � 50      �� *SelectedItem+$	 dtg����6O   �� *bilan+6i   51      52      �� 54   
   $��2��6   $��
0,0,-0.4,0q�6)   .+�55      �� -   5        $	 
btnValider��55      $��Modifier��6)   $��65��6<   $��0,357,77.6,42q�6G   $��Right=�6^   $��Center=�6z   $��28��6�   6�   56      57      58      