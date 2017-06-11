using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ptc.Example.Workflow
{
    public static class FlowManager
    {
        static FlowManager()
        {

        }   

        /// <summary>
        /// 流程清單
        /// </summary>
        public static IDictionary<String, IFlow> _flows { get; private set; } = new Dictionary<String, IFlow>();
        /// <summary>
        /// 新增流程
        /// </summary>
        /// <param name="BookmarkName"></param>
        /// <param name="flow"></param>
        public static void AddFlow(String BookmarkName, IFlow Flow)
        {

            if (_flows.ContainsKey(BookmarkName))
                throw new IndexOutOfRangeException($"already added this Bookmark:{BookmarkName}");

            _flows.Add(BookmarkName, Flow);
        }
        /// <summary>
        /// 刪除流程
        /// </summary>
        /// <param name="BookmarkName"></param>
        public static void RemoveFlow(String BookmarkName)
        {

            if (!_flows.ContainsKey(BookmarkName))
                throw new IndexOutOfRangeException($"not exist Bookmark:{BookmarkName}");

            _flows.Remove(BookmarkName);

        }
        /// <summary>
        /// 修改流程
        /// </summary>
        /// <param name="BookmarkName"></param>
        /// <param name="flow"></param>
        public static void UpdateFlow(String BookmarkName, IFlow Flow)
        {

            if (_flows.ContainsKey(BookmarkName))
                _flows[BookmarkName] = Flow;

        }
        /// <summary>
        /// 清除流程
        /// </summary>
        public static void ClearAllFlow() => _flows.Clear();
        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public static Boolean Next(this ILog Log)
            => _flows[Log.Bookmark]._steps[Log.NextSts]
                                   .Excute(Log);
        /// <summary>
        /// 上一步
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public static Boolean Prev(this ILog Log)
            => _flows[Log.Bookmark]._steps[Log.PrevSts]
                                   .Excute(Log);

    }
}
