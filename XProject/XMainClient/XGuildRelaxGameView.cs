using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E46 RID: 3654
	internal class XGuildRelaxGameView : DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>
	{
		// Token: 0x1700345A RID: 13402
		// (get) Token: 0x0600C42F RID: 50223 RVA: 0x002AC7AC File Offset: 0x002AA9AC
		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildRelaxGameDlg";
			}
		}

		// Token: 0x1700345B RID: 13403
		// (get) Token: 0x0600C430 RID: 50224 RVA: 0x002AC7C4 File Offset: 0x002AA9C4
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700345C RID: 13404
		// (get) Token: 0x0600C431 RID: 50225 RVA: 0x002AC7D8 File Offset: 0x002AA9D8
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700345D RID: 13405
		// (get) Token: 0x0600C432 RID: 50226 RVA: 0x002AC7EC File Offset: 0x002AA9EC
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700345E RID: 13406
		// (get) Token: 0x0600C433 RID: 50227 RVA: 0x002AC800 File Offset: 0x002AAA00
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700345F RID: 13407
		// (get) Token: 0x0600C434 RID: 50228 RVA: 0x002AC814 File Offset: 0x002AAA14
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600C435 RID: 50229 RVA: 0x002AC828 File Offset: 0x002AAA28
		protected override void Init()
		{
			base.Init();
			this.m_realxSysList = new List<XSysDefine>();
			this.m_relaxChildren = new List<GuildRelaxChildHandler>();
			this.m_RelaxIndex = 0;
			this.RegisterHandler<GuildRelaxVoiceHandler>(XSysDefine.XSys_GuildRelax_VoiceQA);
			this.RegisterHandler<GuildRelaxJokerMatchHandler>(XSysDefine.XSys_GuildRelax_JokerMatch);
			this.RegisterHandler<GuildRelaxCollectHandler>(XSysDefine.XSys_GuildCollect);
			base.uiBehaviour.m_GameScrollView.ResetPosition();
		}

		// Token: 0x0600C436 RID: 50230 RVA: 0x002AC88F File Offset: 0x002AAA8F
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		// Token: 0x0600C437 RID: 50231 RVA: 0x002AC8B8 File Offset: 0x002AAAB8
		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600C438 RID: 50232 RVA: 0x002AC8D4 File Offset: 0x002AAAD4
		protected override void OnUnload()
		{
			this.RemoveHandler(XSysDefine.XSys_GuildRelax_VoiceQA);
			this.RemoveHandler(XSysDefine.XSys_GuildRelax_JokerMatch);
			this.RemoveHandler(XSysDefine.XSys_GuildCollect);
			this.m_realxSysList.Clear();
			this.m_relaxChildren.Clear();
			this.m_realxSysList = null;
			this.m_relaxChildren = null;
			base.OnUnload();
		}

		// Token: 0x0600C439 RID: 50233 RVA: 0x002AC934 File Offset: 0x002AAB34
		public override void StackRefresh()
		{
			base.StackRefresh();
			int i = 0;
			int count = this.m_relaxChildren.Count;
			while (i < count)
			{
				this.m_relaxChildren[i].StackRefresh();
				i++;
			}
		}

		// Token: 0x0600C43A RID: 50234 RVA: 0x002AC97C File Offset: 0x002AAB7C
		public bool TryGetRelaxChild(XSysDefine define, out GuildRelaxChildHandler handler)
		{
			int num = this.m_realxSysList.IndexOf(define);
			bool flag = num < 0;
			bool result;
			if (flag)
			{
				handler = null;
				result = false;
			}
			else
			{
				handler = this.m_relaxChildren[num];
				result = true;
			}
			return result;
		}

		// Token: 0x0600C43B RID: 50235 RVA: 0x002AC9BC File Offset: 0x002AABBC
		protected override void OnHide()
		{
			int i = 0;
			int count = this.m_relaxChildren.Count;
			while (i < count)
			{
				this.m_relaxChildren[i].SetVisible(false);
				i++;
			}
			base.OnHide();
		}

		// Token: 0x0600C43C RID: 50236 RVA: 0x002ACA04 File Offset: 0x002AAC04
		protected override void OnShow()
		{
			base.OnShow();
			int i = 0;
			int count = this.m_relaxChildren.Count;
			while (i < count)
			{
				this.m_relaxChildren[i].SetVisible(true);
				i++;
			}
		}

		// Token: 0x0600C43D RID: 50237 RVA: 0x002ACA4C File Offset: 0x002AAC4C
		public override void OnUpdate()
		{
			base.OnUpdate();
			int i = 0;
			int count = this.m_relaxChildren.Count;
			while (i < count)
			{
				this.m_relaxChildren[i].OnUpdate();
				i++;
			}
		}

		// Token: 0x0600C43E RID: 50238 RVA: 0x002ACA94 File Offset: 0x002AAC94
		private void RegisterHandler<T>(XSysDefine define) where T : GuildRelaxChildHandler, new()
		{
			bool flag = this.m_realxSysList.IndexOf(define) < 0;
			if (flag)
			{
				T t = default(T);
				GameObject gameObject = XCommon.Instantiate<GameObject>(base.uiBehaviour.m_GameTemp);
				gameObject.SetActive(true);
				gameObject.transform.parent = this.m_uiBehaviour.m_GameScrollView.gameObject.transform;
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = new Vector3((float)(-340 + this.m_RelaxIndex * 360), -28f, 0f);
				gameObject.name = define.ToString();
				t = DlgHandlerBase.EnsureCreate<T>(ref t, gameObject, null, false);
				this.m_realxSysList.Add(define);
				this.m_relaxChildren.Add(t);
				t.SetGuildRelex(define);
				this.m_RelaxIndex++;
			}
		}

		// Token: 0x0600C43F RID: 50239 RVA: 0x002ACB94 File Offset: 0x002AAD94
		private void RemoveHandler(XSysDefine define)
		{
			int num = this.m_realxSysList.IndexOf(define);
			bool flag = num < 0;
			if (!flag)
			{
				GuildRelaxChildHandler guildRelaxChildHandler = this.m_relaxChildren[num];
				DlgHandlerBase.EnsureUnload<GuildRelaxChildHandler>(ref guildRelaxChildHandler);
				this.m_relaxChildren.RemoveAt(num);
				this.m_realxSysList.RemoveAt(num);
			}
		}

		// Token: 0x0600C440 RID: 50240 RVA: 0x002ACBE8 File Offset: 0x002AADE8
		public void Refresh(XSysDefine define)
		{
			GuildRelaxChildHandler guildRelaxChildHandler;
			bool flag = this.TryGetRelaxChild(define, out guildRelaxChildHandler);
			if (flag)
			{
				guildRelaxChildHandler.RefreshData();
			}
		}

		// Token: 0x0600C441 RID: 50241 RVA: 0x002ACC0C File Offset: 0x002AAE0C
		public void RefreshRedPoint(XSysDefine define)
		{
			GuildRelaxChildHandler guildRelaxChildHandler;
			bool flag = this.TryGetRelaxChild(define, out guildRelaxChildHandler);
			if (flag)
			{
				guildRelaxChildHandler.RefreshRedPoint();
			}
		}

		// Token: 0x04005547 RID: 21831
		private List<XSysDefine> m_realxSysList;

		// Token: 0x04005548 RID: 21832
		private List<GuildRelaxChildHandler> m_relaxChildren;

		// Token: 0x04005549 RID: 21833
		private int m_RelaxIndex = 0;
	}
}
