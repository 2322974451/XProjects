using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal struct XArtifactBuffInfo
	{

		public uint Type
		{
			get
			{
				return this.m_type;
			}
		}

		public uint Id
		{
			get
			{
				return this.m_id;
			}
		}

		public List<int> Values
		{
			get
			{
				return this.m_values;
			}
		}

		public uint SortId
		{
			get
			{
				return this.m_sortId;
			}
		}

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

		private uint m_type;

		private uint m_id;

		private uint m_sortId;

		private List<int> m_values;
	}
}
