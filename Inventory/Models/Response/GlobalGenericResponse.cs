namespace Inventory.Models.Response
{
    public class GlobalGenericResponse<T>
    {
        /// <summary>
        /// Response
        /// </summary>
        public T? Response { get; set; }
        /// <summary>
        /// RowCount
        /// </summary>
        public int? RowCount { get; set; } = 0;
        /// <summary>
        /// IsError
        /// </summary>
        public bool IsError { get; set; } = false;
        /// <summary>
        /// ErrorDescription
        /// </summary>
        public string? ErrorDescription { get; set; } = "";
    }
}
