﻿namespace SIM.Tool.Wizards
{
  using System;
  using System.Collections.Generic;
  using SIM.Tool.Base.Wizards;

  #region

  #endregion

  public abstract class FinishActionHive
  {
    #region Fields

    protected readonly Type WizardArgumentsType;

    #endregion

    #region Constructors

    public FinishActionHive(Type type)
    {
      this.WizardArgumentsType = type;
    }

    #endregion

    #region Public methods

    public abstract IEnumerable<FinishAction> GetFinishActions(WizardArgs wizardArgs);

    #endregion
  }
}