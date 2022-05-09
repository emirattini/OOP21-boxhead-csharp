using System.Collections.Generic;

namespace boxhead.model.entities.gun
{

	using Point2D = javafx.geometry.Point2D;

	/// <summary>
	/// Implementation of <seealso cref="AmmoSpawn"/>
	/// </summary>
	public class AmmoSpawnImpl : AmmoSpawn
	{

		private const long AMMO_TIME_RESPAWN = 8000;
		private const double AMMO_WIDTH = 40;
		private const double AMMO_HEIGTH = 40;

		private readonly ISet<Ammo> ammoActive;
		private IDictionary<Point2D, long?> ammoSpawnPoints;

		/// <summary>
		/// Constructor
		/// </summary>
		public AmmoSpawnImpl()
		{
			this.ammoActive = new HashSet<>();
			this.ammoSpawnPoints = new Dictionary<>();
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		public override ISet<Ammo> AmmoActive
		{
			get
			{
				return this.ammoActive;
			}
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>

		public override ISet<Point2D> AmmoSpawnPoints
		{
			set
			{
				value.forEach(p => this.ammoSpawnPoints.put(p, DateTimeHelperClass.CurrentUnixTimeMillis()));
			}
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>

		public override void removeAmmo(Ammo ammo)
		{
			this.ammoActive.Remove(ammo);
			this.ammoSpawnPoints.forEach((p,t) =>
			{
				if (p.Equals(ammo.Position))
				{
					this.ammoSpawnPoints.replace(p, DateTimeHelperClass.CurrentUnixTimeMillis());
				}
			});
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		public override void update()
		{
			long now = DateTimeHelperClass.CurrentUnixTimeMillis();
			this.ammoSpawnPoints.forEach((p, t) =>
			{
				if (now - t > AMMO_TIME_RESPAWN && t != 0)
				{
					this.ammoActive.Add(new Ammo(p, AMMO_WIDTH, AMMO_HEIGTH));
					this.ammoSpawnPoints.replace(p, (long) 0);
				}
			});
		}
	}
}


internal static class DateTimeHelperClass
{
	private static readonly System.DateTime Jan1st1970 = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
	internal static long CurrentUnixTimeMillis()
	{
		return (long)(System.DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
	}
}
