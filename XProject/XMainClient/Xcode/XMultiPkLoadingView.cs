using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XMultiPkLoadingView : DlgBase<XMultiPkLoadingView, XMultiPkLoadingBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/PkLoadingDlg2";
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

		public void ShowPkLoading()
		{
			this.SetVisible(true, true);
		}

		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LoadingOver), null);
			this.SetRoleInfo();
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
			int num = 0;
			while (num < this._doc.PkInfoList.Count && num < 4)
			{
				base.uiBehaviour.m_Name[num].SetText(this._doc.PkInfoList[num].brief.roleName);
				base.uiBehaviour.m_Score[num].SetText(this._doc.PkInfoList[num].point.ToString());
				int num2 = (int)this._doc.PkInfoList[num].brief.roleProfession;
				bool flag = XAttributes.GetCategory(this._doc.PkInfoList[num].brief.roleID) > EntityCategory.Category_Role;
				if (flag)
				{
					num2 %= 10;
				}
				base.uiBehaviour.m_Prefession[num].SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(num2));
				string halfPic = XSingleton<XProfessionSkillMgr>.singleton.GetHalfPic(this._doc.PkInfoList[num].brief.roleProfession % 10U);
				base.uiBehaviour.m_HalfPic[num].SetTexturePath("atlas/UI/common/2DAvatar/" + halfPic);
				num++;
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

		private XQualifyingDocument _doc = null;

		private bool _isLoadingOver = false;
	}
}
