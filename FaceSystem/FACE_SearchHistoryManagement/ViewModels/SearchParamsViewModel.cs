using FACE_SearchHistoryManagement.Models;
using Microsoft.Practices.Prism.ViewModel;

namespace FACE_SearchHistoryManagement.ViewModels
{
    /// <summary>
    /// SearchParamsViewModel
    /// </summary>
    public partial class ViewModel : NotificationObject
    {
        #region Command

        #endregion

        #region CommandFunc

        #endregion

        #region ThriftService

        #endregion

        #region View Properties

        HistorySearchParamsModel _historySearchParams;

        /// <summary>
        /// Search Params for history data
        /// </summary>
        public HistorySearchParamsModel HistorySearchParams
        {
            get { return _historySearchParams; }
            set { _historySearchParams = value; RaisePropertyChanged("HistorySearchParams"); }
        }

        #endregion

        #region CommonFunc

        #endregion
    }
}
