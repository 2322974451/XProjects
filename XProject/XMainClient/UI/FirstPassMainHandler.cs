using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FirstPassMainHandler : DlgHandlerBase
	{

		private FirstPassDocument m_doc
		{
			get
			{
				return FirstPassDocument.Doc;
			}
		}

		public FirstPassTeamInfoHandler TeamInfoHandler
		{
			get
			{
				return this.m_TeamInfoHandler;
			}
		}

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/FirstPassMain";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_viewRewardBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnViewRewardClicked));
			this.m_topTeamInfoBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnTopTeamInfoClicked));
			this.m_goBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGoClicked));
			this.m_leftSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnLeftClicked));
			this.m_rightSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRightClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.m_doc.CurData = this.m_doc.AutoSelectFirstPassData;
			this.FillBgTexture();
			this.m_doc.ReqFirstPassInfo();
		}

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

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<FirstPassTeamInfoHandler>(ref this.m_TeamInfoHandler);
			base.OnUnload();
		}

		public void RefreshUI()
		{
			this.FillContent();
		}

		public void UiBackRefrsh()
		{
			this.FillBgTexture();
			this.FillContent();
		}

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

		private void FillBgTexture()
		{
			this.m_bgTexture.SetTexturePath("atlas/UI/common/Pic/" + this.m_doc.CurData.FirstPassRow.BgTexName);
		}

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

		private bool OnViewRewardClicked(IXUIButton sp)
		{
			DlgBase<FirstPassRewardView, FirstPassRewardBehaviour>.singleton.SetVisible(true, true);
			return true;
		}

		private bool OnTopTeamInfoClicked(IXUIButton sp)
		{
			this.m_leftSpr.gameObject.SetActive(false);
			this.m_rightSpr.gameObject.SetActive(false);
			DlgHandlerBase.EnsureCreate<FirstPassTeamInfoHandler>(ref this.m_TeamInfoHandler, this.parent, true, this);
			return true;
		}

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

		private IXUILabel m_tittle1Lab;

		private IXUILabel m_tittle2Lab;

		private IXUILabel m_myRankLab;

		private IXUILabel m_itemTittleLab;

		private IXUILabel m_goLab;

		private IXUILabel m_tipsLab;

		private IXUILabel m_timeLab;

		private IXUIButton m_viewRewardBtn;

		private IXUIButton m_topTeamInfoBtn;

		private IXUIButton m_goBtn;

		private IXUISprite m_leftSpr;

		private IXUISprite m_rightSpr;

		private IXUITexture m_bgTexture;

		private GameObject m_getRewardRedDot;

		private GameObject m_leftRedDot;

		private GameObject m_rightRedDot;

		private GameObject m_itemsGo;

		private GameObject m_PariseRedDot;

		private FirstPassTeamInfoHandler m_TeamInfoHandler;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
