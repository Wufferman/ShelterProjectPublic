namespace Client.Shared
{
    public partial class NavMenu
    {
        public static bool isLoggedIn = false;
        public static bool isAdmin = false;

        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        public NavMenu()
        {

        }
        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }

    }
}
