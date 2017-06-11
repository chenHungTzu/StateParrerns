using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Example.Workflow
{
    public interface IFlow
    {
        /// <summary>
        /// 工作主流程
        /// </summary>
        IDictionary<int, IStep> _steps { get; set; }
        /// <summary>
        /// 新增成員
        /// </summary>
        /// <param name="sts"></param>
        /// <param name="step"></param>
        void AddMember(int sts, IStep step);
        /// <summary>
        /// 刪除成員
        /// </summary>
        /// <param name="sts"></param>
        void RemoveMember(int sts);
        /// <summary>
        /// 更新成員
        /// </summary>
        /// <param name="sts"></param>
        /// <param name="step"></param>
        void UpdateMember(int sts, IStep step);
    }
}
