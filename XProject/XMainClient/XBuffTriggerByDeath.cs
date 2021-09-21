using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020008A2 RID: 2210
	internal class XBuffTriggerByDeath : XBuffTrigger
	{
		// Token: 0x06008619 RID: 34329 RVA: 0x0010D887 File Offset: 0x0010BA87
		public XBuffTriggerByDeath(XBuff buff) : base(buff)
		{
			this.m_Type = base._GetTriggerParamInt(buff.BuffInfo, 0);
			this.m_Param0 = base._GetTriggerParamInt(buff.BuffInfo, 1);
		}

		// Token: 0x0600861A RID: 34330 RVA: 0x0010D8B8 File Offset: 0x0010BAB8
		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			base.OnAdd(entity, pEffectHelper);
			this.m_Entity = entity;
		}

		// Token: 0x0600861B RID: 34331 RVA: 0x0010D8CB File Offset: 0x0010BACB
		public override void OnRealDead(XRealDeadEventArgs e)
		{
			base.Trigger();
		}

		// Token: 0x0600861C RID: 34332 RVA: 0x0010D8D8 File Offset: 0x0010BAD8
		public override bool CheckTriggerCondition()
		{
			int type = this.m_Type;
			if (type == 0)
			{
				bool flag = !XSingleton<XScene>.singleton.SceneData.CanRevive;
				if (!flag)
				{
					bool flag2 = this.m_Param0 == 1;
					if (flag2)
					{
						XReviveDocument specificDocument = XDocuments.GetSpecificDocument<XReviveDocument>(XReviveDocument.uuID);
						bool flag3 = specificDocument.ReviveUsedTime >= specificDocument.ReviveMaxTime;
						if (flag3)
						{
							goto IL_5D;
						}
					}
					return true;
				}
			}
			IL_5D:
			return false;
		}

		// Token: 0x0600861D RID: 34333 RVA: 0x0010D94C File Offset: 0x0010BB4C
		protected override void OnTrigger()
		{
			base.OnTrigger();
			int type = this.m_Type;
			if (type == 0)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("Trigger by death.", null, null, null, null, null);
				XReviveDocument specificDocument = XDocuments.GetSpecificDocument<XReviveDocument>(XReviveDocument.uuID);
				specificDocument.SetAutoReviveData(this.m_Param0 == 1, 2f);
			}
		}

		// Token: 0x040029CA RID: 10698
		private int m_Type;

		// Token: 0x040029CB RID: 10699
		private int m_Param0;

		// Token: 0x040029CC RID: 10700
		private XEntity m_Entity;
	}
}
