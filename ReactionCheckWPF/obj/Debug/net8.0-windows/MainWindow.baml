   M S B A M L   `   `   `  ����K  GReactionCheckWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ReactionCheckWPFReactionCheckWPF  5   	   !    ReactionCheckWPF.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ReactionCheckWPF     5   	     � Title$  Log in��5   	   $	��450��6   $	��300��6%   $	��450��5	   	   $	��300��6   $	��450��5
   	   $	��300��6    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $��4* �6   �� 5      .+�5   
   � $��1��6   
������� � RowDefinitions 5      �� 5      $
��0.1* �6    �� 5      $
��0.2* �6    �� 5      $
��0.1* �6    �� 5      $
��0.2* �6    �� 5      $
��0.1* �6    �� 5      $
��0.2* �6    �� 5      $
��0.1* �6    �� 5      $
��0.2* �6    �� 5      $
��0.1* �6    �� 5      $
��0.2* �6    �� 5      $
��0.1* �6    �� 5       $
��0.2* �6    �� 5!      $
��0.1* �6    .+�5$      � $��1��6    5%      �� 5&      �� 5'      .+�5*      �� $��First Name:��6   $��Center=�5+      �� 5,      -   5         ��Name$ FirstNameInput��5.      $��1��5,       �� TextAlignment$ Center=�5-      5.      5/      � 51      $��3��6    52      �� 53      �� 54      .+�57      �� $��
Last Name:��6   $��Center=�58      �� 59      -   5        $ LastNameInput��5;      $��1��59      $ Center=�5:      5;      5<      � 5>      $��5��6    5?      �� 5@      �� 5A      .+�5D      �� $��Max buttons count:��6   $��Center=�5E      �� 5F      -   5         ��Name$ CountButtonBox��5G      $��1��5F      $��Center=�5H      .@�5I      �� .��6#   26&   �� 5J      .��6#   36&   �� 5K      .��6#   46&   �� 5L      .��6#   56&   5M      5N      � 5P      $��7��6    5Q      �� 5R      �� 5S      .+�5V      �� $)��#Button press interval (in seconds):��6   $��Center=�5W      �� 5X      -   5        $ PressIntervalInput��5Y      $��1��5X      $ Center=�5Z      5[      � 5]      $��9��6    5^      �� 5_      �� 5`      .+�5c      �� $$��Clicks number before level up:��6   $��Center=�5d      �� 5e      -   5        $ ClickBeforeLevelUpInput��5f      $��1��5e      $ Center=�5g      5h      � 5j      $��11��6    5k      �� 5l      �� 5m      �� 5n      .+�5q      �� -   5         ��Name$ GoButton��5s      $��1��5q      $	��Go!��5r      5t      5u      5v      5w      5x      