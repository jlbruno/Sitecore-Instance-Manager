﻿namespace SIM.Tool.Windows.MainWindowComponents
{
  using System.Windows;
  using SIM.Core.Common;
  using SIM.Instances;
  using SIM.Tool.Base.Plugins;
  using SIM.Tool.Base.Profiles;
  using SIM.Tool.Wizards;
  using Sitecore.Diagnostics.Base.Annotations;

  [UsedImplicitly]
  public class DownloadButton : IMainWindowButton
  {
    #region Public methods

    public bool IsEnabled(Window mainWindow, Instance instance)
    {
      return true;
    }

    public void OnClick(Window mainWindow, Instance instance)
    {
      Analytics.TrackEvent("Download");

      if (FileSystem.FileSystem.Local.Directory.Exists(ProfileManager.Profile.LocalRepository))
      {
        WizardPipelineManager.Start("download", mainWindow, null, null, MainWindowHelper.RefreshInstaller, WindowsSettings.AppDownloaderSdnUserName.Value, WindowsSettings.AppDownloaderSdnPassword.Value);
      }
    }

    #endregion
  }
}