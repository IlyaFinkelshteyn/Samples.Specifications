﻿namespace Samples.Specifications.Tests.Domain.ScreenObjects
{
    public interface IExitScreenObject
    {
        bool IsDisplayed();
        void ExitWithSave();
        void ExitWithoutSave();
        void Cancel();
    }
}