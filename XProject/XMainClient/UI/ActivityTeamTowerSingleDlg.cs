

using KKSG;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
    internal class ActivityTeamTowerSingleDlg :
      DlgBase<ActivityTeamTowerSingleDlg, ActivityTeamTowerSingleDlgBehaviour>
    {
        private XExpeditionDocument _doc;
        private uint _count_timer;
        private bool _in_sweeping = false;
        private float _time_left = 0.0f;
        private bool _sweep_finished = false;
        private float _sweep_time = 0.0f;
        private int _sweep_level = 0;
        private int _tower_max_floor = 100;
        private uint _show_sweep_timer = 0;
        private float _effect_result = 1f;
        private List<float> _random_list = new List<float>();
        private List<int> _refresh_cost = new List<int>();
        private List<int> _refresh_money = new List<int>();
        private List<int> frames = new List<int>();
        private XElapseTimer timePass = new XElapseTimer();
        public ActivityTeamTowerSingleDlg.State state = ActivityTeamTowerSingleDlg.State.None;
        private int _play_count = 0;
        private int _acc_time = 0;
        private int _all_count = 35;
        private bool _is_getting_reward = false;

        public bool SweepFinished
        {
            get => this._sweep_finished;
            set => this._sweep_finished = value;
        }

        public override string fileName => "Hall/TeamTowerNewDlg";

        public override int layer => 1;

        public override bool autoload => true;

        public override bool hideMainMenu => true;

        public override bool pushstack => true;

        public override bool fullscreenui => true;

        public override int sysid => XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Activity_TeamTowerSingle);

        protected override void Init()
        {
            this._doc = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
            this._doc.TeamTowerSingleView = this;
            this._sweep_time = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("SweepTowerTime").Split('|')[0].Split('=')[1]);
            string[] strArray1 = XSingleton<XGlobalConfig>.singleton.GetValue("RefreshSweepRand").Split('|');
            this._random_list.Clear();
            for (int index = 0; index < strArray1.Length; ++index)
                this._random_list.Add((float)((double)int.Parse(strArray1[index].Split('=')[0]) / 100.0));
            string[] strArray2 = XSingleton<XGlobalConfig>.singleton.GetValue("RefreshSweepCost").Split('|');
            this._refresh_cost.Clear();
            this._refresh_money.Clear();
            for (int index = 0; index < strArray2.Length; ++index)
            {
                string[] strArray3 = strArray2[index].Split('=');
                this._refresh_cost.Add(int.Parse(strArray3[1]));
                this._refresh_money.Add(int.Parse(strArray3[0]));
            }
            this.frames.Clear();
            string str = XSingleton<XGlobalConfig>.singleton.GetValue("TeamTower_Ani");
            char[] chArray = new char[1] { '|' };
            foreach (string s in str.Split(chArray))
                this.frames.Add(int.Parse(s));
            this._all_count = this.frames.Count;
        }

        public override void RegisterEvent()
        {
            base.RegisterEvent();
            this.uiBehaviour.mMainClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseDlg));
            this.uiBehaviour.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
            this.uiBehaviour.mSweepBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowSweepFrame));
            this.uiBehaviour.mSingleDoSweep.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnQuickStartSweep));
            this.uiBehaviour.mDoubleSweep.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnStartSweep));
            this.uiBehaviour.mDoubleDoSweep.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnQuickStartSweep));
            this.uiBehaviour.mBackClick.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseSweep));
            this.uiBehaviour.mCloseSweep.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseSweep));
            this.uiBehaviour.mResetBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReqResetSweep));
            this.uiBehaviour.mRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.ShowTeamTowerRank));
            this.uiBehaviour.mGoBattle.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnEnterBattle));
            this.uiBehaviour.mRewardRefresh.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRefreshReward));
            this.uiBehaviour.mRewardGet.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetReward));
            this.uiBehaviour.mFirstPassBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnShowFirstPassReward));
            this.uiBehaviour.mFirstPassGetReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetFirstPassReward));
            this.uiBehaviour.mFirstPassBackClick.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnHideFirstPassReward));
            this.uiBehaviour.mFirstPassCheckReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnGetDisableReward));
        }

        public bool OnHelpClicked(IXUIButton button)
        {
            DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_Activity_TeamTowerSingle);
            return true;
        }

        protected override void OnShow() => this.ShowTeamTowerFrame();

        protected override void OnHide()
        {
            if (this._count_timer > 0U)
                XSingleton<XTimerMgr>.singleton.KillTimer(this._count_timer);
            this._count_timer = 0U;
            if (this._show_sweep_timer > 0U)
                XSingleton<XTimerMgr>.singleton.KillTimer(this._show_sweep_timer);
            this._show_sweep_timer = 0U;
        }

        private void ShowTeamTowerFrame()
        {
            this.uiBehaviour.mSweepFrame.SetVisible(false);
            this.uiBehaviour.mSweepResult.SetVisible(false);
            this.uiBehaviour.mFirstPassPanel.SetVisible(false);
            this._sweep_level = 0;
            this._sweep_finished = false;
            this._is_getting_reward = false;
            this._doc.GetSingleTowerActivityTop();
        }

        private bool OnCloseDlg(IXUIButton btn)
        {
            this.SetVisibleWithAnimation(false, (DlgBase<ActivityTeamTowerSingleDlg, ActivityTeamTowerSingleDlgBehaviour>.OnAnimationOver)null);
            return true;
        }

        private bool ShowTeamTowerRank(IXUIButton btn)
        {
            DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank_TeamTower);
            return true;
        }

        public void OnRefreshTopInfo()
        {
            if (this._doc == null || !this.IsVisible())
                return;
            TeamTowerData singleTowerData = this._doc.SingleTowerData;
            TeamTowerRewardTable.RowData[] teamTowerTable = this._doc.GetTeamTowerTable();
            if (singleTowerData == null)
                return;
            if (singleTowerData.sweeplefttime > 0)
            {
                if ((double)singleTowerData.sweeplefttime <= (double)Time.time - (double)singleTowerData.sweepreqtime)
                {
                    this._in_sweeping = false;
                    this._sweep_finished = true;
                }
                else
                {
                    this._in_sweeping = true;
                    this._sweep_finished = false;
                }
            }
            else
            {
                this._sweep_finished = singleTowerData.maxlevel == singleTowerData.sweepfloor && singleTowerData.maxlevel > 0;
                this._in_sweeping = false;
            }
            this._sweep_level = singleTowerData.sweepfloor;
            int leftcount = this._doc.SingleTowerData.leftcount;
            int num = singleTowerData.level + 1;
            if (num >= teamTowerTable.Length)
                num = teamTowerTable.Length;
            this.uiBehaviour.mStage.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("TEAMTOWER_LEVEL"), (object)num));
            int result = 1;
            int.TryParse(XSingleton<XGlobalConfig>.singleton.GetValue("TowerTeamDayCount"), out result);
            this.uiBehaviour.mResetNum.SetText(string.Format("{0}/{1}", (object)leftcount, (object)result));
            if (leftcount > 0)
            {
                this.uiBehaviour.mResetSprite.SetVisible(true);
                this.uiBehaviour.mResetCount.SetText(leftcount.ToString());
            }
            else
                this.uiBehaviour.mResetSprite.SetVisible(false);
            this.OnInitMainReward();
            this.InitTowerMap(singleTowerData.level);
            this.OnRefreshSweepInfo();
            this.OnInitFirstReward();
            if (this._sweep_finished)
                this.OnShowSweepResultFrame();
            else
                this.OnHideSweepResultFrame();
        }

        public void OnRefreshSweepInfo()
        {
            TeamTowerData singleTowerData = this._doc.SingleTowerData;
            this._time_left = (float)singleTowerData.sweeplefttime - (Time.time - singleTowerData.sweepreqtime);
            this._in_sweeping = (double)this._time_left > 0.0;
            if ((double)this._time_left < 0.0)
                this._time_left = 0.0f;
            if ((double)this._time_left > 0.0)
                this.DoCountDown((object)null);
            if (!this._in_sweeping)
                return;
            this._show_sweep_timer = XSingleton<XTimerMgr>.singleton.SetTimer(0.5f, new XTimerMgr.ElapsedEventHandler(this.LateShowSweepFrame), (object)null);
        }

        private bool HasFirstRewardRedPoint()
        {
            TeamTowerData singleTowerData = this._doc.SingleTowerData;
            TeamTowerRewardTable.RowData[] teamTowerTable = this._doc.GetTeamTowerTable();
            int num1 = 0;
            if (singleTowerData.firstpassreward.Count > 0)
                num1 = singleTowerData.firstpassreward[singleTowerData.firstpassreward.Count - 1];
            int num2 = 0;
            for (int index = singleTowerData.maxlevel - 1; index >= 0; --index)
            {
                if (teamTowerTable[index].FirstPassReward.Count > 0 && (uint)teamTowerTable[index].preward > 0U)
                {
                    num2 = index + 1;
                    break;
                }
            }
            return num2 > num1;
        }

        private int GetRewardLevel()
        {
            TeamTowerData singleTowerData = this._doc.SingleTowerData;
            TeamTowerRewardTable.RowData[] teamTowerTable = this._doc.GetTeamTowerTable();
            int num = 0;
            if (singleTowerData.firstpassreward.Count > 0)
                num = singleTowerData.firstpassreward[singleTowerData.firstpassreward.Count - 1];
            for (int index = num + 1; index < singleTowerData.maxlevel; ++index)
            {
                if (teamTowerTable[index].FirstPassReward.Count > 0 && teamTowerTable[index].preward > 0)
                    return index + 1;
            }
            return singleTowerData.firstpassreward[singleTowerData.firstpassreward.Count - 1];
        }

        private int GetNextRewardLevel()
        {
            TeamTowerData singleTowerData = this._doc.SingleTowerData;
            TeamTowerRewardTable.RowData[] teamTowerTable = this._doc.GetTeamTowerTable();
            int num = 0;
            if (singleTowerData.firstpassreward.Count > 0)
                num = singleTowerData.firstpassreward[singleTowerData.firstpassreward.Count - 1];
            for (int index = num + 1; index < teamTowerTable.Length; ++index)
            {
                if (teamTowerTable[index].FirstPassReward.Count > 0 && teamTowerTable[index].preward > 0)
                    return index + 1;
            }
            return singleTowerData.firstpassreward[singleTowerData.firstpassreward.Count - 1];
        }

        private void OnInitFirstReward()
        {
            if (this.HasFirstRewardRedPoint())
            {
                this.uiBehaviour.mFirstPassRedPoint.SetVisible(true);
                this.uiBehaviour.mFirstPassLevel.SetText(string.Format(XStringDefineProxy.GetString("TEAMTOWER_LEVEL"), (object)this.GetRewardLevel()));
            }
            else
            {
                this.uiBehaviour.mFirstPassRedPoint.SetVisible(false);
                this.uiBehaviour.mFirstPassLevel.SetText(string.Format(XStringDefineProxy.GetString("TEAMTOWER_LEVEL"), (object)this.GetNextRewardLevel()));
            }
            if (!this.uiBehaviour.mFirstPassPanel.IsVisible())
                return;
            this.OnShowFirstPassReward((IXUIButton)null);
        }

        public bool OnShowFirstPassReward(IXUIButton btn)
        {
            this.uiBehaviour.mFirstPassPanel.SetVisible(true);
            TeamTowerRewardTable.RowData[] teamTowerTable = this._doc.GetTeamTowerTable();
            int num1;
            if (this.HasFirstRewardRedPoint())
            {
                num1 = this.GetRewardLevel();
                this.uiBehaviour.mFirstPassGet.gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                this.uiBehaviour.mFIrstPassCheck.gameObject.transform.localPosition = new Vector3(1000f, 0.0f, 0.0f);
                this.uiBehaviour.mFirstPassCongraThrough.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("TEAMTOWER_CONGRA_THROUGH"), (object)this.GetRewardLevel()));
            }
            else
            {
                num1 = this.GetNextRewardLevel();
                this.uiBehaviour.mFirstPassGet.gameObject.transform.localPosition = new Vector3(1000f, 0.0f, 0.0f);
                this.uiBehaviour.mFIrstPassCheck.gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                this.uiBehaviour.mFirstPassPlsThrough.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("TEAMTOWER_PLS_THROUGH"), (object)this.GetNextRewardLevel()));
            }
            this.uiBehaviour.mFirstPassReward.ReturnAll();
            SeqListRef<int> firstPassReward = teamTowerTable[num1 - 1].FirstPassReward;
            for (int index = 0; index < firstPassReward.Count; ++index)
            {
                GameObject gameObject = this.uiBehaviour.mFirstPassReward.FetchGameObject();
                XItem xitem = XBagDocument.MakeXItem(firstPassReward[index, 0]);
                xitem.itemCount = firstPassReward[index, 1];
                int num2 = index % 2 == 0 ? 1 : -1;
                int num3 = this.uiBehaviour.mFirstPassReward.TplWidth / 2;
                if (firstPassReward.Count % 2 == 1)
                    num3 = 0;
                XSingleton<XItemDrawerMgr>.singleton.DrawItem(gameObject.transform.FindChild("Item").gameObject, xitem);
                gameObject.transform.localPosition = new Vector3(this.uiBehaviour.mFirstPassReward.TplPos.x + (float)(num2 * ((index + 1) / 2) * this.uiBehaviour.mFirstPassReward.TplWidth) + (float)num3, this.uiBehaviour.mFirstPassReward.TplPos.y, this.uiBehaviour.mFirstPassReward.TplPos.z);
            }
            return true;
        }

        private void OnHideFirstPassReward(IXUISprite sp) => this.uiBehaviour.mFirstPassPanel.SetVisible(false);

        public bool OnGetFirstPassReward(IXUIButton btn)
        {
            if (this._is_getting_reward)
                return false;
            this._doc.GetFirstPassReward(this.GetRewardLevel());
            this._is_getting_reward = true;
            return true;
        }

        private bool OnGetDisableReward(IXUIButton btn)
        {
            XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("TEAMTOWER_CANOT_GET"), "fece00");
            return true;
        }

        public void OnGetFirstPassRewardRes(ErrorCode error)
        {
            this._is_getting_reward = false;
            if ((uint)error > 0U)
                XSingleton<UiUtility>.singleton.ShowSystemTip(error);
            else
                this._doc.GetSingleTowerActivityTop();
        }

        public void LateShowSweepFrame(object obj) => this.OnShowSweepFrame((IXUIButton)null);

        public bool OnShowSweepFrame(IXUIButton btn)
        {
            if (this._sweep_finished)
            {
                this.uiBehaviour.mSweepResult.SetVisible(true);
                return true;
            }
            if (this._doc.SingleTowerData.maxlevel == 0)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("TEAMTOWER_FIRST_NOT_SWEEP"), "fece00");
                return false;
            }
            if (this._doc.SingleTowerData.level == this._doc.SingleTowerData.maxlevel || this._sweep_finished)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("TEAMTOWER_LAST_NOT_SWEEP"), "fece00");
                return false;
            }
            TeamTowerData singleTowerData = this._doc.SingleTowerData;
            this.uiBehaviour.mSweepFrame.SetVisible(true);
            this.uiBehaviour.mSweepedLevel.SetText(string.Format(XStringDefineProxy.GetString("TEAMTOWER_REACH_LEVEL"), (object)singleTowerData.maxlevel));
            if (this._in_sweeping)
            {
                this.uiBehaviour.mSingleDoSweep.SetVisible(true);
                this.uiBehaviour.mDoubleSweep.SetVisible(false);
                this.uiBehaviour.mDoubleDoSweep.SetVisible(false);
                this.uiBehaviour.mSingleMoneyNum.SetText("20");
                this.uiBehaviour.mSingleMoneySign.SetSprite(XBagDocument.GetItemSmallIcon(7));
                this.SetTimeLeft((int)this._time_left);
            }
            else
            {
                this.uiBehaviour.mSingleDoSweep.SetVisible(false);
                this.uiBehaviour.mDoubleSweep.SetVisible(true);
                this.uiBehaviour.mDoubleDoSweep.SetVisible(true);
                this.uiBehaviour.mDoubleMoneyNum.SetText("20");
                this.uiBehaviour.mDoubleMoneySign.SetSprite(XBagDocument.GetItemSmallIcon(7));
                if (singleTowerData.maxlevel > singleTowerData.level)
                    this.SetTimeLeft((int)this._sweep_time * (singleTowerData.maxlevel - singleTowerData.level));
                else
                    this.SetTimeLeft((int)this._sweep_time * singleTowerData.maxlevel);
            }
            this.OnInitReward(this.uiBehaviour.mRewardPool);
            return true;
        }

        private void SetTimeLeft(int time)
        {
            int num1 = time / 3600;
            int num2 = (time - num1 * 3600) / 60;
            int num3 = time % 60;
            this.uiBehaviour.mSweepEstimateTime.SetText(string.Format("{0:D2}:{1:D2}:{2:D2}", (object)num1, (object)num2, (object)num3));
        }

        private void OnInitReward(XUIPool pool, float rewardalpha = 1f)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            TeamTowerRewardTable.RowData[] teamTowerTable = this._doc.GetTeamTowerTable();
            TeamTowerData singleTowerData = this._doc.SingleTowerData;
            int maxlevel = singleTowerData.maxlevel;
            int num1 = maxlevel < teamTowerTable.Length ? maxlevel : teamTowerTable.Length;
            for (int level = singleTowerData.level; level < num1; ++level)
            {
                TeamTowerRewardTable.RowData rowData = teamTowerTable[level];
                for (int index = 0; index < rowData.Reward.Count; ++index)
                {
                    if (dictionary.ContainsKey(rowData.Reward[index, 0]))
                        dictionary[rowData.Reward[index, 0]] += rowData.Reward[index, 1];
                    else
                        dictionary[rowData.Reward[index, 0]] = rowData.Reward[index, 1];
                }
            }
            List<int> intList = new List<int>((IEnumerable<int>)dictionary.Keys);
            pool.ReturnAll();
            bool flag = XActivityDocument.Doc.IsInnerDropTime(530U);
            for (int index = 0; index < intList.Count; ++index)
            {
                GameObject gameObject = pool.FetchGameObject();
                XItem xitem = XBagDocument.MakeXItem(intList[index]);
                xitem.itemCount = (int)((double)dictionary[intList[index]] * (double)rewardalpha + 0.5);
                if (gameObject.transform.FindChild("Item/Num").GetComponent("XUIPlayTween") is IXUITweenTool component2)
                {
                    component2.ResetTweenByGroup(true);
                    component2.PlayTween(true);
                }
                int num2 = index % 2 == 0 ? 1 : -1;
                int num3 = pool.TplWidth / 2;
                if (intList.Count % 2 == 1)
                    num3 = 0;
                XSingleton<XItemDrawerMgr>.singleton.DrawItem(gameObject.transform.FindChild("Item").gameObject, xitem);
                gameObject.transform.localPosition = new Vector3(pool.TplPos.x + (float)(num2 * ((index + 1) / 2) * pool.TplWidth) + (float)num3, pool.TplPos.y, pool.TplPos.z);
                Transform child = gameObject.transform.FindChild("Item/Double");
                if ((Object)child != (Object)null)
                    child.gameObject.SetActive(flag);
            }
        }

        private void OnInitMainReward()
        {
            Dictionary<int, int> dictionary1 = new Dictionary<int, int>();
            Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
            this.uiBehaviour.mMainRewardPool.ReturnAll();
            TeamTowerRewardTable.RowData[] teamTowerTable = this._doc.GetTeamTowerTable();
            int index1 = this._doc.SingleTowerData.level;
            if (index1 >= teamTowerTable.Length)
                index1 = teamTowerTable.Length - 1;
            TeamTowerRewardTable.RowData rowData = teamTowerTable[index1];
            if (rowData.preward == 0 && index1 >= this._doc.SingleTowerData.maxlevel)
            {
                for (int index2 = 0; index2 < rowData.FirstPassReward.Count; ++index2)
                {
                    if (rowData.FirstPassReward[index2, 1] > 0)
                    {
                        if (dictionary2.ContainsKey(rowData.FirstPassReward[index2, 0]))
                            dictionary2[rowData.FirstPassReward[index2, 0]] += rowData.FirstPassReward[index2, 1];
                        else
                            dictionary2[rowData.FirstPassReward[index2, 0]] = rowData.FirstPassReward[index2, 1];
                    }
                }
            }
            for (int index3 = 0; index3 < rowData.Reward.Count; ++index3)
            {
                if (rowData.Reward[index3, 1] > 0)
                {
                    if (dictionary1.ContainsKey(rowData.Reward[index3, 0]))
                        dictionary1[rowData.Reward[index3, 0]] += rowData.Reward[index3, 1];
                    else
                        dictionary1[rowData.Reward[index3, 0]] = rowData.Reward[index3, 1];
                }
            }
            List<int> intList1 = new List<int>((IEnumerable<int>)dictionary1.Keys);
            List<int> intList2 = new List<int>((IEnumerable<int>)dictionary2.Keys);
            int num1 = intList1.Count + intList2.Count;
            for (int index4 = 0; index4 < intList1.Count; ++index4)
            {
                GameObject go = this.uiBehaviour.mMainRewardPool.FetchGameObject();
                XItem realItem = XBagDocument.MakeXItem(intList1[index4]);
                realItem.itemCount = dictionary1[intList1[index4]];
                int num2 = this.uiBehaviour.mMainRewardPool.TplWidth / 2;
                if (num1 % 2 == 1)
                    num2 = 0;
                realItem.Description.ItemDrawer.DrawItem(go, realItem, true);
                go.transform.localPosition = new Vector3(this.uiBehaviour.mMainRewardPool.TplPos.x + (float)(index4 - (num1 - 1) / 2) * 1f * (float)this.uiBehaviour.mMainRewardPool.TplWidth - (float)num2, this.uiBehaviour.mMainRewardPool.TplPos.y, this.uiBehaviour.mMainRewardPool.TplPos.z);
                if (go.transform.FindChild("shoutong").GetComponent("XUISprite") is IXUISprite component2)
                    component2.SetVisible(false);
            }
            for (int index5 = 0; index5 < intList2.Count; ++index5)
            {
                int num3 = index5 + intList1.Count;
                GameObject go = this.uiBehaviour.mMainRewardPool.FetchGameObject();
                XItem realItem = XBagDocument.MakeXItem(intList2[index5]);
                realItem.itemCount = dictionary2[intList2[index5]];
                int num4 = this.uiBehaviour.mMainRewardPool.TplWidth / 2;
                if ((intList1.Count + intList2.Count) % 2 == 1)
                    num4 = 0;
                realItem.Description.ItemDrawer.DrawItem(go, realItem, true);
                go.transform.localPosition = new Vector3(this.uiBehaviour.mMainRewardPool.TplPos.x + (float)(num3 - (num1 - 1) / 2) * 1f * (float)this.uiBehaviour.mMainRewardPool.TplWidth - (float)num4, this.uiBehaviour.mMainRewardPool.TplPos.y, this.uiBehaviour.mMainRewardPool.TplPos.z);
                if (go.transform.FindChild("shoutong").GetComponent("XUISprite") is IXUISprite component5)
                    component5.SetVisible(true);
            }
            double attr = XSingleton<XEntityMgr>.singleton.Player.PlayerAttributes.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Total);
            SceneTable.RowData sceneData = XSingleton<XSceneMgr>.singleton.GetSceneData((uint)rowData.SceneID);
            double num5 = (double)sceneData.RecommendPower * 1.0;
            if (sceneData != null)
                num5 = (double)sceneData.RecommendPower * 1.0;
            double num6 = (attr - num5 * 1.0) / num5 * 1.0;
            if (num6 > 0.01)
            {
                this.uiBehaviour.mDemandFP.SetText(num5.ToString());
                this.uiBehaviour.mDemandFP.SetColor(Color.green);
            }
            else if (num6 > -0.01)
            {
                this.uiBehaviour.mDemandFP.SetText(string.Format("[e2ca9e]{0}[-]", (object)num5));
            }
            else
            {
                this.uiBehaviour.mDemandFP.SetText(num5.ToString());
                this.uiBehaviour.mDemandFP.SetColor(Color.red);
            }
        }

        public bool OnCloseSweep(IXUIButton btn)
        {
            this.uiBehaviour.mSweepFrame.SetVisible(false);
            return true;
        }

        public bool OnStartSweep(IXUIButton btn)
        {
            XSingleton<XClientNetwork>.singleton.Send((Rpc)new RpcC2G_SweepTower()
            {
                oArg = {
          hardLevel = this.GetHardLevel()
        }
            });
            return true;
        }

        public int GetHardLevel() => this._doc.ExpeditionId % 100 / 10 + 1;

        public void OnStartSweepRes(SweepTowerArg arg, int timeleft)
        {
            if (arg.cost == null || arg.cost.itemID == 0U)
            {
                this._time_left = (float)timeleft;
                this._in_sweeping = true;
                this._sweep_finished = false;
                this.DoCountDown((object)null);
                this._doc.SingleTowerData.sweepreqtime = Time.time;
                this.uiBehaviour.mSingleDoSweep.SetVisible(true);
                this.uiBehaviour.mDoubleSweep.SetVisible(false);
                this.uiBehaviour.mDoubleDoSweep.SetVisible(false);
            }
            else
            {
                this._time_left = 0.0f;
                this._in_sweeping = false;
                this._sweep_finished = true;
                this.OnCloseSweep((IXUIButton)null);
                this.OnQuickStartSweepRes();
            }
        }

        public bool OnQuickStartSweep(IXUIButton btn)
        {
            RpcC2G_SweepTower rpcC2GSweepTower = new RpcC2G_SweepTower()
            {
                oArg = {
          cost = new ItemBrief(),
          hardLevel = 1
        }
            };
            rpcC2GSweepTower.oArg.cost.itemID = 7U;
            XSingleton<XClientNetwork>.singleton.Send((Rpc)rpcC2GSweepTower);
            return true;
        }

        public void OnQuickStartSweepRes()
        {
            this._sweep_finished = true;
            this._in_sweeping = false;
            this._time_left = 0.0f;
            if (this._doc.SingleTowerData.level >= this._doc.GetTeamTowerTopLevel(1))
            {
                this._doc.ExpeditionId = this._doc.ExpeditionId - this._doc.ExpeditionId % 10 + 1;
                this._doc.OnRefreshDayCount(TeamLevelType.TeamLevelTeamTower, this._doc.GetDayCount(TeamLevelType.TeamLevelTeamTower) - 1);
            }
            this.OnCloseSweep((IXUIButton)null);
            this.OnShowSweepResultFrame();
            this._doc.GetSingleTowerActivityTop();
        }

        private bool OnReqResetSweep(IXUIButton btn)
        {
            if (this._doc.SingleTowerData.leftcount <= 0)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_TEAM_TOWER_DAYCOUNT);
                return false;
            }
            if (this._doc.SingleTowerData.level == 0)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("TEAMTOWER_FIRST_NOT_RESET"), "fece00");
                return false;
            }
            if (this._in_sweeping)
            {
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(true);
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(XStringDefineProxy.GetString("TEAMTOWER_IN_SWEEP"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_OK"));
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnCancelReset), new ButtonClickEventHandler(this.OnCancelReset));
            }
            else
            {
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(XStringDefineProxy.GetString("TEAMTOWER_RESET_INFO"), XStringDefineProxy.GetString("TEAMTOWER_RESET"), XStringDefineProxy.GetString("COMMON_CANCEL"));
                DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnResetSweep), new ButtonClickEventHandler(this.OnCancelReset));
            }
            return true;
        }

        private bool OnCancelReset(IXUIButton btn)
        {
            DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
            return true;
        }

        public bool OnResetSweep(IXUIButton btn)
        {
            this._doc.ResetSingleTower();
            return true;
        }

        public void OnResetSweepRes()
        {
            TeamTowerData singleTowerData = this._doc.SingleTowerData;
            singleTowerData.sweepfloor = 1;
            singleTowerData.sweeplefttime = 0;
            this._in_sweeping = false;
            this._sweep_finished = false;
            this._doc.ExpeditionId = this._doc.ExpeditionId - this._doc.ExpeditionId % 10 + 1;
            XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAMTOWER_RESETOK"), "fece00");
            this._doc.GetSingleTowerActivityTop();
        }

        public bool OnEnterBattle(IXUIButton btn)
        {
            TeamTowerRewardTable.RowData[] teamTowerTable = this._doc.GetTeamTowerTable();
            if (this._doc.SingleTowerData.level >= teamTowerTable.Length)
            {
                XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TEAMTOWER_REACH_TOP"), "fece00");
                return false;
            }
            TeamTowerRewardTable.RowData rowData = teamTowerTable[this._doc.SingleTowerData.level];
            XSingleton<XClientNetwork>.singleton.Send((Protocol)new PtcC2G_EnterSceneReq()
            {
                Data = {
          sceneID = (uint) rowData.SceneID
        }
            });
            return true;
        }

        public void DoCountDown(object obj)
        {
            TeamTowerData singleTowerData = this._doc.SingleTowerData;
            this._time_left = (float)singleTowerData.sweeplefttime - (Time.time - singleTowerData.sweepreqtime);
            if (this._count_timer > 0U)
                XSingleton<XTimerMgr>.singleton.KillTimer(this._count_timer);
            if ((double)this._time_left <= 0.0)
            {
                this._time_left = 0.0f;
                this._in_sweeping = false;
                this._sweep_finished = true;
                this.SetTimeLeft(0);
                this.OnCloseSweep((IXUIButton)null);
                this._doc.GetSingleTowerActivityTop();
            }
            else
            {
                this.SetTimeLeft((int)this._time_left);
                this._count_timer = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.DoCountDown), (object)null);
            }
        }

        private void InitTowerMap(int curfloor = 1)
        {
            TeamTowerRewardTable.RowData[] teamTowerTable = this._doc.GetTeamTowerTable();
            this._tower_max_floor = teamTowerTable.Length;
            int maxlevel = this._doc.SingleTowerData.maxlevel;
            int num1 = maxlevel + 5 >= this._tower_max_floor ? this._tower_max_floor : maxlevel + 5;
            int num2 = num1 % 2 == 0 ? num1 : num1 + 1;
            int num3 = num2 / 2 - 1;
            IXUILabel component1 = this.uiBehaviour.transform.FindChild("Bg/Tower/TowerBase/Floor").GetComponent("XUILabel") as IXUILabel;
            GameObject gameObject1 = this.uiBehaviour.transform.FindChild("Bg/Tower/TowerBase/Floor/Current/Normal/UI_hasd_gk").gameObject;
            component1.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("TEAMTOWER_LEVEL"), (object)1));
            if (this._doc.SingleTowerData.level + 1 == 1)
                gameObject1.SetActive(true);
            else
                gameObject1.SetActive(false);
            (this.uiBehaviour.transform.FindChild("Bg/Tower/TowerBase/Floor1").GetComponent("XUILabel") as IXUILabel).SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("TEAMTOWER_LEVEL"), (object)2));
            GameObject gameObject2 = this.uiBehaviour.transform.FindChild("Bg/Tower/TowerBase/Floor1/Current/Normal/UI_hasd_gk").gameObject;
            if (this._doc.SingleTowerData.level + 1 == 2)
                gameObject2.SetActive(true);
            else
                gameObject2.SetActive(false);
            (this.uiBehaviour.transform.FindChild("Bg/Tower/TowerBase/Floor/FirstBlood").GetComponent("XUISprite") as IXUISprite).SetVisible(false);
            IXUISprite component2 = this.uiBehaviour.transform.FindChild("Bg/Tower/TowerBase/Floor").GetComponent("XUISprite") as IXUISprite;
            TeamTowerRewardTable.RowData rowData = teamTowerTable[0];
            if (curfloor >= 1)
                component2.SetEnabled(false);
            else
                component2.SetEnabled(true);
            IXUISprite component3 = this.uiBehaviour.transform.FindChild("Bg/Tower/TowerBase/Floor1").GetComponent("XUISprite") as IXUISprite;
            (this.uiBehaviour.transform.FindChild("Bg/Tower/TowerBase/Floor1/FirstBlood").GetComponent("XUISprite") as IXUISprite).SetVisible(false);
            rowData = teamTowerTable[1];
            if (curfloor >= 2)
                component3.SetEnabled(false);
            else
                component3.SetEnabled(true);
            this.uiBehaviour.mTowerPool.ReturnAll();
            for (int index = 0; index < num3; ++index)
            {
                GameObject gameObject3 = this.uiBehaviour.mTowerPool.FetchGameObject();
                Vector3 vector3 = new Vector3(this.uiBehaviour.mTowerPool.TplPos.x, this.uiBehaviour.mTowerPool.TplPos.y + (float)((this.uiBehaviour.mTowerPool.TplHeight - 60) * index), this.uiBehaviour.mTowerPool.TplPos.z);
                gameObject3.transform.localPosition = vector3;
                rowData = teamTowerTable[(index + 1) * 2];
                (gameObject3.transform.FindChild("Floor").GetComponent("XUILabel") as IXUILabel).SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("TEAMTOWER_LEVEL"), (object)((index + 1) * 2 + 1)));
                IXUISprite component4 = gameObject3.transform.FindChild("Floor").GetComponent("XUISprite") as IXUISprite;
                (gameObject3.transform.FindChild("Floor/FirstBlood").GetComponent("XUISprite") as IXUISprite).SetVisible(false);
                GameObject gameObject4 = gameObject3.transform.FindChild("Floor/Current/Normal/UI_hasd_gk").gameObject;
                if (this._doc.SingleTowerData.level + 1 == (index + 1) * 2 + 1)
                    gameObject4.SetActive(true);
                else
                    gameObject4.SetActive(false);
                if (curfloor >= (index + 1) * 2 + 1)
                    component4.SetEnabled(false);
                else
                    component4.SetEnabled(true);
                (gameObject3.transform.FindChild("Floor1").GetComponent("XUILabel") as IXUILabel).SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("TEAMTOWER_LEVEL"), (object)((index + 1) * 2 + 2)));
                (gameObject3.transform.FindChild("Floor1/FirstBlood").GetComponent("XUISprite") as IXUISprite).SetVisible(false);
                rowData = teamTowerTable[(index + 1) * 2 + 1];
                IXUISprite component5 = gameObject3.transform.FindChild("Floor1").GetComponent("XUISprite") as IXUISprite;
                if (curfloor >= (index + 1) * 2 + 2)
                    component5.SetEnabled(false);
                else
                    component5.SetEnabled(true);
                GameObject gameObject5 = gameObject3.transform.FindChild("Floor1/Current/Normal/UI_hasd_gk").gameObject;
                if (this._doc.SingleTowerData.level + 1 == (index + 1) * 2 + 2)
                    gameObject5.SetActive(true);
                else
                    gameObject5.SetActive(false);
            }
            this.uiBehaviour.mScroll.NeedRecalcBounds();
            this.uiBehaviour.mScroll.SetPosition((float)(1.0 - (double)curfloor * 1.0 / (double)num2));
        }

        private bool OnGetReward(IXUIButton btn)
        {
            this._doc.GetSweepSingleTowerReward();
            return true;
        }

        public void OnGotReward()
        {
            this.uiBehaviour.mSweepResult.SetVisible(false);
            this._doc.GetSingleTowerActivityTop();
        }

        public void OnShowSweepResultFrame()
        {
            this.uiBehaviour.mSweepResult.SetVisible(true);
            this.uiBehaviour.mRewardFx.SetVisible(false);
            this.uiBehaviour.mEffect.SetActive(false);
            this.OnRefreshResult();
        }

        public void OnHideSweepResultFrame() => this.uiBehaviour.mSweepResult.SetVisible(false);

        private bool OnRefreshReward(IXUIButton btn)
        {
            this.uiBehaviour.mRewardRefresh.SetEnable(false);
            this.uiBehaviour.mRewardGet.SetEnable(false);
            this._doc.RefreshSingleSweepReward();
            return true;
        }

        public void OnStartPlayRefreshResultEffect(ErrorCode code, int res)
        {
            if ((uint)code > 0U)
            {
                this.uiBehaviour.mRewardRefresh.SetEnable(true);
                this.uiBehaviour.mRewardGet.SetEnable(true);
            }
            else
            {
                this._effect_result = (float)res / 100f;
                ++this._doc.SingleTowerData.refreshcount;
                if (this._doc.SingleTowerData.refreshcount >= this._refresh_cost.Count)
                    this._doc.SingleTowerData.refreshcount = this._refresh_cost.Count;
                this.uiBehaviour.mRewardFx.SetVisible(true);
                this.uiBehaviour.mEffect.SetActive(false);
                this.uiBehaviour.mRewardFreeTime.SetText(string.Format("{0}/{1}", (object)(this._refresh_cost.Count - this._doc.SingleTowerData.refreshcount), (object)this._refresh_cost.Count));
                int index = this._doc.SingleTowerData.refreshcount >= this._refresh_cost.Count ? this._refresh_cost.Count - 1 : this._doc.SingleTowerData.refreshcount;
                if (this._refresh_cost[index] == 0)
                {
                    this.uiBehaviour.mRewardFreeLabel.SetVisible(true);
                    this.uiBehaviour.mRewardMoneyNum.SetVisible(false);
                }
                else
                {
                    this.uiBehaviour.mRewardFreeLabel.SetVisible(false);
                    this.uiBehaviour.mRewardMoneyNum.SetVisible(true);
                    this.uiBehaviour.mRewardMoneyNum.SetText(this._refresh_cost[index].ToString());
                    this.uiBehaviour.mRewardMoneySign.SetSprite(XBagDocument.GetItemSmallIcon(this._refresh_money[index]));
                }
                this.state = ActivityTeamTowerSingleDlg.State.BEGIN;
                this.timePass.LeftTime = 10f;
            }
        }

        private int GetFrame(uint index)
        {
            if (this.frames.Count <= 0)
                return 15;
            return (long)this.frames.Count <= (long)index ? this.frames[this.frames.Count - 1] : this.frames[(int)index];
        }

        public void OnRefreshReverseCount() => this.OnRefreshSweepInfo();

        public void RefreshAlpha()
        {
            int num = XSingleton<XCommon>.singleton.RandomInt(0, this._random_list.Count);
            this.uiBehaviour.mRewardAlpha.SetText(string.Format("{0:F1}{1}", (object)this._random_list[num], (object)XSingleton<XStringTable>.singleton.GetString("FOLD")));
            this.uiBehaviour.mRewardAlpha.SetColor(XSingleton<UiUtility>.singleton.GetItemQualityColor(num));
        }

        private void PlayAlphaFinished()
        {
            this.uiBehaviour.mRewardAlpha.SetText(string.Format("{0:F1}{1}", (object)this._effect_result, (object)XSingleton<XStringTable>.singleton.GetString("FOLD")));
            for (int index = 0; index < this._random_list.Count; ++index)
            {
                if ((double)this._random_list[index] == (double)this._effect_result)
                    this.uiBehaviour.mRewardAlpha.SetColor(XSingleton<UiUtility>.singleton.GetItemQualityColor(index));
            }
            this.uiBehaviour.mRewardFx.SetVisible(false);
            this.OnInitReward(this.uiBehaviour.mRewardFramePool, this._effect_result);
            this.uiBehaviour.mRewardRefresh.SetEnable(true);
            this.uiBehaviour.mRewardGet.SetEnable(true);
            this.uiBehaviour.mEffect.SetActive(true);
        }

        public void OnRefreshResult()
        {
            TeamTowerData singleTowerData = this._doc.SingleTowerData;
            this.uiBehaviour.mRewardLevel.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("TEAMTOWER_REACH_LEVEL"), (object)(singleTowerData.maxlevel == 0 ? 1 : singleTowerData.maxlevel)));
            this.uiBehaviour.mRewardAlpha.SetText(string.Format("{0:F1}{1}", (object)1, (object)XSingleton<XStringTable>.singleton.GetString("FOLD")));
            this.uiBehaviour.mRewardAlpha.SetColor(XSingleton<UiUtility>.singleton.GetItemQualityColor(0));
            this.uiBehaviour.mRewardFreeTime.SetText(string.Format("{0}/{1}", (object)(this._refresh_cost.Count - this._doc.SingleTowerData.refreshcount), (object)this._refresh_cost.Count));
            int index = this._doc.SingleTowerData.refreshcount >= this._refresh_cost.Count ? this._refresh_cost.Count - 1 : this._doc.SingleTowerData.refreshcount;
            if (this._refresh_cost[index] == 0)
            {
                this.uiBehaviour.mRewardFreeLabel.SetVisible(true);
                this.uiBehaviour.mRewardMoneyNum.SetVisible(false);
            }
            else
            {
                this.uiBehaviour.mRewardFreeLabel.SetVisible(false);
                this.uiBehaviour.mRewardMoneyNum.SetVisible(true);
                this.uiBehaviour.mRewardMoneyNum.SetText(this._refresh_cost[index].ToString());
                this.uiBehaviour.mRewardMoneySign.SetSprite(XBagDocument.GetItemSmallIcon(this._refresh_money[index]));
            }
            this.OnInitReward(this.uiBehaviour.mRewardFramePool);
        }

        public override void OnUpdate()
        {
            if (this.state == ActivityTeamTowerSingleDlg.State.BEGIN)
            {
                this._play_count = 0;
                this._acc_time = 0;
                this.timePass.LeftTime = 10f;
                this.state = ActivityTeamTowerSingleDlg.State.PLAY;
            }
            else if (this.state == ActivityTeamTowerSingleDlg.State.PLAY)
            {
                this.timePass.Update();
                this._acc_time = (int)((double)this.timePass.PassTime * 1000.0);
                if (this._acc_time <= this.GetFrame((uint)this._play_count))
                    return;
                this.timePass.LeftTime = 1f;
                this._acc_time = 0;
                ++this._play_count;
                this.RefreshAlpha();
                if (this._play_count >= this._all_count)
                {
                    this._play_count = 0;
                    this.state = ActivityTeamTowerSingleDlg.State.Idle;
                }
            }
            else
            {
                if (this.state != ActivityTeamTowerSingleDlg.State.Idle)
                    return;
                this.state = ActivityTeamTowerSingleDlg.State.None;
                this.PlayAlphaFinished();
            }
        }

        public enum State
        {
            BEGIN,
            PLAY,
            Idle,
            FADE,
            None,
        }
    }
}
