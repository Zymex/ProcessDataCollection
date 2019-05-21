using System;

namespace ProcessDataCollection._ApplicationModels.DataModels
{
    public class ProcessItems
    {
        public ProcessItems()
        {
            DateCreated = DateTime.Now;
        }
        public int Id { get; set; }
        public int ProcessEntriesId { get; set; }
        public int Qty { get; set; }
        public string Scrap { get; set; }
        public bool Rework { get; set; }
        public string Category { get; set; }
        public string Reason { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}