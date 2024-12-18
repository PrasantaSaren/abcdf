namespace Inventory.Models.Request
{
    public class BrowseParam
    {
        /// <summary>
        /// The Search For
        /// </summary>
        /// <example></example>
        public string SearchFor { get; set; } = "";
        /// <summary>
        /// The Page Sort
        /// </summary>
        /// <example>Name</example>
        public string PageSort { get; set; } = "";
        /// <summary>
        /// The Page Order
        /// </summary>
        /// <example>ASC</example>
        public string PageOrder { get; set; } = "";
        /// <summary>
        /// The Start Row
        /// </summary>
        /// <example>0</example>
        public int StartRow { get; set; } = 0;
        /// <summary>
        /// The End Row
        /// </summary>
        /// <example>30</example>
        public int EndRow { get; set; } = 10;
    }
}
