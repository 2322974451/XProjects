using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal sealed class XSkillMgr
	{

		public XSkillMgr(XEntity entity)
		{
			this.Initialize(entity);
		}

		public int SkillCount
		{
			get
			{
				return this._core.Count;
			}
		}

		public XSkillCore GetSkillCore(int index)
		{
			return this._core[index] as XSkillCore;
		}

		private bool TryGetSkillCore(uint id, out XSkillCore s)
		{
			return this._coreDic.TryGetValue(id, out s);
		}

		private bool ContainSkillCore(uint id)
		{
			return this._coreDic.ContainsKey(id);
		}

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

		public void AttachPhysicalSkill(XSkillCore core)
		{
			this._physical = core.ID;
			this.AttachSkill(core, true);
		}

		public void AttachAppearSkill(XSkillCore core)
		{
			this._appear = core.ID;
			this.AttachSkill(core, false);
		}

		public void AttachDisappearSkill(XSkillCore core)
		{
			this._disappear = core.ID;
			this.AttachSkill(core, false);
		}

		public void AttachUltraSkill(XSkillCore core)
		{
			this._ultra = core.ID;
			this.AttachSkill(core, true);
		}

		public void AttachRecoverySkill(XSkillCore core)
		{
			this._recovery = core.ID;
			this.AttachSkill(core, false);
		}

		public void AttachBrokenSkill(XSkillCore core)
		{
			this._broken = core.ID;
			this.AttachSkill(core, false);
		}

		public void AttachDashSkill(XSkillCore core)
		{
			this._dash = core.ID;
			this.AttachSkill(core, true);
		}

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

		public XSkillCore GetPhysicalSkill()
		{
			return this.GetSkill(this._physical);
		}

		public XSkillCore GetDashSkill()
		{
			return this.GetSkill(this._dash);
		}

		public XSkillCore GetSkill(uint id)
		{
			XSkillCore result = null;
			this.TryGetSkillCore(id, out result);
			return result;
		}

		public uint GetPhysicalIdentity()
		{
			return this._physical;
		}

		public bool IsPhysicalAttack(uint id)
		{
			return this._physicals.Contains(id);
		}

		public uint GetUltraIdentity()
		{
			return this._ultra;
		}

		public uint GetAppearIdentity()
		{
			return this._appear;
		}

		public uint GetDisappearIdentity()
		{
			return this._disappear;
		}

		public uint GetDashIdentity()
		{
			return this._dash;
		}

		public uint GetRecoveryIdentity()
		{
			return this._recovery;
		}

		public uint GetBrokenIdentity()
		{
			return this._broken;
		}

		public bool IsCooledDown(XSkillCore skill)
		{
			return skill.CooledDown;
		}

		public bool IsCooledDown(uint id)
		{
			return this.IsCooledDown(this.GetSkill(id));
		}

		public bool IsQTESkill(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			return skill != null && skill.Soul.Logical.CanCastAt_QTE > 0;
		}

		public float GetCD(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			return (skill != null) ? skill.GetCoolDown() : 0f;
		}

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

		public void CoolDown(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			bool flag = skill != null;
			if (flag)
			{
				skill.CoolDown();
			}
		}

		public void ResetStaticCD(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			bool flag = skill != null;
			if (flag)
			{
				skill.ResetStaticCD();
			}
		}

		public void AccelerateStaticCD(uint id, float delta)
		{
			XSkillCore skill = this.GetSkill(id);
			bool flag = skill != null;
			if (flag)
			{
				skill.AccelerateStaticCD(delta);
			}
		}

		public void Accelerate(uint id, float delta, bool ratio)
		{
			XSkillCore skill = this.GetSkill(id);
			bool flag = skill != null;
			if (flag)
			{
				skill.AccelerateCD(delta, ratio);
			}
		}

		public float GetCastRangeUpper(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			return skill.CastRangeUpper;
		}

		public float GetCastRangeLower(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			return skill.CastRangeLower;
		}

		public float GetCastScope(uint id)
		{
			XSkillCore skill = this.GetSkill(id);
			return skill.CastScope;
		}

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

		public static XSkillMgr.XQTEInfo[] QTEBuffer;

		public static int MaxQTECount = 4;

		private XEntity _host = null;

		private SmallBuffer<uint> _physicals;

		private SmallBuffer<object> _carriers;

		private SmallBuffer<object> _core;

		private Dictionary<uint, XSkillCore> _coreDic = new Dictionary<uint, XSkillCore>();

		public SmallBuffer<object> SkillOrder;

		private uint _physical = 0U;

		private uint _ultra = 0U;

		private uint _appear = 0U;

		private uint _disappear = 0U;

		private uint _dash = 0U;

		private uint _recovery = 0U;

		private uint _broken = 0U;

		internal struct XQTEInfo
		{

			public XQTEInfo(int rkey, uint rskill)
			{
				this.key = rkey;
				this.skill = rskill;
			}

			public void Empty()
			{
				this.key = 0;
				this.skill = 0U;
			}

			public int key;

			public uint skill;
		}
	}
}
