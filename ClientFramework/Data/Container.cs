﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientFramework.Data
{
    public class Container
    {
        private int id;
        private string name;
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public Container(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
