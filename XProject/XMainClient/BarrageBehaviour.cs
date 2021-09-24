using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class BarrageBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_tranLeftBound = base.transform.Find("Bg/left");
			this.m_tranRightBound = base.transform.Find("Bg/right");
			this.m_lblTpl = (base.transform.Find("Bg/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_objQueueTpl = base.transform.Find("Bg/queue").gameObject;
			this.m_pool.SetupPool(this.m_objQueueTpl.transform.parent.gameObject, this.m_objQueueTpl, 3U, true);
		}

		public void SetupPool()
		{
			this.m_objQueue = new GameObject[BarrageDlg.MAX_QUEUE_CNT];
			for (int i = 0; i < BarrageDlg.MAX_QUEUE_CNT; i++)
			{
				this.m_objQueue[i] = this.m_pool.FetchGameObject(false);
				this.m_objQueue[i].transform.localPosition = new Vector3(0f, (float)(320 - 40 * i), 0f);
			}
		}

		public Transform m_tranLeftBound;

		public Transform m_tranRightBound;

		public IXUILabel m_lblTpl;

		public GameObject m_objQueueTpl;

		public GameObject[] m_objQueue;

		public XUIPool m_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
