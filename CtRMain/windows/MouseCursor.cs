using System.Collections.Generic;
using CutTheRope.iframework;
using CutTheRope.iframework.core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace CutTheRope.windows
{
	internal class MouseCursor
	{
		private Texture2D _cursor;

		private Texture2D _cursorActive;

		private MouseState _mouseStateTranformed;

		private MouseState _mouseStateOriginal;

		private int _touchID;

		private bool _enabled;

		public void Enable(bool b)
		{
			_enabled = b;
		}

		public void ReleaseButtons()
		{
			_mouseStateTranformed = new MouseState(_mouseStateTranformed.X, _mouseStateTranformed.Y, _mouseStateTranformed.ScrollWheelValue, Microsoft.Xna.Framework.Input.ButtonState.Released, Microsoft.Xna.Framework.Input.ButtonState.Released, Microsoft.Xna.Framework.Input.ButtonState.Released, Microsoft.Xna.Framework.Input.ButtonState.Released, Microsoft.Xna.Framework.Input.ButtonState.Released);
		}

		public void Load(ContentManager cm)
		{
			_cursor = cm.Load<Texture2D>("cursor");
			_cursorActive = cm.Load<Texture2D>("cursor_active");
		}

		public static MouseState GetMouseState()
		{
			return TransformMouseState(Global.XnaGame.GetMouseState());
		}

		private static MouseState TransformMouseState(MouseState mouseState)
		{
			return new MouseState(Global.ScreenSizeManager.TransformWindowToViewX(mouseState.X), Global.ScreenSizeManager.TransformWindowToViewY(mouseState.Y), mouseState.ScrollWheelValue, mouseState.LeftButton, mouseState.MiddleButton, mouseState.RightButton, mouseState.XButton1, mouseState.XButton2);
		}

		public List<TouchLocation> GetTouchLocation()
		{
			List<TouchLocation> list = new List<TouchLocation>();
			_mouseStateOriginal = Global.XnaGame.GetMouseState();
			if (_mouseStateOriginal.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
			{
				Global.XnaGame.SetCursor(_cursorActive, _mouseStateOriginal, 1, 1);
			}
			else
			{
				Global.XnaGame.SetCursor(_cursor, _mouseStateOriginal, 0, 1);
			}
			MouseState mouseStateTranformed = TransformMouseState(_mouseStateOriginal);
			TouchLocation item = default(TouchLocation);
			if (_touchID > 0)
			{
				if (mouseStateTranformed.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
				{
					item = ((_mouseStateTranformed.LeftButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed) ? new TouchLocation(++_touchID, TouchLocationState.Pressed, new Vector2(mouseStateTranformed.X, mouseStateTranformed.Y)) : new TouchLocation(_touchID, TouchLocationState.Moved, new Vector2(mouseStateTranformed.X, mouseStateTranformed.Y)));
				}
				else if (_mouseStateTranformed.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
				{
					item = new TouchLocation(_touchID, TouchLocationState.Released, new Vector2(_mouseStateTranformed.X, _mouseStateTranformed.Y));
				}
			}
			else if (mouseStateTranformed.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
			{
				item = new TouchLocation(++_touchID, TouchLocationState.Pressed, new Vector2(mouseStateTranformed.X, mouseStateTranformed.Y));
			}
			if (item.State != 0)
			{
				list.Add(item);
			}
			_mouseStateTranformed = mouseStateTranformed;
			return global::CutTheRope.iframework.core.Application.sharedCanvas().convertTouches(list);
		}
	}
}
