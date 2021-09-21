using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001723 RID: 5923
	internal class BattleVoiceHandler : DlgHandlerBase
	{
		// Token: 0x0600F4A1 RID: 62625 RVA: 0x0036F81C File Offset: 0x0036DA1C
		protected override void Init()
		{
			base.Init();
			this.tpl = base.PanelObject.transform.Find("tpl").gameObject;
			this.m_pool.SetupPool(this.tpl.transform.parent.gameObject, this.tpl, 2U, true);
		}

		// Token: 0x0600F4A2 RID: 62626 RVA: 0x0036F87C File Offset: 0x0036DA7C
		public void Refresh(List<VoipRoomMember> _server)
		{
			this.dic.Clear();
			this.m_pool.ReturnAll(false);
			for (int i = 0; i < _server.Count; i++)
			{
				GameObject gameObject = this.m_pool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(-147f, (float)(10 - 40 * i), 0f);
				IXUILabel ixuilabel = gameObject.GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(_server[i].name);
				GameObject gameObject2 = gameObject.transform.Find("voice").gameObject;
				gameObject2.SetActive(true);
				GameObject gameObject3 = gameObject.transform.Find("speak").gameObject;
				gameObject3.SetActive(false);
				BattleVoiceNode battleVoiceNode = new BattleVoiceNode();
				battleVoiceNode.memberid = _server[i].memberID;
				battleVoiceNode.sign = false;
				battleVoiceNode.roleid = _server[i].roleID;
				battleVoiceNode.speak = gameObject3;
				battleVoiceNode.voice = gameObject2;
				this.dic.Add(battleVoiceNode.roleid, battleVoiceNode);
			}
		}

		// Token: 0x0600F4A3 RID: 62627 RVA: 0x0036F9B0 File Offset: 0x0036DBB0
		public void Play(ulong[] roleids, int[] states)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsLoaded();
			if (flag)
			{
				for (int i = 0; i < roleids.Length; i++)
				{
					bool flag2 = this.dic.ContainsKey(roleids[i]);
					if (flag2)
					{
						this.dic[roleids[i]].speak.SetActive(states[i] == 2);
						this.dic[roleids[i]].voice.SetActive(states[i] == 1);
					}
				}
			}
		}

		// Token: 0x04006985 RID: 27013
		public GameObject tpl;

		// Token: 0x04006986 RID: 27014
		private XUIPool m_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04006987 RID: 27015
		public Dictionary<ulong, BattleVoiceNode> dic = new Dictionary<ulong, BattleVoiceNode>();
	}
}
