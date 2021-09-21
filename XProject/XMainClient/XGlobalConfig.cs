using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000FEC RID: 4076
	public class XGlobalConfig : XSingleton<XGlobalConfig>
	{
		// Token: 0x0600D40A RID: 54282 RVA: 0x0031E330 File Offset: 0x0031C530
		public override bool Init()
		{
			bool flag = this._async_loader == null;
			if (flag)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/GlobalConfig", this._table, false);
				this._async_loader.Execute(null);
			}
			bool flag2 = !this._async_loader.IsDone;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
				XGame.RoleCount = int.Parse(this.GetValue("MaxRole"));
				this.ElemDefLimit = double.Parse(this.GetValue("ElemDefLimit"));
				this.ElemAtkLimit = double.Parse(this.GetValue("ElemAtkLimit"));
				this.CritDamageBase = double.Parse(this.GetValue("CritDamageBase"));
				this.FinalDamageLimit = double.Parse(this.GetValue("FinalDamageLimit"));
				this.StunResistLimit = double.Parse(this.GetValue("StunResistLimit"));
				this.StunLimit = double.Parse(this.GetValue("StunLimit"));
				this.ParaResistLimit = double.Parse(this.GetValue("ParaResistLimit"));
				this.ParalyzeLimit = double.Parse(this.GetValue("ParalyzeLimit"));
				this.CritResistLimit = double.Parse(this.GetValue("CritResistLimit"));
				this.CriticalLimit = double.Parse(this.GetValue("CriticalLimit"));
				this.GeneralCombatParam = double.Parse(this.GetValue("GeneralCombatParam"));
				this.AttrChangeDamageLimit = double.Parse(this.GetValue("AttrChangeDamageLimit"));
				string[] array = this.GetValue("CDChangeLimit").Split(XGlobalConfig.SequenceSeparator);
				this.CDChangeLowerBound = float.Parse(array[0]);
				this.CDChangeUpperBound = float.Parse(array[1]);
				string[] array2 = this.GetValue("AttackSpeedLimit").Split(XGlobalConfig.SequenceSeparator);
				this.AttackSpeedLowerBound = double.Parse(array2[0]);
				this.AttackSpeedUpperBound = double.Parse(array2[1]);
				string[] array3 = this.GetValue("CritDamageLimit").Split(XGlobalConfig.SequenceSeparator);
				this.CritDamageLowerBound = double.Parse(array3[0]);
				this.CritDamageUpperBound = double.Parse(array3[1]);
				string[] array4 = this.GetValue("DamageRandomRange").Split(XGlobalConfig.SequenceSeparator);
				this.DamageRandomLowerBound = float.Parse(array4[0]);
				this.DamageRandomUpperBound = float.Parse(array4[1]);
				this.StunTime = float.Parse(this.GetValue("StunTime"));
				this.AccelerationUp = new float[XGame.RoleCount];
				this.AccelerationDown = new float[XGame.RoleCount];
				string[] array5 = this.GetValue("AccelerationUp").Split(XGlobalConfig.ListSeparator);
				for (int i = 0; i < XGame.RoleCount; i++)
				{
					this.AccelerationUp[i] = float.Parse(array5[i]);
				}
				array5 = this.GetValue("AccelerationDown").Split(XGlobalConfig.ListSeparator);
				for (int j = 0; j < XGame.RoleCount; j++)
				{
					this.AccelerationDown[j] = float.Parse(array5[j]);
				}
				this.Hit_PresentStraight = float.Parse(this.GetValue("PresentStraight"));
				this.Hit_HardStraight = float.Parse(this.GetValue("HardStraight"));
				this.Hit_Offset = float.Parse(this.GetValue("Offset"));
				this.Hit_Height = float.Parse(this.GetValue("Height"));
				this.CloseUpCameraSpeed = float.Parse(this.GetValue("CloseUpCameraSpeed"));
				this.NewbieLevelRoleID = new uint[XGame.RoleCount];
				string[] array6 = this.GetValue("NewbieLevelRoleID").Split(XGlobalConfig.ListSeparator);
				for (int k = 0; k < XGame.RoleCount; k++)
				{
					this.NewbieLevelRoleID[k] = uint.Parse(array6[k]);
				}
				string[] array7 = this.GetValue("EntitySummonGroupLimit").Split(XGlobalConfig.ListSeparator);
				this.EntitySummonGroupLimit = new int[array7.Length + 1];
				for (int l = 1; l <= array7.Length; l++)
				{
					this.EntitySummonGroupLimit[l] = int.Parse(array7[l - 1]);
				}
				string[] array8 = this.GetValue("CameraAdjustScopeExceptSkills").Split(XGlobalConfig.ListSeparator);
				for (int m = 0; m < array8.Length; m++)
				{
					this.CameraAdjustScopeExceptSkills.Add(XSingleton<XCommon>.singleton.XHash(array8[m]));
				}
				string[] array9 = this.GetValue("NumberSeparator").Split(XGlobalConfig.ListSeparator);
				this.NumberSeparators = new ulong[array9.Length];
				for (int n = 0; n < array9.Length; n++)
				{
					this.NumberSeparators[n] = ulong.Parse(array9[n]);
				}
				this.MinSeparateNum = ulong.Parse(this.GetValue("MinSeparateNum"));
				this.PINGInterval = int.Parse(this.GetValue("PINGInterval"));
				this.ScreenSaveLimit = float.Parse(this.GetValue("ScreenSaveLimit"));
				this.ScreenSavePercentage = int.Parse(this.GetValue("ScreenSavePercentage"));
				this.MaxGetGuildCheckInBonusNum = int.Parse(this.GetValue("MaxGetGuildCheckInBonusNum"));
				this.BuffMinAuraInterval = float.Parse(this.GetValue("BuffMinAuraInterval"));
				this.BuffMinRegenerateInterval = float.Parse(this.GetValue("BuffMinRegenerateInterval"));
				this.StudentMinLevel = int.Parse(this.GetValue("GuildInheritRoleLvlLow"));
				this.TeacherMinLevel = int.Parse(this.GetValue("GuildInheritRoleLvlHig"));
				List<uint> uintList = this.GetUIntList("BuffMaxDisplayCount");
				bool flag3 = uintList.Count != 3;
				if (flag3)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("BuffMaxDisplayCount should be 3: ", uintList.ToString(), null, null, null, null);
				}
				else
				{
					this.BuffMaxDisplayCountPlayer = uintList[0];
					this.BuffMaxDisplayCountTeam = uintList[1];
					this.BuffMaxDisplayCountBoss = uintList[2];
				}
				this.BuffMaxDisplayTime = float.Parse(this.GetValue("BuffMaxDisplayTime"));
				string text = "";
				bool value = this.GetValue("SpriteOffset", out text);
				if (value)
				{
					string[] array10 = text.Split(XGlobalConfig.ListSeparator);
					bool flag4 = array10.Length != 0;
					if (flag4)
					{
						this.SpriteOffset.x = float.Parse(array10[0]);
						bool flag5 = array10.Length > 1;
						if (flag5)
						{
							this.SpriteOffset.y = float.Parse(array10[1]);
							bool flag6 = array10.Length > 2;
							if (flag6)
							{
								this.SpriteOffset.z = float.Parse(array10[2]);
							}
						}
					}
				}
				string[] array11 = this.GetValue("ViewGridScene").Split(XGlobalConfig.ListSeparator);
				for (int num = 0; num < array11.Length; num++)
				{
					this.ViewGridScene.Add(int.Parse(array11[num]));
				}
				this.ProShowTurnInterval = float.Parse(this.GetValue("ProShowTurnInterval"));
				this.DefaultIconWidth = uint.Parse(this.GetValue("DefaultIconWidth"));
				string[] array12 = this.GetValue("Gyro").Split(XGlobalConfig.ListSeparator);
				this.GyroScale = float.Parse(array12[0]);
				this.GyroDeadZone = float.Parse(array12[1]);
				this.GyroFrequency = float.Parse(array12[2]);
				string[] array13 = this.GetValue("EquipPosType").Split(XGlobalConfig.ListSeparator);
				bool flag7 = array13.Length != XBagDocument.EquipMax;
				if (flag7)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("EquipPosType Length Error: ", array13.Length.ToString(), null, null, null, null);
				}
				this.MaxEquipPosType = 0;
				for (int num2 = 0; num2 < array13.Length; num2++)
				{
					this.EquipPosType[num2] = int.Parse(array13[num2]);
					this.MaxEquipPosType = Math.Max(this.MaxEquipPosType, this.EquipPosType[num2]);
				}
				this.LoginBlockTime = uint.Parse(this.GetValue("LoginBlockTime"));
				string text2;
				bool value2 = this.GetValue("SettingEnum", out text2);
				if (value2)
				{
					bool flag8 = text2.StartsWith("0x");
					if (flag8)
					{
						text2 = text2.Substring(2).Replace(",", "");
						this.SettingEnum = Convert.ToUInt32(text2, 2);
					}
					else
					{
						this.SettingEnum = Convert.ToUInt32(text2);
					}
				}
				text2 = "";
				bool flag9 = this.GetValue("EmptyPrefab", out text2) && !string.IsNullOrEmpty(text2);
				if (flag9)
				{
					this.EmptyPrefab = text2.Split(XGlobalConfig.ListSeparator);
				}
				text2 = "";
				bool flag10 = this.GetValue("SelectPos", out text2) && !string.IsNullOrEmpty(text2);
				if (flag10)
				{
					string[] array14 = text2.Split(new char[]
					{
						','
					});
					bool flag11 = array14 != null && array14.Length != 0;
					if (flag11)
					{
						int num3 = array14.Length;
						bool flag12 = num3 % 3 == 0;
						if (flag12)
						{
							this.SelectPos = new Vector3[num3 / 3];
							for (int num4 = 0; num4 < this.SelectPos.Length; num4++)
							{
								Vector3 vector = default(Vector3);
								float num5 = 0f;
								float.TryParse(array14[num4 * 3], out num5);
								vector.x = num5;
								num5 = 0f;
								float.TryParse(array14[num4 * 3 + 1], out num5);
								vector.y = num5;
								num5 = 0f;
								float.TryParse(array14[num4 * 3 + 2], out num5);
								vector.z = num5;
								this.SelectPos[num4] = vector;
							}
						}
					}
				}
				text2 = "";
				bool flag13 = this.GetValue("MobMovePos", out text2) && !string.IsNullOrEmpty(text2);
				if (flag13)
				{
					string[] array15 = text2.Split(XGlobalConfig.AllSeparators);
					bool flag14 = array15 != null && array15.Length != 0;
					if (flag14)
					{
						int num6 = array15.Length;
						bool flag15 = num6 % 3 == 0;
						if (flag15)
						{
							this.MobMovePos = new Vector3[num6 / 3];
							for (int num7 = 0; num7 < this.MobMovePos.Length; num7++)
							{
								Vector3 vector2 = default(Vector3);
								float num8 = 0f;
								float.TryParse(array15[num7 * 3], out num8);
								vector2.x = num8;
								num8 = 0f;
								float.TryParse(array15[num7 * 3 + 1], out num8);
								vector2.y = num8;
								num8 = 0f;
								float.TryParse(array15[num7 * 3 + 2], out num8);
								vector2.z = num8;
								this.MobMovePos[num7] = vector2;
							}
						}
					}
				}
				this.MobaTowerFxOffset = float.Parse(this.GetValue("MobaTowerFxOffset"));
				this.BlockFashionProfs.Clear();
				string[] array16 = this.GetValue("BlockFashionProfs").Split(XGlobalConfig.ListSeparator);
				for (int num9 = 0; num9 < array16.Length; num9++)
				{
					this.BlockFashionProfs.Add(uint.Parse(array16[num9]));
				}
				XBuffComponent.InitConfigs();
				HomeSpriteClass.InitPosList();
				XProfessionSkillMgr.InitFromGlobalConfig();
				XEnchantDocument.InitFromGlobalConfig();
				XCharacterItemDocument.InitFromGlobalConfig();
				XSingleton<XCombatEffectManager>.singleton.InitFromGlobalConfig();
				XCharacterItemDocument.InitTabList();
				XQualitySetting.VisibleRoleCountPerLevel = (this.GetInt("ViewGridCount") + 2) / 4;
				result = true;
			}
			return result;
		}

		// Token: 0x0600D40B RID: 54283 RVA: 0x0031EED4 File Offset: 0x0031D0D4
		public override void Uninit()
		{
			this._async_loader = null;
		}

		// Token: 0x0600D40C RID: 54284 RVA: 0x0031EEE0 File Offset: 0x0031D0E0
		public string GetValue(string key)
		{
			string text = "";
			uint key2 = XSingleton<XCommon>.singleton.XHash(key);
			bool flag = this._table.Table.TryGetValue(key2, out text);
			string result;
			if (flag)
			{
				result = text;
			}
			else
			{
				result = text;
			}
			return result;
		}

		// Token: 0x0600D40D RID: 54285 RVA: 0x0031EF24 File Offset: 0x0031D124
		public bool GetValue(string key, out string value)
		{
			uint key2 = XSingleton<XCommon>.singleton.XHash(key);
			return this._table.Table.TryGetValue(key2, out value);
		}

		// Token: 0x0600D40E RID: 54286 RVA: 0x0031EF60 File Offset: 0x0031D160
		public string[] GetAndSeparateValue(string key, char[] separator)
		{
			return this.GetValue(key).Split(separator);
		}

		// Token: 0x0600D40F RID: 54287 RVA: 0x0031EF80 File Offset: 0x0031D180
		public int GetInt(string key)
		{
			string s = "";
			bool value = this.GetValue(key, out s);
			int result;
			if (value)
			{
				result = int.Parse(s);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600D410 RID: 54288 RVA: 0x0031EFB0 File Offset: 0x0031D1B0
		private SeqList<int> GetSequenceList(string key, short dim, bool tmp = true)
		{
			string[] array = this.GetValue(key).Split(XGlobalConfig.AllSeparators);
			bool flag = array.Length == 0 || array.Length % (int)dim != 0;
			SeqList<int> result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("XGlobalConfig GetSequenceList Error! key is ", key, null, null, null, null);
				result = this.emptySeqList;
			}
			else
			{
				SeqList<int> seqList;
				if (tmp)
				{
					seqList = this.tmpSeqList;
					seqList.Reset(dim, (short)(array.Length / (int)dim));
				}
				else
				{
					seqList = new SeqList<int>(dim, (short)(array.Length / (int)dim));
				}
				for (int i = 0; i < array.Length; i += (int)dim)
				{
					for (int j = 0; j < (int)dim; j++)
					{
						seqList[i / (int)dim, j] = int.Parse(array[i + j]);
					}
				}
				result = seqList;
			}
			return result;
		}

		// Token: 0x0600D411 RID: 54289 RVA: 0x0031F088 File Offset: 0x0031D288
		public SeqList<int> GetSequenceList(string key, bool tmp)
		{
			return this.GetSequenceList(key, 2, tmp);
		}

		// Token: 0x0600D412 RID: 54290 RVA: 0x0031F0A4 File Offset: 0x0031D2A4
		public SeqList<int> GetSequence3List(string key, bool tmp)
		{
			return this.GetSequenceList(key, 3, tmp);
		}

		// Token: 0x0600D413 RID: 54291 RVA: 0x0031F0C0 File Offset: 0x0031D2C0
		public SeqList<int> GetSequence4List(string key, bool tmp)
		{
			return this.GetSequenceList(key, 4, tmp);
		}

		// Token: 0x0600D414 RID: 54292 RVA: 0x0031F0DC File Offset: 0x0031D2DC
		public List<int> GetIntList(string key)
		{
			List<int> list = new List<int>();
			string[] array = this.GetValue(key).Split(XGlobalConfig.ListSeparator);
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(int.Parse(array[i]));
			}
			return list;
		}

		// Token: 0x0600D415 RID: 54293 RVA: 0x0031F12C File Offset: 0x0031D32C
		public void GetIntList(string key, List<int> list)
		{
			string value = this.GetValue(key);
			bool flag = !string.IsNullOrEmpty(value);
			if (flag)
			{
				string[] array = value.Split(XGlobalConfig.ListSeparator);
				for (int i = 0; i < array.Length; i++)
				{
					list.Add(int.Parse(array[i]));
				}
			}
		}

		// Token: 0x0600D416 RID: 54294 RVA: 0x0031F184 File Offset: 0x0031D384
		public List<uint> GetUIntList(string key)
		{
			List<uint> list = new List<uint>();
			string[] array = this.GetValue(key).Split(XGlobalConfig.ListSeparator);
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(uint.Parse(array[i]));
			}
			return list;
		}

		// Token: 0x0600D417 RID: 54295 RVA: 0x0031F1D4 File Offset: 0x0031D3D4
		public List<string> GetStringList(string key)
		{
			List<string> list = new List<string>();
			string[] array = this.GetValue(key).Split(XGlobalConfig.ListSeparator);
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
			return list;
		}

		// Token: 0x0600D418 RID: 54296 RVA: 0x0031F220 File Offset: 0x0031D420
		public SeqList<string> GetStringSeqList(string key)
		{
			string[] array = this.GetValue(key).Split(XGlobalConfig.AllSeparators);
			SeqList<string> seqList = new SeqList<string>(2, (short)(array.Length / 2));
			bool flag = array.Length == 0 || array.Length % 2 != 0;
			SeqList<string> result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("XGlobalConfig GetSequenceList Error! key is ", key, null, null, null, null);
				result = seqList;
			}
			else
			{
				for (int i = 0; i < array.Length; i += 2)
				{
					for (int j = 0; j < 2; j++)
					{
						seqList[i / 2, j] = array[i + j];
					}
				}
				result = seqList;
			}
			return result;
		}

		// Token: 0x0600D419 RID: 54297 RVA: 0x0031F2C8 File Offset: 0x0031D4C8
		public void GetFloatList(string key, ref float[] floatList)
		{
			string[] array = this.GetValue(key).Split(XGlobalConfig.ListSeparator);
			bool flag = array.Length != 0;
			if (flag)
			{
				floatList = new float[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					floatList[i] = float.Parse(array[i]);
				}
			}
		}

		// Token: 0x0600D41A RID: 54298 RVA: 0x0031F320 File Offset: 0x0031D520
		public List<float> GetFloatList(string key)
		{
			List<float> list = new List<float>();
			string[] array = this.GetValue(key).Split(XGlobalConfig.ListSeparator);
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(float.Parse(array[i]));
			}
			return list;
		}

		// Token: 0x0600D41B RID: 54299 RVA: 0x0031F370 File Offset: 0x0031D570
		public bool GetSettingEnum(ESettingConfig sc)
		{
			uint settingEnum = XSingleton<XGlobalConfig>.singleton.SettingEnum;
			return ((ulong)settingEnum & (ulong)((long)XFastEnumIntEqualityComparer<ESettingConfig>.ToInt(sc))) > 0UL;
		}

		// Token: 0x0600D41C RID: 54300 RVA: 0x0031F39C File Offset: 0x0031D59C
		public string PreFilterPrefab(string location)
		{
			bool flag = this.EmptyPrefab == null;
			string result;
			if (flag)
			{
				result = location;
			}
			else
			{
				for (int i = 0; i < this.EmptyPrefab.Length; i++)
				{
					bool flag2 = location.EndsWith(this.EmptyPrefab[i]);
					if (flag2)
					{
						return "";
					}
				}
				result = location;
			}
			return result;
		}

		// Token: 0x0400607A RID: 24698
		public static readonly char[] SequenceSeparator = new char[]
		{
			'='
		};

		// Token: 0x0400607B RID: 24699
		public static readonly char[] ListSeparator = new char[]
		{
			'|'
		};

		// Token: 0x0400607C RID: 24700
		public static readonly char[] AllSeparators = new char[]
		{
			'|',
			'='
		};

		// Token: 0x0400607D RID: 24701
		public static readonly char[] SpaceSeparator = new char[]
		{
			' '
		};

		// Token: 0x0400607E RID: 24702
		public static readonly char[] TabSeparator = new char[]
		{
			' ',
			'\t'
		};

		// Token: 0x0400607F RID: 24703
		private XTableAsyncLoader _async_loader = null;

		// Token: 0x04006080 RID: 24704
		private GlobalTable _table = new GlobalTable();

		// Token: 0x04006081 RID: 24705
		public double CriticalLimit;

		// Token: 0x04006082 RID: 24706
		public double CritResistLimit;

		// Token: 0x04006083 RID: 24707
		public double ParalyzeLimit;

		// Token: 0x04006084 RID: 24708
		public double ParaResistLimit;

		// Token: 0x04006085 RID: 24709
		public double StunLimit;

		// Token: 0x04006086 RID: 24710
		public double StunResistLimit;

		// Token: 0x04006087 RID: 24711
		public double FinalDamageLimit;

		// Token: 0x04006088 RID: 24712
		public double CritDamageBase;

		// Token: 0x04006089 RID: 24713
		public double ElemAtkLimit;

		// Token: 0x0400608A RID: 24714
		public double ElemDefLimit;

		// Token: 0x0400608B RID: 24715
		public double GeneralCombatParam;

		// Token: 0x0400608C RID: 24716
		public double AttrChangeDamageLimit;

		// Token: 0x0400608D RID: 24717
		public float CDChangeUpperBound;

		// Token: 0x0400608E RID: 24718
		public float CDChangeLowerBound;

		// Token: 0x0400608F RID: 24719
		public double AttackSpeedUpperBound;

		// Token: 0x04006090 RID: 24720
		public double AttackSpeedLowerBound;

		// Token: 0x04006091 RID: 24721
		public double CritDamageUpperBound;

		// Token: 0x04006092 RID: 24722
		public double CritDamageLowerBound;

		// Token: 0x04006093 RID: 24723
		public float DamageRandomUpperBound;

		// Token: 0x04006094 RID: 24724
		public float DamageRandomLowerBound;

		// Token: 0x04006095 RID: 24725
		public float StunTime;

		// Token: 0x04006096 RID: 24726
		public float[] AccelerationUp;

		// Token: 0x04006097 RID: 24727
		public float[] AccelerationDown;

		// Token: 0x04006098 RID: 24728
		public float Hit_PresentStraight;

		// Token: 0x04006099 RID: 24729
		public float Hit_HardStraight;

		// Token: 0x0400609A RID: 24730
		public float Hit_Offset;

		// Token: 0x0400609B RID: 24731
		public float Hit_Height;

		// Token: 0x0400609C RID: 24732
		public float ProShowTurnInterval = 4f;

		// Token: 0x0400609D RID: 24733
		public float CloseUpCameraSpeed = 3f;

		// Token: 0x0400609E RID: 24734
		public float ScreenSaveLimit = 30f;

		// Token: 0x0400609F RID: 24735
		public int ScreenSavePercentage = 20;

		// Token: 0x040060A0 RID: 24736
		public uint[] NewbieLevelRoleID;

		// Token: 0x040060A1 RID: 24737
		public int[] EntitySummonGroupLimit;

		// Token: 0x040060A2 RID: 24738
		public ulong[] NumberSeparators;

		// Token: 0x040060A3 RID: 24739
		public ulong MinSeparateNum;

		// Token: 0x040060A4 RID: 24740
		public int PINGInterval = 3;

		// Token: 0x040060A5 RID: 24741
		public List<uint> CameraAdjustScopeExceptSkills = new List<uint>();

		// Token: 0x040060A6 RID: 24742
		public int MaxGetGuildCheckInBonusNum;

		// Token: 0x040060A7 RID: 24743
		public float BuffMinAuraInterval;

		// Token: 0x040060A8 RID: 24744
		public float BuffMinRegenerateInterval;

		// Token: 0x040060A9 RID: 24745
		public uint BuffMaxDisplayCountPlayer = 5U;

		// Token: 0x040060AA RID: 24746
		public uint BuffMaxDisplayCountTeam = 5U;

		// Token: 0x040060AB RID: 24747
		public uint BuffMaxDisplayCountBoss = 5U;

		// Token: 0x040060AC RID: 24748
		public float BuffMaxDisplayTime = 600f;

		// Token: 0x040060AD RID: 24749
		public int StudentMinLevel = 20;

		// Token: 0x040060AE RID: 24750
		public int TeacherMinLevel = 30;

		// Token: 0x040060AF RID: 24751
		public List<int> ViewGridScene = new List<int>();

		// Token: 0x040060B0 RID: 24752
		public Vector3 SpriteOffset = Vector3.zero;

		// Token: 0x040060B1 RID: 24753
		public uint DefaultIconWidth;

		// Token: 0x040060B2 RID: 24754
		public float GyroScale = 0.2f;

		// Token: 0x040060B3 RID: 24755
		public float GyroDeadZone = 0.01f;

		// Token: 0x040060B4 RID: 24756
		public float GyroFrequency = 30f;

		// Token: 0x040060B5 RID: 24757
		public int MaxEquipPosType;

		// Token: 0x040060B6 RID: 24758
		public int[] EquipPosType = new int[XBagDocument.EquipMax];

		// Token: 0x040060B7 RID: 24759
		public float LoginBlockTime;

		// Token: 0x040060B8 RID: 24760
		public uint SettingEnum = 0U;

		// Token: 0x040060B9 RID: 24761
		private string[] EmptyPrefab = null;

		// Token: 0x040060BA RID: 24762
		public float MobaTowerFxOffset = 2f;

		// Token: 0x040060BB RID: 24763
		public Vector3[] SelectPos = null;

		// Token: 0x040060BC RID: 24764
		public Vector3[] MobMovePos = null;

		// Token: 0x040060BD RID: 24765
		public HashSet<uint> BlockFashionProfs = new HashSet<uint>();

		// Token: 0x040060BE RID: 24766
		private SeqList<int> emptySeqList = new SeqList<int>(2, 1);

		// Token: 0x040060BF RID: 24767
		private SeqList<int> tmpSeqList = new SeqList<int>(2, 1);
	}
}
