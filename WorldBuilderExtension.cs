using Genkit;
using XRL.World;

namespace XRL.World.WorldBuilders
{
  [JoppaWorldBuilderExtension]
  public class Gearlink_CASKOFROSEWINE_WorldBuilderExtension : IJoppaWorldBuilderExtension
  {
    /* This builder is only ever going to be modifying JoppaWorld, the main world
    seen on the overworld map. */
    private string World = "JoppaWorld";

    // The game calls this method after JoppaWorld generation takes place.
    // JoppaWorld generation includes the creation of lairs, historic ruins, villages, and more.
    public override void OnAfterBuild(JoppaWorldBuilder builder)
    {
      // Will log to the Player.log so you know that this builder extension is working.
      MetricsManager.LogInfo("Gearlink_CASKOFROSEWINE_WorldBuilderExtension running");

      // Get a mutable zone in the Ruins terrain.
			Location2D location = builder.popMutableLocationOfTerrain("Ruins");
      // Get that zone's ID.
			string zoneID = Zone.XYToID(this.World, location.X, location.Y, 10);
      /* Get a random empty cell that is reachable where we will add an object.
      Due to the nature of the object we're adding, it probably isn't striclty
      necessary to ensure the cell is empty and reachable, but this would be important
      if we were adding an objec the player was meant to see and interact with. */
			Cell emptyCell = The.ZoneManager.GetZone(zoneID).GetEmptyReachableCells().RemoveRandomElement<Cell>();
      // Actually add the object.
			emptyCell.AddObject("Gearlink_CASKOFROSEWINE_FortunadoSpawner");

      /* Will log the ID of the zone being modified to the Player.log for debugging
      purposes. In game, you can use the wish goto:zoneID to teleport to the zone
      the builder modified. */
			MetricsManager.LogInfo( zoneID );
    }
	}
}
