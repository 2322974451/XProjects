using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RecruitPublishBehaviour : DlgBehaviourBase
	{

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

		public virtual void OtherAwake()
		{
		}

		public IXUIButton _Close;

		public IXUIButton _Submit;

		public IXUIScrollView _TypeListScrollView;

		public XUIPool _levelOnePool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUIPool _levelTwoPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUICheckBox[] _memberTypes;

		public Transform _StartTime;
	}
}
