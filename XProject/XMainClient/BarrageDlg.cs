using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BC5 RID: 3013
	internal class BarrageDlg : DlgBase<BarrageDlg, BarrageBehaviour>
	{
		// Token: 0x17003071 RID: 12401
		// (get) Token: 0x0600AC0D RID: 44045 RVA: 0x001F99DC File Offset: 0x001F7BDC
		public override string fileName
		{
			get
			{
				return "Common/BarrageDlg";
			}
		}

		// Token: 0x17003072 RID: 12402
		// (get) Token: 0x0600AC0E RID: 44046 RVA: 0x001F99F4 File Offset: 0x001F7BF4
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003073 RID: 12403
		// (get) Token: 0x0600AC0F RID: 44047 RVA: 0x001F9A08 File Offset: 0x001F7C08
		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AC10 RID: 44048 RVA: 0x001F9A1C File Offset: 0x001F7C1C
		protected override void Init()
		{
			base.Init();
			BarrageDlg.MAX_QUEUE_CNT = XSingleton<XGlobalConfig>.singleton.GetInt("BarrageQueueCnt");
			BarrageDlg.MOVE_TIME = XSingleton<XGlobalConfig>.singleton.GetInt("BarrageTime");
			this.barrages = new BarrageQueue[BarrageDlg.MAX_QUEUE_CNT];
			for (int i = 0; i < BarrageDlg.MAX_QUEUE_CNT; i++)
			{
				this.barrages[i] = new BarrageQueue();
			}
			base.uiBehaviour.SetupPool();
		}

		// Token: 0x0600AC11 RID: 44049 RVA: 0x001F9A98 File Offset: 0x001F7C98
		protected override void OnUnload()
		{
			bool flag = this.itemspool != null;
			if (flag)
			{
				this.itemspool.Clear();
			}
			bool flag2 = base.IsVisible();
			if (flag2)
			{
				this.SetVisible(false, true);
			}
			base.OnUnload();
		}

		// Token: 0x0600AC12 RID: 44050 RVA: 0x001F9ADC File Offset: 0x001F7CDC
		public void OnFouceGame(bool pause)
		{
			this.ClearAll();
			bool flag = !pause;
			if (flag)
			{
				this.recoveryTime = Time.unscaledTime;
			}
		}

		// Token: 0x0600AC13 RID: 44051 RVA: 0x001F9B04 File Offset: 0x001F7D04
		public void ClearAll()
		{
			bool flag = base.IsLoaded() && base.IsVisible();
			if (flag)
			{
				bool flag2 = this.itemspool != null;
				if (flag2)
				{
					while (this.itemspool.Count > 0)
					{
						BarrageItem barrageItem = this.itemspool.Peek();
						barrageItem.Drop();
						this.itemspool.Dequeue();
					}
					this.itemspool.Clear();
					for (int i = 0; i < this.barrages.Length; i++)
					{
						this.barrages[i].ForceClear();
					}
				}
			}
		}

		// Token: 0x0600AC14 RID: 44052 RVA: 0x001F9BAC File Offset: 0x001F7DAC
		public void RealPush(ChatInfo info)
		{
			bool flag = Time.unscaledTime - this.recoveryTime < 0.8f && this.recoveryTime != 0f;
			if (!flag)
			{
				bool flag2 = info.mChannelId == ChatChannelType.Spectate;
				if (flag2)
				{
					string mContent = info.mContent;
					this.RealPush(mContent, info.isSelfSender);
				}
			}
		}

		// Token: 0x0600AC15 RID: 44053 RVA: 0x001F9C0C File Offset: 0x001F7E0C
		public void RealPush(string txt, bool outline = false)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				txt = DlgBase<ChatEmotionView, ChatEmotionBehaviour>.singleton.OnRemoveEmotion(txt);
				txt = this.RemoveLink(txt);
				bool flag2 = !string.IsNullOrEmpty(txt);
				if (flag2)
				{
					int queueCnt = this.barrages[0].queueCnt;
					BarrageQueue barrageQueue = this.barrages[0];
					int num = 0;
					for (int i = BarrageDlg.MAX_QUEUE_CNT - 1; i > 0; i--)
					{
						bool flag3 = this.barrages[i].queueCnt < queueCnt;
						if (flag3)
						{
							num = i;
							queueCnt = this.barrages[i].queueCnt;
							barrageQueue = this.barrages[i];
						}
					}
					BarrageItem barrageItem = this.FetchItem();
					barrageItem.transform.parent = base.uiBehaviour.m_objQueue[num].transform;
					barrageItem.transform.localScale = Vector3.one;
					barrageItem.transform.localEulerAngles = Vector3.zero;
					barrageItem.transform.localPosition = new Vector3(base.uiBehaviour.m_tranRightBound.transform.localPosition.x, 0f, 0f);
					barrageQueue.Fire(barrageItem, txt, outline);
				}
			}
		}

		// Token: 0x0600AC16 RID: 44054 RVA: 0x001F9D4C File Offset: 0x001F7F4C
		public bool IsOutScreen(float posX)
		{
			bool flag = base.IsVisible();
			return flag && posX < base.uiBehaviour.m_tranLeftBound.localPosition.x;
		}

		// Token: 0x0600AC17 RID: 44055 RVA: 0x001F9D84 File Offset: 0x001F7F84
		public BarrageItem FetchItem()
		{
			bool flag = this.itemspool.Count > 0;
			BarrageItem barrageItem;
			if (flag)
			{
				barrageItem = this.itemspool.Dequeue();
				barrageItem.gameObject.SetActive(true);
			}
			else
			{
				GameObject gameObject = XCommon.Instantiate<GameObject>(base.uiBehaviour.m_lblTpl.gameObject);
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localEulerAngles = Vector3.zero;
				barrageItem = gameObject.AddComponent<BarrageItem>();
			}
			return barrageItem;
		}

		// Token: 0x0600AC18 RID: 44056 RVA: 0x001F9E08 File Offset: 0x001F8008
		public void RecycleItem(BarrageItem item)
		{
			bool flag = this.itemspool.Count > 8;
			if (flag)
			{
				item.Drop();
			}
			else
			{
				item.gameObject.SetActive(false);
				this.itemspool.Enqueue(item);
			}
		}

		// Token: 0x0600AC19 RID: 44057 RVA: 0x001F9E50 File Offset: 0x001F8050
		public string RemoveLink(string content)
		{
			bool flag = content.Contains("sp=");
			if (flag)
			{
				int num = content.LastIndexOf("sp=") - 1;
				bool flag2 = num > 0;
				if (flag2)
				{
					content = content.Remove(num);
				}
			}
			return content;
		}

		// Token: 0x040040AF RID: 16559
		public bool openBarrage = true;

		// Token: 0x040040B0 RID: 16560
		public static int MAX_QUEUE_CNT = 1;

		// Token: 0x040040B1 RID: 16561
		public static int MOVE_TIME = 15;

		// Token: 0x040040B2 RID: 16562
		private const int MAX_RECYCLE_CNT = 8;

		// Token: 0x040040B3 RID: 16563
		private BarrageQueue[] barrages;

		// Token: 0x040040B4 RID: 16564
		private Queue<BarrageItem> itemspool = new Queue<BarrageItem>();

		// Token: 0x040040B5 RID: 16565
		private float recoveryTime = 0f;
	}
}
