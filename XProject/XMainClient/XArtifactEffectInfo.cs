using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DDF RID: 3551
	internal struct XArtifactEffectInfo
	{
		// Token: 0x170033D6 RID: 13270
		// (get) Token: 0x0600C0C6 RID: 49350 RVA: 0x0028D45C File Offset: 0x0028B65C
		// (set) Token: 0x0600C0C7 RID: 49351 RVA: 0x0028D474 File Offset: 0x0028B674
		public uint EffectId
		{
			get
			{
				return this.m_effectId;
			}
			set
			{
				this.m_effectId = value;
			}
		}

		// Token: 0x170033D7 RID: 13271
		// (get) Token: 0x0600C0C8 RID: 49352 RVA: 0x0028D480 File Offset: 0x0028B680
		public uint BaseProf
		{
			get
			{
				return this.m_baseProf;
			}
		}

		// Token: 0x170033D8 RID: 13272
		// (get) Token: 0x0600C0C9 RID: 49353 RVA: 0x0028D498 File Offset: 0x0028B698
		// (set) Token: 0x0600C0CA RID: 49354 RVA: 0x0028D4B0 File Offset: 0x0028B6B0
		public List<XArtifactBuffInfo> BuffInfoList
		{
			get
			{
				return this.m_buffInfoList;
			}
			set
			{
				this.m_buffInfoList = value;
			}
		}

		// Token: 0x170033D9 RID: 13273
		// (get) Token: 0x0600C0CB RID: 49355 RVA: 0x0028D4BC File Offset: 0x0028B6BC
		// (set) Token: 0x0600C0CC RID: 49356 RVA: 0x0028D4D4 File Offset: 0x0028B6D4
		public bool IsValid
		{
			get
			{
				return this.m_isValid;
			}
			set
			{
				this.m_isValid = value;
			}
		}

		// Token: 0x0600C0CD RID: 49357 RVA: 0x0028D4E0 File Offset: 0x0028B6E0
		public void Init()
		{
			this.m_effectId = 0U;
			this.m_isValid = true;
			bool flag = this.m_buffInfoList == null;
			if (flag)
			{
				this.m_buffInfoList = new List<XArtifactBuffInfo>();
			}
			else
			{
				this.m_buffInfoList.Clear();
			}
		}

		// Token: 0x0600C0CE RID: 49358 RVA: 0x0028D524 File Offset: 0x0028B724
		public void SetBaseProf(uint effectId)
		{
			EffectDesTable.RowData byEffectID = ArtifactDocument.EffectDesTab.GetByEffectID(this.EffectId);
			bool flag = byEffectID != null;
			if (flag)
			{
				this.m_baseProf = (uint)byEffectID.BaseProf;
			}
			else
			{
				this.m_baseProf = 0U;
			}
		}

		// Token: 0x0600C0CF RID: 49359 RVA: 0x0028D560 File Offset: 0x0028B760
		public List<string> GetValues()
		{
			bool flag = this.m_allVaules == null;
			if (flag)
			{
				this.m_allVaules = new List<string>();
			}
			else
			{
				this.m_allVaules.Clear();
			}
			bool flag2 = this.m_buffInfoList == null;
			List<string> allVaules;
			if (flag2)
			{
				allVaules = this.m_allVaules;
			}
			else
			{
				EffectDesTable.RowData byEffectID = ArtifactDocument.EffectDesTab.GetByEffectID(this.EffectId);
				float[] array = null;
				string[] array2 = null;
				bool flag3 = byEffectID != null;
				if (flag3)
				{
					array = byEffectID.ParamCoefficient;
					array2 = byEffectID.ColorDes;
				}
				for (int i = 0; i < this.m_buffInfoList.Count; i++)
				{
					bool flag4 = this.m_buffInfoList[i].Values == null;
					if (!flag4)
					{
						for (int j = 0; j < this.m_buffInfoList[i].Values.Count; j++)
						{
							bool flag5 = array != null && array.Length > j;
							if (flag5)
							{
								float num = Math.Abs((float)this.m_buffInfoList[i].Values[j] * array[j]);
								bool flag6 = array2 != null && array2.Length > j;
								if (flag6)
								{
									this.m_allVaules.Add(string.Format("[{0}]{1}[-]", array2[j], num.ToString("f1")));
								}
								else
								{
									this.m_allVaules.Add(num.ToString("f1"));
								}
							}
							else
							{
								bool flag7 = array2 != null && array2.Length > j;
								if (flag7)
								{
									this.m_allVaules.Add(string.Format("[{0}]{1}[-]", array2[j], this.m_buffInfoList[i].Values[j].ToString("f1")));
								}
								else
								{
									this.m_allVaules.Add(this.m_buffInfoList[i].Values[j].ToString("f1"));
								}
							}
						}
					}
				}
				allVaules = this.m_allVaules;
			}
			return allVaules;
		}

		// Token: 0x040050F5 RID: 20725
		private uint m_effectId;

		// Token: 0x040050F6 RID: 20726
		private uint m_baseProf;

		// Token: 0x040050F7 RID: 20727
		private List<XArtifactBuffInfo> m_buffInfoList;

		// Token: 0x040050F8 RID: 20728
		private List<string> m_allVaules;

		// Token: 0x040050F9 RID: 20729
		private bool m_isValid;
	}
}
