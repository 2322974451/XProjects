using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildRelaxGameView : DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildSystem/GuildRelaxGameDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
		}

		private bool OnCloseClick(IXUIButton button)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

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

		public void Refresh(XSysDefine define)
		{
			GuildRelaxChildHandler guildRelaxChildHandler;
			bool flag = this.TryGetRelaxChild(define, out guildRelaxChildHandler);
			if (flag)
			{
				guildRelaxChildHandler.RefreshData();
			}
		}

		public void RefreshRedPoint(XSysDefine define)
		{
			GuildRelaxChildHandler guildRelaxChildHandler;
			bool flag = this.TryGetRelaxChild(define, out guildRelaxChildHandler);
			if (flag)
			{
				guildRelaxChildHandler.RefreshRedPoint();
			}
		}

		private List<XSysDefine> m_realxSysList;

		private List<GuildRelaxChildHandler> m_relaxChildren;

		private int m_RelaxIndex = 0;
	}
}
