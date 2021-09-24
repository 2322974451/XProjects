using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal interface IFashionStorageSelect
	{

		int GetID();

		int GetCount();

		void SetCount(uint count);

		string GetName();

		bool Active { get; }

		string GetLabel();

		bool Select { get; set; }

		List<uint> GetItems();

		bool ActivateAll { get; }

		uint[] GetFashionList();

		List<AttributeCharm> GetAttributeCharm();

		bool RedPoint { get; }

		void Refresh();
	}
}
