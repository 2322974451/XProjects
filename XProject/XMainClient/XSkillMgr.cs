using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EE6 RID: 3814
	internal sealed class XSkillMgr
	{
		// Token: 0x0600CA88 RID: 51848 RVA: 0x002DEF90 File Offset: 0x002DD190
		public XSkillMgr(XEntity entity)
		{
			this.Initialize(entity);
		}

		// Token: 0x1700355E RID: 13662
		// (get) Token: 0x0600CA89 RID: 51849 RVA: 0x002DEFF0 File Offset: 0x002DD1F0
		public int SkillCount
		{
			get
			{
				return this._core.Count;
			}
		}

		// Token: 0x0600CA8A RID: 51850 RVA: 0x002DF010 File Offset: 0x002DD210
		public XSkillCore GetSkillCore(int index)
		{
			return this._core[index] as XSkillCore;
		}

		// Token: 0x0600CA8B RID: 51851 RVA: 0x002DF034 File Offset: 0x002DD234
		private bool TryGetSkillCore(uint id, out XSkillCore s)
		{
			return this._coreDic.TryGetValue(id, out s);
		}

		// Token: 0x0600CA8C RID: 51852 RVA: 0x002DF054 File Offset: 0x002DD254
		private bool ContainSkillCore(uint id)
		{
			return this._coreDic.ContainsKey(id);
		}

		// Token: 0x0600CA8D RID: 51853 RVA: 0x002DF074 File Offset: 0x002DD274
		public void Initialize(XEntity entity)
		{
			this._host = entity;
			this._physicals.debugName = "XSkillMgr._physicals";
			this._carriers.debugName = "XSkillMgr._carriers";
			this.SkillOrder.debugName = "XSkillMgr.SkillOrder";
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._physicals, 16, 0);
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._carriers, 4, 0);
			int i = 0;
			int num = XSkillData.Skills.Length;
			while (i < num)
			{
				this._carriers.Add(null);
				i++;
			}
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._core, 16, 0);
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this.SkillOrder, 16, 0);
		}

		// Token: 0x0600CA8E RID: 51854 RVA: 0x002DF130 File Offset: 0x002DD330
		public void Uninitialize()
		{
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._physicals);
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this.SkillOrder);
			int i = 0;
			int count = this._carriers.Count;
			while (i < count)
			{
				XSkill xskill = this._carriers[i] as XSkill;
				bool flag = xskill != null;
				if (flag)
				{
					xskill.Uninitialize();
					XSingleton<XSkillFactory>.singleton.ReturnSkill(xskill);
				}
				i++;
			}
			this._carriers.Clear();
			int j = 0;
			int count2 = this._core.Count;
			while (j < count2)
			{
				XSkillCore xskillCore = this._core[j] as XSkillCore;
				bool flag2 = xskillCore != null;
				if (flag2)
				{
					XSingleton<XSkillFactory>.singleton.Release(xskillCore);
				}
				j++;
			}
			this._core.Clear();
			this._coreDic.Clear();
			this._physical = 0U;
			this._ultra = 0U;
			this._appear = 0U;
			this._disappear = 0U;
			this._dash = 0U;
			this._recovery = 0U;
			this._broken = 0U;
		}

		// Token: 0x0600CA8F RID: 51855 RVA: 0x002DF258 File Offset: 0x002DD458
		public void AttachPhysicalSkill(XSkillCore core)
		{
			this._physical = core.ID;
			this.AttachSkill(core, true);
		}

		// Token: 0x0600CA90 RID: 51856 RVA: 0x002DF270 File Offset: 0x002DD470
		public void AttachAppearSkill(XSkillCore core)
		{
			this._appear = core.ID;
			this.AttachSkill(core, false);
		}

		// Token: 0x0600CA91 RID: 51857 RVA: 0x002DF288 File Offset: 0x002DD488
		public void AttachDisappearSkill(XSkillCore core)
		{
			this._disappear = core.ID;
			this.AttachSkill(core, false);
		}

		// Token: 0x0600CA92 RID: 51858 RVA: 0x002DF2A0 File Offset: 0x002DD4A0
		public void AttachUltraSkill(XSkillCore core)
		{
			this._ultra = core.ID;
			this.AttachSkill(core, true);
		}

		// Token: 0x0600CA93 RID: 51859 RVA: 0x002DF2B8 File Offset: 0x002DD4B8
		public void AttachRecoverySkill(XSkillCore core)
		{
			this._recovery = core.ID;
			this.AttachSkill(core, false);
		}

		// Token: 0x0600CA94 RID: 51860 RVA: 0x002DF2D0 File Offset: 0x002DD4D0
		public void AttachBrokenSkill(XSkillCore core)
		{
			this._broken = core.ID;
			this.AttachSkill(core, false);
		}

		// Token: 0x0600CA95 RID: 51861 RVA: 0x002DF2E8 File Offset: 0x002DD4E8
		public void AttachDashSkill(XSkillCore core)
		{
			this._dash = core.ID;
			this.AttachSkill(core, true);
		}

		// Token: 0x0600CA96 RID: 51862 RVA: 0x002DF300 File Offset: 0x002DD500
		public void AttachSkill(XSkillCore core, bool inorder = true)
		{
			bool flag = !this.ContainSkillCore(core.ID);
			if (flag)
			{
				bool flag2 = this._host.Attributes != null;
				if (flag2)
				{
					bool flag3 = core.Level > 0U;
					if (flag3)
					{
						this.SkillBuildIn(core, inorder);
					}
					else
					{
						bool preLoad = XSkillData.PreLoad;
						XSkillData.PreLoad = false;
						bool isSkillReplaced = this._host.Skill.IsSkillReplaced;
						if (isSkillReplaced)
						{
							this.SkillBuildIn(core, inorder);
						}
						XSkillData.PreLoad = preLoad;
					}
				}
				else
				{
					this._core.Add(core);
					this._coreDic.Add(core.ID, core);
					bool flag4 = core.Soul.TypeToken == 3;
					if (flag4)
					{
						for (int i = 0; i < core.Soul.Combined.Count; i++)
						{
							XSkillCore xskillCore = XSingleton<XSkillFactory>.singleton.Build(this._host.IsTransform ? this._host.Transformer.Present.SkillPrefix : this._host.Present.SkillPrefix, core.Soul.Combined[i].Name, this._host);
							bool flag5 = !this.ContainSkillCore(xskillCore.ID);
							if (flag5)
							{
								this._core.Add(xskillCore);
								this._coreDic.Add(xskillCore.ID, xskillCore);
							}
						}
					}
					bool flag6 = core.Soul.TypeToken < this._carriers.Count;
					if (flag6)
					{
						bool flag7 = this._carriers[core.Soul.TypeToken] == null;
						if (flag7)
						{
							this._carriers[core.Soul.TypeToken] = XSingleton<XSkillFactory>.singleton.CreateSkill(this._host, core.Soul.TypeToken);
						}
					}
				}
			}
		}

		// Token: 0x0600CA97 RID: 51863 RVA: 0x002DF504 File Offset: 0x002DD704
		public void DetachSkill(uint id)
		{
			XSkillCore item = null;
			bool flag = this.TryGetSkillCore(id, out item);
			if (flag)
			{
				bool flag2 = id == this._physical;
				if (flag2)
				{
					this._physical = 0U;
				}
				bool flag3 = id == this._ultra;
				if (flag3)
				{
					this._ultra = 0U;
				}
				bool flag4 = id == this._appear;
				if (flag4)
				{
					this._appear = 0U;
				}
				bool flag5 = id == this._disappear;
				if (flag5)
				{
					this._disappear = 0U;
				}
				this.SkillOrder.Remove(item);
				this._core.Remove(id);
				this._coreDic.Remove(id);
				this._physicals.Remove(id);
			}
		}

		// Token: 0x0600CA98 RID: 51864 RVA: 0x002DF5B4 File Offset: 0x002DD7B4
		public XSkill GetCarrier(int id)
		{
			XSkill xskill = null;
			bool flag = id < this._carriers.Count;
			if (flag)
			{
				xskill = (this._carriers[id] as XSkill);
				bool flag2 = xskill == null;
				if (flag2)
				{
					xskill = XSingleton<XSkillFactory>.singleton.CreateSkill(this._host, id);
					this._carriers[id] = xskill;
				}
			}
			bool flag3 = xskill == null;
			if (flag3)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Invalid carrier id: ", id.ToString(), null, null, null, null);
			}
			return xskill;
		}

		// Token: 0x0600CA99 RID: 51865 RVA: 0x002DF640 File Offset: 0x002DD840
		public XSkillCore GetPhysicalSkill()
		{
			return this.GetSkill(this._physical);
		}

		// Token: 0x0600CA9A RID: 51866 RVA: 0x002DF660 File Offset: 0x002DD860
		public XSkillCore GetDashSkill()
		{
			return this.GetSkill(this._dash);
		}

		// Token: 0x0600CA9B RID: 51867 RVA: 0x002DF680 File Offset: 0x002DD880
		public XSkillCore GetSkill(uint id)
		{
			XSkillCore result = null;
			this.TryGetSkillCore(id, out result);
			return result;
		}

		// Token: 0x0600CA9C RID: 51868 RVA: 0x002DF6A0 File Offset: 0x002DD8A0
		public uint GetPhysicalIdentity()
		{
			return this._physical;
		}

		// Token: 0x0600CA9D RID: 51869 RVA: 0x002DF6B8 File Offset: 0x002DD8B8
		public bool IsPhysicalAttack(uint id)
		{
			return this._physicals.Contains(id);
		}

		// Token: 0x0600CA9E RID: 51870 RVA: 0x002DF6D8 File Offset: 0x002DD8D8
		public uint GetUltraIdentity()
		{
			return this._ultra;
		}

		// Token: 0x0600CA9F RID: 51871 RVA: 0x002DF6F0 File Offset: 0x002DD8F0
		public uint GetAppearIdentity()
		{
			return this._appear;
		}

		// Token: 0x0600CAA0 RID: 51872 RVA: 0x002DF708 File Offset: 0x002DD908
		public uint GetDisappearIdentity()
		{
			return this._disappear;
		}

		// Token: 0x0600CAA1 RID: 51873 RVA: 0x002DF720 File Offset: 0x002DD920
		public uint GetDashIdentity()
		{
			return this._dash;
		}

		// Token: 0x0600CAA2 RID: 51874 RVA: 0x002DF738 File Offset: 0x002DD938
		public uint GetRecoveryIdentity()
		{
			return this._recovery;
		}

		// Token: 0x0600CAA3 RID: 51875 RVA: 0x002DF750 File Offset: 0x002DD950
		public uint GetBrokenIdentity()
		{
			return this._broken;
		}

		// Token: 0x0600CAA4 RID: 51876 RVA: 0x002DF768 File Offset: 0x002DD968
		public bool IsCooledDown(XSkillCore skill)
		{
			return skill.CooledDown;
		}

		// Token: 0x0600CAA5 RID: 51877 RVA: 0x002DF780 File Offset: 0x002DD980
		public bool IsCooledDown(uint id)
		{
			return this.IsCooledDown(this.GetSkill(id));
		}

		// Token: 0x0600CAA6 RID: 51878 RVA: 0x002DF7A0 File Offset: 0x002DD9A0
		public bool IsQTESkill(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			return skill != null && skill.Soul.Logical.CanCastAt_QTE > 0;
		}

		// Token: 0x0600CAA7 RID: 51879 RVA: 0x002DF7D4 File Offset: 0x002DD9D4
		public float GetCD(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			return (skill != null) ? skill.GetCoolDown() : 0f;
		}

		// Token: 0x0600CAA8 RID: 51880 RVA: 0x002DF800 File Offset: 0x002DDA00
		public static float GetCD(XEntity entity, string name, uint skillLevel = 0U)
		{
			XSkillData data = XSingleton<XResourceLoaderMgr>.singleton.GetData<XSkillData>(XSingleton<XCommon>.singleton.StringCombine(entity.Present.SkillPrefix, name), ".txt");
			data.Prefix = entity.Present.SkillPrefix;
			uint skillHash = XSingleton<XCommon>.singleton.XHash(data.Name);
			bool flag = skillLevel == 0U;
			if (flag)
			{
				skillLevel = ((entity.Attributes == null) ? 1U : entity.Attributes.SkillLevelInfo.GetSkillLevel(XSingleton<XCommon>.singleton.XHash(data.Name)));
				bool flag2 = skillLevel == 0U;
				if (flag2)
				{
					skillLevel = 1U;
				}
			}
			float num = (data != null) ? (XSingleton<XSkillEffectMgr>.singleton.GetSkillCDStaticRatio(skillHash, skillLevel, entity.SkillCasterTypeID, XSingleton<XScene>.singleton.IsPVPScene) * data.CoolDown) : 0f;
			return entity.IsPlayer ? (num * XSingleton<XSkillEffectMgr>.singleton.GetSkillCDDynamicRatio(entity.Attributes, skillHash)) : num;
		}

		// Token: 0x0600CAA9 RID: 51881 RVA: 0x002DF8EC File Offset: 0x002DDAEC
		public void CoolDown(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			bool flag = skill != null;
			if (flag)
			{
				skill.CoolDown();
			}
		}

		// Token: 0x0600CAAA RID: 51882 RVA: 0x002DF914 File Offset: 0x002DDB14
		public void ResetStaticCD(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			bool flag = skill != null;
			if (flag)
			{
				skill.ResetStaticCD();
			}
		}

		// Token: 0x0600CAAB RID: 51883 RVA: 0x002DF93C File Offset: 0x002DDB3C
		public void AccelerateStaticCD(uint id, float delta)
		{
			XSkillCore skill = this.GetSkill(id);
			bool flag = skill != null;
			if (flag)
			{
				skill.AccelerateStaticCD(delta);
			}
		}

		// Token: 0x0600CAAC RID: 51884 RVA: 0x002DF964 File Offset: 0x002DDB64
		public void Accelerate(uint id, float delta, bool ratio)
		{
			XSkillCore skill = this.GetSkill(id);
			bool flag = skill != null;
			if (flag)
			{
				skill.AccelerateCD(delta, ratio);
			}
		}

		// Token: 0x0600CAAD RID: 51885 RVA: 0x002DF98C File Offset: 0x002DDB8C
		public float GetCastRangeUpper(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			return skill.CastRangeUpper;
		}

		// Token: 0x0600CAAE RID: 51886 RVA: 0x002DF9AC File Offset: 0x002DDBAC
		public float GetCastRangeLower(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			return skill.CastRangeLower;
		}

		// Token: 0x0600CAAF RID: 51887 RVA: 0x002DF9CC File Offset: 0x002DDBCC
		public float GetCastScope(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			return skill.CastScope;
		}

		// Token: 0x0600CAB0 RID: 51888 RVA: 0x002DF9EC File Offset: 0x002DDBEC
		public float GetElapsedCD(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			bool flag = skill == null;
			float result;
			if (flag)
			{
				result = 0f;
			}
			else
			{
				result = skill.GetElapsedCD();
			}
			return result;
		}

		// Token: 0x0600CAB1 RID: 51889 RVA: 0x002DFA20 File Offset: 0x002DDC20
		public float GetMPCost(uint id)
		{
			float result = float.PositiveInfinity;
			bool flag = this.GetSkill(id) != null;
			if (flag)
			{
				XAttributes attributes = this._host.Attributes;
				uint skillLevel = attributes.SkillLevelInfo.GetSkillLevel(id);
				SkillList.RowData skillConfig = XSingleton<XSkillEffectMgr>.singleton.GetSkillConfig(id, skillLevel, this._host.SkillCasterTypeID);
				bool flag2 = skillConfig != null;
				if (flag2)
				{
					result = skillConfig.CostMP[0] + skillConfig.CostMP[1] * skillLevel;
				}
			}
			return result;
		}

		// Token: 0x0600CAB2 RID: 51890 RVA: 0x002DFAAC File Offset: 0x002DDCAC
		public void StatisticsPhysicalSkill()
		{
			this._physicals.Clear();
			XSkillCore xskillCore = this.GetPhysicalSkill();
			while (xskillCore != null)
			{
				this._physicals.Add(xskillCore.ID);
				bool flag = xskillCore.Soul.Logical.Association && !string.IsNullOrEmpty(xskillCore.Soul.Logical.Association_Skill);
				if (flag)
				{
					this._physicals.Add(XSingleton<XCommon>.singleton.XHash(xskillCore.Soul.Logical.Association_Skill));
				}
				bool flag2 = xskillCore.Soul.Ja != null && xskillCore.Soul.Ja.Count > 0;
				if (flag2)
				{
					uint num = XSingleton<XCommon>.singleton.XHash(xskillCore.Soul.Ja[0].Name);
					bool flag3 = num > 0U;
					if (flag3)
					{
						this._physicals.Add(num);
					}
					xskillCore = this.GetSkill(num);
				}
				else
				{
					xskillCore = null;
				}
			}
		}

		// Token: 0x0600CAB3 RID: 51891 RVA: 0x002DFBB8 File Offset: 0x002DDDB8
		public int GetQTE(uint id, out XSkillMgr.XQTEInfo[] qteList)
		{
			bool flag = XSkillMgr.QTEBuffer == null;
			if (flag)
			{
				XSkillMgr.QTEBuffer = new XSkillMgr.XQTEInfo[XSkillMgr.MaxQTECount];
			}
			qteList = XSkillMgr.QTEBuffer;
			int num = 0;
			int i = 0;
			int count = this._core.Count;
			while (i < count)
			{
				XSkillCore xskillCore = this._core[i] as XSkillCore;
				bool flag2 = xskillCore != null && (1 << (int)id & xskillCore.Soul.Logical.CanCastAt_QTE) > 0;
				if (flag2)
				{
					XSkillMgr.XQTEInfo xqteinfo = default(XSkillMgr.XQTEInfo);
					xqteinfo.skill = xskillCore.ID;
					xqteinfo.key = xskillCore.Soul.Logical.QTE_Key;
					qteList[num++] = xqteinfo;
					bool flag3 = num == 4;
					if (flag3)
					{
						return num;
					}
				}
				i++;
			}
			return num;
		}

		// Token: 0x0600CAB4 RID: 51892 RVA: 0x002DFCA0 File Offset: 0x002DDEA0
		private void SkillBuildIn(XSkillCore core, bool inorder)
		{
			bool preLoad = XSkillData.PreLoad;
			if (preLoad)
			{
				XSkillData.PreLoadSkillRes(core.Soul, 1);
			}
			this._core.Add(core);
			this._coreDic.Add(core.ID, core);
			if (inorder)
			{
				bool flag = core.ID != this._physical;
				if (flag)
				{
					this.SkillOrder.Add(core);
				}
			}
			bool flag2 = core.Soul.TypeToken == 3;
			if (flag2)
			{
				for (int i = 0; i < core.Soul.Combined.Count; i++)
				{
					XSkillCore xskillCore = XSingleton<XSkillFactory>.singleton.Build(core.Soul.Prefix, core.Soul.Combined[i].Name, this._host);
					bool flag3 = !this.ContainSkillCore(xskillCore.ID);
					if (flag3)
					{
						bool preLoad2 = XSkillData.PreLoad;
						if (preLoad2)
						{
							XSkillData.PreLoadSkillRes(xskillCore.Soul, 1);
						}
						this._core.Add(xskillCore);
						this._coreDic.Add(xskillCore.ID, xskillCore);
					}
				}
			}
			bool flag4 = core.Soul.TypeToken < this._carriers.Count;
			if (flag4)
			{
				bool flag5 = this._carriers[core.Soul.TypeToken] == null;
				if (flag5)
				{
					this._carriers[core.Soul.TypeToken] = XSingleton<XSkillFactory>.singleton.CreateSkill(this._host, core.Soul.TypeToken);
				}
			}
		}

		// Token: 0x04005997 RID: 22935
		public static XSkillMgr.XQTEInfo[] QTEBuffer;

		// Token: 0x04005998 RID: 22936
		public static int MaxQTECount = 4;

		// Token: 0x04005999 RID: 22937
		private XEntity _host = null;

		// Token: 0x0400599A RID: 22938
		private SmallBuffer<uint> _physicals;

		// Token: 0x0400599B RID: 22939
		private SmallBuffer<object> _carriers;

		// Token: 0x0400599C RID: 22940
		private SmallBuffer<object> _core;

		// Token: 0x0400599D RID: 22941
		private Dictionary<uint, XSkillCore> _coreDic = new Dictionary<uint, XSkillCore>();

		// Token: 0x0400599E RID: 22942
		public SmallBuffer<object> SkillOrder;

		// Token: 0x0400599F RID: 22943
		private uint _physical = 0U;

		// Token: 0x040059A0 RID: 22944
		private uint _ultra = 0U;

		// Token: 0x040059A1 RID: 22945
		private uint _appear = 0U;

		// Token: 0x040059A2 RID: 22946
		private uint _disappear = 0U;

		// Token: 0x040059A3 RID: 22947
		private uint _dash = 0U;

		// Token: 0x040059A4 RID: 22948
		private uint _recovery = 0U;

		// Token: 0x040059A5 RID: 22949
		private uint _broken = 0U;

		// Token: 0x020019E8 RID: 6632
		internal struct XQTEInfo
		{
			// Token: 0x060110D3 RID: 69843 RVA: 0x00456D38 File Offset: 0x00454F38
			public XQTEInfo(int rkey, uint rskill)
			{
				this.key = rkey;
				this.skill = rskill;
			}

			// Token: 0x060110D4 RID: 69844 RVA: 0x00456D49 File Offset: 0x00454F49
			public void Empty()
			{
				this.key = 0;
				this.skill = 0U;
			}

			// Token: 0x04008090 RID: 32912
			public int key;

			// Token: 0x04008091 RID: 32913
			public uint skill;
		}
	}
}
