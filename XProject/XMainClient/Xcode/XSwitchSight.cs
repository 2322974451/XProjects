using System;
using UILib;
using XMainClient.UI;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSwitchSight
	{

		public XSwitchSight(ButtonClickEventHandler eventHandler, IXUIButton Btn25D, IXUIButton Btn3D, IXUIButton Btn3DFree = null)
		{
			this.buttonClick = eventHandler;
			bool flag = Btn3DFree != null;
			if (flag)
			{
				Btn25D.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X25D));
				Btn25D.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSwitchSightClick));
				Btn3D.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X3D));
				Btn3D.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSwitchSightClick));
				Btn3DFree.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X3D_Free));
				Btn3DFree.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSwitchSightClick));
			}
			else
			{
				Btn25D.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X3D));
				Btn25D.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSwitchSightClick));
				Btn3D.ID = (ulong)((long)XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X25D));
				Btn3D.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSwitchSightClick));
			}
		}

		public bool OnSwitchSightClick(IXUIButton sp)
		{
			bool isPlaying = XSingleton<XCutScene>.singleton.IsPlaying;
			bool result;
			if (isPlaying)
			{
				result = false;
			}
			else
			{
				SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData(XSingleton<XScene>.singleton.SceneID);
				bool flag = sceneData != null && sceneData.ShieldSight != null;
				if (flag)
				{
					for (int i = 0; i < sceneData.ShieldSight.Length; i++)
					{
						bool flag2 = (int)sp.ID == (int)sceneData.ShieldSight[i];
						if (flag2)
						{
							XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("OPTION_SHIELD_SIGHT"), "fece00");
							return false;
						}
					}
				}
				XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				bool flag3 = (int)sp.ID != specificDocument.GetValue(XOptionsDefine.OD_VIEW);
				if (flag3)
				{
					specificDocument.SetValue(XOptionsDefine.OD_VIEW, (int)sp.ID, false);
					specificDocument.SetBattleOptionValue();
				}
				this.buttonClick(sp);
				result = true;
			}
			return result;
		}

		private ButtonClickEventHandler buttonClick;
	}
}
