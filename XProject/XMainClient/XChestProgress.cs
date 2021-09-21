using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000E6D RID: 3693
	internal class XChestProgress
	{
		// Token: 0x1700348E RID: 13454
		// (get) Token: 0x0600C5D2 RID: 50642 RVA: 0x002BC6C0 File Offset: 0x002BA8C0
		// (set) Token: 0x0600C5D3 RID: 50643 RVA: 0x002BC6D8 File Offset: 0x002BA8D8
		public uint IncreaseSpeed
		{
			get
			{
				return this._IncreaseSpeed;
			}
			set
			{
				this._IncreaseSpeed = value;
			}
		}

		// Token: 0x1700348F RID: 13455
		// (get) Token: 0x0600C5D4 RID: 50644 RVA: 0x002BC6E4 File Offset: 0x002BA8E4
		public List<XChest> ChestList
		{
			get
			{
				return this.m_ChestList;
			}
		}

		// Token: 0x0600C5D5 RID: 50645 RVA: 0x002BC6FC File Offset: 0x002BA8FC
		public XChestProgress(IXUIProgress progress)
		{
			this.m_Progress = progress;
			this.m_ProgressSprite = (progress.gameObject.GetComponent("XUISprite") as IXUISprite);
			this.m_ForegroundSprite = (progress.foreground.GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x0600C5D6 RID: 50646 RVA: 0x002BC764 File Offset: 0x002BA964
		public void Unload()
		{
			for (int i = 0; i < this.m_ChestList.Count; i++)
			{
				XChest xchest = this.m_ChestList[i];
				bool flag = xchest != null;
				if (flag)
				{
					xchest.ResetState();
				}
			}
			this.m_ChestList.Clear();
		}

		// Token: 0x0600C5D7 RID: 50647 RVA: 0x002BC7BC File Offset: 0x002BA9BC
		public void SetExp(uint start, uint end)
		{
			this.m_StartExp = start;
			this.m_EndExp = end;
			this.m_TargetExp = start;
			this.m_ExpRange = this.m_EndExp - this.m_StartExp;
			this._SetProgressBar();
			for (int i = 0; i < this.m_ChestList.Count; i++)
			{
				this.m_ChestList[i].ResetState();
			}
			this._RefreshChestState();
			this._UpdateChestPosition();
		}

		// Token: 0x17003490 RID: 13456
		// (set) Token: 0x0600C5D8 RID: 50648 RVA: 0x002BC835 File Offset: 0x002BAA35
		public uint TargetExp
		{
			set
			{
				this.m_TargetExp = value;
			}
		}

		// Token: 0x0600C5D9 RID: 50649 RVA: 0x002BC840 File Offset: 0x002BAA40
		public void Update(float time)
		{
			bool flag = this.m_CurrentExp != this.m_TargetExp;
			if (flag)
			{
				bool flag2 = this.m_CurrentExp > this.m_TargetExp;
				if (flag2)
				{
					this.m_CurrentExp = this.m_TargetExp;
					this.m_fCurrentExp = this.m_CurrentExp;
				}
				else
				{
					bool flag3 = this.m_fCurrentExp < this.m_StartExp;
					if (flag3)
					{
						this.m_fCurrentExp = this.m_StartExp;
					}
					this.m_fCurrentExp += this.IncreaseSpeed * time;
					this.m_CurrentExp = (uint)this.m_fCurrentExp;
					bool flag4 = this.m_CurrentExp > this.m_TargetExp;
					if (flag4)
					{
						this.m_CurrentExp = this.m_TargetExp;
					}
				}
				this._SetProgressBar();
				this._RefreshChestState();
			}
		}

		// Token: 0x0600C5DA RID: 50650 RVA: 0x002BC90C File Offset: 0x002BAB0C
		private void _SetProgressBar()
		{
			bool flag = this.m_ExpRange > 0U;
			if (flag)
			{
				this.m_Progress.value = (this.m_CurrentExp - this.m_StartExp) / this.m_ExpRange;
			}
			else
			{
				this.m_Progress.value = 0f;
			}
		}

		// Token: 0x0600C5DB RID: 50651 RVA: 0x002BC960 File Offset: 0x002BAB60
		public void AddChest(XChest chest)
		{
			this.m_ChestList.Add(chest);
			bool flag = this.m_ExpRange == 0U;
			if (!flag)
			{
				Vector3 position = chest.Position;
				chest.Position = new Vector3((float)this.m_ForegroundSprite.spriteWidth * (chest.m_RequiredExp - this.m_StartExp) / this.m_ExpRange, position.y, position.z);
			}
		}

		// Token: 0x0600C5DC RID: 50652 RVA: 0x002BC9D0 File Offset: 0x002BABD0
		private void _UpdateChestPosition()
		{
			for (int i = 0; i < this.m_ChestList.Count; i++)
			{
				XChest xchest = this.m_ChestList[i];
				Vector3 position = xchest.Position;
				xchest.Position = new Vector3((float)this.m_ForegroundSprite.spriteWidth * (xchest.m_RequiredExp - this.m_StartExp) / this.m_ExpRange, position.y, position.z);
			}
		}

		// Token: 0x0600C5DD RID: 50653 RVA: 0x002BCA4C File Offset: 0x002BAC4C
		private void _RefreshChestState()
		{
			for (int i = 0; i < this.m_ChestList.Count; i++)
			{
				this.m_ChestList[i].Update(this.m_CurrentExp);
			}
		}

		// Token: 0x0600C5DE RID: 50654 RVA: 0x002BCA90 File Offset: 0x002BAC90
		public bool IsExpEnough(int index)
		{
			bool flag = index >= 0 && index < this.m_ChestList.Count;
			return flag && this.m_ChestList[index].m_RequiredExp <= this.m_CurrentExp;
		}

		// Token: 0x040056BC RID: 22204
		private IXUIProgress m_Progress;

		// Token: 0x040056BD RID: 22205
		private IXUISprite m_ProgressSprite;

		// Token: 0x040056BE RID: 22206
		private IXUISprite m_ForegroundSprite;

		// Token: 0x040056BF RID: 22207
		private uint m_StartExp;

		// Token: 0x040056C0 RID: 22208
		private uint m_EndExp;

		// Token: 0x040056C1 RID: 22209
		private uint m_CurrentExp;

		// Token: 0x040056C2 RID: 22210
		private uint m_TargetExp;

		// Token: 0x040056C3 RID: 22211
		private uint m_ExpRange;

		// Token: 0x040056C4 RID: 22212
		private float m_fCurrentExp;

		// Token: 0x040056C5 RID: 22213
		private uint _IncreaseSpeed = 80U;

		// Token: 0x040056C6 RID: 22214
		private List<XChest> m_ChestList = new List<XChest>();
	}
}
