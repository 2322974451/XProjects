using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A37 RID: 2615
	internal class RecruitPublishBehaviour : DlgBehaviourBase
	{
		// Token: 0x06009F3A RID: 40762 RVA: 0x001A5B60 File Offset: 0x001A3D60
		private void Awake()
		{
			this._Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this._Submit = (base.transform.Find("Bg/Submit").GetComponent("XUIButton") as IXUIButton);
			this._TypeListScrollView = (base.transform.Find("Bg/TypeList").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform = base.transform.Find("Bg/TypeList/Table/LevelOneTpl");
			this._levelOnePool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			transform = base.transform.Find("Bg/TypeList/Table/LevelTwoTpl");
			this._levelTwoPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			this._StartTime = base.transform.Find("Bg/StartTime");
			transform = base.transform.Find("Bg/MemberTypes");
			int childCount = transform.childCount;
			this._memberTypes = new IXUICheckBox[childCount];
			for (int i = 0; i < childCount; i++)
			{
				string text = XSingleton<XCommon>.singleton.StringCombine("GroupMember_Type", i.ToString());
				IXUICheckBox ixuicheckBox = transform.Find(text).GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.ID = (ulong)((long)i);
				IXUILabel ixuilabel = ixuicheckBox.gameObject.transform.Find("Text").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(XStringDefineProxy.GetString(text));
				this._memberTypes[i] = ixuicheckBox;
			}
			this.OtherAwake();
		}

		// Token: 0x06009F3B RID: 40763 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public virtual void OtherAwake()
		{
		}

		// Token: 0x040038C9 RID: 14537
		public IXUIButton _Close;

		// Token: 0x040038CA RID: 14538
		public IXUIButton _Submit;

		// Token: 0x040038CB RID: 14539
		public IXUIScrollView _TypeListScrollView;

		// Token: 0x040038CC RID: 14540
		public XUIPool _levelOnePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040038CD RID: 14541
		public XUIPool _levelTwoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040038CE RID: 14542
		public IXUICheckBox[] _memberTypes;

		// Token: 0x040038CF RID: 14543
		public Transform _StartTime;
	}
}
