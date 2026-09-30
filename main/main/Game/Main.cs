using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;
using Engine;

namespace Lecture4
{
    public class Main
    {
        private Dictionary<string, Scene> scenes;
        private string currentSceneName = "main";

        public Scene scene => scenes[currentSceneName];
        
        public Main(ContentManager content)
        {
            new AssetManager(content);
            new DialogueSystem();
            new InventorySystem();

            Scene.pixelTexture = Services.AssetManager.GetTexture(Art.Pixel);
            
            scenes = new Dictionary<string, Scene>();
            scenes.Add("main",new MainScene("level0.txt"));
        }
        

        void SetScene(string sceneName)
        {
            if (scenes.ContainsKey(sceneName) == false)
            {
                Debug.WriteLine($"error: scene {sceneName} does not exist");
                return;
            }
            currentSceneName = sceneName;
        }
        
        public void Update(GameTime gameTime)
        {
            Input.Update();
            Services.DialogueSystem.Update(gameTime);
            scene.Update(gameTime);
            HandleSceneChange();
        }
        void HandleSceneChange()
        {
            if (scene.newSceneDesired)
            {
                string nextScene = scene.nextScene;
                scene.Close();
                SetScene(nextScene);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            scene.Draw(spriteBatch);
            Services.InventorySystem.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
