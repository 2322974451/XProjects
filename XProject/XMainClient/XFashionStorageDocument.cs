using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008D8 RID: 2264
	internal class XFashionStorageDocument : XDocComponent
	{
		// Token: 0x17002ACB RID: 10955
		// (get) Token: 0x06008931 RID: 35121 RVA: 0x0011F26C File Offset: 0x0011D46C
		public override uint ID
		{
			get
			{
				return XFashionStorageDocument.uuID;
			}
		}

		// Token: 0x06008932 RID: 35122 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x06008933 RID: 35123 RVA: 0x0011F284 File Offset: 0x0011D484
		public static bool TryGetFashionStoragePosition(FashionPosition position, out int pos)
		{
			pos = -1;
			bool result = true;
			switch (position)
			{
			case FashionPosition.FASHION_START:
				pos = XFastEnumIntEqualityComparer<FashionStoragePosition>.ToInt(FashionStoragePosition.FashionHeadgear);
				return result;
			case FashionPosition.FashionUpperBody:
				pos = XFastEnumIntEqualityComparer<FashionStoragePosition>.ToInt(FashionStoragePosition.FashionUpperBody);
				return result;
			case FashionPosition.FashionLowerBody:
				pos = XFastEnumIntEqualityComparer<FashionStoragePosition>.ToInt(FashionStoragePosition.FashionLowerBody);
				return result;
			case FashionPosition.FashionGloves:
				pos = XFastEnumIntEqualityComparer<FashionStoragePosition>.ToInt(FashionStoragePosition.FashionGloves);
				return result;
			case FashionPosition.FashionBoots:
				pos = XFastEnumIntEqualityComparer<FashionStoragePosition>.ToInt(FashionStoragePosition.FashionBoots);
				return result;
			case FashionPosition.FashionMainWeapon:
			case FashionPosition.FashionSecondaryWeapon:
				pos = XFastEnumIntEqualityComparer<FashionStoragePosition>.ToInt(FashionStoragePosition.FashionWeapon);
				return result;
			case FashionPosition.FashionWings:
			case FashionPosition.FashionTail:
			case FashionPosition.FashionDecal:
				pos = XFastEnumIntEqualityComparer<FashionStoragePosition>.ToInt(FashionStoragePosition.FashionThird);
				return result;
			case FashionPosition.Hair:
				pos = XFastEnumIntEqualityComparer<FashionStoragePosition>.ToInt(FashionStoragePosition.FASHION_START);
				return result;
			}
			result = false;
			return result;
		}

		// Token: 0x06008934 RID: 35124 RVA: 0x0011F32C File Offset: 0x0011D52C
		public static string GetFashionStoragePartName(FashionStoragePosition pos)
		{
			string result;
			switch (pos)
			{
			case FashionStoragePosition.FASHION_START:
				result = XStringDefineProxy.GetString("FASHION_HAIR");
				break;
			case FashionStoragePosition.FashionHeadgear:
				result = XStringDefineProxy.GetString("FASHION_HEAD");
				break;
			case FashionStoragePosition.FashionUpperBody:
				result = XStringDefineProxy.GetString("FASHION_UPPERBODY");
				break;
			case FashionStoragePosition.FashionLowerBody:
				result = XStringDefineProxy.GetString("FASHION_LOWERBODY");
				break;
			case FashionStoragePosition.FashionGloves:
				result = XStringDefineProxy.GetString("FASHION_GLOVES");
				break;
			case FashionStoragePosition.FashionBoots:
				result = XStringDefineProxy.GetString("FASHION_BOOTS");
				break;
			case FashionStoragePosition.FashionWeapon:
				result = XStringDefineProxy.GetString("FASHION_WEAPON");
				break;
			case FashionStoragePosition.FashionThird:
				result = XStringDefineProxy.GetString("FASHION_THIRD");
				break;
			default:
				result = "";
				break;
			}
			return result;
		}

		// Token: 0x06008935 RID: 35125 RVA: 0x0011F3D8 File Offset: 0x0011D5D8
		public static Color GetHairColor(uint colorID)
		{
			HairColorTable.RowData byID = XFashionStorageDocument.m_hairColorTable.GetByID(colorID);
			bool flag = byID == null;
			Color result;
			if (flag)
			{
				result = Color.white;
			}
			else
			{
				result = XSingleton<UiUtility>.singleton.GetColor(byID.Color);
			}
			return result;
		}

		// Token: 0x17002ACC RID: 10956
		// (get) Token: 0x06008936 RID: 35126 RVA: 0x0011F418 File Offset: 0x0011D618
		public static uint[] SpecialEffectIDs
		{
			get
			{
				bool flag = XFashionStorageDocument.m_specialEffectIDs == null;
				if (flag)
				{
					int num = XFashionStorageDocument.m_specialEffects.Table.Length;
					XFashionStorageDocument.m_specialEffectIDs = new uint[num];
					for (int i = 0; i < num; i++)
					{
						XFashionStorageDocument.m_specialEffectIDs[i] = XFashionStorageDocument.m_specialEffects.Table[i].suitid;
					}
				}
				return XFashionStorageDocument.m_specialEffectIDs;
			}
		}

		// Token: 0x06008937 RID: 35127 RVA: 0x0011F484 File Offset: 0x0011D684
		public static FashionSuitSpecialEffects.RowData GetSpecialEffect(uint id)
		{
			return XFashionStorageDocument.m_specialEffects.GetBysuitid(id);
		}

		// Token: 0x06008938 RID: 35128 RVA: 0x0011F4A4 File Offset: 0x0011D6A4
		public static uint GetDefaultColorID(uint hairID)
		{
			bool flag = hairID == 0U;
			uint result;
			if (flag)
			{
				result = 1U;
			}
			else
			{
				FashionHair.RowData byHairID = XFashionStorageDocument.m_fashionHair.GetByHairID(hairID);
				bool flag2 = byHairID == null;
				if (flag2)
				{
					result = 1U;
				}
				else
				{
					result = byHairID.DefaultColorID;
				}
			}
			return result;
		}

		// Token: 0x06008939 RID: 35129 RVA: 0x0011F4E0 File Offset: 0x0011D6E0
		public static bool TryGetSpecialEffect(uint id, uint type_id, out string strFx)
		{
			strFx = string.Empty;
			type_id %= 10U;
			bool flag = id == 0U;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				FashionSuitSpecialEffects.RowData bysuitid = XFashionStorageDocument.m_specialEffects.GetBysuitid(id);
				bool flag2 = bysuitid == null;
				if (flag2)
				{
					result = false;
				}
				else
				{
					switch (type_id)
					{
					case 1U:
						strFx = bysuitid.Fx1;
						break;
					case 2U:
						strFx = bysuitid.Fx2;
						break;
					case 3U:
						strFx = bysuitid.Fx3;
						break;
					case 4U:
						strFx = bysuitid.Fx4;
						break;
					case 5U:
						strFx = bysuitid.Fx5;
						break;
					case 6U:
						strFx = bysuitid.Fx6;
						break;
					case 7U:
						strFx = bysuitid.Fx7;
						break;
					case 8U:
						strFx = bysuitid.Fx8;
						break;
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600893A RID: 35130 RVA: 0x0011F5A8 File Offset: 0x0011D7A8
		public static void Execute(OnLoadedCallback callback = null)
		{
			XFashionStorageDocument.AsyncLoader.AddTask("Table/FashionCharm", XFashionStorageDocument.m_fashionCharmTable, false);
			XFashionStorageDocument.AsyncLoader.AddTask("Table/FashionHair", XFashionStorageDocument.m_fashionHair, false);
			XFashionStorageDocument.AsyncLoader.AddTask("Table/HairColorTable", XFashionStorageDocument.m_hairColorTable, false);
			XFashionStorageDocument.AsyncLoader.AddTask("Table/FashionSuitSpecialEffects", XFashionStorageDocument.m_specialEffects, false);
			XFashionStorageDocument.AsyncLoader.Execute(null);
		}

		// Token: 0x17002ACD RID: 10957
		// (get) Token: 0x0600893B RID: 35131 RVA: 0x0011F61C File Offset: 0x0011D81C
		public List<uint> DisplayFashion
		{
			get
			{
				return this.m_displayFashion;
			}
		}

		// Token: 0x17002ACE RID: 10958
		// (get) Token: 0x0600893C RID: 35132 RVA: 0x0011F634 File Offset: 0x0011D834
		public List<uint> SpecialEffects
		{
			get
			{
				return this.m_special_effects;
			}
		}

		// Token: 0x17002ACF RID: 10959
		// (get) Token: 0x0600893D RID: 35133 RVA: 0x0011F64C File Offset: 0x0011D84C
		public bool ShowEffect
		{
			get
			{
				bool showEffect = this.m_showEffect;
				bool result;
				if (showEffect)
				{
					this.m_showEffect = false;
					result = true;
				}
				else
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x0600893E RID: 35134 RVA: 0x0011F678 File Offset: 0x0011D878
		public void InitHairColor(uint colorID, List<ActivateHairColor> hairs)
		{
			this.m_selfHairColor = colorID;
			bool flag = this.m_activateHairColors == null;
			if (flag)
			{
				this.m_activateHairColors = new XBetterDictionary<uint, IFashionStorageSelect>(0);
			}
			this.m_activateHairColors.Clear();
			int i = 0;
			int num = XFashionStorageDocument.m_fashionHair.Table.Length;
			while (i < num)
			{
				bool flag2 = XFashionStorageDocument.m_fashionHair.Table[i].UnLookColorID == null || XFashionStorageDocument.m_fashionHair.Table[i].UnLookColorID.Length == 0;
				if (!flag2)
				{
					this.m_activateHairColors.Add(XFashionStorageDocument.m_fashionHair.Table[i].HairID, new FashionStorageHairColor(XFashionStorageDocument.m_fashionHair.Table[i]));
				}
				i++;
			}
			i = 0;
			num = hairs.Count;
			while (i < num)
			{
				bool flag3 = this.m_activateHairColors.ContainsKey(hairs[i].hair_id);
				if (flag3)
				{
					this.m_activateHairColors[hairs[i].hair_id].GetItems().AddRange(hairs[i].hair_color_id);
				}
				i++;
			}
		}

		// Token: 0x0600893F RID: 35135 RVA: 0x0011F79C File Offset: 0x0011D99C
		public void Init(FashionRecord info)
		{
			this.m_displayFashion = info.display_fashion;
			this.m_ownDisplayItems = info.own_display_items;
			this.m_activateCharms = info.own_fashins;
			this.InitCharmMap();
			this.InitPartDisplay();
			this.InitStorageCharm();
			this.InitSuitEffect();
			this.InitHairColor(info.hair_color_id, info.hair_color_info);
			this.SetupSpecialEffects(info.special_effects_list, info.special_effects_id);
			int i = 0;
			int count = this.m_ownDisplayItems.Count;
			while (i < count)
			{
				this.InsertPartToDisplay(this.m_ownDisplayItems[i]);
				i++;
			}
			int j = 0;
			int count2 = this.m_activateCharms.Count;
			while (j < count2)
			{
				bool flag = this.m_fashionCharm.ContainsKey((int)this.m_activateCharms[j].suit_id);
				if (flag)
				{
					this.m_fashionCharm[(int)this.m_activateCharms[j].suit_id].SetCount(this.m_activateCharms[j].activate_count);
					this.m_fashionCharm[(int)this.m_activateCharms[j].suit_id].Refresh();
				}
				else
				{
					bool flag2 = this.m_equipCharm.ContainsKey((int)this.m_activateCharms[j].suit_id);
					if (flag2)
					{
						this.m_equipCharm[(int)this.m_activateCharms[j].suit_id].SetCount(this.m_activateCharms[j].activate_count);
						this.m_equipCharm[(int)this.m_activateCharms[j].suit_id].Refresh();
					}
				}
				j++;
			}
			this.RefreshRedPoint();
			XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.SetFashionData(this.m_displayFashion, this.m_selfHairColor, this.m_selfEffectID, true);
			XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.CalculateOutLookFashion();
		}

		// Token: 0x06008940 RID: 35136 RVA: 0x0011F9A0 File Offset: 0x0011DBA0
		private void SetupSpecialEffects(List<uint> effectIDs, uint special_effect_id)
		{
			this.m_selfEffectID = special_effect_id;
			this.m_special_effects.Clear();
			bool flag = effectIDs == null;
			if (!flag)
			{
				this.m_special_effects.AddRange(effectIDs);
			}
		}

		// Token: 0x06008941 RID: 35137 RVA: 0x0011F9D8 File Offset: 0x0011DBD8
		private void InitSuitEffect()
		{
			bool flag = this.m_activateSuitEffects == null;
			if (flag)
			{
				this.m_activateSuitEffects = new XBetterDictionary<uint, IFashionStorageSelect>(0);
			}
			this.m_activateSuitEffects.Clear();
			int i = 0;
			int num = XFashionStorageDocument.m_specialEffects.Table.Length;
			while (i < num)
			{
				FashionSuitSpecialEffects.RowData rowData = XFashionStorageDocument.m_specialEffects.Table[i];
				FashionStorageSuitEffect value = new FashionStorageSuitEffect(rowData);
				this.m_activateSuitEffects.Add(rowData.suitid, value);
				i++;
			}
		}

		// Token: 0x06008942 RID: 35138 RVA: 0x0011FA58 File Offset: 0x0011DC58
		public bool TryGetCharmAttr(out Dictionary<uint, uint> attr, out int activate_count, out int activate_total)
		{
			attr = new Dictionary<uint, uint>();
			activate_count = 0;
			activate_total = 0;
			this.AnalysisCharmAttr(this.m_equipCharm, ref attr, ref activate_total, ref activate_count);
			this.AnalysisCharmAttr(this.m_fashionCharm, ref attr, ref activate_total, ref activate_count);
			return activate_count > 0;
		}

		// Token: 0x06008943 RID: 35139 RVA: 0x0011FA9C File Offset: 0x0011DC9C
		private void AnalysisCharmAttr(XBetterDictionary<int, IFashionStorageSelect> charms, ref Dictionary<uint, uint> attr, ref int activate_total, ref int activate_count)
		{
			bool flag = charms == null;
			if (!flag)
			{
				int i = 0;
				int count = charms.BufferValues.Count;
				while (i < count)
				{
					bool flag2 = !charms.BufferValues[i].Active;
					if (!flag2)
					{
						activate_total += charms.BufferValues[i].GetFashionList().Length;
						activate_count += charms.BufferValues[i].GetItems().Count;
						List<AttributeCharm> attributeCharm = charms.BufferValues[i].GetAttributeCharm();
						int j = 0;
						int count2 = attributeCharm.Count;
						while (j < count2)
						{
							bool active = attributeCharm[j].active;
							if (active)
							{
								bool flag3 = attr.ContainsKey(attributeCharm[j].key);
								if (flag3)
								{
									Dictionary<uint, uint> dictionary = attr;
									uint key = attributeCharm[j].key;
									dictionary[key] += attributeCharm[j].value;
								}
								else
								{
									attr[attributeCharm[j].key] = attributeCharm[j].value;
								}
							}
							j++;
						}
					}
					i++;
				}
			}
		}

		// Token: 0x17002AD0 RID: 10960
		// (get) Token: 0x06008944 RID: 35140 RVA: 0x0011FBF4 File Offset: 0x0011DDF4
		public bool RedPoint
		{
			get
			{
				return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Fashion_OutLook) && this.m_redPoint;
			}
		}

		// Token: 0x17002AD1 RID: 10961
		// (get) Token: 0x06008945 RID: 35141 RVA: 0x0011FC20 File Offset: 0x0011DE20
		public bool EquipRedPoint
		{
			get
			{
				return this.m_equipRedPoint;
			}
		}

		// Token: 0x17002AD2 RID: 10962
		// (get) Token: 0x06008946 RID: 35142 RVA: 0x0011FC38 File Offset: 0x0011DE38
		public bool FashionRedPoint
		{
			get
			{
				return this.m_fashionRedPoint;
			}
		}

		// Token: 0x17002AD3 RID: 10963
		// (get) Token: 0x06008947 RID: 35143 RVA: 0x0011FC50 File Offset: 0x0011DE50
		public bool SuitRedPoint
		{
			get
			{
				return this.m_suitSuitRedPoint;
			}
		}

		// Token: 0x06008948 RID: 35144 RVA: 0x0011FC68 File Offset: 0x0011DE68
		private void RefreshRedPoint()
		{
			this.m_equipRedPoint = this.GetEquipCharmRedPoint();
			this.m_fashionRedPoint = this.GetFashionCharmRedPoint();
			this.m_suitSuitRedPoint = this.GetFashionSuitEffectRedPoint();
			this.m_redPoint = (this.m_equipRedPoint || this.m_fashionRedPoint || this.m_suitSuitRedPoint);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Fashion_OutLook, true);
			bool flag = DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.IsVisible() && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._FashionBagHandler != null && DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._FashionBagHandler.IsVisible();
			if (flag)
			{
				DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton._FashionBagHandler.RefreshOutLookRedPoint();
			}
		}

		// Token: 0x06008949 RID: 35145 RVA: 0x0011FD08 File Offset: 0x0011DF08
		public bool GetFashionCharmRedPoint()
		{
			bool flag = false;
			bool flag2 = this.m_fashionCharm == null;
			bool result;
			if (flag2)
			{
				result = flag;
			}
			else
			{
				int i = 0;
				int count = this.m_fashionCharm.BufferValues.Count;
				while (i < count)
				{
					bool flag3 = this.m_fashionCharm.BufferValues[i] == null || !this.m_fashionCharm.BufferValues[i].RedPoint;
					if (!flag3)
					{
						flag = true;
						break;
					}
					i++;
				}
				result = flag;
			}
			return result;
		}

		// Token: 0x0600894A RID: 35146 RVA: 0x0011FD90 File Offset: 0x0011DF90
		public bool GetFashionSuitEffectRedPoint()
		{
			bool flag = false;
			bool flag2 = this.m_activateSuitEffects == null;
			bool result;
			if (flag2)
			{
				result = flag;
			}
			else
			{
				int i = 0;
				int count = this.m_activateSuitEffects.BufferValues.Count;
				while (i < count)
				{
					bool flag3 = this.m_activateSuitEffects.BufferValues[i] == null || !this.m_activateSuitEffects.BufferValues[i].RedPoint;
					if (!flag3)
					{
						flag = true;
						break;
					}
					i++;
				}
				result = flag;
			}
			return result;
		}

		// Token: 0x0600894B RID: 35147 RVA: 0x0011FE18 File Offset: 0x0011E018
		public bool GetEquipCharmRedPoint()
		{
			bool flag = false;
			bool flag2 = this.m_equipCharm == null;
			bool result;
			if (flag2)
			{
				result = flag;
			}
			else
			{
				int i = 0;
				int count = this.m_equipCharm.BufferValues.Count;
				while (i < count)
				{
					bool flag3 = this.m_equipCharm.BufferValues[i] == null || !this.m_equipCharm.BufferValues[i].RedPoint;
					if (!flag3)
					{
						flag = true;
						break;
					}
					i++;
				}
				result = flag;
			}
			return result;
		}

		// Token: 0x0600894C RID: 35148 RVA: 0x0011FEA0 File Offset: 0x0011E0A0
		private void InitStorageCharm()
		{
			bool flag = this.m_fashionCharm == null;
			if (flag)
			{
				this.m_fashionCharm = new XBetterDictionary<int, IFashionStorageSelect>(0);
			}
			bool flag2 = this.m_equipCharm == null;
			if (flag2)
			{
				this.m_equipCharm = new XBetterDictionary<int, IFashionStorageSelect>(0);
			}
			uint basicTypeID = XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID;
			this.m_fashionCharm.Clear();
			this.m_equipCharm.Clear();
			int i = 0;
			int num = XFashionStorageDocument.m_fashionCharmTable.Table.Length;
			while (i < num)
			{
				FashionCharm.RowData rowData = XFashionStorageDocument.m_fashionCharmTable.Table[i];
				int suitID = (int)rowData.SuitID;
				bool flag3 = XFashionDocument.IsFashionBySuitID(suitID);
				if (flag3)
				{
					bool flag4 = !this.m_fashionCharm.ContainsKey(suitID);
					if (flag4)
					{
						this.m_fashionCharm.Add(suitID, new FashionStorageFashionCollection(suitID));
					}
				}
				else
				{
					bool flag5 = XEquipCreateDocument.InEquipSuit(suitID, true);
					if (flag5)
					{
						bool flag6 = !this.m_equipCharm.ContainsKey(suitID);
						if (flag6)
						{
							this.m_equipCharm.Add(suitID, new FashionStorageEquipCollection(suitID));
						}
					}
				}
				i++;
			}
		}

		// Token: 0x0600894D RID: 35149 RVA: 0x0011FFC0 File Offset: 0x0011E1C0
		private void InitCharmMap()
		{
			int i = 0;
			int num = XFashionStorageDocument.m_fashionCharmTable.Table.Length;
			while (i < num)
			{
				bool flag = XFashionStorageDocument.m_fashionCharmTable.Table[i].SuitParam == null;
				if (!flag)
				{
					for (int j = 0; j < XFashionStorageDocument.m_fashionCharmTable.Table[i].SuitParam.Length; j++)
					{
						bool flag2 = !XFashionStorageDocument.m_charmMap.ContainsKey(XFashionStorageDocument.m_fashionCharmTable.Table[i].SuitParam[j]);
						if (flag2)
						{
							XFashionStorageDocument.m_charmMap.Add(XFashionStorageDocument.m_fashionCharmTable.Table[i].SuitParam[j], XFashionStorageDocument.m_fashionCharmTable.Table[i].SuitID);
						}
					}
				}
				i++;
			}
		}

		// Token: 0x0600894E RID: 35150 RVA: 0x0012008C File Offset: 0x0011E28C
		private void InitPartDisplay()
		{
			bool flag = this.m_partDisplay != null;
			if (!flag)
			{
				this.m_partDisplay = new XBetterDictionary<int, IFashionStorageSelect>(0);
				int num = XFastEnumIntEqualityComparer<FashionStoragePosition>.ToInt(FashionStoragePosition.FASHION_START);
				int num2 = XFastEnumIntEqualityComparer<FashionStoragePosition>.ToInt(FashionStoragePosition.FASHION_END);
				for (int i = num; i < num2; i++)
				{
					this.m_partDisplay.Add(i, new FashionStorageDisplay((FashionStoragePosition)i));
				}
			}
		}

		// Token: 0x0600894F RID: 35151 RVA: 0x001200E8 File Offset: 0x0011E2E8
		public bool InDisplay(uint itemid)
		{
			return this.m_ownDisplayItems != null && this.m_ownDisplayItems.Contains(itemid);
		}

		// Token: 0x06008950 RID: 35152 RVA: 0x00120114 File Offset: 0x0011E314
		public void CheckMutuexHair(int hairID)
		{
			int fashionInBody = this.GetFashionInBody(FashionPosition.FASHION_START);
			bool flag = fashionInBody == 0;
			if (!flag)
			{
				FashionList.RowData fashionConf = XBagDocument.GetFashionConf(fashionInBody);
				bool flag2 = fashionConf == null || fashionConf.ReplaceID == null;
				if (!flag2)
				{
					int num = (int)(XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID - 1U);
					bool flag3 = num >= 0 && num < fashionConf.ReplaceID.Length && fashionConf.ReplaceID[num] > 0;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FASHION_STPRAGE_MUTEXT"), "fece00");
					}
				}
			}
		}

		// Token: 0x06008951 RID: 35153 RVA: 0x001201A4 File Offset: 0x0011E3A4
		public void CheckMutuexHeadgear(int headgear)
		{
			FashionList.RowData fashionConf = XBagDocument.GetFashionConf(headgear);
			bool flag = fashionConf != null && fashionConf.ReplaceID != null;
			if (flag)
			{
				int num = (int)(XSingleton<XAttributeMgr>.singleton.XPlayerData.BasicTypeID - 1U);
				bool flag2 = num >= 0 && num < fashionConf.ReplaceID.Length && fashionConf.ReplaceID[num] > 0;
				if (flag2)
				{
					bool flag3 = this.GetFashionInBody(FashionPosition.Hair) > 0;
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("FASHION_STPRAGE_MUTEXT"), "fece00");
					}
				}
			}
		}

		// Token: 0x06008952 RID: 35154 RVA: 0x00120230 File Offset: 0x0011E430
		private int GetFashionInBody(FashionPosition pos)
		{
			int result = 0;
			int i = 0;
			int count = this.m_displayFashion.Count;
			while (i < count)
			{
				bool flag = this.m_displayFashion[i] != 0U && XFashionDocument.IsTargetPart((int)this.m_displayFashion[i], pos);
				if (flag)
				{
					result = (int)this.m_displayFashion[i];
					break;
				}
				i++;
			}
			return result;
		}

		// Token: 0x06008953 RID: 35155 RVA: 0x001202A0 File Offset: 0x0011E4A0
		private void InsertPartToDisplay(uint itemID)
		{
			bool flag = itemID == 0U;
			if (!flag)
			{
				bool flag2 = !this.m_ownDisplayItems.Contains(itemID);
				if (flag2)
				{
					this.m_ownDisplayItems.Add(itemID);
				}
				FashionList.RowData fashionConf = XBagDocument.GetFashionConf((int)itemID);
				bool flag3 = fashionConf != null;
				if (flag3)
				{
					int key = -1;
					bool flag4 = XFashionStorageDocument.TryGetFashionStoragePosition((FashionPosition)fashionConf.EquipPos, out key) && this.m_partDisplay.ContainsKey(key);
					if (flag4)
					{
						IFashionStorageSelect fashionStorageSelect = this.m_partDisplay[key];
						bool flag5 = !fashionStorageSelect.GetItems().Contains((uint)fashionConf.ItemID);
						if (flag5)
						{
							fashionStorageSelect.GetItems().Add((uint)fashionConf.ItemID);
						}
					}
				}
				bool flag6 = !XFashionStorageDocument.m_charmMap.ContainsKey(itemID);
				if (!flag6)
				{
					int key2 = (int)XFashionStorageDocument.m_charmMap[itemID];
					bool flag7 = this.m_fashionCharm.ContainsKey(key2);
					if (flag7)
					{
						bool flag8 = !this.m_fashionCharm[key2].GetItems().Contains(itemID);
						if (flag8)
						{
							this.m_fashionCharm[key2].GetItems().Add(itemID);
							this.m_fashionCharm[key2].Refresh();
						}
					}
					else
					{
						bool flag9 = this.m_equipCharm.ContainsKey(key2);
						if (flag9)
						{
							bool flag10 = !this.m_equipCharm[key2].GetItems().Contains(itemID);
							if (flag10)
							{
								this.m_equipCharm[key2].GetItems().Add(itemID);
								this.m_equipCharm[key2].Refresh();
							}
						}
					}
					bool flag11 = this.m_activateSuitEffects.ContainsKey((uint)key2);
					if (flag11)
					{
						bool flag12 = !this.m_activateSuitEffects[(uint)key2].GetItems().Contains(itemID);
						if (flag12)
						{
							this.m_activateSuitEffects[(uint)key2].GetItems().Add(itemID);
							this.m_activateSuitEffects[(uint)key2].Refresh();
						}
					}
				}
			}
		}

		// Token: 0x06008954 RID: 35156 RVA: 0x0012049C File Offset: 0x0011E69C
		public void ItemUpdate(uint add, uint del)
		{
			bool flag = add > 0U;
			if (flag)
			{
				this.InsertPartToDisplay(add);
			}
			bool flag2 = del > 0U;
			if (flag2)
			{
				this.RemovePartFromDisplay(del);
			}
			this.RefreshRedPoint();
			this.RefreshView();
		}

		// Token: 0x06008955 RID: 35157 RVA: 0x001204D8 File Offset: 0x0011E6D8
		private void RefreshView()
		{
			bool flag = DlgBase<FashionStorageDlg, FashionStorageBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<FashionStorageDlg, FashionStorageBehaviour>.singleton.Refresh();
			}
		}

		// Token: 0x06008956 RID: 35158 RVA: 0x00120500 File Offset: 0x0011E700
		public void UpdateDisplay(UpdateDisplayItems org)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("UpdateDisplay :" + org.hair_color_id.ToString(), null, null, null, null, null);
			this.m_displayFashion = org.display_items;
			this.m_selfHairColor = org.hair_color_id;
			this.m_selfEffectID = org.special_effects_id;
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null || XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook == null;
			if (!flag)
			{
				XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.SetFashionData(this.m_displayFashion, this.m_selfHairColor, this.m_selfEffectID, true);
				XEquipChangeEventArgs @event = XEventPool<XEquipChangeEventArgs>.GetEvent();
				@event.Firer = XSingleton<XEntityMgr>.singleton.Player;
				XSingleton<XEventMgr>.singleton.FireEvent(@event);
				this.RefreshView();
			}
		}

		// Token: 0x06008957 RID: 35159 RVA: 0x001205D4 File Offset: 0x0011E7D4
		private bool RemovePartFromDisplay(uint itemID)
		{
			bool flag = this.m_partDisplay == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.m_ownDisplayItems.Contains(itemID);
				if (flag2)
				{
					this.m_ownDisplayItems.Remove(itemID);
				}
				FashionList.RowData fashionConf = XBagDocument.GetFashionConf((int)itemID);
				bool flag3 = fashionConf == null;
				if (flag3)
				{
					result = true;
				}
				else
				{
					int key = -1;
					bool flag4 = XFashionStorageDocument.TryGetFashionStoragePosition((FashionPosition)fashionConf.EquipPos, out key) && this.m_partDisplay.ContainsKey(key);
					if (flag4)
					{
						IFashionStorageSelect fashionStorageSelect = this.m_partDisplay[key];
						bool flag5 = fashionStorageSelect.GetItems().Contains((uint)fashionConf.ItemID);
						if (flag5)
						{
							fashionStorageSelect.GetItems().Remove((uint)fashionConf.ItemID);
						}
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06008958 RID: 35160 RVA: 0x00120690 File Offset: 0x0011E890
		public bool FashionInBody(int itemid)
		{
			return this.m_displayFashion != null && itemid > 0 && this.m_displayFashion.Contains((uint)itemid);
		}

		// Token: 0x06008959 RID: 35161 RVA: 0x001206C0 File Offset: 0x0011E8C0
		public bool TryGetFashionChaim(uint suitID, out FashionCharm.RowData charm)
		{
			charm = XFashionStorageDocument.m_fashionCharmTable.GetBySuitID(suitID);
			return charm != null;
		}

		// Token: 0x0600895A RID: 35162 RVA: 0x001206E4 File Offset: 0x0011E8E4
		private void FilterSelect(XBetterDictionary<int, IFashionStorageSelect> charms, ref List<IFashionStorageSelect> list)
		{
			bool flag = charms == null;
			if (!flag)
			{
				bool flag2 = list == null;
				if (flag2)
				{
					list = new List<IFashionStorageSelect>();
				}
				list.Clear();
				int i = 0;
				int count = charms.BufferValues.Count;
				while (i < count)
				{
					bool active = charms.BufferValues[i].Active;
					if (active)
					{
						list.Add(charms.BufferValues[i]);
					}
					i++;
				}
			}
		}

		// Token: 0x0600895B RID: 35163 RVA: 0x00120760 File Offset: 0x0011E960
		public void GetCollection(ref List<IFashionStorageSelect> list, FashionStorageType type)
		{
			switch (type)
			{
			case FashionStorageType.OutLook:
				this.FilterSelect(this.m_partDisplay, ref list);
				break;
			case FashionStorageType.FashionCollection:
				this.FilterSelect(this.m_fashionCharm, ref list);
				break;
			case FashionStorageType.EquipCollection:
				this.FilterSelect(this.m_equipCharm, ref list);
				break;
			}
		}

		// Token: 0x0600895C RID: 35164 RVA: 0x001207B4 File Offset: 0x0011E9B4
		public void SendActivateFashion(uint suitID)
		{
			RpcC2G_ActivateFashionCharm rpcC2G_ActivateFashionCharm = new RpcC2G_ActivateFashionCharm();
			rpcC2G_ActivateFashionCharm.oArg.suit_id = suitID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ActivateFashionCharm);
		}

		// Token: 0x0600895D RID: 35165 RVA: 0x001207E4 File Offset: 0x0011E9E4
		public void ReceiveActivateFashion(ActivateFashionArg arg, ActivateFashionRes res)
		{
			bool flag = res.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(res.result, "fece00");
			}
			else
			{
				int suit_id = (int)arg.suit_id;
				bool flag2 = this.m_fashionCharm.ContainsKey(suit_id);
				if (flag2)
				{
					this.m_fashionCharm[suit_id].SetCount(res.active_count);
					this.m_fashionCharm[suit_id].Refresh();
					this.m_showEffect = this.m_fashionCharm[suit_id].ActivateAll;
				}
				else
				{
					bool flag3 = this.m_equipCharm.ContainsKey(suit_id);
					if (flag3)
					{
						this.m_equipCharm[suit_id].SetCount(res.active_count);
						this.m_equipCharm[suit_id].Refresh();
						this.m_showEffect = this.m_equipCharm[suit_id].ActivateAll;
					}
				}
				this.RefreshRedPoint();
				this.RefreshView();
			}
		}

		// Token: 0x17002AD4 RID: 10964
		// (get) Token: 0x0600895E RID: 35166 RVA: 0x001208D8 File Offset: 0x0011EAD8
		public uint selfEffectID
		{
			get
			{
				return this.m_selfEffectID;
			}
		}

		// Token: 0x0600895F RID: 35167 RVA: 0x001208F0 File Offset: 0x0011EAF0
		public bool isActivateEffect(uint effectID)
		{
			return effectID == 0U || this.m_special_effects.Contains(effectID);
		}

		// Token: 0x06008960 RID: 35168 RVA: 0x00120914 File Offset: 0x0011EB14
		public XBetterList<IFashionStorageSelect> GetActivateSuits()
		{
			return (this.m_activateSuitEffects != null) ? this.m_activateSuitEffects.BufferValues : null;
		}

		// Token: 0x06008961 RID: 35169 RVA: 0x0012093C File Offset: 0x0011EB3C
		public IFashionStorageSelect GetActivateSuit(uint suitID)
		{
			return (this.m_activateSuitEffects == null) ? null : this.m_activateSuitEffects[suitID];
		}

		// Token: 0x06008962 RID: 35170 RVA: 0x00120968 File Offset: 0x0011EB68
		public void GetActiveSuitEffect(uint suitEeffectID)
		{
			this.preview = FashionStoragePreview.None;
			RpcC2G_ChooseSpecialEffects rpcC2G_ChooseSpecialEffects = new RpcC2G_ChooseSpecialEffects();
			rpcC2G_ChooseSpecialEffects.oArg.special_effects_id = suitEeffectID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChooseSpecialEffects);
		}

		// Token: 0x06008963 RID: 35171 RVA: 0x0012099C File Offset: 0x0011EB9C
		public void SetActiveSuitEffect(ChooseSpecialEffectsArg oArg, ChooseSpecialEffectsRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.result, "fece00");
			}
			else
			{
				bool flag2 = oArg.special_effects_id > 0U && !this.m_special_effects.Contains(oArg.special_effects_id);
				if (flag2)
				{
					this.m_special_effects.Add(oArg.special_effects_id);
				}
				this.m_selfEffectID = oArg.special_effects_id;
				this.RefreshRedPoint();
				this.RefreshView();
			}
		}

		// Token: 0x17002AD5 RID: 10965
		// (get) Token: 0x06008964 RID: 35172 RVA: 0x00120A20 File Offset: 0x0011EC20
		public static uint HairColorID
		{
			get
			{
				XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
				return specificDocument.m_selfHairColor;
			}
		}

		// Token: 0x17002AD6 RID: 10966
		// (get) Token: 0x06008965 RID: 35173 RVA: 0x00120A44 File Offset: 0x0011EC44
		public uint selfHairColor
		{
			get
			{
				return this.m_selfHairColor;
			}
		}

		// Token: 0x06008966 RID: 35174 RVA: 0x00120A5C File Offset: 0x0011EC5C
		public IFashionStorageSelect GetFashionHair(uint hairID)
		{
			return this.m_activateHairColors.ContainsKey(hairID) ? this.m_activateHairColors[hairID] : null;
		}

		// Token: 0x17002AD7 RID: 10967
		// (get) Token: 0x06008967 RID: 35175 RVA: 0x00120A8C File Offset: 0x0011EC8C
		public uint CurHairColor
		{
			get
			{
				return this.m_selfHairColor;
			}
		}

		// Token: 0x06008968 RID: 35176 RVA: 0x00120AA4 File Offset: 0x0011ECA4
		public FashionHair.RowData GetFashionHairData(uint hairID)
		{
			return XFashionStorageDocument.m_fashionHair.GetByHairID(hairID);
		}

		// Token: 0x06008969 RID: 35177 RVA: 0x00120AC4 File Offset: 0x0011ECC4
		public HairColorTable.RowData GetHairColorData(uint colorID)
		{
			return XFashionStorageDocument.m_hairColorTable.GetByID(colorID);
		}

		// Token: 0x0600896A RID: 35178 RVA: 0x00120AE4 File Offset: 0x0011ECE4
		public bool TryGetHairColor(uint colorID, out HairColorTable.RowData hcolor)
		{
			bool flag = colorID > 0U;
			bool result;
			if (flag)
			{
				hcolor = this.GetHairColorData(colorID);
				result = (hcolor != null);
			}
			else
			{
				hcolor = null;
				result = false;
			}
			return result;
		}

		// Token: 0x0600896B RID: 35179 RVA: 0x00120B14 File Offset: 0x0011ED14
		public bool TryGetSelfHairColor(out HairColorTable.RowData hcolor)
		{
			return this.TryGetHairColor(this.m_selfHairColor, out hcolor);
		}

		// Token: 0x0600896C RID: 35180 RVA: 0x00120B34 File Offset: 0x0011ED34
		public void SelectHair(uint hairID)
		{
			FashionHair.RowData byHairID = XFashionStorageDocument.m_fashionHair.GetByHairID(hairID);
			bool flag = byHairID == null;
			if (!flag)
			{
				this.selectHairID = hairID;
				DlgBase<FashionStorageDlg, FashionStorageBehaviour>.singleton.Switch(FashionStoragePreview.Hair);
			}
		}

		// Token: 0x0600896D RID: 35181 RVA: 0x00120B6C File Offset: 0x0011ED6C
		public bool IsActivateHairColor(uint hairID, uint colorID)
		{
			return this.m_activateHairColors.ContainsKey(hairID) && this.m_activateHairColors[hairID].GetItems().Contains(colorID);
		}

		// Token: 0x0600896E RID: 35182 RVA: 0x00120BA8 File Offset: 0x0011EDA8
		public bool TryGetActivateUseItem(uint hairID, uint colorID, out uint itemid, out uint count)
		{
			itemid = 0U;
			count = 0U;
			FashionHair.RowData fashionHairData = this.GetFashionHairData(hairID);
			bool flag = fashionHairData == null;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				int i = 0;
				int count2 = fashionHairData.Cost.Count;
				while (i < count2)
				{
					bool flag2 = fashionHairData.Cost[i, 0] == colorID;
					if (flag2)
					{
						itemid = fashionHairData.Cost[i, 1];
						count = fashionHairData.Cost[i, 2];
						return true;
					}
					i++;
				}
				result = false;
			}
			return result;
		}

		// Token: 0x0600896F RID: 35183 RVA: 0x00120C34 File Offset: 0x0011EE34
		public void GetActivateHairColor(uint hairID, uint colorID)
		{
			bool flag = !this.IsActivateHairColor(hairID, colorID);
			if (flag)
			{
				uint num;
				uint num2;
				bool flag2 = !this.TryGetActivateUseItem(hairID, colorID, out num, out num2);
				if (flag2)
				{
					return;
				}
				uint num3 = (uint)XBagDocument.BagDoc.GetItemCount((int)num);
				bool flag3 = num3 < num2;
				if (flag3)
				{
					ItemList.RowData itemConf = XBagDocument.GetItemConf((int)num);
					bool flag4 = itemConf != null;
					if (flag4)
					{
						UiUtility singleton = XSingleton<UiUtility>.singleton;
						string key = "FASHION_HAIR_COLORING";
						object[] itemName = itemConf.ItemName;
						singleton.ShowSystemTip(XStringDefineProxy.GetString(key, itemName), "fece00");
					}
					return;
				}
			}
			this.preview = FashionStoragePreview.None;
			RpcC2G_ActivateHairColor rpcC2G_ActivateHairColor = new RpcC2G_ActivateHairColor();
			rpcC2G_ActivateHairColor.oArg.hair_id = hairID;
			rpcC2G_ActivateHairColor.oArg.hair_color_id = colorID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ActivateHairColor);
		}

		// Token: 0x06008970 RID: 35184 RVA: 0x00120CF4 File Offset: 0x0011EEF4
		public void SetActivateHairColor(ActivateHairColorRes oRes)
		{
			bool flag = oRes.result > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.result);
			}
			else
			{
				bool flag2 = this.m_activateHairColors.ContainsKey(oRes.hair_id);
				if (flag2)
				{
					int i = 0;
					int count = oRes.hair_colorid_list.Count;
					while (i < count)
					{
						bool flag3 = !this.m_activateHairColors[oRes.hair_id].GetItems().Contains(oRes.hair_colorid_list[i]);
						if (flag3)
						{
							this.m_activateHairColors[oRes.hair_id].GetItems().Add(oRes.hair_colorid_list[i]);
						}
						i++;
					}
				}
				this.RefreshView();
			}
		}

		// Token: 0x06008971 RID: 35185 RVA: 0x00120DBC File Offset: 0x0011EFBC
		public void DoCheckPreview(ButtonClickEventHandler eventHandle)
		{
			bool flag = this.preview == FashionStoragePreview.Hair;
			if (flag)
			{
				string @string = XStringDefineProxy.GetString("FASHION_HAIRCOLOR_UNSAVE");
				XSingleton<UiUtility>.singleton.ShowModalDialog(@string, XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), eventHandle);
			}
			else
			{
				bool flag2 = eventHandle != null;
				if (flag2)
				{
					eventHandle(null);
				}
			}
		}

		// Token: 0x04002B7D RID: 11133
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FashionStorageDocument");

		// Token: 0x04002B7E RID: 11134
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x04002B7F RID: 11135
		private static FashionCharm m_fashionCharmTable = new FashionCharm();

		// Token: 0x04002B80 RID: 11136
		private static FashionSuitSpecialEffects m_specialEffects = new FashionSuitSpecialEffects();

		// Token: 0x04002B81 RID: 11137
		private static Dictionary<uint, uint> m_charmMap = new Dictionary<uint, uint>();

		// Token: 0x04002B82 RID: 11138
		private static HairColorTable m_hairColorTable = new HairColorTable();

		// Token: 0x04002B83 RID: 11139
		private static FashionHair m_fashionHair = new FashionHair();

		// Token: 0x04002B84 RID: 11140
		private static uint[] m_specialEffectIDs;

		// Token: 0x04002B85 RID: 11141
		private List<uint> m_displayFashion = new List<uint>();

		// Token: 0x04002B86 RID: 11142
		private List<uint> m_special_effects = new List<uint>();

		// Token: 0x04002B87 RID: 11143
		private List<ActivateFashionCharm> m_activateCharms;

		// Token: 0x04002B88 RID: 11144
		private List<uint> m_ownDisplayItems;

		// Token: 0x04002B89 RID: 11145
		private XBetterDictionary<int, IFashionStorageSelect> m_partDisplay;

		// Token: 0x04002B8A RID: 11146
		private XBetterDictionary<int, IFashionStorageSelect> m_fashionCharm;

		// Token: 0x04002B8B RID: 11147
		private XBetterDictionary<int, IFashionStorageSelect> m_equipCharm;

		// Token: 0x04002B8C RID: 11148
		public FashionStorageType fashionStorageType = FashionStorageType.OutLook;

		// Token: 0x04002B8D RID: 11149
		private bool m_redPoint = false;

		// Token: 0x04002B8E RID: 11150
		private bool m_equipRedPoint = false;

		// Token: 0x04002B8F RID: 11151
		private bool m_fashionRedPoint = false;

		// Token: 0x04002B90 RID: 11152
		private bool m_suitSuitRedPoint = false;

		// Token: 0x04002B91 RID: 11153
		private bool m_showEffect = false;

		// Token: 0x04002B92 RID: 11154
		private uint m_selfEffectID = 0U;

		// Token: 0x04002B93 RID: 11155
		public uint previewEffectID = 0U;

		// Token: 0x04002B94 RID: 11156
		private XBetterDictionary<uint, IFashionStorageSelect> m_activateSuitEffects;

		// Token: 0x04002B95 RID: 11157
		private uint m_selfHairColor = 0U;

		// Token: 0x04002B96 RID: 11158
		public uint previewHairColor = 0U;

		// Token: 0x04002B97 RID: 11159
		public uint selectHairID = 0U;

		// Token: 0x04002B98 RID: 11160
		public FashionStoragePreview preview = FashionStoragePreview.None;

		// Token: 0x04002B99 RID: 11161
		private XBetterDictionary<uint, IFashionStorageSelect> m_activateHairColors;
	}
}
