﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Arch.Core.Utils
{
    internal class TypeArraySequenceEqualityComparer : IEqualityComparer<Type[]>
    {
        /// <summary>
        /// Checks whether or not two Type Arrays are equal using sequence equality rather than reference equality
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Equals(Type[] x, Type[] y)
        {
            return x.SequenceEqual(y);
        }

        /// <summary>
        /// Calculates the Hash Code of a Type Array by iterating over the elements and adding the individual Hash Codes together
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int GetHashCode(Type[] obj)
        {
            unchecked{ 
                int hash = 17;
                foreach (var x in obj)
                    hash = hash * 23 + x.GetHashCode();
                return hash;
            }
        }

        public static TypeArraySequenceEqualityComparer Instance { get; } = new TypeArraySequenceEqualityComparer();
    }
}