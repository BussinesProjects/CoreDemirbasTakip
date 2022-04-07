

namespace DemirbasTakipSistemi.Models.DataModel
{
   
    
    public partial class Request
    {
        public int RequestID { get; set; }
        public string RequestUsername { get; set; }
        public string RequestSubjectTitle { get; set; }
        public string RequestCategoryName { get; set; }
        public System.DateTime RequestDateTime { get; set; }
        public string RequestMessage { get; set; }
        public string RequestReceiverID { get; set; }
        public bool RequestStatus { get; set; }
    }
}
