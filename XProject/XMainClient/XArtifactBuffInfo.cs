using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DE0 RID: 3552
	internal struct XArtifactBuffInfo
	{
		// Token: 0x170033DA RID: 13274
		// (get) Token: 0x0600C0D0 RID: 49360 RVA: 0x0028D79C File Offset: 0x0028B99C
		public uint Type
		{
			get
			{
				return this.m_type;
			}
		}

		// Token: 0x170033DB RID: 13275
		// (get) Token: 0x0600C0D1 RID: 49361 RVA: 0x0028D7B4 File Offset: 0x0028B9B4
		public uint Id
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x170033DC RID: 13276
		// (get) Token: 0x0600C0D2 RID: 49362 RVA: 0x0028D7CC File Offset: 0x0028B9CC
		public List<int> Values
		{
			get
			{
				return this.m_values;
			}
		}

		// Token: 0x170033DD RID: 13277
		// (get) Token: 0x0600C0D3 RID: 49363 RVA: 0x0028D7E4 File Offset: 0x0028B9E4
		public uint SortId
		{
			get
			{
				return this.m_sortId;
			}
		}

		// Token: 0x0600C0D4 RID: 49364 RVA: 0x0028D7FC File Offset: 0x0028B9FC
		public void Init()
		{
			this.m_type = 1U;
			this.m_id = 0U;
			this.m_sortId = 0U;
			bool flag = this.m_values == null;
			if (flag)
			{
				this.m_values = new List<int>();
			}
			else
			{
				this.m_values.Clear();
			}
		}

		// Token: 0x0600C0D5 RID: 49365 RVA: 0x0028D848 File Offset: 0x0028BA48
		public void SetData(uint effectId, uint type, uint id, List<int> values)
		{
			this.m_type = type;
			this.m_id = id;
			this.m_values = values;
			EffectTable.RowData rowData = null;
			bool flag = type == 1U;
			if (flag)
			{
				rowData = ArtifactDocument.Doc.GetArtifactSkillEffect(effectId, id);
			}
			else
			{
				bool flag2 = type == 2U;
				if (flag2)
				{
					rowData = ArtifactDocument.Doc.GetArtifactSkillEffect(effectId, id);
				}
			}
			bool flag3 = rowData != null;
			if (flag3)
			{
				this.m_sortId = (uint)rowData.SortID;
			}
			else
			{
				this.m_sortId = 0U;
				XSingleton<XDebug>.singleton.AddGreenLog(string.Format("cannot find this effectTable data effectId = {0},id = {1}", effectId, id), null, null, null, null, null);
			}
		}

		// Token: 0x040050FA RID: 20730
		private uint m_type;

		// Token: 0x040050FB RID: 20731
		private uint m_id;

		// Token: 0x040050FC RID: 20732
		private uint m_sortId;

		// Token: 0x040050FD RID: 20733
		private List<int> m_values;
	}
}
