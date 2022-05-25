using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLibrary.Scenes
{
    public class Scene
    {
        private ISceneSourse SceneSourse { get;  set; }

        public Scene(ISceneSourse sceneSourse)
        {
            SceneSourse = sceneSourse;
        }

        public void SetSoure(ISceneSourse sceneSourse)
        {
            SceneSourse = sceneSourse;
        }

        public void PrintScene()
        {
            SceneSourse.PrintScene();
        }

        public void UpdateScene(List<ISceneItem> sceneItems)
        {
            SceneSourse.UpdateScene(sceneItems);
        }
        
    }
}
