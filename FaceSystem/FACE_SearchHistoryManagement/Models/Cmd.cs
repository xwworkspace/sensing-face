using System.Windows.Input;

namespace FACE_SearchHistoryManagement.Models
{
    public class Cmd
    {
        public ICommand SearchHistoryCommand { get; private set; }
        public ICommand PageMoveToPrevCommand { get; private set; }
        public ICommand PageMoveToNextCommand { get; private set; }
    }
}
