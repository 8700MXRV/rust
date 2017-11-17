using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RustProtect
{
    public class SpawnBuilds
    {

        public string name;
        public Vector3 v;
        public Quaternion q;
        public SpawnBuilds(string name1, float xx, float yy, float zz)
        {
            this.name = name1;
            this.v = new Vector3(xx, yy, zz);
        }
        public SpawnBuilds(string name1,Vector3 vv)
        {
            this.name = name1;
            this.v = vv;
        }

    }
}
