using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D4E RID: 3406
	internal class XEnmityList
	{
		// Token: 0x17003318 RID: 13080
		// (get) Token: 0x0600BC3D RID: 48189 RVA: 0x0026CBB4 File Offset: 0x0026ADB4
		public bool IsInited
		{
			get
			{
				return this._inited;
			}
		}

		// Token: 0x17003319 RID: 13081
		// (get) Token: 0x0600BC3E RID: 48190 RVA: 0x0026CBCC File Offset: 0x0026ADCC
		public bool IsActive
		{
			get
			{
				return this._is_active;
			}
		}

		// Token: 0x0600BC3F RID: 48191 RVA: 0x0026CBE4 File Offset: 0x0026ADE4
		public void Init(XEntity host)
		{
			bool inited = this._inited;
			if (!inited)
			{
				this._host = host;
				this._hatred_list.Clear();
				this._inited = true;
			}
		}

		// Token: 0x0600BC40 RID: 48192 RVA: 0x0026CC18 File Offset: 0x0026AE18
		public void Reset()
		{
			this._hatred_list.Clear();
		}

		// Token: 0x0600BC41 RID: 48193 RVA: 0x0026CC28 File Offset: 0x0026AE28
		public void AddHateValue(XEntity entity, float value)
		{
			bool flag = false;
			float enmityCoefficient = XSingleton<XProfessionSkillMgr>.singleton.GetEnmityCoefficient((int)entity.Attributes.Type);
			float profFixedEnmity = XSingleton<XProfessionSkillMgr>.singleton.GetProfFixedEnmity((int)entity.Attributes.TypeID);
			float num = profFixedEnmity + value * enmityCoefficient * (float)(entity.Attributes.GetAttr(XAttributeDefine.XATTR_ENMITY_Total) / XSingleton<XGlobalConfig>.singleton.GeneralCombatParam);
			for (int i = 0; i < this._hatred_list.Count; i++)
			{
				bool flag2 = this._hatred_list[i].entity == entity;
				if (flag2)
				{
					this._hatred_list[i].value += num;
					this._hatred_list[i].value = Math.Max(this._hatred_list[i].value, 0f);
					flag = true;
					break;
				}
			}
			bool flag3 = !flag;
			if (flag3)
			{
				Enmity enmity = new Enmity();
				enmity.value = Math.Max(num, 0f);
				enmity.entity = entity;
				this._hatred_list.Add(enmity);
			}
			this.UpdateHateList();
		}

		// Token: 0x0600BC42 RID: 48194 RVA: 0x0026CD58 File Offset: 0x0026AF58
		public int CompareHate(Enmity a, Enmity b)
		{
			return b.value.CompareTo(a.value);
		}

		// Token: 0x0600BC43 RID: 48195 RVA: 0x0026CD7C File Offset: 0x0026AF7C
		public void UpdateHateList()
		{
			bool flag = this._hatred_list.Count == 0;
			if (!flag)
			{
				float value = this._hatred_list[0].value;
				int num = 0;
				float num2 = 0f;
				for (int i = 1; i < this._hatred_list.Count; i++)
				{
					bool flag2 = !XEntity.ValideEntity(this._hatred_list[i].entity);
					if (flag2)
					{
						this._hatred_list.RemoveAt(i);
						i--;
					}
				}
				bool flag3 = !XEntity.ValideEntity(this._hatred_list[0].entity);
				if (flag3)
				{
					this._hatred_list.RemoveAt(0);
					this._hatred_list.Sort(new Comparison<Enmity>(this.CompareHate));
				}
				else
				{
					for (int j = 1; j < this._hatred_list.Count; j++)
					{
						bool flag4 = num == 0;
						if (flag4)
						{
							bool flag5 = this._hatred_list[j].value > value * XEnmityList.OT_VALUE;
							if (flag5)
							{
								num = j;
								num2 = this._hatred_list[j].value;
							}
						}
						else
						{
							bool flag6 = this._hatred_list[j].value > num2;
							if (flag6)
							{
								num = j;
								num2 = this._hatred_list[j].value;
							}
						}
					}
					bool flag7 = num != 0;
					if (flag7)
					{
						Enmity value2 = this._hatred_list[0];
						this._hatred_list[0] = this._hatred_list[num];
						this._hatred_list[num] = value2;
					}
					Enmity item = this._hatred_list[0];
					List<Enmity> hatred_list = this._hatred_list;
					hatred_list.RemoveAt(0);
					this._hatred_list.Sort(new Comparison<Enmity>(this.CompareHate));
					this._hatred_list.Insert(0, item);
					bool flag8 = (DateTime.Now - this._last_refresh_time).Seconds < 1;
					if (!flag8)
					{
						this._last_refresh_time = DateTime.Now;
					}
				}
			}
		}

		// Token: 0x0600BC44 RID: 48196 RVA: 0x0026CFB8 File Offset: 0x0026B1B8
		public void AddInitHateValue(XEntity entity)
		{
			bool flag = this._hatred_list.Count != 0;
			if (!flag)
			{
				float value = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("InitEnmityValue"));
				this.AddHateValue(entity, value);
			}
		}

		// Token: 0x0600BC45 RID: 48197 RVA: 0x0026CFF8 File Offset: 0x0026B1F8
		public List<XEntity> GetHateEntity(bool filterImmortal = false)
		{
			this._targets.Clear();
			this.UpdateHateList();
			bool flag = this._hatred_list.Count == 0;
			List<XEntity> targets;
			if (flag)
			{
				targets = this._targets;
			}
			else
			{
				bool flag2 = !this._is_active;
				if (flag2)
				{
					targets = this._targets;
				}
				else
				{
					if (filterImmortal)
					{
						float num = 0f;
						for (int i = 0; i < this._hatred_list.Count; i++)
						{
							bool flag3 = this._hatred_list[i].entity.Buffs == null || !this._hatred_list[i].entity.Buffs.IsBuffStateOn(XBuffType.XBuffType_Immortal);
							if (flag3)
							{
								bool flag4 = num == 0f;
								if (flag4)
								{
									num = this._hatred_list[i].value;
									this._targets.Add(this._hatred_list[i].entity);
								}
								else
								{
									bool flag5 = num == this._hatred_list[i].value;
									if (flag5)
									{
										this._targets.Add(this._hatred_list[i].entity);
									}
								}
							}
						}
					}
					else
					{
						float num2 = 0f;
						for (int j = 0; j < this._hatred_list.Count; j++)
						{
							bool flag6 = num2 == 0f;
							if (flag6)
							{
								num2 = this._hatred_list[j].value;
								this._targets.Add(this._hatred_list[j].entity);
							}
							else
							{
								bool flag7 = num2 == this._hatred_list[j].value;
								if (flag7)
								{
									this._targets.Add(this._hatred_list[j].entity);
								}
							}
						}
					}
					targets = this._targets;
				}
			}
			return targets;
		}

		// Token: 0x0600BC46 RID: 48198 RVA: 0x0026D20E File Offset: 0x0026B40E
		public void SetActive(bool active)
		{
			this._is_active = active;
		}

		// Token: 0x04004C55 RID: 19541
		private List<Enmity> _hatred_list = new List<Enmity>();

		// Token: 0x04004C56 RID: 19542
		private List<XEntity> _targets = new List<XEntity>();

		// Token: 0x04004C57 RID: 19543
		private XEntity _host = null;

		// Token: 0x04004C58 RID: 19544
		private static readonly float OT_VALUE = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("OTValue"));

		// Token: 0x04004C59 RID: 19545
		private bool _inited = false;

		// Token: 0x04004C5A RID: 19546
		private bool _is_active = true;

		// Token: 0x04004C5B RID: 19547
		private DateTime _last_refresh_time = DateTime.Today;
	}
}
