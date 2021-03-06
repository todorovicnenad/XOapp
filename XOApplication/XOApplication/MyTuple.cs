﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOApplication 
{
    //Serijalizacija liste tupli nije moguca jer Tuple<T,T> nema konstruktor bez parametara
    //sto je uslov da se neki tip serijalizuje

    [Serializable]
    public class MyTuple<T1, T2>
    {
        public MyTuple() { }

        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }

        public MyTuple(T1 a, T2 b)
        {
            Item1 = a;
            Item2 = b;
        }


        public static implicit operator MyTuple<T1, T2>(Tuple<T1, T2> t)
        {
            return new MyTuple<T1, T2>()
            {
                Item1 = t.Item1,
                Item2 = t.Item2
            };
        }

        public static implicit operator Tuple<T1, T2>(MyTuple<T1, T2> t)
        {
            return Tuple.Create(t.Item1, t.Item2);
        }
    }
}
