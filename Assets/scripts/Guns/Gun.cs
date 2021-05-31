using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    public abstract class Gun
    {
        public abstract void Shoot();
        public double ShootTimer { get; set; } = 0;
    }
