using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defense
{
    public class Button
    {
        private ContentManager _content;
        private SpriteBatch _spriteBatch;
        private Texture2D textureSet;
        private Texture2D textureButtonOff, textureButtonOn;
        private List<Button> buttonList;
        public enum ButtonType
        {
            Setting,
            MuteMusic,
            UnmuteMusic,
            MuteSound,
            UnmuteSound,
            Pause,
            Unpause,
            Slower,
            Faster,
            Book,
            Money,
            Undo,
        }
        public Button()
        {
            
        }
        private void CreateButton()
        {
            foreach (ButtonType buttonType in Enum.GetValues(typeof(ButtonType)))
            {
                if (buttonType == ButtonType.UnmuteMusic ||
                    buttonType == ButtonType.UnmuteSound ||
                    buttonType == ButtonType.Unpause)
                {
                    continue;
                }
                Button _button = new Button();
                buttonList.Add(_button);
            }
        }
        public void Load()
        {
            textureSet = _content.Load<Texture2D>("GUI/buttons");
            CreateButton();
        }

        public void Unload()
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {

        }
    }
}
