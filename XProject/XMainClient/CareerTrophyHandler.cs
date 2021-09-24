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

	internal class CareerTrophyHandler : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XPersonalCareerDocument>(XPersonalCareerDocument.uuID);
			for (int i = 0; i < XPersonalCareerDocument.TrophyInfoTable.Table.Length; i++)
			{
				CareerTrophyHandler.TrophyData trophyData = new CareerTrophyHandler.TrophyData();
				trophyData.ID = XPersonalCareerDocument.TrophyInfoTable.Table[i].ID;
				trophyData.SortID = i;
				this.m_TrophyData.Add(trophyData);
			}
			this.m_GloryExp = (base.transform.Find("GloryLevel/Exp").GetComponent("XUILabel") as IXUILabel);
			this.m_GloryLevel = (base.transform.Find("GloryLevel/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_NextRewardLevel = (base.transform.Find("NextRewardLevel").GetComponent("XUILabel") as IXUILabel);
			this.m_RewardItem = base.transform.Find("Item");
			this.m_HonorRewardOpen = (base.transform.Find("Reward").GetComponent("XUIButton") as IXUIButton);
			this.m_WrapContent = (base.transform.Find("TrophyFrame/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ListScrollView = (base.transform.Find("TrophyFrame").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_Push = (base.transform.Find("Push").GetComponent("XUIButton") as IXUIButton);
			this.m_Share = (base.transform.Find("Share").GetComponent("XUIButton") as IXUIButton);
			this.m_TrophyDetailFrame = base.transform.Find("TrophyDetail");
			this.m_TrophyClose = (this.m_TrophyDetailFrame.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_TrophyTitle = (this.m_TrophyDetailFrame.Find("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_TrophyPool.SetupPool(null, this.m_TrophyDetailFrame.Find("TrophyDetailTpl").gameObject, 3U, false);
			this.m_HonorRewardFrame = base.transform.Find("PointRewardFrame");
			this.m_HonorRewardClose = (this.m_HonorRewardFrame.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_HonorScrollView = (this.m_HonorRewardFrame.Find("Bg/Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_HonorCurrentLevel = (this.m_HonorRewardFrame.Find("Bg/CurrentPoint/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_HonorRewardPool.SetupPool(null, this.m_HonorRewardFrame.Find("Bg/Bg/ScrollView/RewardTpl").gameObject, 8U, false);
			this.m_HonorItemPool.SetupPool(null, this.m_HonorRewardFrame.Find("Bg/Bg/ScrollView/Item").gameObject, 5U, false);
			this.InitShow();
		}

		protected override string FileName
		{
			get
			{
				return "GameSystem/PersonalCareer/CareerTrophy";
			}
		}

		public override void RegisterEvent()
		{
			this.m_Push.RegisterClickEventHandler(new ButtonClickEventHandler(this._PushBtnClick));
			this.m_Share.RegisterClickEventHandler(new ButtonClickEventHandler(this._ShareBtnClick));
			this.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._OnListItemUpdated));
			this.m_TrophyClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTrophyCloseClicked));
			this.m_HonorRewardOpen.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHonorRewardOpenClick));
			this.m_HonorRewardClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHonorRewardCloseClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
		}

		protected override void OnHide()
		{
			this.ClearPreTabTextures();
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		public void ClearPreTabTextures()
		{
			foreach (KeyValuePair<Transform, IXUITexture> keyValuePair in this._WrapTextureList)
			{
				IXUITexture value = keyValuePair.Value;
				value.SetTexturePath("");
			}
			this._WrapTextureList.Clear();
		}

		private void InitShow()
		{
			this.m_GloryLevel.SetText("");
			this.m_GloryExp.SetText("");
			this.m_NextRewardLevel.SetText("");
			this.m_RewardItem.gameObject.SetActive(false);
			this.m_TrophyDetailFrame.gameObject.SetActive(false);
			this.m_HonorRewardFrame.gameObject.SetActive(false);
		}

		public void SetData(StageTrophy data)
		{
			bool flag = data != null;
			if (flag)
			{
				this.curLevel = data.honour_rank;
				this.m_GloryLevel.SetText(this.curLevel.ToString());
				TrophyReward.RowData rowData = XPersonalCareerDocument.GetTrophyReward((int)this.curLevel);
				rowData = this.doc.ProcessHonorLevelMax(rowData);
				this.m_GloryExp.SetText(string.Format("({0}/{1})", data.total_score.ToString(), rowData.TrophyScore.ToString()));
				TrophyReward.RowData honorNextReward = XPersonalCareerDocument.GetHonorNextReward(rowData.HonourRank);
				bool flag2 = honorNextReward != null && honorNextReward.Rewards.Count > 0;
				if (flag2)
				{
					this.m_NextRewardLevel.SetText(string.Format(XStringDefineProxy.GetString("CAREER_TROPHY_LEVEL_REWARD"), honorNextReward.HonourRank.ToString()));
					this.m_RewardItem.gameObject.SetActive(true);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_RewardItem.gameObject, (int)honorNextReward.Rewards[0, 0], (int)honorNextReward.Rewards[0, 1], false);
					IXUISprite ixuisprite = this.m_RewardItem.Find("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)honorNextReward.Rewards[0, 0];
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
				else
				{
					this.m_NextRewardLevel.SetText(string.Format(XStringDefineProxy.GetString("CAREER_TROPHY_LEVEL_REWARD_MAX"), new object[0]));
					this.m_RewardItem.gameObject.SetActive(false);
				}
				for (int i = 0; i < this.m_TrophyData.Count; i++)
				{
					this.m_TrophyData[i].Clear();
				}
				XSingleton<XDebug>.singleton.AddGreenLog("trophydata.Count:" + data.trophydata.Count, null, null, null, null, null);
				for (int j = 0; j < data.trophydata.Count; j++)
				{
					List<TrophyInfo.RowData> trophyTableDataToSceneID = XPersonalCareerDocument.GetTrophyTableDataToSceneID(data.trophydata[j].scene_id);
					for (int k = 0; k < trophyTableDataToSceneID.Count; k++)
					{
						CareerTrophyHandler.TrophyData trophyData = this.GetTrophyData(trophyTableDataToSceneID[k].ID);
						trophyData.SetData(data.trophydata[j], trophyTableDataToSceneID[k].ID);
					}
				}
			}
			this.m_TrophyData.Sort(new Comparison<CareerTrophyHandler.TrophyData>(this._Compare));
			this.RefreshList(true);
		}

		public void RefreshList(bool bResetPosition = true)
		{
			int count = this.m_TrophyData.Count;
			this.m_WrapContent.SetContentCount(count, false);
			if (bResetPosition)
			{
				this.m_ListScrollView.ResetPosition();
			}
			else
			{
				this.m_WrapContent.RefreshAllVisibleContents();
			}
		}

		private void _OnListItemUpdated(Transform t, int index)
		{
			bool flag = index < 0;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("index:" + index, null, null, null, null, null);
			}
			else
			{
				Transform transform = t.Find("Bg");
				bool flag2 = index >= this.m_TrophyData.Count;
				if (flag2)
				{
					transform.gameObject.SetActive(false);
				}
				else
				{
					transform.gameObject.SetActive(true);
					TrophyInfo.RowData trophyTableData = XPersonalCareerDocument.GetTrophyTableData(this.m_TrophyData[index].ID);
					IXUILabel ixuilabel = transform.Find("Name").GetComponent("XUILabel") as IXUILabel;
					bool flag3 = trophyTableData != null;
					if (flag3)
					{
						ixuilabel.SetText(trophyTableData.Name);
					}
					TrophyDetail bestTrophy = this.m_TrophyData[index].GetBestTrophy();
					IXUILabel ixuilabel2 = transform.Find("Time").GetComponent("XUILabel") as IXUILabel;
					bool flag4 = bestTrophy != null;
					string text;
					if (flag4)
					{
						text = XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)bestTrophy.trophy_time, XStringDefineProxy.GetString("CAREER_TROPHY_TIME"), true);
					}
					else
					{
						text = XStringDefineProxy.GetString("CAREER_TROPHY_UNREACH");
					}
					ixuilabel2.SetText(text);
					IXUITexture ixuitexture = transform.Find("Trophy").GetComponent("XUITexture") as IXUITexture;
					int num = 0;
					bool flag5 = bestTrophy != null;
					if (flag5)
					{
						num = (int)bestTrophy.tropy_order;
					}
					ixuitexture.SetTexturePath(this.GetTrophyTex(num));
					this._WrapTextureList[t] = ixuitexture;
					IXUISprite ixuisprite = ixuitexture.gameObject.transform.Find("P").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.SetSprite(trophyTableData.Icon);
					Transform transform2 = transform.Find("Block");
					transform2.gameObject.SetActive(num == 0);
					IXUISprite ixuisprite2 = t.GetComponent("XUISprite") as IXUISprite;
					ixuisprite2.ID = (ulong)this.m_TrophyData[index].ID;
					ixuisprite2.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OpenTrophyClick));
				}
			}
		}

		private int _Compare(CareerTrophyHandler.TrophyData left, CareerTrophyHandler.TrophyData right)
		{
			int num = (left.trophyDetail == null) ? 1 : 0;
			int num2 = (right.trophyDetail == null) ? 1 : 0;
			bool flag = num == num2;
			int result;
			if (flag)
			{
				result = left.SortID.CompareTo(right.SortID);
			}
			else
			{
				result = num.CompareTo(num2);
			}
			return result;
		}

		private CareerTrophyHandler.TrophyData GetTrophyData(uint ID)
		{
			for (int i = 0; i < this.m_TrophyData.Count; i++)
			{
				bool flag = this.m_TrophyData[i].ID == ID;
				if (flag)
				{
					return this.m_TrophyData[i];
				}
			}
			XSingleton<XDebug>.singleton.AddErrorLog("TrophyData:" + ID + " No Find", null, null, null, null, null);
			return new CareerTrophyHandler.TrophyData();
		}

		private string GetTrophyTex(int data)
		{
			bool flag = data == 1;
			string result;
			if (flag)
			{
				result = "atlas/UI/common/Pic/tex_glory4";
			}
			else
			{
				bool flag2 = data == 2;
				if (flag2)
				{
					result = "atlas/UI/common/Pic/tex_glory5";
				}
				else
				{
					bool flag3 = data == 3;
					if (flag3)
					{
						result = "atlas/UI/common/Pic/tex_glory6";
					}
					else
					{
						result = "atlas/UI/common/Pic/tex_glory4";
					}
				}
			}
			return result;
		}

		public bool OnTrophyCloseClicked(IXUIButton btn)
		{
			this.m_TrophyDetailFrame.gameObject.SetActive(false);
			return true;
		}

		private void RefreshTrophyDetail(uint ID)
		{
			TrophyInfo.RowData trophyTableData = XPersonalCareerDocument.GetTrophyTableData(ID);
			CareerTrophyHandler.TrophyData trophyData = this.GetTrophyData(ID);
			this.m_TrophyPool.FakeReturnAll();
			for (int i = 0; i < 3; i++)
			{
				GameObject gameObject = this.m_TrophyPool.FetchGameObject(false);
				Transform transform = this.m_TrophyDetailFrame.FindChild(string.Format("Trophy/Trophy{0}", i));
				XSingleton<UiUtility>.singleton.AddChild(transform, gameObject.transform);
				IXUILabel ixuilabel = gameObject.transform.Find("Bg/Name").GetComponent("XUILabel") as IXUILabel;
				bool flag = trophyTableData != null;
				if (flag)
				{
					ixuilabel.SetText(trophyTableData.Name);
				}
				bool flag2 = trophyTableData != null;
				if (flag2)
				{
					this.m_TrophyTitle.SetText(trophyTableData.Name);
				}
				IXUILabel ixuilabel2 = gameObject.transform.Find("Bg/Point").GetComponent("XUILabel") as IXUILabel;
				bool flag3 = trophyTableData != null;
				if (flag3)
				{
					ixuilabel2.SetText(string.Format(XStringDefineProxy.GetString("CAREER_TROPHY_POINT"), trophyTableData.TrophyScore[i]));
				}
				IXUITexture ixuitexture = gameObject.transform.Find("Bg/Tex").GetComponent("XUITexture") as IXUITexture;
				ixuitexture.SetTexturePath(this.GetTrophyTex(i + 1));
				this._WrapTextureList[transform] = ixuitexture;
				IXUISprite ixuisprite = ixuitexture.gameObject.transform.Find("P").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.SetSprite(trophyTableData.Icon);
				IXUILabel ixuilabel3 = gameObject.transform.Find("Bg/Desc").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = gameObject.transform.Find("Bg/Progress").GetComponent("XUILabel") as IXUILabel;
				Transform transform2 = gameObject.transform.Find("Bg/OK");
				Transform transform3 = gameObject.transform.Find("Bg/Block");
				IXUILabel ixuilabel5 = gameObject.transform.Find("Bg/OK/Time").GetComponent("XUILabel") as IXUILabel;
				bool flag4 = trophyTableData != null;
				if (flag4)
				{
					string format = "";
					uint param = 0U;
					uint type = 0U;
					bool flag5 = i == 0;
					if (flag5)
					{
						format = trophyTableData.ThirdDesc;
						param = trophyTableData.ThirdPara;
						type = trophyTableData.Third;
					}
					bool flag6 = i == 1;
					if (flag6)
					{
						format = trophyTableData.SecondDesc;
						param = trophyTableData.SecondPara;
						type = trophyTableData.Second;
					}
					bool flag7 = i == 2;
					if (flag7)
					{
						format = trophyTableData.FirstDesc;
						param = trophyTableData.FirstPara;
						type = trophyTableData.First;
					}
					ixuilabel3.SetText(string.Format(format, trophyData.GetProgress(type, param)));
					TrophyDetail trophyDetail = trophyData.GetTrophyDetail(i + 1);
					bool flag8 = trophyDetail == null;
					if (flag8)
					{
						transform2.gameObject.SetActive(false);
						transform3.gameObject.SetActive(true);
						ixuilabel4.gameObject.SetActive(true);
						ixuilabel4.SetText(string.Format("({0}/{1})", trophyData.GetProgress(type), trophyData.GetProgress(type, param)));
					}
					else
					{
						transform2.gameObject.SetActive(true);
						transform3.gameObject.SetActive(false);
						ixuilabel4.gameObject.SetActive(false);
						ixuilabel5.SetText(XSingleton<UiUtility>.singleton.TimeFormatSince1970((int)trophyDetail.trophy_time, XStringDefineProxy.GetString("CAREER_TROPHY_TIME"), true));
					}
				}
			}
			this.m_TrophyPool.ActualReturnAll(false);
		}

		public bool OnHonorRewardCloseClicked(IXUIButton btn)
		{
			this.m_HonorRewardFrame.gameObject.SetActive(false);
			return true;
		}

		private void RefreshHonorReward(bool resetPos = true)
		{
			this.m_HonorCurrentLevel.SetText(this.curLevel.ToString());
			List<TrophyReward.RowData> honorRewardList = XPersonalCareerDocument.GetHonorRewardList();
			bool flag = honorRewardList == null;
			if (!flag)
			{
				this.m_HonorRewardPool.FakeReturnAll();
				this.m_HonorItemPool.FakeReturnAll();
				for (int i = 0; i < honorRewardList.Count; i++)
				{
					GameObject gameObject = this.m_HonorRewardPool.FetchGameObject(false);
					IXUILabel ixuilabel = gameObject.transform.FindChild("Bg/Point/Num").GetComponent("XUILabel") as IXUILabel;
					ixuilabel.SetText(honorRewardList[i].HonourRank.ToString());
					for (int j = 0; j < honorRewardList[i].Rewards.Count; j++)
					{
						GameObject gameObject2 = this.m_HonorItemPool.FetchGameObject(false);
						XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject2, (int)honorRewardList[i].Rewards[j, 0], (int)honorRewardList[i].Rewards[j, 1], false);
						IXUISprite ixuisprite = gameObject2.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.ID = (ulong)honorRewardList[i].Rewards[j, 0];
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
						gameObject2.transform.parent = gameObject.transform;
						gameObject2.transform.localPosition = new Vector3(this.m_HonorItemPool.TplPos.x - this.m_HonorRewardPool.TplPos.x + (float)(this.m_HonorItemPool.TplWidth * j), 0f);
					}
					gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)this.m_HonorRewardPool.TplHeight * i)) + this.m_HonorRewardPool.TplPos;
					Transform transform = gameObject.transform.FindChild("Bg/Reach");
					Transform transform2 = gameObject.transform.FindChild("Bg/UnReach");
					transform.gameObject.SetActive((ulong)this.curLevel >= (ulong)((long)honorRewardList[i].HonourRank));
					transform2.gameObject.SetActive((ulong)this.curLevel < (ulong)((long)honorRewardList[i].HonourRank));
				}
				this.m_HonorItemPool.ActualReturnAll(false);
				this.m_HonorRewardPool.ActualReturnAll(false);
				if (resetPos)
				{
					this.m_HonorScrollView.ResetPosition();
				}
			}
		}

		private bool _PushBtnClick(IXUIButton btn)
		{
			DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.PushClick(0UL);
			return true;
		}

		private bool _ShareBtnClick(IXUIButton btn)
		{
			DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.ShareClick();
			return true;
		}

		private bool OnHonorRewardOpenClick(IXUIButton btn)
		{
			this.m_HonorRewardFrame.gameObject.SetActive(true);
			this.RefreshHonorReward(true);
			return true;
		}

		private void _OpenTrophyClick(IXUISprite sp)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("TrophyID:" + sp.ID, null, null, null, null, null);
			this.m_TrophyDetailFrame.gameObject.SetActive(true);
			this.RefreshTrophyDetail((uint)sp.ID);
		}

		private XPersonalCareerDocument doc = null;

		private uint curLevel;

		private List<CareerTrophyHandler.TrophyData> m_TrophyData = new List<CareerTrophyHandler.TrophyData>();

		public Dictionary<Transform, IXUITexture> _WrapTextureList = new Dictionary<Transform, IXUITexture>();

		private IXUILabel m_GloryExp;

		private IXUILabel m_GloryLevel;

		private IXUILabel m_NextRewardLevel;

		private IXUIButton m_HonorRewardOpen;

		private IXUIButton m_Push;

		private IXUIButton m_Share;

		private Transform m_RewardItem;

		private IXUIWrapContent m_WrapContent;

		private IXUIScrollView m_ListScrollView;

		private Transform m_TrophyDetailFrame;

		private IXUIButton m_TrophyClose;

		private IXUILabel m_TrophyTitle;

		private XUIPool m_TrophyPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private Transform m_HonorRewardFrame;

		private IXUIButton m_HonorRewardClose;

		private IXUILabel m_HonorCurrentLevel;

		private IXUIScrollView m_HonorScrollView;

		private XUIPool m_HonorRewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private XUIPool m_HonorItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private class TrophyData
		{

			public void Clear()
			{
				this.SceneID = 0U;
				this.pass_count = 0U;
				this.quickly_pass_time = 0U;
				this.hight_damage = 0UL;
				this.hight_treat = 0UL;
				this.help_count = 0U;
				this.no_deathpass_count = 0U;
				this.trophyDetail = null;
			}

			public void SetData(StageTrophyData data, uint tID)
			{
				this.ID = tID;
				this.SceneID = data.scene_id;
				this.pass_count = data.pass_count;
				this.quickly_pass_time = data.quickly_pass_time;
				this.hight_damage = data.hight_damage;
				this.hight_treat = data.hight_treat;
				this.help_count = data.help_count;
				this.no_deathpass_count = data.no_deathpass_count;
				for (int i = 0; i < data.get_trophy_detail.Count; i++)
				{
					bool flag = data.get_trophy_detail[i].trophy_id == tID;
					if (flag)
					{
						this.trophyDetail = data.get_trophy_detail[i].detail;
					}
				}
			}

			public TrophyDetail GetBestTrophy()
			{
				bool flag = this.trophyDetail == null;
				TrophyDetail result;
				if (flag)
				{
					result = null;
				}
				else
				{
					TrophyDetail trophyDetail = null;
					for (int i = 0; i < this.trophyDetail.Count; i++)
					{
						bool flag2 = trophyDetail == null || trophyDetail.tropy_order < this.trophyDetail[i].tropy_order;
						if (flag2)
						{
							trophyDetail = this.trophyDetail[i];
						}
					}
					result = trophyDetail;
				}
				return result;
			}

			public TrophyDetail GetTrophyDetail(int index)
			{
				bool flag = this.trophyDetail == null;
				TrophyDetail result;
				if (flag)
				{
					result = null;
				}
				else
				{
					for (int i = 0; i < this.trophyDetail.Count; i++)
					{
						bool flag2 = (long)index == (long)((ulong)this.trophyDetail[i].tropy_order);
						if (flag2)
						{
							return this.trophyDetail[i];
						}
					}
					result = null;
				}
				return result;
			}

			public string GetProgress(uint type)
			{
				bool flag = type == 1U;
				string result;
				if (flag)
				{
					result = this.pass_count.ToString();
				}
				else
				{
					bool flag2 = type == 2U;
					if (flag2)
					{
						result = XSingleton<UiUtility>.singleton.TimeFormatString((int)this.quickly_pass_time, 2, 2, 4, false, true);
					}
					else
					{
						bool flag3 = type == 3U;
						if (flag3)
						{
							result = XSingleton<UiUtility>.singleton.NumberFormatBillion(this.hight_damage * 10000UL);
						}
						else
						{
							bool flag4 = type == 4U;
							if (flag4)
							{
								result = XSingleton<UiUtility>.singleton.NumberFormatBillion(this.hight_treat * 10000UL);
							}
							else
							{
								bool flag5 = type == 5U;
								if (flag5)
								{
									result = this.help_count.ToString();
								}
								else
								{
									bool flag6 = type == 6U;
									if (flag6)
									{
										result = this.no_deathpass_count.ToString();
									}
									else
									{
										result = "";
									}
								}
							}
						}
					}
				}
				return result;
			}

			public string GetProgress(uint type, uint param)
			{
				bool flag = type == 1U;
				string result;
				if (flag)
				{
					result = param.ToString();
				}
				else
				{
					bool flag2 = type == 2U;
					if (flag2)
					{
						result = XSingleton<UiUtility>.singleton.TimeFormatString((int)param, 2, 2, 4, false, true);
					}
					else
					{
						bool flag3 = type == 3U;
						if (flag3)
						{
							result = XSingleton<UiUtility>.singleton.NumberFormatBillion((ulong)param * 10000UL);
						}
						else
						{
							bool flag4 = type == 4U;
							if (flag4)
							{
								result = XSingleton<UiUtility>.singleton.NumberFormatBillion((ulong)param * 10000UL);
							}
							else
							{
								bool flag5 = type == 5U;
								if (flag5)
								{
									result = param.ToString();
								}
								else
								{
									bool flag6 = type == 6U;
									if (flag6)
									{
										result = param.ToString();
									}
									else
									{
										result = "";
									}
								}
							}
						}
					}
				}
				return result;
			}

			public uint ID;

			public uint SceneID;

			public int SortID;

			public uint pass_count;

			public uint quickly_pass_time;

			public ulong hight_damage;

			public ulong hight_treat;

			public uint help_count;

			public uint no_deathpass_count;

			public List<TrophyDetail> trophyDetail;
		}
	}
}
