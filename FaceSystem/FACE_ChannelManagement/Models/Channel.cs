using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
