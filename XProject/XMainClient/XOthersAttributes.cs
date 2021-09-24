using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XOthersAttributes : XAttributes
	{

		public override uint ID
		{
			get
			{
				return XOthersAttributes.uuID;
			}
		}

		public XOthersAttributes()
		{
			this._security_Statistics = new XSecurityStatistics();
		}

		public float NormalAttackProb { get; set; }

		public float EnterFightRange { get; set; }

		public float FloatingMax { get; set; }

		public float FloatingMin { get; set; }

		public float AIStartTime { get; set; }

		public float AIActionGap { get; set; }

		public bool Blocked { get; set; }

		public bool IsWander { get; set; }

		public bool IsFixedInCD { get; set; }

		public bool Outline { get; set; }

		public int UseMyMesh { get; set; }

		public int SummonGroup { get; set; }

		public bool EndShow { get; set; }

		public bool GeneralCutScene { get; set; }

		public bool SameBillBoardByMaster { get; set; }

		public uint Fov { get; set; }

		public uint FashionTemplate { get; set; }

		public short LinkCombo { get; set; }

		public override uint Tag
		{
			get
			{
				return this.m_Tag;
			}
		}

		public override void InitAttribute(XEntityStatistics.RowData data)
		{
			base.InitAttribute(data);
			this.Init(data);
		}

		private void Init(XEntityStatistics.RowData data)
		{
			this.NormalAttackProb = data.AttackProb;
			this.EnterFightRange = data.Sight;
			this.IsWander = data.IsWander;
			this.Blocked = data.Block;
			base.BeLocked = data.BeLocked;
			this.AIStartTime = data.AIStartTime;
			this.AIActionGap = data.AIActionGap;
			this.IsFixedInCD = data.IsFixedInCD;
			this.Outline = data.Highlight;
			this.UseMyMesh = (int)data.UseMyMesh;
			this.FloatingMin = ((data.FloatHeight != null && data.FloatHeight.Length != 0) ? data.FloatHeight[0] : 0f);
			this.FloatingMax = ((data.FloatHeight != null && data.FloatHeight.Length != 0) ? data.FloatHeight[1] : 0f);
			this.EndShow = data.EndShow;
			base.SoloShow = data.SoloShow;
			this.GeneralCutScene = data.UsingGeneralCutscene;
			this.SameBillBoardByMaster = data.SameBillBoard;
			this.FashionTemplate = (uint)data.FashionTemplate;
			this.Fov = (uint)data.Fov;
			this.SummonGroup = (int)data.SummonGroup;
			this.LinkCombo = data.LinkCombo;
			this._inborn_buff = data.InBornBuff;
			this._CreateTag(data);
		}

		private void _CreateTag(XEntityStatistics.RowData data)
		{
			this.m_Tag = 0U;
			bool flag = data.Tag == null;
			if (!flag)
			{
				for (int i = 0; i < data.Tag.Length; i++)
				{
					this.m_Tag |= 1U << (int)data.Tag[i];
				}
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("Others_Attributes");

		private uint m_Tag;
	}
}
