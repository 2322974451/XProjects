using System;
using System.Collections.Generic;
using KKSG;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C2D RID: 3117
	internal class Farmland
	{
		// Token: 0x0600B089 RID: 45193 RVA: 0x0021B960 File Offset: 0x00219B60
		public Farmland(uint farmlandId)
		{
			this.m_farmlandId = farmlandId;
			this.m_fxPath = "Effects/FX_Particle/UIfx/rwts_zhongzhi";
		}

		// Token: 0x17003120 RID: 12576
		// (get) Token: 0x0600B08A RID: 45194 RVA: 0x0021B9FC File Offset: 0x00219BFC
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

		// Token: 0x17003121 RID: 12577
		// (get) Token: 0x0600B08B RID: 45195 RVA: 0x0021BA2C File Offset: 0x00219C2C
		public uint SeedId
		{
			get
			{
				return this.m_seedId;
			}
		}

		// Token: 0x17003122 RID: 12578
		// (get) Token: 0x0600B08C RID: 45196 RVA: 0x0021BA44 File Offset: 0x00219C44
		public bool IsLock
		{
			get
			{
				return this.m_bIsLock;
			}
		}

		// Token: 0x17003123 RID: 12579
		// (get) Token: 0x0600B08D RID: 45197 RVA: 0x0021BA5C File Offset: 0x00219C5C
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

		// Token: 0x17003124 RID: 12580
		// (get) Token: 0x0600B08E RID: 45198 RVA: 0x0021BAA4 File Offset: 0x00219CA4
		public ulong OwnerRoleId
		{
			get
			{
				return this.m_ownerRoleId;
			}
		}

		// Token: 0x17003125 RID: 12581
		// (get) Token: 0x0600B08F RID: 45199 RVA: 0x0021BABC File Offset: 0x00219CBC
		public uint FarmlandID
		{
			get
			{
				return this.m_farmlandId;
			}
		}

		// Token: 0x17003126 RID: 12582
		// (get) Token: 0x0600B090 RID: 45200 RVA: 0x0021BAD4 File Offset: 0x00219CD4
		public PlantSeed.RowData Row
		{
			get
			{
				return this.m_row;
			}
		}

		// Token: 0x17003127 RID: 12583
		// (get) Token: 0x0600B091 RID: 45201 RVA: 0x0021BAEC File Offset: 0x00219CEC
		public List<HomeEventLog> FarmLogList
		{
			get
			{
				return this.m_farmLogList;
			}
		}

		// Token: 0x17003128 RID: 12584
		// (get) Token: 0x0600B092 RID: 45202 RVA: 0x0021BB04 File Offset: 0x00219D04
		public bool IsFree
		{
			get
			{
				return this.m_seedId == 0U;
			}
		}

		// Token: 0x17003129 RID: 12585
		// (get) Token: 0x0600B093 RID: 45203 RVA: 0x0021BB20 File Offset: 0x00219D20
		public ulong StateLeftTime
		{
			get
			{
				return this.m_stateLeftTime;
			}
		}

		// Token: 0x1700312A RID: 12586
		// (get) Token: 0x0600B094 RID: 45204 RVA: 0x0021BB38 File Offset: 0x00219D38
		public CropState State
		{
			get
			{
				return this.m_state;
			}
		}

		// Token: 0x0600B095 RID: 45205 RVA: 0x0021BB50 File Offset: 0x00219D50
		public void AddStolenUid(ulong uid)
		{
			this.m_stolenRoleIdList.Add(uid);
		}

		// Token: 0x1700312B RID: 12587
		// (get) Token: 0x0600B097 RID: 45207 RVA: 0x0021BB94 File Offset: 0x00219D94
		// (set) Token: 0x0600B096 RID: 45206 RVA: 0x0021BB60 File Offset: 0x00219D60
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

		// Token: 0x0600B098 RID: 45208 RVA: 0x0021BBAC File Offset: 0x00219DAC
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

		// Token: 0x1700312C RID: 12588
		// (get) Token: 0x0600B099 RID: 45209 RVA: 0x0021BC28 File Offset: 0x00219E28
		public float GrowPercent
		{
			get
			{
				return this.m_growth / this.m_row.GrowUpAmount;
			}
		}

		// Token: 0x1700312D RID: 12589
		// (get) Token: 0x0600B09A RID: 45210 RVA: 0x0021BC50 File Offset: 0x00219E50
		public virtual int BreakLevel
		{
			get
			{
				return this.m_breakLevel;
			}
		}

		// Token: 0x1700312E RID: 12590
		// (get) Token: 0x0600B09B RID: 45211 RVA: 0x0021BC68 File Offset: 0x00219E68
		protected virtual Vector3 BoardRotation
		{
			get
			{
				return Vector3.zero;
			}
		}

		// Token: 0x1700312F RID: 12591
		// (get) Token: 0x0600B09C RID: 45212 RVA: 0x0021BC80 File Offset: 0x00219E80
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

		// Token: 0x17003130 RID: 12592
		// (get) Token: 0x0600B09D RID: 45213 RVA: 0x0021BCBC File Offset: 0x00219EBC
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

		// Token: 0x17003131 RID: 12593
		// (get) Token: 0x0600B09E RID: 45214 RVA: 0x0021BCF0 File Offset: 0x00219EF0
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

		// Token: 0x0600B09F RID: 45215 RVA: 0x0021BD88 File Offset: 0x00219F88
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

		// Token: 0x0600B0A0 RID: 45216 RVA: 0x0021BE2E File Offset: 0x0021A02E
		public void SetLockStatus(bool status)
		{
			this.m_bIsLock = status;
			this.SetPerfab();
		}

		// Token: 0x0600B0A1 RID: 45217 RVA: 0x0021BE40 File Offset: 0x0021A040
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

		// Token: 0x0600B0A2 RID: 45218 RVA: 0x0021BE7C File Offset: 0x0021A07C
		public void SetFarmlandFree()
		{
			this.m_seedId = 0U;
			this.m_growth = 0f;
			this.m_stateLeftTime = 0UL;
			this.m_ownerRoleId = 0UL;
			this.m_farmLogList.Clear();
			this.m_stolenRoleIdList.Clear();
		}

		// Token: 0x0600B0A3 RID: 45219 RVA: 0x0021BEBC File Offset: 0x0021A0BC
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

		// Token: 0x0600B0A4 RID: 45220 RVA: 0x0021BF14 File Offset: 0x0021A114
		public void UpdateGrowth()
		{
			bool flag = this.m_growth < this.m_row.GrowUpAmount;
			if (flag)
			{
				this.m_growth += this.GrowSpeed;
			}
		}

		// Token: 0x0600B0A5 RID: 45221 RVA: 0x0021BF50 File Offset: 0x0021A150
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

		// Token: 0x0600B0A6 RID: 45222 RVA: 0x0021BFC0 File Offset: 0x0021A1C0
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

		// Token: 0x0600B0A7 RID: 45223 RVA: 0x0021C0B8 File Offset: 0x0021A2B8
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

		// Token: 0x0600B0A8 RID: 45224 RVA: 0x0021C108 File Offset: 0x0021A308
		public void Destroy()
		{
			this.DestroyFxEffect();
			this.DestroyPerfab();
		}

		// Token: 0x0600B0A9 RID: 45225 RVA: 0x0021C11C File Offset: 0x0021A31C
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

		// Token: 0x0600B0AA RID: 45226 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected virtual void SetPerfab()
		{
		}

		// Token: 0x0600B0AB RID: 45227 RVA: 0x0021C210 File Offset: 0x0021A410
		public void DestroyFxEffect()
		{
			bool flag = this.m_fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(this.m_fx, true);
				this.m_fx = null;
			}
		}

		// Token: 0x0600B0AC RID: 45228 RVA: 0x0021C246 File Offset: 0x0021A446
		protected void DestroyPerfab()
		{
			XResourceLoaderMgr.SafeDestroy(ref this.m_boardGo, true);
		}

		// Token: 0x0600B0AD RID: 45229 RVA: 0x0021C256 File Offset: 0x0021A456
		private void GetSeedRowData(uint seedId)
		{
			this.m_row = HomePlantDocument.PlantSeedTable.GetBySeedID(seedId);
		}

		// Token: 0x0600B0AE RID: 45230 RVA: 0x0021C26C File Offset: 0x0021A46C
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

		// Token: 0x040043DF RID: 17375
		private XFx m_fx;

		// Token: 0x040043E0 RID: 17376
		private PlantSeed.RowData m_row;

		// Token: 0x040043E1 RID: 17377
		private string m_fxPath = "";

		// Token: 0x040043E2 RID: 17378
		protected uint m_farmlandId = 0U;

		// Token: 0x040043E3 RID: 17379
		protected uint m_npcId = 0U;

		// Token: 0x040043E4 RID: 17380
		private uint m_seedId = 0U;

		// Token: 0x040043E5 RID: 17381
		private float m_growth = 0f;

		// Token: 0x040043E6 RID: 17382
		private ulong m_stateLeftTime = 0UL;

		// Token: 0x040043E7 RID: 17383
		protected bool m_bIsLock = true;

		// Token: 0x040043E8 RID: 17384
		protected GameObject m_boardGo;

		// Token: 0x040043E9 RID: 17385
		private CropState m_state = CropState.None;

		// Token: 0x040043EA RID: 17386
		private HomePlantDocument m_doc;

		// Token: 0x040043EB RID: 17387
		protected int m_breakLevel = -1;

		// Token: 0x040043EC RID: 17388
		private ulong m_ownerRoleId = 0UL;

		// Token: 0x040043ED RID: 17389
		private GrowStage m_growStage = GrowStage.None;

		// Token: 0x040043EE RID: 17390
		private bool m_bisRipe = false;

		// Token: 0x040043EF RID: 17391
		private List<HomeEventLog> m_farmLogList = new List<HomeEventLog>();

		// Token: 0x040043F0 RID: 17392
		private List<ulong> m_stolenRoleIdList = new List<ulong>();
	}
}
