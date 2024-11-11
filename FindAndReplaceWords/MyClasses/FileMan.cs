using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
    public class FileMan
    {

        public static FunctionReturn FileExit(string filename)
        {
            var ret = new FunctionReturn();
            ret.CheckNullOrEmptyWithTrim(filename);

            if (ret.IsTextEmpty)
                ret.Flag = false;
            else
                ret.Flag = File.Exists(ret.Text);

            return ret;
        }
        public static FunctionReturn PathExists(string path)
        {
            var ret = new FunctionReturn();
            ret.CheckNullOrEmptyWithTrim(path);
            if (ret.IsTextEmpty) return ret;

            if (File.Exists(ret.Text))
                ret.Text = Path.GetDirectoryName(ret.Text);
            else if (Directory.Exists(ret.Text))
            { }
            else
                ret.Reset();

            return ret;
        }
        public static string PathShorten(string str, int limitedLength = 0)
        {
            var ret = new FunctionReturn();
            ret.CheckNullOrEmptyWithTrim(str);
            if (ret.IsTextEmpty) return str;

            str = ret.Text;

            int[] pos = { 0, 0 };
            pos[0] = str.IndexOf("\\", 0);
            pos[1] = str.LastIndexOf("\\");
            pos[1] = str.LastIndexOf("\\", pos[1] - 1);

            string[] s = { str.Substring(0, pos[0]), "...", str.Substring(pos[1] + 1) };
            string t = string.Join("\\", s);

            ret.Text = str.Length <= t.Length ? str : t;

            pos[0] = ret.Text.Length;

            if (limitedLength < 1 || limitedLength >= pos[0])
                str = ret.Text;
            else if (limitedLength > 10 && limitedLength <= ret.Text.Length)
            {
                pos[0] = ret.Text.Length - limitedLength + 1;
                str = ret.Text.Substring(pos[0]);
            }
            else
                str = ret.Text;

            return "..." + str;
        }

    }
}

