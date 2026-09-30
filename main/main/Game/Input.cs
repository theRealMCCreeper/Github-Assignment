using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace Lecture4
{
    public enum InputEvent
    {
        MoveRight,
        MoveLeft,
        MoveDown,
        MoveUp,
        Talk
    }
    public static class Input
    {
        private static Dictionary<InputEvent, List<Keys>> inputEventKeys = new Dictionary<InputEvent, List<Keys>>()
        {
            {InputEvent.MoveRight, new List<Keys>{Keys.Right,Keys.D,Keys.E} },
            {InputEvent.MoveLeft,new List<Keys> {Keys.Left,Keys.A} },
            {InputEvent.MoveDown, new List<Keys>{Keys.Down,Keys.S} },
            {InputEvent.MoveUp,new List<Keys> {Keys.Up,Keys.W} },
            {InputEvent.Talk,new List<Keys>{Keys.Space } }
        };
        private static KeyboardState currentState, previousState;
        public static void Update()
        {
            previousState = currentState;
            currentState = Keyboard.GetState();
        }
        public static bool IsInputEventDown(InputEvent e)
        {
            if(inputEventKeys.ContainsKey(e) == false)
            {
                return false;
            }
            foreach(Keys key in inputEventKeys[e])
            {
                if (IsKeyDown(key))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsKeyDown(Keys key)
        {
            return currentState.IsKeyDown(key);
        }
        public static bool IsInputEventPressed(InputEvent e)
        {
            if (inputEventKeys.ContainsKey(e) == false)
            {
                return false;
            }
            foreach (Keys key in inputEventKeys[e])
            {
                if (IsKeyPressed(key))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsKeyPressed(Keys key)
        {
            return currentState.IsKeyDown(key) && previousState.IsKeyUp(key);
        }
    }
}
