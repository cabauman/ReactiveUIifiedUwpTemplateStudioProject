﻿using System;

using ReactiveUI;

using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace ReactiveUIifiedUwpTemplateStudioProject.ViewModels
{
    public class ShellNavigationItem : ReactiveObject
    {
        public string Label { get; }

        public Symbol Symbol { get; }

        public Func<IRoutableViewModel> ViewModelFactory { get; }

        public string ViewModelName { get; }

        private Visibility _selectedVisibility = Visibility.Collapsed;

        public Visibility SelectedVisibility
        {
            get { return _selectedVisibility; }
            set { this.RaiseAndSetIfChanged(ref _selectedVisibility, value); }
        }

        public char SymbolAsChar
        {
            get { return (char)Symbol; }
        }

        private readonly IconElement _iconElement = null;

        public IconElement Icon
        {
            get
            {
                var foregroundBinding = new Binding
                {
                    Source = this,
                    Path = new PropertyPath("SelectedForeground"),
                    Mode = BindingMode.OneWay,
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                };

                if (_iconElement != null)
                {
                    BindingOperations.SetBinding(_iconElement, IconElement.ForegroundProperty, foregroundBinding);

                    return _iconElement;
                }

                var fontIcon = new FontIcon { FontSize = 16, Glyph = SymbolAsChar.ToString() };

                BindingOperations.SetBinding(fontIcon, IconElement.ForegroundProperty, foregroundBinding);

                return fontIcon;
            }
        }

        private bool _isSelected;

        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref _isSelected, value);

                bool isFcu = ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 5);
                SelectedVisibility = isFcu && value ? Visibility.Visible : Visibility.Collapsed;

                SelectedForeground = IsSelected
                    ? Application.Current.Resources["SystemControlForegroundAccentBrush"] as SolidColorBrush
                    : GetStandardTextColorBrush();
            }
        }

        private SolidColorBrush _selectedForeground = null;

        public SolidColorBrush SelectedForeground
        {
            get { return _selectedForeground ?? (_selectedForeground = GetStandardTextColorBrush()); }
            set { this.RaiseAndSetIfChanged(ref _selectedForeground, value); }
        }

        public ShellNavigationItem(string label, Symbol symbol, Func<IRoutableViewModel> viewModelFactory)
            : this(label, viewModelFactory)
        {
            Symbol = symbol;
        }

        public ShellNavigationItem(string label, IconElement icon, Func<IRoutableViewModel> viewModelFactory)
            : this(label, viewModelFactory)
        {
            _iconElement = icon;
        }

        public ShellNavigationItem(string label, Func<IRoutableViewModel> viewModelFactory)
        {
            Label = label;
            ViewModelFactory = viewModelFactory;
            ViewModelName = viewModelFactory.GetType().FullName;
        }

        private SolidColorBrush GetStandardTextColorBrush()
        {
            var brush = Application.Current.Resources["ThemeControlForegroundBaseHighBrush"] as SolidColorBrush;

            return brush;
        }

        public override string ToString()
        {
            return Label;
        }
    }
}
