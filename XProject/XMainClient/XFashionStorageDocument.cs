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

	internal class XFashionStorageDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XFashionStorageDocument.uuID;
			}
		}

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

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

		public static FashionSuitSpecialEffects.RowData GetSpecialEffect(uint id)
		{
			return XFashionStorageDocument.m_specialEffects.GetBysuitid(id);
		}

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

		public static void Execute(OnLoadedCallback callback = null)
		{
			XFashionStorageDocument.AsyncLoader.AddTask("Table/FashionCharm", XFashionStorageDocument.m_fashionCharmTable, false);
			XFashionStorageDocument.AsyncLoader.AddTask("Table/FashionHair", XFashionStorageDocument.m_fashionHair, false);
			XFashionStorageDocument.AsyncLoader.AddTask("Table/HairColorTable", XFashionStorageDocument.m_hairColorTable, false);
			XFashionStorageDocument.AsyncLoader.AddTask("Table/FashionSuitSpecialEffects", XFashionStorageDocument.m_specialEffects, false);
			XFashionStorageDocument.AsyncLoader.Execute(null);
		}

		public List<uint> DisplayFashion
		{
			get
			{
				return this.m_displayFashion;
			}
		}

		public List<uint> SpecialEffects
		{
			get
			{
				return this.m_special_effects;
			}
		}

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

		public bool TryGetCharmAttr(out Dictionary<uint, uint> attr, out int activate_count, out int activate_total)
		{
			attr = new Dictionary<uint, uint>();
			activate_count = 0;
			activate_total = 0;
			this.AnalysisCharmAttr(this.m_equipCharm, ref attr, ref activate_total, ref activate_count);
			this.AnalysisCharmAttr(this.m_fashionCharm, ref attr, ref activate_total, ref activate_count);
			return activate_count > 0;
		}

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

		public bool RedPoint
		{
			get
			{
				return XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Fashion_OutLook) && this.m_redPoint;
			}
		}

		public bool EquipRedPoint
		{
			get
			{
				return this.m_equipRedPoint;
			}
		}

		public bool FashionRedPoint
		{
			get
			{
				return this.m_fashionRedPoint;
			}
		}

		public bool SuitRedPoint
		{
			get
			{
				return this.m_suitSuitRedPoint;
			}
		}

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

		public bool InDisplay(uint itemid)
		{
			return this.m_ownDisplayItems != null && this.m_ownDisplayItems.Contains(itemid);
		}

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

		private void RefreshView()
		{
			bool flag = DlgBase<FashionStorageDlg, FashionStorageBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<FashionStorageDlg, FashionStorageBehaviour>.singleton.Refresh();
			}
		}

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

		public bool FashionInBody(int itemid)
		{
			return this.m_displayFashion != null && itemid > 0 && this.m_displayFashion.Contains((uint)itemid);
		}

		public bool TryGetFashionChaim(uint suitID, out FashionCharm.RowData charm)
		{
			charm = XFashionStorageDocument.m_fashionCharmTable.GetBySuitID(suitID);
			return charm != null;
		}

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

		public void SendActivateFashion(uint suitID)
		{
			RpcC2G_ActivateFashionCharm rpcC2G_ActivateFashionCharm = new RpcC2G_ActivateFashionCharm();
			rpcC2G_ActivateFashionCharm.oArg.suit_id = suitID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ActivateFashionCharm);
		}

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

		public uint selfEffectID
		{
			get
			{
				return this.m_selfEffectID;
			}
		}

		public bool isActivateEffect(uint effectID)
		{
			return effectID == 0U || this.m_special_effects.Contains(effectID);
		}

		public XBetterList<IFashionStorageSelect> GetActivateSuits()
		{
			return (this.m_activateSuitEffects != null) ? this.m_activateSuitEffects.BufferValues : null;
		}

		public IFashionStorageSelect GetActivateSuit(uint suitID)
		{
			return (this.m_activateSuitEffects == null) ? null : this.m_activateSuitEffects[suitID];
		}

		public void GetActiveSuitEffect(uint suitEeffectID)
		{
			this.preview = FashionStoragePreview.None;
			RpcC2G_ChooseSpecialEffects rpcC2G_ChooseSpecialEffects = new RpcC2G_ChooseSpecialEffects();
			rpcC2G_ChooseSpecialEffects.oArg.special_effects_id = suitEeffectID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ChooseSpecialEffects);
		}

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

		public static uint HairColorID
		{
			get
			{
				XFashionStorageDocument specificDocument = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
				return specificDocument.m_selfHairColor;
			}
		}

		public uint selfHairColor
		{
			get
			{
				return this.m_selfHairColor;
			}
		}

		public IFashionStorageSelect GetFashionHair(uint hairID)
		{
			return this.m_activateHairColors.ContainsKey(hairID) ? this.m_activateHairColors[hairID] : null;
		}

		public uint CurHairColor
		{
			get
			{
				return this.m_selfHairColor;
			}
		}

		public FashionHair.RowData GetFashionHairData(uint hairID)
		{
			return XFashionStorageDocument.m_fashionHair.GetByHairID(hairID);
		}

		public HairColorTable.RowData GetHairColorData(uint colorID)
		{
			return XFashionStorageDocument.m_hairColorTable.GetByID(colorID);
		}

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

		public bool TryGetSelfHairColor(out HairColorTable.RowData hcolor)
		{
			return this.TryGetHairColor(this.m_selfHairColor, out hcolor);
		}

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

		public bool IsActivateHairColor(uint hairID, uint colorID)
		{
			return this.m_activateHairColors.ContainsKey(hairID) && this.m_activateHairColors[hairID].GetItems().Contains(colorID);
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("FashionStorageDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static FashionCharm m_fashionCharmTable = new FashionCharm();

		private static FashionSuitSpecialEffects m_specialEffects = new FashionSuitSpecialEffects();

		private static Dictionary<uint, uint> m_charmMap = new Dictionary<uint, uint>();

		private static HairColorTable m_hairColorTable = new HairColorTable();

		private static FashionHair m_fashionHair = new FashionHair();

		private static uint[] m_specialEffectIDs;

		private List<uint> m_displayFashion = new List<uint>();

		private List<uint> m_special_effects = new List<uint>();

		private List<ActivateFashionCharm> m_activateCharms;

		private List<uint> m_ownDisplayItems;

		private XBetterDictionary<int, IFashionStorageSelect> m_partDisplay;

		private XBetterDictionary<int, IFashionStorageSelect> m_fashionCharm;

		private XBetterDictionary<int, IFashionStorageSelect> m_equipCharm;

		public FashionStorageType fashionStorageType = FashionStorageType.OutLook;

		private bool m_redPoint = false;

		private bool m_equipRedPoint = false;

		private bool m_fashionRedPoint = false;

		private bool m_suitSuitRedPoint = false;

		private bool m_showEffect = false;

		private uint m_selfEffectID = 0U;

		public uint previewEffectID = 0U;

		private XBetterDictionary<uint, IFashionStorageSelect> m_activateSuitEffects;

		private uint m_selfHairColor = 0U;

		public uint previewHairColor = 0U;

		public uint selectHairID = 0U;

		public FashionStoragePreview preview = FashionStoragePreview.None;

		private XBetterDictionary<uint, IFashionStorageSelect> m_activateHairColors;
	}
}
