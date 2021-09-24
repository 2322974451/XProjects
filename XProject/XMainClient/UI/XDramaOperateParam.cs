using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XDramaOperateParam : XDataBase
	{

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

		public override void Recycle()
		{
			XDataPool<XDramaOperateParam>.Recycle(this);
		}

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

		private void _DefaultCallback(IXUISprite iSp)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
		}

		private bool _DefaultCallback(IXUIButton btn)
		{
			DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			return true;
		}

		public XDramaOperateButton[] Buttons
		{
			get
			{
				return this._Buttons;
			}
		}

		public XDramaOperateList[] Lists
		{
			get
			{
				return this._Lists;
			}
		}

		public int ButtonCount
		{
			get
			{
				return this._ButtonCount;
			}
		}

		public int ListCount
		{
			get
			{
				return this._ListCount;
			}
		}

		public static int MAX_BUTTON_COUNT = 4;

		public static int MAX_LIST_COUNT = 2;

		public XNpc Npc;

		public string Text;

		private XDramaOperateButton[] _Buttons = new XDramaOperateButton[XDramaOperateParam.MAX_BUTTON_COUNT];

		private XDramaOperateList[] _Lists = new XDramaOperateList[XDramaOperateParam.MAX_LIST_COUNT];

		private int _ButtonCount;

		private int _ListCount;
	}
}
