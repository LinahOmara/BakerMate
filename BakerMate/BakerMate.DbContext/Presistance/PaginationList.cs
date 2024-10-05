namespace BakerMate.DbContext.Presistance
{
    public class PaginationList<T> : List<T>
    {
        public int TotalCount { get; set; }

        public PaginationList(List<T> items, int count)
        {
            TotalCount = count;
            AddRange(items);
        }

        public PaginationList(IEnumerable<T> items, int count)
        {
            TotalCount = count;
            AddRange(items);
        }
    }
}
