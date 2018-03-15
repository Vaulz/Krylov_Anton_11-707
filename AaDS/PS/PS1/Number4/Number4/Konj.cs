using System;
using System.Collections.Generic;
using System.Text;

namespace Number4
{
    public class Konj
    {
        public List<int> ListOfVariables = new List<int>();

        public Konj(string conjunct)
        {
            var variables = conjunct.Split('&');
            foreach (var variable in variables)
            {
                switch (variable)
                {
                    case "x1":
                        ListOfVariables.Add(1);
                        break;
                    case "x2":
                        ListOfVariables.Add(2);
                        break;
                    case "x3":
                        ListOfVariables.Add(3);
                        break;
                    case "x4":
                        ListOfVariables.Add(4);
                        break;
                    case "x5":
                        ListOfVariables.Add(5);
                        break;

                    case "-x1":
                        ListOfVariables.Add(-1);
                        break;
                    case "-x2":
                        ListOfVariables.Add(-2);
                        break;
                    case "-x3":
                        ListOfVariables.Add(-3);
                        break;
                    case "-x4":
                        ListOfVariables.Add(-4);
                        break;
                    case "-x5":
                        ListOfVariables.Add(-5);
                        break;
                    default:
                        throw new Exception("Data is incorrect");
                }
            }
            ListOfVariables.Sort();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var variable in ListOfVariables)
            {
                switch (variable)
                {
                    case 1:
                        stringBuilder.Append("x1");
                        break;
                    case 2:
                        stringBuilder.Append("x2");
                        break;
                    case 3:
                        stringBuilder.Append("x3");
                        break;
                    case 4:
                        stringBuilder.Append("x4");
                        break;
                    case 5:
                        stringBuilder.Append("x5");
                        break;

                    case -1:
                        stringBuilder.Append("-x1");
                        break;
                    case -2:
                        stringBuilder.Append("-x2");
                        break;
                    case -3:
                        stringBuilder.Append("-x3");
                        break;
                    case -4:
                        stringBuilder.Append("-x4");
                        break;
                    case -5:
                        stringBuilder.Append("-x5");
                        break;
                }
                stringBuilder.Append('&');
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Konj)
            {
                var konj = obj as Konj;

                var length = ListOfVariables.Count;
                var lengthOfKonj = konj.ListOfVariables.Count;

                if (length == lengthOfKonj)
                {
                    for (int i = 0; i < length; i++)
                    {
                        if (konj.ListOfVariables[i] != ListOfVariables[i])
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Value(bool[] v)
        {
            bool x1 = true, x2 = true, x3 = true, x4 = true, x5 = true;
            foreach (var variable in ListOfVariables)
            {
                switch (variable)
                {
                    case 1:
                        x1 = v[0];
                        break;
                    case 2:
                        x2 = v[1];
                        break;
                    case 3:
                        x3 = v[2];
                        break;
                    case 4:
                        x4 = v[3];
                        break;
                    case 5:
                        x5 = v[4];
                        break;

                    case -1:
                        x1 = !v[0];
                        break;
                    case -2:
                        x2 = !v[0];
                        break;
                    case -3:
                        x3 = !v[0];
                        break;
                    case -4:
                        x4 = !v[0];
                        break;
                    case -5:
                        x5 = !v[0];
                        break;
                }
            }
            return x1 & x2 & x3 & x4 & x5;
        }

        public bool Contains(int i)
        {
            foreach (var variable in ListOfVariables)
            {
                if (Math.Abs(variable) == i)
                {
                    return true;
                }
            }
            return false;
        }
    }
}