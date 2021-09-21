using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200099F RID: 2463
	internal class XPetDocument : XDocComponent
	{
		// Token: 0x17002CDA RID: 11482
		// (get) Token: 0x0600941D RID: 37917 RVA: 0x0015C448 File Offset: 0x0015A648
		public override uint ID
		{
			get
			{
				return XPetDocument.uuID;
			}
		}

		// Token: 0x17002CDB RID: 11483
		// (get) Token: 0x0600941E RID: 37918 RVA: 0x0015C45F File Offset: 0x0015A65F
		// (set) Token: 0x0600941F RID: 37919 RVA: 0x0015C466 File Offset: 0x0015A666
		public static ulong HosterId { get; set; }

		// Token: 0x17002CDC RID: 11484
		// (get) Token: 0x06009420 RID: 37920 RVA: 0x0015C470 File Offset: 0x0015A670
		// (set) Token: 0x06009421 RID: 37921 RVA: 0x0015C488 File Offset: 0x0015A688
		public XPetMainView View
		{
			get
			{
				return this._view;
			}
			set
			{
				this._view = value;
			}
		}

		// Token: 0x17002CDD RID: 11485
		// (get) Token: 0x06009422 RID: 37922 RVA: 0x0015C494 File Offset: 0x0015A694
		public int PetCountMax
		{
			get
			{
				return this.PetSeatBuy.Length;
			}
		}

		// Token: 0x17002CDE RID: 11486
		// (get) Token: 0x06009423 RID: 37923 RVA: 0x0015C4AE File Offset: 0x0015A6AE
		// (set) Token: 0x06009424 RID: 37924 RVA: 0x0015C4B6 File Offset: 0x0015A6B6
		public uint BeInvitedCount { get; set; }

		// Token: 0x17002CDF RID: 11487
		// (get) Token: 0x06009425 RID: 37925 RVA: 0x0015C4C0 File Offset: 0x0015A6C0
		// (set) Token: 0x06009426 RID: 37926 RVA: 0x0015C4D8 File Offset: 0x0015A6D8
		public bool BeInvited
		{
			get
			{
				return this.m_beInvited;
			}
			set
			{
				bool flag = this.m_beInvited != value;
				if (flag)
				{
					this.m_beInvited = value;
					XSingleton<XGameSysMgr>.singleton.UpdateRedPointOnHallUI(XSysDefine.XSys_Pet_Pairs);
				}
			}
		}

		// Token: 0x17002CE0 RID: 11488
		// (get) Token: 0x06009427 RID: 37927 RVA: 0x0015C510 File Offset: 0x0015A710
		public List<PetInviteInfo> PetInviteInfolist
		{
			get
			{
				return this.m_petInviteInfolist;
			}
		}

		// Token: 0x17002CE1 RID: 11489
		// (get) Token: 0x06009428 RID: 37928 RVA: 0x0015C528 File Offset: 0x0015A728
		// (set) Token: 0x06009429 RID: 37929 RVA: 0x0015C56C File Offset: 0x0015A76C
		public bool HasGetSkillUI
		{
			get
			{
				bool flag = this.View != null && this.View.SkillHandler != null;
				return flag && this.View.SkillHandler.HasGetSkillUI;
			}
			set
			{
				bool flag = this.View != null && this.View.SkillHandler != null;
				if (flag)
				{
					this.View.SkillHandler.HasGetSkillUI = value;
				}
			}
		}

		// Token: 0x17002CE2 RID: 11490
		// (get) Token: 0x0600942A RID: 37930 RVA: 0x0015C5A8 File Offset: 0x0015A7A8
		private bool CanPlayExpUp
		{
			get
			{
				return this.ChangeExp && !this.HasGetSkillUI && !this.InPlayExpUp;
			}
		}

		// Token: 0x17002CE3 RID: 11491
		// (get) Token: 0x0600942B RID: 37931 RVA: 0x0015C5D8 File Offset: 0x0015A7D8
		public bool HasRedPoint
		{
			get
			{
				return this.CanHasRedPoint && this.FightPetHungry && this.HasFood;
			}
		}

		// Token: 0x17002CE4 RID: 11492
		// (get) Token: 0x0600942C RID: 37932 RVA: 0x0015C604 File Offset: 0x0015A804
		public List<XPet> Pets
		{
			get
			{
				return this.m_PetList;
			}
		}

		// Token: 0x17002CE5 RID: 11493
		// (get) Token: 0x0600942D RID: 37933 RVA: 0x0015C61C File Offset: 0x0015A81C
		public ulong CurMount
		{
			get
			{
				return (XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.state.type == OutLookStateType.OutLook_RidePet) ? this.m_CurMount : 0UL;
			}
		}

		// Token: 0x17002CE6 RID: 11494
		// (get) Token: 0x0600942E RID: 37934 RVA: 0x0015C654 File Offset: 0x0015A854
		public int DefaultPet
		{
			get
			{
				bool hasNewPet = this.HasNewPet;
				int result;
				if (hasNewPet)
				{
					result = this.Pets.Count - 1;
				}
				else
				{
					result = ((this.CurFightIndex >= 0) ? this.CurFightIndex : 0);
				}
				return result;
			}
		}

		// Token: 0x17002CE7 RID: 11495
		// (get) Token: 0x0600942F RID: 37935 RVA: 0x0015C694 File Offset: 0x0015A894
		private int CurFightIndex
		{
			get
			{
				for (int i = 0; i < this.Pets.Count; i++)
				{
					bool flag = this.m_CurFightUID == this.Pets[i].UID;
					if (flag)
					{
						return i;
					}
				}
				return -1;
			}
		}

		// Token: 0x17002CE8 RID: 11496
		// (get) Token: 0x06009430 RID: 37936 RVA: 0x0015C6E4 File Offset: 0x0015A8E4
		public ulong CurFightUID
		{
			get
			{
				return this.m_CurFightUID;
			}
		}

		// Token: 0x17002CE9 RID: 11497
		// (get) Token: 0x06009431 RID: 37937 RVA: 0x0015C6FC File Offset: 0x0015A8FC
		public int CurSelectedIndex
		{
			get
			{
				return this.m_CurSelected;
			}
		}

		// Token: 0x17002CEA RID: 11498
		// (get) Token: 0x06009432 RID: 37938 RVA: 0x0015C714 File Offset: 0x0015A914
		public XPet CurSelectedPet
		{
			get
			{
				bool flag = this.m_CurSelected >= this.m_PetList.Count || this.m_CurSelected < 0;
				XPet result;
				if (flag)
				{
					result = null;
				}
				else
				{
					result = this.m_PetList[this.m_CurSelected];
				}
				return result;
			}
		}

		// Token: 0x17002CEB RID: 11499
		// (get) Token: 0x06009433 RID: 37939 RVA: 0x0015C760 File Offset: 0x0015A960
		public List<XItem> SkillBookList
		{
			get
			{
				return this.m_SkillBookList;
			}
		}

		// Token: 0x06009434 RID: 37940 RVA: 0x0015C778 File Offset: 0x0015A978
		public static void Execute(OnLoadedCallback callback = null)
		{
			XPetDocument.AsyncLoader.AddTask("Table/PetLevel", XPetDocument._LevelTable, false);
			XPetDocument.AsyncLoader.AddTask("Table/PetInfo", XPetDocument._InfoTable, false);
			XPetDocument.AsyncLoader.AddTask("Table/PetItem", XPetDocument._PetItemTable, false);
			XPetDocument.AsyncLoader.AddTask("Table/PetPassiveSkill", XPetDocument._SkillTable, false);
			XPetDocument.AsyncLoader.AddTask("Table/PetFood", XPetDocument._FoodTable, false);
			XPetDocument.AsyncLoader.AddTask("Table/PetMoodTips", XPetDocument._MoodTipsTable, false);
			XPetDocument.AsyncLoader.AddTask("Table/PetBubble", XPetDocument._BubbleTable, false);
			XPetDocument.AsyncLoader.AddTask("Table/PetSkillBook", XPetDocument._SkillBookTable, false);
			XPetDocument.AsyncLoader.Execute(callback);
		}

		// Token: 0x06009435 RID: 37941 RVA: 0x0015C844 File Offset: 0x0015AA44
		public static void OnTableLoaded()
		{
			XPetDocument.PetLevelInfo.Clear();
			XPetDocument.PetLevel key = default(XPetDocument.PetLevel);
			for (int i = 0; i < XPetDocument._LevelTable.Table.Length; i++)
			{
				key.PetId = XPetDocument._LevelTable.Table[i].PetsID;
				key.Level = XPetDocument._LevelTable.Table[i].level;
				XPetDocument.PetLevelInfo.Add(key, XPetDocument._LevelTable.Table[i]);
			}
			XPetDocument.PetActionData.Clear();
			XPetDocument.PetAction key2 = default(XPetDocument.PetAction);
			for (int j = 0; j < XPetDocument._BubbleTable.Table.Length; j++)
			{
				key2.PetId = XPetDocument._BubbleTable.Table[j].id;
				key2.PetActionId = XPetDocument._BubbleTable.Table[j].ActionID;
				XPetDocument.PetActionData.Add(key2, XPetDocument._BubbleTable.Table[j]);
			}
		}

		// Token: 0x06009436 RID: 37942 RVA: 0x0015C94B File Offset: 0x0015AB4B
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
		}

		// Token: 0x06009437 RID: 37943 RVA: 0x0015C96C File Offset: 0x0015AB6C
		public static string GetFoodDescription(ItemList.RowData rowData)
		{
			PetFoodTable.RowData byitemid = XPetDocument._FoodTable.GetByitemid((uint)rowData.ItemID);
			bool flag = byitemid != null;
			string result;
			if (flag)
			{
				result = string.Format(byitemid.description, byitemid.exp);
			}
			else
			{
				result = rowData.ItemDescription;
			}
			return result;
		}

		// Token: 0x06009438 RID: 37944 RVA: 0x0015C9B8 File Offset: 0x0015ABB8
		public static uint GetPetID(uint itemid)
		{
			PetItemTable.RowData byitemid = XPetDocument._PetItemTable.GetByitemid(itemid);
			bool flag = byitemid != null;
			uint result;
			if (flag)
			{
				result = byitemid.petid;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		// Token: 0x06009439 RID: 37945 RVA: 0x0015C9E8 File Offset: 0x0015ABE8
		public static uint GetPresentID(uint id)
		{
			PetInfoTable.RowData byid = XPetDocument._InfoTable.GetByid(id);
			bool flag = byid != null;
			uint result;
			if (flag)
			{
				result = byid.presentID;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		// Token: 0x0600943A RID: 37946 RVA: 0x0015CA18 File Offset: 0x0015AC18
		public static uint GetPetType(uint id)
		{
			PetInfoTable.RowData byid = XPetDocument._InfoTable.GetByid(id);
			bool flag = byid != null;
			uint result;
			if (flag)
			{
				result = byid.PetType;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		// Token: 0x0600943B RID: 37947 RVA: 0x0015CA48 File Offset: 0x0015AC48
		public static bool GetWithowWind(uint id)
		{
			PetInfoTable.RowData byid = XPetDocument._InfoTable.GetByid(id);
			return byid == null || byid.WithWings == 0U;
		}

		// Token: 0x17002CEC RID: 11500
		// (get) Token: 0x0600943C RID: 37948 RVA: 0x0015CA78 File Offset: 0x0015AC78
		public bool IsDrivingPairPet
		{
			get
			{
				bool flag = this.CurMount != 0UL && this.CurSelectedPet != null;
				bool result;
				if (flag)
				{
					uint petType = XPetDocument.GetPetType(this.CurSelectedPet.ID);
					result = (petType == 1U);
				}
				else
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x0600943D RID: 37949 RVA: 0x0015CABC File Offset: 0x0015ACBC
		public static void TryMountCopilot(bool bMount, XEntity copilot, XEntity host, bool bInit = false)
		{
			bool flag = copilot == host;
			if (!flag)
			{
				if (bMount)
				{
					bool flag2 = host.IsMounted && !host.IsCopilotMounted;
					if (flag2)
					{
						bool isMounted = copilot.IsMounted;
						if (isMounted)
						{
							bool isCopilotMounted = copilot.IsCopilotMounted;
							if (isCopilotMounted)
							{
								bool flag3 = copilot.Mount == host.Mount;
								if (flag3)
								{
									return;
								}
								copilot.Mount.UnMountEntity(copilot);
							}
							else
							{
								copilot.Mount.UnMountEntity(copilot);
								XSingleton<XEntityMgr>.singleton.DestroyEntity(copilot.Mount);
							}
						}
						bool flag4 = !host.Mount.MountCopilot(copilot);
						if (flag4)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("Passive Mount Failed.", null, null, null, null, null);
						}
						bool flag5 = !bInit;
						if (flag5)
						{
							host.Mount.PlayFx("Effects/FX_Particle/VehicleFX/Vehicle_shangma");
						}
					}
					else
					{
						bool flag6 = !host.IsMounted;
						if (flag6)
						{
							XSingleton<XDebug>.singleton.AddErrorLog("Copilot Mount Failed: entity ", host.Name, " does not ride a pet.", null, null, null);
						}
						else
						{
							bool isCopilotMounted2 = host.IsCopilotMounted;
							if (isCopilotMounted2)
							{
								XSingleton<XDebug>.singleton.AddErrorLog("Copilot Mount Failed: host entity ", host.Name, " is mounted as a copilot.", null, null, null);
							}
						}
					}
				}
				else
				{
					bool isMounted2 = copilot.IsMounted;
					if (isMounted2)
					{
						bool flag7 = !bInit;
						if (flag7)
						{
							copilot.Mount.PlayFx("Effects/FX_Particle/VehicleFX/Vehicle_xiama");
						}
						copilot.Mount.UnMountEntity(copilot);
					}
				}
			}
		}

		// Token: 0x0600943E RID: 37950 RVA: 0x0015CC40 File Offset: 0x0015AE40
		public static void TryMount(bool bMount, XEntity entity, uint petID = 0U, bool bInit = false)
		{
			if (bMount)
			{
				uint presentID = XPetDocument.GetPresentID(petID);
				bool flag = presentID == 0U;
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("PresentID = 0, while petid = ", petID.ToString(), null, null, null, null);
				}
				else
				{
					bool isMounted = entity.IsMounted;
					if (isMounted)
					{
						bool isCopilotMounted = entity.IsCopilotMounted;
						if (isCopilotMounted)
						{
							entity.Mount.UnMountEntity(entity);
						}
						else
						{
							bool flag2 = entity.Mount.PresentID == presentID;
							if (flag2)
							{
								return;
							}
							entity.Mount.UnMountEntity(entity);
							XSingleton<XEntityMgr>.singleton.DestroyEntity(entity.Mount);
						}
					}
					bool isCopilot = XPetDocument.GetPetType(petID) == 1U;
					XMount xmount = XSingleton<XEntityMgr>.singleton.CreateMount(presentID, entity, isCopilot);
					bool flag3 = !bInit && xmount != null;
					if (flag3)
					{
						xmount.PlayFx("Effects/FX_Particle/VehicleFX/Vehicle_shangma");
					}
				}
			}
			else
			{
				bool flag4 = entity.Mount != null;
				if (flag4)
				{
					bool flag5 = !bInit && entity.Mount.EngineObject != null;
					if (flag5)
					{
						entity.Mount.PlayFx("Effects/FX_Particle/VehicleFX/Vehicle_xiama");
					}
					entity.Mount.UnMountEntity(entity);
					XSingleton<XEntityMgr>.singleton.DestroyEntity(entity.Mount);
				}
			}
		}

		// Token: 0x0600943F RID: 37951 RVA: 0x0015CD84 File Offset: 0x0015AF84
		public PetBubble.RowData GetPetBubble(XPetActionFile PetActionFile, uint petid = 0U)
		{
			XPetDocument.PetAction petAction = default(XPetDocument.PetAction);
			bool flag = petid == 0U && this.CurSelectedPet != null;
			if (flag)
			{
				petid = this.CurSelectedPet.ID;
			}
			petAction.PetId = petid;
			petAction.PetActionId = (uint)XFastEnumIntEqualityComparer<XPetActionFile>.ToInt(PetActionFile);
			PetBubble.RowData rowData;
			bool flag2 = !XPetDocument.PetActionData.TryGetValue(petAction, out rowData);
			PetBubble.RowData result;
			if (flag2)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
				{
					"PetBubble No Find\nPetId:",
					petAction.PetId,
					"PetActionId:",
					petAction.PetActionId
				}), null, null, null, null, null);
				result = null;
			}
			else
			{
				result = rowData;
			}
			return result;
		}

		// Token: 0x06009440 RID: 37952 RVA: 0x0015CE38 File Offset: 0x0015B038
		public int GetAddExp(int requiredExp)
		{
			float num = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("PetExpUpSpeed"));
			return (int)Math.Ceiling((double)((float)requiredExp * num));
		}

		// Token: 0x06009441 RID: 37953 RVA: 0x0015CE6C File Offset: 0x0015B06C
		public override void Update(float fDeltaT)
		{
			base.Update(fDeltaT);
			bool flag = this.View == null;
			if (!flag)
			{
				bool flag2 = this.CurSelectedPet == null;
				if (!flag2)
				{
					bool canPlayExpUp = this.CanPlayExpUp;
					if (canPlayExpUp)
					{
						this.InPlayExpUp = true;
						int requiredExp = this.GetRequiredExp(this.CurSelectedPet.ID, this.CurSelectedPet.showLevel);
						this.addExp = this.GetAddExp(requiredExp);
					}
					bool flag3 = this.InPlayExpUp && !this.HasGetSkillUI;
					if (flag3)
					{
						int requiredExp2 = this.GetRequiredExp(this.CurSelectedPet.ID, this.CurSelectedPet.showLevel);
						this.CurSelectedPet.showExp += this.addExp;
						bool flag4 = this.CurSelectedPet.showExp >= requiredExp2 && this.CurSelectedPet.showLevel < this.CurSelectedPet.Level;
						if (flag4)
						{
							this.View.PlayPetLevelUpFx(this.View.uiBehaviour.m_PetSnapshot.transform, false);
							this.CurSelectedPet.showExp = 0;
							this.CurSelectedPet.showLevel++;
							requiredExp2 = this.GetRequiredExp(this.CurSelectedPet.ID, this.CurSelectedPet.showLevel);
							this.addExp = this.GetAddExp(requiredExp2);
							this.View.RefreshPage(false);
							bool flag5 = this.CurSelectedPet.showLevel > this.CurSelectedPet.Level;
							if (flag5)
							{
								this.PlayEnd();
							}
							this.View.SkillHandler.PlayNewSkillTip(this.GetNewSkill(), 0U);
						}
						bool flag6 = this.CurSelectedPet.showExp >= this.CurSelectedPet.Exp && this.CurSelectedPet.showLevel >= this.CurSelectedPet.Level;
						if (flag6)
						{
							this.PlayEnd();
						}
						this.View.RefreshExp();
					}
					bool changeFullDegree = this.ChangeFullDegree;
					if (changeFullDegree)
					{
						this.CurSelectedPet.showFullDegree += XPetDocument.PLAY_FULL_DEGREE_UP_FRAMES;
						bool flag7 = this.CurSelectedPet.showFullDegree >= this.CurSelectedPet.FullDegree;
						if (flag7)
						{
							this.CurSelectedPet.showFullDegree = this.CurSelectedPet.FullDegree;
							this.ChangeFullDegree = false;
						}
						this.View.RefreshFullDegree();
					}
				}
			}
		}

		// Token: 0x06009442 RID: 37954 RVA: 0x0015D0E8 File Offset: 0x0015B2E8
		private void PlayEnd()
		{
			this.ChangeExp = false;
			this.CurSelectedPet.showExp = this.CurSelectedPet.Exp;
			this.CurSelectedPet.showLevel = this.CurSelectedPet.Level;
			bool flag = this.qExpAnimation.Count == 0;
			if (flag)
			{
				this.InPlayExpUp = false;
				bool flag2 = this.View == null;
				if (flag2)
				{
					this.View.RefreshPage(false);
				}
			}
			else
			{
				PetSingle data = this.qExpAnimation.Dequeue();
				this.Pets[this.CurSelectedIndex].Init(data, PetChange.Exp);
			}
		}

		// Token: 0x06009443 RID: 37955 RVA: 0x0015D188 File Offset: 0x0015B388
		public int GetNewSkill()
		{
			for (int i = 0; i < this.petGetSkill.Count; i++)
			{
				bool flag = (ulong)this.petGetSkill[i].petLvl == (ulong)((long)this.CurSelectedPet.showLevel);
				if (flag)
				{
					int j = 0;
					while (j < this.CurSelectedPet.SkillList.Count)
					{
						bool flag2 = this.CurSelectedPet.SkillList[j].id == this.petGetSkill[i].skillid;
						if (flag2)
						{
							XSingleton<XDebug>.singleton.AddLog("Get Skill:" + this.petGetSkill[i].skillid, null, null, null, null, null, XDebugColor.XDebug_None);
							bool flag3 = (long)j < (long)((ulong)XPet.FIX_SKILL_COUNT_MAX);
							if (flag3)
							{
								this.CurSelectedPet.ShowSkillList[j].open = true;
								this.petGetSkill.Remove(this.petGetSkill[i]);
								return j;
							}
							int k;
							for (k = 0; k < this.CurSelectedPet.ShowSkillList.Count; k++)
							{
								bool flag4 = this.CurSelectedPet.ShowSkillList[k].id == this.CurSelectedPet.SkillList[j].id;
								if (flag4)
								{
									break;
								}
							}
							this.petGetSkill.Remove(this.petGetSkill[i]);
							bool flag5 = k == this.CurSelectedPet.ShowSkillList.Count;
							if (flag5)
							{
								this.CurSelectedPet.ShowSkillList.Add(this.CurSelectedPet.SkillList[j]);
							}
							return k;
						}
						else
						{
							j++;
						}
					}
				}
			}
			return -1;
		}

		// Token: 0x06009444 RID: 37956 RVA: 0x0015D37C File Offset: 0x0015B57C
		public override void OnAttachToHost(XObject host)
		{
			base.OnAttachToHost(host);
			this.Pets.Clear();
			this.m_CurSelected = -1;
			this.m_FoodFilter.Clear();
			this.m_FoodFilter.AddItemType(ItemType.PET_FOOD);
			this.m_SkillBookFilter.Clear();
			this.m_SkillBookFilter.AddItemType(ItemType.PET_SKILL_BOOK);
		}

		// Token: 0x06009445 RID: 37957 RVA: 0x0015D3DC File Offset: 0x0015B5DC
		public void Select(int index, bool bResetPosition = false)
		{
			this.ClearPetAnimation();
			bool flag = index < this.Pets.Count;
			if (flag)
			{
				this.m_CurSelected = index;
			}
			this.ShowCurPet();
			bool flag2 = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<XPetMainView, XPetMainBehaviour>.singleton.SetTravelSetBtnStatus();
				DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshPage(bResetPosition);
				DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshPetModel();
			}
		}

		// Token: 0x06009446 RID: 37958 RVA: 0x0015D444 File Offset: 0x0015B644
		public void ClearPetAnimation()
		{
			while (this.qExpAnimation.Count != 0)
			{
				PetSingle data = this.qExpAnimation.Dequeue();
				bool flag = this.qExpAnimation.Count == 0 && this.CurSelectedIndex != -1;
				if (flag)
				{
					this.Pets[this.CurSelectedIndex].Init(data, PetChange.None);
				}
			}
			this.ChangeFullDegree = false;
			this.ChangeExp = false;
			this.HasGetSkillUI = false;
			this.InPlayExpUp = false;
			bool flag2 = this.CurSelectedPet != null;
			if (flag2)
			{
				this.CurSelectedPet.showFullDegree = this.CurSelectedPet.FullDegree;
				this.CurSelectedPet.showExp = this.CurSelectedPet.Exp;
				this.CurSelectedPet.showLevel = this.CurSelectedPet.Level;
			}
		}

		// Token: 0x06009447 RID: 37959 RVA: 0x0015D51C File Offset: 0x0015B71C
		public void ShowCurPet()
		{
			bool flag = this.CurSelectedPet != null;
			if (flag)
			{
				this.CurSelectedPet.Refresh();
			}
			this.petGetSkill.Clear();
			bool flag2 = this.View != null;
			if (flag2)
			{
				this.View.RefreshAutoRefresh();
				this.View.uiBehaviour.m_FullDegreeTip.gameObject.SetActive(false);
				this.View.uiBehaviour.m_MoodTip.gameObject.SetActive(false);
				this.View.uiBehaviour.m_Talk.gameObject.SetActive(false);
			}
		}

		// Token: 0x06009448 RID: 37960 RVA: 0x0015D5C0 File Offset: 0x0015B7C0
		public void PlayRandAction()
		{
			bool flag = this.CurSelectedPet == null;
			if (!flag)
			{
				List<PetBubble.RowData> list = new List<PetBubble.RowData>();
				list.Add(this.GetPetBubble(XPetActionFile.IDLE, 0U));
				DateTime dateTime = default(DateTime);
				int hour = DateTime.Now.Hour;
				bool flag2 = hour >= 22 || hour <= 6;
				if (flag2)
				{
					list.Add(this.GetPetBubble(XPetActionFile.SLEEP, 0U));
				}
				this.RandomPlayAnimation(list);
			}
		}

		// Token: 0x06009449 RID: 37961 RVA: 0x0015D638 File Offset: 0x0015B838
		public void PlayIdleAction()
		{
			bool flag = this.CurSelectedPet == null;
			if (!flag)
			{
				this.RandomPlayAnimation(new List<PetBubble.RowData>
				{
					this.GetPetBubble(XPetActionFile.IDLE, 0U),
					this.GetPetBubble(XPetActionFile.IDLE_PEOPLE, 0U)
				});
			}
		}

		// Token: 0x0600944A RID: 37962 RVA: 0x0015D684 File Offset: 0x0015B884
		public void RandomPlayAnimation(List<PetBubble.RowData> action)
		{
			int num = 0;
			for (int i = 0; i < action.Count; i++)
			{
				num += (int)action[i].Weights;
			}
			int num2 = XSingleton<XCommon>.singleton.RandomInt(0, num);
			for (int j = 0; j < action.Count; j++)
			{
				num2 -= (int)action[j].Weights;
				bool flag = num2 < 0;
				if (flag)
				{
					bool flag2 = this.View != null;
					if (flag2)
					{
						this.View.PetActionChange((XPetActionFile)action[j].ActionID, this.CurSelectedPet.ID, this.View.m_Dummy, false);
					}
					break;
				}
			}
		}

		// Token: 0x0600944B RID: 37963 RVA: 0x0015D740 File Offset: 0x0015B940
		public string RandomPlayBubble(string[] bubble)
		{
			bool flag = bubble != null;
			string result;
			if (flag)
			{
				int num = XSingleton<XCommon>.singleton.RandomInt(0, bubble.Length);
				result = bubble[num];
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600944C RID: 37964 RVA: 0x0015D778 File Offset: 0x0015B978
		public PetMoodTipsTable.RowData GetPetMoodTip(uint mood)
		{
			for (int i = XPetDocument._MoodTipsTable.Table.Length - 1; i >= 0; i--)
			{
				bool flag = (long)XPetDocument._MoodTipsTable.Table[i].value <= (long)((ulong)mood);
				if (flag)
				{
					return XPetDocument._MoodTipsTable.Table[i];
				}
			}
			return null;
		}

		// Token: 0x0600944D RID: 37965 RVA: 0x0015D7DC File Offset: 0x0015B9DC
		public static PetSkillBook.RowData GetPetSkillBook(uint itemID)
		{
			return XPetDocument._SkillBookTable.GetByitemid(itemID);
		}

		// Token: 0x0600944E RID: 37966 RVA: 0x0015D7FC File Offset: 0x0015B9FC
		public static PetFoodTable.RowData GetPetFood(uint itemID)
		{
			return XPetDocument._FoodTable.GetByitemid(itemID);
		}

		// Token: 0x0600944F RID: 37967 RVA: 0x0015D81C File Offset: 0x0015BA1C
		public static PetInfoTable.RowData GetPetInfo(uint petID)
		{
			return XPetDocument._InfoTable.GetByid(petID);
		}

		// Token: 0x06009450 RID: 37968 RVA: 0x0015D83C File Offset: 0x0015BA3C
		public static PetPassiveSkillTable.RowData GetPetSkill(uint id)
		{
			return XPetDocument._SkillTable.GetByid(id);
		}

		// Token: 0x06009451 RID: 37969 RVA: 0x0015D85C File Offset: 0x0015BA5C
		public static uint GetFixSkill(uint PetID, int SkillNum)
		{
			PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(PetID);
			bool flag = SkillNum == 1;
			uint result;
			if (flag)
			{
				result = petInfo.skill1[0, 0];
			}
			else
			{
				bool flag2 = SkillNum == 2;
				if (flag2)
				{
					result = petInfo.skill2[0, 0];
				}
				else
				{
					bool flag3 = SkillNum == 3;
					if (flag3)
					{
						result = petInfo.skill3[0, 0];
					}
					else
					{
						result = 0U;
					}
				}
			}
			return result;
		}

		// Token: 0x06009452 RID: 37970 RVA: 0x0015D8C0 File Offset: 0x0015BAC0
		public static PetLevelTable.RowData GetPetLevel(XPet pet)
		{
			PetLevelTable.RowData petLevel = XPetDocument.GetPetLevel(pet.ID, pet.Level);
			bool flag = petLevel == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog(string.Concat(new object[]
				{
					"PetLevelTable petID:",
					pet.ID,
					" petLevel:",
					pet.Level,
					" No Find "
				}), null, null, null, null, null);
			}
			return petLevel;
		}

		// Token: 0x06009453 RID: 37971 RVA: 0x0015D93C File Offset: 0x0015BB3C
		public static PetLevelTable.RowData GetPetLevel(uint petId, int level)
		{
			XPetDocument.PetLevel key = default(XPetDocument.PetLevel);
			key.PetId = petId;
			key.Level = (uint)level;
			PetLevelTable.RowData rowData;
			bool flag = !XPetDocument.PetLevelInfo.TryGetValue(key, out rowData);
			PetLevelTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = rowData;
			}
			return result;
		}

		// Token: 0x06009454 RID: 37972 RVA: 0x0015D980 File Offset: 0x0015BB80
		public PetPassiveSkillTable.RowData GetPassiveSkillData(uint id)
		{
			for (int i = 0; i < XPetDocument._SkillTable.Table.Length; i++)
			{
				PetPassiveSkillTable.RowData rowData = XPetDocument._SkillTable.Table[i];
				bool flag = rowData.id == id;
				if (flag)
				{
					return rowData;
				}
			}
			return null;
		}

		// Token: 0x06009455 RID: 37973 RVA: 0x0015D9D0 File Offset: 0x0015BBD0
		public int GetRequiredExp(XPet pet)
		{
			return this.GetRequiredExp(pet.ID, pet.Level);
		}

		// Token: 0x06009456 RID: 37974 RVA: 0x0015D9F4 File Offset: 0x0015BBF4
		public int GetRequiredExp(uint id, int level)
		{
			bool flag = this.IsMaxLevel(id, level);
			int result;
			if (flag)
			{
				result = 1;
			}
			else
			{
				PetLevelTable.RowData petLevel = XPetDocument.GetPetLevel(id, level + 1);
				bool flag2 = petLevel == null;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					result = (int)petLevel.exp;
				}
			}
			return result;
		}

		// Token: 0x06009457 RID: 37975 RVA: 0x0015DA33 File Offset: 0x0015BC33
		public void GetExpInfo(XPet pet, out int curExp, out int totalExp)
		{
			totalExp = this.GetRequiredExp(pet.ID, pet.showLevel);
			curExp = pet.showExp;
		}

		// Token: 0x06009458 RID: 37976 RVA: 0x0015DA54 File Offset: 0x0015BC54
		public bool IsMaxLevel(XPet pet)
		{
			return this.IsMaxLevel(pet.ID, pet.Level);
		}

		// Token: 0x06009459 RID: 37977 RVA: 0x0015DA78 File Offset: 0x0015BC78
		public bool IsMaxLevel(uint id, int level)
		{
			PetLevelTable.RowData petLevel = XPetDocument.GetPetLevel(id, level);
			bool flag = petLevel != null;
			if (flag)
			{
				petLevel = XPetDocument.GetPetLevel(id, level + 1);
				bool flag2 = petLevel == null;
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600945A RID: 37978 RVA: 0x0015DAB4 File Offset: 0x0015BCB4
		public List<XItem> GetFood()
		{
			ulong filterValue = this.m_FoodFilter.FilterValue;
			this.m_FoodList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(filterValue, ref this.m_FoodList);
			return this.m_FoodList;
		}

		// Token: 0x0600945B RID: 37979 RVA: 0x0015DB00 File Offset: 0x0015BD00
		public List<XItem> GetSkillBook()
		{
			ulong filterValue = this.m_SkillBookFilter.FilterValue;
			this.m_SkillBookList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(filterValue, ref this.m_SkillBookList);
			return this.m_SkillBookList;
		}

		// Token: 0x0600945C RID: 37980 RVA: 0x0015DB4C File Offset: 0x0015BD4C
		public void ReqPetTouch()
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.type = PetOP.PetTouch;
			rpcC2G_PetOperation.oArg.uid = this.CurSelectedPet.UID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
			this.ReqPetInfo();
		}

		// Token: 0x0600945D RID: 37981 RVA: 0x0015DB98 File Offset: 0x0015BD98
		public void ReqBuySeat()
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.type = PetOP.ExpandSeat;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
		}

		// Token: 0x0600945E RID: 37982 RVA: 0x0015DBC8 File Offset: 0x0015BDC8
		public void ReqMount()
		{
			XPet curSelectedPet = this.CurSelectedPet;
			bool flag = curSelectedPet == null;
			if (!flag)
			{
				RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
				rpcC2G_PetOperation.oArg.type = PetOP.PetFellow;
				rpcC2G_PetOperation.oArg.uid = curSelectedPet.UID;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
			}
		}

		// Token: 0x0600945F RID: 37983 RVA: 0x0015DC18 File Offset: 0x0015BE18
		public void ReqRecentMount()
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.uid = this.CurMount;
			rpcC2G_PetOperation.oArg.type = PetOP.PetFellow;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
		}

		// Token: 0x06009460 RID: 37984 RVA: 0x0015DC58 File Offset: 0x0015BE58
		public void ReqRelease()
		{
			XPet curSelectedPet = this.CurSelectedPet;
			bool flag = curSelectedPet == null;
			if (!flag)
			{
				RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
				rpcC2G_PetOperation.oArg.type = PetOP.PetRelease;
				rpcC2G_PetOperation.oArg.uid = curSelectedPet.UID;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
			}
		}

		// Token: 0x06009461 RID: 37985 RVA: 0x0015DCA8 File Offset: 0x0015BEA8
		public void ReqFight()
		{
			XPet curSelectedPet = this.CurSelectedPet;
			bool flag = curSelectedPet == null;
			if (!flag)
			{
				RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
				rpcC2G_PetOperation.oArg.type = PetOP.PetFight;
				rpcC2G_PetOperation.oArg.uid = curSelectedPet.UID;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
			}
		}

		// Token: 0x06009462 RID: 37986 RVA: 0x0015DCF8 File Offset: 0x0015BEF8
		public void ReqFeed(int itemid)
		{
			XPet curSelectedPet = this.CurSelectedPet;
			bool flag = curSelectedPet == null;
			if (!flag)
			{
				RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
				rpcC2G_PetOperation.oArg.type = PetOP.PetFeed;
				rpcC2G_PetOperation.oArg.uid = curSelectedPet.UID;
				rpcC2G_PetOperation.oArg.food = new ItemBrief();
				rpcC2G_PetOperation.oArg.food.itemID = (uint)itemid;
				rpcC2G_PetOperation.oArg.food.itemCount = 1U;
				XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
				this.ReqPetInfo();
			}
		}

		// Token: 0x06009463 RID: 37987 RVA: 0x0015DD84 File Offset: 0x0015BF84
		public void ReqPetInfo()
		{
			RpcC2G_SynPetInfo rpcC2G_SynPetInfo = new RpcC2G_SynPetInfo();
			rpcC2G_SynPetInfo.oArg.uid = this.CurSelectedPet.UID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SynPetInfo);
		}

		// Token: 0x06009464 RID: 37988 RVA: 0x0015DDBC File Offset: 0x0015BFBC
		public void OnPetTouch(PetOperationArg oArg, PetOperationRes oRes)
		{
			bool flag = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.View.PetActionChange(XPetActionFile.CARESS, this.CurSelectedPet.ID, this.View.m_Dummy, false);
				DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshList(false);
			}
		}

		// Token: 0x06009465 RID: 37989 RVA: 0x0015DE10 File Offset: 0x0015C010
		public void OnBuySeat(PetOperationArg oArg, PetOperationRes oRes)
		{
			this.PetSeat += 1U;
			bool flag = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshList(false);
			}
		}

		// Token: 0x06009466 RID: 37990 RVA: 0x0015DE48 File Offset: 0x0015C048
		public void OnMount(PetOperationArg oArg, PetOperationRes oRes)
		{
			this.m_CurMount = oRes.followpetid;
			bool flag = this.m_PetList.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.m_PetList.Count; i++)
				{
					bool flag2 = this.m_PetList[i].UID == oRes.followpetid;
					if (flag2)
					{
						this.m_CurSelected = i;
						break;
					}
				}
			}
			bool flag3 = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
			if (flag3)
			{
				XSingleton<UIManager>.singleton.CloseAllUI();
			}
		}

		// Token: 0x06009467 RID: 37991 RVA: 0x0015DED4 File Offset: 0x0015C0D4
		public void OnRelease(PetOperationArg oArg, PetOperationRes oRes)
		{
			bool flag = this.HasNewPet && this.CurSelectedIndex == this.Pets.Count - 1;
			if (flag)
			{
				this.HasNewPet = false;
			}
			this.Pets.Remove(this.CurSelectedPet);
			this.m_CurSelected = -1;
			this.Select(this.DefaultPet, false);
		}

		// Token: 0x06009468 RID: 37992 RVA: 0x0015DF34 File Offset: 0x0015C134
		public void OnFight(PetOperationArg oArg, PetOperationRes oRes)
		{
			this.m_CurFightUID = oArg.uid;
			bool flag = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshPage(false);
			}
		}

		// Token: 0x06009469 RID: 37993 RVA: 0x0015DF68 File Offset: 0x0015C168
		public void OnFeed(PetOperationArg oArg, PetOperationRes oRes)
		{
			bool flag = this.CurSelectedPet.UID != oArg.uid;
			if (!flag)
			{
				bool flag2 = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					this.View.PetActionChange(XPetActionFile.EAT, this.CurSelectedPet.ID, this.View.m_Dummy, false);
					DlgBase<XPetMainView, XPetMainBehaviour>.singleton.FoodSelectorHandler.UpdateContent();
				}
			}
		}

		// Token: 0x0600946A RID: 37994 RVA: 0x0015DFD8 File Offset: 0x0015C1D8
		public void OnPetOperation(PetOperationArg oArg, PetOperationRes oRes)
		{
			bool flag = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				bool ismoodup = oRes.ismoodup;
				if (ismoodup)
				{
					this.View.PlayPetMoodUpFx();
				}
				bool ishuneryup = oRes.ishuneryup;
				if (ishuneryup)
				{
					this.View.PlayPetEatUpFx();
				}
			}
		}

		// Token: 0x0600946B RID: 37995 RVA: 0x0015E024 File Offset: 0x0015C224
		public void OnPetInfo(SynPetInfoArg oArg, SynPetInfoRes oRes)
		{
			bool flag = this.CurSelectedPet == null;
			if (!flag)
			{
				bool flag2 = oArg.uid != this.CurSelectedPet.UID;
				if (!flag2)
				{
					this.CurSelectedPet.showFullDegree = oRes.hungry;
					this.CurSelectedPet.FullDegree = oRes.hungry;
					this.CurSelectedPet.Mood = oRes.mood;
					bool flag3 = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
					if (flag3)
					{
						DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshFullDegree();
						DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshMood();
					}
				}
			}
		}

		// Token: 0x0600946C RID: 37996 RVA: 0x0015E0B8 File Offset: 0x0015C2B8
		public void OnFightPetHungry(PtcG2C_NoticeHungryDown roPtc)
		{
			bool flag = roPtc.Data.petid == this.CurFightUID && (ulong)roPtc.Data.hungry < (ulong)((long)int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("PetRedPoint")));
			if (flag)
			{
				this.FightPetHungry = true;
			}
		}

		// Token: 0x0600946D RID: 37997 RVA: 0x0015E10C File Offset: 0x0015C30C
		public void OnPetChange(PetChangeNotfiy data)
		{
			bool flag = data.pet.Count == 0;
			if (!flag)
			{
				PetSingle petSingle = data.pet[0];
				XPet xpet = this.GetPet(data.pet[0].uid);
				switch (data.type)
				{
				case PetOP.PetFight:
					this.HasNewPet = false;
					break;
				case PetOP.PetFeed:
				{
					bool flag2 = data.delexp > 0U;
					if (flag2)
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(string.Format(XSingleton<XStringTable>.singleton.GetString("PET_EXP_PERCENT_TIP"), data.delexp.ToString()), "fece00");
					}
					bool flag3 = xpet == this.CurSelectedPet;
					if (flag3)
					{
						bool flag4 = !this.IsMaxLevel(petSingle.petid, (int)petSingle.level);
						if (flag4)
						{
							PetLevelTable.RowData petLevel = XPetDocument.GetPetLevel(petSingle.petid, (int)(petSingle.level + 1U));
							bool flag5 = petSingle.exp > petLevel.exp;
							if (flag5)
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("PET_LEVEL_MORE_ROLE_TIP"), "fece00");
							}
						}
						bool flag6 = (long)this.CurSelectedPet.showExp != (long)((ulong)petSingle.exp) || (long)this.CurSelectedPet.showLevel != (long)((ulong)petSingle.level) || this.CurSelectedPet.showFullDegree != petSingle.hungry;
						if (flag6)
						{
							for (int i = 0; i < data.getskills.Count; i++)
							{
								this.petGetSkill.Add(data.getskills[i]);
							}
							bool inPlayExpUp = this.InPlayExpUp;
							if (inPlayExpUp)
							{
								this.qExpAnimation.Enqueue(petSingle);
							}
							else
							{
								xpet.Init(petSingle, PetChange.All);
							}
						}
					}
					else
					{
						xpet.Init(petSingle, PetChange.None);
					}
					break;
				}
				case PetOP.PetBorn:
				{
					xpet = new XPet();
					xpet.Init(petSingle, PetChange.None);
					this.Pets.Add(xpet);
					this.HasNewPet = true;
					XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_Horse, 0UL);
					bool flag7 = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
					if (flag7)
					{
						this.View.PlayPetGetFx();
					}
					break;
				}
				case PetOP.PetExpTransfer:
				{
					bool flag8 = data.pet.Count != 2;
					if (flag8)
					{
						XSingleton<XDebug>.singleton.AddErrorLog("Pet Transfer Count No 2", null, null, null, null, null);
						return;
					}
					xpet = this.GetPet(data.pet[0].uid);
					xpet.Init(data.pet[0], PetChange.ExpTransfer);
					xpet = this.GetPet(data.pet[1].uid);
					xpet.Init(data.pet[1], PetChange.ExpTransfer);
					this.petGetSkill.Clear();
					for (int j = 0; j < data.getskills.Count; j++)
					{
						this.petGetSkill.Add(data.getskills[j]);
					}
					bool flag9 = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.ExpTransferHandler != null;
					if (flag9)
					{
						DlgBase<XPetMainView, XPetMainBehaviour>.singleton.ExpTransferHandler.Transfer(data.pet[0].uid, data.pet[1].uid);
					}
					break;
				}
				case PetOP.useskillbook:
				{
					bool flag10 = xpet == this.CurSelectedPet;
					if (flag10)
					{
						xpet.Init(petSingle, PetChange.None);
					}
					for (int k = 0; k < data.getskills.Count; k++)
					{
						this.petGetSkill.Add(data.getskills[k]);
					}
					bool flag11 = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
					if (flag11)
					{
						this.View.SkillHandler.PlayNewSkillTip(this.GetNewSkill(), data.delskillid);
					}
					break;
				}
				}
				switch (data.type)
				{
				case PetOP.PetFight:
				case PetOP.PetUpdate:
				case PetOP.PetRelease:
				{
					bool flag12 = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
					if (flag12)
					{
						DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshList(false);
						DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshContent();
					}
					break;
				}
				case PetOP.PetTouch:
				{
					bool flag13 = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
					if (flag13)
					{
						DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshMood();
					}
					break;
				}
				case PetOP.useskillbook:
				{
					bool flag14 = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
					if (flag14)
					{
						DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshBaseInfo();
						bool flag15 = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.SkillLearnHandler.IsVisible();
						if (flag15)
						{
							DlgBase<XPetMainView, XPetMainBehaviour>.singleton.SkillLearnHandler.RefreshList(false);
						}
					}
					break;
				}
				}
			}
		}

		// Token: 0x0600946E RID: 37998 RVA: 0x0015E5E0 File Offset: 0x0015C7E0
		public void OnPetAllNotify(PetSysData data)
		{
			this.Pets.Clear();
			bool flag = data == null || data.petseats == 0U;
			if (flag)
			{
				this.PetSeat = 0U;
				while ((ulong)this.PetSeat < (ulong)((long)this.PetSeatBuy.Length))
				{
					bool flag2 = int.Parse(this.PetSeatBuy[(int)this.PetSeat]) != 0;
					if (flag2)
					{
						break;
					}
					this.PetSeat += 1U;
				}
			}
			else
			{
				this.PetSeat = data.petseats;
				bool flag3 = data.pets == null;
				if (!flag3)
				{
					for (int i = 0; i < data.pets.Count; i++)
					{
						XPet xpet = new XPet();
						xpet.Init(data.pets[i], PetChange.None);
						this.Pets.Add(xpet);
					}
					this.m_CurMount = data.followid;
					this.m_CurFightUID = data.fightid;
					bool canHasRedPoint = this.CanHasRedPoint;
					if (canHasRedPoint)
					{
						this.HasFood = (this.GetFood().Count != 0);
						this.FightPetHungry = (this.CurFightIndex >= 0 && (ulong)this.Pets[this.CurFightIndex].FullDegree < (ulong)((long)int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("PetRedPoint"))));
					}
				}
			}
		}

		// Token: 0x0600946F RID: 37999 RVA: 0x0015E748 File Offset: 0x0015C948
		public void OnReqSetTravelSet(bool status)
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.type = PetOP.SetPetPairRide;
			rpcC2G_PetOperation.oArg.uid = this.CurSelectedPet.UID;
			rpcC2G_PetOperation.oArg.setpairride = status;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
		}

		// Token: 0x06009470 RID: 38000 RVA: 0x0015E79C File Offset: 0x0015C99C
		public void OnReqInviteList()
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.type = PetOP.QueryPetPairRideInvite;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
		}

		// Token: 0x06009471 RID: 38001 RVA: 0x0015E7CC File Offset: 0x0015C9CC
		public void OnReqOffPetPairRide()
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.type = PetOP.OffPetPairRide;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
		}

		// Token: 0x06009472 RID: 38002 RVA: 0x0015E7FC File Offset: 0x0015C9FC
		public void OnReqIgnoreAll()
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.type = PetOP.IgnorePetPairRideInvite;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
		}

		// Token: 0x06009473 RID: 38003 RVA: 0x0015E82C File Offset: 0x0015CA2C
		public void ReqPetPetOperationOther(PetOtherOp type, ulong otherRoleId)
		{
			RpcC2G_PetOperationOther rpcC2G_PetOperationOther = new RpcC2G_PetOperationOther();
			rpcC2G_PetOperationOther.oArg.op = type;
			rpcC2G_PetOperationOther.oArg.otherroleid = otherRoleId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperationOther);
		}

		// Token: 0x06009474 RID: 38004 RVA: 0x0015E868 File Offset: 0x0015CA68
		public void OnReqSetTravelSetBack(PetOperationArg oArg, PetOperationRes oRes)
		{
			bool flag = this.CurSelectedPet != null && oArg.uid == this.CurSelectedPet.UID;
			if (flag)
			{
				this.CurSelectedPet.Canpairride = oArg.setpairride;
			}
			else
			{
				for (int i = 0; i < this.m_PetList.Count; i++)
				{
					bool flag2 = this.m_PetList[i].UID == oArg.uid;
					if (flag2)
					{
						this.m_PetList[i].Canpairride = oArg.setpairride;
						break;
					}
				}
			}
		}

		// Token: 0x06009475 RID: 38005 RVA: 0x0015E904 File Offset: 0x0015CB04
		public void OnReqReqInviteListBack(PetOperationArg oArg, PetOperationRes oRes)
		{
			this.m_petInviteInfolist.Clear();
			for (int i = 0; i < oRes.invite.Count; i++)
			{
				PetInviteInfo petInviteInfo = new PetInviteInfo();
				petInviteInfo.roleid = oRes.invite[i].roleid;
				petInviteInfo.petuid = oRes.invite[i].petuid;
				petInviteInfo.petconfigid = oRes.invite[i].petconfigid;
				petInviteInfo.rolename = oRes.invite[i].rolename;
				petInviteInfo.profession = oRes.invite[i].profession;
				petInviteInfo.ppt = oRes.invite[i].ppt;
				petInviteInfo.petppt = oRes.invite[i].petppt;
				this.m_petInviteInfolist.Add(petInviteInfo);
			}
			bool flag = this.m_petInviteInfolist.Count == 0;
			if (flag)
			{
				this.BeInvited = false;
				this.BeInvitedCount = 0U;
			}
			bool flag2 = DlgBase<PairsPetInviteView, PairsPetInviteBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<PairsPetInviteView, PairsPetInviteBehaviour>.singleton.RefreshUi();
			}
		}

		// Token: 0x06009476 RID: 38006 RVA: 0x0015EA3A File Offset: 0x0015CC3A
		public void OnReqIgnoreAllBack()
		{
			this.m_petInviteInfolist.Clear();
			this.BeInvited = false;
			this.BeInvitedCount = 0U;
		}

		// Token: 0x06009477 RID: 38007 RVA: 0x0015EA59 File Offset: 0x0015CC59
		public void OnReqOffPetPairRideBack()
		{
			XSingleton<UIManager>.singleton.CloseAllUI();
		}

		// Token: 0x06009478 RID: 38008 RVA: 0x0015EA68 File Offset: 0x0015CC68
		public void OnPetPetOperationOtherBack(PetOperationOtherArg oArg, PetOperationOtherRes oRes)
		{
			bool flag = oRes.errorcode == ErrorCode.ERR_INVALID_REQUEST;
			if (flag)
			{
				string fullName = MethodBase.GetCurrentMethod().ReflectedType.FullName;
				XSingleton<UiUtility>.singleton.OnGetInvalidRequest(fullName);
			}
			else
			{
				bool flag2 = oRes.errorcode > ErrorCode.ERR_SUCCESS;
				if (flag2)
				{
					bool flag3 = oArg.op == PetOtherOp.AgreePetPairRide;
					if (flag3)
					{
						bool flag4 = DlgBase<PairsPetInviteView, PairsPetInviteBehaviour>.singleton.IsVisible();
						if (flag4)
						{
							this.OnReqInviteList();
						}
					}
					XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
				}
				else
				{
					switch (oArg.op)
					{
					case PetOtherOp.DoPetPairRide:
					{
						bool flag5 = DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>.singleton.IsVisible();
						if (flag5)
						{
							DlgBase<XCharacterCommonMenuView, XCharacterCommonMenuBehaviour>.singleton.SetVisible(false, true);
						}
						break;
					}
					case PetOtherOp.InvitePetPairRide:
						XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("InvitedSuc"), "fece00");
						break;
					case PetOtherOp.AgreePetPairRide:
					{
						this.BeInvited = false;
						this.BeInvitedCount = 0U;
						bool flag6 = DlgBase<PairsPetInviteView, PairsPetInviteBehaviour>.singleton.IsVisible();
						if (flag6)
						{
							XSingleton<UIManager>.singleton.CloseAllUI();
						}
						break;
					}
					}
				}
			}
		}

		// Token: 0x06009479 RID: 38009 RVA: 0x0015EB84 File Offset: 0x0015CD84
		public void OnPetInviteNtfPtc(PetInviteNtf roPtc)
		{
			this.BeInvitedCount = roPtc.allcount;
			this.BeInvited = true;
		}

		// Token: 0x0600947A RID: 38010 RVA: 0x0015EB9C File Offset: 0x0015CD9C
		public uint GetFullDegreeRate()
		{
			bool flag = this.CurSelectedPet == null;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				PetInfoTable.RowData petInfo = XPetDocument.GetPetInfo(this.CurSelectedPet.ID);
				uint maxHungry = petInfo.maxHungry;
				result = 100U * this.CurSelectedPet.showFullDegree / maxHungry;
			}
			return result;
		}

		// Token: 0x0600947B RID: 38011 RVA: 0x0015EBE8 File Offset: 0x0015CDE8
		public bool OnAddItem(XEventArgs args)
		{
			XAddItemEventArgs xaddItemEventArgs = args as XAddItemEventArgs;
			for (int i = 0; i < xaddItemEventArgs.items.Count; i++)
			{
				bool flag = xaddItemEventArgs.items[i].type == 14U;
				if (flag)
				{
					this.HasFood = true;
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600947C RID: 38012 RVA: 0x0015EC48 File Offset: 0x0015CE48
		public XPet GetPet(ulong uid)
		{
			for (int i = 0; i < this.Pets.Count; i++)
			{
				bool flag = uid == this.Pets[i].UID;
				if (flag)
				{
					return this.Pets[i];
				}
			}
			return null;
		}

		// Token: 0x0600947D RID: 38013 RVA: 0x0015ECA0 File Offset: 0x0015CEA0
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			this.OnPetAllNotify(arg.PlayerInfo.petsys);
			bool flag = this.CurSelectedPet == null;
			if (flag)
			{
				this.Select(this.DefaultPet, false);
			}
			bool flag2 = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.ExpTransferHandler != null && DlgBase<XPetMainView, XPetMainBehaviour>.singleton.ExpTransferHandler.IsVisible();
			if (flag2)
			{
				DlgBase<XPetMainView, XPetMainBehaviour>.singleton.ExpTransferHandler.Select(DlgBase<XPetMainView, XPetMainBehaviour>.singleton.ExpTransferHandler.CurExpTransferSelectedIndex, false);
			}
		}

		// Token: 0x0600947E RID: 38014 RVA: 0x0015ED20 File Offset: 0x0015CF20
		public static void PreLoadPet(int maxCount = 10)
		{
			List<uint> list = ListPool<uint>.Get();
			int num = 0;
			int num2 = XPetDocument._PetItemTable.Table.Length;
			while (num < num2 && num < maxCount)
			{
				PetItemTable.RowData rowData = XPetDocument._PetItemTable.Table[num];
				uint presentID = XPetDocument.GetPresentID(rowData.petid);
				bool flag = presentID != 0U && !list.Contains(presentID);
				if (flag)
				{
					list.Add(presentID);
				}
				num++;
			}
			int i = 0;
			int count = list.Count;
			while (i < count)
			{
				string location = "Prefabs/" + XSingleton<XEntityMgr>.singleton.EntityInfo.GetByPresentID(list[i]).Prefab;
				XSingleton<XResourceLoaderMgr>.singleton.CreateInAdvance(location, 1, ECreateHideType.DisableAnim);
				i++;
			}
			ListPool<uint>.Release(list);
		}

		// Token: 0x040031EE RID: 12782
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PetDocument");

		// Token: 0x040031EF RID: 12783
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040031F0 RID: 12784
		private static PetLevelTable _LevelTable = new PetLevelTable();

		// Token: 0x040031F1 RID: 12785
		private static PetItemTable _PetItemTable = new PetItemTable();

		// Token: 0x040031F2 RID: 12786
		private static PetInfoTable _InfoTable = new PetInfoTable();

		// Token: 0x040031F3 RID: 12787
		private static PetPassiveSkillTable _SkillTable = new PetPassiveSkillTable();

		// Token: 0x040031F4 RID: 12788
		private static PetFoodTable _FoodTable = new PetFoodTable();

		// Token: 0x040031F5 RID: 12789
		private static PetMoodTipsTable _MoodTipsTable = new PetMoodTipsTable();

		// Token: 0x040031F6 RID: 12790
		private static PetBubble _BubbleTable = new PetBubble();

		// Token: 0x040031F7 RID: 12791
		private static PetSkillBook _SkillBookTable = new PetSkillBook();

		// Token: 0x040031F8 RID: 12792
		private static Dictionary<XPetDocument.PetLevel, PetLevelTable.RowData> PetLevelInfo = new Dictionary<XPetDocument.PetLevel, PetLevelTable.RowData>();

		// Token: 0x040031F9 RID: 12793
		private static Dictionary<XPetDocument.PetAction, PetBubble.RowData> PetActionData = new Dictionary<XPetDocument.PetAction, PetBubble.RowData>();

		// Token: 0x040031FB RID: 12795
		private XPetMainView _view = null;

		// Token: 0x040031FC RID: 12796
		private List<PetInviteInfo> m_petInviteInfolist = new List<PetInviteInfo>();

		// Token: 0x040031FD RID: 12797
		public string[] PetSeatBuy = XSingleton<XGlobalConfig>.singleton.GetValue("PetSeatBuy").Split(new char[]
		{
			'|'
		});

		// Token: 0x040031FE RID: 12798
		public string[] ColorLevel = XSingleton<XGlobalConfig>.singleton.GetValue("HungryColorThreshold").Split(new char[]
		{
			'|'
		});

		// Token: 0x040031FF RID: 12799
		public string[] HungryExpPercent = XSingleton<XGlobalConfig>.singleton.GetValue("HungryExpPercent").Split(new char[]
		{
			'|',
			'='
		});

		// Token: 0x04003200 RID: 12800
		public Queue<PetSingle> qExpAnimation = new Queue<PetSingle>();

		// Token: 0x04003201 RID: 12801
		public List<petGetSkill> petGetSkill = new List<petGetSkill>();

		// Token: 0x04003202 RID: 12802
		public uint PetSeat;

		// Token: 0x04003203 RID: 12803
		public static readonly uint PLAY_FULL_DEGREE_UP_FRAMES = 1U;

		// Token: 0x04003204 RID: 12804
		private int addExp;

		// Token: 0x04003205 RID: 12805
		public bool ChangeExp;

		// Token: 0x04003206 RID: 12806
		public bool ChangeFullDegree;

		// Token: 0x04003208 RID: 12808
		private bool m_beInvited = false;

		// Token: 0x04003209 RID: 12809
		public bool InPlayExpUp;

		// Token: 0x0400320A RID: 12810
		public bool HasFood = false;

		// Token: 0x0400320B RID: 12811
		public bool FightPetHungry = false;

		// Token: 0x0400320C RID: 12812
		public bool CanHasRedPoint = false;

		// Token: 0x0400320D RID: 12813
		public bool HasNewPet = false;

		// Token: 0x0400320E RID: 12814
		private List<XPet> m_PetList = new List<XPet>();

		// Token: 0x0400320F RID: 12815
		private ulong m_CurMount;

		// Token: 0x04003210 RID: 12816
		private ulong m_CurFightUID;

		// Token: 0x04003211 RID: 12817
		private int m_CurSelected = -1;

		// Token: 0x04003212 RID: 12818
		private XItemFilter m_FoodFilter = new XItemFilter();

		// Token: 0x04003213 RID: 12819
		private XItemFilter m_SkillBookFilter = new XItemFilter();

		// Token: 0x04003214 RID: 12820
		private List<XItem> m_FoodList = new List<XItem>();

		// Token: 0x04003215 RID: 12821
		private List<XItem> m_SkillBookList = new List<XItem>();

		// Token: 0x0200196A RID: 6506
		private struct PetLevel
		{
			// Token: 0x04007E1E RID: 32286
			public uint PetId;

			// Token: 0x04007E1F RID: 32287
			public uint Level;
		}

		// Token: 0x0200196B RID: 6507
		private struct PetAction
		{
			// Token: 0x04007E20 RID: 32288
			public uint PetId;

			// Token: 0x04007E21 RID: 32289
			public uint PetActionId;
		}
	}
}
