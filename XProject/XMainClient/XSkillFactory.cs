using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B89 RID: 2953
	internal class XSkillFactory : XSingleton<XSkillFactory>
	{
		// Token: 0x0600A985 RID: 43397 RVA: 0x001E3244 File Offset: 0x001E1444
		public void OnSceneLoaded()
		{
			this._skillData.debugName = "XSkillCorePool._skillData";
			this._skillCache.debugName = "XSkillCorePool._skillCache";
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._skillData, 256, 0);
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._skillCache, 256, 0);
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._skillMgrCache, 256, 0);
			XSingleton<XBulletMgr>.singleton.OnEnterScene();
		}

		// Token: 0x0600A986 RID: 43398 RVA: 0x001E32C4 File Offset: 0x001E14C4
		public void OnLeaveScene()
		{
			bool isInit = this._skillData.IsInit;
			if (isInit)
			{
				int i = 0;
				int count = this._skillData.Count;
				while (i < count)
				{
					XSkillCore xskillCore = this._skillData[i] as XSkillCore;
					bool flag = xskillCore != null;
					if (flag)
					{
						xskillCore.Clear();
					}
					i++;
				}
			}
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._skillData);
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._skillCache);
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._skillMgrCache);
			XSingleton<XBulletMgr>.singleton.OnLeaveScene();
		}

		// Token: 0x0600A987 RID: 43399 RVA: 0x001E3368 File Offset: 0x001E1568
		public XSkillCore Build(string skillprefix, string name, XEntity firer)
		{
			string text = skillprefix + name;
			uint num = XSingleton<XCommon>.singleton.XHash(text);
			XSkillCore xskillCore = firer.SkillMgr.GetSkill(XSingleton<XCommon>.singleton.XHash(name));
			bool flag = xskillCore != null;
			XSkillCore result;
			if (flag)
			{
				result = xskillCore;
			}
			else
			{
				int i = 0;
				int count = this._skillData.Count;
				while (i < count)
				{
					XSkillCore xskillCore2 = this._skillData[i] as XSkillCore;
					bool flag2 = xskillCore2 != null && num == xskillCore2.LongID;
					if (flag2)
					{
						xskillCore2.Recycle(firer);
						this._skillData[i] = null;
						bool flag3 = XSingleton<XScene>.singleton.IsPVPScene && !xskillCore2.IsPvPVersion;
						if (flag3)
						{
							bool flag4 = !string.IsNullOrEmpty(xskillCore2.Soul.PVP_Script_Name);
							if (flag4)
							{
								XSkillData data = XSingleton<XResourceLoaderMgr>.singleton.GetData<XSkillData>(skillprefix + xskillCore2.Soul.PVP_Script_Name, ".txt");
								data.Prefix = skillprefix;
								data.Name = xskillCore2.Soul.Name;
								xskillCore2.SoulRefine(data, true);
							}
						}
						else
						{
							bool flag5 = !XSingleton<XScene>.singleton.IsPVPScene && xskillCore2.IsPvPVersion;
							if (flag5)
							{
								XSkillData data2 = XSingleton<XResourceLoaderMgr>.singleton.GetData<XSkillData>(skillprefix + xskillCore2.Soul.Name, ".txt");
								data2.Prefix = skillprefix;
								xskillCore2.SoulRefine(data2, false);
							}
						}
						return xskillCore2;
					}
					i++;
				}
				XSkillData data3 = XSingleton<XResourceLoaderMgr>.singleton.GetData<XSkillData>(text, ".txt");
				data3.Prefix = skillprefix;
				xskillCore = new XSkillCore(firer, data3, num);
				bool flag6 = XSingleton<XScene>.singleton.IsPVPScene && !string.IsNullOrEmpty(xskillCore.Soul.PVP_Script_Name);
				if (flag6)
				{
					XSkillData data4 = XSingleton<XResourceLoaderMgr>.singleton.GetData<XSkillData>(skillprefix + xskillCore.Soul.PVP_Script_Name, ".txt");
					data4.Prefix = skillprefix;
					data4.Name = xskillCore.Soul.Name;
					xskillCore.SoulRefine(data4, true);
				}
				switch (xskillCore.Soul.TypeToken)
				{
				case 0:
					xskillCore.TriggerToken = XSkillData.JA_Command[xskillCore.Soul.SkillPosition];
					break;
				case 1:
					xskillCore.TriggerToken = "ToArtSkill";
					xskillCore.Soul.Ja = null;
					break;
				case 2:
					xskillCore.TriggerToken = "ToUltraShow";
					xskillCore.Soul.Ja = null;
					break;
				case 3:
					xskillCore.TriggerToken = "ToPhase";
					xskillCore.Soul.Ja = null;
					break;
				}
				bool multipleAttackSupported = xskillCore.Soul.MultipleAttackSupported;
				if (multipleAttackSupported)
				{
					xskillCore.TriggerToken = "ToMultipleDirAttack";
				}
				result = xskillCore;
			}
			return result;
		}

		// Token: 0x0600A988 RID: 43400 RVA: 0x001E3654 File Offset: 0x001E1854
		public void Release(XSkillCore core)
		{
			core.CoolDown();
			core.Uninit();
			int i = 0;
			int count = this._skillData.Count;
			while (i < count)
			{
				bool flag = this._skillData[i] == null;
				if (flag)
				{
					this._skillData[i] = core;
					return;
				}
				i++;
			}
			this._skillData.Add(core);
		}

		// Token: 0x0600A989 RID: 43401 RVA: 0x001E36C0 File Offset: 0x001E18C0
		public void Print()
		{
			XSingleton<XDebug>.singleton.AddLog("skill core count:", this._skillData.Count.ToString(), null, null, null, null, XDebugColor.XDebug_None);
		}

		// Token: 0x0600A98A RID: 43402 RVA: 0x001E36F8 File Offset: 0x001E18F8
		public string GetTypeName(int token)
		{
			bool flag = token < XSkillData.Skills.Length;
			string result;
			if (flag)
			{
				result = XSkillData.Skills[token];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600A98B RID: 43403 RVA: 0x001E3724 File Offset: 0x001E1924
		public int GetTypeHash(int token)
		{
			int result;
			switch (token)
			{
			case 0:
				result = XSkill.XJAComboSkillHash;
				break;
			case 1:
				result = XSkill.XArtsSkillHash;
				break;
			case 2:
				result = XSkill.XUltraSkillHash;
				break;
			case 3:
				result = XSkill.XCombinedSkillHash;
				break;
			default:
				throw new ArgumentException();
			}
			return result;
		}

		// Token: 0x0600A98C RID: 43404 RVA: 0x001E3774 File Offset: 0x001E1974
		public XSkill CreateSkill(XEntity firer, int token)
		{
			int i = 0;
			int count = this._skillCache.Count;
			while (i < count)
			{
				XSkill xskill = this._skillCache[i] as XSkill;
				bool flag = xskill != null && xskill.SkillType == token;
				if (flag)
				{
					this._skillCache[i] = null;
					xskill.Initialize(firer);
					return xskill;
				}
				i++;
			}
			XSkill xskill2;
			switch (token)
			{
			case 0:
				xskill2 = new XJAComboSkill();
				break;
			case 1:
				xskill2 = new XArtsSkill();
				break;
			case 2:
				xskill2 = new XUltraSkill();
				break;
			case 3:
				xskill2 = new XCombinedSkill();
				break;
			default:
				return null;
			}
			xskill2.Initialize(firer);
			return xskill2;
		}

		// Token: 0x0600A98D RID: 43405 RVA: 0x001E3838 File Offset: 0x001E1A38
		public void ReturnSkill(XSkill skill)
		{
			int i = 0;
			int count = this._skillCache.Count;
			while (i < count)
			{
				bool flag = this._skillCache[i] == null;
				if (flag)
				{
					this._skillCache[i] = skill;
					return;
				}
				i++;
			}
			this._skillCache.Add(skill);
		}

		// Token: 0x0600A98E RID: 43406 RVA: 0x001E3898 File Offset: 0x001E1A98
		public XSkillMgr CreateSkillMgr(XEntity entity)
		{
			int i = 0;
			int count = this._skillMgrCache.Count;
			while (i < count)
			{
				XSkillMgr xskillMgr = this._skillMgrCache[i] as XSkillMgr;
				bool flag = xskillMgr != null;
				if (flag)
				{
					this._skillMgrCache[i] = null;
					xskillMgr.Initialize(entity);
					return xskillMgr;
				}
				i++;
			}
			return new XSkillMgr(entity);
		}

		// Token: 0x0600A98F RID: 43407 RVA: 0x001E3908 File Offset: 0x001E1B08
		public void ReturnSkillMgr(XSkillMgr skillMgr)
		{
			bool flag = skillMgr != null;
			if (flag)
			{
				skillMgr.Uninitialize();
				int i = 0;
				int count = this._skillMgrCache.Count;
				while (i < count)
				{
					bool flag2 = this._skillMgrCache[i] == null;
					if (flag2)
					{
						this._skillCache[i] = skillMgr;
						return;
					}
					i++;
				}
				this._skillMgrCache.Add(skillMgr);
			}
		}

		// Token: 0x04003EAF RID: 16047
		private SmallBuffer<object> _skillData;

		// Token: 0x04003EB0 RID: 16048
		private SmallBuffer<object> _skillCache;

		// Token: 0x04003EB1 RID: 16049
		private SmallBuffer<object> _skillMgrCache;
	}
}
