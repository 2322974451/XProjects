using System;

namespace UILib
{

	public interface IXUICheckBox : IXUIObject
	{

		void RegisterOnCheckEventHandler(CheckBoxOnCheckEventHandler eventHandler);

		CheckBoxOnCheckEventHandler GetCheckEventHandler();

		void SetEnable(bool bEnable);

		bool bChecked { get; set; }

		void ForceSetFlag(bool bCheckd);

		void SetAlpha(float f);

		void SetAudioClip(string name);

		bool bInstantTween { get; set; }

		int spriteHeight { get; set; }

		int spriteWidth { get; set; }

		void SetGroup(int group);
	}
}
