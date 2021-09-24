using System;
using System.Collections.Generic;
using UnityEngine;

namespace UILib
{

	public interface IXUISpecLabelSymbol : IXUIObject
	{

		IXUILabel Label { get; }

		IXUISprite Board { get; }

		IXUISprite[] SpriteList { get; }

		void SetColor(Color color);

		Color GetColor();

		void SetInputText(List<string> sprite);

		void Copy(IXUISpecLabelSymbol other);

		void SetSpriteVisibleFalse(int index);
	}
}
