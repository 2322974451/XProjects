using System;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class BarrageDlg : DlgBase<BarrageDlg, BarrageBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Common/BarrageDlg";
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isMainUI
		{
			get
			{
				return true;
			}
		}

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

		public void OnFouceGame(bool pause)
		{
			this.ClearAll();
			bool flag = !pause;
			if (flag)
			{
				this.recoveryTime = Time.unscaledTime;
			}
		}

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

		public bool IsOutScreen(float posX)
		{
			bool flag = base.IsVisible();
			return flag && posX < base.uiBehaviour.m_tranLeftBound.localPosition.x;
		}

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

		public bool openBarrage = true;

		public static int MAX_QUEUE_CNT = 1;

		public static int MOVE_TIME = 15;

		private const int MAX_RECYCLE_CNT = 8;

		private BarrageQueue[] barrages;

		private Queue<BarrageItem> itemspool = new Queue<BarrageItem>();

		private float recoveryTime = 0f;
	}
}
