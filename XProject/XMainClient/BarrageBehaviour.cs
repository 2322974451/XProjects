using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BC4 RID: 3012
	internal class BarrageBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600AC0A RID: 44042 RVA: 0x001F98A4 File Offset: 0x001F7AA4
		private void Awake()
		{
			this.m_tranLeftBound = base.transform.Find("Bg/left");
			this.m_tranRightBound = base.transform.Find("Bg/right");
			this.m_lblTpl = (base.transform.Find("Bg/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_objQueueTpl = base.transform.Find("Bg/queue").gameObject;
			this.m_pool.SetupPool(this.m_objQueueTpl.transform.parent.gameObject, this.m_objQueueTpl, 3U, true);
		}

		// Token: 0x0600AC0B RID: 44043 RVA: 0x001F9948 File Offset: 0x001F7B48
		public void SetupPool()
		{
			this.m_objQueue = new GameObject[BarrageDlg.MAX_QUEUE_CNT];
			for (int i = 0; i < BarrageDlg.MAX_QUEUE_CNT; i++)
			{
				this.m_objQueue[i] = this.m_pool.FetchGameObject(false);
				this.m_objQueue[i].transform.localPosition = new Vector3(0f, (float)(320 - 40 * i), 0f);
			}
		}

		// Token: 0x040040A9 RID: 16553
		public Transform m_tranLeftBound;

		// Token: 0x040040AA RID: 16554
		public Transform m_tranRightBound;

		// Token: 0x040040AB RID: 16555
		public IXUILabel m_lblTpl;

		// Token: 0x040040AC RID: 16556
		public GameObject m_objQueueTpl;

		// Token: 0x040040AD RID: 16557
		public GameObject[] m_objQueue;

		// Token: 0x040040AE RID: 16558
		public XUIPool m_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
