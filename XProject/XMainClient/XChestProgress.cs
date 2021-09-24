using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;

namespace XMainClient
{

	internal class XChestProgress
	{

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

		public List<XChest> ChestList
		{
			get
			{
				return this.m_ChestList;
			}
		}

		public XChestProgress(IXUIProgress progress)
		{
			this.m_Progress = progress;
			this.m_ProgressSprite = (progress.gameObject.GetComponent("XUISprite") as IXUISprite);
			this.m_ForegroundSprite = (progress.foreground.GetComponent("XUISprite") as IXUISprite);
		}

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

		public uint TargetExp
		{
			set
			{
				this.m_TargetExp = value;
			}
		}

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

		private void _UpdateChestPosition()
		{
			for (int i = 0; i < this.m_ChestList.Count; i++)
			{
				XChest xchest = this.m_ChestList[i];
				Vector3 position = xchest.Position;
				xchest.Position = new Vector3((float)this.m_ForegroundSprite.spriteWidth * (xchest.m_RequiredExp - this.m_StartExp) / this.m_ExpRange, position.y, position.z);
			}
		}

		private void _RefreshChestState()
		{
			for (int i = 0; i < this.m_ChestList.Count; i++)
			{
				this.m_ChestList[i].Update(this.m_CurrentExp);
			}
		}

		public bool IsExpEnough(int index)
		{
			bool flag = index >= 0 && index < this.m_ChestList.Count;
			return flag && this.m_ChestList[index].m_RequiredExp <= this.m_CurrentExp;
		}

		private IXUIProgress m_Progress;

		private IXUISprite m_ProgressSprite;

		private IXUISprite m_ForegroundSprite;

		private uint m_StartExp;

		private uint m_EndExp;

		private uint m_CurrentExp;

		private uint m_TargetExp;

		private uint m_ExpRange;

		private float m_fCurrentExp;

		private uint _IncreaseSpeed = 80U;

		private List<XChest> m_ChestList = new List<XChest>();
	}
}
