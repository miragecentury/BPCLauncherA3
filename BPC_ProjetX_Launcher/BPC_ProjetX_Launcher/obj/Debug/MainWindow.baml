   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=0.14.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    BPC_ProjetX_Launcher%   BPC_ProjetX_Launcher.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   -   5          � Title$@  :BPC - ProjetX Launcher - Version 0.0.1 - Revision XXXXXXXX��5   	   ���	#FF343434
�������(   "MahApps.Metro.Controls.MetroWindow   EnableDWMDropShadow .  � 
ResizeMode$ CanResizeWithGrip=�5   	      WindowTransitionsEnabled .   � WindowStartupLocation$ CenterScreen=�5   	   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $	��57* �6   �� 5      $	��32* �6   �� 5      $��30 �6   .+�5   
   o� $��0��6   $	��Top=�6   $��30��64   ���	#FF343434$��3��6W   .@�5      m� $��Authentification��6   $��30��61   ���	#FF343434
�������.@�5      m� -   5         m�Name$ MainWindow_Menu_Login��5      $��Login��6:   ���	#FF343434{�. 6q   m� 5      -   5        $ MainWindow_Menu_Logout��5      $��Logout��6;   ���	#FF343434{�.  6b   5      m� 5      -   5        $ MainWindow_Menu_Debug��5      $��Debug��66   $��30��6E   ���	#FF343434$��Right=�6h   {�.  .@�5      m� -   5        $# MainWindow_Menu_Debug_LiveLog��5      $��Live Log��6B   ���	#FF343434{�.  6k   m� 5      -   5        $% MainWindow_Menu_Debug_LiveEvent��5      $��
Live Event��6D   ���	#FF343434{�.  6o   5      m� 5      $��?��6   $��30��6"   ���	#FF343434
�������$��Right=�6X   .@�5       m� $��A Propos��6   ���	#FF343434{�. 6D   m� 5!      $��Version��6   ���	#FF343434{�. 6C   5"      5#      �� 5$   
   $	��Top=�6   $��1��6,   
�������$��1��6E   $��3��6R   �� 5%   
   $
��Left=�6   ���	#FF343434
�������$��3��6[   $��3��6h   $	��708��6|   .@�5&      �� -   5         ��Name$% MainWindow_Status_ServeurStatus��5&      
���  ��$��Serveur Status��6N   �� 5'      -   5        	 ��Name$)	 #MainWindow_Status_ServeurStatus_Rct��5'      $��0,4,0,0q�6E   
���  ��$��Center=�6a   $��20��6~   
���Gc��$��Center=�6�   $��20��6�   �� 5(      $��0,10,0,5q�6   �� 5)      -	   5        $/ )MainWindow_Status_ServeurConnectionStatus��5)      
���  ��$��Serveur Not Connected��6X   �� 5*      -
   5        $3	 -MainWindow_Status_ServeurConnectionStatus_Rct��5*      $��0,4,0,0q�6O   
���  ��$��Center=�6k   $��20��6�   
���Gc��$��Center=�6�   $��20��6�   �� 5+      $��0,10,0,5q�6   �� 5,      -   5        $/ )MainWindow_Status_ServeurAuthentification��5,      
���  ��$��Not Authentified��6X   �� 5-      -   5        $3	 -MainWindow_Status_ServeurAuthentification_Rct��5-      $��0,4,0,0q�6O   
���  ��$��Center=�6k   $��20��6�   
���Gc��$��Center=�6�   $��20��6�   �� 5.      $��0,10,0,5q�6   �� 5/      -   5        $! MainWindow_Status_ModsCheck��5/      
���  ��$��
Check Mods��6J   �� 50      -   5        $%	 MainWindow_Status_ModsCheck_Rct��50      $��0,4,0,0q�6A   
���  ��$��Center=�6]   $��20��6z   
���Gc��$��Center=�6�   $��20��6�   �� 51      $��0,10,0,5q�6   �� 52      -   5        $* $MainWindow_Status_GameLinkConnection��52      
���  ��$��Game Link Not Connected��6S   �� 53      -   5        $.	 (MainWindow_Status_GameLinkConnection_Rct��53      $��0,4,0,0q�6J   
���  ��$��Center=�6f   $��20��6�   
���Gc��$��Center=�6�   $��20��6�   �� 54      $��0,10,0,5q�6   �� 55      56      !   MahApps.Metro.Controls.Tile  57   
   -   5        
  Name$#
 MainWindow_Tile_LaunchProjetX��57         Title$2 ,Démarre Arma3 est vous connecte sur ProjetX��6?      
TiltFactor$ 2��6s   $��Lancer ProjetX��6�   $��1,1,1,1q�6�   $��1��6�   $
��Auto��6�   $
��Auto��6�   6�     58   
   -   5        $
 MainWindow_Tile_OpenSite��58      $ Ouvre le Site de ProjetX��6:   $ 2��6[   $��Site: projetx.nordri.fr��6j   $��1,1,1,1q�6�   $��2��6�   $
��Auto��6�   $
��Auto��6�   6�     59   
   -   5        $#
 MainWindow_Tile_LaunchVanilla��59      $( "Démarre Arma3 Vanilla (sans Mods)��6?   $ 2��6i   $��Lancer Arma3 Vanilla��6x   $��1,1,1,1q�6�   $��1��6�   $��1��6�   $��2��6�   $
��Auto��6�   $
��Auto��6�   6�     5:   
   -   5        $
 MainWindow_Tile_ModCheck��5:      $$ Vérification des Mods Projetx��6:   $ 2��6`   $��Check Mods ProjetX��6o   $��1,1,1,1q�6�   $��2��6�   $��1��6�   $
��Auto��6�   $
��Auto��6�   6�     5;   
   -   5        $#
 MainWindow_Tile_Arma3Settings��5;      $0 *Définir les Options de Lancement de Arma3��6?   $ 2��6q   $��Arma3 Settings��6�   $��1,1,1,1q�6�   $��2��6�   $��2��6�   $
��Auto��6�   $
��Auto��6�   6  5<      5=      