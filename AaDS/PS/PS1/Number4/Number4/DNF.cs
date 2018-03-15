using System;
using System.Text;

namespace Number4
{
    public class DNF
    {
        SinglyLinkedList ListOfConjuncts = new SinglyLinkedList();

        public DNF(String s)
        {
            var conjuncts = s.Split('^');
            foreach (var conjunct in conjuncts)
            {
                ListOfConjuncts.Add(new Konj(conjunct));
            }
        }

        public DNF()
        {

        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var conjunct in ListOfConjuncts)
            {
                stringBuilder.Append(conjunct.Data);
                stringBuilder.Append(" ^ ");
            }
            stringBuilder.Remove(stringBuilder.Length - 3, 3);
            return stringBuilder.ToString();
        }

        public void Insert(Konj k)
        {
            if (!ListOfConjuncts.Contains(k))
            {
                ListOfConjuncts.Add(k);
            }
        }

        public DNF Disj(DNF d)
        {
            foreach (var conjunct in d.ListOfConjuncts)
            {
                Insert(conjunct.Data);
            }
            return this;
        }

        public bool Value(bool[] v)
        {
            bool value = false;
            foreach (var conjunct in ListOfConjuncts)
            {
                value |= conjunct.Data.Value(v);
                if (value)
                    return true;
            }
            return value;
        }

        public DNF DnfWith(int i)
        {
            DNF newDnf = new DNF();
            foreach (var conjunct in ListOfConjuncts)
            {
                if (conjunct.Data.Contains(i))
                    newDnf.Insert(conjunct.Data);
            }
            return newDnf;
        }

        //public void SortByLength()
        //{
        //    var length = ListOfConjuncts.Count;
        //    for (int i = 0; i < length; i++)
        //    {
        //        for (int j = 0; j < length - 1; j++)
        //        {
        //            if (ListOfConjuncts[j].Data.ListOfVariables.Count > ListOfConjuncts[j + 1].Data.ListOfVariables.Count)
        //            {
        //                var temp = ListOfConjuncts[j + 1].Data;
        //                ListOfConjuncts[j + 1].Data = ListOfConjuncts[j].Data;
        //                ListOfConjuncts[j].Data = temp;
        //            }
        //        }
        //    }
        //}

        public void SortByLength()
        {
            bool flag = true;
            while (flag)
            {
                var current = ListOfConjuncts.Head;
                flag = false;
                while (current.Next!=null)
                {
                    if (current.Data.ListOfVariables.Count > current.Next.Data.ListOfVariables.Count)
                    {
                        var temp = current.Next.Data;
                        current.Next.Data = current.Data;
                        current.Data = temp;
                        flag = true;
                    }
                    current = current.Next;
                }  
            }
        }
    }
}