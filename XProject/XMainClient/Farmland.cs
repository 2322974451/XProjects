using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Farmland
	{

		public Farmland(uint farmlandId)
		{
			this.m_farmlandId = farmlandId;
			this.m_fxPath = "Effects/FX_Particle/UIfx/rwts_zhongzhi";
		}

		public HomePlantDocument Doc
		{
			get
			{
				bool flag = this.m_doc == null;
				if (flag)
				{
					this.m_doc = HomePlantDocument.Doc;
				}
				return this.m_doc;
			}
		}

		public uint SeedId
		{
			get
			{
				return this.m_seedId;
			}
		}

		public bool IsLock
		{
			get
			{
				return this.m_bIsLock;
			}
		}

		public bool IsNeedBreak
		{
			get
			{
				bool flag = !this.m_bIsLock;
				bool result;
				if (flag)
				{
					result = false;
				}
				else
				{
					bool flag2 = (ulong)XSingleton<XAttributeMgr>.singleton.XPlayerData.Level < (ulong)((long)this.BreakLevel);
					result = !flag2;
				}
				return result;
			}
		}

		public ulong OwnerRoleId
		{
			get
			{
				return this.m_ownerRoleId;
			}
		}

		public uint FarmlandID
		{
			get
			{
				return this.m_farmlandId;
			}
		}

		public PlantSeed.RowData Row
		{
			get
			{
				return this.m_row;
			}
		}

		public List<HomeEventLog> FarmLogList
		{
			get
			{
				return this.m_farmLogList;
			}
		}

		public bool IsFree
		{
			get
			{
				return this.m_seedId == 0U;
			}
		}

		public ulong StateLeftTime
		{
			get
			{
				return this.m_stateLeftTime;
			}
		}

		public CropState State
		{
			get
			{
				return this.m_state;
			}
		}

		public void AddStolenUid(ulong uid)
		{
			this.m_stolenRoleIdList.Add(uid);
		}

		public bool IsRipe
		{
			get
			{
				return this.m_bisRipe;
			}
			set
			{
				bool flag = this.m_bisRipe != value;
				if (flag)
				{
					this.m_bisRipe = value;
					this.Doc.SetHadRedDot();
				}
			}
		}

		public int CanSteal()
		{
			bool flag = (long)this.m_stolenRoleIdList.Count >= (long)((ulong)this.m_row.CanStealMaxTimes);
			int result;
			if (flag)
			{
				result = 1;
			}
			else
			{
				for (int i = 0; i < this.m_stolenRoleIdList.Count; i++)
				{
					bool flag2 = this.m_stolenRoleIdList[i] == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
					if (flag2)
					{
						return 2;
					}
				}
				result = 0;
			}
			return result;
		}

		public float GrowPercent
		{
			get
			{
				return this.m_growth / this.m_row.GrowUpAmount;
			}
		}

		public virtual int BreakLevel
		{
			get
			{
				return this.m_breakLevel;
			}
		}

		protected virtual Vector3 BoardRotation
		{
			get
			{
				return Vector3.zero;
			}
		}

		public uint NpcId
		{
			get
			{
				bool flag = this.m_npcId == 0U;
				if (flag)
				{
					this.m_npcId = this.Doc.GetNpcIdByFarmId(this.m_farmlandId);
				}
				return this.m_npcId;
			}
		}

		public GrowStage Stage
		{
			get
			{
				bool isFree = this.IsFree;
				GrowStage result;
				if (isFree)
				{
					result = GrowStage.None;
				}
				else
				{
					bool isRipe = this.IsRipe;
					if (isRipe)
					{
						result = GrowStage.Ripe;
					}
					else
					{
						result = this.m_growStage;
					}
				}
				return result;
			}
		}

		public float GrowSpeed
		{
			get
			{
				bool isFree = this.IsFree;
				float result;
				if (isFree)
				{
					result = 0f;
				}
				else
				{
					uint num = 0U;
					bool flag = this.State > CropState.None;
					if (flag)
					{
						num = this.m_row.BadStateGrowUpRate;
					}
					bool isHadSprite = this.Doc.HomeSprite.IsHadSprite;
					if (isHadSprite)
					{
						num += this.Doc.HomeSprite.Row.EffectGrowRate;
					}
					bool flag2 = num < 100U;
					if (flag2)
					{
						result = this.m_row.GrowUpAmountPerMinute * (100U - num) / 100f;
					}
					else
					{
						result = 1f;
					}
				}
				return result;
			}
		}

		public void SetFarmInfo(uint seedId, float growth, uint stage, ulong statLeftTime, ulong ownerId)
		{
			this.m_seedId = seedId;
			this.m_growth = growth;
			this.m_ownerRoleId = ownerId;
			this.GetSeedRowData(seedId);
			this.SetGrowStage(stage);
			bool flag = this.m_row != null;
			if (flag)
			{
				bool flag2 = (ulong)this.m_row.PlantStateCD > statLeftTime;
				if (flag2)
				{
					this.m_stateLeftTime = (ulong)this.m_row.PlantStateCD - statLeftTime;
				}
				else
				{
					this.m_stateLeftTime = 0UL;
				}
				bool flag3 = this.m_growth == 0f;
				if (flag3)
				{
					this.m_growth = this.m_row.InitUpAmount;
				}
			}
			this.m_farmLogList.Clear();
		}

		public void SetLockStatus(bool status)
		{
			this.m_bIsLock = status;
			this.SetPerfab();
		}

		public void UpdateFarmInfo(float growth, uint stage)
		{
			this.m_growth = growth;
			this.SetGrowStage(stage);
			bool flag = this.m_row != null;
			if (flag)
			{
				this.m_stateLeftTime = (ulong)this.m_row.PlantStateCD;
			}
		}

		public void SetFarmlandFree()
		{
			this.m_seedId = 0U;
			this.m_growth = 0f;
			this.m_stateLeftTime = 0UL;
			this.m_ownerRoleId = 0UL;
			this.m_farmLogList.Clear();
			this.m_stolenRoleIdList.Clear();
		}

		public long GrowLeftTime()
		{
			bool isFree = this.IsFree;
			long result;
			if (isFree)
			{
				result = 0L;
			}
			else
			{
				float num = (this.m_row.GrowUpAmount - this.m_growth) / this.GrowSpeed;
				bool flag = num < 0f;
				if (flag)
				{
					num = 0f;
				}
				result = (long)Math.Ceiling((double)num);
			}
			return result;
		}

		public void UpdateGrowth()
		{
			bool flag = this.m_growth < this.m_row.GrowUpAmount;
			if (flag)
			{
				this.m_growth += this.GrowSpeed;
			}
		}

		public void SetCropState(PlantGrowState state)
		{
			this.IsRipe = (state == PlantGrowState.growMature);
			switch (state)
			{
			case PlantGrowState.growDrought:
				this.m_state = CropState.Watering;
				break;
			case PlantGrowState.growPest:
				this.m_state = CropState.Disinsection;
				break;
			case PlantGrowState.growSluggish:
				this.m_state = CropState.Fertilizer;
				break;
			case PlantGrowState.growCD:
				this.m_state = CropState.None;
				break;
			case PlantGrowState.growMature:
				this.m_state = CropState.None;
				break;
			default:
				this.m_state = CropState.None;
				break;
			}
		}

		public void SetFarmlandLog(List<GardenEventLog> lst, uint severTime)
		{
			this.m_farmLogList.Clear();
			this.m_stolenRoleIdList.Clear();
			for (int i = 0; i < lst.Count; i++)
			{
				bool flag = lst[i].event_type == 4U;
				if (flag)
				{
					this.m_stolenRoleIdList.Add(lst[i].role_id);
				}
			}
			bool flag2 = lst.Count > 3;
			if (flag2)
			{
				for (int j = lst.Count - 3; j < lst.Count; j++)
				{
					HomeEventLog item = new HomeEventLog(lst[j], severTime);
					this.m_farmLogList.Add(item);
				}
			}
			else
			{
				for (int k = 0; k < lst.Count; k++)
				{
					HomeEventLog item2 = new HomeEventLog(lst[k], severTime);
					this.m_farmLogList.Add(item2);
				}
			}
		}

		public void AddFarmlandLog(GardenEventLog eventLog)
		{
			HomeEventLog item = new HomeEventLog(eventLog, 0U);
			this.m_farmLogList.Insert(0, item);
			bool flag = this.m_farmLogList.Count > 3;
			if (flag)
			{
				this.m_farmLogList.RemoveRange(2, this.m_farmLogList.Count - 3);
			}
		}

		public void Destroy()
		{
			this.DestroyFxEffect();
			this.DestroyPerfab();
		}

		public void SetFxEffect()
		{
			HomeTypeEnum homeType = HomePlantDocument.Doc.HomeType;
			bool flag = !this.IsFree || this.IsLock || homeType == HomeTypeEnum.None || homeType == HomeTypeEnum.OtherHome;
			if (flag)
			{
				this.DestroyFxEffect();
			}
			else
			{
				XNpc npc = XSingleton<XEntityMgr>.singleton.GetNpc(this.NpcId);
				bool flag2 = npc != null;
				if (flag2)
				{
					bool flag3 = this.m_fx != null;
					if (flag3)
					{
						this.DestroyFxEffect();
					}
					bool flag4 = this.m_fx == null;
					if (flag4)
					{
						this.m_fx = XSingleton<XFxMgr>.singleton.CreateFx(this.m_fxPath, null, true);
					}
					bool flag5 = this.m_fx != null;
					if (flag5)
					{
						this.m_fx.Play(npc.EngineObject, new Vector3(0f, npc.Height - 0.3f, 0f), Vector3.one, 1f, false, false, "", 0f);
					}
				}
			}
		}

		protected virtual void SetPerfab()
		{
		}

		public void DestroyFxEffect()
		{
			bool flag = this.m_fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx, true);
				this.m_fx = null;
			}
		}

		protected void DestroyPerfab()
		{
			XResourceLoaderMgr.SafeDestroy(ref this.m_boardGo, true);
		}

		private void GetSeedRowData(uint seedId)
		{
			this.m_row = HomePlantDocument.PlantSeedTable.GetBySeedID(seedId);
		}

		private void SetGrowStage(uint stage)
		{
			switch (stage)
			{
			case 1U:
				this.m_growStage = GrowStage.First;
				break;
			case 2U:
				this.m_growStage = GrowStage.Second;
				break;
			case 3U:
				this.m_growStage = GrowStage.Third;
				break;
			}
		}

		private XFx m_fx;

		private PlantSeed.RowData m_row;

		private string m_fxPath = "";

		protected uint m_farmlandId = 0U;

		protected uint m_npcId = 0U;

		private uint m_seedId = 0U;

		private float m_growth = 0f;

		private ulong m_stateLeftTime = 0UL;

		protected bool m_bIsLock = true;

		protected GameObject m_boardGo;

		private CropState m_state = CropState.None;

		private HomePlantDocument m_doc;

		protected int m_breakLevel = -1;

		private ulong m_ownerRoleId = 0UL;

		private GrowStage m_growStage = GrowStage.None;

		private bool m_bisRipe = false;

		private List<HomeEventLog> m_farmLogList = new List<HomeEventLog>();

		private List<ulong> m_stolenRoleIdList = new List<ulong>();
	}
}
