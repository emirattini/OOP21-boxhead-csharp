namespace boxhead.model.entities.gun
{

	using Point2D = javafx.geometry.Point2D;

	/// <summary>
	/// Class to model a single Ammo Box entity, that when is picked up refills all your ammos.
	/// </summary>
	public class Ammo : AbstractEntity
	{


		public Ammo(Point2D position, double width, double height) : base(position, EntityType.AMMO)
		{
			base.setBoundingBox(height, width);
		}
	}
}
