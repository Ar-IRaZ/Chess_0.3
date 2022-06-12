using ChessLibrary.MainMenu;
using ChessLibrary.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Authorization
{
    class LogInGamePart : GamePart
    {
        private int status = 0;
        private Player Player { get; set; }
        public override List<ISceneItem> GetScene()
        {
            List<ISceneItem> sceneItems = null;
            switch (status)
            {

                case 0:
                    sceneItems = new List<ISceneItem>() {  new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                //Console.SetCursorPosition(12,6);
                                                                                new MenuSceneItems("Write Login:"  + new string(' ', 67)+ '\n',true),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79), false)};
                    break;


                case 1:
                    sceneItems = new List<ISceneItem>() {  new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                //Console.SetCursorPosition(21,6);
                                                                                new MenuSceneItems("Write Password:"  + new string(' ', 64)+ '\n',true),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79), false)};
                    break;
                
                case 2:
                    sceneItems = new List<ISceneItem>() {  new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 22)+"There is no that player"  + new string(' ', 21)+ '\n',false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79), false)};
                    break;

                case 3:
                    sceneItems = new List<ISceneItem>() {  new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 29)+"Password does not match"  + new string(' ', 28)+ '\n',false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79), false)};
                    break;


                default:
                    break;
            }
            return sceneItems;
        }

        public override void ReadInput()
        {
            using (PlayerContext context = new PlayerContext())
            {

                switch (status)
                {
                    #region 0
                    case 0:
                        Console.SetCursorPosition(12, 6);
                        string s = Console.ReadLine();
                        Player pl = null;
                        pl = context.Players
                                            .Where(p => p.Login == s)
                                            .FirstOrDefault();
                        if (pl == null)
                        {
                            status = 2;
                            
                        }
                        else
                        {
                            status = 1;
                            Player = pl;                            
                        }
                        break;
                    #endregion

                    #region 1
                    case 1:
                        Console.SetCursorPosition(16, 6);
                        s = Console.ReadLine();
                        if (Player.Password == s)
                        {
                            App.SetScene(new MainMenuScene());
                            App.SetGamePart(new MainMenuGamePart());
                        }
                        else
                        {
                            status = 3;
                        }
                        break;
                    #endregion

                    #region 2
                    case 2:
                        Console.SetCursorPosition(28, 6);
                        s = Console.ReadLine();
                        if (Player.Password == s)
                        {
                            status = 3;
                        }
                        else
                        {
                            Player.Password = null;
                            status = 5;
                        }
                        break;
                    #endregion

                    #region 3
                    case 3:
                        Console.SetCursorPosition(22, 6);
                        s = Console.ReadLine();
                        GamesStats gamesStats = new GamesStats();
                        Player.NickName = s;
                        Player.GamesStats = gamesStats;
                        gamesStats.Player = Player;

                        context.Players.Add(Player);
                        context.GamesStats.Add(gamesStats);
                        context.SaveChanges();
                        status = -1;
                        App.SetGamePart(new LogInOrSingInGamePart());
                        App.SetScene(new LogInOrSingInScene());
                        break;
                    #endregion

                    #region 4
                    case 4:
                        status = 0;
                    Here: if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {

                        }
                        else
                        {
                            goto Here;
                        }
                        break;
                    #endregion

                    #region 5
                    case 5:
                        status = 1;
                    Here2: if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {

                        }
                        else
                        {
                            goto Here2;
                        }
                        break;
                        #endregion                    
                }
            }
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
