   M S B A M L   `   `   `  ����K  G04.08_System_ex2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:System_ex2
System_ex2  5   	       System_ex2.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:System_ex2     5   	     � Title$  Process Manager��5   	   $	��400��6!   $	��600��6.   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Process to launch:��6   $��0,0,0,5q�6.   �� 5   
   -   5         ��Name$ ProcessPathTextBox��5      $��1��6.   $��0,0,0,10q�6;   $��notepad.exe��5      �� 5   
   $��Arguments (optional):��6   $��2��61   $��0,0,0,5q�6>   �� 5   
   -   5        $ ArgumentsTextBox��5      $��3��6,   $��0,0,0,10q�69   �� 5   
   $��4��6    �� Orientation$ 
Horizontal=�6"   $	��Top=�6;   .+�5      �� -   5         ��Name$ LaunchAndWaitButton��5      $��Launch and Wait��62   $��30��5      $	��120��6!   $��0,0,10,0q�6-   5      �� 5      -   5        $ LaunchButton��5      $��Launch��6+   $��30��5      $	��120��6!   $��0,0,10,0q�6-   5       �� 5!      -   5        $ KillProcessButton��5!      $��Kill Process��60   $��30��5"      $	��120��6!   ${�False��5#   5   5$      �� 5&   
   $��5��6   $��Bottom=�6"   .+�5'      �� -   5         ��Name$ StatusTextBlock��5'      $��0,10,0,0q�61   $
��Wrap=�5(      �� 5)      -   5        $ ExitCodeTextBlock��5)      $��0,10,0,0q�63   $
��Bold"�5*      $
��Wrap=�6*   �� 5+      -   5         ��Name$ WaitForExitCheckBox��5+      $��Wait for exit��64   $��0,10,0,0q�6L   5,      5-      5.      