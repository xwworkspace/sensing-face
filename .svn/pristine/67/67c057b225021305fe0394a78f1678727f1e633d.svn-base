using System.Collections.Generic;

namespace FACE_ChannelManagement.Models
{
    /// <summary>
    /// 通道管理 通道RootNode及ChildNode
    /// </summary>
    public class Channel
    {
        readonly List<Channel> _children = new List<Channel>();
        /// <summary>
        /// 递归子节点
        /// </summary>
        public IList<Channel> Children
        {
            get { return _children; }
            set { value = _children; }
        }

        /// <summary>
        /// 通道唯一标识 ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 通道名称
        /// </summary>
        public string Name { get; set; }

        //节点其他相关信息  待添加
    }
}
