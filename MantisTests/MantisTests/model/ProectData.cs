using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTests
{
    public class ProectData : IEquatable<ProectData>, IComparable<ProectData>
    {
        public string ProectName { get; set; }
        public string Id { get; set; }

        public ProectData()
        {
        }

        public ProectData(string proectName)
        {
            ProectName = proectName;
        }

        public bool Equals(ProectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return ProectName == other.ProectName &&  Id == other.Id;

        }

        public override int GetHashCode()
        {
            return (ProectName +  Id).GetHashCode();
        }

        public int CompareTo(ProectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Id.CompareTo(other.Id);
        }
    }
}
