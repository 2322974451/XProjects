using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200184B RID: 6219
	internal class FirstPassMainHandler : DlgHandlerBase
	{
		// Token: 0x1700395B RID: 14683
		// (get) Token: 0x06010279 RID: 66169 RVA: 0x003DEFC8 File Offset: 0x003DD1C8
		private FirstPassDocument m_doc
		{
			get
			{
				return FirstPassDocument.Doc;
			}
		}

		// Token: 0x1700395C RID: 14684
		// (get) Token: 0x0601027A RID: 66170 RVA: 0x003DEFE0 File Offset: 0x003DD1E0
		public FirstPassTeamInfoHandler TeamInfoHandler
		{
			get
			{
				return this.m_TeamInfoHandler;
			}
		}

		// Token: 0x1700395D RID: 14685
		// (get) Token: 0x0601027B RID: 66171 RVA: 0x003DEFF8 File Offset: 0x003DD1F8
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/FirstPassMain";
			}
		}

		// Token: 0x0601027C RID: 66172 RVA: 0x003DF010 File Offset: 0x003DD210
		protected override void Init()
		{
			base.Init();
			this.m_doc.View = this;
			this.m_leftSpr = (base.PanelObject.transform.FindChild("Arrow/Left").GetComponent("XUISprite") as IXUISprite);
			this.m_rightSpr = (base.PanelObject.transform.FindChild("Arrow/Right").GetComponent("XUISprite") as IXUISprite);
			this.m_leftRedDot = this.m_leftSpr.gameObject.transform.FindChild("RedPoint").gameObject;
			this.m_rightRedDot = this.m_rightSpr.gameObject.transform.FindChild("RedPoint").gameObject;
			Transform transform = base.PanelObject.transform.FindChild("Main/Tittles");
			this.m_tittle1Lab = (transform.FindChild("Tittle1").GetComponent("XUILabel") as IXUILabel);
			this.m_tittle2Lab = (transform.FindChild("Tittle2").GetComponent("XUILabel") as IXUILabel);
			this.m_myRankLab = (transform.FindChild("MyRank").GetComponent("XUILabel") as IXUILabel);
			this.m_tipsLab = (transform.FindChild("Tips").GetComponent("XUILabel") as IXUILabel);
			transform = base.PanelObject.transform.FindChild("Main/Btns");
			this.m_viewRewardBtn = (transform.FindChild("ViewRewardBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_topTeamInfoBtn = (transform.FindChild("TopTeamInfoBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_goBtn = (transform.FindChild("GoBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_goLab = (transform.FindChild("GoBtn/T").GetComponent("XUILabel") as IXUILabel);
			this.m_getRewardRedDot = transform.FindChild("GoBtn/RedPoint").gameObject;
			this.m_PariseRedDot = transform.FindChild("TopTeamInfoBtn/RedPoint").gameObject;
			this.m_bgTexture = (base.PanelObject.transform.FindChild("Main/P").GetComponent("XUITexture") as IXUITexture);
			transform = base.PanelObject.transform.FindChild("Main/Items");
			this.m_itemsGo = transform.gameObject;
			this.m_ItemPool.SetupPool(this.m_itemsGo, transform.FindChild("Item").gameObject, 2U, false);
			this.m_itemTittleLab = (transform.FindChild("Tittle").GetComponent("XUILabel") as IXUILabel);
			this.m_timeLab = (base.PanelObject.transform.FindChild("Main/TimeLab").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0601027D RID: 66173 RVA: 0x003DF2E4 File Offset: 0x003DD4E4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_viewRewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnViewRewardClicked));
			this.m_topTeamInfoBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTopTeamInfoClicked));
			this.m_goBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoClicked));
			this.m_leftSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnLeftClicked));
			this.m_rightSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRightClicked));
		}

		// Token: 0x0601027E RID: 66174 RVA: 0x003DF371 File Offset: 0x003DD571
		protected override void OnShow()
		{
			base.OnShow();
			this.m_doc.CurData = this.m_doc.AutoSelectFirstPassData;
			this.FillBgTexture();
			this.m_doc.ReqFirstPassInfo();
		}

		// Token: 0x0601027F RID: 66175 RVA: 0x003DF3A8 File Offset: 0x003DD5A8
		protected override void OnHide()
		{
			base.OnHide();
			this.m_bgTexture.SetTexturePath("");
			bool flag = this.m_TeamInfoHandler != null;
			if (flag)
			{
				this.m_TeamInfoHandler.SetVisible(false);
			}
		}

		// Token: 0x06010280 RID: 66176 RVA: 0x0022CCF0 File Offset: 0x0022AEF0
		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		// Token: 0x06010281 RID: 66177 RVA: 0x003DF3E8 File Offset: 0x003DD5E8
		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<FirstPassTeamInfoHandler>(ref this.m_TeamInfoHandler);
			base.OnUnload();
		}

		// Token: 0x06010282 RID: 66178 RVA: 0x003DF3FE File Offset: 0x003DD5FE
		public void RefreshUI()
		{
			this.FillContent();
		}

		// Token: 0x06010283 RID: 66179 RVA: 0x003DF408 File Offset: 0x003DD608
		public void UiBackRefrsh()
		{
			this.FillBgTexture();
			this.FillContent();
		}

		// Token: 0x06010284 RID: 66180 RVA: 0x003DF41C File Offset: 0x003DD61C
		private void FillContent()
		{
			bool flag = this.m_doc.CurData == null;
			if (!flag)
			{
				this.FillTime();
				this.m_tittle1Lab.SetText(string.Format(XStringDefineProxy.GetString("FirstPassTips"), this.m_doc.CurData.FirstPassRow.Des));
				string text = string.Format(XStringDefineProxy.GetString("CanGetReward"), this.m_doc.NeedPassTeamCount);
				text = string.Format("{0}({1}/{2})", text, this.m_doc.CurData.PassTeamCount, this.m_doc.NeedPassTeamCount);
				this.m_tittle2Lab.SetText(text);
				bool flag2 = this.m_doc.CurData.CurRank == 0;
				if (flag2)
				{
					text = XStringDefineProxy.GetString("NoPass");
				}
				else
				{
					text = string.Format(XStringDefineProxy.GetString("MyRank"), this.m_doc.CurData.CurRank);
				}
				this.m_myRankLab.SetText(text);
				bool isHadReward = this.m_doc.CurData.IsHadReward;
				if (isHadReward)
				{
					this.m_goLab.SetText(XStringDefineProxy.GetString("SRS_FETCH"));
					this.m_getRewardRedDot.SetActive(true);
				}
				else
				{
					this.m_goLab.SetText(XStringDefineProxy.GetString("GoToBattle"));
					this.m_getRewardRedDot.SetActive(false);
				}
				this.m_leftSpr.gameObject.SetActive(this.m_doc.IsHadLastData);
				this.m_rightSpr.gameObject.SetActive(this.m_doc.IsHadNextData);
				this.m_leftRedDot.SetActive(this.m_doc.MainArrowRedDot(ArrowDirection.Left));
				this.m_rightRedDot.SetActive(this.m_doc.MainArrowRedDot(ArrowDirection.Right));
				this.m_PariseRedDot.SetActive(this.m_doc.CurData.IsCanPrise);
				bool flag3 = this.m_doc.CurData.PassTeamCount >= this.m_doc.NeedPassTeamCount;
				if (flag3)
				{
					this.m_tipsLab.gameObject.SetActive(true);
					this.m_tipsLab.SetText(XStringDefineProxy.GetString("RewardIsNone"));
					this.m_itemsGo.SetActive(false);
				}
				else
				{
					this.m_tipsLab.gameObject.SetActive(false);
					this.m_itemsGo.SetActive(true);
					bool flag4 = !this.m_doc.CurData.IsHadReward;
					if (flag4)
					{
						this.FileItems(this.m_doc.CurData.GetFirstPassReward(this.m_doc.CurData.PassTeamCount + 1));
					}
					else
					{
						this.FileItems(this.m_doc.CurData.GetFirstPassReward(this.m_doc.CurData.CurRank));
					}
				}
			}
		}

		// Token: 0x06010285 RID: 66181 RVA: 0x003DF6FC File Offset: 0x003DD8FC
		private void FillTime()
		{
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			bool flag = this.m_doc.CurData == null || this.m_doc.CurData.FirstPassRow == null || this.m_doc.CurData.FirstPassRow.SceneID.Length < 1;
			if (!flag)
			{
				ExpeditionTable.RowData expeditionDataByID = specificDocument.GetExpeditionDataByID(this.m_doc.CurData.FirstPassRow.SceneID[0]);
				bool flag2 = expeditionDataByID == null;
				if (flag2)
				{
					this.m_timeLab.SetText("");
				}
				else
				{
					string text = "";
					int num = (int)expeditionDataByID.ServerOpenTime[0];
					int num2 = (int)expeditionDataByID.ServerOpenTime[1];
					XActivityDocument doc = XActivityDocument.Doc;
					uint severOpenSecond = doc.SeverOpenSecond;
					bool flag3 = doc.ServerOpenDay < num;
					if (flag3)
					{
						text = string.Format(XSingleton<XStringTable>.singleton.GetString("MulActivity_ServerOpenDay"), num - doc.ServerOpenDay);
					}
					else
					{
						bool flag4 = doc.ServerOpenDay == num;
						if (flag4)
						{
							bool flag5 = severOpenSecond % 3600U == 0U;
							uint num3;
							if (flag5)
							{
								num3 = severOpenSecond / 3600U;
							}
							else
							{
								num3 = severOpenSecond / 3600U + 1U;
							}
							bool flag6 = (ulong)num3 < (ulong)((long)num2);
							if (flag6)
							{
								text = string.Format("{0}{1}", (long)num2 - (long)((ulong)num3), XSingleton<XStringTable>.singleton.GetString("HOUR_DUARATION"));
								text = string.Format(XSingleton<XStringTable>.singleton.GetString("ActivityOpenTime"), text);
							}
							else
							{
								bool flag7 = (ulong)num3 == (ulong)((long)num2);
								if (flag7)
								{
									bool flag8 = severOpenSecond % 3600U < 60U;
									if (flag8)
									{
										text = string.Format(XSingleton<XStringTable>.singleton.GetString("ActivityOpenTime"), XSingleton<XStringTable>.singleton.GetString("LessOneHour"));
									}
								}
							}
						}
					}
					this.m_timeLab.SetText(text);
				}
			}
		}

		// Token: 0x06010286 RID: 66182 RVA: 0x003DF8E8 File Offset: 0x003DDAE8
		private void FillBgTexture()
		{
			this.m_bgTexture.SetTexturePath("atlas/UI/common/Pic/" + this.m_doc.CurData.FirstPassRow.BgTexName);
		}

		// Token: 0x06010287 RID: 66183 RVA: 0x003DF918 File Offset: 0x003DDB18
		private void FileItems(RewardAuxData data)
		{
			bool flag = data == null;
			if (!flag)
			{
				bool flag2 = data.RankRang[1] == 1;
				if (flag2)
				{
					this.m_itemTittleLab.SetText(XStringDefineProxy.GetString("FirstPassReward"));
				}
				else
				{
					this.m_itemTittleLab.SetText(string.Format(XStringDefineProxy.GetString("RankReward1"), data.RankRang[1]));
				}
				this.m_ItemPool.ReturnAll(false);
				for (int i = 0; i < data.RewardDataList.Count; i++)
				{
					GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
					gameObject.transform.parent = this.m_itemsGo.transform;
					gameObject.name = i.ToString();
					gameObject.transform.localScale = Vector3.one;
					gameObject.transform.localPosition = new Vector3((float)(this.m_ItemPool.TplWidth * i), 0f, 0f);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)((long)data.RewardDataList[i].Id);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, data.RewardDataList[i].Id, data.RewardDataList[i].Count, false);
					ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				}
			}
		}

		// Token: 0x06010288 RID: 66184 RVA: 0x003DFABC File Offset: 0x003DDCBC
		private bool OnViewRewardClicked(IXUIButton sp)
		{
			DlgBase<FirstPassRewardView, FirstPassRewardBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		// Token: 0x06010289 RID: 66185 RVA: 0x003DFADC File Offset: 0x003DDCDC
		private bool OnTopTeamInfoClicked(IXUIButton sp)
		{
			this.m_leftSpr.gameObject.SetActive(false);
			this.m_rightSpr.gameObject.SetActive(false);
			DlgHandlerBase.EnsureCreate<FirstPassTeamInfoHandler>(ref this.m_TeamInfoHandler, this.parent, true, this);
			return true;
		}

		// Token: 0x0601028A RID: 66186 RVA: 0x003DFB28 File Offset: 0x003DDD28
		private bool OnGoClicked(IXUIButton sp)
		{
			bool flag = this.m_doc.CurData == null;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool isHadReward = this.m_doc.CurData.IsHadReward;
				if (isHadReward)
				{
					this.m_doc.ReqFirstPassReward(this.m_doc.CurData.Id);
				}
				else
				{
					bool flag2 = !XSingleton<XGameSysMgr>.singleton.IsSystemOpened((XSysDefine)this.m_doc.CurData.FirstPassRow.SystemId);
					if (flag2)
					{
						int sysOpenServerDay = XSingleton<XGameSysMgr>.singleton.GetSysOpenServerDay(this.m_doc.CurData.FirstPassRow.SystemId);
						XActivityDocument specificDocument = XDocuments.GetSpecificDocument<XActivityDocument>(XActivityDocument.uuID);
						int serverOpenDay = specificDocument.ServerOpenDay;
						int num = sysOpenServerDay - serverOpenDay;
						bool flag3 = sysOpenServerDay == 0 || num <= 0;
						if (flag3)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("SYSTEM_NOT_OPEN"), "fece00");
						}
						else
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XStringDefineProxy.GetString("MulActivity_ServerOpenDay"), num), "fece00");
						}
						return true;
					}
					XSingleton<XGameSysMgr>.singleton.OpenSystem(this.m_doc.CurData.FirstPassRow.SystemId);
				}
				result = true;
			}
			return result;
		}

		// Token: 0x0601028B RID: 66187 RVA: 0x003DFC70 File Offset: 0x003DDE70
		private void OnLeftClicked(IXUISprite sp)
		{
			bool isHadLastData = this.m_doc.IsHadLastData;
			if (isHadLastData)
			{
				this.m_doc.CurData = this.m_doc.GetLastFirstPassData();
				this.FillBgTexture();
				this.FillContent();
			}
		}

		// Token: 0x0601028C RID: 66188 RVA: 0x003DFCB4 File Offset: 0x003DDEB4
		private void OnRightClicked(IXUISprite sp)
		{
			bool isHadNextData = this.m_doc.IsHadNextData;
			if (isHadNextData)
			{
				this.m_doc.CurData = this.m_doc.GetNextFirstPassData();
				this.FillBgTexture();
				this.FillContent();
			}
		}

		// Token: 0x04007378 RID: 29560
		private IXUILabel m_tittle1Lab;

		// Token: 0x04007379 RID: 29561
		private IXUILabel m_tittle2Lab;

		// Token: 0x0400737A RID: 29562
		private IXUILabel m_myRankLab;

		// Token: 0x0400737B RID: 29563
		private IXUILabel m_itemTittleLab;

		// Token: 0x0400737C RID: 29564
		private IXUILabel m_goLab;

		// Token: 0x0400737D RID: 29565
		private IXUILabel m_tipsLab;

		// Token: 0x0400737E RID: 29566
		private IXUILabel m_timeLab;

		// Token: 0x0400737F RID: 29567
		private IXUIButton m_viewRewardBtn;

		// Token: 0x04007380 RID: 29568
		private IXUIButton m_topTeamInfoBtn;

		// Token: 0x04007381 RID: 29569
		private IXUIButton m_goBtn;

		// Token: 0x04007382 RID: 29570
		private IXUISprite m_leftSpr;

		// Token: 0x04007383 RID: 29571
		private IXUISprite m_rightSpr;

		// Token: 0x04007384 RID: 29572
		private IXUITexture m_bgTexture;

		// Token: 0x04007385 RID: 29573
		private GameObject m_getRewardRedDot;

		// Token: 0x04007386 RID: 29574
		private GameObject m_leftRedDot;

		// Token: 0x04007387 RID: 29575
		private GameObject m_rightRedDot;

		// Token: 0x04007388 RID: 29576
		private GameObject m_itemsGo;

		// Token: 0x04007389 RID: 29577
		private GameObject m_PariseRedDot;

		// Token: 0x0400738A RID: 29578
		private FirstPassTeamInfoHandler m_TeamInfoHandler;

		// Token: 0x0400738B RID: 29579
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
