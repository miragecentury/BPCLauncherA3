   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=0.14.0.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    BPC_ProjetX_Launcher+   %BPC_ProjetX_Launcher.BPC.Common.Login   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	     � Title$  Login��5   	   $	��305��6   $	��288��6$    � WindowStartupLocation$ CenterScreen=�60    � 
ResizeMode$ NoResize=�6U    � WindowStyle$ 
ToolWindow=�6k    � Topmost . (   "MahApps.Metro.Controls.MetroWindow   EnableDWMDropShadow .    ShowCloseButton .  .��5      � $��0,0,0,0q�6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5	      $��2* �6   �� 5
      $��1* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��1* �6   �� 5      $��3* �6   �� 5      $��3* �6   .+�5   
   �� $"��Veuillez entrer votre email ��6   $��0��67   $��1��6D   $��Center=�6U   $��Center=�6y   �� 5   
   $,��&et votre password de votre compte BPC.��6   $��1��6A   $��1��6N   $��Center=�6_   $��Center=�6�   �� 5   
   -   5         ��Name$ Login_TextBox_Email��5      $��30��6/   $��5,0,5,0q�6;   	 �� TextWrapping$
	 Wrap=�6L   *   $MahApps.Metro.Controls.TextboxHelper
   	Watermark$
 Email��6`   $�� ��6�   $��3��6�   $��1��6�   G� 5   
   -   5         G�Name$  Login_PasswordBox_Password��5      $��30��6;   $��5,0,5,0q�6G   $
 Password��6X   $��4��6�   �� 5   
   -   5         ��Name$# Login_Button_Authentification��5      $��Authentification��68   $��	10,6,10,0q�6S   $	��Top=�6f   $��6��6~   6�   �� 5   
   -   5        $ Login_Button_Annuler��5      $��Annuler��6/   $��
10,11,10,0q�6A   $	��Top=�6U   $��7��6m   6z   5      5      