using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLibrary.Scenes
{
    public interface ISceneSourse
    {
        
        public void PrintScene();
        public void UpdateScene(List<ISceneItem> sceneItems);        

        //public event Action SceneRanderHendler;
    }
}