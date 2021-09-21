using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008E0 RID: 2272
	internal class FashionStorageDisplay : FashionStorageTabBase
	{
		// Token: 0x060089B1 RID: 35249 RVA: 0x00121907 File Offset: 0x0011FB07
		public FashionStorageDisplay(FashionStoragePosition position)
		{
			this.m_position = position;
			this.m_name = XFashionStorageDocument.GetFashionStoragePartName(this.m_position);
		}

		// Token: 0x060089B2 RID: 35250 RVA: 0x0012192C File Offset: 0x0011FB2C
		public override int GetID()
		{
			return XFastEnumIntEqualityComparer<FashionStoragePosition>.ToInt(this.m_position);
		}

		// Token: 0x060089B3 RID: 35251 RVA: 0x0012194C File Offset: 0x0011FB4C
		public override int GetCount()
		{
			return this.GetItems().Count;
		}

		// Token: 0x060089B4 RID: 35252 RVA: 0x0012196C File Offset: 0x0011FB6C
		public override string GetName()
		{
			return string.Format("{0}({1})", this.m_name, this.GetCount());
		}

		// Token: 0x060089B5 RID: 35253 RVA: 0x0012199C File Offset: 0x0011FB9C
		public override uint[] GetFashionList()
		{
			XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
			return specificDocument.DisplayFashion.ToArray();
		}

		// Token: 0x04002BB3 RID: 11187
		private FashionStoragePosition m_position;

		// Token: 0x04002BB4 RID: 11188
		private string m_name;
	}
}
