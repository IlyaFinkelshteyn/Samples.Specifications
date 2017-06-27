﻿using System;
using FlaUI.Core.AutomationElements;
using Samples.Specifications.Tests.Domain.ScreenObjects;

namespace Samples.Specifications.Tests.EndToEnd.Domain.ScreenObjects
{
    class ExitScreenObject : IExitScreenObject
    {
        public bool IsDisplayed()
        {
            var application = ApplicationContext.Application;
            Window exitWindow = null;
            try
            {
                exitWindow = application?.GetWindowEx("Exit options");
            }
            catch (Exception e)
            {
            }
            return exitWindow?.Properties.IsOffscreen ?? false;
        }

        public void ExitWithSave()
        {
            var application = ApplicationContext.Application;
            var exitWindow = application?.GetWindowEx("Exit options");

            var exitControl = exitWindow?.FindFirstDescendant("ExitWithSave").AsButton();
            exitControl?.Click();
        }

        public void ExitWithoutSave()
        {
            var application = ApplicationContext.Application;
            var exitWindow = application?.GetWindowEx("Exit options");

            var exitControl = exitWindow?.FindFirstDescendant("ExitWithSave").AsButton();
            exitControl?.Click();
        }

        public void Cancel()
        {
            var application = ApplicationContext.Application;
            var exitWindow = application?.GetWindowEx("Exit options");

            var exitControl = exitWindow?.FindFirstDescendant("ExitCancel").AsButton();
            exitControl?.Click();
        }
    }
}