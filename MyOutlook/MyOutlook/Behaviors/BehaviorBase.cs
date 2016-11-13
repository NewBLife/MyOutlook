// ***********************************************************************
// FileName:BehaviorBase
// Description:
// Project:
// Author:NewBLife
// Created:2016/11/13 14:42:02
// Copyright (c) 2016 NewBLife,All rights reserved.
// ***********************************************************************
using System;
using Xamarin.Forms;

namespace MyOutlook.Behaviors
{
    public class BindableBehavior<T> : Behavior<T> where T : BindableObject
    {
        public T AssociatedObject { get; private set; }

        protected override void OnAttachedTo(T visualElement)
        {
            base.OnAttachedTo(visualElement);

            AssociatedObject = visualElement;

            if (visualElement.BindingContext != null)
                BindingContext = visualElement.BindingContext;

            visualElement.BindingContextChanged += OnBindingContextChanged;
        }

        private void OnBindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnDetachingFrom(T view)
        {
            view.BindingContextChanged -= OnBindingContextChanged;
        }

        /// <summary>
        /// Track any changes of the view's binding context
        /// </summary>
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
    }
}
