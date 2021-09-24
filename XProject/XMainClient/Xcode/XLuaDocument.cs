

using XUtliPoolLib;

namespace XMainClient
{
    internal class XLuaDocument : XDocComponent
    {
        public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash(nameof(XLuaDocument));

        public override uint ID => XLuaDocument.uuID;

        public override void OnDetachFromHost()
        {
            XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine.hotfixMgr.OnDetachFromHost();
            base.OnDetachFromHost();
        }

        public override void OnAttachToHost(XObject host)
        {
            base.OnAttachToHost(host);
            XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine.hotfixMgr.OnAttachToHost();
        }

        public override void OnLeaveScene()
        {
            XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine.hotfixMgr.OnLeaveScene();
            base.OnLeaveScene();
        }

        public override void OnEnterScene()
        {
            base.OnEnterScene();
            XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine.hotfixMgr.OnEnterScene();
        }

        public override void OnEnterSceneFinally()
        {
            base.OnEnterSceneFinally();
            XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine.hotfixMgr.OnEnterSceneFinally();
        }

        protected override void OnReconnected(XReconnectedEventArgs arg) => XSingleton<XUpdater.XUpdater>.singleton.XLuaEngine.hotfixMgr.OnReconnect();
    }
}
