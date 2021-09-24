using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal struct XArtifactEffectInfo
	{

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

		public uint BaseProf
		{
			get
			{
				return this.m_baseProf;
			}
		}

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

		private uint m_effectId;

		private uint m_baseProf;

		private List<XArtifactBuffInfo> m_buffInfoList;

		private List<string> m_allVaules;

		private bool m_isValid;
	}
}
