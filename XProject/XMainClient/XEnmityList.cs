using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XEnmityList
	{

		public bool IsInited
		{
			get
			{
				return this._inited;
			}
		}

		public bool IsActive
		{
			get
			{
				return this._is_active;
			}
		}

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

		public void Reset()
		{
			this._hatred_list.Clear();
		}

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

		public int CompareHate(Enmity a, Enmity b)
		{
			return b.value.CompareTo(a.value);
		}

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

		public void AddInitHateValue(XEntity entity)
		{
			bool flag = this._hatred_list.Count != 0;
			if (!flag)
			{
				float value = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("InitEnmityValue"));
				this.AddHateValue(entity, value);
			}
		}

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

		public void SetActive(bool active)
		{
			this._is_active = active;
		}

		private List<Enmity> _hatred_list = new List<Enmity>();

		private List<XEntity> _targets = new List<XEntity>();

		private XEntity _host = null;

		private static readonly float OT_VALUE = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("OTValue"));

		private bool _inited = false;

		private bool _is_active = true;

		private DateTime _last_refresh_time = DateTime.Today;
	}
}
