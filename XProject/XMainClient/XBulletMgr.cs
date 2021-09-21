using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000EDF RID: 3807
	internal class XBulletMgr : XSingleton<XBulletMgr>
	{
		// Token: 0x0600C9B2 RID: 51634 RVA: 0x002D5EFC File Offset: 0x002D40FC
		public override bool Init()
		{
			this.m_BufferPool.Init(this.blockInit, 4);
			return true;
		}

		// Token: 0x0600C9B3 RID: 51635 RVA: 0x002D5F22 File Offset: 0x002D4122
		public void GetSmallBuffer(ref SmallBuffer<XBullet.XBulletTarget> sb, int size)
		{
			this.m_BufferPool.GetBlock(ref sb, size, 0);
		}

		// Token: 0x0600C9B4 RID: 51636 RVA: 0x002D5F34 File Offset: 0x002D4134
		public void ReturnSmallBuffer(ref SmallBuffer<XBullet.XBulletTarget> sb)
		{
			this.m_BufferPool.ReturnBlock(ref sb);
		}

		// Token: 0x0600C9B5 RID: 51637 RVA: 0x002D5F44 File Offset: 0x002D4144
		public XBullet GetBullet(XBulletMgr.KeyOfBullet id)
		{
			XBullet result = null;
			this._bullets_maps.TryGetValue(id, out result);
			return result;
		}

		// Token: 0x0600C9B6 RID: 51638 RVA: 0x002D5F68 File Offset: 0x002D4168
		public void Cache(XBulletMgr.KeyOfBullet id)
		{
			this._server_temp_bullets.Add(id);
		}

		// Token: 0x0600C9B7 RID: 51639 RVA: 0x002D5F78 File Offset: 0x002D4178
		public void ShootBullet(XBullet bullet)
		{
			XBulletMgr.KeyOfBullet keyOfBullet = new XBulletMgr.KeyOfBullet(bullet.BulletCore.FirerID, bullet.ID, bullet.ExtraID);
			bool flag = !this._bullets_maps.ContainsKey(keyOfBullet);
			if (flag)
			{
				this._bullets_maps.Add(keyOfBullet, bullet);
				this._bullets.Add(bullet);
				bool flag2 = this._server_temp_bullets.Contains(keyOfBullet);
				if (flag2)
				{
					bullet.OnResult(null);
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Duplicated Bullet id ", bullet.ID.ToString(), null, null, null, null);
			}
		}

		// Token: 0x0600C9B8 RID: 51640 RVA: 0x002D6016 File Offset: 0x002D4216
		public void LogEndFx(XFx bullet)
		{
			this._bullets_end_fx.Add(bullet);
			bullet.callback = new OnFxDestroyed(this.UnLogEndFx);
		}

		// Token: 0x0600C9B9 RID: 51641 RVA: 0x002D6038 File Offset: 0x002D4238
		public void Update(float fDeltaT)
		{
			int count = this._bullets.Count;
			for (int i = count - 1; i >= 0; i--)
			{
				XBullet xbullet = this._bullets[i] as XBullet;
				xbullet.Update(fDeltaT);
				bool flag = xbullet.IsExpired();
				if (flag)
				{
					XBulletMgr.KeyOfBullet keyOfBullet = new XBulletMgr.KeyOfBullet(xbullet.BulletCore.FirerID, xbullet.ID, xbullet.ExtraID);
					xbullet.Destroy(false);
					this._server_temp_bullets.Remove(keyOfBullet);
					this._bullets_maps.Remove(keyOfBullet);
					this._bullets.RemoveAt(i);
					bool flag2 = false;
					int j = 0;
					int count2 = this._bulletsCache.Count;
					while (j < count2)
					{
						bool flag3 = this._bulletsCache[j] == null;
						if (flag3)
						{
							this._bulletsCache[j] = xbullet;
							flag2 = true;
							break;
						}
						j++;
					}
					bool flag4 = !flag2;
					if (flag4)
					{
						this._bulletsCache.Add(xbullet);
					}
				}
			}
		}

		// Token: 0x0600C9BA RID: 51642 RVA: 0x002D615C File Offset: 0x002D435C
		public XBullet CreateBullet(ulong bulletid, long token, XEntity firer, XEntity target, XSkillCore core, XResultData data, uint id, int diviation, bool demonstration, int wid)
		{
			int i = 0;
			int count = this._bulletsCache.Count;
			while (i < count)
			{
				XBullet xbullet = this._bulletsCache[i] as XBullet;
				bool flag = xbullet != null;
				if (flag)
				{
					xbullet.Init(bulletid, new XBulletCore(token, firer, target, core, data, id, diviation, demonstration, wid));
					this._bulletsCache[i] = null;
					return xbullet;
				}
				i++;
			}
			return new XBullet(bulletid, new XBulletCore(token, firer, target, core, data, id, diviation, demonstration, wid));
		}

		// Token: 0x0600C9BB RID: 51643 RVA: 0x002D61F8 File Offset: 0x002D43F8
		public void OnEnterScene()
		{
			this._bullets_end_fx.debugName = "XBulletMgr._bullets_end_fx";
			this._bullets.debugName = "XBulletMgr._bullets";
			this._bulletsCache.debugName = "XBulletMgr._bulletsCache";
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._bullets_end_fx, 256, 0);
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._bullets, 16, 0);
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._bulletsCache, 16, 0);
		}

		// Token: 0x0600C9BC RID: 51644 RVA: 0x002D6275 File Offset: 0x002D4475
		public void OnLeaveScene()
		{
			this.ClearBullets();
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._bullets_end_fx);
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._bullets);
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._bulletsCache);
		}

		// Token: 0x0600C9BD RID: 51645 RVA: 0x002D62B2 File Offset: 0x002D44B2
		public void OnLeaveStage()
		{
			this.ClearBullets();
		}

		// Token: 0x0600C9BE RID: 51646 RVA: 0x002D62BC File Offset: 0x002D44BC
		public void ClearBullets(ulong hostid)
		{
			for (int i = this._bullets.Count - 1; i >= 0; i--)
			{
				XBullet xbullet = this._bullets[i] as XBullet;
				bool flag = xbullet != null && xbullet.BulletCore.FirerID == hostid;
				if (flag)
				{
					xbullet.Expire();
					xbullet.Deny();
				}
			}
		}

		// Token: 0x0600C9BF RID: 51647 RVA: 0x002D632C File Offset: 0x002D452C
		public void ClearBullets()
		{
			for (int i = this._bullets.Count - 1; i >= 0; i--)
			{
				XBullet xbullet = this._bullets[i] as XBullet;
				xbullet.Destroy(true);
			}
			this._bullets.Clear();
			this._bullets_maps.Clear();
			this._server_temp_bullets.Clear();
			for (int j = this._bullets_end_fx.Count - 1; j >= 0; j--)
			{
				XFx fx = this._bullets_end_fx[j] as XFx;
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
			}
			this._bullets_end_fx.Clear();
		}

		// Token: 0x0600C9C0 RID: 51648 RVA: 0x002D63E9 File Offset: 0x002D45E9
		public void UnLogEndFx(XFx fx)
		{
			this._bullets_end_fx.Remove(fx);
		}

		// Token: 0x04005930 RID: 22832
		private SmallBufferPool<XBullet.XBulletTarget> m_BufferPool = new SmallBufferPool<XBullet.XBulletTarget>();

		// Token: 0x04005931 RID: 22833
		public BlockInfo[] blockInit = new BlockInfo[]
		{
			new BlockInfo(4, 128),
			new BlockInfo(8, 512)
		};

		// Token: 0x04005932 RID: 22834
		private HashSet<XBulletMgr.KeyOfBullet> _server_temp_bullets = new HashSet<XBulletMgr.KeyOfBullet>();

		// Token: 0x04005933 RID: 22835
		private SmallBuffer<object> _bullets;

		// Token: 0x04005934 RID: 22836
		private SmallBuffer<object> _bulletsCache;

		// Token: 0x04005935 RID: 22837
		private Dictionary<XBulletMgr.KeyOfBullet, XBullet> _bullets_maps = new Dictionary<XBulletMgr.KeyOfBullet, XBullet>();

		// Token: 0x04005936 RID: 22838
		private SmallBuffer<object> _bullets_end_fx;

		// Token: 0x020019E2 RID: 6626
		internal struct KeyOfBullet : IEqualityComparer<XBulletMgr.KeyOfBullet>
		{
			// Token: 0x060110D0 RID: 69840 RVA: 0x00456CBB File Offset: 0x00454EBB
			public KeyOfBullet(ulong h, ulong s, ulong t)
			{
				this.host = h;
				this.self = s;
				this.target = t;
			}

			// Token: 0x060110D1 RID: 69841 RVA: 0x00456CD4 File Offset: 0x00454ED4
			public bool Equals(XBulletMgr.KeyOfBullet x, XBulletMgr.KeyOfBullet y)
			{
				return x.host == y.host && x.self == y.self && x.target == y.target;
			}

			// Token: 0x060110D2 RID: 69842 RVA: 0x00456D14 File Offset: 0x00454F14
			public int GetHashCode(XBulletMgr.KeyOfBullet obj)
			{
				return (int)obj.host | (int)obj.self << 24;
			}

			// Token: 0x0400806A RID: 32874
			public ulong self;

			// Token: 0x0400806B RID: 32875
			public ulong host;

			// Token: 0x0400806C RID: 32876
			public ulong target;
		}
	}
}
