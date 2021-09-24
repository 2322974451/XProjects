using System;
using System.Collections.Generic;

namespace UILib
{

	public interface IXUIPopupList : IXUIObject
	{

		void SetOptionList(List<string> options);

		string value { get; set; }

		int currentIndex { get; set; }
	}
}
