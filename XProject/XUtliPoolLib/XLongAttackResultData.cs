using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x020001FD RID: 509
	[Serializable]
	public class XLongAttackResultData
	{
		// Token: 0x06000BF1 RID: 3057 RVA: 0x0003E7A4 File Offset: 0x0003C9A4
		public XLongAttackResultData()
		{
			this.WithCollision = true;
			this.TriggerOnce = true;
			this.EndFx_Ground = true;
			this.FlyWithTerrain = true;
			this.AimTargetCenter = true;
			this.StaticCollider = true;
		}

		// Token: 0x04000656 RID: 1622
		[SerializeField]
		public XResultBulletType Type = XResultBulletType.Sphere;

		// Token: 0x04000657 RID: 1623
		[SerializeField]
		[DefaultValue(true)]
		public bool WithCollision;

		// Token: 0x04000658 RID: 1624
		[SerializeField]
		[DefaultValue(false)]
		public bool Follow;

		// Token: 0x04000659 RID: 1625
		[SerializeField]
		[DefaultValue(0f)]
		public float Runningtime;

		// Token: 0x0400065A RID: 1626
		[SerializeField]
		[DefaultValue(0f)]
		public float Stickytime;

		// Token: 0x0400065B RID: 1627
		[SerializeField]
		[DefaultValue(0f)]
		public float Velocity;

		// Token: 0x0400065C RID: 1628
		[SerializeField]
		[DefaultValue(0f)]
		public float Radius;

		// Token: 0x0400065D RID: 1629
		[SerializeField]
		[DefaultValue(0f)]
		public float Palstance;

		// Token: 0x0400065E RID: 1630
		[SerializeField]
		[DefaultValue(0f)]
		public float RingVelocity;

		// Token: 0x0400065F RID: 1631
		[SerializeField]
		[DefaultValue(0f)]
		public float RingRadius;

		// Token: 0x04000660 RID: 1632
		[SerializeField]
		[DefaultValue(false)]
		public bool RingFull;

		// Token: 0x04000661 RID: 1633
		[SerializeField]
		public string Prefab = null;

		// Token: 0x04000662 RID: 1634
		[SerializeField]
		[DefaultValue(true)]
		public bool TriggerOnce;

		// Token: 0x04000663 RID: 1635
		[SerializeField]
		[DefaultValue(false)]
		public bool TriggerAtEnd;

		// Token: 0x04000664 RID: 1636
		[SerializeField]
		[DefaultValue(0f)]
		public float TriggerAtEnd_Cycle;

		// Token: 0x04000665 RID: 1637
		[SerializeField]
		[DefaultValue(0)]
		public int TriggerAtEnd_Count;

		// Token: 0x04000666 RID: 1638
		[SerializeField]
		[DefaultValue(0)]
		public int FireAngle;

		// Token: 0x04000667 RID: 1639
		[SerializeField]
		public string HitGround_Fx = null;

		// Token: 0x04000668 RID: 1640
		[SerializeField]
		[DefaultValue(0f)]
		public float HitGroundFx_LifeTime;

		// Token: 0x04000669 RID: 1641
		[SerializeField]
		public string End_Fx = null;

		// Token: 0x0400066A RID: 1642
		[SerializeField]
		[DefaultValue(0f)]
		public float EndFx_LifeTime;

		// Token: 0x0400066B RID: 1643
		[SerializeField]
		[DefaultValue(true)]
		public bool EndFx_Ground;

		// Token: 0x0400066C RID: 1644
		[SerializeField]
		public string Audio = null;

		// Token: 0x0400066D RID: 1645
		[SerializeField]
		public AudioChannel Audio_Channel = AudioChannel.Skill;

		// Token: 0x0400066E RID: 1646
		[SerializeField]
		public string End_Audio = null;

		// Token: 0x0400066F RID: 1647
		[SerializeField]
		public AudioChannel End_Audio_Channel = AudioChannel.Skill;

		// Token: 0x04000670 RID: 1648
		[SerializeField]
		[DefaultValue(true)]
		public bool FlyWithTerrain;

		// Token: 0x04000671 RID: 1649
		[SerializeField]
		[DefaultValue(false)]
		public bool IsPingPong;

		// Token: 0x04000672 RID: 1650
		[SerializeField]
		[DefaultValue(true)]
		public bool AimTargetCenter;

		// Token: 0x04000673 RID: 1651
		[SerializeField]
		[DefaultValue(0f)]
		public float At_X;

		// Token: 0x04000674 RID: 1652
		[SerializeField]
		[DefaultValue(0f)]
		public float At_Y;

		// Token: 0x04000675 RID: 1653
		[SerializeField]
		[DefaultValue(0f)]
		public float At_Z;

		// Token: 0x04000676 RID: 1654
		[SerializeField]
		[DefaultValue(0f)]
		public float Refine_Cycle;

		// Token: 0x04000677 RID: 1655
		[SerializeField]
		[DefaultValue(0)]
		public int Refine_Count;

		// Token: 0x04000678 RID: 1656
		[SerializeField]
		[DefaultValue(false)]
		public bool AutoRefine_at_Half;

		// Token: 0x04000679 RID: 1657
		[SerializeField]
		[DefaultValue(true)]
		public bool StaticCollider;

		// Token: 0x0400067A RID: 1658
		[SerializeField]
		[DefaultValue(false)]
		public bool DynamicCollider;

		// Token: 0x0400067B RID: 1659
		[SerializeField]
		[DefaultValue(false)]
		public bool Manipulation;

		// Token: 0x0400067C RID: 1660
		[SerializeField]
		[DefaultValue(false)]
		public bool Reinforce;

		// Token: 0x0400067D RID: 1661
		[SerializeField]
		[DefaultValue(0f)]
		public float ManipulationRadius;

		// Token: 0x0400067E RID: 1662
		[SerializeField]
		[DefaultValue(0f)]
		public float ManipulationForce;
	}
}
