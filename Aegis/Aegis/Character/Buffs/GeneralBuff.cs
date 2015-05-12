using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegis.Character.Buffs
{
    /// <summary>
    /// This class provides some good utility functions. Usually want to inherit from this for convenience.
    /// </summary>
    public abstract class GeneralBuff : IBuff
    {
        private BuffRegistrationCollection registrationSet;

        protected BuffRegistrationCollection RegistrationSet { get { return registrationSet; } }

        public void RegisterForEvents(BuffRegistrationCollection eventSet)
        {
            this.registrationSet = eventSet;
            ActualRegisterForEvents();
        }

        protected void RemoveSelf()
        {
            this.RegistrationSet.stats.RemoveBuff(this);
        }

        public abstract bool AllowOverwrite(IBuff buffOverwriting);

        public abstract void Update();

        public abstract void ActualRegisterForEvents();
    }
}
