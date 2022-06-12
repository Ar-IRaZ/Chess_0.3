using ChessLibrary.MainMenu;
using ChessLibrary.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Authorization
{
    public class SingInGamePart : GamePart
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
                                                                                //Console.SetCursorPosition(17,6);
                                                                                new MenuSceneItems("Write new Login:"  + new string(' ', 36)+ '\n',true),
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
                                                                                new MenuSceneItems("Write new Password:"  + new string(' ', 36)+ '\n',true),
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
                                                                                //Console.SetCursorPosition(28,6);
                                                                                new MenuSceneItems("Confirm your new Password:"  + new string(' ', 36)+ '\n',true),
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
                                                                                //Console.SetCursorPosition(22,6);
                                                                                new MenuSceneItems("Create your Nickname:"  + new string(' ', 36)+ '\n',true),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79), false)};
                    break;
                case 4:
                    sceneItems = new List<ISceneItem>() {  new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 22)+"Login in used. Create another one."  + new string(' ', 21)+ '\n',false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79) + '\n', false),
                                                                                new MenuSceneItems(new string(' ', 79), false)};
                    break;

                case 5:
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
                        Console.SetCursorPosition(17, 6);
                        string s = Console.ReadLine();
                        Player pl = null;                        
                            pl = context.Players
                                                .Where(p => p.Login == s)
                                                .FirstOrDefault();                        
                        if (pl == null)
                        {
                            status = 1;
                            Player = new Player();
                            Player.Login = s;
                        }
                        else
                        {
                            status = 4;
                        }                
                    break;
                    #endregion

                    #region 1
                    case 1:
                        Console.SetCursorPosition(21, 6);
                        s = Console.ReadLine();
                        Player.Password = s;
                        status = 2;
                        break;
                    #endregion

                    #region 2
                    case 2:
                        Console.SetCursorPosition(28, 6);
                        s = Console.ReadLine();
                        if (Player.Password == s)
                        {
                            status = 3;
                        }else
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
                        Here: if(Console.ReadKey().Key == ConsoleKey.Enter)
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
