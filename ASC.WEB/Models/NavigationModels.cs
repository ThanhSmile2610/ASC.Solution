namespace ASC.WEB.Models
{
    public class NavigationModels
    {
        public List<NavigationModelsItem> MenuItems { get; set; }
    }
    public class NavigationModelsItem
    {
        public string DisplayName { get; set; }
        public string MaterialIcon { get; set; }
        public string Link { get; set; }
        public bool IsNested { get; set; }
        public int Sequence { get; set; }
        public List<string> UserRoles { get; set; }
        public List<NavigationModelsItem> NestedItems { get; set; }
    }
}
