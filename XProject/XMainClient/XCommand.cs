// Decompiled with JetBrains decompiler
// Type: XMainClient.XCommand
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.Battle;
using XMainClient.UI.UICommon;
using XUpdater;
using XUtliPoolLib;

namespace XMainClient
{
    public class XCommand : XSingleton<XCommand>
    {
        private GameObject terrain = (GameObject)null;
        private uint _timeToken;
        private uint NpcID = 97;

        public bool ProcessCommand(string command)
        {
            string[] strArray1 = command.Split(' ');
            string str1 = strArray1[0];
            bool flag = true;
            switch (str1)
            {
                case "AddMaquee":
                    int result1 = 0;
                    int.TryParse(strArray1[1], out result1);
                    for (int index = 0; index < result1; ++index)
                        DlgBase<XChatMaqueeView, XChatMaqueeBehaviour>.singleton.AddMaqueeNormalInfo(strArray1[2], 0.0f);
                    break;
                case "IgnoreServerOpenDay":
                    XDocuments.GetSpecificDocument<XActivityDocument>(XActivityDocument.uuID).ServerOpenDay = 1000;
                    break;
                case "TopTask":
                    if (strArray1.Length >= 2)
                    {
                        XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID).SetHighestPriorityTask(uint.Parse(strArray1[1]));
                        break;
                    }
                    break;
                case "addblack":
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_AddBlackListNew()
                    {
                        oArg = {
              otherroleid = ulong.Parse(strArray1[1])
            }
                    });
                    break;
                case "addfriend":
                    ulong num1 = ulong.Parse(strArray1[1]);
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_AddFriendNew()
                    {
                        oArg = {
              friendroleid = num1
            }
                    });
                    break;
                case "airuntime":
                    XAIComponent.UseRunTime = (uint)int.Parse(strArray1[1]) > 0U;
                    XSingleton<XResourceLoaderMgr>.singleton.DelayLoad = XAIComponent.UseRunTime;
                    break;
                case "aitree":
                    XRole role1 = XSingleton<XEntityMgr>.singleton.CreateRole((XAttributes)XSingleton<XAttributeMgr>.singleton.XPlayerData, XSingleton<XEntityMgr>.singleton.Player.MoveObj.Position, Quaternion.identity, false);
                    XSingleton<XEntityMgr>.singleton.CreateMount(12014U, (XEntity)role1, true);
                    XRole role2 = XSingleton<XEntityMgr>.singleton.CreateRole((XAttributes)XSingleton<XAttributeMgr>.singleton.XPlayerData, XSingleton<XEntityMgr>.singleton.Player.MoveObj.Position, Quaternion.identity, false);
                    XSingleton<XDebug>.singleton.AddLog(role1.Mount.MountCopilot((XEntity)role2).ToString());
                    string tree = XSingleton<XGlobalConfig>.singleton.GetValue("WeddingPatrolAITree");
                    if (role1.AI == null)
                    {
                        role1.AI = XSingleton<XComponentMgr>.singleton.CreateComponent((XObject)role1, XAIComponent.uuID) as XAIComponent;
                        role1.AI.InitVariables();
                        role1.AI.SetFixVariables();
                    }
                    if (role1.Nav == null)
                    {
                        role1.Nav = XSingleton<XComponentMgr>.singleton.CreateComponent((XObject)role1, XNavigationComponent.uuID) as XNavigationComponent;
                        role1.Nav.Active();
                    }
                    role1.AI.Patrol.InitNavPath(XSingleton<XGlobalConfig>.singleton.GetValue("WeddingPatrolPath"), XPatrol.PathType.PT_NORMAL);
                    role1.AI.SetBehaviorTree(tree);
                    break;
                case "allpk":
                    DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_CustomBattle_BountyMode);
                    break;
                case "allskill":
                    if ((int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetSkillPointCount() < 300)
                    {
                        this.ProcessCommand("item 2 800");
                        this.ProcessCommand("item 5 800");
                    }
                    this.SkillLearn();
                    break;
                case "anim":
                    XAnimator.debug = !XAnimator.debug;
                    break;
                case "attr":
                    if (!XSingleton<XGame>.singleton.SyncMode)
                    {
                        if (strArray1.Length >= 3)
                        {
                            int num2 = int.Parse(strArray1[1]);
                            int num3 = int.Parse(strArray1[2]);
                            XEntity xentity = strArray1.Length != 3 ? XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(strArray1[3])) : (XEntity)XSingleton<XEntityMgr>.singleton.Player;
                            if (xentity != null)
                            {
                                XAttrChangeEventArgs xattrChangeEventArgs = new XAttrChangeEventArgs();
                                xattrChangeEventArgs.AttrKey = (XAttributeDefine)num2;
                                xattrChangeEventArgs.DeltaValue = (double)num3;
                                xattrChangeEventArgs.Firer = (XObject)xentity;
                                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xattrChangeEventArgs);
                            }
                            break;
                        }
                        break;
                    }
                    goto default;
                case "authinvalid":
                    XSingleton<XLoginDocument>.singleton.OnAuthorizationSignOut("test");
                    break;
                case "battleqte":
                    DlgBase<BattleQTEDlg, BattleQTEDlgBehaviour>.singleton.SetStatus(QteUIType.Abnormal, true);
                    break;
                case "blackwhite":
                    XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.BlackWhite, true);
                    break;
                case "boon":
                    DlgBase<XGuildBoonView, XGuildBoonBehaviour>.singleton.SetVisible(true, true);
                    break;
                case "bubble":
                    XBubbleEventArgs xbubbleEventArgs = XEventPool<XBubbleEventArgs>.GetEvent();
                    if (strArray1.Length >= 2)
                        xbubbleEventArgs.bubbletext = strArray1[1];
                    if (strArray1.Length >= 3)
                        xbubbleEventArgs.existtime = float.Parse(strArray1[2]);
                    if (strArray1.Length >= 4)
                    {
                        xbubbleEventArgs.Firer = (XObject)XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(strArray1[3]));
                        xbubbleEventArgs.speaker = XSingleton<XEntityMgr>.singleton.GetEntity(ulong.Parse(strArray1[3])).Name;
                    }
                    else
                    {
                        xbubbleEventArgs.Firer = (XObject)XSingleton<XEntityMgr>.singleton.Player;
                        xbubbleEventArgs.speaker = XSingleton<XEntityMgr>.singleton.Player.Name;
                    }
                    if (!(xbubbleEventArgs.Firer.GetXComponent(XBubbleComponent.uuID) is XBubbleComponent))
                        XSingleton<XComponentMgr>.singleton.CreateComponent(xbubbleEventArgs.Firer, XBubbleComponent.uuID);
                    XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xbubbleEventArgs);
                    break;
                case "buff":
                    if (!XSingleton<XGame>.singleton.SyncMode)
                    {
                        XBuffAddEventArgs xbuffAddEventArgs = XEventPool<XBuffAddEventArgs>.GetEvent();
                        if (strArray1.Length >= 3)
                        {
                            xbuffAddEventArgs.xBuffDesc.BuffID = int.Parse(strArray1[1]);
                            xbuffAddEventArgs.xBuffDesc.BuffLevel = int.Parse(strArray1[2]);
                            xbuffAddEventArgs.xBuffDesc.CasterID = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
                            ulong id;
                            if (strArray1.Length >= 4)
                            {
                                if (strArray1[3].StartsWith("t"))
                                {
                                    xbuffAddEventArgs.xBuffDesc.EffectTime = float.Parse(strArray1[3].Substring(1));
                                    id = strArray1.Length < 5 ? XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID : ulong.Parse(strArray1[4]);
                                }
                                else
                                    id = ulong.Parse(strArray1[3]);
                            }
                            else
                                id = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
                            XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(id);
                            if (entity != null)
                            {
                                xbuffAddEventArgs.Firer = (XObject)entity;
                                XSingleton<XEventMgr>.singleton.FireEvent((XEventArgs)xbuffAddEventArgs);
                                xbuffAddEventArgs = (XBuffAddEventArgs)null;
                            }
                        }
                        if (xbuffAddEventArgs != null)
                        {
                            xbuffAddEventArgs.Recycle();
                            break;
                        }
                        break;
                    }
                    goto default;
                case "buildlog":
                    XSingleton<XGame>.singleton.ShowBuildLog = !XSingleton<XGame>.singleton.ShowBuildLog;
                    break;
                case "bundlelog":
                    AssetBundleManager.enableLog = !AssetBundleManager.enableLog;
                    XFileLog._logBundleOpen = !XFileLog._logBundleOpen;
                    break;
                case "buy":
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_BuyGoldAndFatigue()
                    {
                        oArg = {
              fatigueID = uint.Parse(strArray1[1])
            }
                    });
                    break;
                case "capture":
                    XSingleton<UiUtility>.singleton.PandoraPicShare("", "", "UIRoot(Clone)/OperatingActivityDlg(Clone)/Bg/Right");
                    break;
                case "changepro":
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_ChangeProfession()
                    {
                        oArg = {
              pro = uint.Parse(strArray1[1])
            }
                    });
                    break;
                case "chat":
                    ulong num4 = ulong.Parse(strArray1[1]);
                    string str2 = strArray1[2];
                    RpcC2M_chat rpcC2MChat = new RpcC2M_chat()
                    {
                        oArg = {
              chatinfo = new KKSG.ChatInfo()
            }
                    };
                    rpcC2MChat.oArg.chatinfo.channel = 3U;
                    rpcC2MChat.oArg.chatinfo.info = str2;
                    rpcC2MChat.oArg.chatinfo.dest = new ChatDest();
                    rpcC2MChat.oArg.chatinfo.dest.roleid.Add(num4);
                    for (int index = 0; index < 20; ++index)
                        XSingleton<XClientNetwork>.singleton.Send((Rpc)rpcC2MChat);
                    break;
                case "cinfo":
                    XFileLog._OpenCustomBtn = !XFileLog._OpenCustomBtn;
                    break;
                case "clearguildcollectCD":
                    XDocuments.GetSpecificDocument<XGuildCollectDocument>(XGuildCollectDocument.uuID).LotteryCDInfo.Clear();
                    break;
                case "clientaddpk":
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_PkReqC2M()
                    {
                        oArg = {
              type = PkReqType.PKREQ_ADDPK
            }
                    });
                    break;
                case "close":
                    XSingleton<XClientNetwork>.singleton.Close();
                    break;
                case "compose":
                    if (strArray1.Length > 1)
                    {
                        XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_UseItem()
                        {
                            oArg = {
                uid = (ulong) uint.Parse(strArray1[1]),
                count = 1U,
                OpType = ItemUseMgr.GetItemUseValue(ItemUse.Composite)
              }
                        });
                        break;
                    }
                    break;
                case "comps":
                    XSingleton<XComponentMgr>.singleton.PrintAllComponent();
                    break;
                case "custombattle":
                    uint result2 = 0;
                    ulong result3 = 0;
                    uint result4 = 0;
                    if (strArray1.Length > 1)
                        uint.TryParse(strArray1[1], out result2);
                    RpcC2M_CustomBattleOp c2MCustomBattleOp = new RpcC2M_CustomBattleOp();
                    c2MCustomBattleOp.oArg.op = (CustomBattleOp)result2;
                    if (strArray1.Length > 2)
                        ulong.TryParse(strArray1[2], out result3);
                    if (c2MCustomBattleOp.oArg.op == CustomBattleOp.CustomBattle_Create && strArray1.Length > 2)
                        uint.TryParse(strArray1[2], out result4);
                    c2MCustomBattleOp.oArg.uid = result3;
                    c2MCustomBattleOp.oArg.config = new CustomBattleConfig();
                    c2MCustomBattleOp.oArg.config.configid = result4;
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)c2MCustomBattleOp);
                    break;
                case "damage":
                    if (!XSingleton<XGame>.singleton.SyncMode)
                    {
                        if (strArray1.Length >= 2)
                        {
                            if (strArray1[1] == "start")
                            {
                                float num5 = 0.0f;
                                if (strArray1.Length >= 3)
                                    num5 = float.Parse(strArray1[2]);
                                XSingleton<XAttributeMgr>.singleton.XPlayerData.TogglePrintDamage(true);
                            }
                            else if (strArray1[1] == "end")
                                XSingleton<XAttributeMgr>.singleton.XPlayerData.TogglePrintDamage(false);
                            break;
                        }
                        break;
                    }
                    goto default;
                case "death":
                    XSingleton<XEntityMgr>.singleton.Player.Attributes.ForceDeath();
                    break;
                case "enable":
                    if (strArray1.Length >= 3)
                    {
                        int num6 = int.Parse(strArray1[1]);
                        int num7 = int.Parse(strArray1[2]);
                        switch (num6)
                        {
                            case 1:
                                XFxMgr.EmptyFx = (uint)num7 > 0U;
                                break;
                            case 2:
                                XSingleton<XAudioMgr>.singleton.hasSound = (uint)num7 > 0U;
                                break;
                            case 3:
                                XStateMachine._EnableAtor = (uint)num7 > 0U;
                                break;
                            case 4:
                                if ((uint)num7 > 0U)
                                {
                                    XSingleton<XScene>.singleton.GameCamera.SetReplaceCameraShader(ShaderManager._color);
                                    break;
                                }
                                XSingleton<XScene>.singleton.GameCamera.SetReplaceCameraShader((Shader)null);
                                break;
                        }
                        break;
                    }
                    break;
                case "equipall":
                    XSingleton<XGame>.singleton.Doc.XBagDoc.GetAllEquip();
                    break;
                case "free3g":
                    XDocuments.GetSpecificDocument<AdditionRemindDocument>(AdditionRemindDocument.uuID).gm_is_3g = true;
                    break;
                case "freetime":
                    int num8 = int.Parse(strArray1[1]);
                    XDocuments.GetSpecificDocument<AdditionRemindDocument>(AdditionRemindDocument.uuID).LOGINTIME = num8;
                    break;
                case "gausblur":
                    XSingleton<XPostEffectMgr>.singleton.MakeEffectEnable(XPostEffect.GausBlur, true);
                    break;
                case "generatefiles":
                    int result5 = 0;
                    int.TryParse(strArray1[1], out result5);
                    XSingleton<XChatIFlyMgr>.singleton.GenerateAudioFiles(result5);
                    break;
                case "getappearance":
                    ulong num9 = ulong.Parse(strArray1[1]);
                    int num10 = int.Parse(strArray1[2]);
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_GetUnitAppearanceNew()
                    {
                        oArg = {
              roleid = num9,
              mask = num10
            }
                    });
                    break;
                case "getdesall":
                    XDesignationDocument specificDocument = XDocuments.GetSpecificDocument<XDesignationDocument>(XDesignationDocument.uuID);
                    for (int index = 1; index < specificDocument._DesignationTable.Table.Length; ++index)
                        XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_GMCommand()
                        {
                            oArg = {
                cmd = string.Format("getdesignation {0}", (object) specificDocument._DesignationTable.Table[index].ID)
              }
                        });
                    flag = true;
                    break;
                case "getwindow":
                    string str3 = strArray1[1];
                    string childName = strArray1[2];
                    GameObject gameObject1 = GameObject.Find("UIRoot/" + str3 + "(Clone)");
                    if ((UnityEngine.Object)gameObject1 == (UnityEngine.Object)null)
                    {
                        DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage("dlg not found!");
                        return true;
                    }
                    Transform child = XSingleton<UiUtility>.singleton.FindChild(gameObject1.transform, childName);
                    if ((UnityEngine.Object)child == (UnityEngine.Object)null)
                    {
                        DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage("window not found!");
                        return true;
                    }
                    DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage("target window position: (" + (object)child.localPosition.x + "," + (object)child.localPosition.y + "," + (object)child.localPosition.z + ")");
                    if (child.GetComponent("XUISprite") is IXUISprite component2)
                    {
                        DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage("target window size: " + (object)component2.spriteWidth + "x" + (object)component2.spriteHeight);
                        break;
                    }
                    break;
                case "god":
                case "niube":
                    string[] strArray2 = new string[8]
                    {
            "level 55",
            "openallsystem",
            "star",
            "task finishall",
            "item 1 900000",
            "item 7 900000",
            "item 9997 1",
            "tutorialendall"
                    };
                    foreach (string command1 in strArray2)
                        this.ProcessCommand(command1);
                    break;
                case "guildcollectitem":
                    for (int index = 8000; index < 8016; ++index)
                        this.ProcessCommand(string.Format("item {0} 20", (object)index));
                    break;
                case "guilddragon":
                    DlgBase<XGuildDragonView, XGuildDragonBehaviour>.singleton.ShowGuildBossView();
                    break;
                case "guildencourage":
                    uint result6 = 0;
                    int result7 = 1;
                    if (strArray1.Length > 1)
                        uint.TryParse(strArray1[1], out result6);
                    if (strArray1.Length > 2)
                        int.TryParse(strArray1[2], out result7);
                    for (int index = 0; index < result7; ++index)
                        XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_WorldBossGuildAddAttr()
                        {
                            oArg = {
                count = result6
              }
                        });
                    break;
                case "guildhall":
                    DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XGuildHallView, XGuildHallBehaviour>.OnAnimationOver)null);
                    break;
                case "gyro":
                    float result8 = 0.0f;
                    float result9 = 0.0f;
                    float result10 = 0.0f;
                    if (strArray1.Length > 1)
                        float.TryParse(strArray1[1], out result8);
                    if (strArray1.Length > 2)
                        float.TryParse(strArray1[2], out result9);
                    if (strArray1.Length > 3)
                        float.TryParse(strArray1[3], out result10);
                    if ((double)result8 == 0.0)
                        result8 = XSingleton<XGyroscope>.singleton.Scale;
                    if ((double)result9 == 0.0)
                        result9 = XSingleton<XGyroscope>.singleton.DeadZone;
                    if ((double)result10 == 0.0)
                        result10 = XSingleton<XGyroscope>.singleton.Frequency;
                    XSingleton<XGyroscope>.singleton.Set(result8, result10, result9);
                    break;
                case "gyrooff":
                    XSingleton<XGyroscope>.singleton.Enabled = false;
                    break;
                case "gyroon":
                    XSingleton<XGyroscope>.singleton.Enabled = true;
                    break;
                case "hailong":
                    List<string> stringList = new List<string>()
          {
            "item 85 100",
            "item 40607 1",
            "item 40608 1",
            "item 40609 1",
            "item 2503001 1",
            "item 2503002 1",
            "item 2503003 1",
            "item 2503004 1",
            "item 2503011 1",
            "item 2503012 1",
            "item 2503013 1",
            "item 2503021 1",
            "item 2503022 1",
            "item 2503031 1",
            "item 2503032 1",
            "item 1000106 10",
            "item 1000206 10",
            "item 1000306 10",
            "item 1000406 10",
            "item 1001106 10",
            "item 1002106 10",
            "item 1003106 10",
            "item 7 100000000"
          };
                    switch (XSingleton<XEntityMgr>.singleton.Player.TypeID % 10U)
                    {
                        case 1:
                            stringList.Add("item 140600 1");
                            stringList.Add("item 140601 1");
                            stringList.Add("item 140602 1");
                            stringList.Add("item 140603 1");
                            stringList.Add("item 140604 1");
                            stringList.Add("item 140605 1");
                            stringList.Add("item 140606 1");
                            break;
                        case 2:
                            stringList.Add("item 240600 1");
                            stringList.Add("item 240601 1");
                            stringList.Add("item 240602 1");
                            stringList.Add("item 240603 1");
                            stringList.Add("item 240604 1");
                            stringList.Add("item 240605 1");
                            stringList.Add("item 240606 1");
                            break;
                        case 3:
                            stringList.Add("item 340600 1");
                            stringList.Add("item 340601 1");
                            stringList.Add("item 340602 1");
                            stringList.Add("item 340603 1");
                            stringList.Add("item 340604 1");
                            stringList.Add("item 340605 1");
                            stringList.Add("item 340606 1");
                            break;
                        case 4:
                            stringList.Add("item 440600 1");
                            stringList.Add("item 440601 1");
                            stringList.Add("item 440602 1");
                            stringList.Add("item 440603 1");
                            stringList.Add("item 440604 1");
                            stringList.Add("item 440605 1");
                            stringList.Add("item 440606 1");
                            break;
                        case 5:
                            stringList.Add("item 540600 1");
                            stringList.Add("item 540601 1");
                            stringList.Add("item 540602 1");
                            stringList.Add("item 540603 1");
                            stringList.Add("item 540604 1");
                            stringList.Add("item 540605 1");
                            stringList.Add("item 540606 1");
                            break;
                    }
                    using (List<string>.Enumerator enumerator = stringList.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                            this.ProcessCommand(enumerator.Current);
                        break;
                    }
                case "hide":
                    if (strArray1.Length > 1)
                    {
                        GameObject[] objectsOfTypeAll = (GameObject[])Resources.FindObjectsOfTypeAll(typeof(GameObject));
                        for (int index = 0; index < objectsOfTypeAll.Length; ++index)
                        {
                            if (objectsOfTypeAll[index].name == strArray1[1])
                                objectsOfTypeAll[index].SetActive(!objectsOfTypeAll[index].activeSelf);
                        }
                        break;
                    }
                    break;
                case "hideT":
                    if (strArray1.Length == 2)
                    {
                        int num11 = int.Parse(strArray1[1]);
                        GameObject gameObject2 = GameObject.Find("Scene/Terrain");
                        if ((UnityEngine.Object)gameObject2 != (UnityEngine.Object)null)
                            this.terrain = gameObject2;
                        if ((UnityEngine.Object)this.terrain != (UnityEngine.Object)null)
                            this.terrain.SetActive(num11 > 0);
                        break;
                    }
                    break;
                case "hud":
                    XHUDComponent.processHud = !XHUDComponent.processHud;
                    break;
                case "hudnum":
                    XHUDComponent._Max_UI_UpdateCount_PreFrame = int.Parse(strArray1[1]);
                    break;
                case "inquirylevelseal":
                    DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage(XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID).SealType.ToString());
                    break;
                case "inquirytutorial":
                    int num12 = 0;
                    int num13 = 10;
                    StringBuilder stringBuilder1 = new StringBuilder();
                    StringBuilder stringBuilder2 = stringBuilder1;
                    string str4 = (num12 + 1).ToString("000");
                    int num14 = num12 + num13;
                    string str5 = num14.ToString("000");
                    string str6 = str4 + "-" + str5 + ": ";
                    stringBuilder2.Append(str6);
                    for (int index1 = 0; index1 < XSingleton<XTutorialMgr>.singleton.TutorialBitsArray.Length; ++index1)
                    {
                        byte tutorialBits = XSingleton<XTutorialMgr>.singleton.TutorialBitsArray[index1];
                        for (int index2 = 0; index2 < 8; ++index2)
                        {
                            if (((int)tutorialBits & 1 << index2) == 0)
                                stringBuilder1.Append("0");
                            else
                                stringBuilder1.Append("1");
                            ++num12;
                            if (num12 % num13 == 0)
                            {
                                DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage(stringBuilder1.ToString());
                                stringBuilder1 = new StringBuilder();
                                StringBuilder stringBuilder3 = stringBuilder1;
                                num14 = num12 + 1;
                                string str7 = num14.ToString("000");
                                num14 = num12 + num13;
                                string str8 = num14.ToString("000");
                                string str9 = str7 + " " + str8 + ":";
                                stringBuilder3.Append(str9);
                            }
                        }
                    }
                    if ((uint)(num12 % num13) > 0U)
                    {
                        DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage(stringBuilder1.ToString());
                        break;
                    }
                    break;
                case "invite":
                    if (strArray1.Length >= 2)
                    {
                        ulong[] numArray = (ulong[])null;
                        if (strArray1.Length >= 3)
                        {
                            numArray = new ulong[strArray1.Length - 2];
                            for (int index = 2; index < strArray1.Length; ++index)
                                numArray[index - 2] = ulong.Parse(strArray1[index]);
                        }
                        XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID).SendOpenSysInvitation((XSysDefine)int.Parse(strArray1[1]), numArray);
                        break;
                    }
                    break;
                case "killclientall":
                    if (strArray1.Length > 1)
                    {
                        XSingleton<XAIOtherActions>.singleton.TickKillAll((object)strArray1[1]);
                        break;
                    }
                    XSingleton<XLevelSpawnMgr>.singleton.KillAllMonster();
                    break;
                case "kiss":
                    XSingleton<XCutScene>.singleton.Start("CutScene/argent_kiss");
                    break;
                case "levelover":
                    XSingleton<XScene>.singleton.ReqLeaveScene();
                    break;
                case "levelslot":
                    if (strArray1.Length == 3)
                    {
                        XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_LevelUpSlotAttr()
                        {
                            oArg = {
                slot = uint.Parse(strArray1[1]),
                count = uint.Parse(strArray1[2])
              }
                        });
                        break;
                    }
                    break;
                case "listattr":
                    if (!XSingleton<XGame>.singleton.SyncMode)
                    {
                        if (strArray1.Length >= 2)
                        {
                            ulong roleId = ulong.Parse(strArray1[1]);
                            if (roleId == 0UL)
                                roleId = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
                            XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roleId);
                            if (entity != null && entity.Attributes != null)
                            {
                                List<int> intList = ListPool<int>.Get();
                                for (int index = 2; index < strArray1.Length; ++index)
                                    intList.Add(int.Parse(strArray1[index]));
                                if (intList.Count == 0)
                                {
                                    for (int index = 1; index < XAttributeCommon.AttrCount; ++index)
                                    {
                                        intList.Add(index);
                                        intList.Add(index + XAttributeCommon.PercentStart);
                                        intList.Add(index + XAttributeCommon.TotalStart);
                                    }
                                }
                                XSingleton<XCommon>.singleton.CleanStringCombine();
                                StringBuilder sharedStringBuilder = XSingleton<XCommon>.singleton.GetSharedStringBuilder();
                                for (int index = 0; index < intList.Count; ++index)
                                {
                                    double attr = entity.Attributes.GetAttr((XAttributeDefine)intList[index]);
                                    if (Math.Abs(attr) >= 0.0001)
                                        sharedStringBuilder.Append("[").Append(intList[index]).Append(": ").Append(attr.ToString("F2")).Append("]\n");
                                }
                                DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage(sharedStringBuilder.ToString());
                            }
                            break;
                        }
                        break;
                    }
                    goto default;
                case "listbuff":
                    if (!XSingleton<XGame>.singleton.SyncMode)
                    {
                        XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(strArray1.Length < 2 ? XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID : ulong.Parse(strArray1[1]));
                        if (entity != null && entity.Buffs != null)
                        {
                            XSingleton<XCommon>.singleton.CleanStringCombine();
                            StringBuilder sharedStringBuilder = XSingleton<XCommon>.singleton.GetSharedStringBuilder();
                            List<XBuff> buffList = entity.Buffs.BuffList;
                            for (int index = 0; index < buffList.Count; ++index)
                                sharedStringBuilder.Append("[").Append(buffList[index].ID).Append(":").Append(buffList[index].Level).Append("]");
                            DlgBase<DemoUI, DemoUIBehaviour>.singleton.AddMessage(sharedStringBuilder.ToString());
                            break;
                        }
                        break;
                    }
                    goto default;
                case "mob":
                    XSingleton<XEntityMgr>.singleton.CreateEntity(uint.Parse(strArray1[1]), XSingleton<XEntityMgr>.singleton.Player.EngineObject.Position, Quaternion.Euler(0.0f, 0.0f, 0.0f), true);
                    break;
                case "mzj":
                    DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.Show(XSysDefine.XSys_CampDuel, true);
                    break;
                case "mzj0":
                    XSingleton<XInput>.singleton.LastNpc = (XEntity)XSingleton<XEntityMgr>.singleton.GetNpc(165U);
                    break;
                case "mzj1":
                    XSingleton<XInput>.singleton.LastNpc = (XEntity)XSingleton<XEntityMgr>.singleton.GetNpc(17U);
                    break;
                case "mzj2":
                    XCampDuelDocument.Doc.campID = 2;
                    break;
                case "notice":
                    if (strArray1.Length >= 2)
                    {
                        ulong[] numArray = (ulong[])null;
                        if (strArray1.Length >= 3)
                        {
                            numArray = new ulong[strArray1.Length - 2];
                            for (int index = 2; index < strArray1.Length; ++index)
                                numArray[index - 2] = ulong.Parse(strArray1[index]);
                        }
                        XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID).SendOpenSysInvitation((NoticeType)int.Parse(strArray1[1]), numArray);
                        break;
                    }
                    break;
                case "officialversionserver":
                    if (File.Exists(Path.Combine(Application.persistentDataPath, "TEST_VERSION")))
                    {
                        File.Delete(Path.Combine(Application.persistentDataPath, "TEST_VERSION"));
                        break;
                    }
                    break;
                case "openfc":
                    DlgBase<ProfessionChangeDlg, ProfessionChangeBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<ProfessionChangeDlg, ProfessionChangeBehaviour>.OnAnimationOver)null);
                    break;
                case "opengamezone":
                    if (DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible())
                    {
                        DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.uiBehaviour.GetSysButton(XSysDefine.XSys_GameCommunity).SetVisible(true);
                        DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.uiBehaviour.m_SysListV2.Refresh();
                        break;
                    }
                    break;
                case "openurl":
                    if (strArray1.Length > 1)
                    {
                        Application.OpenURL(strArray1[1]);
                        break;
                    }
                    break;
                case "pandora":
                    XSingleton<XPandoraSDKDocument>.singleton.PandoraOnJsonEvent(strArray1[1]);
                    break;
                case "print":
                    XSingleton<XDebug>.singleton.Print();
                    break;
                case "queryrolestate":
                    PtcC2M_RoleStateReportNew roleStateReportNew = new PtcC2M_RoleStateReportNew();
                    for (int index = 0; index < strArray1.Length; ++index)
                        roleStateReportNew.Data.roleid.Add(ulong.Parse(strArray1[index]));
                    XSingleton<XClientNetwork>.singleton.Send((Protocol)roleStateReportNew);
                    break;
                case "quit":
                    Application.Quit();
                    break;
                case "randomfriend":
                    string str10 = strArray1[1];
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_RandomFriendWaitListNew()
                    {
                        oArg = {
              match = str10
            }
                    });
                    break;
                case "reconnect":
                    XSingleton<XClientNetwork>.singleton.XConnect.ReconnectionEnabled = true;
                    break;
                case "record":
                    int num15 = int.Parse(strArray1[1]);
                    XDebug.RecordChannel channel = (XDebug.RecordChannel)int.Parse(strArray1[2]);
                    switch (num15)
                    {
                        case 0:
                            XSingleton<XDebug>.singleton.EndRecord();
                            break;
                        case 1:
                            XSingleton<XDebug>.singleton.StartRecord(channel);
                            break;
                        case 2:
                            XSingleton<XDebug>.singleton.ClearRecord();
                            break;
                    }
                    break;
                case "removeblack":
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_RemoveBlackListNew()
                    {
                        oArg = {
              otherroleid = ulong.Parse(strArray1[1])
            }
                    });
                    break;
                case "removefiles":
                    XSingleton<XChatIFlyMgr>.singleton.ClearAudioCache();
                    break;
                case "removefriend":
                    ulong num16 = ulong.Parse(strArray1[1]);
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_RemoveFriendNew()
                    {
                        oArg = {
              friendroleid = num16
            }
                    });
                    break;
                case "sendflower":
                    ulong num17 = ulong.Parse(strArray1[1]);
                    uint num18 = uint.Parse(strArray1[2]);
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_SendFlower()
                    {
                        oArg = {
              roleid = num17,
              count = num18
            }
                    });
                    break;
                case "setminimapsize":
                    DlgBase<BattleMain, BattleMainBehaviour>.singleton.IndicateHandler.SetMiniMapSize(new Vector2(float.Parse(strArray1[1]), float.Parse(strArray1[2])), strArray1.Length > 3 ? float.Parse(strArray1[3]) : 0.0f);
                    break;
                case "setsound":
                    XSingleton<XAudioMgr>.singleton.hasSound = !XSingleton<XAudioMgr>.singleton.hasSound;
                    break;
                case "setsysredpoint":
                    XSingleton<XGameSysMgr>.singleton.SetSysRedPointState((XSysDefine)int.Parse(strArray1[1]), strArray1[2] == "true");
                    break;
                case "setxy":
                    Screen.SetResolution(int.Parse(strArray1[1]), int.Parse(strArray1[2]), true);
                    break;
                case "showblacklist":
                    XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2M_BlackListReportNew());
                    break;
                case "showflowerpage":
                    ulong num19 = ulong.Parse(strArray1[1]);
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2M_ShowFlowerPageNew()
                    {
                        oArg = {
              roleid = num19
            }
                    });
                    break;
                case "showsystemui":
                    if (strArray1.Length == 2)
                    {
                        XSingleton<XGameSysMgr>.singleton.OpenSystem((XSysDefine)int.Parse(strArray1[1]));
                        break;
                    }
                    break;
                case "sscale":
                    if (strArray1.Length == 2)
                    {
                        float num20 = float.Parse(strArray1[1]);
                        Screen.SetResolution((int)(1136f * num20), (int)(640f * num20), true);
                        break;
                    }
                    break;
                case "stop":
                    if (strArray1.Length > 1)
                    {
                        int result11 = 0;
                        int.TryParse(strArray1[1], out result11);
                        switch (result11)
                        {
                            case 0:
                                GameObject gameObject3 = GameObject.Find("XGamePoint");
                                if ((UnityEngine.Object)gameObject3 != (UnityEngine.Object)null)
                                {
                                    gameObject3.SetActive(false);
                                    break;
                                }
                                break;
                            case 1:
                                GameObject gameObject4 = GameObject.Find("UIRoot(Clone)");
                                if ((UnityEngine.Object)gameObject4 != (UnityEngine.Object)null)
                                    gameObject4.SetActive(false);
                                GameObject gameObject5 = GameObject.Find("HpbarRoot(Clone)");
                                if ((UnityEngine.Object)gameObject5 != (UnityEngine.Object)null)
                                    gameObject5.SetActive(false);
                                GameObject gameObject6 = GameObject.Find("NpcHpbarRoot");
                                if ((UnityEngine.Object)gameObject6 != (UnityEngine.Object)null)
                                {
                                    gameObject6.SetActive(false);
                                    break;
                                }
                                break;
                        }
                        break;
                    }
                    break;
                case "suit":
                    int suitID = int.Parse(strArray1[1]);
                    XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID).EquipSuit(suitID);
                    break;
                case "sweep":
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_Sweep()
                    {
                        oArg = {
              sceneID = uint.Parse(strArray1[1]),
              count = uint.Parse(strArray1[2])
            }
                    });
                    break;
                case "targetframe":
                    Application.targetFrameRate = Application.targetFrameRate == XShell.TargetFrame ? -1 : XShell.TargetFrame;
                    break;
                case "tca":
                case "tutorialendcurall":
                    XSingleton<XTutorialMgr>.singleton.SkipCurrentTutorial(true);
                    break;
                case "tea":
                case "tutorialendall":
                    XSingleton<XTutorialMgr>.singleton.CloseAllTutorial();
                    this.ProcessCommand("tutorialendcurall");
                    break;
                case "team":
                    DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
                    break;
                case "testskill":
                    XSingleton<XSkillEffectMgr>.singleton.TestSkillTable();
                    break;
                case "testversionserver":
                    using (new StreamWriter(Path.Combine(Application.persistentDataPath, "TEST_VERSION")))
                    {
                        XSingleton<XUpdater.XUpdater>.singleton.XPlatform.SetNoBackupFlag(Path.Combine(Application.persistentDataPath, "TEST_VERSION"));
                        break;
                    }
                case "themeopen":
                    DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.debug = true;
                    DlgBase<XThemeActivityView, XThemeActivityBehaviour>.singleton.SetVisibleWithAnimation(true, (DlgBase<XThemeActivityView, XThemeActivityBehaviour>.OnAnimationOver)null);
                    break;
                case "titleitem":
                    this.ProcessCommand("item 2097 1");
                    this.ProcessCommand("item 301 30");
                    this.ProcessCommand("item 302 30");
                    this.ProcessCommand("item 303 30");
                    this.ProcessCommand("item 304 30");
                    break;
                case "tutorialend":
                    PtcC2G_UpdateTutorial c2GUpdateTutorial = new PtcC2G_UpdateTutorial();
                    for (int index = 1; index < strArray1.Length; ++index)
                    {
                        c2GUpdateTutorial.Data.tutorialID = uint.Parse(strArray1[index]);
                        XSingleton<XClientNetwork>.singleton.Send((Protocol)c2GUpdateTutorial);
                    }
                    break;
                case "tutorialendcur":
                    XSingleton<XTutorialMgr>.singleton.SkipCurrentTutorial();
                    break;
                case "uiopt":
                    if (strArray1.Length >= 4)
                    {
                        XSingleton<XGameUI>.singleton.SetUIOptOption((uint)int.Parse(strArray1[1]) > 0U, (uint)int.Parse(strArray1[2]) > 0U, (uint)int.Parse(strArray1[3]) > 0U);
                        break;
                    }
                    break;
                case "unloadassets":
                    Resources.UnloadUnusedAssets();
                    break;
                case "unloadbundle":
                    XSingleton<XUpdater.XUpdater>.singleton.ABManager.UnloadNotUsedLoader();
                    break;
                default:
                    XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_GMCommand()
                    {
                        oArg = {
              cmd = command
            }
                    });
                    flag = true;
                    break;
            }
            return flag;
        }

        public void SkillLearn(object o = null)
        {
            XSkillTreeDocument specificDocument = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
            bool flag = false;
            for (int index1 = 10; index1 <= 1000 && (long)XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID >= (long)(index1 / 10); index1 *= 10)
            {
                List<uint> profSkillId = XSingleton<XSkillEffectMgr>.singleton.GetProfSkillID((int)XSingleton<XAttributeMgr>.singleton.XPlayerData.TypeID % index1);
                for (int index2 = 0; index2 < profSkillId.Count; ++index2)
                {
                    if (specificDocument.CheckLevelUpButton(profSkillId[index2]))
                    {
                        flag = true;
                        XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_SkillLevelup()
                        {
                            oArg = {
                skillHash = profSkillId[index2]
              }
                        });
                    }
                }
            }
            if (flag)
            {
                int num = (int)XSingleton<XTimerMgr>.singleton.SetTimer(0.2f, new XTimerMgr.ElapsedEventHandler(this.SkillLearn), (object)null);
            }
            else
                XSingleton<XDebug>.singleton.AddGreenLog("Learn All Skill End.");
        }

        public void GuildCollectNav(object o = null)
        {
            XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
            this._timeToken = XSingleton<XTimerMgr>.singleton.SetTimer(2f, new XTimerMgr.ElapsedEventHandler(this.GuildCollectNav), (object)null);
            if (DlgBase<GuildInheritProcessDlg, GuildInheritProcessBehaviour>.singleton.IsVisible())
            {
                XSingleton<XInput>.singleton.LastNpc = (XEntity)null;
            }
            else
            {
                if (XSingleton<XInput>.singleton.LastNpc != null)
                    return;
                --this.NpcID;
                if (this.NpcID < 97U)
                    this.NpcID = 100U;
                XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(this.NpcID);
                if (npc == null)
                    return;
                XSingleton<XInput>.singleton.LastNpc = (XEntity)npc;
            }
        }

        public void ClearGuildCollectNav()
        {
            this.ProcessCommand("clearguildcollectCD");
            XSingleton<XInput>.singleton.LastNpc = (XEntity)null;
            XSingleton<XTimerMgr>.singleton.KillTimer(this._timeToken);
        }

        public void CustomCommand(int index)
        {
            string str = Path.Combine(Application.persistentDataPath, "GM.txt");
            if (!new FileInfo(str).Exists)
                return;
            StreamReader streamReader;
            try
            {
                streamReader = new StreamReader(str, Encoding.Default);
            }
            catch (IOException ex)
            {
                Debug.Log((object)ex);
                XSingleton<XDebug>.singleton.AddErrorLog("读表失败，请关闭正在打开的表格重试");
                return;
            }
            bool flag = false;
            while (!streamReader.EndOfStream)
            {
                string command = streamReader.ReadLine();
                if (command.Length >= 2 && command[0] == '$')
                    flag = (int)command[1] == 48 + index;
                else if (flag)
                    this.ProcessCommand(command);
            }
            streamReader.Close();
        }
    }
}
