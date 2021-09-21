// Decompiled with JetBrains decompiler
// Type: XMainClient.XTutorialCmdExecutor
// Assembly: XMainClient, Version=1.0.6733.32538, Culture=neutral, PublicKeyToken=null
// MVID: 71510397-FE89-4B5C-BC50-B6D560866D97
// Assembly location: F:\龙之谷\Client\Assets\Lib\XMainClient.dll

using KKSG;
using System.Collections.Generic;
using UnityEngine;
using XMainClient.Tutorial.Command;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
    internal class XTutorialCmdExecutor
    {
        private XBaseCommand _command;
        public float _lastCmdFinishTime = 0.0f;
        private XCommandForceClick _forceCmd = new XCommandForceClick();
        private XCommandCutscene _cutsceneCmd = new XCommandCutscene();
        private XCommandExec _execCmd = new XCommandExec();
        private XCommandForceSlide _forceSlideCmd = new XCommandForceSlide();
        private XCommandGenericClick _genericClickCmd = new XCommandGenericClick();
        private XCommandNewIcon _newIconCmd = new XCommandNewIcon();
        private XCommandDirectSys _newDirectSys = new XCommandDirectSys();
        private XCommandNoforceClick _noforceClickCmd = new XCommandNoforceClick();
        private XCommandPureText _pureTextCmd = new XCommandPureText();
        private XCommandMove _moveCmd = new XCommandMove();
        private XCommandForceSkill _skillCmd = new XCommandForceSkill();
        private XCommandPureOverlay _overlayCmd = new XCommandPureOverlay();
        private XCommandPrefab _prefabCmd = new XCommandPrefab();
        private XCommandNote _noteCmd = new XCommandNote();
        private XCommandHideSkills _hideskillCmd = new XCommandHideSkills();
        private XCommandShowSkills _showskillCmd = new XCommandShowSkills();
        private XCommandIsShowButton _isshowbuttonCmd = new XCommandIsShowButton();
        private XCommandClickEntity _clickEntityCmd = new XCommandClickEntity();
        private XCommandEmpty _emptyCmd = new XCommandEmpty();

        public void ExecuteCmd(ref XTutorialCmd Cmd)
        {
            this.ResetRelativeFlag();
            if (this.IsSkip(Cmd))
            {
                if (Cmd.skipParam1 != null && (uint)int.Parse(Cmd.skipParam1) > 0U)
                {
                    XSingleton<XTutorialMgr>.singleton.SkipCurrentTutorial();
                }
                else
                {
                    Cmd.state = XCmdState.Cmd_Finished;
                    XSingleton<XDebug>.singleton.AddLog("Skip Tutorial:" + Cmd.tag);
                }
            }
            else if (Cmd.cmd == "forceclick")
            {
                this._command = (XBaseCommand)this._forceCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_In_Process;
            }
            else if (Cmd.cmd == "forceskill")
            {
                this._command = (XBaseCommand)this._skillCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_In_Process;
            }
            else if (Cmd.cmd == "noforceclick")
            {
                this._command = (XBaseCommand)this._noforceClickCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_In_Process;
            }
            else if (Cmd.cmd == "forceslide")
            {
                this._command = (XBaseCommand)this._forceSlideCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_In_Process;
            }
            else if (Cmd.cmd == "movetutorial")
            {
                this._command = (XBaseCommand)this._moveCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_In_Process;
            }
            else if (Cmd.cmd == "newsys")
            {
                this._command = (XBaseCommand)this._newIconCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_In_Process;
            }
            else if (Cmd.cmd == "directsys")
            {
                this._command = (XBaseCommand)this._newDirectSys;
                this._command.SetCommand(Cmd);
                if (this._command.Execute())
                    Cmd.state = XCmdState.Cmd_In_Process;
                XSingleton<XTutorialMgr>.singleton.OnCmdFinished();
            }
            else if (Cmd.cmd == "clickentity")
            {
                this._command = (XBaseCommand)this._clickEntityCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_In_Process;
            }
            else if (Cmd.cmd == "cutscene")
            {
                this._command = (XBaseCommand)this._cutsceneCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_In_Process;
            }
            else if (Cmd.cmd == "exec")
            {
                this._command = (XBaseCommand)this._execCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_Finished;
            }
            else if (Cmd.cmd == "puretext")
            {
                this._command = (XBaseCommand)this._pureTextCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_In_Process;
            }
            else if (Cmd.cmd == "overlay")
            {
                this._command = (XBaseCommand)this._overlayCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_In_Process;
            }
            else if (Cmd.cmd == "genericclick")
            {
                this._command = (XBaseCommand)this._genericClickCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_In_Process;
            }
            else if (Cmd.cmd == "showprefab")
            {
                this._command = (XBaseCommand)this._prefabCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_In_Process;
            }
            else if (Cmd.cmd == "notewindow")
            {
                this._command = (XBaseCommand)this._noteCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_In_Process;
            }
            else if (Cmd.cmd == "hideskills")
            {
                this._command = (XBaseCommand)this._hideskillCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_Finished;
            }
            else if (Cmd.cmd == "showskills")
            {
                this._command = (XBaseCommand)this._showskillCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_Finished;
            }
            else if (Cmd.cmd == "showbutton")
            {
                this._command = (XBaseCommand)this._isshowbuttonCmd;
                this._command.SetCommand(Cmd);
                if (!this._command.Execute())
                    return;
                Cmd.state = XCmdState.Cmd_Finished;
            }
            else
            {
                if (!(Cmd.cmd == "empty"))
                    return;
                this._command = (XBaseCommand)this._emptyCmd;
                this._command.SetCommand(Cmd);
                if (this._command.Execute())
                    Cmd.state = XCmdState.Cmd_In_Process;
            }
        }

        public void UpdateCmd(ref XTutorialCmd Cmd)
        {
            this._command.Update();
            if (!this.CanCmdFinish(Cmd))
                return;
            XSingleton<XTutorialMgr>.singleton.OnCmdFinished();
        }

        public void StopCmd() => this._command.Stop();

        public void OnCmdFinish(ref XTutorialCmd Cmd)
        {
            this._command.OnFinish();
            Cmd.state = XCmdState.Cmd_Finished;
            this._lastCmdFinishTime = Time.time;
        }

        private bool ConditionSatisified(List<XTutorialCmdExecuteCondition> conds, List<string> param)
        {
            bool flag1 = true;
            for (int index1 = 0; index1 < conds.Count; ++index1)
            {
                switch (conds[index1])
                {
                    case XTutorialCmdExecuteCondition.Player_Level:
                        if ((long)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (long)int.Parse(param[index1]))
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.In_Level:
                        uint sceneId1 = XSingleton<XScene>.singleton.SceneID;
                        if ((int)sceneId1 != int.Parse(param[index1]))
                        {
                            flag1 = false;
                            break;
                        }
                        if (sceneId1 == 1U && !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible())
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.After_Level:
                        if ((int)XSingleton<XLevelFinishMgr>.singleton.LastFinishScene != int.Parse(param[index1]))
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Cast_Skill:
                        if (XSingleton<XEntityMgr>.singleton.Boss == null || !XSingleton<XEntityMgr>.singleton.Boss.Skill.IsCasting() || (int)XSingleton<XEntityMgr>.singleton.Boss.Skill.CurrentSkill.MainCore.ID != (int)XSingleton<XCommon>.singleton.XHash(param[index1]))
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.External_String:
                        if (!XSingleton<XTutorialMgr>.singleton.QueryExternalString(param[index1], false))
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Talk_Npc:
                        if (!DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible())
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Can_Accept_Task:
                        XTaskDocument specificDocument1 = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
                        int num1 = int.Parse(param[index1]);
                        bool flag2 = false;
                        for (int index2 = 0; index2 < specificDocument1.TaskRecord.Tasks.Count; ++index2)
                        {
                            XTaskInfo task = specificDocument1.TaskRecord.Tasks[index2];
                            if (task != null && (long)task.ID == (long)num1)
                            {
                                flag2 = true;
                                if (task.Status != TaskStatus.TaskStatus_CanTake || !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible())
                                {
                                    flag1 = false;
                                    break;
                                }
                                break;
                            }
                        }
                        if (!flag2)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Can_Finish_Task:
                    case XTutorialCmdExecuteCondition.Task_Scene_Finish:
                        XTaskDocument specificDocument2 = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
                        int num2 = int.Parse(param[index1]);
                        bool flag3 = false;
                        for (int index3 = 0; index3 < specificDocument2.TaskRecord.Tasks.Count; ++index3)
                        {
                            XTaskInfo task = specificDocument2.TaskRecord.Tasks[index3];
                            if (task != null && (long)task.ID == (long)num2)
                            {
                                flag3 = true;
                                if (task.Status != TaskStatus.TaskStatus_Finish || !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible())
                                {
                                    flag1 = false;
                                    break;
                                }
                                break;
                            }
                        }
                        if (!flag3)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Task_Over:
                        flag1 = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID).TaskRecord.IsTaskFinished(uint.Parse(param[index1]));
                        break;
                    case XTutorialCmdExecuteCondition.Task_Battle:
                        XTaskDocument specificDocument3 = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
                        uint num3 = uint.Parse(param[index1]);
                        bool flag4 = false;
                        for (int index4 = 0; index4 < specificDocument3.TaskRecord.Tasks.Count; ++index4)
                        {
                            XTaskInfo task = specificDocument3.TaskRecord.Tasks[index4];
                            TaskTableNew.RowData tableData = task.TableData;
                            uint sceneId2 = XTaskDocument.GetSceneID(ref tableData.PassScene);
                            uint sceneId3 = XTaskDocument.GetSceneID(ref tableData.TaskScene);
                            if (task != null && ((int)sceneId2 == (int)num3 || (int)sceneId3 == (int)num3))
                            {
                                flag4 = true;
                                if (task.Status != TaskStatus.TaskStatus_Taked || !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible())
                                {
                                    flag1 = false;
                                    break;
                                }
                                break;
                            }
                        }
                        if (!flag4)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Time_Delay:
                        float num4 = float.Parse(param[index1]);
                        if ((double)num4 > 0.0 && (double)Time.time - (double)this._lastCmdFinishTime < (double)num4)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Sys_Notify:
                        bool flag5 = flag1;
                        if (!XSingleton<XTutorialMgr>.singleton.QueryExternalString("OpenSys" + param[index1], false))
                            flag1 = false;
                        if (XSingleton<XAttributeMgr>.singleton.XPlayerData.IsSystemOpened(uint.Parse(param[index1])))
                        {
                            flag1 = flag5;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Meet_Enemy:
                        if (!XSingleton<XTutorialHelper>.singleton.MeetEnemy)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Art_Skill:
                        if (!XSingleton<XTutorialHelper>.singleton.ArtSkillOver)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Cutscene_Over:
                        if (XSingleton<XCutScene>.singleton.IsPlaying)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Get_Focused:
                        if (XSingleton<XEntityMgr>.singleton.Boss == null || !XSingleton<XEntityMgr>.singleton.Boss.Skill.IsCasting())
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.No_SuperAmor:
                        if (XSingleton<XEntityMgr>.singleton.Boss == null)
                        {
                            flag1 = false;
                            break;
                        }
                        List<XBattleEnemyInfo> enemyList = DlgBase<BattleMain, BattleMainBehaviour>.singleton.EnemyInfoHandler.EnemyList;
                        double num5 = 0.0;
                        if (enemyList.Count > 0)
                            num5 = (double)enemyList[0].m_uiSuperArmor.value;
                        if (num5 > 0.0)
                            flag1 = false;
                        break;
                    case XTutorialCmdExecuteCondition.Boss_Exist:
                        if (!XSingleton<XTutorialHelper>.singleton.HasBoss)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Enemy_OnGround:
                        if (!XSingleton<XTutorialHelper>.singleton.HitDownOnGround)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.No_Promote:
                        if (XSingleton<XEntityMgr>.singleton.Player.TypeID >= 10U)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Team2:
                        XTeamDocument specificDocument4 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
                        if (!specificDocument4.bInTeam || specificDocument4.MyTeam.members.Count <= 1)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Has_Target:
                        if (!XSingleton<XTutorialHelper>.singleton.HasTarget)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.MainUI:
                        if (XSingleton<UIManager>.singleton.IsUIShowed() || XSingleton<UIManager>.singleton.IsHideTutorial())
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Has_Item:
                        string[] strArray1 = param[index1].Split(XGlobalConfig.SequenceSeparator);
                        int itemid = int.Parse(strArray1[0]);
                        int num6 = int.Parse(strArray1[1]);
                        int num7 = XBagDocument.ConvertTemplate(itemid);
                        int itemCount = (int)XDocuments.GetSpecificDocument<XBagDocument>(XBagDocument.uuID).GetItemCount(num7);
                        if (XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID).OwnFashion(num7))
                            ++itemCount;
                        if (itemCount < num6)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Has_Body:
                        XBagDocument specificDocument5 = XDocuments.GetSpecificDocument<XBagDocument>(XBagDocument.uuID);
                        XItem xitem = (XItem)null;
                        string[] strArray2 = param[index1].Split(XGlobalConfig.SequenceSeparator);
                        string str = strArray2[0];
                        int num8 = 0;
                        if (strArray2.Length > 1)
                            num8 = int.Parse(strArray2[1]);
                        XJadeDocument specificDocument6 = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
                        int num9 = 0;
                        if (str == "boots")
                        {
                            num9 = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.Boots);
                            xitem = specificDocument5.EquipBag[num9];
                        }
                        else if (str == "earrings")
                        {
                            num9 = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.Earrings);
                            xitem = specificDocument5.EquipBag[num9];
                        }
                        else if (str == "gloves")
                        {
                            num9 = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.Gloves);
                            xitem = specificDocument5.EquipBag[num9];
                        }
                        else if (str == "headgear")
                        {
                            num9 = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.EQUIP_START);
                            xitem = specificDocument5.EquipBag[num9];
                        }
                        else if (str == "lowerbody")
                        {
                            num9 = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.Lowerbody);
                            xitem = specificDocument5.EquipBag[num9];
                        }
                        else if (str == "mainweapon")
                        {
                            num9 = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.Mainweapon);
                            xitem = specificDocument5.EquipBag[num9];
                        }
                        else if (str == "necklace")
                        {
                            num9 = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.Necklace);
                            xitem = specificDocument5.EquipBag[num9];
                        }
                        else if (str == "rings")
                        {
                            num9 = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.Rings);
                            xitem = specificDocument5.EquipBag[num9];
                        }
                        else if (str == "secondaryweapon")
                        {
                            num9 = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.Secondaryweapon);
                            xitem = specificDocument5.EquipBag[num9];
                        }
                        else if (str == "upperbody")
                        {
                            num9 = XBagDocument.BodyPosition<EquipPosition>(EquipPosition.Upperbody);
                            xitem = specificDocument5.EquipBag[num9];
                        }
                        if (num8 == 0)
                        {
                            if (xitem == null || xitem.itemID == 0)
                            {
                                flag1 = false;
                                break;
                            }
                            break;
                        }
                        if (!specificDocument6.HasRedPoint(num9))
                            flag1 = false;
                        break;
                    case XTutorialCmdExecuteCondition.No_Stackui:
                        if (XSingleton<UIManager>.singleton.IsUIShowed() || XSingleton<UIManager>.singleton.IsHideTutorial())
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Activity_Open:
                        if (!XSingleton<XTutorialHelper>.singleton.ActivityOpen)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Dragon_Crusade_Open:
                        if (!XSingleton<XTutorialHelper>.singleton.DragonCrusadeOpen)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                    case XTutorialCmdExecuteCondition.Battle_NPC_Talk_End:
                        if (!XSingleton<XTutorialHelper>.singleton.BattleNPCTalkEnd)
                        {
                            flag1 = false;
                            break;
                        }
                        break;
                }
                if (!flag1)
                    break;
            }
            return flag1;
        }

        public bool CanTutorialExecute(XTutorialMainCmd tutorial) => this.ConditionSatisified(tutorial.conditions, tutorial.condParams);

        public bool CanCmdExecute(XTutorialCmd cmd)
        {
            if (cmd.state == XCmdState.Cmd_In_Process || cmd.state == XCmdState.Cmd_Finished || !this.ConditionSatisified(cmd.conditions, cmd.condParams))
                return false;
            for (int index = 0; index < cmd.conditions.Count; ++index)
            {
                switch (cmd.conditions[index])
                {
                    case XTutorialCmdExecuteCondition.External_String:
                        XSingleton<XTutorialMgr>.singleton.QueryExternalString(cmd.condParams[index], true);
                        break;
                    case XTutorialCmdExecuteCondition.Sys_Notify:
                        XSingleton<XTutorialMgr>.singleton.QueryExternalString("OpenSys" + cmd.condParams[index], true);
                        break;
                }
            }
            return true;
        }

        public bool CanCmdFinish(XTutorialCmd cmd)
        {
            if (cmd.state != XCmdState.Cmd_In_Process || cmd.endcondition == XTutorialCmdFinishCondition.No_Condition)
                return false;
            bool flag = false;
            switch (cmd.endcondition)
            {
                case XTutorialCmdFinishCondition.Time:
                    if ((double)Time.time - (double)this._command._startTime > (cmd.endParam.Count > 0 ? (double)float.Parse(cmd.endParam[0]) : 3.0))
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.TalkingNpc:
                    if (DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible())
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.WorldMap:
                    if (DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.IsVisible())
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.SkillLevelup:
                    if (XSingleton<XTutorialHelper>.singleton.SkillLevelup)
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.SkillBind:
                    if (XSingleton<XTutorialHelper>.singleton.SkillBind)
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.UseItem:
                    if (XSingleton<XTutorialHelper>.singleton.UseItem)
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.SysOpened:
                    if (XSingleton<XAttributeMgr>.singleton.XPlayerData.IsSystemOpened(uint.Parse(cmd.param1)))
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.GetReward:
                    if (XSingleton<XTutorialHelper>.singleton.GetReward)
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.Move:
                    if (XSingleton<XTutorialHelper>.singleton.Moved)
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.ComposeFashion:
                    if (XSingleton<XTutorialHelper>.singleton.FashionCompose)
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.ReinforceItem:
                    if (XSingleton<XTutorialHelper>.singleton.ReinforceItem)
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.EnhanceItem:
                    if (XSingleton<XTutorialHelper>.singleton.EnhanceItem)
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.ChangeProf:
                    if (XSingleton<XTutorialHelper>.singleton.SwitchProf)
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.HasTeam:
                    if (XSingleton<XTutorialHelper>.singleton.HasTeam)
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.Smelting:
                    if (XSingleton<XTutorialHelper>.singleton.Smelting)
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.SelectView:
                    if (XSingleton<XTutorialHelper>.singleton.SelectView)
                    {
                        flag = true;
                        break;
                    }
                    break;
                case XTutorialCmdFinishCondition.SelectSkipTutorial:
                    if (XSingleton<XTutorialHelper>.singleton.SelectSkipTutorial)
                    {
                        flag = true;
                        break;
                    }
                    break;
            }
            return flag;
        }

        private bool IsSkip(XTutorialCmd cmd)
        {
            string skipCondition = cmd.skipCondition;
            if (string.IsNullOrEmpty(skipCondition))
                return false;
            XSkillTreeDocument specificDocument1 = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
            bool flag = false;
            switch (skipCondition)
            {
                case "Chapter1Star8Box":
                    flag = XSingleton<XStageProgress>.singleton.HasChapterBoxFetched(1, 0);
                    break;
                case "CurSkillNoLearn":
                    flag = !specificDocument1.CheckLevelUpButton();
                    break;
                case "HasTaskTab":
                    flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler._TaskSwitchBtnState;
                    break;
                case "InTaskTab":
                    flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.IsShowingTaskTab;
                    break;
                case "InTeamTab":
                    flag = !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton._TaskNaviHandler.IsShowingTaskTab;
                    break;
                case "LearnSkill":
                    if (cmd.skipParam2 == null || cmd.skipParam3 == null)
                        XSingleton<XDebug>.singleton.AddErrorLog("TutorialId:" + (object)cmd.TutorialID + " Error\ntag:" + cmd.tag + " Command:LearnSkill  Param Num Error");
                    flag = !specificDocument1.isTutorialNeed(int.Parse(cmd.skipParam2), int.Parse(cmd.skipParam3));
                    break;
                case "MenuBtnInState1":
                    flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.MenuSwitchBtnState;
                    break;
                case "MenuBtnInState2":
                    flag = !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.MenuSwitchBtnState;
                    break;
                case "ModalDlg":
                    flag = !DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.IsVisible();
                    break;
                case "NoLearnSkill":
                    if (cmd.skipParam2 == null || cmd.skipParam3 == null)
                        XSingleton<XDebug>.singleton.AddErrorLog("TutorialId:" + (object)cmd.TutorialID + " Error\ntag:" + cmd.tag + " Command:LearnSkill  Param Num Error");
                    flag = specificDocument1.isTutorialNeed(int.Parse(cmd.skipParam2), int.Parse(cmd.skipParam3));
                    break;
                case "PPTLess":
                    if (cmd.skipParam2 == null)
                        XSingleton<XDebug>.singleton.AddErrorLog("TutorialId:" + (object)cmd.TutorialID + " Error\ntag:" + cmd.tag + " Command:PPTLess  Param Num Error");
                    flag = XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Total) < (double)int.Parse(cmd.skipParam2);
                    break;
                case "ProfessionNo1Turn":
                    flag = XFastEnumIntEqualityComparer<RoleType>.ToInt(XSingleton<XAttributeMgr>.singleton.XPlayerData.Profession) < 10;
                    break;
                case "RadioNoCanOpen":
                    XRadioDocument specificDocument2 = XDocuments.GetSpecificDocument<XRadioDocument>(XRadioDocument.uuID);
                    XOptionsDocument specificDocument3 = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
                    flag = specificDocument2.roomState == XRadioDocument.BigRoomState.InRoom || specificDocument3.GetValue(XOptionsDefine.OD_RADIO) == 0;
                    break;
                case "SelectSight2.5D":
                    flag = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID).GetValue(XOptionsDefine.OD_VIEW) == XFastEnumIntEqualityComparer<XOperationMode>.ToInt(XOperationMode.X25D);
                    break;
            }
            return flag;
        }

        public void ResetRelativeFlag()
        {
            XSingleton<XTutorialHelper>.singleton.SkillLevelup = false;
            XSingleton<XTutorialHelper>.singleton.SkillBind = false;
            XSingleton<XTutorialHelper>.singleton.UseItem = false;
            XSingleton<XTutorialHelper>.singleton.GetReward = false;
            XSingleton<XTutorialHelper>.singleton.FashionCompose = false;
            XSingleton<XTutorialHelper>.singleton.ReinforceItem = false;
            XSingleton<XTutorialHelper>.singleton.EnhanceItem = false;
            XSingleton<XTutorialHelper>.singleton.SwitchProf = false;
            XSingleton<XTutorialHelper>.singleton.MeetEnemy = false;
            XSingleton<XTutorialHelper>.singleton.HasTeam = false;
            XSingleton<XTutorialHelper>.singleton.Smelting = false;
            XSingleton<XTutorialHelper>.singleton.HitDownOnGround = false;
        }
    }
}
