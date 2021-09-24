using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSkillFactory : XSingleton<XSkillFactory>
	{

		public void OnSceneLoaded()
		{
			this._skillData.debugName = "XSkillCorePool._skillData";
			this._skillCache.debugName = "XSkillCorePool._skillCache";
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._skillData, 256, 0);
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._skillCache, 256, 0);
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._skillMgrCache, 256, 0);
			XSingleton<XBulletMgr>.singleton.OnEnterScene();
		}

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

		public void Print()
		{
			XSingleton<XDebug>.singleton.AddLog("skill core count:", this._skillData.Count.ToString(), null, null, null, null, XDebugColor.XDebug_None);
		}

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

		private SmallBuffer<object> _skillData;

		private SmallBuffer<object> _skillCache;

		private SmallBuffer<object> _skillMgrCache;
	}
}
