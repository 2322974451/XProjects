using System;
using KKSG;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C7B RID: 3195
	internal class XMultiPkLoadingView : DlgBase<XMultiPkLoadingView, XMultiPkLoadingBehaviour>
	{
		// Token: 0x170031F4 RID: 12788
		// (get) Token: 0x0600B493 RID: 46227 RVA: 0x00235ADC File Offset: 0x00233CDC
		public override string fileName
		{
			get
			{
				return "Common/PkLoadingDlg2";
			}
		}

		// Token: 0x170031F5 RID: 12789
		// (get) Token: 0x0600B494 RID: 46228 RVA: 0x00235AF4 File Offset: 0x00233CF4
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170031F6 RID: 12790
		// (get) Token: 0x0600B495 RID: 46229 RVA: 0x00235B08 File Offset: 0x00233D08
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170031F7 RID: 12791
		// (get) Token: 0x0600B496 RID: 46230 RVA: 0x00235B1C File Offset: 0x00233D1C
		public bool IsLoadingOver
		{
			get
			{
				return this._isLoadingOver;
			}
		}

		// Token: 0x170031F8 RID: 12792
		// (get) Token: 0x0600B497 RID: 46231 RVA: 0x00235B34 File Offset: 0x00233D34
		public override bool needOnTop
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B498 RID: 46232 RVA: 0x00235B47 File Offset: 0x00233D47
		protected override void Init()
		{
			base.Init();
			this._isLoadingOver = false;
			this._doc = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
		}

		// Token: 0x0600B499 RID: 46233 RVA: 0x00235B68 File Offset: 0x00233D68
		public void ShowPkLoading()
		{
			this.SetVisible(true, true);
		}

		// Token: 0x0600B49A RID: 46234 RVA: 0x00235B74 File Offset: 0x00233D74
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.LoadingOver), null);
			this.SetRoleInfo();
		}

		// Token: 0x0600B49B RID: 46235 RVA: 0x00235BA4 File Offset: 0x00233DA4
		protected override void OnHide()
		{
			base.OnHide();
			for (int i = 0; i < base.uiBehaviour.m_HalfPic.Length; i++)
			{
				base.uiBehaviour.m_HalfPic[i].SetTexturePath("");
			}
		}

		// Token: 0x0600B49C RID: 46236 RVA: 0x00235BEF File Offset: 0x00233DEF
		protected override void OnUnload()
		{
			base.OnUnload();
		}

		// Token: 0x0600B49D RID: 46237 RVA: 0x00235BF9 File Offset: 0x00233DF9
		private void LoadingOver(object o)
		{
			this._isLoadingOver = true;
		}

		// Token: 0x0600B49E RID: 46238 RVA: 0x00235C04 File Offset: 0x00233E04
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

		// Token: 0x0600B49F RID: 46239 RVA: 0x00235D4C File Offset: 0x00233F4C
		public void HidePkLoading()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				base.uiBehaviour.m_PkLoadingTween.PlayTween(true, -1f);
				base.uiBehaviour.m_PkLoadingTween.RegisterOnFinishEventHandler(new OnTweenFinishEventHandler(this.OnPkLoadingTweenFinish));
			}
		}

		// Token: 0x0600B4A0 RID: 46240 RVA: 0x00235D9D File Offset: 0x00233F9D
		private void OnPkLoadingTweenFinish(IXUITweenTool tween)
		{
			this.SetVisible(false, true);
		}

		// Token: 0x04004626 RID: 17958
		private XQualifyingDocument _doc = null;

		// Token: 0x04004627 RID: 17959
		private bool _isLoadingOver = false;
	}
}
