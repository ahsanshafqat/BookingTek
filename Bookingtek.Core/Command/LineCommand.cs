using Bookingtek.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookingtek.Core.Command
{
	public class LineCommand : ICommand
	{
		private int _x1, _x2, _y1, _y2;
		public void CommandValidation(List<string> cmd)
		{
            if(Canvas.Instance.CanvasInitialzed==false)
                throw new ArgumentNullException("create a canvas first");

            if (cmd == null || !cmd.Any())
				throw new ArgumentNullException("missing command arguments");

			if (cmd.Count != 4)
				throw new ArgumentException("only accept 4 arguments: x1,x2,y1,y2");
			
			if ((!int.TryParse(cmd[0], out _x1) || _x1 <= 0) ||
				(!int.TryParse(cmd[2], out _x2) || _x2 <= 0) ||
				(!int.TryParse(cmd[1], out _y1) || _y1 <= 0) ||
				(!int.TryParse(cmd[3], out _y2) || _y2 <= 0))
				throw new ArgumentException("arguments should be a positive int");
			
			if ((_x1 != _x2) && (_y1 != _y2))
				throw new ArgumentException("currently only	horizontal or vertical lines are supported.");

			if ((_x1 > _x2) || (_y1 > _y2))
				throw new ArgumentException("arguments wrong: x1 > x2 or y1 > y2");

			if ((_x2 > Canvas.Instance.Width - 2) || (_y2 > Canvas.Instance.Height - 2))
				throw new ArgumentException("point should be in the canvas");
		}

		public void ExecuteCommand()
		{
			if (_x1 == _x2)
			{
				//draw vertical
				for (int i = _y1; i <= _y2; i++)
                    Canvas.Instance.cells[_x1, i] = Canvas.Instance.lineChar;
			}
			else if (_y1 == _y2)
			{
				//draw horizontal
				for (int i = _x1; i <= _x2; i++)
                    Canvas.Instance.cells[i, _y1] = Canvas.Instance.lineChar;
			}
			

		}		
	}
}
