using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtDMMAdonis.src.ExtensionMethods {
    public static class StringExtensions {
        public static string ListItems(this string[] str) {
            String s = "";
            foreach (var item in str) {
                s += item;
                if (item != str.Last()) {
                    s += ", ";
                }
            }

            return s;
        }
    }
}
