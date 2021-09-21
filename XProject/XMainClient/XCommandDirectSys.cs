using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DA0 RID: 3488
	internal class XCommandDirectSys : XBaseCommand
	{
		// Token: 0x0600BD95 RID: 48533 RVA: 0x002765D4 File Offset: 0x002747D4
		public override bool Execute()
		{
			base.publicModule();
			return this._execute(this._cmd.param1, this._cmd.param2);
		}

		// Token: 0x0600BD96 RID: 48534 RVA: 0x00276609 File Offset: 0x00274809
		public override void OnFinish()
		{
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
			base.OnFinish();
		}

		// Token: 0x0600BD97 RID: 48535 RVA: 0x00276620 File Offset: 0x00274820
		public bool _execute(string param1, string param2)
		{
			this.CachedOpenSystem = uint.Parse(param1);
			XPlayerAttributes xplayerAttributes = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
			bool flag = xplayerAttributes.IsSystemOpened(this.CachedOpenSystem);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = !XSingleton<XTutorialHelper>.singleton.IsSysOpend(this.CachedOpenSystem);
				if (flag2)
				{
					result = false;
				}
				else
				{
					bool flag3 = this.CachedOpenSystem > 0U;
					if (flag3)
					{
						(XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes).ReallyOpenSystem(this.CachedOpenSystem);
						bool flag4 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
						if (flag4)
						{
							DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.OnSysChange((XSysDefine)this.CachedOpenSystem);
							XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState((XSysDefine)this.CachedOpenSystem, true);
						}
						result = true;
					}
					else
					{
						result = false;
					}
				}
			}
			return result;
		}

		// Token: 0x04004D3B RID: 19771
		private uint CachedOpenSystem;
	}
}
