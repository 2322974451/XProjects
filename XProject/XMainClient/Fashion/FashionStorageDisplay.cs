using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class FashionStorageDisplay : FashionStorageTabBase
	{

		public FashionStorageDisplay(FashionStoragePosition position)
		{
			this.m_position = position;
			this.m_name = XFashionStorageDocument.GetFashionStoragePartName(this.m_position);
		}

		public override int GetID()
		{
			return XFastEnumIntEqualityComparer<FashionStoragePosition>.ToInt(this.m_position);
		}

		public override int GetCount()
		{
			return this.GetItems().Count;
		}

		public override string GetName()
		{
			return string.Format("{0}({1})", this.m_name, this.GetCount());
		}

		public override uint[] GetFashionList()
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			return specificDocument.DisplayFashion.ToArray();
		}

		private FashionStoragePosition m_position;

		private string m_name;
	}
}
