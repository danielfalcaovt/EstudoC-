namespace DataAccess.Models
{
    public partial class Category
    {
        public string AffectedRowsHelper(int rows)
        {
            return $"{rows} registros afetados.";
        }
    }
}