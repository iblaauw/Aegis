using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;
using Microsoft.Xna.Framework.Input;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Aegis.Keyboard
{
    class ButtonState
    {
        private KeyboardState keyboardState;
        private Dictionary<Keys, bool> keyValidity = new Dictionary<Keys, bool>();

        public ButtonState() {}

        /// <summary>
        /// Returns true once if key is pressed, but will
        /// not return true on subsequent calls until key
        /// is released first.
        /// </summary>
        /// <param name="key">Button to check if pressed</param>
        /// <returns></returns>
        public bool IsKeyPressedOnce(Keys key)
        {
            keyboardState = GameState.Keyboard;

            if (!keyValidity.ContainsKey(key))
            {
                keyValidity[key] = true;
            }

            if (keyboardState.IsKeyDown(key))
            {
                if (keyValidity[key])
                {
                    keyValidity[key] = false;
                    return true;
                }
            }
            else
            {
                keyValidity[key] = true;
            }

            return false;
        }

        /// <summary>
        /// Returns true if key is pressed. False otherwise.
        /// No debouncing included.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyDown(Keys key)
        {
            keyboardState = GameState.Keyboard;
            return keyboardState.IsKeyDown(key);
        }
    }
}
