   M S B A M L   `   `   `  ����N  JAdvancedColorPicker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:AdvancedColorPicker.ViewModelsAdvancedColorPicker.ViewModels  5      /    )AdvancedColorPicker.Views.ColorPickerView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.3.1.917, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      =
viewModels,clr-namespace:AdvancedColorPicker.ViewModels  5      -   5          >�Name$
  Root��5	   7    � DataContext 5
      9   3AdvancedColorPicker.ViewModels.ColorPickerViewModel  5   
   -   5        	ViewModel��5   ?    � 	Resources 5       �� MergedDictionaries �� Source4   .AdvancedColorPicker.ViewModels.ThemesViewModel   ThemesViewModel�� 5   
    5      �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Slider.xaml?�6%   �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6%   %   &	          5      6C   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   �� 5      $
��Auto �6   .+�5   
   `� .�5      c� .@�5      �� $��Center=�6   ��6;   �� *OpenCommand+��6[   ��  �� ElementName$ Image��.��5      ��  �� Orientation$ 
Horizontal=�6!   .+�5       '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.1.917, Culture=neutral, PublicKeyToken=null]]   Kind$
 File=�62   $��Center=�6>   6[   �� 5!      $��10,0,0,0q�6$   $��Center=�66   Open6W   5"      5#      �� 5$      $��Center=�6   ��6;   �� *PasteCommand+��6\   �� $ Image��.��5%      �� $ 
Horizontal=�6!   .+�5&        $ ContentPaste=�62   $��Center=�6F   6c   �� 5'      $��10,0,0,0q�6$   $��Center=�66   Paste6X   5(      5)      �� 5*      -   5        $��Center=�5*   :   .��5+      �� $ 
Horizontal=�6!   .+�5,        $	 Tab=�62   $��Center=�6=   6Z   �� 5-      $��10,0,0,0q�6$   $��Center=�66   Take Screenshot6b   5.      5/      50      51      �� 52   
   $��1��6   $��Center=�6!   $��Center=�6<   $��20(�6Y   y�6g   �� *ImageNotOpened+   BooleanToVisibilityConverter	 �� 	Converter#	 [ No Image Opened6�   �� 53   
   -   5        
 ��Name$
 Border��53   2   $��1��6   }�. ._�54      �� -   5         ��Name$ Image��54      $��Uniform=�6#    J� RenderTransformOrigin$ 0.5,0.5&�6U   z�55      V� 56      .~�57      �� �� 58      �� 59      T� 5:      5;      5=      5>      �� 5?   
   $��2��6   .@�5@      �� $ 
Horizontal=�6   $
��10,3q�62   .+�5A      �� $��Center=�6   Zoom6=   �� 5B      $��Center=�6     MaterialDesignSlider#��[ 64   $	��200��6b   $��20,0,0,0q�6n    � Minimum$ 50Q�6�    � Maximum$
 1500Q�6�    � Value 6�   �� *Zoom+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5C      -   5        /  )MaterialDesignThemes.Wpf.ValidationAssist   UsePopup . $��Center=�5C   J   $��15,0,0,0q�6e   ��6w   �� *Zoom+ �� StringFormat$
 %{0}��6�   5D      �� 5E      6   �� 5F      $��24��6   $��24��6#   $
��10,0q�6/   ��5G      �� 5H       �� Color 6&   �� *Color+ �� Mode$ TwoWay=�6M   5J      �� 5K      -   5         � ToolTip$% Click to copy to the clipboard.��5K       ^� 	Placement$	 Top=�6A    �� 
IsReadOnly . $��0,0,10,0q�6�   ��6�   �� *Color+6�   �� 5L      -   5         ��Name$ FavoriteButton��5L   H     MaterialDesignFlatButton#���  6   {�6`   �� *ColorSelected+��6�   �� *AddToFavoritesCommand+��6�   �� *Color+.��6�   Mark as Favorite Color6�   �� 5M      $ 
Horizontal=�6   .+�5N      �� -	   5        $ AddToThemeButton��5N   �   #���  6   ��6L   �� *AddToThemesCommand+��6s   �� $ ThemesComboBox�� �� Path$ SelectedItem�{�6�   �� *ColorSelected+.��6�   Add To Theme:6
  �� 5O      -
   5         ��Name$ ThemesComboBox��5O      ��63   �� $
 Root��$' !Resources[ThemesViewModel].Themes�6�   5P      5Q      5R      5S      