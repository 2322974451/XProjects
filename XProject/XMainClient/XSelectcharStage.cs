// Decompiled with JetBrains decompiler
// Type: XMainClient.XSelectcharStage
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XSelectcharStage : XCharStage
    {
        private uint _token2 = 0;
        private uint _token3 = 0;
        private float _turn_interval = 3f;
        private float _turn_update = 0.0f;
        private bool _character_show = false;

        public XSelectcharStage()
          : base(EXStage.SelectChar)
        {
            this._turn_interval = XSingleton<XGlobalConfig>.singleton.ProShowTurnInterval;
            this._turn_update = 0.0f;
        }

        public override void OnEnterStage(EXStage eOld)
        {
            base.OnEnterStage(eOld);
            CombineMeshTask.s_CombineMatType = ECombineMatType.EIndependent;
            XSingleton<XResourceLoaderMgr>.singleton.DelayLoad = false;
            if (this._eStage != eOld)
                this._auto_enter = false;
            this._character_show = false;
            this._prelusive = true;
            if (eOld == EXStage.Login)
            {
                XSingleton<XCutScene>.singleton.Start("CutScene/first2second_slash_show", false);
                this._token2 = XSingleton<XTimerMgr>.singleton.SetTimer(XSingleton<XCutScene>.singleton.Length, new XTimerMgr.ElapsedEventHandler(this.PresentDone), (object)null);
            }
            else
            {
                this.ReLogined();
                XSingleton<XTutorialMgr>.singleton.Uninit();
            }
            XSingleton<XClientNetwork>.singleton.XLoginStep = XLoginStep.EnterGame;
        }

        public override void OnLeaveStage(EXStage eNew)
        {
            base.OnLeaveStage(eNew);
            this._character_show = false;
            XSingleton<XTimerMgr>.singleton.KillTimer(this._token2);
            XSingleton<XTimerMgr>.singleton.KillTimer(this._token3);
            CombineMeshTask.s_CombineMatType = ECombineMatType.ECombined;
            XSingleton<XResourceLoaderMgr>.singleton.DelayLoad = true;
        }

        public void ReLogined()
        {
            this._auto_enter = false;
            this._cur_tag = 0;
            DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.SwitchProfession(-1);
            XSingleton<XCutScene>.singleton.Start("CutScene/second_slash_show", false);
            XSingleton<XLoginDocument>.singleton.ShowSelectCharGerenalUI();
            this._prelusive = false;
        }

        public static void ShowBillboard(XDummy dummy)
        {
            int result = -1;
            int.TryParse(dummy.EngineObject.Tag, out result);
            if (result < 0 || result - 1 >= XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo.Count)
            {
                XSingleton<XDebug>.singleton.AddErrorLog("Character tag ", dummy.EngineObject.Tag, " exceeded server PlayerBriefInfo count.");
            }
            else
            {
                RoleBriefInfo roleBriefInfo = XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo[result - 1];
                if (roleBriefInfo == null)
                    return;
                XSingleton<XGameUI>.singleton.HpbarRoot.gameObject.SetActive(true);
                XSingleton<XGameUI>.singleton.NpcHpbarRoot.gameObject.SetActive(true);
                if (dummy.BillBoard == null)
                {
                    dummy.BillBoard = XSingleton<XComponentMgr>.singleton.CreateComponent((XObject)dummy, XBillboardComponent.uuID) as XBillboardComponent;
                    dummy.BillBoard.AttachDummyBillboard(roleBriefInfo.name, roleBriefInfo.level, (int)roleBriefInfo.type % 10);
                }
                else
                    dummy.BillBoard.AttachDummyBillboard(roleBriefInfo.name, roleBriefInfo.level, (int)roleBriefInfo.type % 10);
                dummy.BillBoard.SetSelectCharStageScale();
            }
        }

        public override void Update(float fDeltaT)
        {
            base.Update(fDeltaT);
            this._turn_update = this._character_show ? this._turn_update + fDeltaT : 0.0f;
            if (!this._prelusive)
            {
                if ((double)this._turn_update > (double)this._turn_interval)
                    this.ShowCharacterTurn(this._cur_tag);
                else if (XSingleton<XGesture>.singleton.OneTouch)
                {
                    Ray ray = XSingleton<XScene>.singleton.GameCamera.UnityCamera.ScreenPointToRay(XSingleton<XGesture>.singleton.TouchPosition);
                    int layerMask = 1 << LayerMask.NameToLayer("Dummy");
                    RaycastHit hitInfo;
                    if (Physics.SphereCast(ray, 0.1f, out hitInfo, float.PositiveInfinity, layerMask))
                    {
                        int tag = int.Parse(hitInfo.collider.tag);
                        if (this._cur_tag == tag)
                            this.ShowCharacterTurn(this._cur_tag);
                        else
                            this.ShowCharacter(tag);
                    }
                }
            }
            if (!this._prelusive)
                return;
            this._character_show = false;
        }

        public override void Play()
        {
            XAutoFade.FadeOut2In(0.5f, 0.5f);
            int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.EnterFinally), (object)null);
        }

        public void EnterGameWorld(int index)
        {
            XSingleton<XLoginDocument>.singleton.SetBlockUIVisable(true);
            XSingleton<XLoginDocument>.singleton.EnterWorld(index);
        }

        protected void EnterFinally(object o) => XSingleton<XScene>.singleton.SceneEnterTo(false);

        protected void PresentDone(object o)
        {
            XSingleton<XCutScene>.singleton.Start("CutScene/second_slash_show", false);
            if (this._auto_enter)
            {
                this.ShowCharacter(XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.SelectedSlot);
            }
            else
            {
                this._token3 = XSingleton<XTimerMgr>.singleton.SetTimer(0.433f, new XTimerMgr.ElapsedEventHandler(this.FirstShow), (object)XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.SelectedSlot);
                XSingleton<XLoginDocument>.singleton.ShowSelectCharGerenalUI();
                this._prelusive = false;
            }
        }

        protected void FirstShow(object o) => this.ShowCharacter((int)o);

        protected override void PrelusiveDone()
        {
            if (this._cur_tag == 0)
                return;
            DlgBase<XSelectCharView, SelectCharWindowBehaviour>.singleton.SelectCharIndex = this._cur_tag;
            if (this._auto_enter)
            {
                this.EnterGameWorld(this._cur_tag);
            }
            else
            {
                this._prelusive = false;
                if (this._cur_tag - 1 >= XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo.Count)
                {
                    XSingleton<XDebug>.singleton.AddErrorLog("Character tag ", this._cur_tag.ToString(), " exceeded server PlayerBriefInfo count.");
                }
                else
                {
                    if (XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo[this._cur_tag - 1] == null)
                        XSingleton<XLoginDocument>.singleton.ShowSelectCharCreatedUI();
                    else
                        XSingleton<XLoginDocument>.singleton.ShowSelectCharSelectedUI(XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo[this._cur_tag - 1].name, XSingleton<XAttributeMgr>.singleton.XPlayerCharacters.PlayerBriefInfo[this._cur_tag - 1].level);
                    XSingleton<XCutScene>.singleton.Start("CutScene/character_show" + XCharStage.role_type[this._cur_tag], false);
                    this._character_show = true;
                }
            }
        }
    }
}
