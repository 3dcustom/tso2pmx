using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tso2Pmd
{
    class EdgeInform : IDisposable
    {
        static string edgefile = "edge.ini";
        static Encoding encoding = Encoding.GetEncoding("Shift_JIS");
        Dictionary<String, Boolean> edgeflag;

        // コンストラクタ：フラグを辞書に読み込む.
        public EdgeInform()
        {
            using (StreamReader sr = new StreamReader(edgefile, encoding))
            {
                edgeflag = new Dictionary<string, bool>();
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    edgeflag.Add(line,true);
                }
            }
        }

        // 指定されたテクニックがエッジを持っているか返す.
        public Boolean hasedge(string technique)
        {
            return edgeflag.ContainsKey(technique);
        }

        public void Dispose()
        {
            edgeflag = null;
        }
    }
}
