namespace ChessLibrary.MainMenu
{
    internal class MenuSceneItems : ISceneItem
    {
        public string Str { get ; set ; }
        public bool CursoreSelected { get; set ; }

        public MenuSceneItems(string str, bool cursoreSelected)
        {
            Str = str;
            CursoreSelected = cursoreSelected;
        }
    }
}