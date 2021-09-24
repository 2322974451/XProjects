using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class FirstPassTeamInfoHandler : DlgHandlerBase
	{

		private FirstPassDocument m_doc
		{
			get
			{
				return FirstPassDocument.Doc;
			}
		}

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/FirstPassTeamInfo";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_returnBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReturnClicked));
			this.m_rankBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankClicked));
			this.m_priseBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPriseClicked));
			this.m_leftSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnLeftClicked));
			this.m_rightSpr.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnRightClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("FirstPassTeamInfoHandler", 1);
			this.FillContent();
		}

		protected override void OnHide()
		{
			base.OnHide();
			base.Return3DAvatarPool();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("FirstPassTeamInfoHandler", 1);
		}

		public override void OnUnload()
		{
			base.Return3DAvatarPool();
			base.OnUnload();
		}

		private void FillContent()
		{
			this.SetDefault();
			this.m_leftSpr.gameObject.SetActive(this.m_doc.IsHadLastData);
			this.m_rightSpr.gameObject.SetActive(this.m_doc.IsHadNextData);
			this.m_doc.ReqFirstPassTopRoleInfo(this.m_doc.CurData.Id);
		}

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

		private void SetDefault()
		{
			this.m_starGo.SetActive(false);
			this.m_tittleLab2.SetText("");
			this.m_fourPos.SetActive(false);
			this.m_sixPos.SetActive(false);
			this.m_tipsGo.SetActive(true);
		}

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

		private void RefreshArrowRedDot()
		{
			this.m_leftRedDot.SetActive(this.m_doc.InfoArrowRedDot(ArrowDirection.Left));
			this.m_rightRedDot.SetActive(this.m_doc.InfoArrowRedDot(ArrowDirection.Right));
		}

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

		private void OnClickavata(IXUISprite sp)
		{
			bool flag = sp == null;
			if (!flag)
			{
				ulong id = sp.ID;
				XCharacterCommonMenuDocument.ReqCharacterMenuInfo(id, false);
			}
		}

		private IXUIButton m_returnBtn;

		private IXUIButton m_rankBtn;

		private IXUIButton m_priseBtn;

		private IXUISprite m_leftSpr;

		private IXUISprite m_rightSpr;

		private IXUILabel m_tittleLab2;

		private IXUILabel m_priseLab;

		private IXUILabel m_starLab;

		private GameObject m_starGo;

		private GameObject m_leftRedDot;

		private GameObject m_rightRedDot;

		private GameObject m_fourPos;

		private GameObject m_sixPos;

		private GameObject m_tipsGo;

		private GameObject m_redDotGo;

		private GameObject m_priseGo2;

		private List<GameObject> m_fourList;

		private List<GameObject> m_sixList;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private float m_fCoolTime = 0.5f;

		private float m_fLastClickBtnTime = 0f;

		private IUIDummy[] m_Snapshots = new IUIDummy[FirstPassDocument.MaxAvata];

		private XDummy[] m_dummys = new XDummy[FirstPassDocument.MaxAvata];
	}
}
