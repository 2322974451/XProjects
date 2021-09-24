using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	public class CarnivalBehavior : DlgBehaviourBase
	{

		private void Awake()
		{
			this._endLabel = (base.transform.Find("Bg/Deadline").GetComponent("XUILabel") as IXUILabel);
			this._contentPanel = base.transform.Find("Bg/contentFrame").gameObject;
			this._rwdPanel = base.transform.Find("Bg/rwdFrame").gameObject;
			this._close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			for (int i = 0; i < 7; i++)
			{
				this._tabs[i] = (base.transform.Find("Bg/Tabs/TabTpl" + i + "/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
				this._redpoint[i] = this._tabs[i].gameObject.transform.Find("RedPoint").gameObject;
				this._lock[i] = this._tabs[i].gameObject.transform.Find("lock");
			}
		}

		public IXUILabel _endLabel;

		public GameObject _contentPanel;

		public GameObject _rwdPanel;

		public IXUIButton _close;

		public IXUICheckBox[] _tabs = new IXUICheckBox[7];

		public GameObject[] _redpoint = new GameObject[7];

		public Transform[] _lock = new Transform[7];
	}
}
