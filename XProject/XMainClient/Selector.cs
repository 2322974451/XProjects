using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BDD RID: 3037
	internal class Selector
	{
		// Token: 0x17003090 RID: 12432
		// (get) Token: 0x0600AD2A RID: 44330 RVA: 0x002010C4 File Offset: 0x001FF2C4
		public Transform transform
		{
			get
			{
				return this._transfrom;
			}
		}

		// Token: 0x17003091 RID: 12433
		// (get) Token: 0x0600AD2B RID: 44331 RVA: 0x002010DC File Offset: 0x001FF2DC
		public Transform parent
		{
			get
			{
				return this._parent;
			}
		}

		// Token: 0x0600AD2C RID: 44332 RVA: 0x002010F4 File Offset: 0x001FF2F4
		public void Bind(Transform parent, SelectorBind sBind, SelectorInvoke sInvoke)
		{
			this._bind = sBind;
			this._invoke = sInvoke;
			this._parent = parent;
			this.BindData();
		}

		// Token: 0x0600AD2D RID: 44333 RVA: 0x00201114 File Offset: 0x001FF314
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

		// Token: 0x0600AD2E RID: 44334 RVA: 0x00201180 File Offset: 0x001FF380
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

		// Token: 0x0600AD2F RID: 44335 RVA: 0x002011F8 File Offset: 0x001FF3F8
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

		// Token: 0x0600AD30 RID: 44336 RVA: 0x00201344 File Offset: 0x001FF544
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

		// Token: 0x0600AD31 RID: 44337 RVA: 0x002013B4 File Offset: 0x001FF5B4
		private void OnClickSelector(IXUISprite sprite)
		{
			bool flag = this._invoke != null;
			if (flag)
			{
				this._invoke(this.ID);
			}
		}

		// Token: 0x04004136 RID: 16694
		public uint ID = 0U;

		// Token: 0x04004137 RID: 16695
		public string Label = "";

		// Token: 0x04004138 RID: 16696
		public bool Selected = false;

		// Token: 0x04004139 RID: 16697
		public List<Selector> selectors = null;

		// Token: 0x0400413A RID: 16698
		public uint SelectorLevel = 0U;

		// Token: 0x0400413B RID: 16699
		private Transform _transfrom;

		// Token: 0x0400413C RID: 16700
		private Transform _parent;

		// Token: 0x0400413D RID: 16701
		private SelectorInvoke _invoke;

		// Token: 0x0400413E RID: 16702
		private SelectorBind _bind;
	}
}
