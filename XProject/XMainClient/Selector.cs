using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Selector
	{

		public Transform transform
		{
			get
			{
				return this._transfrom;
			}
		}

		public Transform parent
		{
			get
			{
				return this._parent;
			}
		}

		public void Bind(Transform parent, SelectorBind sBind, SelectorInvoke sInvoke)
		{
			this._bind = sBind;
			this._invoke = sInvoke;
			this._parent = parent;
			this.BindData();
		}

		public void UnBind()
		{
			bool flag = this.selectors != null;
			if (flag)
			{
				int i = 0;
				int count = this.selectors.Count;
				while (i < count)
				{
					this.selectors[i].UnBind();
					i++;
				}
			}
			this._transfrom = null;
			this._parent = null;
			this._invoke = null;
			this._bind = null;
		}

		public void Release()
		{
			bool flag = this.selectors != null;
			if (flag)
			{
				int i = 0;
				int count = this.selectors.Count;
				while (i < count)
				{
					this.selectors[i].UnBind();
					this.selectors[i] = null;
					i++;
				}
				this.selectors.Clear();
				this.selectors = null;
			}
			SelectorPool.Release(this);
		}

		private void BindData()
		{
			bool flag = this._bind == null || this._parent == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("BindData._bind is Null Or BindData._parent is Null", null, null, null, null, null);
			}
			else
			{
				this._transfrom = this._bind(this.SelectorLevel);
				IXUILabel ixuilabel = this._transfrom.Find("Label").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = this._transfrom.Find("Selected/Label").GetComponent("XUILabel") as IXUILabel;
				IXUISprite ixuisprite = this._transfrom.GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)this.ID;
				ixuilabel.SetText(this.Label);
				ixuilabel2.SetText(this.Label);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnClickSelector));
				this._transfrom.parent = this._parent;
				this._transfrom.localScale = Vector3.one;
				this._transfrom.localPosition = new Vector3(0f, -((float)this._parent.childCount - 0.5f) * (float)ixuisprite.spriteHeight, 0f);
				this.BindChildren();
			}
		}

		private void BindChildren()
		{
			bool flag = this.selectors != null && this.selectors.Count > 0;
			if (flag)
			{
				int i = 0;
				int count = this.selectors.Count;
				while (i < count)
				{
					this.selectors[i].Bind(this._transfrom, this._bind, this._invoke);
					i++;
				}
			}
		}

		private void OnClickSelector(IXUISprite sprite)
		{
			bool flag = this._invoke != null;
			if (flag)
			{
				this._invoke(this.ID);
			}
		}

		public uint ID = 0U;

		public string Label = "";

		public bool Selected = false;

		public List<Selector> selectors = null;

		public uint SelectorLevel = 0U;

		private Transform _transfrom;

		private Transform _parent;

		private SelectorInvoke _invoke;

		private SelectorBind _bind;
	}
}
