namespace ApiEjemplo.Controllers
{
    public static class Mapper
    {
        public static ActivityRead Map(Activity a)
        {
            return new()
            {
                Creator = a.Creator,
                FinishDate = a.FinishDate,
                Id = a.Id,
                StartDate = a.StartDate
            };
        }
    }
}