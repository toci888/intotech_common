using System;
using System.Collections.Generic;

namespace ClassesFrom.ClassesFromCopy
{
    public partial class Accountmode
    {
        public int Idaccount { get; set; }
        public int Mode { get; set; }

        public virtual Account IdaccountNavigation { get; set; } = null!;
    }
}
