using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Enterprise.Core.Messages
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult Validation { get; set; }
        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
