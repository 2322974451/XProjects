using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOpposer : XEnemy
	{

		public override bool Initilize(int flag)
		{
			base.Initilize(flag);
			this._eEntity_Type |= XEntity.EnitityType.Entity_Opposer;
			bool flag2 = base.Ator != null;
			if (flag2)
			{
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XMoveComponent.uuID);
			}
			bool flag3 = (flag & XFastEnumIntEqualityComparer<XEntity.InitFlag>.ToInt(XEntity.InitFlag.Entity_Transform)) == 0;
			if (flag3)
			{
				bool flag4 = !XSingleton<XGame>.singleton.SyncMode;
				if (flag4)
				{
					XSingleton<XComponentMgr>.singleton.CreateComponent(this, XManipulationComponent.uuID);
				}
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XChargeComponent.uuID);
				this._buff = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XBuffComponent.uuID) as XBuffComponent);
				this._rotate = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XRotationComponent.uuID) as XRotationComponent);
				this._audio = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XAudioComponent.uuID) as XAudioComponent);
				XSingleton<XComponentMgr>.singleton.CreateComponent(this, XEndureComponent.uuID);
				bool flag5 = XSingleton<XSceneMgr>.singleton.SceneCanNavi(XSingleton<XScene>.singleton.SceneID);
				if (flag5)
				{
					this._nav = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XNavigationComponent.uuID) as XNavigationComponent);
				}
				bool flag6 = !XSingleton<XGame>.singleton.SyncMode;
				if (flag6)
				{
					this._ai = (XSingleton<XComponentMgr>.singleton.CreateComponent(this, XAIComponent.uuID) as XAIComponent);
				}
			}
			return true;
		}
	}
}
