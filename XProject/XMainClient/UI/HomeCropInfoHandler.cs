using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class HomeCropInfoHandler : DlgHandlerBase
	{

		private bool m_bIsPlayingAction
		{
			get
			{
				return DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.IsPlayingAction;
			}
			set
			{
				DlgBase<HomePlantDlg, HomePlantBehaviour>.singleton.IsPlayingAction = value;
			}
		}

		protected override string FileName
		{
			get
			{
				return "Home/SeedInfo";
			}
		}

		protected override void Init()
		{
			this.m_tittleLab = (base.PanelObject.transform.FindChild("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_cdLab = (base.PanelObject.transform.FindChild("CD").GetComponent("XUILabel") as IXUILabel);
			this.m_cancleBtn = (base.PanelObject.transform.FindChild("BtnCancelPlant").GetComponent("XUIButton") as IXUIButton);
			this.m_cancleBtn.gameObject.SetActive(true);
			Transform transform = base.PanelObject.transform.FindChild("Info");
			this.m_harvestNeedTimeLab = (transform.FindChild("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_statueLab = (transform.FindChild("status").GetComponent("XUILabel") as IXUILabel);
			this.m_harvestLab = (transform.FindChild("harvest").GetComponent("XUILabel") as IXUILabel);
			this.m_growUpLab = (transform.FindChild("GrowUp").GetComponent("XUILabel") as IXUILabel);
			this.m_growUpStateLab = (transform.FindChild("GrowUp/T").GetComponent("XUILabel") as IXUILabel);
			this.m_growthSlider = (transform.FindChild("Bar").GetComponent("XUISlider") as IXUISlider);
			transform = transform.FindChild("Log");
			IXUILabel item = transform.FindChild("0").GetComponent("XUILabel") as IXUILabel;
			this.m_homeLogs.Add(item);
			item = (transform.FindChild("1").GetComponent("XUILabel") as IXUILabel);
			this.m_homeLogs.Add(item);
			item = (transform.FindChild("2").GetComponent("XUILabel") as IXUILabel);
			this.m_homeLogs.Add(item);
			this.m_itemGo = base.PanelObject.transform.FindChild("Item").gameObject;
			this.m_operateBtnGo = base.PanelObject.transform.FindChild("OperateBtn").gameObject;
			this.m_fertilizerBtn = (this.m_operateBtnGo.transform.FindChild("FertilizerBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_disinsectionBtn = (this.m_operateBtnGo.transform.FindChild("DisinsectionBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_wateringBtn = (this.m_operateBtnGo.transform.FindChild("WateringBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_harvestBtn = (base.PanelObject.transform.FindChild("BtnHarvest").GetComponent("XUIButton") as IXUIButton);
			this.m_stealBtn = (base.PanelObject.transform.FindChild("BtnSteal").GetComponent("XUIButton") as IXUIButton);
			this.m_doc = HomePlantDocument.Doc;
			base.Init();
		}

		public override void RegisterEvent()
		{
			this.m_harvestBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickHarvestBtn));
			this.m_stealBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickStealBtn));
			this.m_fertilizerBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickFertilizerBtn));
			this.m_disinsectionBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickDisinsectionBtn));
			this.m_wateringBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickWateringBtn));
			this.m_cancleBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickCancleBtn));
			base.RegisterEvent();
		}

		protected override void OnShow()
		{
			this.m_bIsPlayingAction = false;
			this.Fillcontent();
			base.OnShow();
		}

		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token1);
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.Player.PlayStateBack();
			}
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public override void OnUnload()
		{
			base.OnUnload();
		}

		public void RefreshUI()
		{
			this.Fillcontent();
		}

		private void Fillcontent()
		{
			this.m_cancleBtn.gameObject.SetActive(false);
			this.m_farmLand = this.m_doc.GetFarmland(this.m_doc.CurFarmlandId);
			bool flag = this.m_farmLand == null || this.m_farmLand.IsFree;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("data error,the farm is null or Free!", null, null, null, null, null);
			}
			else
			{
				switch (this.m_doc.HomeType)
				{
				case HomeTypeEnum.MyHome:
					this.m_cancleBtn.gameObject.SetActive(this.m_farmLand.Stage != GrowStage.Ripe);
					break;
				case HomeTypeEnum.OtherHome:
					this.m_cancleBtn.gameObject.SetActive(false);
					break;
				case HomeTypeEnum.GuildHome:
				{
					bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null && this.m_farmLand.OwnerRoleId == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag2)
					{
						this.m_cancleBtn.gameObject.SetActive(true);
					}
					else
					{
						this.m_cancleBtn.gameObject.SetActive(false);
					}
					break;
				}
				default:
					this.m_cancleBtn.gameObject.SetActive(false);
					break;
				}
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_itemGo, this.m_farmLand.Row.PlantID[0], 0, false);
				IXUISprite ixuisprite = this.m_itemGo.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)this.m_farmLand.Row.PlantID[0]);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
				this.m_tittleLab.SetText(this.m_farmLand.Row.PlantName);
				this.m_growUpLab.SetText(string.Format("{0}%", Math.Round((double)(this.m_farmLand.GrowSpeed * 100f))));
				bool flag3 = this.m_farmLand.State > CropState.None;
				if (flag3)
				{
					this.m_growUpStateLab.SetVisible(true);
				}
				else
				{
					this.m_growUpStateLab.SetVisible(false);
				}
				this.m_growthSlider.Value = this.m_farmLand.GrowPercent;
				this.m_harvestLab.SetText(this.m_farmLand.Row.PlantID[1].ToString());
				bool flag4 = this.m_farmLand.Stage != GrowStage.Ripe;
				if (flag4)
				{
					this.m_harvestNeedTimeLab.SetVisible(true);
					string timeString = this.GetTimeString((ulong)this.m_farmLand.GrowLeftTime(), XStringDefineProxy.GetString("HomeCropRipeNeedTime"));
					this.m_harvestNeedTimeLab.SetText(timeString);
				}
				else
				{
					this.m_harvestNeedTimeLab.SetVisible(false);
				}
				this.SetLogInfos(this.m_farmLand);
				bool flag5 = this.m_farmLand.State > CropState.None;
				if (flag5)
				{
					this.m_operateBtnGo.SetActive(true);
					this.m_harvestBtn.SetVisible(false);
					this.m_stealBtn.SetVisible(false);
					this.m_cdLab.SetVisible(false);
					this.m_statueLab.SetText(XStringDefineProxy.GetString("NeedHelp"));
				}
				else
				{
					this.m_operateBtnGo.SetActive(false);
					this.m_harvestBtn.SetVisible(false);
					this.m_stealBtn.SetVisible(false);
					this.m_cdLab.SetVisible(false);
					bool flag6 = this.m_farmLand.Stage == GrowStage.Ripe;
					if (flag6)
					{
						bool flag7 = XSingleton<XAttributeMgr>.singleton.XPlayerData != null && this.m_farmLand.OwnerRoleId == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
						if (flag7)
						{
							this.m_harvestBtn.SetVisible(true);
						}
						else
						{
							this.m_stealBtn.SetVisible(true);
						}
						this.m_statueLab.SetText(XStringDefineProxy.GetString("HadRipe"));
					}
					else
					{
						this.m_cdLab.SetVisible(true);
						string timeString2 = this.GetTimeString(this.m_farmLand.StateLeftTime, XStringDefineProxy.GetString("HomeSeedCoolTime"));
						this.m_cdLab.SetText(timeString2);
						this.m_statueLab.SetText(XStringDefineProxy.GetString("Plant_Growing"));
					}
				}
				XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
				this.m_token = XSingleton<XTimerMgr>.singleton.SetTimer(5f, new XTimerMgr.ElapsedEventHandler(this.QequestInfo), null);
			}
		}

		private void SetLogInfos(Farmland farm)
		{
			float num = 0f;
			for (int i = 0; i < this.m_homeLogs.Count; i++)
			{
				bool flag = i >= this.m_farmLand.FarmLogList.Count;
				if (flag)
				{
					this.m_homeLogs[i].SetVisible(false);
				}
				else
				{
					this.m_homeLogs[i].SetVisible(true);
					this.m_homeLogs[i].SetText(this.m_farmLand.FarmLogList[i].Txt);
					this.m_homeLogs[i].gameObject.transform.localPosition = new Vector3(0f, num, 0f);
					num -= (float)this.m_homeLogs[i].spriteHeight;
					num -= 5f;
				}
			}
		}

		public void QequestInfo(object o = null)
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token);
			HomePlantDocument doc = HomePlantDocument.Doc;
			doc.FetchPlantInfo(doc.CurFarmlandId);
			this.m_token = XSingleton<XTimerMgr>.singleton.SetTimer(5f, new XTimerMgr.ElapsedEventHandler(this.QequestInfo), null);
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_farmLand == null || this.m_farmLand.IsFree;
			if (!flag)
			{
				bool flag2 = this.m_farmLand.Stage != GrowStage.Ripe;
				if (flag2)
				{
					this.m_harvestNeedTimeLab.SetVisible(true);
					string timeString = this.GetTimeString((ulong)this.m_farmLand.GrowLeftTime(), XStringDefineProxy.GetString("HomeCropRipeNeedTime"));
					this.m_harvestNeedTimeLab.SetText(timeString);
					this.m_growthSlider.Value = this.m_farmLand.GrowPercent;
					bool flag3 = this.m_farmLand.State == CropState.None;
					if (flag3)
					{
						this.m_cdLab.SetVisible(true);
						timeString = this.GetTimeString(this.m_farmLand.StateLeftTime, XStringDefineProxy.GetString("HomeSeedCoolTime"));
						this.m_cdLab.SetText(timeString);
					}
				}
				else
				{
					this.m_harvestNeedTimeLab.SetVisible(false);
					this.m_cdLab.SetVisible(false);
				}
			}
		}

		private string GetTimeString(ulong ti, string str)
		{
			bool flag = ti < 60UL;
			string result;
			if (flag)
			{
				string arg = string.Format("{0}{1}", ti, XStringDefineProxy.GetString("MINUTE_DUARATION"));
				result = string.Format(str, arg);
			}
			else
			{
				ulong num = ti / 60UL;
				ulong num2 = ti % 60UL;
				bool flag2 = num2 > 0UL;
				string arg;
				if (flag2)
				{
					arg = string.Format("{0}{1}{2}{3}", new object[]
					{
						num,
						XStringDefineProxy.GetString("HOUR_DUARATION"),
						num2,
						XStringDefineProxy.GetString("MINUTE_DUARATION")
					});
				}
				else
				{
					arg = string.Format("{0}{1}", num, XStringDefineProxy.GetString("HOUR_DUARATION"));
				}
				result = string.Format(str, arg);
			}
			return result;
		}

		private bool OnClickHarvestBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = XSingleton<XAttributeMgr>.singleton.XPlayerData == null || this.m_farmLand.OwnerRoleId != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = this.m_farmLand.Stage != GrowStage.Ripe;
					if (flag3)
					{
						result = true;
					}
					else
					{
						bool bIsPlayingAction = this.m_bIsPlayingAction;
						if (bIsPlayingAction)
						{
							result = true;
						}
						else
						{
							bool flag4 = !XOutlookHelper.CanPlaySpecifiedAnimation(XSingleton<XEntityMgr>.singleton.Player);
							if (flag4)
							{
								result = true;
							}
							else
							{
								bool flag5 = this.m_doc.HomeType == HomeTypeEnum.GuildHome;
								if (flag5)
								{
									XSingleton<UiUtility>.singleton.ShowModalDialog(XStringDefineProxy.GetString("GuildHomeHarvestTips"), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this.PlayHarvestAction));
								}
								else
								{
									this.PlayHarvestAction();
								}
								result = true;
							}
						}
					}
				}
			}
			return result;
		}

		private bool PlayHarvestAction(IXUIButton btn)
		{
			this.PlayHarvestAction();
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private void PlayHarvestAction()
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player == null;
			if (flag)
			{
				this.m_bIsPlayingAction = false;
			}
			else
			{
				XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimation(this.m_doc.GetHomePlantAction(ActionType.Harvest));
				XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token1);
				this.m_token1 = XSingleton<XTimerMgr>.singleton.SetTimer(this.m_harvestActionTime, new XTimerMgr.ElapsedEventHandler(this.QequestHarvest), null);
				XSingleton<XFxMgr>.singleton.CreateAndPlay(this.m_harvestFxPath, XSingleton<XEntityMgr>.singleton.Player.EngineObject, Vector3.zero, Vector3.one, 1f, false, this.m_harvestActionTime, true);
				XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/Farm_PlantLV1", true, AudioChannel.Action);
				this.m_bIsPlayingAction = true;
			}
		}

		private bool OnClickStealBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this.m_farmLand.OwnerRoleId == 0UL || (XSingleton<XAttributeMgr>.singleton.XPlayerData != null && this.m_farmLand.OwnerRoleId == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = this.m_farmLand.Stage != GrowStage.Ripe;
					if (flag3)
					{
						result = true;
					}
					else
					{
						bool flag4 = XSingleton<XEntityMgr>.singleton.Player == null;
						if (flag4)
						{
							result = true;
						}
						else
						{
							int num = this.m_farmLand.CanSteal();
							bool flag5 = num == 1;
							if (flag5)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CannotStealed1"), "fece00");
								result = true;
							}
							else
							{
								bool flag6 = num == 2;
								if (flag6)
								{
									XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CannotStealed2"), "fece00");
									result = true;
								}
								else
								{
									bool flag7 = XSingleton<XEntityMgr>.singleton.Player == null;
									if (flag7)
									{
										result = true;
									}
									else
									{
										bool flag8 = !XOutlookHelper.CanPlaySpecifiedAnimation(XSingleton<XEntityMgr>.singleton.Player);
										if (flag8)
										{
											result = true;
										}
										else
										{
											bool bIsPlayingAction = this.m_bIsPlayingAction;
											if (bIsPlayingAction)
											{
												result = true;
											}
											else
											{
												this.m_bIsPlayingAction = true;
												XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimation(this.m_doc.GetHomePlantAction(ActionType.Harvest));
												XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token1);
												this.m_token1 = XSingleton<XTimerMgr>.singleton.SetTimer(this.m_harvestActionTime, new XTimerMgr.ElapsedEventHandler(this.QequestSteal), null);
												XSingleton<XFxMgr>.singleton.CreateAndPlay(this.m_harvestFxPath, XSingleton<XEntityMgr>.singleton.Player.EngineObject, Vector3.zero, Vector3.one, 1f, false, this.m_harvestActionTime, true);
												XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/Farm_PlantLV1", true, AudioChannel.Action);
												result = true;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		private bool OnClickFertilizerBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this.m_farmLand.State == CropState.None;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = XSingleton<XEntityMgr>.singleton.Player == null;
					if (flag3)
					{
						result = true;
					}
					else
					{
						bool flag4 = !XOutlookHelper.CanPlaySpecifiedAnimation(XSingleton<XEntityMgr>.singleton.Player);
						if (flag4)
						{
							result = true;
						}
						else
						{
							bool bIsPlayingAction = this.m_bIsPlayingAction;
							if (bIsPlayingAction)
							{
								result = true;
							}
							else
							{
								this.m_bIsPlayingAction = true;
								XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token1);
								this.m_token1 = XSingleton<XTimerMgr>.singleton.SetTimer(this.m_waterActionTime, new XTimerMgr.ElapsedEventHandler(this.QequestPlantCultivation), CropState.Fertilizer);
								XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimation(this.m_doc.GetHomePlantAction(ActionType.Fertilizer));
								XSingleton<XFxMgr>.singleton.CreateAndPlay(HomePlantDocument.PlantEffectPath, XSingleton<XEntityMgr>.singleton.Player.EngineObject, Vector3.zero, Vector3.one, 1f, false, this.m_waterActionTime, true);
								XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/Farm_Planting", true, AudioChannel.Action);
								result = true;
							}
						}
					}
				}
			}
			return result;
		}

		private bool OnClickDisinsectionBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this.m_farmLand.State == CropState.None;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = XSingleton<XEntityMgr>.singleton.Player == null;
					if (flag3)
					{
						result = true;
					}
					else
					{
						bool flag4 = !XOutlookHelper.CanPlaySpecifiedAnimation(XSingleton<XEntityMgr>.singleton.Player);
						if (flag4)
						{
							result = true;
						}
						else
						{
							bool bIsPlayingAction = this.m_bIsPlayingAction;
							if (bIsPlayingAction)
							{
								result = true;
							}
							else
							{
								this.m_bIsPlayingAction = true;
								XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token1);
								this.m_token1 = XSingleton<XTimerMgr>.singleton.SetTimer(this.m_waterActionTime, new XTimerMgr.ElapsedEventHandler(this.QequestPlantCultivation), CropState.Disinsection);
								XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimation(this.m_doc.GetHomePlantAction(ActionType.Disinsection));
								XSingleton<XFxMgr>.singleton.CreateAndPlay(HomePlantDocument.PlantEffectPath, XSingleton<XEntityMgr>.singleton.Player.EngineObject, Vector3.zero, Vector3.one, 1f, false, this.m_waterActionTime, true);
								XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/Farm_Planting", true, AudioChannel.Action);
								result = true;
							}
						}
					}
				}
			}
			return result;
		}

		private bool OnClickWateringBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this.m_farmLand.State == CropState.None;
				if (flag2)
				{
					result = true;
				}
				else
				{
					bool flag3 = XSingleton<XEntityMgr>.singleton.Player == null;
					if (flag3)
					{
						result = true;
					}
					else
					{
						bool flag4 = !XOutlookHelper.CanPlaySpecifiedAnimation(XSingleton<XEntityMgr>.singleton.Player);
						if (flag4)
						{
							result = true;
						}
						else
						{
							bool bIsPlayingAction = this.m_bIsPlayingAction;
							if (bIsPlayingAction)
							{
								result = true;
							}
							else
							{
								this.m_bIsPlayingAction = true;
								XSingleton<XTimerMgr>.singleton.KillTimer(this.m_token1);
								this.m_token1 = XSingleton<XTimerMgr>.singleton.SetTimer(this.m_waterActionTime, new XTimerMgr.ElapsedEventHandler(this.QequestPlantCultivation), CropState.Watering);
								XSingleton<XEntityMgr>.singleton.Player.PlaySpecifiedAnimation(this.m_doc.GetHomePlantAction(ActionType.Watering));
								XSingleton<XFxMgr>.singleton.CreateAndPlay(this.m_waterFxPath, XSingleton<XEntityMgr>.singleton.Player.EngineObject, Vector3.zero, Vector3.one, 1f, false, this.m_waterActionTime, true);
								XSingleton<XAudioMgr>.singleton.PlayUISound("Audio/UI/Farm_Sprayingwater", true, AudioChannel.Action);
								result = true;
							}
						}
					}
				}
			}
			return result;
		}

		private bool OnClickCancleBtn(IXUIButton btn)
		{
			bool flag = this.SetButtonCool(this.m_fCoolTime);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				bool flag2 = this.m_farmLand == null;
				if (flag2)
				{
					result = true;
				}
				else
				{
					this.m_doc.StartPlant(this.m_farmLand.FarmlandID, this.m_farmLand.SeedId, true);
					result = true;
				}
			}
			return result;
		}

		private bool SetButtonCool(float time)
		{
			float num = Time.realtimeSinceStartup - this.m_fLastClickBtnTime;
			bool flag = num < time;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.m_fLastClickBtnTime = Time.realtimeSinceStartup;
				result = false;
			}
			return result;
		}

		public void QequestHarvest(object o = null)
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.Player.PlayStateBack();
			}
			this.m_doc.PlantHarvest(this.m_farmLand.FarmlandID);
			this.m_bIsPlayingAction = false;
		}

		public void QequestSteal(object o = null)
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.Player.PlayStateBack();
			}
			this.m_doc.HomeSteal(this.m_farmLand.FarmlandID);
			this.m_bIsPlayingAction = false;
		}

		public void QequestPlantCultivation(object o = null)
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.Player.PlayStateBack();
			}
			bool flag2 = o != null;
			if (flag2)
			{
				this.m_doc.PlantCultivation(this.m_farmLand.FarmlandID, this.m_doc.GrowStateTrans((CropState)o));
			}
			this.m_bIsPlayingAction = false;
		}

		private GameObject m_itemGo;

		private GameObject m_operateBtnGo;

		private IXUILabel m_tittleLab;

		private IXUILabel m_cdLab;

		private IXUILabel m_harvestNeedTimeLab;

		private IXUILabel m_statueLab;

		private IXUILabel m_harvestLab;

		private IXUILabel m_growUpLab;

		private IXUILabel m_growUpStateLab;

		private IXUISlider m_growthSlider;

		private List<IXUILabel> m_homeLogs = new List<IXUILabel>();

		private IXUIButton m_harvestBtn;

		private IXUIButton m_stealBtn;

		private IXUIButton m_fertilizerBtn;

		private IXUIButton m_disinsectionBtn;

		private IXUIButton m_wateringBtn;

		private IXUIButton m_cancleBtn;

		private HomePlantDocument m_doc;

		private Farmland m_farmLand;

		private uint m_token;

		private uint m_token1;

		private float m_fCoolTime = 3.5f;

		private float m_fLastClickBtnTime = 0f;

		private float m_harvestActionTime = 2.5f;

		private float m_waterActionTime = 2.5f;

		private readonly string m_waterFxPath = "Effects/FX_Particle/UIfx/UI_jy_ss";

		private readonly string m_harvestFxPath = "Effects/FX_Particle/UIfx/UI_jy_sh";
	}
}
