using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBuffTriggerByDeath : XBuffTrigger
	{

		public XBuffTriggerByDeath(XBuff buff) : base(buff)
		{
			this.m_Type = base._GetTriggerParamInt(buff.BuffInfo, 0);
			this.m_Param0 = base._GetTriggerParamInt(buff.BuffInfo, 1);
		}

		public override void OnAdd(XEntity entity, CombatEffectHelper pEffectHelper)
		{
			base.OnAdd(entity, pEffectHelper);
			this.m_Entity = entity;
		}

		public override void OnRealDead(XRealDeadEventArgs e)
		{
			base.Trigger();
		}

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

		private int m_Type;

		private int m_Param0;

		private XEntity m_Entity;
	}
}
