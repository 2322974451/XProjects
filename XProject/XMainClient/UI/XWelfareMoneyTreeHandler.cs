using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XWelfareMoneyTreeHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/Welfare/GoldTree";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
			this._status_info = base.PanelObject.transform.FindChild("Status").gameObject;
			this._once_info = base.PanelObject.transform.FindChild("Once").gameObject;
			this._ten_info = base.PanelObject.transform.FindChild("Ten").gameObject;
			this._free_info = base.PanelObject.transform.FindChild("Free").gameObject;
			this._gold_info = base.PanelObject.transform.FindChild("Gold").gameObject;
			this._fx_gold_tree = base.PanelObject.transform.FindChild("FX/UI_Goldtree").gameObject;
			this._fx_gold_tree_putong = base.PanelObject.transform.FindChild("FX/UI_Goldtree_putong").gameObject;
			this._fx_gold_tree_baoji = base.PanelObject.transform.FindChild("FX/UI_Goldtree_baoji").gameObject;
			this._free_time = base.PanelObject.transform.FindChild("Status/FreeTime").gameObject;
			this._free_btn = (base.PanelObject.transform.FindChild("Free/Btn_ExchangeOne").GetComponent("XUIButton") as IXUIButton);
			this._free_btn.ID = 1UL;
			this._free_count_free = (base.PanelObject.transform.FindChild("Free/Cash/RemainTime").GetComponent("XUILabel") as IXUILabel);
			this._left_count = (base.PanelObject.transform.FindChild("Status/PaidTime").GetComponent("XUILabel") as IXUILabel);
			this._free_count = (base.PanelObject.transform.FindChild("Status/FreeTime/RemainTime").GetComponent("XUILabel") as IXUILabel);
			this._next_reset_info = (base.PanelObject.transform.FindChild("Status/FreeTime/RemainTime").GetComponent("XUILabel") as IXUILabel);
			this._free_left_time = (base.PanelObject.transform.FindChild("Status/FreeTime/Time").GetComponent("XUILabel") as IXUILabel);
			this._refresh_time = (base.PanelObject.transform.FindChild("Status/RefreshTime").GetComponent("XUILabel") as IXUILabel);
			this._once_cost = (base.PanelObject.transform.FindChild("Once/Cash/Num").GetComponent("XUILabel") as IXUILabel);
			this._once_btn = (base.PanelObject.transform.FindChild("Once/Btn_ExchangeOne").GetComponent("XUIButton") as IXUIButton);
			this._once_btn.ID = 2UL;
			this._ten_cost = (base.PanelObject.transform.FindChild("Ten/Cash/Num").GetComponent("XUILabel") as IXUILabel);
			this._ten_btn = (base.PanelObject.transform.FindChild("Ten/Btn_ExchangeTen").GetComponent("XUIButton") as IXUIButton);
			this._ten_btn.ID = 3UL;
			this._gold_num = (base.PanelObject.transform.FindChild("Gold/Icon/Number").GetComponent("XUILabel") as IXUILabel);
			this._critical_times = (base.PanelObject.transform.FindChild("Gold/Critical/Times1").GetComponent("XUILabel") as IXUILabel);
			this._critical = (base.PanelObject.transform.FindChild("Gold/Critical").GetComponent("XUILabel") as IXUILabel);
			this._guide = (base.PanelObject.transform.FindChild("Help/Guide").GetComponent("XUILabel") as IXUILabel);
			this._tween1 = (base.PanelObject.transform.FindChild("Gold").GetComponent("XUIPlayTween") as IXUITweenTool);
			this._tween2 = (base.PanelObject.transform.FindChild("Gold/Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
			this._tween3 = (base.PanelObject.transform.FindChild("Gold/Icon").GetComponent("XUIPlayTween") as IXUITweenTool);
			this._tween4 = (base.PanelObject.transform.FindChild("Gold/Critical").GetComponent("XUIPlayTween") as IXUITweenTool);
			this._tween5 = (base.PanelObject.transform.FindChild("Gold/Critical/Times1").GetComponent("XUIPlayTween") as IXUITweenTool);
			this._tween6 = (base.PanelObject.transform.FindChild("Gold/Critical/T").GetComponent("XUIPlayTween") as IXUITweenTool);
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("GoldClickConsume");
			this._cost_count = int.Parse(value.Split(new char[]
			{
				'='
			})[1]);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._gold_info.SetActive(false);
			this.ShowPaid();
			this.ReqMoneyTree(0U, 1U);
			this._guide.SetText(XSingleton<XStringTable>.singleton.GetString("MoneyBox"));
			XShowGetItemDocument specificDocument = XDocuments.GetSpecificDocument<XShowGetItemDocument>(XShowGetItemDocument.uuID);
			specificDocument.bBlock = true;
		}

		protected override void OnHide()
		{
			base.OnHide();
			bool flag = this._tick_token > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._tick_token);
			}
			this._tick_token = 0U;
			XShowGetItemDocument specificDocument = XDocuments.GetSpecificDocument<XShowGetItemDocument>(XShowGetItemDocument.uuID);
			specificDocument.ClearItemQueue();
			specificDocument.bBlock = false;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._play_token);
			this._play_token = 0U;
		}

		public override void RegisterEvent()
		{
			this._free_btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReqGoldClick));
			this._once_btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReqGoldClick));
			this._ten_btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnReqGoldClick));
			base.RegisterEvent();
		}

		public override void RefreshData()
		{
			MoneyTreeData welfareMoneyTreeData = this._doc.WelfareMoneyTreeData;
			bool flag = welfareMoneyTreeData.left_time == 0U && welfareMoneyTreeData.free_all_count - welfareMoneyTreeData.free_count > 0U && welfareMoneyTreeData.free_count + welfareMoneyTreeData.count < welfareMoneyTreeData.all_count;
			if (flag)
			{
				this.ShowFree();
			}
			else
			{
				this.ShowPaid();
			}
			bool flag2 = this._req_type > 0U;
			if (flag2)
			{
				bool flag3 = this._req_type == 1U;
				if (flag3)
				{
					bool flag4 = this._doc.WelfareMoneyTreeData.result.Count > 0;
					if (flag4)
					{
						this.StartPlayTween(this._doc.WelfareMoneyTreeData.result[0]);
					}
					else
					{
						this.StartPlayTween(1f);
					}
					this.StartPlayFx("goldtreeputong");
					this._critical.SetVisible(false);
				}
				else
				{
					bool flag5 = this._req_type == 2U;
					if (flag5)
					{
						this._res.Clear();
						for (int i = 0; i < this._doc.WelfareMoneyTreeData.result.Count; i++)
						{
							this._res.Add(this._doc.WelfareMoneyTreeData.result[i]);
						}
						this._play_index = 0;
						bool flag6 = this._res.Count <= 1;
						if (flag6)
						{
							this.StartPlayFx("goldtreeputong");
							this._critical.SetVisible(false);
						}
						else
						{
							this.StartPlayFx("goldtreebaoji");
							this._critical.SetVisible(true);
						}
						bool flag7 = this._res.Count > 0;
						if (flag7)
						{
							this.StartPlayResult(null);
						}
						else
						{
							this.StartPlayTween(1f);
						}
					}
				}
				this._req_type = 0U;
			}
		}

		private void ShowFree()
		{
			this._once_info.SetActive(false);
			this._ten_info.SetActive(false);
			this._free_info.SetActive(true);
			this._status_info.SetActive(false);
			this._fx_gold_tree_putong.SetActive(false);
			this._fx_gold_tree_baoji.SetActive(false);
			this._free_time.SetActive(false);
			this._left_count.SetVisible(false);
			this._refresh_time.SetVisible(false);
			this._free_left_time.SetVisible(false);
			this._free_count_free.SetText(string.Format("({0}/{1})", this._doc.WelfareMoneyTreeData.free_all_count - this._doc.WelfareMoneyTreeData.free_count, this._doc.WelfareMoneyTreeData.free_all_count));
		}

		private void ShowPaid()
		{
			this._once_info.SetActive(true);
			this._ten_info.SetActive(true);
			this._free_info.SetActive(false);
			this._status_info.SetActive(true);
			this._fx_gold_tree_putong.SetActive(false);
			this._fx_gold_tree_baoji.SetActive(false);
			this._left_count.SetVisible(true);
			this._once_cost.SetText(this._cost_count.ToString());
			this._ten_cost.SetText((this._cost_count * 10).ToString());
			bool flag = this._doc.WelfareMoneyTreeData.all_count <= this._doc.WelfareMoneyTreeData.count + this._doc.WelfareMoneyTreeData.free_count;
			if (flag)
			{
				this._left_count.SetVisible(false);
				this._refresh_time.SetVisible(true);
			}
			else
			{
				this._left_count.SetVisible(true);
				this._refresh_time.SetVisible(false);
			}
			this._free_left_time.SetVisible(true);
			this._time_left = this._doc.WelfareMoneyTreeData.left_time;
			bool flag2 = this._time_left > 0f && this._time_left <= 10000f;
			if (flag2)
			{
				this._free_time.SetActive(true);
				this.DoCountDown(null);
			}
			else
			{
				this._free_time.SetActive(false);
			}
			int num = (int)(this._doc.WelfareMoneyTreeData.all_count - this._doc.WelfareMoneyTreeData.count - this._doc.WelfareMoneyTreeData.free_count);
			num = ((num >= 0) ? num : 0);
			this._left_count.SetText(string.Format("({0}/{1})", num, this._doc.WelfareMoneyTreeData.all_count));
		}

		private void ReqMoneyTree(uint type, uint num)
		{
			this._req_type = type;
			RpcC2G_GoldClick rpcC2G_GoldClick = new RpcC2G_GoldClick();
			rpcC2G_GoldClick.oArg.type = type;
			rpcC2G_GoldClick.oArg.count = num;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_GoldClick);
		}

		private void SetTimeLeft(int time)
		{
			int num = time / 3600;
			int num2 = (time - num * 3600) / 60;
			int num3 = time % 60;
			string text = string.Format("{0:D2}:{1:D2}", num2, num3);
			this._free_left_time.SetText(text);
		}

		private bool OnReqGoldClick(IXUIButton btn)
		{
			bool flag = btn.ID == 1UL;
			if (flag)
			{
				this.ReqMoneyTree(1U, 1U);
			}
			else
			{
				bool flag2 = btn.ID == 2UL;
				if (flag2)
				{
					this.ReqMoneyTree(2U, 1U);
				}
				else
				{
					bool flag3 = btn.ID == 3UL;
					if (flag3)
					{
						this.ReqMoneyTree(2U, 10U);
					}
				}
			}
			return true;
		}

		public void DoCountDown(object obj)
		{
			MoneyTreeData welfareMoneyTreeData = this._doc.WelfareMoneyTreeData;
			this._time_left = welfareMoneyTreeData.left_time - (Time.time - welfareMoneyTreeData.req_time);
			bool flag = this._tick_token > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._tick_token);
			}
			bool flag2 = this._time_left <= 0f;
			if (flag2)
			{
				this._time_left = 0f;
				this.SetTimeLeft(0);
				bool flag3 = this._doc.WelfareMoneyTreeData.free_all_count - this._doc.WelfareMoneyTreeData.free_count > 0U;
				if (flag3)
				{
					this.ShowFree();
				}
			}
			else
			{
				this.SetTimeLeft((int)this._time_left);
				this._tick_token = XSingleton<XTimerMgr>.singleton.SetTimer(1f, new XTimerMgr.ElapsedEventHandler(this.DoCountDown), null);
			}
		}

		public void StartPlayFx(string fxname)
		{
			this._fx_gold_tree.SetActive(false);
			this._fx_gold_tree_baoji.SetActive(false);
			this._fx_gold_tree_putong.SetActive(false);
			bool flag = fxname == "goldtree";
			if (flag)
			{
				this._fx_gold_tree.SetActive(true);
			}
			else
			{
				bool flag2 = fxname == "goldtreeputong";
				if (flag2)
				{
					this._fx_gold_tree_putong.SetActive(true);
				}
				else
				{
					bool flag3 = fxname == "goldtreebaoji";
					if (flag3)
					{
						this._fx_gold_tree_baoji.SetActive(true);
					}
				}
			}
		}

		public void StartPlayTween(float alpha)
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				int num = int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("GoldClickBaseCount"));
				this._gold_num.SetText(((int)((float)num * alpha)).ToString());
				this._critical_times.SetText(alpha.ToString());
				bool flag2 = alpha <= 1f;
				if (flag2)
				{
					this._critical.SetVisible(false);
				}
				else
				{
					this._critical.SetVisible(true);
				}
				this._gold_info.SetActive(true);
				this._tween1.ResetTweenByGroup(true, 0);
				this._tween1.PlayTween(true, -1f);
				this._tween2.ResetTweenByGroup(true, 0);
				this._tween2.PlayTween(true, -1f);
				this._tween3.ResetTweenByGroup(true, 0);
				this._tween3.PlayTween(true, -1f);
				this._tween4.ResetTweenByGroup(true, 0);
				this._tween4.PlayTween(true, -1f);
				this._tween5.ResetTweenByGroup(true, 0);
				this._tween5.PlayTween(true, -1f);
				this._tween6.ResetTweenByGroup(true, 0);
				this._tween6.PlayTween(true, -1f);
			}
		}

		public void StartPlayResult(object obj)
		{
			bool flag = this._play_token > 0U;
			if (flag)
			{
				XSingleton<XTimerMgr>.singleton.KillTimer(this._play_token);
			}
			bool flag2 = this._play_index < this._res.Count;
			if (flag2)
			{
				this.StartPlayTween(this._res[this._play_index]);
				this._play_index++;
				this._play_token = XSingleton<XTimerMgr>.singleton.SetTimer(0.8f, new XTimerMgr.ElapsedEventHandler(this.StartPlayResult), null);
			}
		}

		private XWelfareDocument _doc;

		private uint _tick_token = 0U;

		private uint _req_type = 0U;

		private float _time_left;

		private List<uint> _res = new List<uint>();

		private int _play_index = 0;

		private uint _play_token = 0U;

		private int _cost_count = 100;

		private GameObject _status_info;

		private GameObject _once_info;

		private GameObject _ten_info;

		private GameObject _free_info;

		private GameObject _gold_info;

		private GameObject _fx_gold_tree;

		private GameObject _free_time;

		private GameObject _fx_gold_tree_putong;

		private GameObject _fx_gold_tree_baoji;

		private IXUIButton _free_btn;

		private IXUILabel _free_count_free;

		private IXUILabel _left_count;

		private IXUILabel _free_count;

		private IXUILabel _next_reset_info;

		private IXUILabel _refresh_time;

		private IXUILabel _free_left_time;

		private IXUILabel _once_cost;

		private IXUIButton _once_btn;

		private IXUILabel _ten_cost;

		private IXUIButton _ten_btn;

		private IXUILabel _gold_num;

		private IXUILabel _critical_times;

		private IXUILabel _critical;

		private IXUILabel _guide;

		private IXUITweenTool _tween1;

		private IXUITweenTool _tween2;

		private IXUITweenTool _tween3;

		private IXUITweenTool _tween4;

		private IXUITweenTool _tween5;

		private IXUITweenTool _tween6;
	}
}
