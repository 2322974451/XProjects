using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E50 RID: 3664
	internal class XPkLoadingView : DlgBase<XPkLoadingView, XPkLoadingBehaviour>
	{
		// Token: 0x17003466 RID: 13414
		// (get) Token: 0x0600C479 RID: 50297 RVA: 0x002AE9E8 File Offset: 0x002ACBE8
		public override string fileName
		{
			get
			{
				return "Common/PkLoadingDlg";
			}
		}

		// Token: 0x17003467 RID: 13415
		// (get) Token: 0x0600C47A RID: 50298 RVA: 0x002AEA00 File Offset: 0x002ACC00
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003468 RID: 13416
		// (get) Token: 0x0600C47B RID: 50299 RVA: 0x002AEA14 File Offset: 0x002ACC14
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003469 RID: 13417
		// (get) Token: 0x0600C47C RID: 50300 RVA: 0x002AEA28 File Offset: 0x002ACC28
		public bool IsLoadingOver
		{
			get
			{
				return this._isLoadingOver;
			}
		}

		// Token: 0x1700346A RID: 13418
		// (get) Token: 0x0600C47D RID: 50301 RVA: 0x002AEA40 File Offset: 0x002ACC40
		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C47E RID: 50302 RVA: 0x002AEA53 File Offset: 0x002ACC53
		protected override void Init()
		{
			base.Init();
			this._isLoadingOver = false;
			this._doc = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
		}

		// Token: 0x0600C47F RID: 50303 RVA: 0x002AEA74 File Offset: 0x002ACC74
		public void ShowPkLoading(SceneType sceneType)
		{
			this._SceneType = sceneType;
			this.SetVisible(true, true);
		}

		// Token: 0x0600C480 RID: 50304 RVA: 0x002AEA88 File Offset: 0x002ACC88
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LoadingOver), null);
			bool flag = this._SceneType == SceneType.SCENE_PK;
			if (flag)
			{
				this.SetRoleInfo();
			}
			else
			{
				bool flag2 = this._SceneType == SceneType.SCENE_INVFIGHT;
				if (flag2)
				{
					this.SetInvFightInfo();
				}
			}
		}

		// Token: 0x0600C481 RID: 50305 RVA: 0x002AEAE8 File Offset: 0x002ACCE8
		protected override void OnHide()
		{
			base.OnHide();
			for (int i = 0; i < base.uiBehaviour.m_HalfPic.Length; i++)
			{
				base.uiBehaviour.m_HalfPic[i].SetTexturePath("");
			}
		}

		// Token: 0x0600C482 RID: 50306 RVA: 0x002AEB33 File Offset: 0x002ACD33
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600C483 RID: 50307 RVA: 0x002AEB3D File Offset: 0x002ACD3D
		private void LoadingOver(object o)
		{
			this._isLoadingOver = true;
		}

		// Token: 0x0600C484 RID: 50308 RVA: 0x002AEB48 File Offset: 0x002ACD48
		private void SetRoleInfo()
		{
			for (int i = 0; i < base.uiBehaviour.m_Detail.Length; i++)
			{
				base.uiBehaviour.m_Detail[i].SetActive(true);
			}
			for (int j = 0; j < this._doc.PkInfoList.Count; j++)
			{
				base.uiBehaviour.m_Level[j].SetText(string.Format("Lv.{0}", this._doc.PkInfoList[j].brief.roleLevel));
				base.uiBehaviour.m_Name[j].SetText(this._doc.PkInfoList[j].brief.roleName);
				base.uiBehaviour.m_Point[j].SetText(this._doc.PkInfoList[j].point.ToString());
				base.uiBehaviour.m_WinCount[j].SetText(this._doc.PkInfoList[j].win.ToString());
				base.uiBehaviour.m_Percent[j].SetText(string.Format("{0}%", this._doc.PkInfoList[j].percent));
				string text = "";
				int num = (this._doc.PkInfoList[j].records.Count > 5) ? 5 : this._doc.PkInfoList[j].records.Count;
				for (int k = 0; k < num; k++)
				{
					switch (this._doc.PkInfoList[j].records[k])
					{
					case 1U:
						text = string.Format((j == 0) ? "{0}[f3da5e]{1}[-]" : "[f3da5e]{1}[-]{0}", text, XStringDefineProxy.GetString("WIN"));
						break;
					case 2U:
						text = string.Format((j == 0) ? "{0}[d5d5d5]{1}[-]" : "[d5d5d5]{1}[-]{0}", text, XStringDefineProxy.GetString("LOSE"));
						break;
					case 3U:
						text = string.Format((j == 0) ? "{0}[99e243]{1}[-]" : "[99e243]{1}[-]{0}", text, XStringDefineProxy.GetString("DRAW"));
						break;
					}
				}
				base.uiBehaviour.m_NearWin[j].SetText(text);
				int num2 = (int)this._doc.PkInfoList[j].brief.roleProfession;
				bool flag = XAttributes.GetCategory(this._doc.PkInfoList[j].brief.roleID) > EntityCategory.Category_Role;
				if (flag)
				{
					num2 %= 10;
				}
				base.uiBehaviour.m_Prefession[j].SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(num2));
				string halfPic = XSingleton<XProfessionSkillMgr>.singleton.GetHalfPic(this._doc.PkInfoList[j].brief.roleProfession % 10U);
				base.uiBehaviour.m_HalfPic[j].SetTexturePath("atlas/UI/common/2DAvatar/" + halfPic);
			}
		}

		// Token: 0x0600C485 RID: 50309 RVA: 0x002AEE78 File Offset: 0x002AD078
		private void SetInvFightInfo()
		{
			for (int i = 0; i < base.uiBehaviour.m_Detail.Length; i++)
			{
				base.uiBehaviour.m_Detail[i].SetActive(false);
			}
			XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
			for (int j = 0; j < specificDocument.PKInfoList.Count; j++)
			{
				bool flag = j < base.uiBehaviour.m_Level.Length;
				if (flag)
				{
					base.uiBehaviour.m_Level[j].SetText(string.Format("Lv.{0}", specificDocument.PKInfoList[j].roleLevel));
					base.uiBehaviour.m_Name[j].SetText(specificDocument.PKInfoList[j].roleName);
					base.uiBehaviour.m_Prefession[j].SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon((int)specificDocument.PKInfoList[j].roleProfession));
					string halfPic = XSingleton<XProfessionSkillMgr>.singleton.GetHalfPic(specificDocument.PKInfoList[j].roleProfession % 10U);
					XSingleton<XDebug>.singleton.AddLog(string.Concat(new object[]
					{
						"Load atlas/UI/common/2DAvatar/",
						halfPic,
						".png, profession = ",
						specificDocument.PKInfoList[j].roleProfession
					}), null, null, null, null, null, XDebugColor.XDebug_None);
					base.uiBehaviour.m_HalfPic[j].SetTexturePath("atlas/UI/common/2DAvatar/" + halfPic);
				}
			}
		}

		// Token: 0x0600C486 RID: 50310 RVA: 0x002AF010 File Offset: 0x002AD210
		public void HidePkLoading()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				base.uiBehaviour.m_PkLoadingTween.PlayTween(true, -1f);
				base.uiBehaviour.m_PkLoadingTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPkLoadingTweenFinish));
			}
		}

		// Token: 0x0600C487 RID: 50311 RVA: 0x002AF061 File Offset: 0x002AD261
		private void OnPkLoadingTweenFinish(IXUITweenTool tween)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x0400558B RID: 21899
		private SceneType _SceneType;

		// Token: 0x0400558C RID: 21900
		private XQualifyingDocument _doc = null;

		// Token: 0x0400558D RID: 21901
		private bool _isLoadingOver = false;
	}
}
