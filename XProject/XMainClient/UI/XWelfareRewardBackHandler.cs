using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWelfareRewardBackHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/RewardBackFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			this.mTipName = (base.PanelObject.transform.FindChild("tipname").GetComponent("XUILabel") as IXUILabel);
			this.mPanelHint = (base.PanelObject.transform.FindChild("PanelHint").GetComponent("XUIPanel") as IXUIPanel);
			this.mTemplate = (base.PanelObject.transform.FindChild("Reward/RightView/ActivityTpl").GetComponent("XUISprite") as IXUISprite);
			this.mRewardBackPool.SetupPool(this.mTemplate.parent.gameObject, this.mTemplate.gameObject, 5U, false);
			this.mNormalFind = (base.PanelObject.transform.FindChild("buttons/SelectNormal").GetComponent("XUISprite") as IXUISprite);
			this.mPerfectFind = (base.PanelObject.transform.FindChild("buttons/SelectPerfect").GetComponent("XUISprite") as IXUISprite);
			this.mCloseDoFind = (base.PanelObject.transform.FindChild("PanelHint/back").GetComponent("XUISprite") as IXUISprite);
			this.mScrollView = (base.PanelObject.transform.FindChild("Reward/RightView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.mButtonsContent = (base.PanelObject.transform.FindChild("buttons").GetComponent("XUISprite") as IXUISprite);
			this.mAilin = (base.PanelObject.transform.FindChild("ailin").GetComponent("XUISprite") as IXUISprite);
			this.mFindBackName = (base.PanelObject.transform.FindChild("PanelHint/findname").GetComponent("XUILabel") as IXUILabel);
			this.mFindBackInfoLabel = (base.PanelObject.transform.FindChild("PanelHint/findinfo").GetComponent("XUILabel") as IXUILabel);
			this.mFindBackNum = (base.PanelObject.transform.FindChild("PanelHint/Count/number").GetComponent("XUILabel") as IXUILabel);
			this.mFindBackSub = (base.PanelObject.transform.FindChild("PanelHint/Count/Sub").GetComponent("XUIButton") as IXUIButton);
			this.mFindBackAdd = (base.PanelObject.transform.FindChild("PanelHint/Count/Add").GetComponent("XUIButton") as IXUIButton);
			this.mCostNum = (base.PanelObject.transform.FindChild("PanelHint/MoneyNum").GetComponent("XUILabel") as IXUILabel);
			this.mMoneyType = (base.PanelObject.transform.FindChild("PanelHint/MoneyNum/icon").GetComponent("XUISprite") as IXUISprite);
			this.mDoFindBack = (base.PanelObject.transform.FindChild("PanelHint/BtnOK").GetComponent("XUIButton") as IXUIButton);
			this.mCancelFindBack = (base.PanelObject.transform.FindChild("PanelHint/BtnNO").GetComponent("XUIButton") as IXUIButton);
			this.mItemTemplate = (base.PanelObject.transform.FindChild("PanelHint/ItemTemplate").GetComponent("XUISprite") as IXUISprite);
			this.mRewardItemPool.SetupPool(this.mPanelHint.gameObject, this.mItemTemplate.gameObject, 3U, false);
			this.mNumberInput = (base.PanelObject.transform.FindChild("PanelHint/Count").GetComponent("XUIInput") as IXUIInput);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.mPanelHint.SetVisible(false);
			this.mWanFindNum = 0;
			this.mFindMax = 0;
			this.mFindID = 0;
			int.TryParse(XSingleton<XGlobalConfig>.singleton.GetValue("FindBackTicketExchangeDragon"), out this.mBackItem2DragonCoin);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.mNormalFind.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnFindTypeClick));
			this.mNormalFind.ID = 0UL;
			this.mPerfectFind.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnFindTypeClick));
			this.mPerfectFind.ID = 1UL;
			this.mCloseDoFind.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseFindBorad));
			this.mFindBackSub.RegisterClickEventHandler(new ButtonClickEventHandler(this.SubFindCount));
			this.mFindBackAdd.RegisterClickEventHandler(new ButtonClickEventHandler(this.AddFindCount));
			this.mDoFindBack.RegisterClickEventHandler(new ButtonClickEventHandler(this.DoFindBack));
			this.mCancelFindBack.RegisterClickEventHandler(new ButtonClickEventHandler(this.CancelFindBack));
			this.mNumberInput.RegisterChangeEventHandler(new InputChangeEventHandler(this.InputChangeEventHandler));
		}

		private int compare(ItemFindBackInfo2Client a, ItemFindBackInfo2Client b)
		{
			return b.dayTime.CompareTo(a.dayTime);
		}

		private int compareids(int a, int b)
		{
			bool flag = this.mFindBackInfo[a].maxfindback == 0 && this.mFindBackInfo[b].maxfindback == 0;
			int result;
			if (flag)
			{
				result = b.CompareTo(a);
			}
			else
			{
				bool flag2 = this.mFindBackInfo[a].maxfindback == 0;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					bool flag3 = this.mFindBackInfo[b].maxfindback == 0;
					if (flag3)
					{
						result = -1;
					}
					else
					{
						bool flag4 = this.GetFindBackCost(this.mFindBackInfo[a], true) == 0 && this.GetFindBackCost(this.mFindBackInfo[a], false) == 0 && this.GetFindBackCost(this.mFindBackInfo[b], true) == 0 && this.GetFindBackCost(this.mFindBackInfo[b], false) == 0;
						if (flag4)
						{
							result = b.CompareTo(a);
						}
						else
						{
							bool flag5 = this.GetFindBackCost(this.mFindBackInfo[a], true) == 0 && this.GetFindBackCost(this.mFindBackInfo[a], false) == 0;
							if (flag5)
							{
								result = -1;
							}
							else
							{
								bool flag6 = this.GetFindBackCost(this.mFindBackInfo[b], true) == 0 && this.GetFindBackCost(this.mFindBackInfo[b], false) == 0;
								if (flag6)
								{
									result = 1;
								}
								else
								{
									bool flag7 = this.HasExpFindBack(this.mFindBackInfo[a]) && this.HasExpFindBack(this.mFindBackInfo[b]);
									if (flag7)
									{
										result = b.CompareTo(a);
									}
									else
									{
										bool flag8 = this.HasExpFindBack(this.mFindBackInfo[a]);
										if (flag8)
										{
											result = -1;
										}
										else
										{
											bool flag9 = this.HasExpFindBack(this.mFindBackInfo[b]);
											if (flag9)
											{
												result = 1;
											}
											else
											{
												bool flag10 = this.HasDiceBack(this.mFindBackInfo[a]) || this.HasDiceBack(this.mFindBackInfo[b]);
												if (flag10)
												{
													int num = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("RiskDiceMaxNum"));
													bool flag11 = XSuperRiskDocument.Doc.LeftDiceTime >= num;
													if (flag11)
													{
														bool flag12 = this.HasDiceBack(this.mFindBackInfo[a]);
														if (flag12)
														{
															return 1;
														}
														return -1;
													}
												}
												result = b.CompareTo(a);
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		private void InitBackData()
		{
			bool flag = this._doc == null;
			if (flag)
			{
				this._doc = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			}
			List<ItemFindBackInfo2Client> findBackInfo = this._doc.FindBackInfo;
			this.mFindBackInfo.Clear();
			this.mHasInfo = false;
			bool flag2 = findBackInfo != null;
			if (flag2)
			{
				for (int i = 0; i < findBackInfo.Count; i++)
				{
					bool flag3 = findBackInfo[i].dragonCoinFindBackItems.Count != 0 || findBackInfo[i].goldCoinFindBackItems.Count != 0;
					if (flag3)
					{
						this.mHasInfo = true;
					}
				}
			}
			bool flag4 = !this.mHasInfo;
			if (flag4)
			{
				bool flag5 = base.IsVisible();
				if (flag5)
				{
					this.mButtonsContent.SetVisible(false);
					this.mAilin.SetVisible(true);
					this.mTipName.SetVisible(false);
				}
			}
			else
			{
				bool flag6 = base.IsVisible();
				if (flag6)
				{
					this.mButtonsContent.SetVisible(true);
					this.mAilin.SetVisible(false);
				}
				findBackInfo.Sort(new Comparison<ItemFindBackInfo2Client>(this.compare));
				for (int j = 0; j < findBackInfo.Count; j++)
				{
					int num = XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(findBackInfo[j].id);
					bool flag7 = this.mFindBackInfo.ContainsKey(num);
					if (flag7)
					{
						this.mFindBackInfo[num].findbackinfo.Add(findBackInfo[j]);
					}
					else
					{
						FindBackData findBackData = new FindBackData();
						findBackData.findbackinfo.Add(findBackInfo[j]);
						this.mFindBackInfo[num] = findBackData;
						findBackData.findid = num;
						this.mFindBackInfo[num].isfind = false;
						this.mFindBackInfo[num].findindex = 0;
					}
					this.mFindBackInfo[num].maxfindback += findBackInfo[j].findBackCount;
					for (int k = 0; k < findBackInfo[j].goldCoinFindBackItems.Count; k++)
					{
						int itemID = (int)findBackInfo[j].goldCoinFindBackItems[k].itemID;
						bool flag8 = findBackInfo[j].findBackCount == 0 && !this.mFindBackInfo[num].isfind;
						if (flag8)
						{
							this.mFindBackInfo[num].findindex++;
						}
						bool flag9 = findBackInfo[j].findBackCount != 0;
						if (flag9)
						{
							this.mFindBackInfo[num].isfind = true;
						}
						bool flag10 = !this.mFindBackInfo[num].goldItemCount.ContainsKey(itemID);
						if (flag10)
						{
							this.mFindBackInfo[num].goldItemCount[itemID] = new List<int>();
						}
						this.mFindBackInfo[num].goldItemCount[itemID].Add((int)findBackInfo[j].goldCoinFindBackItems[k].itemCount);
					}
					List<KeyValuePair<int, List<int>>> list = new List<KeyValuePair<int, List<int>>>(this.mFindBackInfo[num].goldItemCount);
					list.Sort((KeyValuePair<int, List<int>> s1, KeyValuePair<int, List<int>> s2) => s1.Key.CompareTo(s2.Key));
					this.mFindBackInfo[num].goldItemCount.Clear();
					for (int l = 0; l < list.Count; l++)
					{
						this.mFindBackInfo[num].goldItemCount[list[l].Key] = list[l].Value;
					}
					bool flag11 = findBackInfo[j].id == ItemFindBackType.NestBack;
					bool flag12 = flag11;
					if (flag12)
					{
						ItemBackTable.RowData rewardBackByIndex = XWelfareDocument.GetRewardBackByIndex(num);
						bool flag13 = rewardBackByIndex != null;
						if (flag13)
						{
							for (int m = 0; m < (int)rewardBackByIndex.ItemDragonCoin.count; m++)
							{
								bool flag14 = !this.mFindBackInfo[num].dragonCoinItemCount.ContainsKey(rewardBackByIndex.ItemDragonCoin[m, 0]);
								if (flag14)
								{
									this.mFindBackInfo[num].dragonCoinItemCount[rewardBackByIndex.ItemDragonCoin[m, 0]] = new List<int>();
								}
								this.mFindBackInfo[num].dragonCoinItemCount[rewardBackByIndex.ItemDragonCoin[m, 0]].Add(rewardBackByIndex.ItemDragonCoin[m, 1]);
							}
						}
					}
					else
					{
						for (int n = 0; n < findBackInfo[j].dragonCoinFindBackItems.Count; n++)
						{
							int itemID2 = (int)findBackInfo[j].dragonCoinFindBackItems[n].itemID;
							bool flag15 = !this.mFindBackInfo[num].dragonCoinItemCount.ContainsKey(itemID2);
							if (flag15)
							{
								this.mFindBackInfo[num].dragonCoinItemCount[itemID2] = new List<int>();
							}
							this.mFindBackInfo[num].dragonCoinItemCount[itemID2].Add((int)findBackInfo[j].dragonCoinFindBackItems[n].itemCount);
						}
					}
					list = new List<KeyValuePair<int, List<int>>>(this.mFindBackInfo[num].dragonCoinItemCount);
					list.Sort((KeyValuePair<int, List<int>> s1, KeyValuePair<int, List<int>> s2) => s1.Key.CompareTo(s2.Key));
					this.mFindBackInfo[num].dragonCoinItemCount.Clear();
					for (int num2 = 0; num2 < list.Count; num2++)
					{
						this.mFindBackInfo[num].dragonCoinItemCount[list[num2].Key] = list[num2].Value;
					}
				}
			}
		}

		public bool HasRedPoint()
		{
			List<int> list = new List<int>(this.mFindBackInfo.Keys);
			int i = 0;
			while (i < this.mFindBackInfo.Count)
			{
				bool flag = XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.FATIGUE_GET) <= list[i] && XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.FATIGUE_BUY) >= list[i];
				if (!flag)
				{
					goto IL_61;
				}
				bool flag2 = (int)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.FATIGUE) >= this.mFullFatige;
				if (!flag2)
				{
					goto IL_61;
				}
				IL_DF:
				i++;
				continue;
				IL_61:
				bool flag3 = list[i] == XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.DICE_BACK);
				if (flag3)
				{
					int num = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("RiskDiceMaxNum"));
					bool flag4 = XSuperRiskDocument.Doc.LeftDiceTime >= num;
					if (flag4)
					{
						goto IL_DF;
					}
				}
				bool flag5 = this.mFindBackInfo[list[i]].maxfindback > 0;
				if (flag5)
				{
					return !this._doc.GetFirstClick(XSysDefine.XSyS_Welfare_RewardBack);
				}
				goto IL_DF;
			}
			return false;
		}

		public override void RefreshData()
		{
			this.InitBackData();
			bool flag = !base.IsVisible();
			if (!flag)
			{
				this.mRewardBackPool.ReturnAll(false);
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
				if (!flag2)
				{
					XSingleton<XDebug>.singleton.AddLog("Findback info num: ", this.mFindBackInfo.Count.ToString(), null, null, null, null, XDebugColor.XDebug_None);
					List<int> list = new List<int>(this.mFindBackInfo.Keys);
					int num = 0;
					uint level = XSingleton<XAttributeMgr>.singleton.XPlayerData.Level;
					XLevelSealDocument specificDocument = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
					ulong itemCount = XBagDocument.BagDoc.GetItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FINDBACK_ITEM));
					bool flag3 = list.Count > 1;
					if (flag3)
					{
						list.Sort(new Comparison<int>(this.compareids));
					}
					for (int i = 0; i < this.mFindBackInfo.Count; i++)
					{
						bool flag4 = ((this.mIsNormalFind && this.mFindBackInfo[list[i]].goldItemCount.Count == 0) || (!this.mIsNormalFind && this.mFindBackInfo[list[i]].dragonCoinItemCount.Count == 0)) && (this.GetFindBackCost(this.mFindBackInfo[list[i]], true) != 0 || this.GetFindBackCost(this.mFindBackInfo[list[i]], false) != 0);
						if (!flag4)
						{
							bool flag5 = (level == 32U || level == 40U || level == 50U) && specificDocument.IsInLevelSeal() && list[i] == 4;
							if (!flag5)
							{
								GameObject gameObject = this.mRewardBackPool.FetchGameObject(false);
								gameObject.transform.localPosition = new Vector3(this.mRewardBackPool.TplPos.x, this.mRewardBackPool.TplPos.y - (float)(num * this.mRewardBackPool.TplHeight), 0f);
								num++;
								XSingleton<XDebug>.singleton.AddLog("The item index: ", num.ToString(), null, null, null, null, XDebugColor.XDebug_None);
								IXUISprite ixuisprite = gameObject.transform.FindChild("Item").GetComponent("XUISprite") as IXUISprite;
								IXUISprite ixuisprite2 = gameObject.transform.FindChild("Item1").GetComponent("XUISprite") as IXUISprite;
								IXUISprite ixuisprite3 = gameObject.transform.FindChild("Item2").GetComponent("XUISprite") as IXUISprite;
								IXUILabel ixuilabel = gameObject.transform.FindChild("name").GetComponent("XUILabel") as IXUILabel;
								IXUILabel ixuilabel2 = gameObject.transform.FindChild("desc").GetComponent("XUILabel") as IXUILabel;
								IXUIButton ixuibutton = gameObject.transform.FindChild("Go").GetComponent("XUIButton") as IXUIButton;
								IXUIButton ixuibutton2 = gameObject.transform.FindChild("Free").GetComponent("XUIButton") as IXUIButton;
								IXUISprite ixuisprite4 = gameObject.transform.FindChild("Go/icon").GetComponent("XUISprite") as IXUISprite;
								IXUISprite ixuisprite5 = gameObject.transform.FindChild("GoBoader").GetComponent("XUISprite") as IXUISprite;
								ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.TryFindBack));
								ixuibutton.ID = (ulong)((long)list[i]);
								ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.TryFindBack));
								ixuibutton2.ID = (ulong)((long)list[i]);
								ixuisprite5.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.WarningFatigeFull));
								bool flag6 = this.GetFindBackCost(this.mFindBackInfo[list[i]], true) == 0 && this.GetFindBackCost(this.mFindBackInfo[list[i]], false) == 0;
								Dictionary<int, List<int>> dictionary;
								if (flag6)
								{
									ixuibutton.SetVisible(false);
									ixuibutton2.SetVisible(true);
									ixuibutton = ixuibutton2;
									bool flag7 = this.mIsNormalFind;
									if (flag7)
									{
										dictionary = this.mFindBackInfo[list[i]].goldItemCount;
									}
									else
									{
										dictionary = this.mFindBackInfo[list[i]].dragonCoinItemCount;
									}
								}
								else
								{
									ixuibutton.SetVisible(true);
									ixuibutton2.SetVisible(false);
									bool flag8 = this.mIsNormalFind;
									if (flag8)
									{
										dictionary = this.mFindBackInfo[list[i]].goldItemCount;
										ixuisprite4.SetSprite("icon-1");
									}
									else
									{
										dictionary = this.mFindBackInfo[list[i]].dragonCoinItemCount;
										this.mWanFindNum = 1;
										this.mCurData = this.mFindBackInfo[list[i]];
										bool flag9 = itemCount > 0UL && (int)itemCount * this.mBackItem2DragonCoin >= this.GetCurCost();
										if (flag9)
										{
											ixuisprite4.SetSprite("icon-18");
										}
										else
										{
											ixuisprite4.SetSprite("icon-28");
										}
									}
								}
								bool flag10 = dictionary == null || dictionary.Count == 0;
								if (flag10)
								{
									return;
								}
								IXUISprite[] array = new IXUISprite[]
								{
									ixuisprite,
									ixuisprite2,
									ixuisprite3
								};
								for (int j = 0; j < array.Length; j++)
								{
									array[j].SetVisible(false);
								}
								List<int> list2 = new List<int>(dictionary.Keys);
								for (int k = 0; k < dictionary.Count; k++)
								{
									bool flag11 = k >= 3;
									if (flag11)
									{
										break;
									}
									array[k].SetVisible(true);
									XItem xitem = XBagDocument.MakeXItem(list2[k], false);
									xitem.itemCount = dictionary[list2[k]][0];
									XSingleton<XItemDrawerMgr>.singleton.DrawItem(array[k].gameObject, xitem);
									IXUISprite ixuisprite6 = array[k].transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
									ixuisprite6.ID = (ulong)((long)list2[k]);
									ixuisprite6.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ShowItemTip));
								}
								ItemBackTable.RowData rewardBackByIndex = XWelfareDocument.GetRewardBackByIndex(list[i]);
								bool flag12 = rewardBackByIndex != null;
								if (flag12)
								{
									ixuilabel.SetText(rewardBackByIndex.SystemName);
									ixuilabel2.SetText(rewardBackByIndex.Desc);
								}
								ixuisprite5.SetVisible(false);
								bool flag13 = this.mFindBackInfo[list[i]].maxfindback <= 0;
								if (flag13)
								{
									ixuibutton.SetEnable(false, false);
								}
								else
								{
									bool flag14 = this.mFindBackInfo[list[i]].goldItemCount.ContainsKey(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FATIGUE)) || this.mFindBackInfo[list[i]].dragonCoinItemCount.ContainsKey(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FATIGUE));
									if (flag14)
									{
										bool flag15 = XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.FATIGUE) >= 200UL;
										if (flag15)
										{
											ixuibutton.SetEnable(false, false);
											ixuisprite5.SetVisible(true);
										}
										else
										{
											ixuibutton.SetEnable(true, false);
											ixuisprite5.SetVisible(false);
										}
									}
									else
									{
										bool flag16 = this.mFindBackInfo[list[i]].goldItemCount.ContainsKey(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DICE)) || this.mFindBackInfo[list[i]].dragonCoinItemCount.ContainsKey(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DICE));
										if (flag16)
										{
											int num2 = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("RiskDiceMaxNum"));
											bool flag17 = XSuperRiskDocument.Doc.LeftDiceTime >= num2;
											if (flag17)
											{
												ixuibutton.SetEnable(false, false);
											}
											else
											{
												ixuibutton.SetEnable(true, false);
											}
										}
										else
										{
											ixuibutton.SetEnable(true, false);
										}
									}
								}
							}
						}
					}
					bool flag18 = XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.FATIGUE) >= 200UL && this.mHasInfo;
					if (flag18)
					{
						this.mTipName.SetVisible(true);
					}
					else
					{
						this.mTipName.SetVisible(false);
					}
				}
			}
		}

		public void OnFindTypeClick(IXUISprite sp)
		{
			bool flag = sp.ID == 1UL;
			if (flag)
			{
				this.mIsNormalFind = true;
			}
			else
			{
				this.mIsNormalFind = false;
			}
			this.RefreshData();
			this.mScrollView.SetPosition(0f);
		}

		public void OnCloseFindBorad(IXUISprite sp)
		{
			this.mPanelHint.SetVisible(false);
		}

		private int GetFindBackCost(FindBackData data, bool isdragoncoin)
		{
			int num = 0;
			for (int i = 0; i < data.findbackinfo.Count; i++)
			{
				if (isdragoncoin)
				{
					num += data.findbackinfo[i].dragonCoinCost;
				}
				else
				{
					num += data.findbackinfo[i].goldCoinCost;
				}
			}
			return num;
		}

		private bool HasExpFindBack(FindBackData data)
		{
			List<int> list = new List<int>(data.goldItemCount.Keys);
			bool flag = list.Contains(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.EXP));
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				list = new List<int>(data.dragonCoinItemCount.Keys);
				bool flag2 = list.Contains(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.EXP));
				result = flag2;
			}
			return result;
		}

		private bool HasDiceBack(FindBackData data)
		{
			List<int> list = new List<int>(data.goldItemCount.Keys);
			bool flag = list.Contains(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DICE));
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				list = new List<int>(data.dragonCoinItemCount.Keys);
				bool flag2 = list.Contains(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DICE));
				result = flag2;
			}
			return result;
		}

		private void InitFindBackItem()
		{
			this.mRewardItemPool.FakeReturnAll();
			bool flag = this.mIsNormalFind;
			Dictionary<int, List<int>> dictionary;
			if (flag)
			{
				dictionary = this.mCurData.goldItemCount;
			}
			else
			{
				dictionary = this.mCurData.dragonCoinItemCount;
			}
			bool flag2 = dictionary == null || dictionary.Count == 0;
			if (!flag2)
			{
				List<int> list = new List<int>(dictionary.Keys);
				for (int i = 0; i < dictionary.Count; i++)
				{
					GameObject gameObject = this.mRewardItemPool.FetchGameObject(false);
					XItem xitem = XBagDocument.MakeXItem(list[i], false);
					ItemBackTable.RowData rewardBackByIndex = XWelfareDocument.GetRewardBackByIndex(this.mCurData.findid);
					bool flag3 = rewardBackByIndex != null;
					if (flag3)
					{
						int num = Mathf.Min(this.mCurData.findbackinfo[0].findBackCount, this.mWanFindNum);
						int num2 = (num == this.mWanFindNum) ? 0 : (this.mWanFindNum - num);
						xitem.itemCount = num * dictionary[list[i]][0];
						int num3 = 1;
						for (int j = 0; j < num2 / rewardBackByIndex.count; j++)
						{
							bool flag4 = j + 1 < dictionary[list[i]].Count;
							if (flag4)
							{
								xitem.itemCount += dictionary[list[i]][j + 1] * rewardBackByIndex.count;
								num3++;
							}
						}
						bool flag5 = num3 < dictionary[list[i]].Count;
						if (flag5)
						{
							xitem.itemCount += num2 % rewardBackByIndex.count * dictionary[list[i]][num3];
						}
					}
					int num4 = (i % 2 == 0) ? 1 : -1;
					int num5 = this.mRewardItemPool.TplWidth / 2;
					bool flag6 = list.Count % 2 == 1;
					if (flag6)
					{
						num5 = 0;
					}
					xitem.Description.ItemDrawer.DrawItem(gameObject, xitem, true);
					gameObject.transform.localPosition = new Vector3(this.mRewardItemPool.TplPos.x + (float)(num4 * ((i + 1) / 2) * this.mRewardItemPool.TplWidth) + (float)num5, this.mRewardItemPool.TplPos.y, this.mRewardItemPool.TplPos.z);
					IXUISprite ixuisprite = gameObject.GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)((long)list[i]);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ShowItemTip));
				}
			}
		}

		private bool TryFindBack(IXUIButton btn)
		{
			this.mFindID = (int)btn.ID;
			this.mWanFindNum = 1;
			this.mCurData = this.mFindBackInfo[this.mFindID];
			this.mFindMax = this.mCurData.maxfindback;
			this.mPanelHint.SetVisible(true);
			this.mRewardItemPool.ReturnAll(false);
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FINDBACK_ITEM));
			bool flag = !this.mIsNormalFind && (int)itemCount * this.mBackItem2DragonCoin >= this.GetCurCost();
			if (flag)
			{
				this.mIsToolFind = true;
			}
			else
			{
				this.mIsToolFind = false;
			}
			this.RefreshFindInfo();
			return true;
		}

		private int GetCurCost()
		{
			int num = 0;
			int num2 = this.mWanFindNum;
			bool flag = this.mIsNormalFind;
			if (flag)
			{
				for (int i = 0; i < this.mCurData.findbackinfo.Count; i++)
				{
					int num3 = (num2 < this.mCurData.findbackinfo[i].findBackCount) ? num2 : this.mCurData.findbackinfo[i].findBackCount;
					bool flag2 = num2 > 0;
					if (!flag2)
					{
						break;
					}
					num += num3 * this.mCurData.findbackinfo[i].goldCoinCost;
					num2 -= this.mCurData.findbackinfo[i].findBackCount;
				}
			}
			else
			{
				for (int j = 0; j < this.mCurData.findbackinfo.Count; j++)
				{
					int num4 = (num2 < this.mCurData.findbackinfo[j].findBackCount) ? num2 : this.mCurData.findbackinfo[j].findBackCount;
					bool flag3 = num2 > 0;
					if (!flag3)
					{
						break;
					}
					num += num4 * this.mCurData.findbackinfo[j].dragonCoinCost;
					num2 -= this.mCurData.findbackinfo[j].findBackCount;
				}
			}
			return num;
		}

		public int GetSingleFindBackNum()
		{
			bool flag = this.mIsNormalFind;
			if (flag)
			{
				List<List<int>> list = new List<List<int>>(this.mCurData.goldItemCount.Values);
				bool flag2 = list.Count > 0;
				if (flag2)
				{
					return list[0][0];
				}
			}
			else
			{
				List<List<int>> list2 = new List<List<int>>(this.mCurData.dragonCoinItemCount.Values);
				bool flag3 = list2.Count > 0;
				if (flag3)
				{
					return list2[0][0];
				}
			}
			return 0;
		}

		private void RefreshFindInfo()
		{
			this.mFindBackNum.SetText(this.mWanFindNum.ToString());
			this.mCostNum.SetText(this.GetCurCost().ToString());
			bool flag = this.mIsNormalFind;
			if (flag)
			{
				this.mMoneyType.SetSprite("icon-1");
				this.mFindBackName.SetText(XSingleton<XStringTable>.singleton.GetString("WELFARE_GOLD_BACK"));
			}
			else
			{
				bool flag2 = !this.mIsToolFind;
				if (flag2)
				{
					this.mMoneyType.SetSprite("icon-28");
				}
				else
				{
					this.mMoneyType.SetSprite("icon-18");
					this.mCostNum.SetText((this.GetCurCost() / this.mBackItem2DragonCoin).ToString());
				}
				this.mFindBackName.SetText(XSingleton<XStringTable>.singleton.GetString("WELFARE_DRAGON_BACK"));
			}
			this.InitFindBackItem();
		}

		private bool SubFindCount(IXUIButton btn)
		{
			this.mWanFindNum--;
			bool flag = this.mWanFindNum <= 0;
			if (flag)
			{
				this.mWanFindNum = 1;
			}
			this.mNumberInput.SetText(this.mWanFindNum.ToString());
			this.RefreshFindInfo();
			return true;
		}

		private bool AddFindCount(IXUIButton btn)
		{
			this.mWanFindNum++;
			bool flag = false;
			ulong itemCount = XBagDocument.BagDoc.GetItemCount(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.FINDBACK_ITEM));
			bool flag2 = this.mIsToolFind;
			if (flag2)
			{
				bool flag3 = this.mWanFindNum <= this.mFindMax;
				if (flag3)
				{
					bool flag4 = this.GetCurCost() > (int)itemCount * this.mBackItem2DragonCoin;
					if (flag4)
					{
						this.mWanFindNum--;
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("WELFARE_ITEMMAX"), "fece00");
						flag = true;
					}
				}
				else
				{
					bool flag5 = this.mWanFindNum > this.mFindMax;
					if (flag5)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("WELFARE_REACH_MAX"), "fece00");
						flag = true;
					}
					this.mWanFindNum = ((this.mFindMax > 0) ? this.mFindMax : 1);
				}
			}
			else
			{
				bool flag6 = this.mWanFindNum >= this.mFindMax;
				if (flag6)
				{
					bool flag7 = this.mWanFindNum > this.mFindMax;
					if (flag7)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("WELFARE_REACH_MAX"), "fece00");
						flag = true;
					}
					this.mWanFindNum = ((this.mFindMax > 0) ? this.mFindMax : 1);
				}
			}
			bool flag8 = XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.FATIGUE_GET) <= this.mCurData.findid && XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.FATIGUE_BUY) >= this.mCurData.findid;
			if (flag8)
			{
				bool flag9 = (int)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.FATIGUE) + (this.mWanFindNum - 1) * this.GetSingleFindBackNum() >= this.mFullFatige && this.mWanFindNum > 1;
				if (flag9)
				{
					this.mWanFindNum--;
					bool flag10 = !flag;
					if (flag10)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("WELFARE_FATIGE_MAX"), "fece00");
					}
				}
			}
			bool flag11 = XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.DICE_BACK) == this.mCurData.findid;
			if (flag11)
			{
				int num = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("RiskDiceMaxNum"));
				bool flag12 = XSuperRiskDocument.Doc.LeftDiceTime + this.mWanFindNum * this.GetSingleFindBackNum() > num && this.mWanFindNum > 1;
				if (flag12)
				{
					this.mWanFindNum--;
					bool flag13 = !flag;
					if (flag13)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("WELFARE_REACH_MAX"), "fece00");
					}
				}
			}
			this.mNumberInput.SetText(this.mWanFindNum.ToString());
			this.RefreshFindInfo();
			return true;
		}

		private bool DoFindBack(IXUIButton btn)
		{
			bool flag = this.mWanFindNum == 0;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.FATIGUE_GET) <= this.mCurData.findid && XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.FATIGUE_BUY) >= this.mCurData.findid;
				if (flag2)
				{
					int num = (int)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.FATIGUE);
					bool flag3 = num + this.mWanFindNum * this.GetSingleFindBackNum() > int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MaxFatigue"));
					if (flag3)
					{
						XSingleton<UiUtility>.singleton.ShowFatigueSureDlg(new ButtonClickEventHandler(this.GetFatigueSure));
						return true;
					}
					bool flag4 = num + this.mWanFindNum * this.GetSingleFindBackNum() >= this.mMaxFatige;
					if (flag4)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("WELFARE_FATIGE_FULL"), "fece00");
						return false;
					}
				}
				bool flag5 = XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.DICE_BACK) == this.mCurData.findid;
				if (flag5)
				{
					int num2 = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("RiskDiceMaxNum"));
					bool flag6 = XSuperRiskDocument.Doc.LeftDiceTime >= num2;
					if (flag6)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("WELFARE_REACH_MAX"), "fece00");
						return false;
					}
				}
				bool flag7 = this.mIsNormalFind;
				if (flag7)
				{
					int num3 = (int)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.GOLD);
					bool flag8 = num3 < this.GetCurCost();
					if (flag8)
					{
						int num4 = this.GetCurCost() - num3;
						int num5 = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("GragonCoinExchangeGold"));
						int num6 = (num4 % num5 == 0) ? (num4 / num5) : (num4 / num5 + 1);
						int num7 = (int)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.DRAGON_COIN);
						bool flag9 = num7 > num6;
						if (flag9)
						{
							string text = XBagDocument.GetItemConf(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.GOLD)).ItemName[0];
							string text2 = XBagDocument.GetItemConf(XFastEnumIntEqualityComparer<ItemEnum>.ToInt(ItemEnum.DRAGON_COIN)).ItemName[0];
							int num8 = num6 * num5;
							DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
							DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
							DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(string.Format(XStringDefineProxy.GetString("WELFARE_NOT_ENOUGH"), new object[]
							{
								num4,
								text,
								num6,
								text2,
								num8,
								text
							}), XStringDefineProxy.GetString("YES"), XStringDefineProxy.GetString("NO"));
							DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnDoBuy), new ButtonClickEventHandler(this.OnCencelBuy));
						}
						else
						{
							DlgBase<XFpStrengthenView, XFPStrengthenBehaviour>.singleton.ShowContent(FunctionDef.JINBI);
						}
						return false;
					}
				}
				else
				{
					int num9 = (int)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.DRAGON_COIN);
					bool flag10 = !this.mIsToolFind && num9 < this.GetCurCost();
					if (flag10)
					{
						int num10 = (int)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.DIAMOND);
						bool flag11 = num10 > this.GetCurCost() - num9;
						if (flag11)
						{
							DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(ItemEnum.DRAGON_COIN);
						}
						else
						{
							DlgBase<XFpStrengthenView, XFPStrengthenBehaviour>.singleton.ShowContent(FunctionDef.LONGBI);
						}
						return false;
					}
				}
				this.mPanelHint.SetVisible(false);
				RpcC2G_ItemFindBack rpcC2G_ItemFindBack = new RpcC2G_ItemFindBack();
				rpcC2G_ItemFindBack.oArg.id = (ItemFindBackType)this.mCurData.findid;
				rpcC2G_ItemFindBack.oArg.findBackCount = this.mWanFindNum;
				rpcC2G_ItemFindBack.oArg.backType = 1 + (this.mIsNormalFind ? 1 : (this.mIsToolFind ? 2 : 0));
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ItemFindBack);
				result = true;
			}
			return result;
		}

		private bool GetFatigueSure(IXUIButton btn)
		{
			this.mPanelHint.SetVisible(false);
			RpcC2G_ItemFindBack rpcC2G_ItemFindBack = new RpcC2G_ItemFindBack();
			rpcC2G_ItemFindBack.oArg.id = (ItemFindBackType)this.mCurData.findid;
			rpcC2G_ItemFindBack.oArg.findBackCount = this.mWanFindNum;
			rpcC2G_ItemFindBack.oArg.backType = 1 + (this.mIsNormalFind ? 1 : (this.mIsToolFind ? 2 : 0));
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ItemFindBack);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		public bool OnDoBuy(IXUIButton btn)
		{
			RpcC2G_ItemFindBack rpcC2G_ItemFindBack = new RpcC2G_ItemFindBack();
			rpcC2G_ItemFindBack.oArg.id = (ItemFindBackType)this.mCurData.findid;
			rpcC2G_ItemFindBack.oArg.findBackCount = this.mWanFindNum;
			rpcC2G_ItemFindBack.oArg.backType = 1 + (this.mIsNormalFind ? 1 : (this.mIsToolFind ? 2 : 0));
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_ItemFindBack);
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this.mPanelHint.SetVisible(false);
			return true;
		}

		public bool OnCencelBuy(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			this.mPanelHint.SetVisible(false);
			return true;
		}

		private bool CancelFindBack(IXUIButton btn)
		{
			this.mPanelHint.SetVisible(false);
			return true;
		}

		private void WarningFatigeFull(IXUISprite sp)
		{
			XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("WELFARE_FATIGE_ERROR"), "fece00");
		}

		private void ShowItemTip(IXUISprite sp)
		{
			XItem mainItem = XBagDocument.MakeXItem((int)sp.ID, false);
			XSingleton<UiUtility>.singleton.ShowTooltipDialog(mainItem, null, sp, false, 0U);
		}

		private void InputChangeEventHandler(IXUIInput input)
		{
			bool flag = this.mCurData == null;
			if (!flag)
			{
				bool flag2 = false;
				int num = 1;
				int.TryParse(input.GetText(), out num);
				bool flag3 = num >= this.mFindMax;
				if (flag3)
				{
					bool flag4 = num > this.mFindMax;
					if (flag4)
					{
						flag2 = true;
					}
					num = ((this.mFindMax > 0) ? this.mFindMax : 1);
				}
				bool flag5 = XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.FATIGUE_GET) <= this.mCurData.findid && XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.FATIGUE_BUY) >= this.mCurData.findid;
				if (flag5)
				{
					bool flag6 = (int)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.FATIGUE) + (num - 1) * this.GetSingleFindBackNum() >= this.mFullFatige && num > 1 && this.GetSingleFindBackNum() > 0;
					if (flag6)
					{
						num = (this.mFullFatige - (int)XBagDocument.BagDoc.GetVirtualItemCount(ItemEnum.FATIGUE)) / this.GetSingleFindBackNum();
					}
				}
				bool flag7 = XFastEnumIntEqualityComparer<ItemFindBackType>.ToInt(ItemFindBackType.DICE_BACK) == this.mCurData.findid;
				if (flag7)
				{
					int num2 = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("RiskDiceMaxNum"));
					bool flag8 = XSuperRiskDocument.Doc.LeftDiceTime + num * this.GetSingleFindBackNum() > num2 && num > 1 && this.GetSingleFindBackNum() > 0;
					if (flag8)
					{
						num = (num2 - XSuperRiskDocument.Doc.LeftDiceTime) / this.GetSingleFindBackNum();
						bool flag9 = !flag2;
						if (flag9)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("WELFARE_REACH_MAX"), "fece00");
						}
					}
				}
				this.mWanFindNum = num;
				input.SetText(num.ToString());
				this.RefreshFindInfo();
			}
		}

		private IXUILabel mTipName;

		private IXUIPanel mPanelHint;

		private IXUISprite mTemplate;

		private IXUISprite mNormalFind;

		private IXUISprite mPerfectFind;

		private bool mIsNormalFind = false;

		private bool mIsToolFind = false;

		private IXUISprite mCloseDoFind;

		private IXUIScrollView mScrollView;

		private IXUISprite mButtonsContent;

		private IXUISprite mAilin;

		private IXUILabel mFindBackName;

		private IXUILabel mFindBackInfoLabel;

		private IXUILabel mFindBackNum;

		private IXUIButton mFindBackSub;

		private IXUIButton mFindBackAdd;

		private IXUILabel mCostNum;

		private IXUISprite mMoneyType;

		private IXUIButton mDoFindBack;

		private IXUIButton mCancelFindBack;

		private IXUISprite mItemTemplate;

		private IXUIInput mNumberInput;

		private XUIPool mRewardBackPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool mRewardItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Dictionary<int, FindBackData> mFindBackInfo = new Dictionary<int, FindBackData>();

		private XWelfareDocument _doc;

		private int mWanFindNum = 0;

		private int mFindMax = 0;

		private int mFindID = 0;

		private FindBackData mCurData = null;

		private int mMaxFatige = 225000;

		private int mFullFatige = 200000;

		private bool mHasInfo = false;

		private int mBackItem2DragonCoin = 5;
	}
}
