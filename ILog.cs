using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Example.Workflow
{
    public interface ILog
    {

        /// <summary>
        /// 編號
        /// </summary>
        string Sn { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        string CompCd { get; set; }

        /// <summary>
        /// 準備下一個流程
        /// </summary>
        int NextSts { get; set; }

        /// <summary>
        /// 退回上一個流程
        /// </summary>
        int PrevSts { get; set; }

        /// <summary>
        /// 目前流程
        /// </summary>
        int CurrentSts { get; set; }

        /// <summary>
        /// 流程註記
        /// </summary>
        String Bookmark { get; set; }
    }
}
