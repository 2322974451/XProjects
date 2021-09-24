using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCommandDirectSys : XBaseCommand
	{

		public override bool Execute()
		{
			base.publicModule();
			return this._execute(this._cmd.param1, this._cmd.param2);
		}

		public override void OnFinish()
		{
			XSingleton<XTutorialMgr>.singleton.Exculsive = false;
			base.OnFinish();
		}

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

		private uint CachedOpenSystem;
	}
}
