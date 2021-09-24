using System;
using System.Collections.Generic;
using System.Reflection;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XPetDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XPetDocument.uuID;
			}
		}

		public static ulong HosterId { get; set; }

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

		public int PetCountMax
		{
			get
			{
				return this.PetSeatBuy.Length;
			}
		}

		public uint BeInvitedCount { get; set; }

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

		public List<PetInviteInfo> PetInviteInfolist
		{
			get
			{
				return this.m_petInviteInfolist;
			}
		}

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

		private bool CanPlayExpUp
		{
			get
			{
				return this.ChangeExp && !this.HasGetSkillUI && !this.InPlayExpUp;
			}
		}

		public bool HasRedPoint
		{
			get
			{
				return this.CanHasRedPoint && this.FightPetHungry && this.HasFood;
			}
		}

		public List<XPet> Pets
		{
			get
			{
				return this.m_PetList;
			}
		}

		public ulong CurMount
		{
			get
			{
				return (XSingleton<XAttributeMgr>.singleton.XPlayerData.Outlook.state.type == OutLookStateType.OutLook_RidePet) ? this.m_CurMount : 0UL;
			}
		}

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

		public ulong CurFightUID
		{
			get
			{
				return this.m_CurFightUID;
			}
		}

		public int CurSelectedIndex
		{
			get
			{
				return this.m_CurSelected;
			}
		}

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

		public List<XItem> SkillBookList
		{
			get
			{
				return this.m_SkillBookList;
			}
		}

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

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AddItem, new XComponent.XEventHandler(this.OnAddItem));
		}

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

		public static bool GetWithowWind(uint id)
		{
			PetInfoTable.RowData byid = XPetDocument._InfoTable.GetByid(id);
			return byid == null || byid.WithWings == 0U;
		}

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

		public int GetAddExp(int requiredExp)
		{
			float num = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("PetExpUpSpeed"));
			return (int)Math.Ceiling((double)((float)requiredExp * num));
		}

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

		public static PetSkillBook.RowData GetPetSkillBook(uint itemID)
		{
			return XPetDocument._SkillBookTable.GetByitemid(itemID);
		}

		public static PetFoodTable.RowData GetPetFood(uint itemID)
		{
			return XPetDocument._FoodTable.GetByitemid(itemID);
		}

		public static PetInfoTable.RowData GetPetInfo(uint petID)
		{
			return XPetDocument._InfoTable.GetByid(petID);
		}

		public static PetPassiveSkillTable.RowData GetPetSkill(uint id)
		{
			return XPetDocument._SkillTable.GetByid(id);
		}

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

		public int GetRequiredExp(XPet pet)
		{
			return this.GetRequiredExp(pet.ID, pet.Level);
		}

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

		public void GetExpInfo(XPet pet, out int curExp, out int totalExp)
		{
			totalExp = this.GetRequiredExp(pet.ID, pet.showLevel);
			curExp = pet.showExp;
		}

		public bool IsMaxLevel(XPet pet)
		{
			return this.IsMaxLevel(pet.ID, pet.Level);
		}

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

		public List<XItem> GetFood()
		{
			ulong filterValue = this.m_FoodFilter.FilterValue;
			this.m_FoodList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(filterValue, ref this.m_FoodList);
			return this.m_FoodList;
		}

		public List<XItem> GetSkillBook()
		{
			ulong filterValue = this.m_SkillBookFilter.FilterValue;
			this.m_SkillBookList.Clear();
			XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemsByType(filterValue, ref this.m_SkillBookList);
			return this.m_SkillBookList;
		}

		public void ReqPetTouch()
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.type = PetOP.PetTouch;
			rpcC2G_PetOperation.oArg.uid = this.CurSelectedPet.UID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
			this.ReqPetInfo();
		}

		public void ReqBuySeat()
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.type = PetOP.ExpandSeat;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
		}

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

		public void ReqRecentMount()
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.uid = this.CurMount;
			rpcC2G_PetOperation.oArg.type = PetOP.PetFellow;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
		}

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

		public void ReqPetInfo()
		{
			RpcC2G_SynPetInfo rpcC2G_SynPetInfo = new RpcC2G_SynPetInfo();
			rpcC2G_SynPetInfo.oArg.uid = this.CurSelectedPet.UID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_SynPetInfo);
		}

		public void OnPetTouch(PetOperationArg oArg, PetOperationRes oRes)
		{
			bool flag = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				this.View.PetActionChange(XPetActionFile.CARESS, this.CurSelectedPet.ID, this.View.m_Dummy, false);
				DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshList(false);
			}
		}

		public void OnBuySeat(PetOperationArg oArg, PetOperationRes oRes)
		{
			this.PetSeat += 1U;
			bool flag = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshList(false);
			}
		}

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

		public void OnFight(PetOperationArg oArg, PetOperationRes oRes)
		{
			this.m_CurFightUID = oArg.uid;
			bool flag = DlgBase<XPetMainView, XPetMainBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XPetMainView, XPetMainBehaviour>.singleton.RefreshPage(false);
			}
		}

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

		public void OnFightPetHungry(PtcG2C_NoticeHungryDown roPtc)
		{
			bool flag = roPtc.Data.petid == this.CurFightUID && (ulong)roPtc.Data.hungry < (ulong)((long)int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("PetRedPoint")));
			if (flag)
			{
				this.FightPetHungry = true;
			}
		}

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

		public void OnReqSetTravelSet(bool status)
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.type = PetOP.SetPetPairRide;
			rpcC2G_PetOperation.oArg.uid = this.CurSelectedPet.UID;
			rpcC2G_PetOperation.oArg.setpairride = status;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
		}

		public void OnReqInviteList()
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.type = PetOP.QueryPetPairRideInvite;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
		}

		public void OnReqOffPetPairRide()
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.type = PetOP.OffPetPairRide;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
		}

		public void OnReqIgnoreAll()
		{
			RpcC2G_PetOperation rpcC2G_PetOperation = new RpcC2G_PetOperation();
			rpcC2G_PetOperation.oArg.type = PetOP.IgnorePetPairRideInvite;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperation);
		}

		public void ReqPetPetOperationOther(PetOtherOp type, ulong otherRoleId)
		{
			RpcC2G_PetOperationOther rpcC2G_PetOperationOther = new RpcC2G_PetOperationOther();
			rpcC2G_PetOperationOther.oArg.op = type;
			rpcC2G_PetOperationOther.oArg.otherroleid = otherRoleId;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_PetOperationOther);
		}

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

		public void OnReqIgnoreAllBack()
		{
			this.m_petInviteInfolist.Clear();
			this.BeInvited = false;
			this.BeInvitedCount = 0U;
		}

		public void OnReqOffPetPairRideBack()
		{
			XSingleton<UIManager>.singleton.CloseAllUI();
		}

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

		public void OnPetInviteNtfPtc(PetInviteNtf roPtc)
		{
			this.BeInvitedCount = roPtc.allcount;
			this.BeInvited = true;
		}

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

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("PetDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		private static PetLevelTable _LevelTable = new PetLevelTable();

		private static PetItemTable _PetItemTable = new PetItemTable();

		private static PetInfoTable _InfoTable = new PetInfoTable();

		private static PetPassiveSkillTable _SkillTable = new PetPassiveSkillTable();

		private static PetFoodTable _FoodTable = new PetFoodTable();

		private static PetMoodTipsTable _MoodTipsTable = new PetMoodTipsTable();

		private static PetBubble _BubbleTable = new PetBubble();

		private static PetSkillBook _SkillBookTable = new PetSkillBook();

		private static Dictionary<XPetDocument.PetLevel, PetLevelTable.RowData> PetLevelInfo = new Dictionary<XPetDocument.PetLevel, PetLevelTable.RowData>();

		private static Dictionary<XPetDocument.PetAction, PetBubble.RowData> PetActionData = new Dictionary<XPetDocument.PetAction, PetBubble.RowData>();

		private XPetMainView _view = null;

		private List<PetInviteInfo> m_petInviteInfolist = new List<PetInviteInfo>();

		public string[] PetSeatBuy = XSingleton<XGlobalConfig>.singleton.GetValue("PetSeatBuy").Split(new char[]
		{
			'|'
		});

		public string[] ColorLevel = XSingleton<XGlobalConfig>.singleton.GetValue("HungryColorThreshold").Split(new char[]
		{
			'|'
		});

		public string[] HungryExpPercent = XSingleton<XGlobalConfig>.singleton.GetValue("HungryExpPercent").Split(new char[]
		{
			'|',
			'='
		});

		public Queue<PetSingle> qExpAnimation = new Queue<PetSingle>();

		public List<petGetSkill> petGetSkill = new List<petGetSkill>();

		public uint PetSeat;

		public static readonly uint PLAY_FULL_DEGREE_UP_FRAMES = 1U;

		private int addExp;

		public bool ChangeExp;

		public bool ChangeFullDegree;

		private bool m_beInvited = false;

		public bool InPlayExpUp;

		public bool HasFood = false;

		public bool FightPetHungry = false;

		public bool CanHasRedPoint = false;

		public bool HasNewPet = false;

		private List<XPet> m_PetList = new List<XPet>();

		private ulong m_CurMount;

		private ulong m_CurFightUID;

		private int m_CurSelected = -1;

		private XItemFilter m_FoodFilter = new XItemFilter();

		private XItemFilter m_SkillBookFilter = new XItemFilter();

		private List<XItem> m_FoodList = new List<XItem>();

		private List<XItem> m_SkillBookList = new List<XItem>();

		private struct PetLevel
		{

			public uint PetId;

			public uint Level;
		}

		private struct PetAction
		{

			public uint PetId;

			public uint PetActionId;
		}
	}
}
