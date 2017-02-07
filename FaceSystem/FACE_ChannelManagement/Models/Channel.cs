using System.Collections.Generic;

namespace FACE_ChannelManagement.Models
{
    public class Channel
    {
        readonly List<Channel> _children = new List<Channel>();
        public IList<Channel> Children
        {
            get { return _children; }
        }

        public string Name { get; set; }
    }
}
