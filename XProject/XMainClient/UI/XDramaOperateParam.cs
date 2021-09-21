using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001783 RID: 6019
	internal class XDramaOperateParam : XDataBase
	{
		// Token: 0x0600F863 RID: 63587 RVA: 0x0038C188 File Offset: 0x0038A388
		public override void Init()
		{
			base.Init();
			for (int i = 0; i < XDramaOperateParam.MAX_BUTTON_COUNT; i++)
			{
				bool flag = this._Buttons[i] != null;
				if (flag)
				{
					this._Buttons[i].Recycle();
					this._Buttons[i] = null;
				}
			}
			for (int j = 0; j < XDramaOperateParam.MAX_LIST_COUNT; j++)
			{
				bool flag2 = this._Lists[j] != null;
				if (flag2)
				{
					this._Lists[j].Recycle();
					this._Lists[j] = null;
				}
			}
			this._ButtonCount = 0;
			this._ListCount = 0;
			this.Npc = null;
			this.Text = null;
		}

		// Token: 0x0600F864 RID: 63588 RVA: 0x0038C239 File Offset: 0x0038A439
		public override void Recycle()
		{
			XDataPool<XDramaOperateParam>.Recycle(this);
		}

		// Token: 0x0600F865 RID: 63589 RVA: 0x0038C244 File Offset: 0x0038A444
		public XDramaOperateButton AppendButton(string name, ButtonClickEventHandler callback, ulong id)
		{
			bool flag = this._ButtonCount >= XDramaOperateParam.MAX_BUTTON_COUNT;
			XDramaOperateButton result;
			if (flag)
			{
				result = null;
			}
			else
			{
				XDramaOperateButton data = XDataPool<XDramaOperateButton>.GetData();
				data.Name = name;
				data.RID = id;
				bool flag2 = callback != null;
				if (flag2)
				{
					data.ClickEvent = callback;
				}
				else
				{
					data.ClickEvent = new ButtonClickEventHandler(this._DefaultCallback);
				}
				this._Buttons[this._ButtonCount] = data;
				this._ButtonCount++;
				result = data;
			}
			return result;
		}

		// Token: 0x0600F866 RID: 63590 RVA: 0x0038C2C4 File Offset: 0x0038A4C4
		public XDramaOperateList AppendList(string name, SpriteClickEventHandler callback, ulong id)
		{
			bool flag = this._ListCount >= XDramaOperateParam.MAX_LIST_COUNT;
			XDramaOperateList result;
			if (flag)
			{
				result = null;
			}
			else
			{
				XDramaOperateList data = XDataPool<XDramaOperateList>.GetData();
				data.Name = name;
				data.RID = id;
				bool flag2 = callback != null;
				if (flag2)
				{
					data.ClickEvent = callback;
				}
				else
				{
					data.ClickEvent = new SpriteClickEventHandler(this._DefaultCallback);
				}
				this._Lists[this._ListCount] = data;
				this._ListCount++;
				result = data;
			}
			return result;
		}

		// Token: 0x0600F867 RID: 63591 RVA: 0x0038C342 File Offset: 0x0038A542
		private void _DefaultCallback(IXUISprite iSp)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
		}

		// Token: 0x0600F868 RID: 63592 RVA: 0x0038C354 File Offset: 0x0038A554
		private bool _DefaultCallback(IXUIButton btn)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		// Token: 0x17003839 RID: 14393
		// (get) Token: 0x0600F869 RID: 63593 RVA: 0x0038C374 File Offset: 0x0038A574
		public XDramaOperateButton[] Buttons
		{
			get
			{
				return this._Buttons;
			}
		}

		// Token: 0x1700383A RID: 14394
		// (get) Token: 0x0600F86A RID: 63594 RVA: 0x0038C38C File Offset: 0x0038A58C
		public XDramaOperateList[] Lists
		{
			get
			{
				return this._Lists;
			}
		}

		// Token: 0x1700383B RID: 14395
		// (get) Token: 0x0600F86B RID: 63595 RVA: 0x0038C3A4 File Offset: 0x0038A5A4
		public int ButtonCount
		{
			get
			{
				return this._ButtonCount;
			}
		}

		// Token: 0x1700383C RID: 14396
		// (get) Token: 0x0600F86C RID: 63596 RVA: 0x0038C3BC File Offset: 0x0038A5BC
		public int ListCount
		{
			get
			{
				return this._ListCount;
			}
		}

		// Token: 0x04006C6B RID: 27755
		public static int MAX_BUTTON_COUNT = 4;

		// Token: 0x04006C6C RID: 27756
		public static int MAX_LIST_COUNT = 2;

		// Token: 0x04006C6D RID: 27757
		public XNpc Npc;

		// Token: 0x04006C6E RID: 27758
		public string Text;

		// Token: 0x04006C6F RID: 27759
		private XDramaOperateButton[] _Buttons = new XDramaOperateButton[XDramaOperateParam.MAX_BUTTON_COUNT];

		// Token: 0x04006C70 RID: 27760
		private XDramaOperateList[] _Lists = new XDramaOperateList[XDramaOperateParam.MAX_LIST_COUNT];

		// Token: 0x04006C71 RID: 27761
		private int _ButtonCount;

		// Token: 0x04006C72 RID: 27762
		private int _ListCount;
	}
}
