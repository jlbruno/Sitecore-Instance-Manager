namespace SIM.Core.Commands
{
  using SIM.Core.Common;
  using Sitecore.Diagnostics.Base;
  using Sitecore.Diagnostics.Base.Annotations;

  public class ProfileCommand : AbstractCommand<Profile>
  {
    protected override void DoExecute(CommandResultBase<Profile> result)
    {
      Assert.ArgumentNotNull(result, "result");

      var profile = Profile.Read();

      var changes = 0;
      var connectionString = this.ConnectionString;
      if (!string.IsNullOrEmpty(connectionString))
      {
        profile.ConnectionString = connectionString;
        changes += 1;
      }

      var instancesRoot = this.InstancesRoot;
      if (!string.IsNullOrEmpty(instancesRoot))
      {
        profile.InstancesFolder = instancesRoot;
        changes += 1;
      }

      var license = this.License;
      if (!string.IsNullOrEmpty(license))
      {
        profile.ConnectionString = license;
        changes += 1;
      }

      var repository = this.Repository;
      if (!string.IsNullOrEmpty(repository))
      {
        profile.ConnectionString = repository;
        changes += 1;
      }

      if (changes > 0)
      {
        profile.Save();
      }

      try
      {
        result.Success = true;
        result.Message = "done";
        result.Data = Profile.Read();
      }
      catch
      {
        result.Success = false;
        result.Message = "profile is corrupted";
        result.Data = null;
      }
    }

    [CanBeNull]
    public virtual string ConnectionString { get; [UsedImplicitly] set; }

    [CanBeNull]
    public virtual string InstancesRoot { get; [UsedImplicitly] set; }

    [CanBeNull]
    public virtual string License { get; [UsedImplicitly] set; }

    [CanBeNull]
    public virtual string Repository { get; [UsedImplicitly]  set; }

    [CanBeNull]
    public virtual string Plugins { get; [UsedImplicitly] set; }    
  }
}