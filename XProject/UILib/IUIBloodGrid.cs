using System;

namespace UILib
{

	public interface IUIBloodGrid : IUIWidget, IUIRect
	{

		void SetMAXHP(int maxHp);

		int MAXHP { get; }
	}
}
