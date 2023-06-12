using System;
using System.Collections.Generic;

namespace ClassesFrom.ClassesFromCopy
{
    public partial class Accountscollocation
    {
        public int Id { get; set; }
        public int Idaccount { get; set; }
        public int Idcollocated { get; set; }
        public decimal? Distancefrom { get; set; }
        public decimal? Distanceto { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual Account IdaccountNavigation { get; set; } = null!;
        public virtual Account IdcollocatedNavigation { get; set; } = null!;
    }
}
