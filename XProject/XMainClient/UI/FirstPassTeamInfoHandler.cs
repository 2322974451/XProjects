using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200184C RID: 6220
	internal class FirstPassTeamInfoHandler : DlgHandlerBase
	{
		// Token: 0x1700395E RID: 14686
		// (get) Token: 0x0601028E RID: 66190 RVA: 0x003DFD18 File Offset: 0x003DDF18
		private FirstPassDocument m_doc
		{
			get
			{
				return FirstPassDocument.Doc;
			}
		}

		// Token: 0x1700395F RID: 14687
		// (get) Token: 0x0601028F RID: 66191 RVA: 0x003DFD30 File Offset: 0x003DDF30
		protected override string FileName
		{
			get
			{
				return "OperatingActivity/FirstPassTeamInfo";
			}
		}

		// Token: 0x06010290 RID: 66192 RVA: 0x003DFD48 File Offset: 0x003DDF48
		protected override void Init()
		{
			base.Init();
			this.m_leftSpr = (base.PanelObject.transform.FindChild("Left").GetComponent("XUISprite") as IXUISprite);
			this.m_rightSpr = (base.PanelObject.transform.FindChild("Right").GetComponent("XUISprite") as IXUISprite);
			this.m_leftRedDot = this.m_leftSpr.gameObject.transform.FindChild("RedPoint").gameObject;
			this.m_rightRedDot = this.m_rightSpr.gameObject.transform.FindChild("RedPoint").gameObject;
			Transform transform = base.PanelObject.transform.FindChild("Btns");
			this.m_returnBtn = (transform.FindChild("BackBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_rankBtn = (transform.FindChild("RankBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_priseBtn = (transform.FindChild("PaiseBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_priseGo2 = transform.FindChild("PaiseBtn2").gameObject;
			this.m_priseLab = (transform.FindChild("PaiseBtn/T").GetComponent("XUILabel") as IXUILabel);
			this.m_redDotGo = transform.FindChild("PaiseBtn/RedPoint").gameObject;
			transform = base.PanelObject.transform.FindChild("Tittles");
			this.m_tittleLab2 = (transform.FindChild("Tittle2").GetComponent("XUILabel") as IXUILabel);
			this.m_tipsGo = base.PanelObject.transform.FindChild("Tips").gameObject;
			this.m_starGo = transform.FindChild("Image").gameObject;
			this.m_starLab = (this.m_starGo.transform.FindChild("Rank").GetComponent("XUILabel") as IXUILabel);
			transform = base.PanelObject.transform.FindChild("Item");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this.m_fourList = new List<GameObject>();
			transform = base.PanelObject.transform.FindChild("FourPos");
			this.m_fourPos = transform.gameObject;
			for (int i = 0; i < transform.childCount; i++)
			{
				this.m_fourList.Add(transform.GetChild(i).gameObject);
			}
			this.m_sixList = new List<GameObject>();
			transform = base.PanelObject.transform.FindChild("SixPos");
			this.m_sixPos = transform.gameObject;
			for (int j = 0; j < transform.childCount; j++)
			{
				this.m_sixList.Add(transform.GetChild(j).gameObject);
			}
		}

		// Token: 0x06010291 RID: 66193 RVA: 0x003E0044 File Offset: 0x003DE244
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_returnBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnClicked));
			this.m_rankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankClicked));
			this.m_priseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPriseClicked));
			this.m_leftSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnLeftClicked));
			this.m_rightSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRightClicked));
		}

		// Token: 0x06010292 RID: 66194 RVA: 0x003E00D1 File Offset: 0x003DE2D1
		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("FirstPassTeamInfoHandler", 1);
			this.FillContent();
		}

		// Token: 0x06010293 RID: 66195 RVA: 0x003E00EF File Offset: 0x003DE2EF
		protected override void OnHide()
		{
			base.OnHide();
			base.Return3DAvatarPool();
		}

		// Token: 0x06010294 RID: 66196 RVA: 0x003E0100 File Offset: 0x003DE300
		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("FirstPassTeamInfoHandler", 1);
		}

		// Token: 0x06010295 RID: 66197 RVA: 0x003E0117 File Offset: 0x003DE317
		public override void OnUnload()
		{
			base.Return3DAvatarPool();
			base.OnUnload();
		}

		// Token: 0x06010296 RID: 66198 RVA: 0x003E0128 File Offset: 0x003DE328
		private void FillContent()
		{
			this.SetDefault();
			this.m_leftSpr.gameObject.SetActive(this.m_doc.IsHadLastData);
			this.m_rightSpr.gameObject.SetActive(this.m_doc.IsHadNextData);
			this.m_doc.ReqFirstPassTopRoleInfo(this.m_doc.CurData.Id);
		}

		// Token: 0x06010297 RID: 66199 RVA: 0x003E0194 File Offset: 0x003DE394
		public void RefreshUI()
		{
			bool flag = this.m_doc.CurData.PassTeamCount == 0;
			if (flag)
			{
				this.m_priseGo2.SetActive(false);
				this.m_priseBtn.gameObject.SetActive(false);
			}
			else
			{
				bool flag2 = !this.m_doc.CurData.IsGivedPrise;
				if (flag2)
				{
					this.m_priseBtn.gameObject.SetActive(true);
					this.m_priseGo2.SetActive(false);
				}
				else
				{
					this.m_priseBtn.gameObject.SetActive(false);
					this.m_priseGo2.SetActive(true);
				}
			}
			this.RefreshArrowRedDot();
		}

		// Token: 0x06010298 RID: 66200 RVA: 0x003E0240 File Offset: 0x003DE440
		public void FillAvata()
		{
			this.RefreshUI();
			bool flag = this.m_doc.CurData.TeamInfoList == null || this.m_doc.CurData.TeamInfoList.Count == 0;
			if (flag)
			{
				this.SetDefault();
			}
			else
			{
				this.FillTopLab();
				List<GameObject> list = null;
				this.m_tipsGo.SetActive(false);
				bool flag2 = this.m_doc.CurData.TeamInfoList.Count <= 4;
				if (flag2)
				{
					this.m_fourPos.SetActive(true);
					this.m_sixPos.SetActive(false);
					list = this.m_fourList;
				}
				else
				{
					bool flag3 = this.m_doc.CurData.TeamInfoList.Count <= 6;
					if (flag3)
					{
						this.m_fourPos.SetActive(false);
						this.m_sixPos.SetActive(true);
						list = this.m_sixList;
					}
				}
				bool flag4 = list == null;
				if (!flag4)
				{
					this.m_ItemPool.ReturnAll(false);
					for (int i = 0; i < this.m_doc.CurData.TeamInfoList.Count; i++)
					{
						UnitAppearance unitAppearance = this.m_doc.CurData.TeamInfoList[i];
						GameObject gameObject = this.m_ItemPool.FetchGameObject(false);
						gameObject.transform.parent = list[i].transform;
						gameObject.transform.localScale = Vector3.one;
						gameObject.transform.localPosition = Vector3.zero;
						IXUILabel ixuilabel = gameObject.transform.FindChild("Name/Lab").GetComponent("XUILabel") as IXUILabel;
						ixuilabel.SetText(unitAppearance.unitName);
						IXUISprite ixuisprite = gameObject.transform.FindChild("Name/Icon").GetComponent("XUISprite") as IXUISprite;
						ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)(unitAppearance.unitType % 10U)));
						ixuilabel = (gameObject.transform.FindChild("GuildName/Lab").GetComponent("XUILabel") as IXUILabel);
						ixuilabel.SetText((unitAppearance.outlook != null && unitAppearance.outlook.guild != null) ? unitAppearance.outlook.guild.name : "");
						ixuisprite = (gameObject.transform.FindChild("GuildName/Icon").GetComponent("XUISprite") as IXUISprite);
						ixuisprite.SetSprite((unitAppearance.outlook != null && unitAppearance.outlook.guild != null) ? unitAppearance.outlook.guild.icon.ToString() : "");
						this.m_Snapshots[i] = (gameObject.transform.FindChild("Snapshot").GetComponent("UIDummy") as IUIDummy);
						ixuisprite = (gameObject.transform.FindChild("Box").GetComponent("XUISprite") as IXUISprite);
						ixuisprite.ID = unitAppearance.uID;
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickavata));
					}
					int j = this.m_doc.CurData.TeamInfoList.Count;
					int num = this.m_Snapshots.Length;
					while (j < num)
					{
						this.m_Snapshots[j] = null;
						j++;
					}
					this.RefreshAvataData();
				}
			}
		}

		// Token: 0x06010299 RID: 66201 RVA: 0x003E05B4 File Offset: 0x003DE7B4
		private void SetDefault()
		{
			this.m_starGo.SetActive(false);
			this.m_tittleLab2.SetText("");
			this.m_fourPos.SetActive(false);
			this.m_sixPos.SetActive(false);
			this.m_tipsGo.SetActive(true);
		}

		// Token: 0x0601029A RID: 66202 RVA: 0x003E0608 File Offset: 0x003DE808
		private void FillTopLab()
		{
			bool flag = this.m_doc.CurData == null;
			if (!flag)
			{
				bool flag2 = this.m_doc.CurData.PassTimeStr != string.Empty;
				if (flag2)
				{
					this.m_tittleLab2.SetText(string.Format("{0}{1}", this.m_doc.CurData.PassTimeStr, this.m_doc.CurData.SceneName));
				}
				else
				{
					this.m_tittleLab2.SetText("");
				}
				bool flag3 = this.m_doc.CurData.Star == -1;
				if (flag3)
				{
					this.m_starGo.SetActive(false);
				}
				else
				{
					this.m_starGo.SetActive(true);
					this.m_starLab.SetText(this.m_doc.CurData.Star.ToString());
				}
			}
		}

		// Token: 0x0601029B RID: 66203 RVA: 0x003E06ED File Offset: 0x003DE8ED
		private void RefreshArrowRedDot()
		{
			this.m_leftRedDot.SetActive(this.m_doc.InfoArrowRedDot(ArrowDirection.Left));
			this.m_rightRedDot.SetActive(this.m_doc.InfoArrowRedDot(ArrowDirection.Right));
		}

		// Token: 0x0601029C RID: 66204 RVA: 0x003E0720 File Offset: 0x003DE920
		private void RefreshAvataData()
		{
			int num = 0;
			while (num < this.m_doc.CurData.TeamInfoList.Count && num < FirstPassDocument.MaxAvata)
			{
				bool flag = this.m_Snapshots[num] != null;
				if (flag)
				{
					this.m_dummys[num] = XSingleton<X3DAvatarMgr>.singleton.CreateCommonRoleDummy(this.m_dummPool, this.m_doc.CurData.TeamInfoList[num], this.m_Snapshots[num], this.m_dummys[num]);
				}
				num++;
			}
		}

		// Token: 0x0601029D RID: 66205 RVA: 0x003E07B0 File Offset: 0x003DE9B0
		private bool OnReturnClicked(IXUIButton sp)
		{
			base.SetVisible(false);
			bool flag = this.m_doc.View != null;
			if (flag)
			{
				this.m_doc.View.UiBackRefrsh();
			}
			return true;
		}

		// Token: 0x0601029E RID: 66206 RVA: 0x003E07F0 File Offset: 0x003DE9F0
		private bool OnRankClicked(IXUIButton sp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				DlgBase<FirstPassRankView, FitstpassRankBehaviour>.singleton.SetVisible(true, true);
				result = true;
			}
			return result;
		}

		// Token: 0x0601029F RID: 66207 RVA: 0x003E0824 File Offset: 0x003DEA24
		private bool OnPriseClicked(IXUIButton sp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this.m_doc.CurData == null;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool isCanPrise = this.m_doc.CurData.IsCanPrise;
					if (isCanPrise)
					{
						this.m_doc.ReqCommendFirstPass(this.m_doc.CurData.Id);
					}
					result = true;
				}
			}
			return result;
		}

		// Token: 0x060102A0 RID: 66208 RVA: 0x003E0894 File Offset: 0x003DEA94
		private void OnLeftClicked(IXUISprite sp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			if (!flag)
			{
				bool isHadLastData = this.m_doc.IsHadLastData;
				if (isHadLastData)
				{
					this.m_doc.CurData = this.m_doc.GetLastFirstPassData();
					this.FillContent();
				}
			}
		}

		// Token: 0x060102A1 RID: 66209 RVA: 0x003E08E4 File Offset: 0x003DEAE4
		private void OnRightClicked(IXUISprite sp)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			if (!flag)
			{
				bool isHadNextData = this.m_doc.IsHadNextData;
				if (isHadNextData)
				{
					this.m_doc.CurData = this.m_doc.GetNextFirstPassData();
					this.FillContent();
				}
			}
		}

		// Token: 0x060102A2 RID: 66210 RVA: 0x003E0934 File Offset: 0x003DEB34
		private bool SetButtonCool(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_fLastClickBtnTime;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_fLastClickBtnTime = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		// Token: 0x060102A3 RID: 66211 RVA: 0x003E096C File Offset: 0x003DEB6C
		private void OnClickavata(IXUISprite sp)
		{
			bool flag = sp == null;
			if (!flag)
			{
				ulong id = sp.ID;
				XCharacterCommonMenuDocument.ReqCharacterMenuInfo(id, false);
			}
		}

		// Token: 0x0400738C RID: 29580
		private IXUIButton m_returnBtn;

		// Token: 0x0400738D RID: 29581
		private IXUIButton m_rankBtn;

		// Token: 0x0400738E RID: 29582
		private IXUIButton m_priseBtn;

		// Token: 0x0400738F RID: 29583
		private IXUISprite m_leftSpr;

		// Token: 0x04007390 RID: 29584
		private IXUISprite m_rightSpr;

		// Token: 0x04007391 RID: 29585
		private IXUILabel m_tittleLab2;

		// Token: 0x04007392 RID: 29586
		private IXUILabel m_priseLab;

		// Token: 0x04007393 RID: 29587
		private IXUILabel m_starLab;

		// Token: 0x04007394 RID: 29588
		private GameObject m_starGo;

		// Token: 0x04007395 RID: 29589
		private GameObject m_leftRedDot;

		// Token: 0x04007396 RID: 29590
		private GameObject m_rightRedDot;

		// Token: 0x04007397 RID: 29591
		private GameObject m_fourPos;

		// Token: 0x04007398 RID: 29592
		private GameObject m_sixPos;

		// Token: 0x04007399 RID: 29593
		private GameObject m_tipsGo;

		// Token: 0x0400739A RID: 29594
		private GameObject m_redDotGo;

		// Token: 0x0400739B RID: 29595
		private GameObject m_priseGo2;

		// Token: 0x0400739C RID: 29596
		private List<GameObject> m_fourList;

		// Token: 0x0400739D RID: 29597
		private List<GameObject> m_sixList;

		// Token: 0x0400739E RID: 29598
		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400739F RID: 29599
		private float m_fCoolTime = 0.5f;

		// Token: 0x040073A0 RID: 29600
		private float m_fLastClickBtnTime = 0f;

		// Token: 0x040073A1 RID: 29601
		private IUIDummy[] m_Snapshots = new IUIDummy[FirstPassDocument.MaxAvata];

		// Token: 0x040073A2 RID: 29602
		private XDummy[] m_dummys = new XDummy[FirstPassDocument.MaxAvata];
	}
}
