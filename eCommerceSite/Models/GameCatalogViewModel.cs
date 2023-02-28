namespace eCommerceSite.Models
{
    public class GameCatalogViewModel
    {
        public GameCatalogViewModel(List<Game> games, int currentPage, int lastPage)
        {
            Games = games;
            CurrentPage = currentPage;
            LastPage = lastPage;
        }

        public List<Game> Games { get; set; }
        public int CurrentPage { get; set; }
        public int LastPage { get; set; }
    }
}
