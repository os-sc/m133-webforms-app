using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using SpielGutWebInterface.Domain.Manager;

namespace SpielGutWebInterface.Domain.Interface
{

    [DataContract]
    public abstract class Manager<TManagable>
    {
        [DataMember]
        protected abstract List<TManagable> Data { get; set; }

        protected abstract XmlDatabase<TManagable> Db { get; set; }

        public abstract TManagable GetById(string id);

        protected List<IManagable> GenerifyList(List<TManagable> list)
        {
            return list.Select(m => (IManagable) m).ToList();
        }

        protected List<TManagable> DegenerifyList(List<IManagable> list)
        {
            return list.Select(m => (TManagable) m).ToList();
        }

        public bool IsEmpty()
        {
            return Data != null && !Data.Any();
        }

        public abstract void InitializeDefaultData();
    }
}
