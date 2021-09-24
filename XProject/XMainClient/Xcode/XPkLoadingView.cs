using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPkLoadingView : DlgBase<XPkLoadingView, XPkLoadingBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/PkLoadingDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public bool IsLoadingOver
		{
			get
			{
				return this._isLoadingOver;
			}
		}

		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._isLoadingOver = false;
			this._doc = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
		}

		public void ShowPkLoading(SceneType sceneType)
		{
			this._SceneType = sceneType;
			this.SetVisible(true, true);
		}

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

		protected override void OnHide()
		{
			base.OnHide();
			for (int i = 0; i < base.uiBehaviour.m_HalfPic.Length; i++)
			{
				base.uiBehaviour.m_HalfPic[i].SetTexturePath("");
			}
		}

		protected override void OnUnload()
		{
			base.OnUnload();
		}

		private void LoadingOver(object o)
		{
			this._isLoadingOver = true;
		}

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

		public void HidePkLoading()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				base.uiBehaviour.m_PkLoadingTween.PlayTween(true, -1f);
				base.uiBehaviour.m_PkLoadingTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPkLoadingTweenFinish));
			}
		}

		private void OnPkLoadingTweenFinish(IXUITweenTool tween)
		{
			this.SetVisible(false, true);
		}

		private SceneType _SceneType;

		private XQualifyingDocument _doc = null;

		private bool _isLoadingOver = false;
	}
}
