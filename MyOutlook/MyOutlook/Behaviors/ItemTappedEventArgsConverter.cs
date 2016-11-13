// ***********************************************************************
// FileName:ItemTappedEventArgsConverter
// Description:
// Project:
// Author:NewBLife
// Created:2016/11/13 17:32:41
// Copyright (c) 2016 NewBLife,All rights reserved.
// ***********************************************************************
using System;
using System.Globalization;
using Xamarin.Forms;

namespace MyOutlook.Behaviors
{
    /// <summary>
    /// Converts a ItemTappedEventArgs event to its Item.
    /// Generally, the Item is the BindingContext of the tapped item.
    /// </summary>
    public class ItemTappedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var eventArgs = value as ItemTappedEventArgs;
            if (eventArgs == null)
                throw new ArgumentException("Expected TappedEventArgs as value", "value");

            return eventArgs.Item;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
